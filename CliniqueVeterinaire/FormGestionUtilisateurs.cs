using System;
using System.Data;
using System.Text.RegularExpressions;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;

namespace CliniqueVeterinaire
{
    public partial class FormGestionUtilisateurs : Form
    {
        private ConnexionBD connexionBD;

        public FormGestionUtilisateurs()
        {
            InitializeComponent();
            connexionBD = new ConnexionBD();
            ChargerUtilisateurs();

            cmbRole.Items.Add("Secretaire");
            cmbRole.Items.Add("Veterinaire");

            groupBoxForm.Enabled = false;
        }

        private void ChargerUtilisateurs()
        {
            using (SqlConnection conn = connexionBD.GetConnection())
            {
                try
                {
                    conn.Open();
                    string sql = "SELECT Id, Nom, Prenom, Login, Role, Email, Telephone FROM Utilisateur WHERE Role != 'Administrateur' ORDER BY Nom";
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvUtilisateurs.DataSource = dt;
                    dgvUtilisateurs.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                    if (dgvUtilisateurs.Columns["Id"] != null)
                        dgvUtilisateurs.Columns["Id"].Visible = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erreur: {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // ========== CHECK DUPLICATE ==========
        private bool UtilisateurExists(string login, string email, int excludeId = 0)
        {
            using (SqlConnection conn = connexionBD.GetConnection())
            {
                conn.Open();
                string sql = @"SELECT COUNT(*) FROM Utilisateur 
                               WHERE (Login = @Login OR Email = @Email) 
                               AND Id != @ExcludeId";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Login", login.Trim());
                cmd.Parameters.AddWithValue("@Email", email.Trim());
                cmd.Parameters.AddWithValue("@ExcludeId", excludeId);
                return (int)cmd.ExecuteScalar() > 0;
            }
        }

        // ========== VALIDATION METHODS ==========

        // Validate name (letters only, no digits, min 2 chars) - REQUIRED
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

        // Validate login (letters only, no spaces, min 3 chars) - REQUIRED
        private bool IsValidLogin(string login)
        {
            if (string.IsNullOrWhiteSpace(login))
                return false;

            if (Regex.IsMatch(login.Trim(), @"\d"))
                return false;

            if (login.Trim().Contains(" "))
                return false;

            if (!Regex.IsMatch(login.Trim(), @"^[a-zA-Z]+$"))
                return false;

            if (login.Trim().Length < 3)
                return false;

            return true;
        }

        // Validate password (min 6 chars) - REQUIRED
        private bool IsValidPassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
                return false;

            if (password.Length < 6)
                return false;

            return true;
        }

        // Validate phone number - REQUIRED (8 digits, starts with 2 or 5)
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

        // Validate all fields
        private bool ValiderChamps(out string message)
        {
            message = "";

            // ===== 1. CHECK EMPTY FIELDS (ALL FIELDS REQUIRED) =====
            string champsVides = "";
            if (string.IsNullOrWhiteSpace(txtNom.Text)) champsVides += "- Nom\n";
            if (string.IsNullOrWhiteSpace(txtPrenom.Text)) champsVides += "- Prénom\n";
            if (string.IsNullOrWhiteSpace(txtLogin.Text)) champsVides += "- Login\n";
            if (string.IsNullOrWhiteSpace(cmbRole.Text)) champsVides += "- Rôle\n";
            if (string.IsNullOrWhiteSpace(txtMotDePasse.Text)) champsVides += "- Mot de passe\n";
            if (string.IsNullOrWhiteSpace(txtEmail.Text)) champsVides += "- Email\n";
            if (string.IsNullOrWhiteSpace(txtTelephone.Text)) champsVides += "- Téléphone\n";

            if (champsVides != "")
            {
                message = $"❌ Les champs suivants sont obligatoires :\n\n{champsVides}";
                return false;
            }

            // ===== 2. VALIDATE NOM =====
            if (!IsValidName(txtNom.Text))
            {
                message = "❌ Nom invalide.\n\nRègles:\n- Uniquement des lettres\n- Minimum 2 caractères\n- Pas de chiffres";
                return false;
            }

            // ===== 3. VALIDATE PRENOM =====
            if (!IsValidName(txtPrenom.Text))
            {
                message = "❌ Prénom invalide.\n\nRègles:\n- Uniquement des lettres\n- Minimum 2 caractères\n- Pas de chiffres";
                return false;
            }

            // ===== 4. VALIDATE LOGIN =====
            if (!IsValidLogin(txtLogin.Text))
            {
                message = "❌ Login invalide.\n\nRègles:\n- Uniquement des lettres\n- Pas d'espaces\n- Pas de chiffres\n- Minimum 3 caractères";
                return false;
            }

            // ===== 5. VALIDATE PASSWORD =====
            if (!IsValidPassword(txtMotDePasse.Text))
            {
                message = "❌ Mot de passe invalide.\n\nRègles:\n- Minimum 6 caractères";
                return false;
            }

            // ===== 6. VALIDATE EMAIL =====
            if (!IsValidEmail(txtEmail.Text))
            {
                message = "❌ Email invalide.\n\nRègles:\n- Doit contenir '@'\n- Doit contenir '.'\n- Exemple: nom@domaine.tn";
                return false;
            }

            // ===== 7. VALIDATE PHONE =====
            if (!IsValidPhone(txtTelephone.Text))
            {
                message = "❌ Numéro de téléphone invalide.\n\nRègles:\n- 8 chiffres exactement\n- Doit commencer par 2 ou 5\n- Exemples: 23******, 51******";
                return false;
            }

            return true;
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            groupBoxForm.Enabled = true;
            groupBoxForm.Text = "Ajouter un utilisateur";
            ClearForm();
            txtNom.Focus();
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            if (dgvUtilisateurs.CurrentRow == null)
            {
                MessageBox.Show("Veuillez sélectionner un utilisateur à modifier",
                    "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            groupBoxForm.Enabled = true;
            groupBoxForm.Text = "Modifier un utilisateur";

            DataGridViewRow row = dgvUtilisateurs.CurrentRow;
            txtNom.Text = row.Cells["Nom"].Value?.ToString() ?? "";
            txtPrenom.Text = row.Cells["Prenom"].Value?.ToString() ?? "";
            txtLogin.Text = row.Cells["Login"].Value?.ToString() ?? "";
            cmbRole.Text = row.Cells["Role"].Value?.ToString() ?? "";
            txtEmail.Text = row.Cells["Email"].Value?.ToString() ?? "";
            txtTelephone.Text = row.Cells["Telephone"].Value?.ToString() ?? "";
            txtMotDePasse.Text = "";
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            if (dgvUtilisateurs.CurrentRow == null)
            {
                MessageBox.Show("Veuillez sélectionner un utilisateur à supprimer",
                    "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult result = MessageBox.Show("Voulez-vous vraiment supprimer cet utilisateur ?",
                "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                int id = (int)dgvUtilisateurs.CurrentRow.Cells["Id"].Value;

                using (SqlConnection conn = connexionBD.GetConnection())
                {
                    try
                    {
                        conn.Open();
                        string sql = "DELETE FROM Utilisateur WHERE Id = @Id";
                        SqlCommand cmd = new SqlCommand(sql, conn);
                        cmd.Parameters.AddWithValue("@Id", id);
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("✅ Utilisateur supprimé avec succès",
                            "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ChargerUtilisateurs();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"❌ Erreur: {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            // ===== VALIDATION =====
            if (!ValiderChamps(out string message))
            {
                MessageBox.Show(message, "Validation des champs", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // ===== DUPLICATE CHECK =====
            int currentId = 0;
            if (groupBoxForm.Text == "Modifier un utilisateur" && dgvUtilisateurs.CurrentRow != null)
                currentId = (int)dgvUtilisateurs.CurrentRow.Cells["Id"].Value;

            if (UtilisateurExists(txtLogin.Text.Trim(), txtEmail.Text.Trim(), currentId))
            {
                MessageBox.Show("❌ Un utilisateur avec ce login ou cet email existe déjà.\nVeuillez utiliser des informations différentes.",
                    "Doublon détecté", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLogin.Focus();
                return;
            }

            using (SqlConnection conn = connexionBD.GetConnection())
            {
                try
                {
                    conn.Open();

                    if (groupBoxForm.Text == "Ajouter un utilisateur")
                    {
                        string sql = @"INSERT INTO Utilisateur (Nom, Prenom, Login, MotDePasse, Role, Email, Telephone) 
                                       VALUES (@Nom, @Prenom, @Login, @MotDePasse, @Role, @Email, @Telephone)";
                        SqlCommand cmd = new SqlCommand(sql, conn);
                        cmd.Parameters.AddWithValue("@Nom", txtNom.Text.Trim());
                        cmd.Parameters.AddWithValue("@Prenom", txtPrenom.Text.Trim());
                        cmd.Parameters.AddWithValue("@Login", txtLogin.Text.Trim());
                        cmd.Parameters.AddWithValue("@MotDePasse", txtMotDePasse.Text);
                        cmd.Parameters.AddWithValue("@Role", cmbRole.Text);
                        cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                        cmd.Parameters.AddWithValue("@Telephone", txtTelephone.Text.Trim());
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("✅ Utilisateur ajouté avec succès",
                            "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        int id = (int)dgvUtilisateurs.CurrentRow.Cells["Id"].Value;
                        string sql = @"UPDATE Utilisateur SET Nom=@Nom, Prenom=@Prenom, Login=@Login, Role=@Role, Email=@Email, Telephone=@Telephone";

                        if (!string.IsNullOrEmpty(txtMotDePasse.Text))
                            sql += ", MotDePasse=@MotDePasse";

                        sql += " WHERE Id=@Id";

                        SqlCommand cmd = new SqlCommand(sql, conn);
                        cmd.Parameters.AddWithValue("@Nom", txtNom.Text.Trim());
                        cmd.Parameters.AddWithValue("@Prenom", txtPrenom.Text.Trim());
                        cmd.Parameters.AddWithValue("@Login", txtLogin.Text.Trim());
                        cmd.Parameters.AddWithValue("@Role", cmbRole.Text);
                        cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                        cmd.Parameters.AddWithValue("@Telephone", txtTelephone.Text.Trim());
                        cmd.Parameters.AddWithValue("@Id", id);

                        if (!string.IsNullOrEmpty(txtMotDePasse.Text))
                            cmd.Parameters.AddWithValue("@MotDePasse", txtMotDePasse.Text);

                        cmd.ExecuteNonQuery();

                        MessageBox.Show("✅ Utilisateur modifié avec succès",
                            "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    groupBoxForm.Enabled = false;
                    ClearForm();
                    ChargerUtilisateurs();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"❌ Erreur: {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            txtPrenom.Text = "";
            txtLogin.Text = "";
            txtMotDePasse.Text = "";
            cmbRole.SelectedIndex = -1;
            txtEmail.Text = "";
            txtTelephone.Text = "";
        }

        private void FormGestionUtilisateurs_Load(object sender, EventArgs e)
        {

        }
    }
}