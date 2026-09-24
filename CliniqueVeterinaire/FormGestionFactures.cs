using System;
using System.Data;
using System.IO;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextFont = iTextSharp.text.Font;//System.Drawing.Font

namespace CliniqueVeterinaire
{
    public partial class FormGestionFactures : Form
    {
        private ConnexionBD connexionBD;
        private int consultationIdSelectionne = 0;
        private int animalIdSelectionne = 0;

        public FormGestionFactures()
        {
            InitializeComponent();
            connexionBD = new ConnexionBD();

            cmbModePaiement.Items.AddRange(new string[] { "Espèces", "Carte bancaire", "Chèque", "Virement" });

            ChargerFactures();
            groupBoxDetails.Enabled = false;
        }

        private void ChargerFactures()
        {
            using (SqlConnection conn = connexionBD.GetConnection())
            {
                try
                {
                    conn.Open();
                    string sql = @"SELECT f.Id, f.NumeroFacture, 
                                          CONVERT(VARCHAR, f.DateFacture, 103) AS DateFacture,
                                          f.MontantHT, f.TVA, f.MontantTTC,
                                          CASE WHEN f.Paye = 1 THEN 'Payée' ELSE 'Non payée' END AS Statut,
                                          f.ModePaiement,
                                          a.Nom AS Animal,
                                          p.Nom + ' ' + p.Prenom AS Proprietaire,
                                          c.Diagnostic
                                   FROM Facture f
                                   JOIN Animal a ON f.AnimalId = a.Id
                                   JOIN Proprietaire p ON a.ProprietaireId = p.Id
                                   JOIN Consultation c ON f.ConsultationId = c.Id
                                   ORDER BY f.DateFacture DESC";
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvFactures.DataSource = dt;

                    if (dgvFactures.Columns["Id"] != null)
                        dgvFactures.Columns["Id"].Visible = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur: " + ex.Message, "Erreur",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnGenererFacture_Click(object sender, EventArgs e)
        {
            FormChoisirConsultation form = new FormChoisirConsultation();
            if (form.ShowDialog() == DialogResult.OK)
            {
                consultationIdSelectionne = form.ConsultationId;
                animalIdSelectionne = form.AnimalId;

                groupBoxDetails.Enabled = true;
                groupBoxDetails.Text = $"Nouvelle facture - {form.AnimalNom}";

                txtNumero.Text = $"FACT-{DateTime.Now:yyyyMMdd-HHmmss}";
                dtpDate.Value = DateTime.Now;
                txtMontantHT.Text = form.MontantHT.ToString("0.00");
                txtTVA.Text = "20";
                CalculerMontantTTC();
                txtMontantHT.Focus();
            }
        }

        private void CalculerMontantTTC()
        {
            if (decimal.TryParse(txtMontantHT.Text, out decimal ht) &&
                decimal.TryParse(txtTVA.Text, out decimal tva))
            {
                decimal ttc = ht + (ht * tva / 100);
                txtMontantTTC.Text = ttc.ToString("0.00");
            }
        }

        private void txtMontantHT_TextChanged(object sender, EventArgs e)
        {
            CalculerMontantTTC();
        }

        private void txtTVA_TextChanged(object sender, EventArgs e)
        {
            CalculerMontantTTC();
        }

        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNumero.Text))
            {
                MessageBox.Show("Numéro de facture obligatoire", "Champ manquant",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNumero.Focus();
                return;
            }

            if (!decimal.TryParse(txtMontantHT.Text, out decimal montantHT) || montantHT <= 0)
            {
                MessageBox.Show("Montant HT invalide", "Erreur",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMontantHT.Focus();
                return;
            }

            if (!decimal.TryParse(txtTVA.Text, out decimal tva) || tva < 0)
            {
                MessageBox.Show("TVA invalide", "Erreur",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTVA.Focus();
                return;
            }

            if (chkPaye.Checked && string.IsNullOrWhiteSpace(cmbModePaiement.Text))
            {
                MessageBox.Show("Mode de paiement obligatoire si facture payée", "Champ manquant",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbModePaiement.Focus();
                return;
            }

            using (SqlConnection conn = connexionBD.GetConnection())
            {
                try
                {
                    conn.Open();
                    string sql = @"INSERT INTO Facture (NumeroFacture, DateFacture, MontantHT, TVA, MontantTTC, 
                                                       Paye, ModePaiement, DatePaiement, ConsultationId, AnimalId)
                                   VALUES (@Numero, @Date, @MontantHT, @TVA, @MontantTTC, 
                                           @Paye, @Mode, @DatePaiement, @ConsultationId, @AnimalId)";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@Numero", txtNumero.Text.Trim());
                    cmd.Parameters.AddWithValue("@Date", dtpDate.Value);
                    cmd.Parameters.AddWithValue("@MontantHT", montantHT);
                    cmd.Parameters.AddWithValue("@TVA", tva);
                    cmd.Parameters.AddWithValue("@MontantTTC", decimal.Parse(txtMontantTTC.Text));
                    cmd.Parameters.AddWithValue("@Paye", chkPaye.Checked ? 1 : 0);
                    cmd.Parameters.AddWithValue("@Mode", chkPaye.Checked ? cmbModePaiement.Text : (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@DatePaiement", chkPaye.Checked ? DateTime.Now : (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@ConsultationId", consultationIdSelectionne);
                    cmd.Parameters.AddWithValue("@AnimalId", animalIdSelectionne);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Facture générée avec succès", "Succès",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    groupBoxDetails.Enabled = false;
                    groupBoxDetails.Text = "Détails de la facture";
                    consultationIdSelectionne = 0;
                    animalIdSelectionne = 0;
                    ClearForm();
                    ChargerFactures();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur: " + ex.Message, "Erreur",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnMarquerPayee_Click(object sender, EventArgs e)
        {
            if (dgvFactures.CurrentRow == null)
            {
                MessageBox.Show("Sélectionnez une facture", "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int id = (int)dgvFactures.CurrentRow.Cells["Id"].Value;
            string statut = dgvFactures.CurrentRow.Cells["Statut"].Value?.ToString() ?? "";

            if (statut.Contains("Payée"))
            {
                MessageBox.Show("Cette facture est déjà payée", "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult result = MessageBox.Show("Marquer cette facture comme payée ?",
                "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                using (SqlConnection conn = connexionBD.GetConnection())
                {
                    try
                    {
                        conn.Open();
                        string sql = "UPDATE Facture SET Paye = 1, DatePaiement = @Date WHERE Id = @Id";
                        SqlCommand cmd = new SqlCommand(sql, conn);
                        cmd.Parameters.AddWithValue("@Date", DateTime.Now);
                        cmd.Parameters.AddWithValue("@Id", id);
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Facture marquée comme payée", "Succès",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ChargerFactures();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erreur: " + ex.Message, "Erreur",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnActualiser_Click(object sender, EventArgs e)
        {
            ChargerFactures();
            MessageBox.Show("Liste des factures actualisée", "Actualisation",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnImprimer_Click(object sender, EventArgs e)
        {
            if (dgvFactures.CurrentRow == null)
            {
                MessageBox.Show("Sélectionnez une facture à imprimer", "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                string numero = dgvFactures.CurrentRow.Cells["NumeroFacture"].Value?.ToString() ?? "";
                string date = dgvFactures.CurrentRow.Cells["DateFacture"].Value?.ToString() ?? "";
                string montantHT = dgvFactures.CurrentRow.Cells["MontantHT"].Value?.ToString() ?? "";
                string tva = dgvFactures.CurrentRow.Cells["TVA"].Value?.ToString() ?? "";
                string montantTTC = dgvFactures.CurrentRow.Cells["MontantTTC"].Value?.ToString() ?? "";
                string statut = dgvFactures.CurrentRow.Cells["Statut"].Value?.ToString() ?? "";
                string animal = dgvFactures.CurrentRow.Cells["Animal"].Value?.ToString() ?? "";
                string proprietaire = dgvFactures.CurrentRow.Cells["Proprietaire"].Value?.ToString() ?? "";
                string diagnostic = dgvFactures.CurrentRow.Cells["Diagnostic"].Value?.ToString() ?? "";

                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "PDF files (*.pdf)|*.pdf";
                saveFileDialog.FileName = $"Facture_{numero}_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";
                saveFileDialog.Title = "Enregistrer la facture PDF";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    using (FileStream stream = new FileStream(saveFileDialog.FileName, FileMode.Create))
                    {
                        Document document = new Document(PageSize.A4, 50, 50, 50, 50);
                        PdfWriter.GetInstance(document, stream);
                        document.Open();

                        iTextFont titleFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 18);
                        iTextFont headerFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12);
                        iTextFont normalFont = FontFactory.GetFont(FontFactory.HELVETICA, 10);
                        iTextFont boldFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10);

                        Paragraph title = new Paragraph("CLINIQUE VÉTÉRINAIRE", titleFont);
                        title.Alignment = Element.ALIGN_CENTER;
                        document.Add(title);

                        Paragraph address = new Paragraph("15 Rue de la Liberté, 1002 Tunis\nTél: 71 234 567 | Email: contact@clinique.tn", normalFont);
                        address.Alignment = Element.ALIGN_CENTER;
                        document.Add(address);

                        document.Add(new Paragraph("\n"));

                        Paragraph invoiceTitle = new Paragraph($"FACTURE N° {numero}", headerFont);
                        invoiceTitle.Alignment = Element.ALIGN_CENTER;
                        document.Add(invoiceTitle);

                        document.Add(new Paragraph("\n"));

                        document.Add(new Paragraph("INFORMATIONS CLIENT", headerFont));
                        document.Add(new Paragraph($"Propriétaire: {proprietaire}", normalFont));
                        document.Add(new Paragraph($"Animal: {animal}", normalFont));
                        document.Add(new Paragraph($"Motif: {diagnostic}", normalFont));

                        document.Add(new Paragraph("\n"));

                        document.Add(new Paragraph("DÉTAILS DE LA FACTURE", headerFont));
                        document.Add(new Paragraph(" "));

                        PdfPTable table = new PdfPTable(2);
                        table.WidthPercentage = 100;
                        table.SetWidths(new float[] { 40f, 60f });

                        AddTableRow(table, "Date facture:", date, boldFont, normalFont);
                        AddTableRow(table, "Montant HT:", $"{montantHT} DT", boldFont, normalFont);
                        AddTableRow(table, "TVA:", $"{tva} %", boldFont, normalFont);
                        AddTableRow(table, "Montant TTC:", $"{montantTTC} DT", boldFont, normalFont);
                        AddTableRow(table, "Statut:", statut, boldFont, normalFont);

                        document.Add(table);

                        document.Add(new Paragraph("\n"));

                        Paragraph total = new Paragraph($"TOTAL À PAYER : {montantTTC} DT", boldFont);
                        total.Alignment = Element.ALIGN_RIGHT;
                        document.Add(total);

                        document.Add(new Paragraph("\n\n\n"));

                        Paragraph footer = new Paragraph("Merci de votre confiance !", normalFont);
                        footer.Alignment = Element.ALIGN_CENTER;
                        document.Add(footer);

                        document.Close();
                    }

                    MessageBox.Show($"Facture {numero} générée avec succès !\nEmplacement: {saveFileDialog.FileName}",
                        "Impression PDF", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de l'impression: " + ex.Message, "Erreur",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddTableRow(PdfPTable table, string label, string value, iTextFont boldFont, iTextFont normalFont)
        {
            PdfPCell cellLabel = new PdfPCell(new Phrase(label, boldFont));
            cellLabel.Border = PdfPCell.NO_BORDER;
            cellLabel.Padding = 5;
            table.AddCell(cellLabel);

            PdfPCell cellValue = new PdfPCell(new Phrase(value, normalFont));
            cellValue.Border = PdfPCell.NO_BORDER;
            cellValue.Padding = 5;
            table.AddCell(cellValue);
        }

        private void btnFermer_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvFactures_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvFactures.CurrentRow == null) return;

            int id = (int)dgvFactures.CurrentRow.Cells["Id"].Value;

            using (SqlConnection conn = connexionBD.GetConnection())
            {
                try
                {
                    conn.Open();
                    string sql = @"SELECT NumeroFacture, DateFacture, MontantHT, TVA, MontantTTC, 
                                          Paye, ModePaiement, ConsultationId, AnimalId
                                   FROM Facture WHERE Id = @Id";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@Id", id);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        consultationIdSelectionne = (int)reader["ConsultationId"];
                        animalIdSelectionne = (int)reader["AnimalId"];

                        txtNumero.Text = reader["NumeroFacture"].ToString();
                        dtpDate.Value = (DateTime)reader["DateFacture"];
                        txtMontantHT.Text = reader["MontantHT"].ToString();
                        txtTVA.Text = reader["TVA"].ToString();
                        txtMontantTTC.Text = reader["MontantTTC"].ToString();
                        chkPaye.Checked = (bool)reader["Paye"];
                        cmbModePaiement.Text = reader["ModePaiement"]?.ToString() ?? "";

                        groupBoxDetails.Enabled = true;
                        groupBoxDetails.Text = "Modifier la facture";
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur: " + ex.Message, "Erreur",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ClearForm()
        {
            txtNumero.Text = "";
            txtMontantHT.Text = "";
            txtTVA.Text = "20";
            txtMontantTTC.Text = "";
            cmbModePaiement.SelectedIndex = -1;
            chkPaye.Checked = false;
        }

        private void btnNouvelleFacture_Click(object sender, EventArgs e)
        {
            groupBoxDetails.Enabled = true;
            groupBoxDetails.Text = "Nouvelle facture";
            ClearForm();
            consultationIdSelectionne = 0;
            animalIdSelectionne = 0;
            txtNumero.Text = $"FACT-{DateTime.Now:yyyyMMdd-HHmmss}";
            dtpDate.Value = DateTime.Now;
            txtMontantHT.Focus();
        }

        private void FormGestionFactures_Load(object sender, EventArgs e)
        {

        }
    }
}