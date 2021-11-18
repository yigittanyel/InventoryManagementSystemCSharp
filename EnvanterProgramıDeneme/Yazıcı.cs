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
    public partial class Yazıcı : Form
    {
        public Yazıcı()
        {
            InitializeComponent();
        }

        private void Yazıcı_Load(object sender, EventArgs e)
        {
            //YAZICI TİPİ
            comboBox4.Items.Add("Deskjeti Lasr");
            comboBox4.Items.Add("Barkod");
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
