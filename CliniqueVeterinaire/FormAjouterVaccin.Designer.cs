namespace CliniqueVeterinaire
{
    partial class FormAjouterVaccin
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
            lblAnimal = new Label();
            labelNomVaccin = new Label();
            txtNomVaccin = new TextBox();
            labelDateAdmin = new Label();
            dtpDateAdmin = new DateTimePicker();
            labelDateRappel = new Label();
            chkRappel = new CheckBox();
            dtpDateRappel = new DateTimePicker();
            btnEnregistrer = new Button();
            btnAnnuler = new Button();
            SuspendLayout();
            // 
            // lblAnimal
            // 
            lblAnimal.Font = new Font("Arial", 9F, FontStyle.Bold);
            lblAnimal.Location = new Point(20, 20);
            lblAnimal.Name = "lblAnimal";
            lblAnimal.Size = new Size(400, 25);
            lblAnimal.TabIndex = 0;
            lblAnimal.Text = "Animal: ";
            // 
            // labelNomVaccin
            // 
            labelNomVaccin.Location = new Point(20, 60);
            labelNomVaccin.Name = "labelNomVaccin";
            labelNomVaccin.Size = new Size(120, 25);
            labelNomVaccin.TabIndex = 1;
            labelNomVaccin.Text = "Nom du vaccin:";
            // 
            // txtNomVaccin
            // 
            txtNomVaccin.Location = new Point(150, 58);
            txtNomVaccin.Name = "txtNomVaccin";
            txtNomVaccin.Size = new Size(250, 23);
            txtNomVaccin.TabIndex = 2;
            // 
            // labelDateAdmin
            // 
            labelDateAdmin.Location = new Point(20, 95);
            labelDateAdmin.Name = "labelDateAdmin";
            labelDateAdmin.Size = new Size(140, 25);
            labelDateAdmin.TabIndex = 3;
            labelDateAdmin.Text = "Date administration:";
            // 
            // dtpDateAdmin
            // 
            dtpDateAdmin.Location = new Point(160, 93);
            dtpDateAdmin.Name = "dtpDateAdmin";
            dtpDateAdmin.Size = new Size(240, 23);
            dtpDateAdmin.TabIndex = 4;
            // 
            // labelDateRappel
            // 
            labelDateRappel.Location = new Point(20, 130);
            labelDateRappel.Name = "labelDateRappel";
            labelDateRappel.Size = new Size(140, 25);
            labelDateRappel.TabIndex = 5;
            labelDateRappel.Text = "Date rappel:";
            // 
            // chkRappel
            // 
            chkRappel.Location = new Point(160, 128);
            chkRappel.Name = "chkRappel";
            chkRappel.Size = new Size(80, 25);
            chkRappel.TabIndex = 6;
            chkRappel.Text = "Ajouter";
            chkRappel.CheckedChanged += chkRappel_CheckedChanged;
            // 
            // dtpDateRappel
            // 
            dtpDateRappel.Enabled = false;
            dtpDateRappel.Location = new Point(246, 126);
            dtpDateRappel.Name = "dtpDateRappel";
            dtpDateRappel.Size = new Size(150, 23);
            dtpDateRappel.TabIndex = 7;
            // 
            // btnEnregistrer
            // 
            btnEnregistrer.BackColor = Color.MediumSeaGreen;
            btnEnregistrer.Location = new Point(160, 180);
            btnEnregistrer.Name = "btnEnregistrer";
            btnEnregistrer.Size = new Size(100, 35);
            btnEnregistrer.TabIndex = 8;
            btnEnregistrer.Text = "Enregistrer";
            btnEnregistrer.UseVisualStyleBackColor = false;
            btnEnregistrer.Click += btnEnregistrer_Click;
            // 
            // btnAnnuler
            // 
            btnAnnuler.BackColor = Color.LightCoral;
            btnAnnuler.Location = new Point(270, 180);
            btnAnnuler.Name = "btnAnnuler";
            btnAnnuler.Size = new Size(100, 35);
            btnAnnuler.TabIndex = 9;
            btnAnnuler.Text = "Annuler";
            btnAnnuler.UseVisualStyleBackColor = false;
            btnAnnuler.Click += btnAnnuler_Click;
            // 
            // FormAjouterVaccin
            // 
            ClientSize = new Size(434, 261);
            Controls.Add(lblAnimal);
            Controls.Add(labelNomVaccin);
            Controls.Add(txtNomVaccin);
            Controls.Add(labelDateAdmin);
            Controls.Add(dtpDateAdmin);
            Controls.Add(labelDateRappel);
            Controls.Add(chkRappel);
            Controls.Add(dtpDateRappel);
            Controls.Add(btnEnregistrer);
            Controls.Add(btnAnnuler);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FormAjouterVaccin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Ajouter un vaccin";
            Load += FormAjouterVaccin_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        private Label lblAnimal;
        private Label labelNomVaccin;
        private TextBox txtNomVaccin;
        private Label labelDateAdmin;
        private DateTimePicker dtpDateAdmin;
        private Label labelDateRappel;
        private CheckBox chkRappel;
        private DateTimePicker dtpDateRappel;
        private Button btnEnregistrer;
        private Button btnAnnuler;
    }
}