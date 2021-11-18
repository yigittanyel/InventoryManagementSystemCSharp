using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.SqlClient;

namespace EnvanterProgramıDeneme
{
    public partial class Form1 : XtraForm
    {
        SqlConnection baglanti;
        SqlCommand komut;
        SqlDataAdapter da;
        public Form1()
        {
            InitializeComponent();
        }
        void CihazListele()
        {
            baglanti = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=dbo_envanter;Integrated Security=True");
            baglanti.Open();
            da = new SqlDataAdapter("SELECT * from tblCihaz where ", baglanti);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            gridControl1.DataSource = tablo;
            baglanti.Close();
        }

        void KullaniciListele()
        {
            baglanti = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=dbo_envanter;Integrated Security=True");
            baglanti.Open();
            da = new SqlDataAdapter("SELECT * from tblKullanici", baglanti);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            gridControl2.DataSource = tablo;
            baglanti.Close();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //CİHAZ TİPİ
            comboBox2.Items.Add("Bilgisayar");
            comboBox2.Items.Add("Ekran");
            comboBox2.Items.Add("Yazıcı");
            comboBox2.Items.Add("El Terminali");
            comboBox2.Items.Add("Barkod Okuyucu");
            comboBox2.Items.Add("Mouse");
            comboBox2.Items.Add("Klavye");
            comboBox2.Items.Add("Projeksiyon Cihazı");

            CihazListele();
            KullaniciListele();
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            
            /*
            string sorgu = "INSERT into ogrenci(ograd,ogrsoyad,cinsiyet,dtarih,sinif,puan) values(@ograd,@ogrsoyad,@cinsiyet,@dtarih,@sinif,@puan)";
            komut = new SqlCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@ograd", textBox2.Text);
            komut.Parameters.AddWithValue("@ogrsoyad", textBox3.Text);
            komut.Parameters.AddWithValue("@cinsiyet", comboBox1.Text);
            komut.Parameters.AddWithValue("@dtarih", dateTimePicker1.Value);
            komut.Parameters.AddWithValue("@sinif", comboBox2.Text);
            komut.Parameters.AddWithValue("@puan", textBox4.Text);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
            OgrenciListele();
            MessageBox.Show("Kayıt başarıyla eklendi.");
            */
        }



        private void simpleButton7_Click(object sender, EventArgs e)
        {
            if (comboBox2.Text == "Ekran")
            {
                this.Hide();
                Ekran newPage = new Ekran();
                newPage.Show();
            }
        }

        private void simpleButton8_Click(object sender, EventArgs e)
        {
            if (comboBox2.Text == "Yazıcı")
            {
                this.Hide();
                Yazıcı newPage = new Yazıcı();
                newPage.Show();
            }
        }

        private void simpleButton9_Click(object sender, EventArgs e)
        {
            if (comboBox2.Text == "El Terminali")
            {
                this.Hide();
                ElTerminali newPage = new ElTerminali();
                newPage.Show();
            }
        }

        private void simpleButton10_Click(object sender, EventArgs e)
        {
            if (comboBox2.Text == "Barkod Okuyucu")
            {
                this.Hide();
                BarkodOkuyucu newPage = new BarkodOkuyucu();
                newPage.Show();
            }
        }

        private void simpleButton11_Click(object sender, EventArgs e)
        {
            if (comboBox2.Text == "Mouse")
            {
                this.Hide();
                Mouse newPage = new Mouse();
                newPage.Show();
            }
        }

        private void simpleButton12_Click(object sender, EventArgs e)
        {
            if (comboBox2.Text == "Projeksiyon")
            {
                this.Hide();
                Projeksiyon newPage = new Projeksiyon();
                newPage.Show();
            }
        }

        private void simpleButton13_Click(object sender, EventArgs e)
        {
            if (comboBox2.Text == "Klavye")
            {
                this.Hide();
                Klavye newPage = new Klavye();
                newPage.Show();
            }
        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            if (comboBox2.Text == "Bilgisayar")
            {
                this.Hide();
                Bilgisayar newPage = new Bilgisayar();
                newPage.Show();
            }
        }

        private void comboBox2_SelectedValueChanged(object sender, EventArgs e)
        {

        }
    }
}
