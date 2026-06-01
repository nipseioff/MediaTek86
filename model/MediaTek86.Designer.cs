using System;

namespace MediaTek86
    {
    partial class MediaTek86
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
        private void btn_personnel_Click(object sender, EventArgs e)
            {
            Console.WriteLine("Ouverture de FormPersonnel...");
            FormPersonnel personnelForm = new FormPersonnel();
            personnelForm.ShowDialog();
            this.Hide();
            }
        private void btn_Absence_Click(object sender, EventArgs e)
            {
            Console.WriteLine("Ouverture de FormPersonnel...");
            FormAbsence absenceForm = new FormAbsence();
            absenceForm.ShowDialog();
            this.Hide();
            }


        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
            {
            

            this.btn_personnel = new System.Windows.Forms.Button();
            this.btn_Absence = new System.Windows.Forms.Button();
            this.texte_bvn = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_personnel
            // 
            this.btn_personnel.Click += new System.EventHandler(this.btn_personnel_Click);
            this.btn_personnel.BackColor = System.Drawing.Color.MidnightBlue;
            this.btn_personnel.Location = new System.Drawing.Point(0, 0);
            this.btn_personnel.Margin = new System.Windows.Forms.Padding(0);
            this.btn_personnel.Name = "btn_personnel";
            this.btn_personnel.Size = new System.Drawing.Size(640, 130);
            this.btn_personnel.TabIndex = 3;
            this.btn_personnel.Text = "Personnel";
            this.btn_personnel.UseVisualStyleBackColor = false;


            // 
            // btn_Absence
            // 
            this.btn_Absence.Click += new System.EventHandler(this.btn_Absence_Click);
            this.btn_Absence.BackColor = System.Drawing.Color.Maroon;
            this.btn_Absence.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btn_Absence.Location = new System.Drawing.Point(640, 0);
            this.btn_Absence.Margin = new System.Windows.Forms.Padding(0);
            this.btn_Absence.Name = "btn_Absence";
            this.btn_Absence.Size = new System.Drawing.Size(624, 130);
            this.btn_Absence.TabIndex = 4;
            this.btn_Absence.Text = "Absence";
            this.btn_Absence.UseVisualStyleBackColor = false;
            // 
            // texte_bvn
            // 
            this.texte_bvn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.texte_bvn.AutoSize = true;
            this.texte_bvn.Location = new System.Drawing.Point(520, 318);
            this.texte_bvn.Name = "texte_bvn";
            this.texte_bvn.Size = new System.Drawing.Size(246, 26);
            this.texte_bvn.TabIndex = 5;
            this.texte_bvn.Text = "Bienvenue sur la basse de donnée MediaTek86\r\nVeuillez cliquer sur un des deux bou" +
    "tons ci dessus.";
            this.texte_bvn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.texte_bvn.Click += new System.EventHandler(this.label1_Click);
            // 
            // MediaTek86
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Green;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.texte_bvn);
            this.Controls.Add(this.btn_Absence);
            this.Controls.Add(this.btn_personnel);
            this.Name = "MediaTek86";
            this.Text = "MediaTek86";
            this.ResumeLayout(false);
            this.PerformLayout();

            }

        #endregion
        private System.Windows.Forms.Button btn_personnel;
        private System.Windows.Forms.Button btn_Absence;
        private System.Windows.Forms.Label texte_bvn;
        }
    }