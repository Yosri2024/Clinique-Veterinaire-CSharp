namespace CliniqueVeterinaire
{
    partial class FormGestionStock
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
            dgvMedicaments = new DataGridView();
            btnAjouter = new Button();
            btnSupprimer = new Button();
            btnActualiser = new Button();
            btnModifier = new Button();
            btnFermer = new Button();
            groupBoxForm = new GroupBox();
            labelFournisseur = new Label();
            txtFournisseur = new TextBox();
            dtpExpiration = new DateTimePicker();
            btnEnregistrer = new Button();
            labelExpiration = new Label();
            txtSeuil = new TextBox();
            labelSeuil = new Label();
            txtQuantite = new TextBox();
            labelQuantite = new Label();
            txtPrix = new TextBox();
            labelPrix = new Label();
            txtDescription = new TextBox();
            labelDescription = new Label();
            txtNom = new TextBox();
            labelNom = new Label();
            lblAlerteStock = new Label();
            lblAlerteExpiration = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvMedicaments).BeginInit();
            groupBoxForm.SuspendLayout();
            SuspendLayout();
            // 
            // dgvMedicaments
            // 
            dgvMedicaments.AllowUserToAddRows = false;
            dgvMedicaments.AllowUserToDeleteRows = false;
            dgvMedicaments.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMedicaments.Location = new Point(20, 20);
            dgvMedicaments.Name = "dgvMedicaments";
            dgvMedicaments.ReadOnly = true;
            dgvMedicaments.RowHeadersVisible = false;
            dgvMedicaments.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMedicaments.Size = new Size(600, 212);
            dgvMedicaments.TabIndex = 0;
            // 
            // btnAjouter
            // 
            btnAjouter.BackColor = Color.LightGreen;
            btnAjouter.Location = new Point(640, 20);
            btnAjouter.Name = "btnAjouter";
            btnAjouter.Size = new Size(120, 35);
            btnAjouter.TabIndex = 1;
            btnAjouter.Text = "Ajouter";
            btnAjouter.UseVisualStyleBackColor = false;
            btnAjouter.Click += btnAjouter_Click;
            // 
            // btnSupprimer
            // 
            btnSupprimer.BackColor = Color.LightCoral;
            btnSupprimer.Location = new Point(640, 127);
            btnSupprimer.Name = "btnSupprimer";
            btnSupprimer.Size = new Size(120, 35);
            btnSupprimer.TabIndex = 2;
            btnSupprimer.Text = "Supprimer";
            btnSupprimer.UseVisualStyleBackColor = false;
            btnSupprimer.Click += btnSupprimer_Click;
            // 
            // btnActualiser
            // 
            btnActualiser.BackColor = Color.LightBlue;
            btnActualiser.Location = new Point(640, 184);
            btnActualiser.Name = "btnActualiser";
            btnActualiser.Size = new Size(120, 35);
            btnActualiser.TabIndex = 3;
            btnActualiser.Text = "Actualiser";
            btnActualiser.UseVisualStyleBackColor = false;
            btnActualiser.Click += btnActualiser_Click;
            // 
            // btnModifier
            // 
            btnModifier.BackColor = Color.LightSkyBlue;
            btnModifier.Location = new Point(640, 77);
            btnModifier.Name = "btnModifier";
            btnModifier.Size = new Size(120, 35);
            btnModifier.TabIndex = 4;
            btnModifier.Text = "Modifier";
            btnModifier.UseVisualStyleBackColor = false;
            btnModifier.Click += btnModifier_Click;
            // 
            // btnFermer
            // 
            btnFermer.BackColor = Color.LightGray;
            btnFermer.Location = new Point(640, 256);
            btnFermer.Name = "btnFermer";
            btnFermer.Size = new Size(120, 35);
            btnFermer.TabIndex = 5;
            btnFermer.Text = "Fermer";
            btnFermer.UseVisualStyleBackColor = false;
            btnFermer.Click += btnFermer_Click;
            // 
            // groupBoxForm
            // 
            groupBoxForm.Controls.Add(labelFournisseur);
            groupBoxForm.Controls.Add(txtFournisseur);
            groupBoxForm.Controls.Add(dtpExpiration);
            groupBoxForm.Controls.Add(btnEnregistrer);
            groupBoxForm.Controls.Add(labelExpiration);
            groupBoxForm.Controls.Add(txtSeuil);
            groupBoxForm.Controls.Add(labelSeuil);
            groupBoxForm.Controls.Add(txtQuantite);
            groupBoxForm.Controls.Add(labelQuantite);
            groupBoxForm.Controls.Add(txtPrix);
            groupBoxForm.Controls.Add(labelPrix);
            groupBoxForm.Controls.Add(txtDescription);
            groupBoxForm.Controls.Add(labelDescription);
            groupBoxForm.Controls.Add(txtNom);
            groupBoxForm.Controls.Add(labelNom);
            groupBoxForm.Enabled = false;
            groupBoxForm.Location = new Point(20, 328);
            groupBoxForm.Name = "groupBoxForm";
            groupBoxForm.Size = new Size(672, 201);
            groupBoxForm.TabIndex = 6;
            groupBoxForm.TabStop = false;
            groupBoxForm.Text = "Informations Médicament";
            // 
            // labelFournisseur
            // 
            labelFournisseur.Location = new Point(20, 140);
            labelFournisseur.Name = "labelFournisseur";
            labelFournisseur.Size = new Size(80, 25);
            labelFournisseur.TabIndex = 15;
            labelFournisseur.Text = "Fournisseur:";
            // 
            // txtFournisseur
            // 
            txtFournisseur.Location = new Point(119, 137);
            txtFournisseur.Name = "txtFournisseur";
            txtFournisseur.Size = new Size(150, 23);
            txtFournisseur.TabIndex = 14;
            // 
            // dtpExpiration
            // 
            dtpExpiration.Location = new Point(375, 100);
            dtpExpiration.Name = "dtpExpiration";
            dtpExpiration.Size = new Size(203, 23);
            dtpExpiration.TabIndex = 13;
            // 
            // btnEnregistrer
            // 
            btnEnregistrer.BackColor = Color.MediumSeaGreen;
            btnEnregistrer.Location = new Point(567, 160);
            btnEnregistrer.Name = "btnEnregistrer";
            btnEnregistrer.Size = new Size(100, 35);
            btnEnregistrer.TabIndex = 12;
            btnEnregistrer.Text = "Enregistrer";
            btnEnregistrer.UseVisualStyleBackColor = false;
            btnEnregistrer.Click += btnEnregistrer_Click;
            // 
            // labelExpiration
            // 
            labelExpiration.AutoSize = true;
            labelExpiration.Location = new Point(285, 103);
            labelExpiration.Name = "labelExpiration";
            labelExpiration.Size = new Size(89, 15);
            labelExpiration.TabIndex = 10;
            labelExpiration.Text = "Date Expiration:";
            // 
            // txtSeuil
            // 
            txtSeuil.Location = new Point(375, 67);
            txtSeuil.Name = "txtSeuil";
            txtSeuil.Size = new Size(150, 23);
            txtSeuil.TabIndex = 11;
            // 
            // labelSeuil
            // 
            labelSeuil.AutoSize = true;
            labelSeuil.Location = new Point(285, 73);
            labelSeuil.Name = "labelSeuil";
            labelSeuil.Size = new Size(69, 15);
            labelSeuil.TabIndex = 8;
            labelSeuil.Text = "Seuil Alerte:";
            // 
            // txtQuantite
            // 
            txtQuantite.Location = new Point(375, 30);
            txtQuantite.Name = "txtQuantite";
            txtQuantite.Size = new Size(150, 23);
            txtQuantite.TabIndex = 7;
            // 
            // labelQuantite
            // 
            labelQuantite.Location = new Point(285, 36);
            labelQuantite.Name = "labelQuantite";
            labelQuantite.Size = new Size(100, 25);
            labelQuantite.TabIndex = 6;
            labelQuantite.Text = "Quantité:";
            // 
            // txtPrix
            // 
            txtPrix.Location = new Point(119, 100);
            txtPrix.Name = "txtPrix";
            txtPrix.Size = new Size(150, 23);
            txtPrix.TabIndex = 5;
            // 
            // labelPrix
            // 
            labelPrix.AutoSize = true;
            labelPrix.Location = new Point(20, 106);
            labelPrix.Name = "labelPrix";
            labelPrix.Size = new Size(98, 15);
            labelPrix.TabIndex = 4;
            labelPrix.Text = "Prix Unitaire (DT):";
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(119, 65);
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(150, 23);
            txtDescription.TabIndex = 3;
            // 
            // labelDescription
            // 
            labelDescription.AutoSize = true;
            labelDescription.Location = new Point(20, 73);
            labelDescription.Name = "labelDescription";
            labelDescription.Size = new Size(70, 15);
            labelDescription.TabIndex = 2;
            labelDescription.Text = "Description:";
            // 
            // txtNom
            // 
            txtNom.Location = new Point(119, 30);
            txtNom.Name = "txtNom";
            txtNom.Size = new Size(150, 23);
            txtNom.TabIndex = 1;
            // 
            // labelNom
            // 
            labelNom.AutoSize = true;
            labelNom.Location = new Point(20, 36);
            labelNom.Name = "labelNom";
            labelNom.Size = new Size(37, 15);
            labelNom.TabIndex = 0;
            labelNom.Text = "Nom:";
            // 
            // lblAlerteStock
            // 
            lblAlerteStock.AutoSize = true;
            lblAlerteStock.ForeColor = Color.Red;
            lblAlerteStock.Location = new Point(20, 256);
            lblAlerteStock.Name = "lblAlerteStock";
            lblAlerteStock.Size = new Size(0, 15);
            lblAlerteStock.TabIndex = 7;
            // 
            // lblAlerteExpiration
            // 
            lblAlerteExpiration.AutoSize = true;
            lblAlerteExpiration.ForeColor = Color.DarkOrange;
            lblAlerteExpiration.Location = new Point(20, 284);
            lblAlerteExpiration.Name = "lblAlerteExpiration";
            lblAlerteExpiration.Size = new Size(0, 15);
            lblAlerteExpiration.TabIndex = 8;
            // 
            // FormGestionStock
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ScrollBar;
            ClientSize = new Size(776, 541);
            Controls.Add(lblAlerteExpiration);
            Controls.Add(lblAlerteStock);
            Controls.Add(groupBoxForm);
            Controls.Add(btnFermer);
            Controls.Add(btnModifier);
            Controls.Add(btnActualiser);
            Controls.Add(btnSupprimer);
            Controls.Add(btnAjouter);
            Controls.Add(dgvMedicaments);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FormGestionStock";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Gestion du Stock - Clinique Vétérinaire";
            Load += FormGestionStock_Load;
            ((System.ComponentModel.ISupportInitialize)dgvMedicaments).EndInit();
            groupBoxForm.ResumeLayout(false);
            groupBoxForm.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvMedicaments;
        private Button btnAjouter;
        private Button btnSupprimer;
        private Button btnActualiser;
        private Button btnModifier;
        private Button btnFermer;
        private GroupBox groupBoxForm;
        private Button btnEnregistrer;
        private Label labelExpiration;
        private TextBox txtSeuil;
        private Label labelSeuil;
        private TextBox txtQuantite;
        private Label labelQuantite;
        private TextBox txtPrix;
        private Label labelPrix;
        private TextBox txtDescription;
        private Label labelDescription;
        private TextBox txtNom;
        private Label labelNom;
        private DateTimePicker dtpExpiration;
        private Label labelFournisseur;
        private TextBox txtFournisseur;
        private Label lblAlerteStock;
        private Label lblAlerteExpiration;
    }
}