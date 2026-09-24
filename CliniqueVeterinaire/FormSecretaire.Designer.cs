namespace CliniqueVeterinaire
{
    partial class FormSecretaire
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            btnEnregistrerRDV = new TabControl();
            tabProprietaires = new TabPage();
            btnFactures = new Button();
            groupBoxProprietaire = new GroupBox();
            labelEmailProp = new Label();
            txtEmailProp = new TextBox();
            btnEnregistrerProp = new Button();
            txtVilleProp = new TextBox();
            labelVilleProp = new Label();
            txtAdresseProp = new TextBox();
            labelAdresseProp = new Label();
            txtTelProp = new TextBox();
            labelTelProp = new Label();
            txtPrenomProp = new TextBox();
            labelPrenomProp = new Label();
            txtNomProp = new TextBox();
            labelNomProp = new Label();
            btnActualiserProp = new Button();
            btnModifierProp = new Button();
            btnSupprimerProp = new Button();
            btnAjouterProp = new Button();
            dgvProprietaires = new DataGridView();
            tabAnimaux = new TabPage();
            groupBoxAnimal = new GroupBox();
            cmbProprietaire = new ComboBox();
            labelProprietaire = new Label();
            dtpDateNaiss = new DateTimePicker();
            cmbSexe = new ComboBox();
            labelRace = new Label();
            cmbEspece = new ComboBox();
            labelSexe = new Label();
            btnEnregistrerAnimal = new Button();
            txtCouleur = new TextBox();
            labelCouleur = new Label();
            labelDateNaiss = new Label();
            txtRace = new TextBox();
            labelEspece = new Label();
            txtNomAnimal = new TextBox();
            labelNomAnimal = new Label();
            btnActualiserAnimal = new Button();
            btnModifierAnimal = new Button();
            btnSupprimerAnimal = new Button();
            btnAjouterAnimal = new Button();
            dgvAnimaux = new DataGridView();
            tabRendezVous = new TabPage();
            groupBoxRDV = new GroupBox();
            cmbVetoRDV = new ComboBox();
            dtpDateRDV = new DateTimePicker();
            cmbStatutRDV = new ComboBox();
            labelMotif = new Label();
            cmbAnimalRDV = new ComboBox();
            labelStatut = new Label();
            button1 = new Button();
            labelDateRDV = new Label();
            txtMotifRDV = new TextBox();
            labelVetoRDV = new Label();
            labelAnimalRDV = new Label();
            btnActualiserRDV = new Button();
            btnModifierRDV = new Button();
            btnAnnulerRDV = new Button();
            btnAjouterRDV = new Button();
            dgvRendezVous = new DataGridView();
            btnDeconnexionSecretaire = new Button();
            btnEnregistrerRDV.SuspendLayout();
            tabProprietaires.SuspendLayout();
            groupBoxProprietaire.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProprietaires).BeginInit();
            tabAnimaux.SuspendLayout();
            groupBoxAnimal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAnimaux).BeginInit();
            tabRendezVous.SuspendLayout();
            groupBoxRDV.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRendezVous).BeginInit();
            SuspendLayout();
            // 
            // btnEnregistrerRDV
            // 
            btnEnregistrerRDV.Controls.Add(tabProprietaires);
            btnEnregistrerRDV.Controls.Add(tabAnimaux);
            btnEnregistrerRDV.Controls.Add(tabRendezVous);
            btnEnregistrerRDV.Location = new Point(12, 24);
            btnEnregistrerRDV.Name = "btnEnregistrerRDV";
            btnEnregistrerRDV.SelectedIndex = 0;
            btnEnregistrerRDV.Size = new Size(760, 560);
            btnEnregistrerRDV.TabIndex = 0;
            // 
            // tabProprietaires
            // 
            tabProprietaires.Controls.Add(groupBoxProprietaire);
            tabProprietaires.Controls.Add(btnActualiserProp);
            tabProprietaires.Controls.Add(btnModifierProp);
            tabProprietaires.Controls.Add(btnSupprimerProp);
            tabProprietaires.Controls.Add(btnAjouterProp);
            tabProprietaires.Controls.Add(dgvProprietaires);
            tabProprietaires.Location = new Point(4, 24);
            tabProprietaires.Name = "tabProprietaires";
            tabProprietaires.Padding = new Padding(3);
            tabProprietaires.Size = new Size(752, 532);
            tabProprietaires.TabIndex = 0;
            tabProprietaires.Text = "Propriétaires";
            tabProprietaires.UseVisualStyleBackColor = true;
            // 
            // btnFactures
            // 
            btnFactures.BackColor = Color.LightCyan;
            btnFactures.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnFactures.Location = new Point(526, 606);
            btnFactures.Name = "btnFactures";
            btnFactures.Size = new Size(120, 35);
            btnFactures.TabIndex = 12;
            btnFactures.Text = "Factures";
            btnFactures.UseVisualStyleBackColor = false;
            btnFactures.Click += btnFactures_Click;
            // 
            // groupBoxProprietaire
            // 
            groupBoxProprietaire.Controls.Add(labelEmailProp);
            groupBoxProprietaire.Controls.Add(txtEmailProp);
            groupBoxProprietaire.Controls.Add(btnEnregistrerProp);
            groupBoxProprietaire.Controls.Add(txtVilleProp);
            groupBoxProprietaire.Controls.Add(labelVilleProp);
            groupBoxProprietaire.Controls.Add(txtAdresseProp);
            groupBoxProprietaire.Controls.Add(labelAdresseProp);
            groupBoxProprietaire.Controls.Add(txtTelProp);
            groupBoxProprietaire.Controls.Add(labelTelProp);
            groupBoxProprietaire.Controls.Add(txtPrenomProp);
            groupBoxProprietaire.Controls.Add(labelPrenomProp);
            groupBoxProprietaire.Controls.Add(txtNomProp);
            groupBoxProprietaire.Controls.Add(labelNomProp);
            groupBoxProprietaire.Enabled = false;
            groupBoxProprietaire.Location = new Point(20, 311);
            groupBoxProprietaire.Name = "groupBoxProprietaire";
            groupBoxProprietaire.Size = new Size(707, 201);
            groupBoxProprietaire.TabIndex = 11;
            groupBoxProprietaire.TabStop = false;
            groupBoxProprietaire.Text = "Informations Propriétaire";
            // 
            // labelEmailProp
            // 
            labelEmailProp.Location = new Point(301, 30);
            labelEmailProp.Name = "labelEmailProp";
            labelEmailProp.Size = new Size(64, 25);
            labelEmailProp.TabIndex = 15;
            labelEmailProp.Text = "Email:";
            // 
            // txtEmailProp
            // 
            txtEmailProp.Location = new Point(371, 30);
            txtEmailProp.Name = "txtEmailProp";
            txtEmailProp.Size = new Size(150, 23);
            txtEmailProp.TabIndex = 14;
            // 
            // btnEnregistrerProp
            // 
            btnEnregistrerProp.BackColor = Color.MediumSeaGreen;
            btnEnregistrerProp.Location = new Point(601, 160);
            btnEnregistrerProp.Name = "btnEnregistrerProp";
            btnEnregistrerProp.Size = new Size(100, 35);
            btnEnregistrerProp.TabIndex = 12;
            btnEnregistrerProp.Text = "Enregistrer";
            btnEnregistrerProp.UseVisualStyleBackColor = false;
            btnEnregistrerProp.Click += btnEnregistrerProp_Click;
            // 
            // txtVilleProp
            // 
            txtVilleProp.Location = new Point(371, 100);
            txtVilleProp.Name = "txtVilleProp";
            txtVilleProp.Size = new Size(150, 23);
            txtVilleProp.TabIndex = 11;
            // 
            // labelVilleProp
            // 
            labelVilleProp.AutoSize = true;
            labelVilleProp.Location = new Point(301, 106);
            labelVilleProp.Name = "labelVilleProp";
            labelVilleProp.Size = new Size(32, 15);
            labelVilleProp.TabIndex = 8;
            labelVilleProp.Text = "Ville:";
            // 
            // txtAdresseProp
            // 
            txtAdresseProp.Location = new Point(371, 65);
            txtAdresseProp.Name = "txtAdresseProp";
            txtAdresseProp.Size = new Size(150, 23);
            txtAdresseProp.TabIndex = 7;
            // 
            // labelAdresseProp
            // 
            labelAdresseProp.Location = new Point(301, 65);
            labelAdresseProp.Name = "labelAdresseProp";
            labelAdresseProp.Size = new Size(100, 25);
            labelAdresseProp.TabIndex = 6;
            labelAdresseProp.Text = "Adresse:";
            // 
            // txtTelProp
            // 
            txtTelProp.Location = new Point(119, 100);
            txtTelProp.Name = "txtTelProp";
            txtTelProp.Size = new Size(150, 23);
            txtTelProp.TabIndex = 5;
            // 
            // labelTelProp
            // 
            labelTelProp.AutoSize = true;
            labelTelProp.Location = new Point(20, 106);
            labelTelProp.Name = "labelTelProp";
            labelTelProp.Size = new Size(65, 15);
            labelTelProp.TabIndex = 4;
            labelTelProp.Text = "Téléphone:";
            // 
            // txtPrenomProp
            // 
            txtPrenomProp.Location = new Point(119, 65);
            txtPrenomProp.Name = "txtPrenomProp";
            txtPrenomProp.Size = new Size(150, 23);
            txtPrenomProp.TabIndex = 3;
            // 
            // labelPrenomProp
            // 
            labelPrenomProp.AutoSize = true;
            labelPrenomProp.Location = new Point(20, 73);
            labelPrenomProp.Name = "labelPrenomProp";
            labelPrenomProp.Size = new Size(52, 15);
            labelPrenomProp.TabIndex = 2;
            labelPrenomProp.Text = "Prénom:";
            // 
            // txtNomProp
            // 
            txtNomProp.Location = new Point(119, 30);
            txtNomProp.Name = "txtNomProp";
            txtNomProp.Size = new Size(150, 23);
            txtNomProp.TabIndex = 1;
            // 
            // labelNomProp
            // 
            labelNomProp.AutoSize = true;
            labelNomProp.Location = new Point(20, 36);
            labelNomProp.Name = "labelNomProp";
            labelNomProp.Size = new Size(37, 15);
            labelNomProp.TabIndex = 0;
            labelNomProp.Text = "Nom:";
            // 
            // btnActualiserProp
            // 
            btnActualiserProp.BackColor = Color.LightBlue;
            btnActualiserProp.Location = new Point(607, 194);
            btnActualiserProp.Name = "btnActualiserProp";
            btnActualiserProp.Size = new Size(120, 35);
            btnActualiserProp.TabIndex = 10;
            btnActualiserProp.Text = "Actualiser";
            btnActualiserProp.UseVisualStyleBackColor = false;
            btnActualiserProp.Click += btnActualiserProp_Click;
            // 
            // btnModifierProp
            // 
            btnModifierProp.BackColor = Color.LightSkyBlue;
            btnModifierProp.Location = new Point(607, 77);
            btnModifierProp.Name = "btnModifierProp";
            btnModifierProp.Size = new Size(120, 35);
            btnModifierProp.TabIndex = 8;
            btnModifierProp.Text = "Modifier";
            btnModifierProp.UseVisualStyleBackColor = false;
            btnModifierProp.Click += btnModifierProp_Click;
            // 
            // btnSupprimerProp
            // 
            btnSupprimerProp.BackColor = Color.LightCoral;
            btnSupprimerProp.Location = new Point(607, 132);
            btnSupprimerProp.Name = "btnSupprimerProp";
            btnSupprimerProp.Size = new Size(120, 35);
            btnSupprimerProp.TabIndex = 7;
            btnSupprimerProp.Text = "Supprimer";
            btnSupprimerProp.UseVisualStyleBackColor = false;
            btnSupprimerProp.Click += btnSupprimerProp_Click;
            // 
            // btnAjouterProp
            // 
            btnAjouterProp.BackColor = Color.LightGreen;
            btnAjouterProp.Location = new Point(607, 20);
            btnAjouterProp.Name = "btnAjouterProp";
            btnAjouterProp.Size = new Size(120, 35);
            btnAjouterProp.TabIndex = 6;
            btnAjouterProp.Text = "Ajouter";
            btnAjouterProp.UseVisualStyleBackColor = false;
            btnAjouterProp.Click += btnAjouterProp_Click;
            // 
            // dgvProprietaires
            // 
            dgvProprietaires.AllowUserToAddRows = false;
            dgvProprietaires.AllowUserToDeleteRows = false;
            dgvProprietaires.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProprietaires.Location = new Point(20, 20);
            dgvProprietaires.Name = "dgvProprietaires";
            dgvProprietaires.ReadOnly = true;
            dgvProprietaires.RowHeadersVisible = false;
            dgvProprietaires.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProprietaires.Size = new Size(581, 209);
            dgvProprietaires.TabIndex = 0;
            // 
            // tabAnimaux
            // 
            tabAnimaux.Controls.Add(groupBoxAnimal);
            tabAnimaux.Controls.Add(btnActualiserAnimal);
            tabAnimaux.Controls.Add(btnModifierAnimal);
            tabAnimaux.Controls.Add(btnSupprimerAnimal);
            tabAnimaux.Controls.Add(btnAjouterAnimal);
            tabAnimaux.Controls.Add(dgvAnimaux);
            tabAnimaux.Location = new Point(4, 24);
            tabAnimaux.Name = "tabAnimaux";
            tabAnimaux.Padding = new Padding(3);
            tabAnimaux.Size = new Size(752, 532);
            tabAnimaux.TabIndex = 1;
            tabAnimaux.Text = "Animaux";
            tabAnimaux.UseVisualStyleBackColor = true;
            // 
            // groupBoxAnimal
            // 
            groupBoxAnimal.Controls.Add(cmbProprietaire);
            groupBoxAnimal.Controls.Add(labelProprietaire);
            groupBoxAnimal.Controls.Add(dtpDateNaiss);
            groupBoxAnimal.Controls.Add(cmbSexe);
            groupBoxAnimal.Controls.Add(labelRace);
            groupBoxAnimal.Controls.Add(cmbEspece);
            groupBoxAnimal.Controls.Add(labelSexe);
            groupBoxAnimal.Controls.Add(btnEnregistrerAnimal);
            groupBoxAnimal.Controls.Add(txtCouleur);
            groupBoxAnimal.Controls.Add(labelCouleur);
            groupBoxAnimal.Controls.Add(labelDateNaiss);
            groupBoxAnimal.Controls.Add(txtRace);
            groupBoxAnimal.Controls.Add(labelEspece);
            groupBoxAnimal.Controls.Add(txtNomAnimal);
            groupBoxAnimal.Controls.Add(labelNomAnimal);
            groupBoxAnimal.Enabled = false;
            groupBoxAnimal.Location = new Point(20, 311);
            groupBoxAnimal.Name = "groupBoxAnimal";
            groupBoxAnimal.Size = new Size(707, 201);
            groupBoxAnimal.TabIndex = 17;
            groupBoxAnimal.TabStop = false;
            groupBoxAnimal.Text = "Informations Animal";
            // 
            // cmbProprietaire
            // 
            cmbProprietaire.FormattingEnabled = true;
            cmbProprietaire.Location = new Point(119, 148);
            cmbProprietaire.Name = "cmbProprietaire";
            cmbProprietaire.Size = new Size(150, 23);
            cmbProprietaire.TabIndex = 21;
            // 
            // labelProprietaire
            // 
            labelProprietaire.AutoSize = true;
            labelProprietaire.Location = new Point(20, 151);
            labelProprietaire.Name = "labelProprietaire";
            labelProprietaire.Size = new Size(71, 15);
            labelProprietaire.TabIndex = 20;
            labelProprietaire.Text = "Propriétaire:";
            // 
            // dtpDateNaiss
            // 
            dtpDateNaiss.Location = new Point(396, 70);
            dtpDateNaiss.Name = "dtpDateNaiss";
            dtpDateNaiss.Size = new Size(203, 23);
            dtpDateNaiss.TabIndex = 19;
            // 
            // cmbSexe
            // 
            cmbSexe.FormattingEnabled = true;
            cmbSexe.Items.AddRange(new object[] { "M", "F" });
            cmbSexe.Location = new Point(396, 30);
            cmbSexe.Name = "cmbSexe";
            cmbSexe.Size = new Size(150, 23);
            cmbSexe.TabIndex = 18;
            // 
            // labelRace
            // 
            labelRace.AutoSize = true;
            labelRace.Location = new Point(20, 111);
            labelRace.Name = "labelRace";
            labelRace.Size = new Size(35, 15);
            labelRace.TabIndex = 17;
            labelRace.Text = "Race:";
            // 
            // cmbEspece
            // 
            cmbEspece.FormattingEnabled = true;
            cmbEspece.Items.AddRange(new object[] { "Chien", "Chat", "Oiseau", "Rongeur", "Reptile", "Autre" });
            cmbEspece.Location = new Point(119, 70);
            cmbEspece.Name = "cmbEspece";
            cmbEspece.Size = new Size(150, 23);
            cmbEspece.TabIndex = 16;
            // 
            // labelSexe
            // 
            labelSexe.Location = new Point(290, 33);
            labelSexe.Name = "labelSexe";
            labelSexe.Size = new Size(64, 25);
            labelSexe.TabIndex = 15;
            labelSexe.Text = "Sexe:";
            // 
            // btnEnregistrerAnimal
            // 
            btnEnregistrerAnimal.BackColor = Color.MediumSeaGreen;
            btnEnregistrerAnimal.Location = new Point(601, 160);
            btnEnregistrerAnimal.Name = "btnEnregistrerAnimal";
            btnEnregistrerAnimal.Size = new Size(100, 35);
            btnEnregistrerAnimal.TabIndex = 12;
            btnEnregistrerAnimal.Text = "Enregistrer";
            btnEnregistrerAnimal.UseVisualStyleBackColor = false;
            btnEnregistrerAnimal.Click += btnEnregistrerAnimal_Click;
            // 
            // txtCouleur
            // 
            txtCouleur.Location = new Point(396, 111);
            txtCouleur.Name = "txtCouleur";
            txtCouleur.Size = new Size(150, 23);
            txtCouleur.TabIndex = 11;
            // 
            // labelCouleur
            // 
            labelCouleur.AutoSize = true;
            labelCouleur.Location = new Point(290, 108);
            labelCouleur.Name = "labelCouleur";
            labelCouleur.Size = new Size(52, 15);
            labelCouleur.TabIndex = 8;
            labelCouleur.Text = "Couleur:";
            // 
            // labelDateNaiss
            // 
            labelDateNaiss.Location = new Point(290, 73);
            labelDateNaiss.Name = "labelDateNaiss";
            labelDateNaiss.Size = new Size(100, 25);
            labelDateNaiss.TabIndex = 6;
            labelDateNaiss.Text = "Date naissance:";
            // 
            // txtRace
            // 
            txtRace.Location = new Point(119, 108);
            txtRace.Name = "txtRace";
            txtRace.Size = new Size(150, 23);
            txtRace.TabIndex = 3;
            // 
            // labelEspece
            // 
            labelEspece.AutoSize = true;
            labelEspece.Location = new Point(20, 73);
            labelEspece.Name = "labelEspece";
            labelEspece.Size = new Size(46, 15);
            labelEspece.TabIndex = 2;
            labelEspece.Text = "Espèce:";
            // 
            // txtNomAnimal
            // 
            txtNomAnimal.Location = new Point(119, 30);
            txtNomAnimal.Name = "txtNomAnimal";
            txtNomAnimal.Size = new Size(150, 23);
            txtNomAnimal.TabIndex = 1;
            // 
            // labelNomAnimal
            // 
            labelNomAnimal.AutoSize = true;
            labelNomAnimal.Location = new Point(20, 36);
            labelNomAnimal.Name = "labelNomAnimal";
            labelNomAnimal.Size = new Size(37, 15);
            labelNomAnimal.TabIndex = 0;
            labelNomAnimal.Text = "Nom:";
            // 
            // btnActualiserAnimal
            // 
            btnActualiserAnimal.BackColor = Color.LightBlue;
            btnActualiserAnimal.Location = new Point(607, 197);
            btnActualiserAnimal.Name = "btnActualiserAnimal";
            btnActualiserAnimal.Size = new Size(120, 35);
            btnActualiserAnimal.TabIndex = 16;
            btnActualiserAnimal.Text = "Actualiser";
            btnActualiserAnimal.UseVisualStyleBackColor = false;
            btnActualiserAnimal.Click += btnActualiserAnimal_Click;
            // 
            // btnModifierAnimal
            // 
            btnModifierAnimal.BackColor = Color.LightSkyBlue;
            btnModifierAnimal.Location = new Point(607, 80);
            btnModifierAnimal.Name = "btnModifierAnimal";
            btnModifierAnimal.Size = new Size(120, 35);
            btnModifierAnimal.TabIndex = 15;
            btnModifierAnimal.Text = "Modifier";
            btnModifierAnimal.UseVisualStyleBackColor = false;
            btnModifierAnimal.Click += btnModifierAnimal_Click;
            // 
            // btnSupprimerAnimal
            // 
            btnSupprimerAnimal.BackColor = Color.LightCoral;
            btnSupprimerAnimal.Location = new Point(607, 135);
            btnSupprimerAnimal.Name = "btnSupprimerAnimal";
            btnSupprimerAnimal.Size = new Size(120, 35);
            btnSupprimerAnimal.TabIndex = 14;
            btnSupprimerAnimal.Text = "Supprimer";
            btnSupprimerAnimal.UseVisualStyleBackColor = false;
            btnSupprimerAnimal.Click += btnSupprimerAnimal_Click;
            // 
            // btnAjouterAnimal
            // 
            btnAjouterAnimal.BackColor = Color.LightGreen;
            btnAjouterAnimal.Location = new Point(607, 23);
            btnAjouterAnimal.Name = "btnAjouterAnimal";
            btnAjouterAnimal.Size = new Size(120, 35);
            btnAjouterAnimal.TabIndex = 13;
            btnAjouterAnimal.Text = "Ajouter";
            btnAjouterAnimal.UseVisualStyleBackColor = false;
            btnAjouterAnimal.Click += btnAjouterAnimal_Click;
            // 
            // dgvAnimaux
            // 
            dgvAnimaux.AllowUserToAddRows = false;
            dgvAnimaux.AllowUserToDeleteRows = false;
            dgvAnimaux.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAnimaux.Location = new Point(20, 23);
            dgvAnimaux.Name = "dgvAnimaux";
            dgvAnimaux.ReadOnly = true;
            dgvAnimaux.RowHeadersVisible = false;
            dgvAnimaux.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAnimaux.Size = new Size(567, 209);
            dgvAnimaux.TabIndex = 12;
            // 
            // tabRendezVous
            // 
            tabRendezVous.Controls.Add(groupBoxRDV);
            tabRendezVous.Controls.Add(btnActualiserRDV);
            tabRendezVous.Controls.Add(btnModifierRDV);
            tabRendezVous.Controls.Add(btnAnnulerRDV);
            tabRendezVous.Controls.Add(btnAjouterRDV);
            tabRendezVous.Controls.Add(dgvRendezVous);
            tabRendezVous.Location = new Point(4, 24);
            tabRendezVous.Name = "tabRendezVous";
            tabRendezVous.Padding = new Padding(3);
            tabRendezVous.Size = new Size(752, 532);
            tabRendezVous.TabIndex = 2;
            tabRendezVous.Text = "Rendez-vous";
            tabRendezVous.UseVisualStyleBackColor = true;
            tabRendezVous.Click += tabRendezVous_Click;
            // 
            // groupBoxRDV
            // 
            groupBoxRDV.Controls.Add(cmbVetoRDV);
            groupBoxRDV.Controls.Add(dtpDateRDV);
            groupBoxRDV.Controls.Add(cmbStatutRDV);
            groupBoxRDV.Controls.Add(labelMotif);
            groupBoxRDV.Controls.Add(cmbAnimalRDV);
            groupBoxRDV.Controls.Add(labelStatut);
            groupBoxRDV.Controls.Add(button1);
            groupBoxRDV.Controls.Add(labelDateRDV);
            groupBoxRDV.Controls.Add(txtMotifRDV);
            groupBoxRDV.Controls.Add(labelVetoRDV);
            groupBoxRDV.Controls.Add(labelAnimalRDV);
            groupBoxRDV.Enabled = false;
            groupBoxRDV.Location = new Point(20, 311);
            groupBoxRDV.Name = "groupBoxRDV";
            groupBoxRDV.Size = new Size(707, 201);
            groupBoxRDV.TabIndex = 23;
            groupBoxRDV.TabStop = false;
            groupBoxRDV.Text = "Informations Rendez-vous";
            // 
            // cmbVetoRDV
            // 
            cmbVetoRDV.FormattingEnabled = true;
            cmbVetoRDV.Location = new Point(119, 70);
            cmbVetoRDV.Name = "cmbVetoRDV";
            cmbVetoRDV.Size = new Size(150, 23);
            cmbVetoRDV.TabIndex = 21;
            // 
            // dtpDateRDV
            // 
            dtpDateRDV.Location = new Point(396, 70);
            dtpDateRDV.Name = "dtpDateRDV";
            dtpDateRDV.Size = new Size(203, 23);
            dtpDateRDV.TabIndex = 19;
            // 
            // cmbStatutRDV
            // 
            cmbStatutRDV.FormattingEnabled = true;
            cmbStatutRDV.Location = new Point(396, 30);
            cmbStatutRDV.Name = "cmbStatutRDV";
            cmbStatutRDV.Size = new Size(150, 23);
            cmbStatutRDV.TabIndex = 18;
            // 
            // labelMotif
            // 
            labelMotif.AutoSize = true;
            labelMotif.Location = new Point(20, 111);
            labelMotif.Name = "labelMotif";
            labelMotif.Size = new Size(39, 15);
            labelMotif.TabIndex = 17;
            labelMotif.Text = "Motif:";
            // 
            // cmbAnimalRDV
            // 
            cmbAnimalRDV.FormattingEnabled = true;
            cmbAnimalRDV.Location = new Point(119, 36);
            cmbAnimalRDV.Name = "cmbAnimalRDV";
            cmbAnimalRDV.Size = new Size(150, 23);
            cmbAnimalRDV.TabIndex = 16;
            // 
            // labelStatut
            // 
            labelStatut.Location = new Point(290, 33);
            labelStatut.Name = "labelStatut";
            labelStatut.Size = new Size(64, 25);
            labelStatut.TabIndex = 15;
            labelStatut.Text = "Statut:";
            // 
            // button1
            // 
            button1.BackColor = Color.MediumSeaGreen;
            button1.Location = new Point(601, 160);
            button1.Name = "button1";
            button1.Size = new Size(100, 35);
            button1.TabIndex = 12;
            button1.Text = "Enregistrer";
            button1.UseVisualStyleBackColor = false;
            button1.Click += btnEnregistrerRDV_Click;
            // 
            // labelDateRDV
            // 
            labelDateRDV.Location = new Point(290, 73);
            labelDateRDV.Name = "labelDateRDV";
            labelDateRDV.Size = new Size(100, 25);
            labelDateRDV.TabIndex = 6;
            labelDateRDV.Text = "Date et heure:";
            // 
            // txtMotifRDV
            // 
            txtMotifRDV.Location = new Point(119, 108);
            txtMotifRDV.Name = "txtMotifRDV";
            txtMotifRDV.Size = new Size(150, 23);
            txtMotifRDV.TabIndex = 3;
            // 
            // labelVetoRDV
            // 
            labelVetoRDV.AutoSize = true;
            labelVetoRDV.Location = new Point(20, 73);
            labelVetoRDV.Name = "labelVetoRDV";
            labelVetoRDV.Size = new Size(65, 15);
            labelVetoRDV.TabIndex = 2;
            labelVetoRDV.Text = "Vétérinaire:";
            // 
            // labelAnimalRDV
            // 
            labelAnimalRDV.AutoSize = true;
            labelAnimalRDV.Location = new Point(20, 36);
            labelAnimalRDV.Name = "labelAnimalRDV";
            labelAnimalRDV.Size = new Size(48, 15);
            labelAnimalRDV.TabIndex = 0;
            labelAnimalRDV.Text = "Animal:";
            // 
            // btnActualiserRDV
            // 
            btnActualiserRDV.BackColor = Color.LightBlue;
            btnActualiserRDV.Location = new Point(607, 197);
            btnActualiserRDV.Name = "btnActualiserRDV";
            btnActualiserRDV.Size = new Size(120, 35);
            btnActualiserRDV.TabIndex = 22;
            btnActualiserRDV.Text = "Actualiser";
            btnActualiserRDV.UseVisualStyleBackColor = false;
            btnActualiserRDV.Click += btnActualiserRDV_Click;
            // 
            // btnModifierRDV
            // 
            btnModifierRDV.BackColor = Color.LightSkyBlue;
            btnModifierRDV.Location = new Point(607, 80);
            btnModifierRDV.Name = "btnModifierRDV";
            btnModifierRDV.Size = new Size(120, 35);
            btnModifierRDV.TabIndex = 21;
            btnModifierRDV.Text = "Modifier";
            btnModifierRDV.UseVisualStyleBackColor = false;
            btnModifierRDV.Click += btnModifierRDV_Click;
            // 
            // btnAnnulerRDV
            // 
            btnAnnulerRDV.BackColor = Color.LightCoral;
            btnAnnulerRDV.Location = new Point(607, 135);
            btnAnnulerRDV.Name = "btnAnnulerRDV";
            btnAnnulerRDV.Size = new Size(120, 35);
            btnAnnulerRDV.TabIndex = 20;
            btnAnnulerRDV.Text = "Annuler";
            btnAnnulerRDV.UseVisualStyleBackColor = false;
            btnAnnulerRDV.Click += btnAnnulerRDV_Click;
            // 
            // btnAjouterRDV
            // 
            btnAjouterRDV.BackColor = Color.LightGreen;
            btnAjouterRDV.Location = new Point(607, 23);
            btnAjouterRDV.Name = "btnAjouterRDV";
            btnAjouterRDV.Size = new Size(120, 35);
            btnAjouterRDV.TabIndex = 19;
            btnAjouterRDV.Text = "Ajouter";
            btnAjouterRDV.UseVisualStyleBackColor = false;
            btnAjouterRDV.Click += btnAjouterRDV_Click;
            // 
            // dgvRendezVous
            // 
            dgvRendezVous.AllowUserToAddRows = false;
            dgvRendezVous.AllowUserToDeleteRows = false;
            dgvRendezVous.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRendezVous.Location = new Point(20, 23);
            dgvRendezVous.Name = "dgvRendezVous";
            dgvRendezVous.ReadOnly = true;
            dgvRendezVous.RowHeadersVisible = false;
            dgvRendezVous.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRendezVous.Size = new Size(567, 209);
            dgvRendezVous.TabIndex = 18;
            // 
            // btnDeconnexionSecretaire
            // 
            btnDeconnexionSecretaire.BackColor = Color.LightCoral;
            btnDeconnexionSecretaire.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDeconnexionSecretaire.Location = new Point(652, 606);
            btnDeconnexionSecretaire.Name = "btnDeconnexionSecretaire";
            btnDeconnexionSecretaire.Size = new Size(120, 35);
            btnDeconnexionSecretaire.TabIndex = 8;
            btnDeconnexionSecretaire.Text = "Déconnexion";
            btnDeconnexionSecretaire.UseVisualStyleBackColor = false;
            btnDeconnexionSecretaire.Click += btnDeconnexionSecretaire_Click;
            // 
            // FormSecretaire
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ScrollBar;
            ClientSize = new Size(798, 675);
            Controls.Add(btnFactures);
            Controls.Add(btnDeconnexionSecretaire);
            Controls.Add(btnEnregistrerRDV);
            Name = "FormSecretaire";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Secrétaire - Clinique Vétérinaire";
            Load += FormSecretaire_Load;
            btnEnregistrerRDV.ResumeLayout(false);
            tabProprietaires.ResumeLayout(false);
            groupBoxProprietaire.ResumeLayout(false);
            groupBoxProprietaire.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProprietaires).EndInit();
            tabAnimaux.ResumeLayout(false);
            groupBoxAnimal.ResumeLayout(false);
            groupBoxAnimal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAnimaux).EndInit();
            tabRendezVous.ResumeLayout(false);
            groupBoxRDV.ResumeLayout(false);
            groupBoxRDV.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRendezVous).EndInit();
            ResumeLayout(false);
        }

        private TabControl btnEnregistrerRDV;
        private TabPage tabProprietaires;
        private TabPage tabAnimaux;
        private TabPage tabRendezVous;
        private DataGridView dgvProprietaires;
        private Button btnModifierProp;
        private Button btnSupprimerProp;
        private Button btnAjouterProp;
        private Button btnActualiserProp;
        private GroupBox groupBoxProprietaire;
        private Label labelEmailProp;
        private TextBox txtEmailProp;
        private Button btnEnregistrerProp;
        private TextBox txtVilleProp;
        private Label labelVilleProp;
        private TextBox txtAdresseProp;
        private Label labelAdresseProp;
        private TextBox txtTelProp;
        private Label labelTelProp;
        private TextBox txtPrenomProp;
        private Label labelPrenomProp;
        private TextBox txtNomProp;
        private Label labelNomProp;
        private GroupBox groupBoxAnimal;
        private Label labelSexe;
        private Button btnEnregistrerAnimal;
        private TextBox txtCouleur;
        private Label labelCouleur;
        private Label labelDateNaiss;
        private TextBox txtRace;
        private Label labelEspece;
        private TextBox txtNomAnimal;
        private Label labelNomAnimal;
        private Button btnActualiserAnimal;
        private Button btnModifierAnimal;
        private Button btnSupprimerAnimal;
        private Button btnAjouterAnimal;
        private DataGridView dgvAnimaux;
        private Label labelRace;
        private ComboBox cmbEspece;
        private ComboBox cmbSexe;
        private DateTimePicker dtpDateNaiss;
        private ComboBox cmbProprietaire;
        private Label labelProprietaire;
        private GroupBox groupBoxRDV;
        private ComboBox cmbVetoRDV;
        private DateTimePicker dtpDateRDV;
        private ComboBox cmbStatutRDV;
        private Label labelMotif;
        private ComboBox cmbAnimalRDV;
        private Label labelStatut;
        private Button button1;
        private Label labelDateRDV;
        private TextBox txtMotifRDV;
        private Label labelVetoRDV;
        private Label labelAnimalRDV;
        private Button btnActualiserRDV;
        private Button btnModifierRDV;
        private Button btnAnnulerRDV;
        private Button btnAjouterRDV;
        private DataGridView dgvRendezVous;
        private Button btnDeconnexionSecretaire;
        private Button btnFactures;
    }
}
