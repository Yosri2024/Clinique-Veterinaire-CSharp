namespace CliniqueVeterinaire
{
    partial class FormGestionUtilisateurs
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
            btnAjouter = new Button();
            btnModifier = new Button();
            btnSupprimer = new Button();
            btnFermer = new Button();
            groupBoxForm = new GroupBox();
            btnEnregistrer = new Button();
            labelEmail = new Label();
            txtEmail = new TextBox();
            cmbRole = new ComboBox();
            labelRole = new Label();
            txtMotDePasse = new TextBox();
            labelMdp = new Label();
            txtPrenom = new TextBox();
            labelPrenom = new Label();
            txtNom = new TextBox();
            labelNom = new Label();
            dgvUtilisateurs = new DataGridView();
            txtTelephone = new TextBox();
            label1 = new Label();
            txtLogin = new TextBox();
            labelLogin = new Label();
            groupBoxForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUtilisateurs).BeginInit();
            SuspendLayout();
            // 
            // btnAjouter
            // 
            btnAjouter.BackColor = Color.LightGreen;
            btnAjouter.Location = new Point(609, 20);
            btnAjouter.Name = "btnAjouter";
            btnAjouter.Size = new Size(120, 35);
            btnAjouter.TabIndex = 1;
            btnAjouter.Text = "Ajouter";
            btnAjouter.UseVisualStyleBackColor = false;
            btnAjouter.Click += btnAjouter_Click;
            // 
            // btnModifier
            // 
            btnModifier.BackColor = Color.LightSkyBlue;
            btnModifier.Location = new Point(609, 70);
            btnModifier.Name = "btnModifier";
            btnModifier.Size = new Size(120, 35);
            btnModifier.TabIndex = 2;
            btnModifier.Text = "Modifier";
            btnModifier.UseVisualStyleBackColor = false;
            btnModifier.Click += btnModifier_Click;
            // 
            // btnSupprimer
            // 
            btnSupprimer.BackColor = Color.LightCoral;
            btnSupprimer.Location = new Point(609, 120);
            btnSupprimer.Name = "btnSupprimer";
            btnSupprimer.Size = new Size(120, 35);
            btnSupprimer.TabIndex = 3;
            btnSupprimer.Text = "Supprimer";
            btnSupprimer.UseVisualStyleBackColor = false;
            btnSupprimer.Click += btnSupprimer_Click;
            // 
            // btnFermer
            // 
            btnFermer.BackColor = Color.LightGray;
            btnFermer.Location = new Point(609, 197);
            btnFermer.Name = "btnFermer";
            btnFermer.Size = new Size(120, 35);
            btnFermer.TabIndex = 4;
            btnFermer.Text = "Fermer";
            btnFermer.UseVisualStyleBackColor = false;
            btnFermer.Click += btnFermer_Click;
            // 
            // groupBoxForm
            // 
            groupBoxForm.Controls.Add(txtLogin);
            groupBoxForm.Controls.Add(labelLogin);
            groupBoxForm.Controls.Add(txtTelephone);
            groupBoxForm.Controls.Add(label1);
            groupBoxForm.Controls.Add(btnEnregistrer);
            groupBoxForm.Controls.Add(labelEmail);
            groupBoxForm.Controls.Add(txtEmail);
            groupBoxForm.Controls.Add(cmbRole);
            groupBoxForm.Controls.Add(labelRole);
            groupBoxForm.Controls.Add(txtMotDePasse);
            groupBoxForm.Controls.Add(labelMdp);
            groupBoxForm.Controls.Add(txtPrenom);
            groupBoxForm.Controls.Add(labelPrenom);
            groupBoxForm.Controls.Add(txtNom);
            groupBoxForm.Controls.Add(labelNom);
            groupBoxForm.Location = new Point(20, 257);
            groupBoxForm.Name = "groupBoxForm";
            groupBoxForm.Size = new Size(709, 189);
            groupBoxForm.TabIndex = 5;
            groupBoxForm.TabStop = false;
            groupBoxForm.Text = "Informations Utilisateur";
            // 
            // btnEnregistrer
            // 
            btnEnregistrer.BackColor = Color.MediumSeaGreen;
            btnEnregistrer.Location = new Point(603, 148);
            btnEnregistrer.Name = "btnEnregistrer";
            btnEnregistrer.Size = new Size(100, 35);
            btnEnregistrer.TabIndex = 12;
            btnEnregistrer.Text = "Enregistrer";
            btnEnregistrer.UseVisualStyleBackColor = false;
            btnEnregistrer.Click += btnEnregistrer_Click;
            // 
            // labelEmail
            // 
            labelEmail.AutoSize = true;
            labelEmail.Location = new Point(21, 99);
            labelEmail.Name = "labelEmail";
            labelEmail.Size = new Size(39, 15);
            labelEmail.TabIndex = 10;
            labelEmail.Text = "Email:";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(88, 96);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(150, 23);
            txtEmail.TabIndex = 11;
            // 
            // cmbRole
            // 
            cmbRole.FormattingEnabled = true;
            cmbRole.Location = new Point(428, 101);
            cmbRole.Name = "cmbRole";
            cmbRole.Size = new Size(150, 23);
            cmbRole.TabIndex = 10;
            // 
            // labelRole
            // 
            labelRole.AutoSize = true;
            labelRole.Location = new Point(318, 103);
            labelRole.Name = "labelRole";
            labelRole.Size = new Size(33, 15);
            labelRole.TabIndex = 8;
            labelRole.Text = "Rôle:";
            // 
            // txtMotDePasse
            // 
            txtMotDePasse.Location = new Point(428, 66);
            txtMotDePasse.Name = "txtMotDePasse";
            txtMotDePasse.Size = new Size(150, 23);
            txtMotDePasse.TabIndex = 7;
            // 
            // labelMdp
            // 
            labelMdp.Location = new Point(318, 68);
            labelMdp.Name = "labelMdp";
            labelMdp.Size = new Size(100, 25);
            labelMdp.TabIndex = 6;
            labelMdp.Text = "Mot de passe:";
            // 
            // txtPrenom
            // 
            txtPrenom.Location = new Point(88, 65);
            txtPrenom.Name = "txtPrenom";
            txtPrenom.Size = new Size(150, 23);
            txtPrenom.TabIndex = 3;
            // 
            // labelPrenom
            // 
            labelPrenom.AutoSize = true;
            labelPrenom.Location = new Point(20, 65);
            labelPrenom.Name = "labelPrenom";
            labelPrenom.Size = new Size(52, 15);
            labelPrenom.TabIndex = 2;
            labelPrenom.Text = "Prénom:";
            // 
            // txtNom
            // 
            txtNom.Location = new Point(88, 30);
            txtNom.Name = "txtNom";
            txtNom.Size = new Size(150, 23);
            txtNom.TabIndex = 1;
            // 
            // labelNom
            // 
            labelNom.AutoSize = true;
            labelNom.Location = new Point(20, 30);
            labelNom.Name = "labelNom";
            labelNom.Size = new Size(37, 15);
            labelNom.TabIndex = 0;
            labelNom.Text = "Nom:";
            // 
            // dgvUtilisateurs
            // 
            dgvUtilisateurs.AllowUserToAddRows = false;
            dgvUtilisateurs.AllowUserToDeleteRows = false;
            dgvUtilisateurs.BorderStyle = BorderStyle.Fixed3D;
            dgvUtilisateurs.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUtilisateurs.GridColor = Color.LightGray;
            dgvUtilisateurs.Location = new Point(20, 20);
            dgvUtilisateurs.Name = "dgvUtilisateurs";
            dgvUtilisateurs.ReadOnly = true;
            dgvUtilisateurs.RowHeadersVisible = false;
            dgvUtilisateurs.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUtilisateurs.Size = new Size(570, 212);
            dgvUtilisateurs.TabIndex = 6;
            // 
            // txtTelephone
            // 
            txtTelephone.Location = new Point(88, 132);
            txtTelephone.Name = "txtTelephone";
            txtTelephone.Size = new Size(150, 23);
            txtTelephone.TabIndex = 14;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(17, 135);
            label1.Name = "label1";
            label1.Size = new Size(65, 15);
            label1.TabIndex = 13;
            label1.Text = "Téléphone:";
            // 
            // txtLogin
            // 
            txtLogin.Location = new Point(428, 27);
            txtLogin.Name = "txtLogin";
            txtLogin.Size = new Size(150, 23);
            txtLogin.TabIndex = 16;
            // 
            // labelLogin
            // 
            labelLogin.AutoSize = true;
            labelLogin.Location = new Point(318, 30);
            labelLogin.Name = "labelLogin";
            labelLogin.Size = new Size(40, 15);
            labelLogin.TabIndex = 15;
            labelLogin.Text = "Login:";
            // 
            // FormGestionUtilisateurs
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ScrollBar;
            ClientSize = new Size(743, 458);
            Controls.Add(dgvUtilisateurs);
            Controls.Add(groupBoxForm);
            Controls.Add(btnFermer);
            Controls.Add(btnSupprimer);
            Controls.Add(btnModifier);
            Controls.Add(btnAjouter);
            Name = "FormGestionUtilisateurs";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Gestion des Utilisateurs";
            Load += FormGestionUtilisateurs_Load;
            groupBoxForm.ResumeLayout(false);
            groupBoxForm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUtilisateurs).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Button btnAjouter;
        private Button btnModifier;
        private Button btnSupprimer;
        private Button btnFermer;
        private GroupBox groupBoxForm;
        private TextBox txtNom;
        private Label labelNom;
        private TextBox txtPrenom;
        private Label labelPrenom;
        private TextBox txtEmail;
        private Label labelEmail;
        private Label labelRole;
        private TextBox txtMotDePasse;
        private Label labelMdp;
        private ComboBox cmbRole;
        private Button btnEnregistrer;
        private DataGridView dgvUtilisateurs;
        private TextBox txtLogin;
        private Label labelLogin;
        private TextBox txtTelephone;
        private Label label1;
    }
}