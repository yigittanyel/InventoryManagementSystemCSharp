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
    public partial class GuncelleEkrani : Form
    {
        public GuncelleEkrani()
        {
            InitializeComponent();
        }

        private void GuncelleEkrani_Load(object sender, EventArgs e)
        {
            panel1.Visible = true;
           // textBox1.Text = AnaEkran.d.CurrentRow.Cells["CihazId"].Value.ToString();
        }
    }
}
