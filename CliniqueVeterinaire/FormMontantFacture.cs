using System;
using System.Windows.Forms;
using System.Drawing;

namespace CliniqueVeterinaire
{
    public partial class FormMontantFacture : Form
    {
        public decimal MontantHT { get; private set; }

        public FormMontantFacture()
        {
            InitializeComponent();

            // Configurer le label
            lblMontant.Text = "💰 Montant HT (DT):";
            lblMontant.Font = new Font("Arial", 9, FontStyle.Bold);
            lblMontant.ForeColor = Color.DarkBlue;
        }

        private void btnValider_Click_1(object sender, EventArgs e)
        {
            if (!decimal.TryParse(txtMontant.Text, out decimal montant) || montant <= 0)
            {
                MessageBox.Show("Veuillez saisir un montant valide (supérieur à 0)",
                    "Montant invalide", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMontant.Focus();
                return;
            }

            MontantHT = montant;
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnAnnuler_Click_1(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void txtMontant_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permettre seulement les chiffres, virgule et point
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                e.KeyChar != ',' && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // Permettre un seul séparateur décimal
            if ((e.KeyChar == ',' || e.KeyChar == '.') &&
                (txtMontant.Text.Contains(",") || txtMontant.Text.Contains(".")))
            {
                e.Handled = true;
            }
        }

        private void FormMontantFacture_Load(object sender, EventArgs e)
        {

        }


    }
}