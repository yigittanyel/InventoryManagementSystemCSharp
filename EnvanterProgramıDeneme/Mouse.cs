﻿using System;
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
    public partial class Mouse : Form
    {
        public Mouse()
        {
            InitializeComponent();
        }

        private void Mouse_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("Kablolu");
            comboBox1.Items.Add("Kablosuz");
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
