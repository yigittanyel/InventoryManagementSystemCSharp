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
    public partial class Bilgisayar : Form
    {
        public Bilgisayar()
        {
            InitializeComponent();
        }

        private void Bilgisayar_Load(object sender, EventArgs e)
        {
            //BİLGİSAYAR TİPİ
            comboBox3.Items.Add("Masaüstü");
            comboBox3.Items.Add("RDP");
            comboBox3.Items.Add("Laptop");


            //İŞLEMCİ
            comboBox5.Items.Add("i3-2350M");
            comboBox5.Items.Add("i3-3220");
            comboBox5.Items.Add("İ3-4160");
            comboBox5.Items.Add("i3-4170");
            comboBox5.Items.Add("i3-6006U");
            comboBox5.Items.Add("i5-3230M");
            comboBox5.Items.Add("i5-4430S");
            comboBox5.Items.Add("i5-4590");
            comboBox5.Items.Add("İ5-6400T");
            comboBox5.Items.Add("i5-6500");
            comboBox5.Items.Add("i5-7400");
            comboBox5.Items.Add("i5-8400");
            comboBox5.Items.Add("i5-10210U");
            comboBox5.Items.Add("i5-1135G7");
            comboBox5.Items.Add("İ7-7500U");
            comboBox5.Items.Add("i7-7600U");
            comboBox5.Items.Add("i7-8665U");
            comboBox5.Items.Add("i7-10610U");
            comboBox5.Items.Add("i7-11370H");
            comboBox5.Items.Add("Pentium G2030");
            comboBox5.Items.Add("Xeon E-1245 v6");
            comboBox5.Items.Add("Xeon E3-1270");
            comboBox5.Items.Add("Xeon E-2274G");

            //RAM
            comboBox6.Items.Add("2 GB");
            comboBox6.Items.Add("2X2 GB");
            comboBox6.Items.Add("4 GB");
            comboBox6.Items.Add("2x4 GB");
            comboBox6.Items.Add("8 GB");
            comboBox6.Items.Add("2x8 GB");
            comboBox6.Items.Add("16 GB");
            comboBox6.Items.Add("2x16 6GB");
            comboBox6.Items.Add("32 GB");

            //HDD
            comboBox7.Items.Add("120 GB SSD");
            comboBox7.Items.Add("128 GB SSD");
            comboBox7.Items.Add("256 GB m2.SSD");
            comboBox7.Items.Add("256 GB SSD");
            comboBox7.Items.Add("500 GB m2.SSD");
            comboBox7.Items.Add("512 GB m2.SSD");
            comboBox7.Items.Add("500 GB HDD");
            comboBox7.Items.Add("1 TB HDD");
            comboBox7.Items.Add("256 GB SSD + 1 TB HDD + 1 TB HDD");
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
