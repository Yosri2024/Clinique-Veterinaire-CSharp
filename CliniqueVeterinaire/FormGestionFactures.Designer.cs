namespace CliniqueVeterinaire
{
    partial class FormGestionFactures
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dgvFactures = new DataGridView();
            btnGenererFacture = new Button();
            btnMarquerPayee = new Button();
            btnActualiser = new Button();
            btnFermer = new Button();
            btnImprimer = new Button();
            groupBoxDetails = new GroupBox();
            chkPaye = new CheckBox();
            cmbModePaiement = new ComboBox();
            lblModePaiement = new Label();
            dtpDate = new DateTimePicker();
            btnEnregistrer = new Button();
            lblDate = new Label();
            txtTVA = new TextBox();
            lblTVA = new Label();
            txtMontantTTC = new TextBox();
            lblMontantTTC = new Label();
            txtMontantHT = new TextBox();
            lblMontantHT = new Label();
            txtNumero = new TextBox();
            lblNumero = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvFactures).BeginInit();
            groupBoxDetails.SuspendLayout();
            SuspendLayout();
            // 
            // dgvFactures
            // 
            dgvFactures.AllowUserToAddRows = false;
            dgvFactures.AllowUserToDeleteRows = false;
            dgvFactures.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvFactures.Location = new Point(20, 20);
            dgvFactures.Name = "dgvFactures";
            dgvFactures.ReadOnly = true;
            dgvFactures.RowHeadersVisible = false;
            dgvFactures.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvFactures.Size = new Size(750, 300);
            dgvFactures.TabIndex = 0;
            // 
            // btnGenererFacture
            // 
            btnGenererFacture.BackColor = Color.LightGreen;
            btnGenererFacture.Location = new Point(800, 40);
            btnGenererFacture.Name = "btnGenererFacture";
            btnGenererFacture.Size = new Size(150, 40);
            btnGenererFacture.TabIndex = 1;
            btnGenererFacture.Text = "Générer Facture";
            btnGenererFacture.UseVisualStyleBackColor = false;
            btnGenererFacture.Click += btnGenererFacture_Click;
            // 
            // btnMarquerPayee
            // 
            btnMarquerPayee.BackColor = Color.LightSkyBlue;
            btnMarquerPayee.Location = new Point(801, 100);
            btnMarquerPayee.Name = "btnMarquerPayee";
            btnMarquerPayee.Size = new Size(150, 40);
            btnMarquerPayee.TabIndex = 2;
            btnMarquerPayee.Text = "Marquer Payée";
            btnMarquerPayee.UseVisualStyleBackColor = false;
            btnMarquerPayee.Click += btnMarquerPayee_Click;
            // 
            // btnActualiser
            // 
            btnActualiser.BackColor = Color.LightBlue;
            btnActualiser.Location = new Point(800, 160);
            btnActualiser.Name = "btnActualiser";
            btnActualiser.Size = new Size(150, 40);
            btnActualiser.TabIndex = 3;
            btnActualiser.Text = "Actualiser";
            btnActualiser.UseVisualStyleBackColor = false;
            btnActualiser.Click += btnActualiser_Click;
            // 
            // btnFermer
            // 
            btnFermer.BackColor = Color.LightCoral;
            btnFermer.Location = new Point(800, 280);
            btnFermer.Name = "btnFermer";
            btnFermer.Size = new Size(150, 40);
            btnFermer.TabIndex = 4;
            btnFermer.Text = "Fermer";
            btnFermer.UseVisualStyleBackColor = false;
            btnFermer.Click += btnFermer_Click;
            // 
            // btnImprimer
            // 
            btnImprimer.BackColor = Color.LightGray;
            btnImprimer.Location = new Point(800, 220);
            btnImprimer.Name = "btnImprimer";
            btnImprimer.Size = new Size(150, 40);
            btnImprimer.TabIndex = 5;
            btnImprimer.Text = "Imprimer";
            btnImprimer.UseVisualStyleBackColor = false;
            btnImprimer.Click += btnImprimer_Click;
            // 
            // groupBoxDetails
            // 
            groupBoxDetails.Controls.Add(chkPaye);
            groupBoxDetails.Controls.Add(cmbModePaiement);
            groupBoxDetails.Controls.Add(lblModePaiement);
            groupBoxDetails.Controls.Add(dtpDate);
            groupBoxDetails.Controls.Add(btnEnregistrer);
            groupBoxDetails.Controls.Add(lblDate);
            groupBoxDetails.Controls.Add(txtTVA);
            groupBoxDetails.Controls.Add(lblTVA);
            groupBoxDetails.Controls.Add(txtMontantTTC);
            groupBoxDetails.Controls.Add(lblMontantTTC);
            groupBoxDetails.Controls.Add(txtMontantHT);
            groupBoxDetails.Controls.Add(lblMontantHT);
            groupBoxDetails.Controls.Add(txtNumero);
            groupBoxDetails.Controls.Add(lblNumero);
            groupBoxDetails.Enabled = false;
            groupBoxDetails.Location = new Point(20, 340);
            groupBoxDetails.Name = "groupBoxDetails";
            groupBoxDetails.Size = new Size(930, 180);
            groupBoxDetails.TabIndex = 7;
            groupBoxDetails.TabStop = false;
            groupBoxDetails.Text = "Détails de la facture";
            // 
            // chkPaye
            // 
            chkPaye.AutoSize = true;
            chkPaye.Location = new Point(350, 111);
            chkPaye.Name = "chkPaye";
            chkPaye.Size = new Size(57, 19);
            chkPaye.TabIndex = 17;
            chkPaye.Text = "Payée";
            chkPaye.UseVisualStyleBackColor = true;
            // 
            // cmbModePaiement
            // 
            cmbModePaiement.FormattingEnabled = true;
            cmbModePaiement.Location = new Point(150, 107);
            cmbModePaiement.Name = "cmbModePaiement";
            cmbModePaiement.Size = new Size(150, 23);
            cmbModePaiement.TabIndex = 16;
            // 
            // lblModePaiement
            // 
            lblModePaiement.Location = new Point(30, 110);
            lblModePaiement.Name = "lblModePaiement";
            lblModePaiement.Size = new Size(80, 25);
            lblModePaiement.TabIndex = 15;
            lblModePaiement.Text = "Mode paiement:";
            // 
            // dtpDate
            // 
            dtpDate.Location = new Point(420, 28);
            dtpDate.Name = "dtpDate";
            dtpDate.Size = new Size(203, 23);
            dtpDate.TabIndex = 13;
            // 
            // btnEnregistrer
            // 
            btnEnregistrer.BackColor = Color.MediumSeaGreen;
            btnEnregistrer.Location = new Point(806, 139);
            btnEnregistrer.Name = "btnEnregistrer";
            btnEnregistrer.Size = new Size(100, 35);
            btnEnregistrer.TabIndex = 12;
            btnEnregistrer.Text = "Enregistrer";
            btnEnregistrer.UseVisualStyleBackColor = false;
            btnEnregistrer.Click += btnEnregistrer_Click;
            // 
            // lblDate
            // 
            lblDate.AutoSize = true;
            lblDate.Location = new Point(350, 30);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(34, 15);
            lblDate.TabIndex = 10;
            lblDate.Text = "Date:";
            // 
            // txtTVA
            // 
            txtTVA.Location = new Point(420, 68);
            txtTVA.Name = "txtTVA";
            txtTVA.Size = new Size(150, 23);
            txtTVA.TabIndex = 7;
            txtTVA.Text = "20";
            // 
            // lblTVA
            // 
            lblTVA.Location = new Point(350, 70);
            lblTVA.Name = "lblTVA";
            lblTVA.Size = new Size(66, 25);
            lblTVA.TabIndex = 6;
            lblTVA.Text = "TVA (%):";
            // 
            // txtMontantTTC
            // 
            txtMontantTTC.Location = new Point(756, 67);
            txtMontantTTC.Name = "txtMontantTTC";
            txtMontantTTC.Size = new Size(150, 23);
            txtMontantTTC.TabIndex = 5;
            // 
            // lblMontantTTC
            // 
            lblMontantTTC.AutoSize = true;
            lblMontantTTC.Location = new Point(645, 70);
            lblMontantTTC.Name = "lblMontantTTC";
            lblMontantTTC.Size = new Size(105, 15);
            lblMontantTTC.TabIndex = 4;
            lblMontantTTC.Text = "Montant TTC (DT):";
            // 
            // txtMontantHT
            // 
            txtMontantHT.Location = new Point(150, 68);
            txtMontantHT.Name = "txtMontantHT";
            txtMontantHT.Size = new Size(150, 23);
            txtMontantHT.TabIndex = 3;
            // 
            // lblMontantHT
            // 
            lblMontantHT.AutoSize = true;
            lblMontantHT.Location = new Point(30, 70);
            lblMontantHT.Name = "lblMontantHT";
            lblMontantHT.Size = new Size(100, 15);
            lblMontantHT.TabIndex = 2;
            lblMontantHT.Text = "Montant HT (DT):";
            // 
            // txtNumero
            // 
            txtNumero.Location = new Point(150, 27);
            txtNumero.Name = "txtNumero";
            txtNumero.Size = new Size(150, 23);
            txtNumero.TabIndex = 1;
            // 
            // lblNumero
            // 
            lblNumero.AutoSize = true;
            lblNumero.Location = new Point(30, 30);
            lblNumero.Name = "lblNumero";
            lblNumero.Size = new Size(94, 15);
            lblNumero.TabIndex = 0;
            lblNumero.Text = "Numéro facture:";
            // 
            // FormGestionFactures
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ScrollBar;
            ClientSize = new Size(1084, 561);
            Controls.Add(groupBoxDetails);
            Controls.Add(btnImprimer);
            Controls.Add(btnFermer);
            Controls.Add(btnActualiser);
            Controls.Add(btnMarquerPayee);
            Controls.Add(btnGenererFacture);
            Controls.Add(dgvFactures);
            Name = "FormGestionFactures";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Gestion des Factures - Clinique Vétérinaire";
            Load += FormGestionFactures_Load;
            ((System.ComponentModel.ISupportInitialize)dgvFactures).EndInit();
            groupBoxDetails.ResumeLayout(false);
            groupBoxDetails.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvFactures;
        private Button btnGenererFacture;
        private Button btnMarquerPayee;
        private Button btnActualiser;
        private Button btnFermer;
        private Button btnImprimer;
        private GroupBox groupBoxDetails;
        private Label lblModePaiement;
        private DateTimePicker dtpDate;
        private Button btnEnregistrer;
        private Label lblDate;
        private TextBox txtTVA;
        private Label lblTVA;
        private TextBox txtMontantTTC;
        private Label lblMontantTTC;
        private TextBox txtMontantHT;
        private Label lblMontantHT;
        private TextBox txtNumero;
        private Label lblNumero;
        private CheckBox chkPaye;
        private ComboBox cmbModePaiement;
    }
}