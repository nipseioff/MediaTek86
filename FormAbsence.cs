
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MediaTek86
    {
    ///
    ///Formulaire de gestion des Absences
    ///
    public partial class FormAbsence : Form
        {
        ///
        ///Formulaire de gestion des Absences
        ///
        // Initialise le formulaire Absences et charge la liste des absences au démarrage
        public FormAbsence()
            {
            InitializeComponent();
            Absence(); // Charge les données dans le DataGridView
            }

        // Événement déclenché lors d'un changement dans une zone de texte (non utilisé)
        private void TextBox1_TextChanged(object sender, EventArgs e)
            {

            }

        // Événement déclenché au clic sur une cellule du tableau des absences (non utilisé)
        private void DataGriedViewAbsence_CellContentClick(object sender, DataGridViewCellEventArgs e)
            {

            }
        }
    }
