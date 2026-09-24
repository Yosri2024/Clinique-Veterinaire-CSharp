namespace CliniqueVeterinaire
{
    partial class FormMontantFacture
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
            txtMontant = new TextBox();
            lblMontant = new Label();
            btnAnnuler = new Button();
            btnValider = new Button();
            SuspendLayout();
            // 
            // txtMontant
            // 
            txtMontant.Location = new Point(160, 28);
            txtMontant.Name = "txtMontant";
            txtMontant.Size = new Size(150, 23);
            txtMontant.TabIndex = 5;
            // 
            // lblMontant
            // 
            lblMontant.AutoSize = true;
            lblMontant.Location = new Point(30, 30);
            lblMontant.Name = "lblMontant";
            lblMontant.Size = new Size(100, 15);
            lblMontant.TabIndex = 4;
            lblMontant.Text = "Montant HT (DT):";
            // 
            // btnAnnuler
            // 
            btnAnnuler.BackColor = Color.LightCoral;
            btnAnnuler.Location = new Point(166, 70);
            btnAnnuler.Name = "btnAnnuler";
            btnAnnuler.Size = new Size(120, 35);
            btnAnnuler.TabIndex = 9;
            btnAnnuler.Text = "Annuler";
            btnAnnuler.UseVisualStyleBackColor = false;
            btnAnnuler.Click += btnAnnuler_Click_1;
            // 
            // btnValider
            // 
            btnValider.BackColor = Color.LightGreen;
            btnValider.Location = new Point(40, 70);
            btnValider.Name = "btnValider";
            btnValider.Size = new Size(120, 35);
            btnValider.TabIndex = 8;
            btnValider.Text = "Valider";
            btnValider.UseVisualStyleBackColor = false;
            btnValider.Click += btnValider_Click_1;
            // 
            // FormMontantFacture
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(350, 134);
            Controls.Add(btnAnnuler);
            Controls.Add(btnValider);
            Controls.Add(txtMontant);
            Controls.Add(lblMontant);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormMontantFacture";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Montant de la facture";
            Load += FormMontantFacture_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox txtMontant;
        private Label lblMontant;
        private Button btnAnnuler;
        private Button btnValider;
    }
}