using System;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;

namespace CliniqueVeterinaire
{
    public partial class FormAdministrateur : Form
    {
        private string nomUtilisateur;
        private string prenomUtilisateur;
        private ConnexionBD connexionBD;

        public FormAdministrateur(string nom, string prenom)
        {
            InitializeComponent();
            connexionBD = new ConnexionBD();
            nomUtilisateur = nom;
            prenomUtilisateur = prenom;
            lblWelcome.Text = $"Bienvenue, {prenom} {nom} !";
        }

        private void ChargerStatistiques()
        {
            using (SqlConnection conn = connexionBD.GetConnection())
            {
                try
                {
                    conn.Open();

                    string sqlUsers = "SELECT COUNT(*) FROM Utilisateur";
                    SqlCommand cmdUsers = new SqlCommand(sqlUsers, conn);
                    int nbUsers = (int)cmdUsers.ExecuteScalar();

                    string sqlAnimals = "SELECT COUNT(*) FROM Animal";
                    SqlCommand cmdAnimals = new SqlCommand(sqlAnimals, conn);
                    int nbAnimals = (int)cmdAnimals.ExecuteScalar();

                    string sqlRdv = "SELECT COUNT(*) FROM RendezVous";
                    SqlCommand cmdRdv = new SqlCommand(sqlRdv, conn);
                    int nbRdv = (int)cmdRdv.ExecuteScalar();

                    dgvDashboard.Rows.Clear();
                    dgvDashboard.Rows.Add("Utilisateurs", nbUsers);
                    dgvDashboard.Rows.Add("Animaux", nbAnimals);
                    dgvDashboard.Rows.Add("Rendez-vous", nbRdv);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erreur: {ex.Message}", "Erreur",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnGestionUtilisateurs_Click(object sender, EventArgs e)
        {
            FormGestionUtilisateurs form = new FormGestionUtilisateurs();
            form.ShowDialog();
        }

        private void btnGestionStock_Click(object sender, EventArgs e)
        {
            FormGestionStock form = new FormGestionStock();
            form.ShowDialog();
        }

        private void btnStats_Click(object sender, EventArgs e)
        {
            ChargerStatistiques();
            MessageBox.Show("Statistiques mises à jour",
                "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDeconnexion_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Voulez-vous vraiment vous déconnecter ?",
                "Déconnexion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Close();
                Application.Restart();
            }
        }

        private void FormAdministrateur_Load(object sender, EventArgs e)
        {

        }
    }
}