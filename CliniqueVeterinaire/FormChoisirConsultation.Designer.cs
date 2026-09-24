namespace CliniqueVeterinaire
{
    partial class FormChoisirConsultation
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
            btnAnnuler = new Button();
            btnValider = new Button();
            dgvConsultations = new DataGridView();
            lblInfo = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvConsultations).BeginInit();
            SuspendLayout();
            // 
            // btnAnnuler
            // 
            btnAnnuler.BackColor = Color.LightCoral;
            btnAnnuler.Location = new Point(322, 393);
            btnAnnuler.Name = "btnAnnuler";
            btnAnnuler.Size = new Size(120, 35);
            btnAnnuler.TabIndex = 7;
            btnAnnuler.Text = "Annuler";
            btnAnnuler.UseVisualStyleBackColor = false;
            btnAnnuler.Click += btnAnnuler_Click_1;
            // 
            // btnValider
            // 
            btnValider.BackColor = Color.LightGreen;
            btnValider.Location = new Point(196, 393);
            btnValider.Name = "btnValider";
            btnValider.Size = new Size(120, 35);
            btnValider.TabIndex = 6;
            btnValider.Text = "Valider";
            btnValider.UseVisualStyleBackColor = false;
            btnValider.Click += btnValider_Click;
            // 
            // dgvConsultations
            // 
            dgvConsultations.AllowUserToAddRows = false;
            dgvConsultations.AllowUserToDeleteRows = false;
            dgvConsultations.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvConsultations.Location = new Point(32, 75);
            dgvConsultations.Name = "dgvConsultations";
            dgvConsultations.ReadOnly = true;
            dgvConsultations.RowHeadersVisible = false;
            dgvConsultations.Size = new Size(540, 300);
            dgvConsultations.TabIndex = 5;
            // 
            // lblInfo
            // 
            lblInfo.AutoSize = true;
            lblInfo.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblInfo.ForeColor = Color.MidnightBlue;
            lblInfo.Location = new Point(32, 34);
            lblInfo.Name = "lblInfo";
            lblInfo.Size = new Size(314, 20);
            lblInfo.TabIndex = 8;
            lblInfo.Text = "Sélectionnez une consultation sans facture :";
            // 
            // FormChoisirConsultation
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(625, 446);
            Controls.Add(lblInfo);
            Controls.Add(btnAnnuler);
            Controls.Add(btnValider);
            Controls.Add(dgvConsultations);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormChoisirConsultation";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sélectionner une consultation";
            Load += FormChoisirConsultation_Load;
            ((System.ComponentModel.ISupportInitialize)dgvConsultations).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnAnnuler;
        private Button btnValider;
        private DataGridView dgvConsultations;
        private Label lblInfo;
    }
}