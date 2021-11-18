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
    public partial class İsletimSistemi : Form
    {
        public İsletimSistemi()
        {
            InitializeComponent();
        }

        private void İsletimSistemi_Load(object sender, EventArgs e)
        {
            //VERSİYON
            comboBox9.Items.Add("1607");
            comboBox9.Items.Add("1709");
            comboBox9.Items.Add("1803");
            comboBox9.Items.Add("1809");
            comboBox9.Items.Add("1903");
            comboBox9.Items.Add("2004");
            comboBox9.Items.Add("2009");

            //İŞLETİM SİSTEMİ
            comboBox12.Items.Add("WIN 10 PRO X64 BİT");
            comboBox12.Items.Add("WIN 10 PRO WORKSTATION X64");
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
