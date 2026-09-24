using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;
using System.Drawing;

namespace CliniqueVeterinaire
{
    public partial class FormChoisirConsultation : Form
    {
        private ConnexionBD connexionBD;
        public int ConsultationId { get; private set; }
        public int AnimalId { get; private set; }
        public string AnimalNom { get; private set; }
        public decimal MontantHT { get; private set; }

        public FormChoisirConsultation()
        {
            InitializeComponent();

            // Configurer le label
            lblInfo.Text = "📋 Sélectionnez une consultation sans facture :";
            lblInfo.Font = new Font("Arial", 9, FontStyle.Bold);
            lblInfo.ForeColor = Color.DarkBlue;

            connexionBD = new ConnexionBD();
            ChargerConsultations();
        }

        private void ChargerConsultations()
        {
            using (SqlConnection conn = connexionBD.GetConnection())
            {
                try
                {
                    conn.Open();
                    string sql = @"SELECT c.Id, a.Nom AS Animal, p.Nom + ' ' + p.Prenom AS Proprietaire,
                                          CONVERT(VARCHAR, c.DateConsultation, 103) AS DateConsultation,
                                          c.Diagnostic
                                   FROM Consultation c
                                   JOIN Animal a ON c.AnimalId = a.Id
                                   JOIN Proprietaire p ON a.ProprietaireId = p.Id
                                   WHERE NOT EXISTS (SELECT 1 FROM Facture f WHERE f.ConsultationId = c.Id)
                                   ORDER BY c.DateConsultation DESC";
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvConsultations.DataSource = dt;
                    dgvConsultations.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                    if (dgvConsultations.Columns["Id"] != null)
                        dgvConsultations.Columns["Id"].Visible = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erreur: {ex.Message}", "Erreur",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnValider_Click(object sender, EventArgs e)
        {
            if (dgvConsultations.CurrentRow == null)
            {
                MessageBox.Show("Sélectionnez une consultation", "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ConsultationId = (int)dgvConsultations.CurrentRow.Cells["Id"].Value;
            AnimalNom = dgvConsultations.CurrentRow.Cells["Animal"].Value?.ToString() ?? "";

            using (SqlConnection conn = connexionBD.GetConnection())
            {
                conn.Open();
                string sql = "SELECT AnimalId FROM Consultation WHERE Id = @Id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Id", ConsultationId);
                AnimalId = (int)cmd.ExecuteScalar();
            }

            // Demander le montant
            FormMontantFacture formMontant = new FormMontantFacture();
            if (formMontant.ShowDialog() == DialogResult.OK)
            {
                MontantHT = formMontant.MontantHT;
                DialogResult = DialogResult.OK;
                this.Close();
            }
        }



        private void FormChoisirConsultation_Load(object sender, EventArgs e)
        {

        }

        private void btnAnnuler_Click_1(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

   
    }
}