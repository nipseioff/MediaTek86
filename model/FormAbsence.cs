using MediaTek86.model;
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
    public partial class FormAbsence : Form
        {
        public FormAbsence()
            {
            InitializeComponent();
            Absence(); // Charge les données dans le DataGridView
            }

        private void textBox1_TextChanged(object sender, EventArgs e)
            {

            }

        private void dataGriedViewAbsence_CellContentClick(object sender, DataGridViewCellEventArgs e)
            {

            }
        }
    }
