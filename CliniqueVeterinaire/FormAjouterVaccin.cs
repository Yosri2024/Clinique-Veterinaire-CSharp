using System;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;

namespace CliniqueVeterinaire
{
    public partial class FormAjouterVaccin : Form
    {
        private ConnexionBD connexionBD;
        private int animalId;
        private string animalNom;

        public FormAjouterVaccin(int id, string nom)
        {
            InitializeComponent();
            connexionBD = new ConnexionBD();
            animalId = id;
            animalNom = nom;
            lblAnimal.Text = $"Animal: {animalNom}";
        }

        private bool IsValidVaccinName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return false;
            if (name.Trim().Length < 2)
                return false;
            return true;
        }

        private bool IsValidAdminDate(DateTime date)
        {
            return date.Date <= DateTime.Today;
        }

        private bool IsValidRappelDate(DateTime adminDate, DateTime rappelDate)
        {
            return rappelDate.Date > adminDate.Date;
        }

        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            if (!IsValidVaccinName(txtNomVaccin.Text))
            {
                MessageBox.Show("❌ Nom du vaccin invalide.\n\nRègles:\n- Minimum 2 caractères",
                    "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNomVaccin.Focus();
                return;
            }

            if (!IsValidAdminDate(dtpDateAdmin.Value))
            {
                MessageBox.Show("❌ La date d'administration ne peut pas être dans le futur.",
                    "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpDateAdmin.Focus();
                return;
            }

            DateTime? dateRappel = null;
            if (chkRappel.Checked)
            {
                if (!IsValidRappelDate(dtpDateAdmin.Value, dtpDateRappel.Value))
                {
                    MessageBox.Show("❌ La date de rappel doit être postérieure à la date d'administration.",
                        "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dtpDateRappel.Focus();
                    return;
                }
                dateRappel = dtpDateRappel.Value;
            }

            using (SqlConnection conn = connexionBD.GetConnection())
            {
                try
                {
                    conn.Open();
                    string sql = @"INSERT INTO Vaccination (NomVaccin, DateAdministration, DateRappel, AnimalId, VeterinaireId) 
                           VALUES (@NomVaccin, @DateAdmin, @DateRappel, @AnimalId, 
                           (SELECT Id FROM Utilisateur WHERE Login = 'vet'))";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@NomVaccin", txtNomVaccin.Text.Trim());
                    cmd.Parameters.AddWithValue("@DateAdmin", dtpDateAdmin.Value);
                    cmd.Parameters.AddWithValue("@DateRappel", dateRappel.HasValue ? (object)dateRappel.Value : DBNull.Value);
                    cmd.Parameters.AddWithValue("@AnimalId", animalId);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("✅ Vaccin ajouté avec succès", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;  // ← ICI le changement
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"❌ Erreur: {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;  // ← ICI le changement
            this.Close();
        }

        private void chkRappel_CheckedChanged(object sender, EventArgs e)
        {
            dtpDateRappel.Enabled = chkRappel.Checked;
            if (!chkRappel.Checked)
            {
                dtpDateRappel.Value = dtpDateAdmin.Value.AddMonths(6);
            }
        }

        private void FormAjouterVaccin_Load(object sender, EventArgs e)
        {
            dtpDateRappel.Enabled = false;
            dtpDateRappel.Value = dtpDateAdmin.Value.AddMonths(6);
        }
    }
}