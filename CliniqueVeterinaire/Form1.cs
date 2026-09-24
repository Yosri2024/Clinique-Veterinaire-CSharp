using System;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;

namespace CliniqueVeterinaire
{
    public partial class Form1 : Form
    {
        private ConnexionBD connexionBD;

        public Form1()
        {
            InitializeComponent();
            connexionBD = new ConnexionBD();
        }

        private void btnQuitter_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnConnexion_Click(object sender, EventArgs e)
        {
            string login = txtLogin.Text.Trim();
            string password = txtMotDePasse.Text;

            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Veuillez saisir votre login et mot de passe",
                    "Champs vides", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection conn = connexionBD.GetConnection())
            {
                try
                {
                    conn.Open();
                    string sql = "SELECT Id, Nom, Prenom, Role FROM Utilisateur WHERE Login=@Login AND MotDePasse=@MotDePasse";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@Login", login);
                    cmd.Parameters.AddWithValue("@MotDePasse", password);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        string nom = reader["Nom"] != null ? reader["Nom"].ToString() : "";
                        string prenom = reader["Prenom"] != null ? reader["Prenom"].ToString() : "";
                        string role = reader["Role"] != null ? reader["Role"].ToString() : "";

                        reader.Close();

                        MessageBox.Show($"Bienvenue {prenom} {nom} !\nRôle: {role}",
                            "Connexion réussie", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        this.Hide();

                        if (role == "Administrateur")
                        {
                            FormAdministrateur adminForm = new FormAdministrateur(nom, prenom);
                            adminForm.Show();
                        }
                        else if (role == "Secretaire")
                        {
                            FormSecretaire secretaireForm = new FormSecretaire(nom, prenom);
                            secretaireForm.Show();
                        }
                        else if (role == "Veterinaire")
                        {
                            FormVeterinaire vetoForm = new FormVeterinaire(nom, prenom);
                            vetoForm.Show();
                            this.Hide();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Login ou mot de passe incorrect",
                            "Échec de connexion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtLogin.Clear();
                        txtMotDePasse.Clear();
                        txtLogin.Focus();
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erreur de connexion à la base de données:\n{ex.Message}",
                        "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}