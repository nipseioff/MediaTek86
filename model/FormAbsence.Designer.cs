using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MediaTek86.dal;
using MediaTek86.DAL;
using MediaTek86.bddmanager;

namespace MediaTek86
    {
    partial class FormAbsence
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



        private void Absence()
            {
            string req = "SELECT * FROM absence;";
            DataTable dataTable = Access.GetInstance().Manager.ReqSelectDataTable(req);

            Console.WriteLine($"Nombre de lignes récupérées : {dataTable.Rows.Count}");

            if (dataTable != null && dataTable.Rows.Count > 0)
                {
                dataGriedViewAbsence.DataSource = dataTable;
                }
            else
                {
                MessageBox.Show("La table 'personnel' est vide ou les données ne sont pas chargées !");
                }
            }
        private void btn_save_Click(object sender, EventArgs e)
            {
            dataGriedViewAbsence.EndEdit(); // Force la validation des modifications
            DataTable changes = ((DataTable)dataGriedViewAbsence.DataSource).GetChanges();

            if (changes == null || changes.Rows.Count == 0)
                {
                Console.WriteLine(" Aucune modification détectée !");
                MessageBox.Show("Aucune modification détectée !");
                return;
                }

            foreach (DataRow row in changes.Rows)
                {
                if (row.RowState == DataRowState.Added) //  Gestion des nouvelles entrées
                    {
                    string req = "INSERT INTO absence (idpersonnel, datedebut, datefin, idmotif) VALUES (@idpersonnel, @datedebut, @datefin, @idmotif);";
                    Dictionary<string, object> parameters = new Dictionary<string, object>
     {
         { "@idpersonnel", row["idpersonnel"] },
         { "@datedebut", row["datedebut"] },
         { "@datefin", row["datefin"] },
         { "@idmotif", row["idmotif"] },
     };

                    Console.WriteLine($" Ajout d'une nouvelle absence : {row["datedebut"]} {row["datefin"]}");
                    Access.GetInstance().Manager.ReqUpdate(req, parameters);

                    // 🔄 Récupérer l'ID généré et le mettre à jour dans DataGridView
                    string idQuery = "SELECT LAST_INSERT_ID();";
                    DataTable idResult = Access.GetInstance().Manager.ReqSelectDataTable(idQuery);

                    if (idResult != null && idResult.Rows.Count > 0)
                        {
                        row["idpersonnel"] = Convert.ToInt32(idResult.Rows[0][0]); // Met à jour le `idpersonnel` dans DataGridView
                        Console.WriteLine($" ID récupéré et assigné : {row["idpersonnel"]}");
                        }
                    }
                else if (row.RowState == DataRowState.Modified) //  Gestion des modifications
                    {
                    string req = "UPDATE absence SET idpersonnel = @idpersonnel, datedebut = @datedebut, datefin = @datefin, idmotif = @idmotif;";
                    Dictionary<string, object> parameters = new Dictionary<string, object>
     {
         { "@idpersonnel", row["idpersonnel"] },
         { "@datedebut", row["datedebut"] },
         { "@datefin", row["datefin"] },
         { "@idmotif", row["idmotif"] },
     };

                    Console.WriteLine($" Mise à jour du personnel : ID {row["idpersonnel"]}");
                    Access.GetInstance().Manager.ReqUpdate(req, parameters);
                    }
                else if (row.RowState == DataRowState.Deleted) // Gestion des suppressions
                    {
                    string req = "DELETE FROM absence WHERE idpersonnel = @idpersonnel;";
                    Dictionary<string, object> parameters = new Dictionary<string, object>
     {
         { "@idpersonnel", row["idpersonnel", DataRowVersion.Original] } // Récupère l'ID d'origine avant suppression
     };

                    Console.WriteLine($" Suppression du personnel : ID {row["idpersonnel", DataRowVersion.Original]}");
                    Access.GetInstance().Manager.ReqUpdate(req, parameters);
                    }
                }

            MessageBox.Show("Modifications enregistrées avec succès !");
            ((DataTable)dataGriedViewAbsence.DataSource).AcceptChanges(); // Valide les modifications localement
            Absence(); // Recharge les données actualisées
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
            this.dataGriedViewAbsence = new System.Windows.Forms.DataGridView();
            this.btn_save = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGriedViewAbsence)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_personnel
            // 
            this.btn_personnel.BackColor = System.Drawing.Color.MidnightBlue;
            this.btn_personnel.Location = new System.Drawing.Point(0, 0);
            this.btn_personnel.Margin = new System.Windows.Forms.Padding(0);
            this.btn_personnel.Name = "btn_personnel";
            this.btn_personnel.Size = new System.Drawing.Size(640, 130);
            this.btn_personnel.TabIndex = 2;
            this.btn_personnel.Text = "Personnel";
            this.btn_personnel.UseVisualStyleBackColor = false;
            // 
            // btn_Absence
            // 
            this.btn_Absence.BackColor = System.Drawing.Color.Maroon;
            this.btn_Absence.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btn_Absence.Location = new System.Drawing.Point(640, 0);
            this.btn_Absence.Margin = new System.Windows.Forms.Padding(0);
            this.btn_Absence.Name = "btn_Absence";
            this.btn_Absence.Size = new System.Drawing.Size(624, 130);
            this.btn_Absence.TabIndex = 3;
            this.btn_Absence.Text = "Absence";
            this.btn_Absence.UseVisualStyleBackColor = false;
            // 
            // dataGriedViewAbsence
            // 
            this.dataGriedViewAbsence.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.dataGriedViewAbsence.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGriedViewAbsence.Location = new System.Drawing.Point(210, 131);
            this.dataGriedViewAbsence.Name = "dataGriedViewAbsence";
            this.dataGriedViewAbsence.Size = new System.Drawing.Size(1054, 550);
            this.dataGriedViewAbsence.TabIndex = 5;
            this.dataGriedViewAbsence.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGriedViewAbsence_CellContentClick);
            // 
            // btn_save
            // 
            this.btn_save = new System.Windows.Forms.Button();
            this.btn_save.Text = "Enregistrer";
            this.btn_save.Location = new System.Drawing.Point(520, 600);
            this.btn_save.Size = new System.Drawing.Size(150, 50);
            this.Controls.Add(this.btn_save);
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);

            this.btn_save.BackColor = System.Drawing.Color.DarkGreen;
            this.btn_save.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_save.Location = new System.Drawing.Point(0, 133);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(210, 547);
            this.btn_save.TabIndex = 9;
            this.btn_save.Text = "Enregistrer les modifications";
            this.btn_save.UseVisualStyleBackColor = false;
            // 
            // FormAbsence
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Firebrick;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.dataGriedViewAbsence);
            this.Controls.Add(this.btn_Absence);
            this.Controls.Add(this.btn_personnel);
            this.Name = "FormAbsence";
            this.Text = "FormAbsence";
            ((System.ComponentModel.ISupportInitialize)(this.dataGriedViewAbsence)).EndInit();
            this.ResumeLayout(false);

            }

        #endregion
        private System.Windows.Forms.Button btn_personnel;
        private System.Windows.Forms.Button btn_Absence;
        private System.Windows.Forms.DataGridView dataGriedViewAbsence;
        private Button btn_save;
        }
    }