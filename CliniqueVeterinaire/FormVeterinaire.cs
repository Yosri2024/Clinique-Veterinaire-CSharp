using System;
using System.Data;
using System.Text.RegularExpressions;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;

namespace CliniqueVeterinaire
{
    public partial class FormVeterinaire : Form
    {
        private ConnexionBD connexionBD;
        private string nomUtilisateur;
        private string prenomUtilisateur;

        public FormVeterinaire(string nom, string prenom)
        {
            InitializeComponent();
            connexionBD = new ConnexionBD();
            nomUtilisateur = nom;
            prenomUtilisateur = prenom;
            lblWelcomeVeto.Text = $"Bienvenue, Dr {prenom} {nom} !";

            ChargerPlanning();
            ChargerComboBoxes();
        }

        // ========== VALIDATIONS ==========

        private bool IsLettersOnly(string text)
        {
            return Regex.IsMatch(text.Trim(), @"^[a-zA-ZÀ-ÿ\s\-]+$");
        }

        private bool IsValidPoids(string poids, out decimal value)
        {
            value = 0;
            if (string.IsNullOrWhiteSpace(poids)) return true;
            if (!decimal.TryParse(poids.Replace(",", "."),
                System.Globalization.NumberStyles.Any,
                System.Globalization.CultureInfo.InvariantCulture, out value))
                return false;
            if (value <= 0 || value > 200) return false;
            return true;
        }

        private bool IsValidTemperature(string temp, out decimal value)
        {
            value = 0;
            if (string.IsNullOrWhiteSpace(temp)) return true;
            if (!decimal.TryParse(temp.Replace(",", "."),
                System.Globalization.NumberStyles.Any,
                System.Globalization.CultureInfo.InvariantCulture, out value))
                return false;
            if (value < 30 || value > 45) return false;
            return true;
        }

        // ========== CHARGER COMBOBOX ==========
        private void ChargerComboBoxes()
        {
            using (SqlConnection conn = connexionBD.GetConnection())
            {
                conn.Open();
                string sql = "SELECT Id, Nom FROM Animal ORDER BY Nom";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                cmbAnimalConsult.Items.Clear();
                while (reader.Read())
                {
                    cmbAnimalConsult.Items.Add(new KeyValuePair<int, string>(
                        (int)reader["Id"], reader["Nom"].ToString()));
                }
                reader.Close();
            }
            cmbAnimalConsult.DisplayMember = "Value";
            cmbAnimalConsult.ValueMember = "Key";
        }

        // ========== TAB 1: PLANNING ==========
        private void ChargerPlanning()
        {
            using (SqlConnection conn = connexionBD.GetConnection())
            {
                try
                {
                    conn.Open();
                    string sql = @"SELECT r.Id, a.Nom AS Animal, p.Nom + ' ' + p.Prenom AS Proprietaire,
                                          r.DateHeure, r.Motif, r.Statut
                                   FROM RendezVous r
                                   JOIN Animal a ON r.AnimalId = a.Id
                                   JOIN Proprietaire p ON a.ProprietaireId = p.Id
                                   WHERE r.VeterinaireId = (SELECT Id FROM Utilisateur WHERE Login = 'vet')
                                   AND CAST(r.DateHeure AS DATE) = CAST(GETDATE() AS DATE)
                                   ORDER BY r.DateHeure";
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvPlanning.DataSource = dt;
                    dgvPlanning.Columns["Id"].Visible = false;
                    dgvPlanning.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"❌ Erreur: {ex.Message}", "Erreur",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnActualiserPlanning_Click(object sender, EventArgs e)
        {
            ChargerPlanning();
            MessageBox.Show("✅ Planning actualisé", "Actualisation",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // ========== TAB 2: CONSULTATIONS ==========
        private void cmbAnimalConsult_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbAnimalConsult.SelectedIndex == -1) return;

            int animalId = ((KeyValuePair<int, string>)cmbAnimalConsult.SelectedItem).Key;

            using (SqlConnection conn = connexionBD.GetConnection())
            {
                try
                {
                    conn.Open();
                    string sql = @"SELECT a.Nom, a.Espece, a.Race, a.Sexe, a.DateNaissance, a.Couleur,
                                          p.Nom + ' ' + p.Prenom AS Proprietaire, p.Telephone
                                   FROM Animal a
                                   JOIN Proprietaire p ON a.ProprietaireId = p.Id
                                   WHERE a.Id = @Id";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@Id", animalId);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        txtRaceConsult.Text = reader["Race"]?.ToString() ?? "";
                        txtSexeConsult.Text = reader["Sexe"]?.ToString() ?? "";
                        dtpDateNaissConsult.Value = reader["DateNaissance"] != DBNull.Value
                            ? (DateTime)reader["DateNaissance"]
                            : DateTime.Now.AddYears(-1);
                    }
                    reader.Close();

                    ChargerHistoriqueConsultations(animalId);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"❌ Erreur: {ex.Message}", "Erreur",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ChargerHistoriqueConsultations(int animalId)
        {
            using (SqlConnection conn = connexionBD.GetConnection())
            {
                try
                {
                    conn.Open();
                    string sql = @"SELECT Id, DateConsultation, Diagnostic, Traitement, Poids, Temperature
                                   FROM Consultation
                                   WHERE AnimalId = @AnimalId
                                   ORDER BY DateConsultation DESC";
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
                    adapter.SelectCommand.Parameters.AddWithValue("@AnimalId", animalId);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvHistoriqueConsult.DataSource = dt;
                    dgvHistoriqueConsult.Columns["Id"].Visible = false;
                    if (dgvHistoriqueConsult.Columns["DateConsultation"] != null)
                        dgvHistoriqueConsult.Columns["DateConsultation"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
                    dgvHistoriqueConsult.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"❌ Erreur: {ex.Message}", "Erreur",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnChargerAnimal_Click(object sender, EventArgs e)
        {
            if (cmbAnimalConsult.SelectedIndex == -1)
            {
                MessageBox.Show("❌ Veuillez sélectionner un animal", "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            cmbAnimalConsult_SelectedIndexChanged(sender, e);
        }

        private void btnEnregistrerConsult_Click(object sender, EventArgs e)
        {
            // ===== ÉTAPE 1: Animal sélectionné =====
            if (cmbAnimalConsult.SelectedIndex == -1)
            {
                MessageBox.Show("❌ Veuillez sélectionner un animal.",
                    "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // ===== ÉTAPE 2: Champs obligatoires =====

            string champsVides = "";
            if (string.IsNullOrWhiteSpace(txtDiagnostic.Text)) champsVides += "- Diagnostic\n";
            if (string.IsNullOrWhiteSpace(txtTraitement.Text)) champsVides += "- Traitement\n";
            if (string.IsNullOrWhiteSpace(txtPoids.Text)) champsVides += "- Poids\n";
            if (string.IsNullOrWhiteSpace(txtTemperature.Text)) champsVides += "- Température\n";
            if (string.IsNullOrWhiteSpace(txtRemarques.Text)) champsVides += "- Remarques\n";
            if (champsVides != "")
            {
                MessageBox.Show("Les champs suivants sont obligatoires :\n\n" + champsVides,
                    "Champs manquants", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDiagnostic.Focus();
                return;
            }

            // ===== ÉTAPE 3: Diagnostic =====
            if (txtDiagnostic.Text.Trim().Length < 3)
            {
                MessageBox.Show("❌ Diagnostic invalide.\n\n- Minimum 3 caractères.",
                    "Diagnostic invalide", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDiagnostic.Focus();
                return;
            }

            if (Regex.IsMatch(txtDiagnostic.Text.Trim(), @"^\d+$"))
            {
                MessageBox.Show("❌ Diagnostic invalide.\n\n- Ne peut pas contenir uniquement des chiffres.",
                    "Diagnostic invalide", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDiagnostic.Focus();
                return;
            }

            // ===== ÉTAPE 4: Traitement =====
            if (txtTraitement.Text.Trim().Length < 3)
            {
                MessageBox.Show("❌ Traitement invalide.\n\n- Minimum 3 caractères.",
                    "Traitement invalide", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTraitement.Focus();
                return;
            }

            if (Regex.IsMatch(txtTraitement.Text.Trim(), @"^\d+$"))
            {
                MessageBox.Show("❌ Traitement invalide.\n\n- Ne peut pas contenir uniquement des chiffres.",
                    "Traitement invalide", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTraitement.Focus();
                return;
            }

            // ===== ÉTAPE 5: Poids (OPTIONNEL) =====
            decimal poidsConsult = 0;
            if (!string.IsNullOrWhiteSpace(txtPoids.Text))
            {
                if (!IsValidPoids(txtPoids.Text, out poidsConsult))
                {
                    MessageBox.Show("❌ Poids invalide.\n\n- Nombre décimal positif.\n- Maximum 200 kg.\n- Exemple: 12.5\n- Ou laissez vide",
                        "Poids invalide", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPoids.Focus();
                    return;
                }
            }

            // ===== ÉTAPE 6: Température (OPTIONNELLE) =====
            decimal temperatureConsult = 0;
            if (!string.IsNullOrWhiteSpace(txtTemperature.Text))
            {
                if (!IsValidTemperature(txtTemperature.Text, out temperatureConsult))
                {
                    MessageBox.Show("❌ Température invalide.\n\n- Nombre décimal.\n- Entre 30°C et 45°C.\n- Exemple: 38.5\n- Ou laissez vide",
                        "Température invalide", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTemperature.Focus();
                    return;
                }
            }

            int animalId = ((KeyValuePair<int, string>)cmbAnimalConsult.SelectedItem).Key;

            using (SqlConnection conn = connexionBD.GetConnection())
            {
                try
                {
                    conn.Open();
                    string sql = @"INSERT INTO Consultation (DateConsultation, Diagnostic, Traitement, Poids, Temperature, AnimalId, VeterinaireId) 
                           VALUES (@DateConsultation, @Diagnostic, @Traitement, @Poids, @Temperature, @AnimalId, 
                           (SELECT Id FROM Utilisateur WHERE Login = 'vet'))";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@DateConsultation", DateTime.Now);
                    cmd.Parameters.AddWithValue("@Diagnostic", txtDiagnostic.Text.Trim());
                    cmd.Parameters.AddWithValue("@Traitement", txtTraitement.Text.Trim());
                    cmd.Parameters.AddWithValue("@Poids", poidsConsult == 0 ? (object)DBNull.Value : poidsConsult);
                    cmd.Parameters.AddWithValue("@Temperature", temperatureConsult == 0 ? (object)DBNull.Value : temperatureConsult);
                    cmd.Parameters.AddWithValue("@AnimalId", animalId);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("✅ Consultation enregistrée avec succès", "Succès",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Clear form
                    txtDiagnostic.Text = "";
                    txtTraitement.Text = "";
                    txtPoids.Text = "";
                    txtTemperature.Text = "";
                    txtRemarques.Text = "";

                    ChargerHistoriqueConsultations(animalId);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"❌ Erreur: {ex.Message}", "Erreur",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        // ========== TAB 3: DOSSIER MÉDICAL ==========
        private void btnRechercher_Click(object sender, EventArgs e)
        {
            // ===== Champ recherche vide =====
            if (string.IsNullOrWhiteSpace(txtRechercheNom.Text))
            {
                MessageBox.Show("❌ Veuillez saisir un nom d'animal.",
                    "Champ manquant", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtRechercheNom.Focus();
                return;
            }

            // ===== Minimum 2 caractères =====
            if (txtRechercheNom.Text.Trim().Length < 2)
            {
                MessageBox.Show("❌ Nom invalide.\n\n- Minimum 2 caractères.",
                    "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtRechercheNom.Focus();
                return;
            }

            // ===== Pas uniquement des chiffres =====
            if (Regex.IsMatch(txtRechercheNom.Text.Trim(), @"^\d+$"))
            {
                MessageBox.Show("❌ Nom invalide.\n\n- Le nom ne peut pas contenir uniquement des chiffres.",
                    "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtRechercheNom.Focus();
                return;
            }

            using (SqlConnection conn = connexionBD.GetConnection())
            {
                try
                {
                    conn.Open();
                    string sql = @"SELECT a.Id, a.Nom, a.Espece, a.Race, a.Sexe, a.DateNaissance, a.Couleur,
                                          p.Nom + ' ' + p.Prenom AS Proprietaire, p.Telephone, p.Email
                                   FROM Animal a
                                   JOIN Proprietaire p ON a.ProprietaireId = p.Id
                                   WHERE a.Nom LIKE @Nom";
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
                    adapter.SelectCommand.Parameters.AddWithValue("@Nom", "%" + txtRechercheNom.Text.Trim() + "%");
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvDossierMedical.DataSource = dt;
                    dgvDossierMedical.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                    if (dgvDossierMedical.Rows.Count > 0)
                    {
                        int animalId = (int)dgvDossierMedical.Rows[0].Cells["Id"].Value;
                        ChargerVaccinations(animalId);
                        MessageBox.Show($"✅ {dgvDossierMedical.Rows.Count} animal(s) trouvé(s)",
                            "Recherche", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("⚠️ Aucun animal trouvé avec ce nom.", "Information",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dgvVaccinations.DataSource = null;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"❌ Erreur: {ex.Message}", "Erreur",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ChargerVaccinations(int animalId)
        {
            using (SqlConnection conn = connexionBD.GetConnection())
            {
                try
                {
                    conn.Open();
                    string sql = @"SELECT Id, NomVaccin, DateAdministration, DateRappel
                                   FROM Vaccination
                                   WHERE AnimalId = @AnimalId
                                   ORDER BY DateAdministration DESC";
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
                    adapter.SelectCommand.Parameters.AddWithValue("@AnimalId", animalId);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvVaccinations.DataSource = dt;
                    dgvVaccinations.Columns["Id"].Visible = false;
                    if (dgvVaccinations.Columns["DateAdministration"] != null)
                        dgvVaccinations.Columns["DateAdministration"].DefaultCellStyle.Format = "dd/MM/yyyy";
                    if (dgvVaccinations.Columns["DateRappel"] != null)
                        dgvVaccinations.Columns["DateRappel"].DefaultCellStyle.Format = "dd/MM/yyyy";
                    dgvVaccinations.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"❌ Erreur: {ex.Message}", "Erreur",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnAjouterVaccin_Click(object sender, EventArgs e)
        {
            if (dgvDossierMedical.CurrentRow == null && dgvDossierMedical.Rows.Count == 0)
            {
                MessageBox.Show("❌ Veuillez d'abord rechercher un animal.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int animalId = (int)dgvDossierMedical.Rows[0].Cells["Id"].Value;
            string animalNom = dgvDossierMedical.Rows[0].Cells["Nom"].Value.ToString();

            FormAjouterVaccin formVaccin = new FormAjouterVaccin(animalId, animalNom);
            DialogResult result = formVaccin.ShowDialog();

            if (result == DialogResult.OK)
            {
                ChargerVaccinations(animalId);
                MessageBox.Show("✅ Vaccin ajouté avec succès", "Succès",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dgvDossierMedical_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int animalId = (int)dgvDossierMedical.Rows[e.RowIndex].Cells["Id"].Value;
                ChargerVaccinations(animalId);
            }
        }

        private void btnDeconnexionVeto_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Voulez-vous vraiment vous déconnecter ?",
                "Déconnexion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Close();
                Application.Restart();
            }
        }

        private void FormVeterinaire_Load(object sender, EventArgs e)
        {
        }
    }
}