using System;
using System.Data;
using System.Text.RegularExpressions;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;

namespace CliniqueVeterinaire
{
    public partial class FormGestionStock : Form
    {
        private ConnexionBD connexionBD;

        public FormGestionStock()
        {
            InitializeComponent();
            connexionBD = new ConnexionBD();
            ChargerMedicaments();
            groupBoxForm.Enabled = false;
        }

        private void ChargerMedicaments()
        {
            using (SqlConnection conn = connexionBD.GetConnection())
            {
                try
                {
                    conn.Open();
                    string sql = @"SELECT Id, Nom, Description, PrixUnitaire, QuantiteStock, 
                                          SeuilAlerte, DateExpiration, Fournisseur 
                                   FROM Medicament 
                                   ORDER BY Nom";
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvMedicaments.DataSource = dt;
                    dgvMedicaments.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                    if (dgvMedicaments.Columns["Id"] != null)
                        dgvMedicaments.Columns["Id"].Visible = false;

                    if (dgvMedicaments.Columns["DateExpiration"] != null)
                        dgvMedicaments.Columns["DateExpiration"].DefaultCellStyle.Format = "dd/MM/yyyy";

                    if (dgvMedicaments.Columns["PrixUnitaire"] != null)
                        dgvMedicaments.Columns["PrixUnitaire"].DefaultCellStyle.Format = "0.00";

                    VerifierAlertes();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erreur: {ex.Message}", "Erreur",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void VerifierAlertes()
        {
            using (SqlConnection conn = connexionBD.GetConnection())
            {
                try
                {
                    conn.Open();

                    string sqlLowStock = "SELECT Nom, QuantiteStock FROM Medicament WHERE QuantiteStock <= SeuilAlerte";
                    SqlCommand cmdLowStock = new SqlCommand(sqlLowStock, conn);
                    SqlDataReader reader = cmdLowStock.ExecuteReader();

                    string alertStock = "";
                    while (reader.Read())
                        alertStock += $"⚠️ {reader["Nom"]}: Stock = {reader["QuantiteStock"]}\n";
                    reader.Close();

                    if (alertStock != "")
                    {
                        lblAlerteStock.Text = alertStock;
                        lblAlerteStock.ForeColor = System.Drawing.Color.Red;
                    }
                    else
                    {
                        lblAlerteStock.Text = "✅ Tous les stocks sont suffisants";
                        lblAlerteStock.ForeColor = System.Drawing.Color.Green;
                    }

                    string sqlExpiring = @"SELECT Nom, DateExpiration FROM Medicament 
                                           WHERE DateExpiration <= DATEADD(MONTH, 3, GETDATE()) 
                                           AND DateExpiration > GETDATE()";
                    SqlCommand cmdExpiring = new SqlCommand(sqlExpiring, conn);
                    reader = cmdExpiring.ExecuteReader();

                    string alertExpiration = "";
                    while (reader.Read())
                    {
                        DateTime expDate = (DateTime)reader["DateExpiration"];
                        alertExpiration += $"⚠️ {reader["Nom"]}: Expire le {expDate:dd/MM/yyyy}\n";
                    }
                    reader.Close();

                    if (alertExpiration != "")
                    {
                        lblAlerteExpiration.Text = alertExpiration;
                        lblAlerteExpiration.ForeColor = System.Drawing.Color.Orange;
                    }
                    else
                    {
                        lblAlerteExpiration.Text = "✅ Aucun médicament n'expire bientôt";
                        lblAlerteExpiration.ForeColor = System.Drawing.Color.Green;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erreur: {ex.Message}", "Erreur",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // ========== VALIDATIONS ==========
        private bool ValiderChamps(out decimal prix, out int quantite, out int seuil)
        {
            prix = 0; quantite = 0; seuil = 5;

            // ===== ÉTAPE 1 : VÉRIFIER TOUS LES CHAMPS VIDES =====
            string champsVides = "";
            if (string.IsNullOrWhiteSpace(txtNom.Text)) champsVides += "- Nom\n";
            if (string.IsNullOrWhiteSpace(txtDescription.Text)) champsVides += "- Description\n";
            if (string.IsNullOrWhiteSpace(txtPrix.Text)) champsVides += "- Prix unitaire\n";
            if (string.IsNullOrWhiteSpace(txtQuantite.Text)) champsVides += "- Quantité en stock\n";
            if (string.IsNullOrWhiteSpace(txtSeuil.Text)) champsVides += "- Seuil d'alerte\n";
            if (string.IsNullOrWhiteSpace(txtFournisseur.Text)) champsVides += "- Fournisseur\n";

            if (champsVides != "")
            {
                MessageBox.Show("Les champs suivants sont obligatoires :\n\n" + champsVides,
                    "Champs manquants", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // ===== ÉTAPE 2 : VALIDATION DU NOM =====

            // Nom ne doit pas contenir de chiffres
            if (Regex.IsMatch(txtNom.Text.Trim(), @"\d"))
            {
                MessageBox.Show("Le nom du médicament ne doit pas contenir de chiffres.",
                    "Nom invalide", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNom.Focus();
                return false;
            }

            // Nom ne doit pas contenir de caractères spéciaux
            if (!Regex.IsMatch(txtNom.Text.Trim(), @"^[a-zA-ZÀ-ÿ\s\-]+$"))
            {
                MessageBox.Show("Le nom du médicament ne doit contenir que des lettres.",
                    "Nom invalide", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNom.Focus();
                return false;
            }

            // Nom minimum 2 caractères
            if (txtNom.Text.Trim().Length < 2)
            {
                MessageBox.Show("Le nom du médicament doit contenir au moins 2 caractères.",
                    "Nom invalide", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNom.Focus();
                return false;
            }

            // ===== ÉTAPE 3 : VALIDATION DU FOURNISSEUR =====

            // Fournisseur ne doit pas contenir de chiffres
            if (Regex.IsMatch(txtFournisseur.Text.Trim(), @"\d"))
            {
                MessageBox.Show("Le nom du fournisseur ne doit pas contenir de chiffres.",
                    "Fournisseur invalide", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFournisseur.Focus();
                return false;
            }

            // Fournisseur ne doit pas contenir de caractères spéciaux
            if (!Regex.IsMatch(txtFournisseur.Text.Trim(), @"^[a-zA-ZÀ-ÿ\s\-]+$"))
            {
                MessageBox.Show("Le nom du fournisseur ne doit contenir que des lettres.",
                    "Fournisseur invalide", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFournisseur.Focus();
                return false;
            }

            // ===== ÉTAPE 4 : VALIDATION DU PRIX =====
            if (!decimal.TryParse(txtPrix.Text.Replace(",", "."), System.Globalization.NumberStyles.Any,
                System.Globalization.CultureInfo.InvariantCulture, out prix) || prix <= 0)
            {
                MessageBox.Show("Le prix doit être un nombre décimal positif (ex: 12.50).",
                    "Prix invalide", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPrix.Focus();
                return false;
            }

            // ===== ÉTAPE 5 : VALIDATION DE LA QUANTITÉ =====
            if (!int.TryParse(txtQuantite.Text, out quantite) || quantite < 0)
            {
                MessageBox.Show("La quantité doit être un nombre entier positif ou zéro.",
                    "Quantité invalide", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtQuantite.Focus();
                return false;
            }

            // ===== ÉTAPE 6 : VALIDATION DU SEUIL =====
            if (!int.TryParse(txtSeuil.Text, out seuil) || seuil < 0)
            {
                MessageBox.Show("Le seuil d'alerte doit être un nombre entier positif.",
                    "Seuil invalide", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSeuil.Focus();
                return false;
            }

            // ===== ÉTAPE 7 : VALIDATION DE LA DATE =====
            if (dtpExpiration.Value.Date < DateTime.Today)
            {
                MessageBox.Show("La date d'expiration ne peut pas être dans le passé.",
                    "Date invalide", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpExpiration.Focus();
                return false;
            }

            return true;
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            groupBoxForm.Enabled = true;
            groupBoxForm.Text = "Ajouter un médicament";
            ClearForm();
            txtNom.Focus();
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            if (dgvMedicaments.CurrentRow == null)
            {
                MessageBox.Show("Veuillez sélectionner un médicament à modifier",
                    "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            groupBoxForm.Enabled = true;
            groupBoxForm.Text = "Modifier un médicament";

            DataGridViewRow row = dgvMedicaments.CurrentRow;
            txtNom.Text = row.Cells["Nom"].Value?.ToString() ?? "";
            txtDescription.Text = row.Cells["Description"].Value?.ToString() ?? "";
            txtPrix.Text = row.Cells["PrixUnitaire"].Value?.ToString() ?? "";
            txtQuantite.Text = row.Cells["QuantiteStock"].Value?.ToString() ?? "";
            txtSeuil.Text = row.Cells["SeuilAlerte"].Value?.ToString() ?? "";

            if (row.Cells["DateExpiration"].Value != null && row.Cells["DateExpiration"].Value != DBNull.Value)
                dtpExpiration.Value = (DateTime)row.Cells["DateExpiration"].Value;

            txtFournisseur.Text = row.Cells["Fournisseur"].Value?.ToString() ?? "";
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            if (dgvMedicaments.CurrentRow == null)
            {
                MessageBox.Show("Veuillez sélectionner un médicament à supprimer",
                    "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult result = MessageBox.Show("Voulez-vous vraiment supprimer ce médicament ?",
                "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                int id = (int)dgvMedicaments.CurrentRow.Cells["Id"].Value;

                using (SqlConnection conn = connexionBD.GetConnection())
                {
                    try
                    {
                        conn.Open();
                        string sql = "DELETE FROM Medicament WHERE Id = @Id";
                        SqlCommand cmd = new SqlCommand(sql, conn);
                        cmd.Parameters.AddWithValue("@Id", id);
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Médicament supprimé avec succès",
                            "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ChargerMedicaments();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Erreur: {ex.Message}",
                            "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnActualiser_Click(object sender, EventArgs e)
        {
            ChargerMedicaments();
            ClearForm();
            groupBoxForm.Enabled = false;
            MessageBox.Show("Liste des médicaments actualisée",
                "Actualisation", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            if (!ValiderChamps(out decimal prix, out int quantite, out int seuil))
                return;

            using (SqlConnection conn = connexionBD.GetConnection())
            {
                try
                {
                    conn.Open();

                    if (groupBoxForm.Text == "Ajouter un médicament")
                    {
                        string sql = @"INSERT INTO Medicament (Nom, Description, PrixUnitaire, QuantiteStock, SeuilAlerte, DateExpiration, Fournisseur) 
                                       VALUES (@Nom, @Description, @Prix, @Quantite, @Seuil, @DateExp, @Fournisseur)";
                        SqlCommand cmd = new SqlCommand(sql, conn);
                        cmd.Parameters.AddWithValue("@Nom", txtNom.Text.Trim());
                        cmd.Parameters.AddWithValue("@Description", txtDescription.Text.Trim());
                        cmd.Parameters.AddWithValue("@Prix", prix);
                        cmd.Parameters.AddWithValue("@Quantite", quantite);
                        cmd.Parameters.AddWithValue("@Seuil", seuil);
                        cmd.Parameters.AddWithValue("@DateExp", dtpExpiration.Value);
                        cmd.Parameters.AddWithValue("@Fournisseur", txtFournisseur.Text.Trim());
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Médicament ajouté avec succès",
                            "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        int id = (int)dgvMedicaments.CurrentRow.Cells["Id"].Value;
                        string sql = @"UPDATE Medicament SET Nom=@Nom, Description=@Description, PrixUnitaire=@Prix, 
                                       QuantiteStock=@Quantite, SeuilAlerte=@Seuil, DateExpiration=@DateExp, 
                                       Fournisseur=@Fournisseur WHERE Id=@Id";
                        SqlCommand cmd = new SqlCommand(sql, conn);
                        cmd.Parameters.AddWithValue("@Nom", txtNom.Text.Trim());
                        cmd.Parameters.AddWithValue("@Description", txtDescription.Text.Trim());
                        cmd.Parameters.AddWithValue("@Prix", prix);
                        cmd.Parameters.AddWithValue("@Quantite", quantite);
                        cmd.Parameters.AddWithValue("@Seuil", seuil);
                        cmd.Parameters.AddWithValue("@DateExp", dtpExpiration.Value);
                        cmd.Parameters.AddWithValue("@Fournisseur", txtFournisseur.Text.Trim());
                        cmd.Parameters.AddWithValue("@Id", id);
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Médicament modifié avec succès",
                            "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    groupBoxForm.Enabled = false;
                    ClearForm();
                    ChargerMedicaments();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erreur: {ex.Message}",
                        "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnFermer_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ClearForm()
        {
            txtNom.Text = "";
            txtDescription.Text = "";
            txtPrix.Text = "";
            txtQuantite.Text = "";
            txtSeuil.Text = "";
            dtpExpiration.Value = DateTime.Now.AddMonths(6);
            txtFournisseur.Text = "";
        }

        private void FormGestionStock_Load(object sender, EventArgs e)
        {

        }
    }
}