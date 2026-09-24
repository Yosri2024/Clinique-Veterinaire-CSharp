using System;
using System.Data;
using System.Text.RegularExpressions;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;

namespace CliniqueVeterinaire
{
    public partial class FormSecretaire : Form
    {
        private ConnexionBD connexionBD;
        private string nomUtilisateur;
        private string prenomUtilisateur;

        public FormSecretaire(string nom, string prenom)
        {
            InitializeComponent();
            connexionBD = new ConnexionBD();
            nomUtilisateur = nom;
            prenomUtilisateur = prenom;
            this.Text = $"Secrétaire - Clinique Vétérinaire - {prenom} {nom}";

            ChargerProprietaires();
            ChargerAnimaux();
            ChargerRendezVous();
            ChargerComboBoxes();

            groupBoxProprietaire.Enabled = false;
            groupBoxAnimal.Enabled = false;
            groupBoxRDV.Enabled = false;
        }

        // ========== VALIDATION METHODS ==========

        // Validate name (letters only, no digits, min 2 chars)
        private bool IsValidName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return false;

            if (!Regex.IsMatch(name.Trim(), @"^[a-zA-ZÀ-ÿ\s\-]+$"))
                return false;

            if (Regex.IsMatch(name.Trim(), @"\d"))
                return false;

            if (name.Trim().Length < 2)
                return false;

            return true;
        }

        // Validate phone number (8 digits, starts with 2 or 5) - REQUIRED
        private bool IsValidPhone(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone))
                return false;

            if (!Regex.IsMatch(phone.Trim(), @"^\d{8}$"))
                return false;

            if (!phone.Trim().StartsWith("2") && !phone.Trim().StartsWith("5"))
                return false;

            return true;
        }

        // Validate email format - REQUIRED
        private bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                return Regex.IsMatch(email.Trim(), @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
            }
            catch
            {
                return false;
            }
        }

        // Validate animal name (letters, spaces, no digits, min 2 chars)
        private bool IsValidAnimalName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return false;
            }

            if (Regex.IsMatch(name.Trim(), @"\d"))
            {
                return false;
            }

            if (name.Trim().Length < 2)
            {
                return false;
            }

            return true;
        }

        // Validate espece (letters only, min 2 chars)
        private bool IsValidEspece(string espece)
        {
            if (string.IsNullOrWhiteSpace(espece))
                return false;

            if (!Regex.IsMatch(espece.Trim(), @"^[a-zA-ZÀ-ÿ]+$"))
                return false;

            if (espece.Trim().Length < 2)
                return false;

            return true;
        }

        // Validate race (letters only, optional)
        private bool IsValidRace(string race)
        {
            if (string.IsNullOrWhiteSpace(race))
                return true; // Race is optional

            if (!Regex.IsMatch(race.Trim(), @"^[a-zA-ZÀ-ÿ\s\-]+$"))
                return false;

            if (Regex.IsMatch(race.Trim(), @"\d"))
                return false;

            return true;
        }

        // Validate sexe (must be M or F)
        private bool IsValidSexe(string sexe)
        {
            if (string.IsNullOrWhiteSpace(sexe))
                return false;

            string sexeUpper = sexe.Trim().ToUpper();
            return sexeUpper == "M" || sexeUpper == "F";
        }

        // Validate couleur (letters only, optional)
        private bool IsValidCouleur(string couleur)
        {
            if (string.IsNullOrWhiteSpace(couleur))
                return true; // Couleur is optional

            if (!Regex.IsMatch(couleur.Trim(), @"^[a-zA-ZÀ-ÿ\s\-]+$"))
                return false;

            if (Regex.IsMatch(couleur.Trim(), @"\d"))
                return false;

            return true;
        }

        // Validate date naissance (not in future)
        private bool IsValidDateNaissance(DateTime date)
        {
            if (date > DateTime.Today)
                return false;

            // Optional: check if date is too old (more than 50 years)
            if (date < DateTime.Today.AddYears(-50))
                return false;

            return true;
        }

        // Validate motif (not empty, min 3 chars)
        private bool IsValidMotif(string motif)
        {
            if (string.IsNullOrWhiteSpace(motif))
                return false;

            if (motif.Trim().Length < 3)
                return false;

            return true;
        }

        // Validate date rendez-vous (not in past)
        private bool IsValidDateRDV(DateTime date)
        {
            return date.Date >= DateTime.Today;
        }

        // ========== PROPRIETAIRE VALIDATION ==========
        private bool ValiderProprietaire(out string message)
        {
            message = "";

            string champsVides = "";
            if (string.IsNullOrWhiteSpace(txtNomProp.Text)) champsVides += "- Nom\n";
            if (string.IsNullOrWhiteSpace(txtPrenomProp.Text)) champsVides += "- Prénom\n";
            if (string.IsNullOrWhiteSpace(txtTelProp.Text)) champsVides += "- Téléphone\n";
            if (string.IsNullOrWhiteSpace(txtEmailProp.Text)) champsVides += "- Email\n";

            if (champsVides != "")
            {
                message = $"❌ Les champs suivants sont obligatoires :\n\n{champsVides}";
                return false;
            }

            if (!IsValidName(txtNomProp.Text))
            {
                message = "❌ Nom invalide.\n\nRègles:\n- Uniquement des lettres\n- Minimum 2 caractères\n- Pas de chiffres";
                return false;
            }

            if (!IsValidName(txtPrenomProp.Text))
            {
                message = "❌ Prénom invalide.\n\nRègles:\n- Uniquement des lettres\n- Minimum 2 caractères\n- Pas de chiffres";
                return false;
            }

            if (!IsValidPhone(txtTelProp.Text))
            {
                message = "❌ Numéro de téléphone invalide.\n\nRègles:\n- 8 chiffres exactement\n- Doit commencer par 2 ou 5\n- Exemples: 23******, 51******";
                return false;
            }

            if (!IsValidEmail(txtEmailProp.Text))
            {
                message = "❌ Email invalide.\n\nRègles:\n- Doit contenir '@'\n- Doit contenir '.'\n- Exemple: nom@domaine.tn";
                return false;
            }

            return true;
        }

        // ========== ANIMAL VALIDATION ==========
        private bool ValiderAnimal(out string message)
        {
            message = "";

            // Check empty required fields
            string champsVides = "";
            if (string.IsNullOrWhiteSpace(txtNomAnimal.Text)) champsVides += "- Nom de l'animal\n";
            if (string.IsNullOrWhiteSpace(cmbEspece.Text)) champsVides += "- Espèce\n";
            if (cmbProprietaire.SelectedIndex == -1) champsVides += "- Propriétaire\n";
            if (string.IsNullOrWhiteSpace(cmbSexe.Text)) champsVides += "- Sexe\n";

            if (champsVides != "")
            {
                message = $"❌ Les champs suivants sont obligatoires :\n\n{champsVides}";
                return false;
            }

            // Validate Nom
            if (!IsValidAnimalName(txtNomAnimal.Text))
            {
                message = "❌ Nom de l'animal invalide.\n\nRègles:\n- Minimum 2 caractères\n- Pas de chiffres\n- Lettres uniquement";
                return false;
            }

            // Validate Espèce
            if (!IsValidEspece(cmbEspece.Text))
            {
                message = "❌ Espèce invalide.\n\nRègles:\n- Uniquement des lettres\n- Minimum 2 caractères\n- Exemples: Chien, Chat, Oiseau";
                return false;
            }

            // Validate Race (optional)
            if (!IsValidRace(txtRace.Text))
            {
                message = "❌ Race invalide.\n\nRègles:\n- Uniquement des lettres\n- Pas de chiffres";
                return false;
            }

            // Validate Sexe
            if (!IsValidSexe(cmbSexe.Text))
            {
                message = "❌ Sexe invalide.\n\nRègles:\n- Doit être 'M' (Masculin) ou 'F' (Féminin)";
                return false;
            }

            // Validate Date naissance
            if (!IsValidDateNaissance(dtpDateNaiss.Value))
            {
                if (dtpDateNaiss.Value > DateTime.Today)
                    message = "❌ La date de naissance ne peut pas être dans le futur.";
                else if (dtpDateNaiss.Value < DateTime.Today.AddYears(-50))
                    message = "❌ La date de naissance semble trop ancienne (plus de 50 ans).";
                else
                    message = "❌ Date de naissance invalide.";
                return false;
            }

            // Validate Couleur (optional)
            if (!IsValidCouleur(txtCouleur.Text))
            {
                message = "❌ Couleur invalide.\n\nRègles:\n- Uniquement des lettres\n- Pas de chiffres";
                return false;
            }

            return true;
        }

        // ========== RENDEZ-VOUS VALIDATION ==========
        private bool ValiderRendezVous(out string message)
        {
            message = "";

            // Check empty fields
            string champsVides = "";
            if (cmbAnimalRDV.SelectedIndex == -1) champsVides += "- Animal\n";
            if (cmbVetoRDV.SelectedIndex == -1) champsVides += "- Vétérinaire\n";
            if (string.IsNullOrWhiteSpace(txtMotifRDV.Text)) champsVides += "- Motif\n";

            if (champsVides != "")
            {
                message = $"❌ Les champs suivants sont obligatoires :\n\n{champsVides}";
                return false;
            }

            // Validate Motif
            if (!IsValidMotif(txtMotifRDV.Text))
            {
                message = "❌ Motif invalide.\n\nRègles:\n- Minimum 3 caractères\n- Ne peut pas être vide";
                return false;
            }

            // Validate Date
            if (!IsValidDateRDV(dtpDateRDV.Value))
            {
                message = "❌ La date du rendez-vous ne peut pas être dans le passé.\n\nVeuillez choisir une date aujourd'hui ou dans le futur.";
                return false;
            }

            return true;
        }

        private void ChargerComboBoxes()
        {
            cmbProprietaire.Items.Clear();
            cmbAnimalRDV.Items.Clear();
            cmbVetoRDV.Items.Clear();

            using (SqlConnection conn = connexionBD.GetConnection())
            {
                conn.Open();
                string sql = "SELECT Id, Nom, Prenom FROM Proprietaire ORDER BY Nom";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string nomComplet = $"{reader["Nom"]} {reader["Prenom"]}";
                    cmbProprietaire.Items.Add(new KeyValuePair<int, string>((int)reader["Id"], nomComplet));
                }
                reader.Close();
            }
            cmbProprietaire.DisplayMember = "Value";
            cmbProprietaire.ValueMember = "Key";

            using (SqlConnection conn = connexionBD.GetConnection())
            {
                conn.Open();
                string sql = "SELECT Id, Nom FROM Animal ORDER BY Nom";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    cmbAnimalRDV.Items.Add(new KeyValuePair<int, string>((int)reader["Id"], reader["Nom"].ToString()));
                }
                reader.Close();
            }
            cmbAnimalRDV.DisplayMember = "Value";
            cmbAnimalRDV.ValueMember = "Key";

            using (SqlConnection conn = connexionBD.GetConnection())
            {
                conn.Open();
                string sql = "SELECT Id, Nom, Prenom FROM Utilisateur WHERE Role = 'Veterinaire'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string nomComplet = $"{reader["Prenom"]} {reader["Nom"]}";
                    cmbVetoRDV.Items.Add(new KeyValuePair<int, string>((int)reader["Id"], nomComplet));
                }
                reader.Close();
            }
            cmbVetoRDV.DisplayMember = "Value";
            cmbVetoRDV.ValueMember = "Key";

            if (cmbStatutRDV.Items.Count == 0)
                cmbStatutRDV.Items.AddRange(new string[] { "Planifie", "Confirme", "Annule", "Termine" });
            cmbStatutRDV.SelectedIndex = 0;

            // Set default for Sexe ComboBox
            if (cmbSexe.Items.Count == 0)
            {
                cmbSexe.Items.Add("M");
                cmbSexe.Items.Add("F");
                cmbSexe.SelectedIndex = 0;
            }
        }

        // ========== DUPLICATE CHECKS ==========
        private bool ProprietaireExists(string telephone, string email, int excludeId = 0)
        {
            using (SqlConnection conn = connexionBD.GetConnection())
            {
                conn.Open();
                string sql = @"SELECT COUNT(*) FROM Proprietaire 
                               WHERE (Telephone = @Tel OR Email = @Email) 
                               AND Id != @ExcludeId";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Tel", telephone.Trim());
                cmd.Parameters.AddWithValue("@Email", email.Trim());
                cmd.Parameters.AddWithValue("@ExcludeId", excludeId);
                return (int)cmd.ExecuteScalar() > 0;
            }
        }

        private bool AnimalExists(string nom, int proprietaireId, int excludeId = 0)
        {
            using (SqlConnection conn = connexionBD.GetConnection())
            {
                conn.Open();
                string sql = @"SELECT COUNT(*) FROM Animal 
                               WHERE Nom = @Nom AND ProprietaireId = @PropId AND Id != @ExcludeId";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Nom", nom.Trim());
                cmd.Parameters.AddWithValue("@PropId", proprietaireId);
                cmd.Parameters.AddWithValue("@ExcludeId", excludeId);
                return (int)cmd.ExecuteScalar() > 0;
            }
        }

        private bool RendezVousExists(int animalId, DateTime dateHeure, int excludeId = 0)
        {
            using (SqlConnection conn = connexionBD.GetConnection())
            {
                conn.Open();
                string sql = @"SELECT COUNT(*) FROM RendezVous 
                               WHERE AnimalId = @AnimalId AND DateHeure = @DateHeure AND Id != @ExcludeId";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@AnimalId", animalId);
                cmd.Parameters.AddWithValue("@DateHeure", dateHeure);
                cmd.Parameters.AddWithValue("@ExcludeId", excludeId);
                return (int)cmd.ExecuteScalar() > 0;
            }
        }

        // ========== PROPRIETAIRES ==========
        private void ChargerProprietaires()
        {
            using (SqlConnection conn = connexionBD.GetConnection())
            {
                try
                {
                    conn.Open();
                    string sql = "SELECT Id, Nom, Prenom, Telephone, Email, Adresse, Ville FROM Proprietaire ORDER BY Nom";
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvProprietaires.DataSource = dt;
                    dgvProprietaires.Columns["Id"].Visible = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erreur: {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnAjouterProp_Click(object sender, EventArgs e)
        {
            groupBoxProprietaire.Enabled = true;
            groupBoxProprietaire.Text = "Ajouter un propriétaire";
            ClearProprietaireForm();
            txtNomProp.Focus();
        }

        private void btnModifierProp_Click(object sender, EventArgs e)
        {
            if (dgvProprietaires.CurrentRow == null)
            {
                MessageBox.Show("Sélectionnez un propriétaire", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            groupBoxProprietaire.Enabled = true;
            groupBoxProprietaire.Text = "Modifier un propriétaire";
            DataGridViewRow row = dgvProprietaires.CurrentRow;
            txtNomProp.Text = row.Cells["Nom"].Value?.ToString() ?? "";
            txtPrenomProp.Text = row.Cells["Prenom"].Value?.ToString() ?? "";
            txtTelProp.Text = row.Cells["Telephone"].Value?.ToString() ?? "";
            txtEmailProp.Text = row.Cells["Email"].Value?.ToString() ?? "";
            txtAdresseProp.Text = row.Cells["Adresse"].Value?.ToString() ?? "";
            txtVilleProp.Text = row.Cells["Ville"].Value?.ToString() ?? "";
        }

        private void btnSupprimerProp_Click(object sender, EventArgs e)
        {
            if (dgvProprietaires.CurrentRow == null)
            {
                MessageBox.Show("Sélectionnez un propriétaire", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            DialogResult result = MessageBox.Show("Supprimer ce propriétaire ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                int id = (int)dgvProprietaires.CurrentRow.Cells["Id"].Value;
                using (SqlConnection conn = connexionBD.GetConnection())
                {
                    try
                    {
                        conn.Open();
                        string sql = "DELETE FROM Proprietaire WHERE Id = @Id";
                        SqlCommand cmd = new SqlCommand(sql, conn);
                        cmd.Parameters.AddWithValue("@Id", id);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("✅ Propriétaire supprimé", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ChargerProprietaires();
                        ChargerComboBoxes();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"❌ Erreur: {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnActualiserProp_Click(object sender, EventArgs e)
        {
            ChargerProprietaires();
            ClearProprietaireForm();
            groupBoxProprietaire.Enabled = false;
            MessageBox.Show("✅ Liste des propriétaires actualisée", "Actualisation", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnEnregistrerProp_Click(object sender, EventArgs e)
        {
            if (!ValiderProprietaire(out string message))
            {
                MessageBox.Show(message, "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int currentId = 0;
            if (groupBoxProprietaire.Text == "Modifier un propriétaire" && dgvProprietaires.CurrentRow != null)
                currentId = (int)dgvProprietaires.CurrentRow.Cells["Id"].Value;

            if (ProprietaireExists(txtTelProp.Text, txtEmailProp.Text, currentId))
            {
                MessageBox.Show("❌ Un propriétaire avec ce téléphone ou cet email existe déjà.",
                    "Doublon détecté", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTelProp.Focus();
                return;
            }

            using (SqlConnection conn = connexionBD.GetConnection())
            {
                try
                {
                    conn.Open();

                    if (groupBoxProprietaire.Text == "Ajouter un propriétaire")
                    {
                        string sql = @"INSERT INTO Proprietaire (Nom, Prenom, Telephone, Email, Adresse, Ville) 
                                       VALUES (@Nom, @Prenom, @Tel, @Email, @Adresse, @Ville)";
                        SqlCommand cmd = new SqlCommand(sql, conn);
                        cmd.Parameters.AddWithValue("@Nom", txtNomProp.Text.Trim());
                        cmd.Parameters.AddWithValue("@Prenom", txtPrenomProp.Text.Trim());
                        cmd.Parameters.AddWithValue("@Tel", txtTelProp.Text.Trim());
                        cmd.Parameters.AddWithValue("@Email", txtEmailProp.Text.Trim());
                        cmd.Parameters.AddWithValue("@Adresse", txtAdresseProp.Text);
                        cmd.Parameters.AddWithValue("@Ville", txtVilleProp.Text);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("✅ Propriétaire ajouté", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        int id = (int)dgvProprietaires.CurrentRow.Cells["Id"].Value;
                        string sql = @"UPDATE Proprietaire SET Nom=@Nom, Prenom=@Prenom, Telephone=@Tel, 
                                       Email=@Email, Adresse=@Adresse, Ville=@Ville WHERE Id=@Id";
                        SqlCommand cmd = new SqlCommand(sql, conn);
                        cmd.Parameters.AddWithValue("@Nom", txtNomProp.Text.Trim());
                        cmd.Parameters.AddWithValue("@Prenom", txtPrenomProp.Text.Trim());
                        cmd.Parameters.AddWithValue("@Tel", txtTelProp.Text.Trim());
                        cmd.Parameters.AddWithValue("@Email", txtEmailProp.Text.Trim());
                        cmd.Parameters.AddWithValue("@Adresse", txtAdresseProp.Text);
                        cmd.Parameters.AddWithValue("@Ville", txtVilleProp.Text);
                        cmd.Parameters.AddWithValue("@Id", id);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("✅ Propriétaire modifié", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    groupBoxProprietaire.Enabled = false;
                    ClearProprietaireForm();
                    ChargerProprietaires();
                    ChargerComboBoxes();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"❌ Erreur: {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ClearProprietaireForm()
        {
            txtNomProp.Text = "";
            txtPrenomProp.Text = "";
            txtTelProp.Text = "";
            txtEmailProp.Text = "";
            txtAdresseProp.Text = "";
            txtVilleProp.Text = "";
        }

        // ========== ANIMAUX ==========
        private void ChargerAnimaux()
        {
            using (SqlConnection conn = connexionBD.GetConnection())
            {
                try
                {
                    conn.Open();
                    string sql = @"SELECT a.Id, a.Nom, a.Espece, a.Race, a.Sexe, a.DateNaissance, a.Couleur,
                                          p.Nom + ' ' + p.Prenom AS Proprietaire
                                   FROM Animal a
                                   JOIN Proprietaire p ON a.ProprietaireId = p.Id
                                   ORDER BY a.Nom";
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvAnimaux.DataSource = dt;
                    dgvAnimaux.Columns["Id"].Visible = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erreur: {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnAjouterAnimal_Click(object sender, EventArgs e)
        {
            groupBoxAnimal.Enabled = true;
            groupBoxAnimal.Text = "Ajouter un animal";
            ClearAnimalForm();
            txtNomAnimal.Focus();
        }

        private void btnModifierAnimal_Click(object sender, EventArgs e)
        {
            if (dgvAnimaux.CurrentRow == null)
            {
                MessageBox.Show("Sélectionnez un animal", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            groupBoxAnimal.Enabled = true;
            groupBoxAnimal.Text = "Modifier un animal";
            DataGridViewRow row = dgvAnimaux.CurrentRow;
            txtNomAnimal.Text = row.Cells["Nom"].Value?.ToString() ?? "";
            cmbEspece.Text = row.Cells["Espece"].Value?.ToString() ?? "";
            txtRace.Text = row.Cells["Race"].Value?.ToString() ?? "";
            cmbSexe.Text = row.Cells["Sexe"].Value?.ToString() ?? "";
            dtpDateNaiss.Value = row.Cells["DateNaissance"].Value != DBNull.Value ? (DateTime)row.Cells["DateNaissance"].Value : DateTime.Now;
            txtCouleur.Text = row.Cells["Couleur"].Value?.ToString() ?? "";

            string proprietaire = row.Cells["Proprietaire"].Value?.ToString() ?? "";
            for (int i = 0; i < cmbProprietaire.Items.Count; i++)
            {
                if (cmbProprietaire.GetItemText(cmbProprietaire.Items[i]) == proprietaire)
                {
                    cmbProprietaire.SelectedIndex = i;
                    break;
                }
            }
        }

        private void btnSupprimerAnimal_Click(object sender, EventArgs e)
        {
            if (dgvAnimaux.CurrentRow == null)
            {
                MessageBox.Show("Sélectionnez un animal", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            DialogResult result = MessageBox.Show("Supprimer cet animal ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                int id = (int)dgvAnimaux.CurrentRow.Cells["Id"].Value;
                using (SqlConnection conn = connexionBD.GetConnection())
                {
                    try
                    {
                        conn.Open();
                        string sql = "DELETE FROM Animal WHERE Id = @Id";
                        SqlCommand cmd = new SqlCommand(sql, conn);
                        cmd.Parameters.AddWithValue("@Id", id);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("✅ Animal supprimé", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ChargerAnimaux();
                        ChargerComboBoxes();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"❌ Erreur: {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnActualiserAnimal_Click(object sender, EventArgs e)
        {
            ChargerAnimaux();
            ClearAnimalForm();
            groupBoxAnimal.Enabled = false;
            MessageBox.Show("✅ Liste des animaux actualisée", "Actualisation", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnEnregistrerAnimal_Click(object sender, EventArgs e)
        {
            // Validation
            if (!ValiderAnimal(out string message))
            {
                MessageBox.Show(message, "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int proprietaireId = ((KeyValuePair<int, string>)cmbProprietaire.SelectedItem).Key;

            // Duplicate check
            int currentId = 0;
            if (groupBoxAnimal.Text == "Modifier un animal" && dgvAnimaux.CurrentRow != null)
                currentId = (int)dgvAnimaux.CurrentRow.Cells["Id"].Value;

            if (AnimalExists(txtNomAnimal.Text, proprietaireId, currentId))
            {
                MessageBox.Show("❌ Cet animal existe déjà pour ce propriétaire.",
                    "Doublon détecté", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNomAnimal.Focus();
                return;
            }

            using (SqlConnection conn = connexionBD.GetConnection())
            {
                try
                {
                    conn.Open();

                    // Get sexe in uppercase
                    string sexe = cmbSexe.Text.Trim().ToUpper();

                    if (groupBoxAnimal.Text == "Ajouter un animal")
                    {
                        string sql = @"INSERT INTO Animal (Nom, Espece, Race, Sexe, DateNaissance, Couleur, ProprietaireId) 
                                       VALUES (@Nom, @Espece, @Race, @Sexe, @DateNaissance, @Couleur, @ProprietaireId)";
                        SqlCommand cmd = new SqlCommand(sql, conn);
                        cmd.Parameters.AddWithValue("@Nom", txtNomAnimal.Text.Trim());
                        cmd.Parameters.AddWithValue("@Espece", cmbEspece.Text.Trim());
                        cmd.Parameters.AddWithValue("@Race", txtRace.Text.Trim());
                        cmd.Parameters.AddWithValue("@Sexe", sexe);
                        cmd.Parameters.AddWithValue("@DateNaissance", dtpDateNaiss.Value);
                        cmd.Parameters.AddWithValue("@Couleur", txtCouleur.Text.Trim());
                        cmd.Parameters.AddWithValue("@ProprietaireId", proprietaireId);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("✅ Animal ajouté avec succès", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        int id = (int)dgvAnimaux.CurrentRow.Cells["Id"].Value;
                        string sql = @"UPDATE Animal SET Nom=@Nom, Espece=@Espece, Race=@Race, Sexe=@Sexe, 
                                       DateNaissance=@DateNaissance, Couleur=@Couleur, ProprietaireId=@ProprietaireId 
                                       WHERE Id=@Id";
                        SqlCommand cmd = new SqlCommand(sql, conn);
                        cmd.Parameters.AddWithValue("@Nom", txtNomAnimal.Text.Trim());
                        cmd.Parameters.AddWithValue("@Espece", cmbEspece.Text.Trim());
                        cmd.Parameters.AddWithValue("@Race", txtRace.Text.Trim());
                        cmd.Parameters.AddWithValue("@Sexe", sexe);
                        cmd.Parameters.AddWithValue("@DateNaissance", dtpDateNaiss.Value);
                        cmd.Parameters.AddWithValue("@Couleur", txtCouleur.Text.Trim());
                        cmd.Parameters.AddWithValue("@ProprietaireId", proprietaireId);
                        cmd.Parameters.AddWithValue("@Id", id);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("✅ Animal modifié avec succès", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    groupBoxAnimal.Enabled = false;
                    ClearAnimalForm();
                    ChargerAnimaux();
                    ChargerComboBoxes();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"❌ Erreur: {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ClearAnimalForm()
        {
            txtNomAnimal.Text = "";
            cmbEspece.SelectedIndex = -1;
            txtRace.Text = "";
            cmbSexe.SelectedIndex = -1;
            dtpDateNaiss.Value = DateTime.Now.AddYears(-1);
            txtCouleur.Text = "";
            cmbProprietaire.SelectedIndex = -1;
        }

        // ========== RENDEZ-VOUS ==========
        private void ChargerRendezVous()
        {
            using (SqlConnection conn = connexionBD.GetConnection())
            {
                try
                {
                    conn.Open();
                    string sql = @"SELECT r.Id, a.Nom AS Animal, r.DateHeure, r.Motif, r.Statut,
                                          u.Nom + ' ' + u.Prenom AS Veterinaire
                                   FROM RendezVous r
                                   JOIN Animal a ON r.AnimalId = a.Id
                                   JOIN Utilisateur u ON r.VeterinaireId = u.Id
                                   ORDER BY r.DateHeure";
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvRendezVous.DataSource = dt;
                    dgvRendezVous.Columns["Id"].Visible = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erreur: {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnAjouterRDV_Click(object sender, EventArgs e)
        {
            groupBoxRDV.Enabled = true;
            groupBoxRDV.Text = "Ajouter un rendez-vous";
            ClearRDVForm();
            cmbAnimalRDV.Focus();
        }

        private void btnModifierRDV_Click(object sender, EventArgs e)
        {
            if (dgvRendezVous.CurrentRow == null)
            {
                MessageBox.Show("Sélectionnez un rendez-vous", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            groupBoxRDV.Enabled = true;
            groupBoxRDV.Text = "Modifier un rendez-vous";

            DataGridViewRow row = dgvRendezVous.CurrentRow;
            string animal = row.Cells["Animal"].Value?.ToString() ?? "";
            string veterinaire = row.Cells["Veterinaire"].Value?.ToString() ?? "";

            for (int i = 0; i < cmbAnimalRDV.Items.Count; i++)
            {
                if (cmbAnimalRDV.GetItemText(cmbAnimalRDV.Items[i]) == animal)
                {
                    cmbAnimalRDV.SelectedIndex = i;
                    break;
                }
            }

            for (int i = 0; i < cmbVetoRDV.Items.Count; i++)
            {
                if (cmbVetoRDV.GetItemText(cmbVetoRDV.Items[i]) == veterinaire)
                {
                    cmbVetoRDV.SelectedIndex = i;
                    break;
                }
            }

            dtpDateRDV.Value = row.Cells["DateHeure"].Value != DBNull.Value ? (DateTime)row.Cells["DateHeure"].Value : DateTime.Now;
            txtMotifRDV.Text = row.Cells["Motif"].Value?.ToString() ?? "";
            cmbStatutRDV.Text = row.Cells["Statut"].Value?.ToString() ?? "";
        }

        private void btnAnnulerRDV_Click(object sender, EventArgs e)
        {
            if (dgvRendezVous.CurrentRow == null)
            {
                MessageBox.Show("Sélectionnez un rendez-vous", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            DialogResult result = MessageBox.Show("Annuler ce rendez-vous ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                int id = (int)dgvRendezVous.CurrentRow.Cells["Id"].Value;
                using (SqlConnection conn = connexionBD.GetConnection())
                {
                    try
                    {
                        conn.Open();
                        string sql = "UPDATE RendezVous SET Statut = 'Annule' WHERE Id = @Id";
                        SqlCommand cmd = new SqlCommand(sql, conn);
                        cmd.Parameters.AddWithValue("@Id", id);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("✅ Rendez-vous annulé", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ChargerRendezVous();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"❌ Erreur: {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnActualiserRDV_Click(object sender, EventArgs e)
        {
            ChargerRendezVous();
            ClearRDVForm();
            groupBoxRDV.Enabled = false;
            MessageBox.Show("✅ Liste des rendez-vous actualisée", "Actualisation", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnEnregistrerRDV_Click(object sender, EventArgs e)
        {
            // Validation
            if (!ValiderRendezVous(out string message))
            {
                MessageBox.Show(message, "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int animalId = ((KeyValuePair<int, string>)cmbAnimalRDV.SelectedItem).Key;
            int vetoId = ((KeyValuePair<int, string>)cmbVetoRDV.SelectedItem).Key;

            // Duplicate check
            int currentId = 0;
            if (groupBoxRDV.Text == "Modifier un rendez-vous" && dgvRendezVous.CurrentRow != null)
                currentId = (int)dgvRendezVous.CurrentRow.Cells["Id"].Value;

            if (RendezVousExists(animalId, dtpDateRDV.Value, currentId))
            {
                MessageBox.Show("❌ Un rendez-vous existe déjà pour cet animal à cette date et heure.",
                    "Doublon détecté", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpDateRDV.Focus();
                return;
            }

            using (SqlConnection conn = connexionBD.GetConnection())
            {
                try
                {
                    conn.Open();

                    if (groupBoxRDV.Text == "Ajouter un rendez-vous")
                    {
                        string sql = @"INSERT INTO RendezVous (DateHeure, Motif, Statut, AnimalId, VeterinaireId) 
                                       VALUES (@DateHeure, @Motif, @Statut, @AnimalId, @VetoId)";
                        SqlCommand cmd = new SqlCommand(sql, conn);
                        cmd.Parameters.AddWithValue("@DateHeure", dtpDateRDV.Value);
                        cmd.Parameters.AddWithValue("@Motif", txtMotifRDV.Text.Trim());
                        cmd.Parameters.AddWithValue("@Statut", cmbStatutRDV.Text);
                        cmd.Parameters.AddWithValue("@AnimalId", animalId);
                        cmd.Parameters.AddWithValue("@VetoId", vetoId);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("✅ Rendez-vous ajouté avec succès", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        int id = (int)dgvRendezVous.CurrentRow.Cells["Id"].Value;
                        string sql = @"UPDATE RendezVous SET DateHeure=@DateHeure, Motif=@Motif, Statut=@Statut, 
                                       AnimalId=@AnimalId, VeterinaireId=@VetoId WHERE Id=@Id";
                        SqlCommand cmd = new SqlCommand(sql, conn);
                        cmd.Parameters.AddWithValue("@DateHeure", dtpDateRDV.Value);
                        cmd.Parameters.AddWithValue("@Motif", txtMotifRDV.Text.Trim());
                        cmd.Parameters.AddWithValue("@Statut", cmbStatutRDV.Text);
                        cmd.Parameters.AddWithValue("@AnimalId", animalId);
                        cmd.Parameters.AddWithValue("@VetoId", vetoId);
                        cmd.Parameters.AddWithValue("@Id", id);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("✅ Rendez-vous modifié avec succès", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    groupBoxRDV.Enabled = false;
                    ClearRDVForm();
                    ChargerRendezVous();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"❌ Erreur: {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ClearRDVForm()
        {
            cmbAnimalRDV.SelectedIndex = -1;
            cmbVetoRDV.SelectedIndex = -1;
            dtpDateRDV.Value = DateTime.Now;
            txtMotifRDV.Text = "";
            cmbStatutRDV.SelectedIndex = 0;
        }

        private void tabRendezVous_Click(object sender, EventArgs e) { }

        private void FormSecretaire_Load(object sender, EventArgs e) { }

        private void btnDeconnexionSecretaire_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Voulez-vous vraiment vous déconnecter ?",
            "Déconnexion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Close();
                Application.Restart();
            }

        }

        private void btnFactures_Click(object sender, EventArgs e)
        {
            FormGestionFactures form = new FormGestionFactures();
            form.ShowDialog();
        }
    }
}