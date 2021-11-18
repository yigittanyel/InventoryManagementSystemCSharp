using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace EnvanterProgramıDeneme
{
    public partial class Ekran : Form
    {
        public Ekran()
        {
            InitializeComponent();
        }
        SqlConnection baglanti;
        SqlCommand komut;
        SqlDataAdapter da;
        void EkranListele()
        {
            baglanti = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=dbo_envanter;Integrated Security=True");
            baglanti.Open();
            da = new SqlDataAdapter("SELECT * from tblEkran", baglanti);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            gridControl1.DataSource = tablo;
            baglanti.Close();
        }
        private void Ekran_Load(object sender, EventArgs e)
        {
            //EKRAN TİPİ
            comboBox15.Items.Add("15.6' ");
            comboBox15.Items.Add("17' ");
            comboBox15.Items.Add("19' ");
            comboBox15.Items.Add("22' ");
            comboBox15.Items.Add("24' ");
            comboBox15.Items.Add("27' ");

            EkranListele();

        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
