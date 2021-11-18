using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EnvanterProgramıDeneme
{
    public partial class Office : Form
    {
        public Office()
        {
            InitializeComponent();
        }

        private void Office_Load(object sender, EventArgs e)
        {

            //OFFICE PROGRAMI
            comboBox13.Items.Add("OFFICE 2010");
            comboBox13.Items.Add("OFFICE 2016");
            comboBox13.Items.Add("OFFICE 2019");
            comboBox13.Items.Add("Libre Office");

            //OFFİCE LİSANSI
            comboBox14.Items.Add("Var");
            comboBox14.Items.Add("Yok");
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
