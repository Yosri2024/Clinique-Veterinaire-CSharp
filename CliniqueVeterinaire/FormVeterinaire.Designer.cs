namespace CliniqueVeterinaire
{
    partial class FormVeterinaire
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
            lblWelcomeVeto = new Label();
            tabControlVeterinaire = new TabControl();
            tabPlanning = new TabPage();
            btnActualiserPlanning = new Button();
            dgvPlanning = new DataGridView();
            tabConsultations = new TabPage();
            dgvHistoriqueConsult = new DataGridView();
            groupBoxAnimalInfo = new GroupBox();
            labelDateNaissConsult = new Label();
            dtpDateNaissConsult = new DateTimePicker();
            cmbAnimalConsult = new ComboBox();
            btnChargerAnimal = new Button();
            txtSexeConsult = new TextBox();
            labelSexeConsult = new Label();
            txtRaceConsult = new TextBox();
            labelRaceConsult = new Label();
            labelAnimalConsult = new Label();
            groupBoxConsultation = new GroupBox();
            btnEnregistrerConsult = new Button();
            txtRemarques = new TextBox();
            labelRemarques = new Label();
            txtTemperature = new TextBox();
            labelTemperature = new Label();
            txtPoids = new TextBox();
            labelPoids = new Label();
            txtTraitement = new TextBox();
            labelTraitement = new Label();
            txtDiagnostic = new TextBox();
            labelDiagnostic = new Label();
            tabDossierMedical = new TabPage();
            dgvVaccinations = new DataGridView();
            btnAjouterVaccin = new Button();
            dgvDossierMedical = new DataGridView();
            groupBoxRecherche = new GroupBox();
            btnRechercher = new Button();
            txtRechercheNom = new TextBox();
            labelRechercheNom = new Label();
            btnDeconnexionVeto = new Button();
            tabControlVeterinaire.SuspendLayout();
            tabPlanning.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPlanning).BeginInit();
            tabConsultations.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHistoriqueConsult).BeginInit();
            groupBoxAnimalInfo.SuspendLayout();
            groupBoxConsultation.SuspendLayout();
            tabDossierMedical.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvVaccinations).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvDossierMedical).BeginInit();
            groupBoxRecherche.SuspendLayout();
            SuspendLayout();
            // 
            // lblWelcomeVeto
            // 
            lblWelcomeVeto.AutoSize = true;
            lblWelcomeVeto.Location = new Point(20, 20);
            lblWelcomeVeto.Margin = new Padding(4, 0, 4, 0);
            lblWelcomeVeto.Name = "lblWelcomeVeto";
            lblWelcomeVeto.Size = new Size(0, 19);
            lblWelcomeVeto.TabIndex = 0;
            // 
            // tabControlVeterinaire
            // 
            tabControlVeterinaire.Controls.Add(tabPlanning);
            tabControlVeterinaire.Controls.Add(tabConsultations);
            tabControlVeterinaire.Controls.Add(tabDossierMedical);
            tabControlVeterinaire.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tabControlVeterinaire.Location = new Point(20, 60);
            tabControlVeterinaire.Name = "tabControlVeterinaire";
            tabControlVeterinaire.SelectedIndex = 0;
            tabControlVeterinaire.Size = new Size(807, 425);
            tabControlVeterinaire.TabIndex = 1;
            // 
            // tabPlanning
            // 
            tabPlanning.Controls.Add(btnActualiserPlanning);
            tabPlanning.Controls.Add(dgvPlanning);
            tabPlanning.Location = new Point(4, 29);
            tabPlanning.Name = "tabPlanning";
            tabPlanning.Padding = new Padding(3);
            tabPlanning.Size = new Size(799, 392);
            tabPlanning.TabIndex = 0;
            tabPlanning.Text = "Planning";
            tabPlanning.UseVisualStyleBackColor = true;
            // 
            // btnActualiserPlanning
            // 
            btnActualiserPlanning.BackColor = Color.LightBlue;
            btnActualiserPlanning.Location = new Point(645, 146);
            btnActualiserPlanning.Name = "btnActualiserPlanning";
            btnActualiserPlanning.Size = new Size(120, 35);
            btnActualiserPlanning.TabIndex = 1;
            btnActualiserPlanning.Text = "Actualiser";
            btnActualiserPlanning.UseVisualStyleBackColor = false;
            btnActualiserPlanning.Click += btnActualiserPlanning_Click;
            // 
            // dgvPlanning
            // 
            dgvPlanning.AllowUserToAddRows = false;
            dgvPlanning.AllowUserToDeleteRows = false;
            dgvPlanning.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPlanning.ImeMode = ImeMode.Off;
            dgvPlanning.Location = new Point(20, 20);
            dgvPlanning.Name = "dgvPlanning";
            dgvPlanning.ReadOnly = true;
            dgvPlanning.RowHeadersVisible = false;
            dgvPlanning.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPlanning.Size = new Size(600, 300);
            dgvPlanning.TabIndex = 0;
            // 
            // tabConsultations
            // 
            tabConsultations.Controls.Add(dgvHistoriqueConsult);
            tabConsultations.Controls.Add(groupBoxAnimalInfo);
            tabConsultations.Controls.Add(groupBoxConsultation);
            tabConsultations.Location = new Point(4, 29);
            tabConsultations.Name = "tabConsultations";
            tabConsultations.Padding = new Padding(3);
            tabConsultations.Size = new Size(799, 392);
            tabConsultations.TabIndex = 1;
            tabConsultations.Text = "Consultations";
            tabConsultations.UseVisualStyleBackColor = true;
            // 
            // dgvHistoriqueConsult
            // 
            dgvHistoriqueConsult.AllowUserToAddRows = false;
            dgvHistoriqueConsult.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHistoriqueConsult.Location = new Point(411, 31);
            dgvHistoriqueConsult.Name = "dgvHistoriqueConsult";
            dgvHistoriqueConsult.ReadOnly = true;
            dgvHistoriqueConsult.RowHeadersVisible = false;
            dgvHistoriqueConsult.Size = new Size(365, 150);
            dgvHistoriqueConsult.TabIndex = 2;
            // 
            // groupBoxAnimalInfo
            // 
            groupBoxAnimalInfo.Controls.Add(labelDateNaissConsult);
            groupBoxAnimalInfo.Controls.Add(dtpDateNaissConsult);
            groupBoxAnimalInfo.Controls.Add(cmbAnimalConsult);
            groupBoxAnimalInfo.Controls.Add(btnChargerAnimal);
            groupBoxAnimalInfo.Controls.Add(txtSexeConsult);
            groupBoxAnimalInfo.Controls.Add(labelSexeConsult);
            groupBoxAnimalInfo.Controls.Add(txtRaceConsult);
            groupBoxAnimalInfo.Controls.Add(labelRaceConsult);
            groupBoxAnimalInfo.Controls.Add(labelAnimalConsult);
            groupBoxAnimalInfo.Location = new Point(20, 20);
            groupBoxAnimalInfo.Name = "groupBoxAnimalInfo";
            groupBoxAnimalInfo.Size = new Size(385, 161);
            groupBoxAnimalInfo.TabIndex = 1;
            groupBoxAnimalInfo.TabStop = false;
            groupBoxAnimalInfo.Text = "Informations Animal";
            // 
            // labelDateNaissConsult
            // 
            labelDateNaissConsult.Location = new Point(20, 126);
            labelDateNaissConsult.Name = "labelDateNaissConsult";
            labelDateNaissConsult.Size = new Size(135, 25);
            labelDateNaissConsult.TabIndex = 16;
            labelDateNaissConsult.Text = "Date de naissance:";
            // 
            // dtpDateNaissConsult
            // 
            dtpDateNaissConsult.Location = new Point(161, 124);
            dtpDateNaissConsult.Name = "dtpDateNaissConsult";
            dtpDateNaissConsult.Size = new Size(218, 27);
            dtpDateNaissConsult.TabIndex = 15;
            // 
            // cmbAnimalConsult
            // 
            cmbAnimalConsult.FormattingEnabled = true;
            cmbAnimalConsult.Location = new Point(110, 24);
            cmbAnimalConsult.Name = "cmbAnimalConsult";
            cmbAnimalConsult.Size = new Size(143, 28);
            cmbAnimalConsult.TabIndex = 14;
            // 
            // btnChargerAnimal
            // 
            btnChargerAnimal.BackColor = Color.LightSteelBlue;
            btnChargerAnimal.Location = new Point(279, 26);
            btnChargerAnimal.Name = "btnChargerAnimal";
            btnChargerAnimal.Size = new Size(100, 35);
            btnChargerAnimal.TabIndex = 13;
            btnChargerAnimal.Text = "Charger";
            btnChargerAnimal.UseVisualStyleBackColor = false;
            btnChargerAnimal.Click += btnChargerAnimal_Click;
            // 
            // txtSexeConsult
            // 
            txtSexeConsult.Location = new Point(110, 88);
            txtSexeConsult.Name = "txtSexeConsult";
            txtSexeConsult.Size = new Size(143, 27);
            txtSexeConsult.TabIndex = 7;
            // 
            // labelSexeConsult
            // 
            labelSexeConsult.Location = new Point(20, 90);
            labelSexeConsult.Name = "labelSexeConsult";
            labelSexeConsult.Size = new Size(135, 25);
            labelSexeConsult.TabIndex = 6;
            labelSexeConsult.Text = "Sexe:";
            // 
            // txtRaceConsult
            // 
            txtRaceConsult.Location = new Point(110, 58);
            txtRaceConsult.Name = "txtRaceConsult";
            txtRaceConsult.Size = new Size(143, 27);
            txtRaceConsult.TabIndex = 3;
            // 
            // labelRaceConsult
            // 
            labelRaceConsult.Location = new Point(20, 60);
            labelRaceConsult.Name = "labelRaceConsult";
            labelRaceConsult.Size = new Size(109, 25);
            labelRaceConsult.TabIndex = 2;
            labelRaceConsult.Text = "Race:";
            // 
            // labelAnimalConsult
            // 
            labelAnimalConsult.Location = new Point(20, 30);
            labelAnimalConsult.Name = "labelAnimalConsult";
            labelAnimalConsult.Size = new Size(109, 25);
            labelAnimalConsult.TabIndex = 0;
            labelAnimalConsult.Text = "Animal:";
            // 
            // groupBoxConsultation
            // 
            groupBoxConsultation.Controls.Add(btnEnregistrerConsult);
            groupBoxConsultation.Controls.Add(txtRemarques);
            groupBoxConsultation.Controls.Add(labelRemarques);
            groupBoxConsultation.Controls.Add(txtTemperature);
            groupBoxConsultation.Controls.Add(labelTemperature);
            groupBoxConsultation.Controls.Add(txtPoids);
            groupBoxConsultation.Controls.Add(labelPoids);
            groupBoxConsultation.Controls.Add(txtTraitement);
            groupBoxConsultation.Controls.Add(labelTraitement);
            groupBoxConsultation.Controls.Add(txtDiagnostic);
            groupBoxConsultation.Controls.Add(labelDiagnostic);
            groupBoxConsultation.Location = new Point(20, 190);
            groupBoxConsultation.Name = "groupBoxConsultation";
            groupBoxConsultation.Size = new Size(756, 178);
            groupBoxConsultation.TabIndex = 0;
            groupBoxConsultation.TabStop = false;
            groupBoxConsultation.Text = "Consultation";
            // 
            // btnEnregistrerConsult
            // 
            btnEnregistrerConsult.BackColor = Color.MediumSeaGreen;
            btnEnregistrerConsult.Location = new Point(646, 121);
            btnEnregistrerConsult.Name = "btnEnregistrerConsult";
            btnEnregistrerConsult.Size = new Size(100, 35);
            btnEnregistrerConsult.TabIndex = 13;
            btnEnregistrerConsult.Text = "Enregistrer";
            btnEnregistrerConsult.UseVisualStyleBackColor = false;
            btnEnregistrerConsult.Click += btnEnregistrerConsult_Click;
            // 
            // txtRemarques
            // 
            txtRemarques.Location = new Point(605, 61);
            txtRemarques.Name = "txtRemarques";
            txtRemarques.Size = new Size(141, 27);
            txtRemarques.TabIndex = 9;
            // 
            // labelRemarques
            // 
            labelRemarques.Location = new Point(464, 64);
            labelRemarques.Name = "labelRemarques";
            labelRemarques.Size = new Size(135, 25);
            labelRemarques.TabIndex = 8;
            labelRemarques.Text = "Remarques:";
            // 
            // txtTemperature
            // 
            txtTemperature.Location = new Point(605, 28);
            txtTemperature.Name = "txtTemperature";
            txtTemperature.Size = new Size(141, 27);
            txtTemperature.TabIndex = 7;
            // 
            // labelTemperature
            // 
            labelTemperature.Location = new Point(464, 31);
            labelTemperature.Name = "labelTemperature";
            labelTemperature.Size = new Size(135, 25);
            labelTemperature.TabIndex = 6;
            labelTemperature.Text = "Température (°C):";
            // 
            // txtPoids
            // 
            txtPoids.Location = new Point(110, 121);
            txtPoids.Name = "txtPoids";
            txtPoids.Size = new Size(300, 27);
            txtPoids.TabIndex = 5;
            // 
            // labelPoids
            // 
            labelPoids.Location = new Point(20, 124);
            labelPoids.Name = "labelPoids";
            labelPoids.Size = new Size(109, 25);
            labelPoids.TabIndex = 4;
            labelPoids.Text = "Poids (kg):";
            // 
            // txtTraitement
            // 
            txtTraitement.Location = new Point(110, 75);
            txtTraitement.Name = "txtTraitement";
            txtTraitement.Size = new Size(300, 27);
            txtTraitement.TabIndex = 3;
            // 
            // labelTraitement
            // 
            labelTraitement.Location = new Point(20, 78);
            labelTraitement.Name = "labelTraitement";
            labelTraitement.Size = new Size(109, 25);
            labelTraitement.TabIndex = 2;
            labelTraitement.Text = "Traitement:";
            // 
            // txtDiagnostic
            // 
            txtDiagnostic.Location = new Point(110, 28);
            txtDiagnostic.Name = "txtDiagnostic";
            txtDiagnostic.Size = new Size(300, 27);
            txtDiagnostic.TabIndex = 1;
            // 
            // labelDiagnostic
            // 
            labelDiagnostic.Location = new Point(20, 31);
            labelDiagnostic.Name = "labelDiagnostic";
            labelDiagnostic.Size = new Size(109, 25);
            labelDiagnostic.TabIndex = 0;
            labelDiagnostic.Text = "Diagnostic:";
            // 
            // tabDossierMedical
            // 
            tabDossierMedical.Controls.Add(dgvVaccinations);
            tabDossierMedical.Controls.Add(btnAjouterVaccin);
            tabDossierMedical.Controls.Add(dgvDossierMedical);
            tabDossierMedical.Controls.Add(groupBoxRecherche);
            tabDossierMedical.Location = new Point(4, 29);
            tabDossierMedical.Name = "tabDossierMedical";
            tabDossierMedical.Padding = new Padding(3);
            tabDossierMedical.Size = new Size(799, 392);
            tabDossierMedical.TabIndex = 2;
            tabDossierMedical.Text = "Rechercher Animal";
            tabDossierMedical.UseVisualStyleBackColor = true;
            // 
            // dgvVaccinations
            // 
            dgvVaccinations.AllowUserToAddRows = false;
            dgvVaccinations.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvVaccinations.Location = new Point(347, 226);
            dgvVaccinations.Name = "dgvVaccinations";
            dgvVaccinations.ReadOnly = true;
            dgvVaccinations.RowHeadersVisible = false;
            dgvVaccinations.Size = new Size(446, 150);
            dgvVaccinations.TabIndex = 15;
            // 
            // btnAjouterVaccin
            // 
            btnAjouterVaccin.BackColor = Color.LightGreen;
            btnAjouterVaccin.Location = new Point(86, 310);
            btnAjouterVaccin.Name = "btnAjouterVaccin";
            btnAjouterVaccin.Size = new Size(150, 35);
            btnAjouterVaccin.TabIndex = 14;
            btnAjouterVaccin.Text = "Ajouter Vaccination";
            btnAjouterVaccin.UseVisualStyleBackColor = false;
            btnAjouterVaccin.Click += btnAjouterVaccin_Click;
            // 
            // dgvDossierMedical
            // 
            dgvDossierMedical.AllowUserToAddRows = false;
            dgvDossierMedical.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDossierMedical.Location = new Point(347, 20);
            dgvDossierMedical.Name = "dgvDossierMedical";
            dgvDossierMedical.ReadOnly = true;
            dgvDossierMedical.RowHeadersVisible = false;
            dgvDossierMedical.Size = new Size(446, 182);
            dgvDossierMedical.TabIndex = 3;
            // 
            // groupBoxRecherche
            // 
            groupBoxRecherche.Controls.Add(btnRechercher);
            groupBoxRecherche.Controls.Add(txtRechercheNom);
            groupBoxRecherche.Controls.Add(labelRechercheNom);
            groupBoxRecherche.Location = new Point(20, 20);
            groupBoxRecherche.Name = "groupBoxRecherche";
            groupBoxRecherche.Size = new Size(302, 182);
            groupBoxRecherche.TabIndex = 2;
            groupBoxRecherche.TabStop = false;
            groupBoxRecherche.Text = "Rechercher Animal";
            // 
            // btnRechercher
            // 
            btnRechercher.BackColor = Color.LightSkyBlue;
            btnRechercher.Location = new Point(178, 128);
            btnRechercher.Name = "btnRechercher";
            btnRechercher.Size = new Size(100, 35);
            btnRechercher.TabIndex = 13;
            btnRechercher.Text = "Rechercher";
            btnRechercher.UseVisualStyleBackColor = false;
            btnRechercher.Click += btnRechercher_Click;
            // 
            // txtRechercheNom
            // 
            txtRechercheNom.Location = new Point(135, 51);
            txtRechercheNom.Name = "txtRechercheNom";
            txtRechercheNom.Size = new Size(143, 27);
            txtRechercheNom.TabIndex = 1;
            // 
            // labelRechercheNom
            // 
            labelRechercheNom.Location = new Point(20, 51);
            labelRechercheNom.Name = "labelRechercheNom";
            labelRechercheNom.Size = new Size(109, 25);
            labelRechercheNom.TabIndex = 0;
            labelRechercheNom.Text = "Nom Animal:";
            // 
            // btnDeconnexionVeto
            // 
            btnDeconnexionVeto.BackColor = Color.LightCoral;
            btnDeconnexionVeto.Location = new Point(701, 513);
            btnDeconnexionVeto.Name = "btnDeconnexionVeto";
            btnDeconnexionVeto.Size = new Size(126, 35);
            btnDeconnexionVeto.TabIndex = 14;
            btnDeconnexionVeto.Text = "Déconnexion";
            btnDeconnexionVeto.UseVisualStyleBackColor = false;
            btnDeconnexionVeto.Click += btnDeconnexionVeto_Click;
            // 
            // FormVeterinaire
            // 
            AutoScaleDimensions = new SizeF(10F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ScrollBar;
            ClientSize = new Size(844, 565);
            Controls.Add(btnDeconnexionVeto);
            Controls.Add(tabControlVeterinaire);
            Controls.Add(lblWelcomeVeto);
            Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Margin = new Padding(4);
            Name = "FormVeterinaire";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Vétérinaire - Clinique Vétérinaire";
            Load += FormVeterinaire_Load;
            tabControlVeterinaire.ResumeLayout(false);
            tabPlanning.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvPlanning).EndInit();
            tabConsultations.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvHistoriqueConsult).EndInit();
            groupBoxAnimalInfo.ResumeLayout(false);
            groupBoxAnimalInfo.PerformLayout();
            groupBoxConsultation.ResumeLayout(false);
            groupBoxConsultation.PerformLayout();
            tabDossierMedical.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvVaccinations).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvDossierMedical).EndInit();
            groupBoxRecherche.ResumeLayout(false);
            groupBoxRecherche.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox txtSexeConsult;
        private Label lblWelcomeVeto;
        private TabControl tabControlVeterinaire;
        private TabPage tabPlanning;
        private Button btnActualiserPlanning;
        private DataGridView dgvPlanning;
        private TabPage tabConsultations;
        private GroupBox groupBoxConsultation;
        private TabPage tabDossierMedical;
        private TextBox txtDiagnostic;
        private Label labelDiagnostic;
        private TextBox txtPoids;
        private Label labelPoids;
        private TextBox txtTraitement;
        private Label labelTraitement;
        private TextBox txtRemarques;
        private Label labelRemarques;
        private TextBox txtTemperature;
        private Label labelTemperature;
        private Button btnEnregistrerConsult;
        private GroupBox groupBoxAnimalInfo;
        private Button btnChargerAnimal;
        private Label labelSexeConsult;
        private TextBox txtRaceConsult;
        private Label labelRaceConsult;
        private Label labelAnimalConsult;
        private DataGridView dgvHistoriqueConsult;
        private GroupBox groupBoxRecherche;
        private Button btnRechercher;
        private TextBox txtRechercheNom;
        private Label labelRechercheNom;
        private DataGridView dgvDossierMedical;
        private DataGridView dgvVaccinations;
        private Button btnAjouterVaccin;
        private Button btnDeconnexionVeto;
        private ComboBox cmbAnimalConsult;
        private Label labelDateNaissConsult;
        private DateTimePicker dtpDateNaissConsult;
        private TextBox txtAnimalNom;
        private TextBox txtEspeceConsult;
        private TextBox txtCouleurConsult;
        private TextBox txtProprietaireConsult;
        private TextBox txtTelConsult;

    }
}