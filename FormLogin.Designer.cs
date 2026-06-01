using System.Windows.Forms;
using System;
using MediaTek86.dal;
using System.Collections.Generic;
using MediaTek86.bddmanager;
using MediaTek86.DAL;
using MediaTek86.Controleur;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace MediaTek86
    {
    partial class FormLogin
        {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
            {
            if (disposing && (components != null))
                {
                components.Dispose();
                }
            base.Dispose(disposing);
            }


        // Vérifie les identifiants saisis et ouvre le formulaire principal si la connexion est valide
        private void Se_connecter_Click(object sender, EventArgs e)
            {
            string login = Login.Text;
            string password = Password.Text;

            // Redirige vers l'accueil si les identifiants sont corrects, affiche une erreur sinon
            if (VerifierAuthentification(login, password))
                {
                this.Hide();
                MediaTek86 mediatekForm = new MediaTek86();
                mediatekForm.ShowDialog();
                this.Close();
                }
            else
                {
                MessageBox.Show("Login ou mot de passe incorrect.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        // Appelle la couche DAL pour contrôler l'authentification de l'utilisateur
        public static bool VerifierAuthentification(string login, string password)
            {
            return DeveloppeurAccess.ControleAuthentification(login, password);
            }

        // Exécute la requête SQL de vérification des identifiants dans la base de données
        public static bool ControleAuthentification(string login, string password)
            {
            string req = "SELECT * FROM developpeur WHERE nom = @login AND pwd = SHA2(@password, 256);";
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "@login", login },
        { "@password", password }


    }; string username = login;
            Console.WriteLine($"Authentification avec user : {username}");

            List<object[]> records = Access.GetInstance().Manager.ReqSelect(req, parameters);
            return records != null && records.Count > 0;
            }


        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
            {
            this.Login = new System.Windows.Forms.TextBox();
            this.Label_Login = new System.Windows.Forms.Label();
            this.Password = new System.Windows.Forms.TextBox();
            this.Label_Password = new System.Windows.Forms.Label();
            this.Se_connecter = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Login
            // 
            this.Login.Location = new System.Drawing.Point(516, 153);
            this.Login.Name = "Login";
            this.Login.Size = new System.Drawing.Size(211, 20);
            this.Login.TabIndex = 0;
            this.Login.BackColor = System.Drawing.Color.FromArgb(50, 50, 75);
            this.Login.ForeColor = System.Drawing.Color.White;
            // 
            // Label_Login
            // 
            this.Label_Login.AutoSize = true;
            this.Label_Login.Location = new System.Drawing.Point(599, 137);
            this.Label_Login.Name = "Label_Login";
            this.Label_Login.Size = new System.Drawing.Size(33, 13);
            this.Label_Login.TabIndex = 1;
            this.Label_Login.ForeColor = System.Drawing.Color.White;
            this.Label_Login.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Label_Login.Text = "Login";
            this.Label_Login.Click += new System.EventHandler(this.label1_Click);
            // 
            // Password
            // 
            this.Password.Location = new System.Drawing.Point(516, 240);
            this.Password.Name = "Password";
            this.Password.Size = new System.Drawing.Size(211, 20);
            this.Password.TabIndex = 2;
            this.Password.BackColor = System.Drawing.Color.FromArgb(50, 50, 75);
            this.Password.ForeColor = System.Drawing.Color.White;
            // 
            // Label_Password
            // 
            this.Label_Password.AutoSize = true;
            this.Label_Password.Location = new System.Drawing.Point(599, 224);
            this.Label_Password.Name = "Label_Password";
            this.Label_Password.Size = new System.Drawing.Size(53, 13);
            this.Label_Password.TabIndex = 3;
            this.Label_Password.ForeColor = System.Drawing.Color.White;
            this.Label_Password.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Label_Password.Text = "Password";
            // 
            // Se_connecter
            // 
            this.Se_connecter.Location = new System.Drawing.Point(577, 358);
            this.Se_connecter.Name = "Se_connecter";
            this.Se_connecter.Size = new System.Drawing.Size(92, 23);
            this.Se_connecter.TabIndex = 4;
            this.Se_connecter.Text = "Se connecter";
            this.Se_connecter.BackColor = System.Drawing.Color.FromArgb(52, 120, 200);
            this.Se_connecter.ForeColor = System.Drawing.Color.White;
            this.Se_connecter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Se_connecter.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.Se_connecter.UseVisualStyleBackColor = false;
            // 
            // FormLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(30, 30, 50);
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.Se_connecter);
            this.Controls.Add(this.Label_Password);
            this.Controls.Add(this.Password);
            this.Controls.Add(this.Label_Login);
            this.Controls.Add(this.Login);
            this.Name = "FormLogin";
            this.Text = "MediaTek86 - Connexion";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
            Se_connecter.Click += new EventHandler(Se_connecter_Click);
            }

        #endregion
        private System.Windows.Forms.TextBox Login;
        private System.Windows.Forms.Label Label_Login;
        private System.Windows.Forms.TextBox Password;
        private System.Windows.Forms.Label Label_Password;
        private System.Windows.Forms.Button Se_connecter;
        }
    }

