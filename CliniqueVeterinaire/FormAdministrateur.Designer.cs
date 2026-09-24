namespace CliniqueVeterinaire
{
    partial class FormAdministrateur
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
            lblTitre = new Label();
            lblWelcome = new Label();
            btnGestionUtilisateurs = new Button();
            btnGestionStock = new Button();
            btnStats = new Button();
            btnDeconnexion = new Button();
            dgvDashboard = new DataGridView();
            colNom = new DataGridViewTextBoxColumn();
            colValeur = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dgvDashboard).BeginInit();
            SuspendLayout();
            // 
            // lblTitre
            // 
            lblTitre.Font = new Font("Arial", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 178);
            lblTitre.Location = new Point(20, 20);
            lblTitre.Name = "lblTitre";
            lblTitre.Size = new Size(326, 30);
            lblTitre.TabIndex = 0;
            lblTitre.Text = "Tableau de Bord Administrateur";
            // 
            // lblWelcome
            // 
            lblWelcome.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblWelcome.Location = new Point(20, 60);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(300, 25);
            lblWelcome.TabIndex = 1;
            lblWelcome.Text = "Welcome, Admin!";
            // 
            // btnGestionUtilisateurs
            // 
            btnGestionUtilisateurs.BackColor = Color.LightSteelBlue;
            btnGestionUtilisateurs.ForeColor = Color.Black;
            btnGestionUtilisateurs.Location = new Point(50, 120);
            btnGestionUtilisateurs.Name = "btnGestionUtilisateurs";
            btnGestionUtilisateurs.Size = new Size(180, 35);
            btnGestionUtilisateurs.TabIndex = 2;
            btnGestionUtilisateurs.Text = "Gestion des Utilisateurs";
            btnGestionUtilisateurs.UseVisualStyleBackColor = false;
            btnGestionUtilisateurs.Click += btnGestionUtilisateurs_Click;
            // 
            // btnGestionStock
            // 
            btnGestionStock.BackColor = Color.LightBlue;
            btnGestionStock.ForeColor = SystemColors.ControlText;
            btnGestionStock.Location = new Point(50, 170);
            btnGestionStock.Name = "btnGestionStock";
            btnGestionStock.Size = new Size(180, 35);
            btnGestionStock.TabIndex = 3;
            btnGestionStock.Text = "Gestion du Stock";
            btnGestionStock.UseVisualStyleBackColor = false;
            btnGestionStock.Click += btnGestionStock_Click;
            // 
            // btnStats
            // 
            btnStats.BackColor = Color.LightSkyBlue;
            btnStats.Location = new Point(50, 220);
            btnStats.Name = "btnStats";
            btnStats.Size = new Size(180, 35);
            btnStats.TabIndex = 4;
            btnStats.Text = "Statistiques";
            btnStats.UseVisualStyleBackColor = false;
            btnStats.Click += btnStats_Click;
            // 
            // btnDeconnexion
            // 
            btnDeconnexion.BackColor = Color.LightCoral;
            btnDeconnexion.Location = new Point(50, 300);
            btnDeconnexion.Name = "btnDeconnexion";
            btnDeconnexion.Size = new Size(180, 35);
            btnDeconnexion.TabIndex = 5;
            btnDeconnexion.Text = "Déconnexion";
            btnDeconnexion.UseVisualStyleBackColor = false;
            btnDeconnexion.Click += btnDeconnexion_Click;
            // 
            // dgvDashboard
            // 
            dgvDashboard.AllowUserToAddRows = false;
            dgvDashboard.AllowUserToDeleteRows = false;
            dgvDashboard.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDashboard.Columns.AddRange(new DataGridViewColumn[] { colNom, colValeur });
            dgvDashboard.Location = new Point(250, 120);
            dgvDashboard.Name = "dgvDashboard";
            dgvDashboard.RowHeadersVisible = false;
            dgvDashboard.Size = new Size(472, 227);
            dgvDashboard.TabIndex = 6;
            // 
            // colNom
            // 
            colNom.HeaderText = "Statistique";
            colNom.Name = "colNom";
            // 
            // colValeur
            // 
            colValeur.HeaderText = "Nombre";
            colValeur.Name = "colValeur";
            // 
            // FormAdministrateur
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ScrollBar;
            ClientSize = new Size(747, 370);
            Controls.Add(dgvDashboard);
            Controls.Add(btnDeconnexion);
            Controls.Add(btnStats);
            Controls.Add(btnGestionStock);
            Controls.Add(btnGestionUtilisateurs);
            Controls.Add(lblWelcome);
            Controls.Add(lblTitre);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "FormAdministrateur";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Administrateur - Clinique Vétérinaire";
            Load += FormAdministrateur_Load;
            ((System.ComponentModel.ISupportInitialize)dgvDashboard).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label lblTitre;
        private Label lblWelcome;
        private Button btnGestionUtilisateurs;
        private Button btnGestionStock;
        private Button btnStats;
        private Button btnDeconnexion;
        private DataGridView dgvDashboard;
        private DataGridViewTextBoxColumn colNom;
        private DataGridViewTextBoxColumn colValeur;
    }
}