namespace CliniqueVeterinaire
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            btnConnexion = new Button();
            txtLogin = new TextBox();
            txtMotDePasse = new TextBox();
            label3 = new Label();
            btnQuitter = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(100, 18);
            label1.Name = "label1";
            label1.Size = new Size(192, 22);
            label1.TabIndex = 0;
            label1.Text = "Clinique Vétérinaire";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.Font = new Font("Arial Narrow", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(52, 88);
            label2.Name = "label2";
            label2.Size = new Size(60, 25);
            label2.TabIndex = 1;
            label2.Text = "Login:";
            // 
            // btnConnexion
            // 
            btnConnexion.BackColor = Color.LightGreen;
            btnConnexion.Location = new Point(100, 190);
            btnConnexion.Name = "btnConnexion";
            btnConnexion.Size = new Size(100, 35);
            btnConnexion.TabIndex = 2;
            btnConnexion.Text = "Se connecter";
            btnConnexion.UseVisualStyleBackColor = false;
            btnConnexion.Click += btnConnexion_Click;
            // 
            // txtLogin
            // 
            txtLogin.Location = new Point(169, 89);
            txtLogin.Name = "txtLogin";
            txtLogin.Size = new Size(160, 23);
            txtLogin.TabIndex = 3;
            // 
            // txtMotDePasse
            // 
            txtMotDePasse.Location = new Point(169, 130);
            txtMotDePasse.Name = "txtMotDePasse";
            txtMotDePasse.PasswordChar = '*';
            txtMotDePasse.Size = new Size(160, 23);
            txtMotDePasse.TabIndex = 5;
            // 
            // label3
            // 
            label3.Font = new Font("Arial Narrow", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(52, 130);
            label3.Name = "label3";
            label3.Size = new Size(111, 25);
            label3.TabIndex = 4;
            label3.Text = "Mot de passe:";
            // 
            // btnQuitter
            // 
            btnQuitter.BackColor = Color.LightCoral;
            btnQuitter.Location = new Point(220, 190);
            btnQuitter.Name = "btnQuitter";
            btnQuitter.Size = new Size(100, 35);
            btnQuitter.TabIndex = 6;
            btnQuitter.Text = "Quitter";
            btnQuitter.UseVisualStyleBackColor = false;
            btnQuitter.Click += btnQuitter_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ScrollBar;
            ClientSize = new Size(398, 261);
            Controls.Add(btnQuitter);
            Controls.Add(txtMotDePasse);
            Controls.Add(label3);
            Controls.Add(txtLogin);
            Controls.Add(btnConnexion);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MinimizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Connexion - Clinique Vétérinaire";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Button btnConnexion;
        private TextBox txtLogin;
        private TextBox txtMotDePasse;
        private Label label3;
        private Button btnQuitter;
    }
}
