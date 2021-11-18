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
    public partial class AidiyetFatura : Form
    {
        public AidiyetFatura()
        {
            InitializeComponent();
        }

        private void AidiyetFatura_Load(object sender, EventArgs e)
        {
            //KİRALIK - BİZİM
            comboBox8.Items.Add("Kiralık");
            comboBox8.Items.Add("Bizim");

        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
