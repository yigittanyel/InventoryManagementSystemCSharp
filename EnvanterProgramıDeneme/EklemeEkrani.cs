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
    public partial class EklemeEkrani : Form
    {
        SqlConnection baglanti;
        SqlCommand komut;
        public EklemeEkrani()
        {
            InitializeComponent();
        }
        private void EklemeEkrani_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("Kiralık");
            comboBox1.Items.Add("Bizim");

            //POSITION için ;  bunu properties -> start-position -> center yaparak çözdük.
            //this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            //EklemeEkrani ee = new EklemeEkrani();
            //ee.WindowState = FormWindowState.Normal;
            //ee.StartPosition = FormStartPosition.Manual;
            //ee.Location = new Point(0, 0);
            //ee.Show();

            //baglanti = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=CihazEnvanter;Integrated Security=True");
            //komut = new SqlCommand();
            //komut.CommandText = "SELECT *FROM CihazMarka";
            //komut.Connection = baglanti;
            //komut.CommandType = CommandType.Text;

            //SqlDataReader dr;
            //baglanti.Open();
            //dr = komut.ExecuteReader();
            //while (dr.Read())
            //{
            //    comboBox3.Items.Add(dr["CihazMarkaAdi"]);
            //}
            //baglanti.Close();

        }

        public void simpleButton1_Click(object sender, EventArgs e) //ekle
        {
            baglanti = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=CihazEnvanter;Integrated Security=True");
            string qry = (@"
                       insert into Cihaz (CihazPcAdi,CalisanId,CihazDiskId,CihazİslemciId,CihazMarkaId,CihazRamId,CihazTipId,CihazTurId,CihazSeriNo,CihazModel,CihazEkranId,CihazGarantiBaslangic,CihazGarantiBitis,CihazAidiyet,CihazAlinanFirma,CihazFaturaTarih,CihazFaturaNo,CihazFaturaFoto) 
                            values
                            ( @CihazPcAdi,@CalisanId,@CihazDiskId,@CihazİslemciId,@CihazMarkaId,@CihazRamId,@CihazTipId,@CihazTurId,@CihazSeriNo,@CihazModel,@CihazEkranId,@CihazGarantiBaslangic,@CihazGarantiBitis,@CihazAidiyet,@CihazAlinanFirma,@CihazFaturaTarih,@CihazFaturaNo,@CihazFaturaFoto)");
            komut = new SqlCommand(qry, baglanti);
            komut.Parameters.AddWithValue("@CihazPcAdi", textEdit2.Text);
            komut.Parameters.AddWithValue("@CalisanId", textEdit3.Text);
            komut.Parameters.AddWithValue("@CihazDiskId", textEdit4.Text);
            komut.Parameters.AddWithValue("@CihazİslemciId", textEdit5.Text);
            komut.Parameters.AddWithValue("@CihazMarkaId", textEdit6.Text);
            komut.Parameters.AddWithValue("@CihazRamId", textEdit7.Text);
            komut.Parameters.AddWithValue("@CihazTipId", textEdit8.Text);
            komut.Parameters.AddWithValue("@CihazTurId", textEdit9.Text);
            komut.Parameters.AddWithValue("@CihazSeriNo", textEdit18.Text);
            komut.Parameters.AddWithValue("@CihazModel", textEdit17.Text);
            komut.Parameters.AddWithValue("@CihazEkranId", textEdit16.Text);
            komut.Parameters.AddWithValue("@CihazGarantiBaslangic", dateTimePicker1.Value);
            komut.Parameters.AddWithValue("@CihazGarantiBitis", dateTimePicker2.Value);
            komut.Parameters.AddWithValue("@CihazAidiyet", comboBox1.Text);
            komut.Parameters.AddWithValue("@CihazAlinanFirma", textEdit12.Text);
            komut.Parameters.AddWithValue("@CihazFaturaTarih", dateTimePicker3.Value);
            komut.Parameters.AddWithValue("@CihazFaturaNo", textEdit10.Text);
            komut.Parameters.AddWithValue("@CihazFaturaFoto", textEdit1.Text);

            if (textEdit3.Text == "")
            {
                MessageBox.Show("Çalışan ID boş geçilemez.");
            }
            else if (textEdit2.Text==""||textEdit4.Text==""||textEdit5.Text==""||textEdit7.Text=="" 
                ||textEdit8.Text==""|| textEdit9.Text=="" || textEdit18.Text=="" || textEdit17.Text=="" || textEdit16.Text==""||comboBox1.Text=="" || textEdit10.Text == "" || dateTimePicker1.Text==""||dateTimePicker2.Text==""||dateTimePicker3.Text=="")
            {
                if (DialogResult.Yes == MessageBox.Show("Boş alanlar var.Yine de veri eklensin mi ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                {
                    baglanti.Open();
                    komut.ExecuteNonQuery();
                    baglanti.Close();
                    MessageBox.Show("Kayıt başarıyla eklendi.");
                    this.Close();
                    AnaEkran ae = new AnaEkran();
                    ae.EnvanterGoruntule();
                }
                else
                {
                    
                }

            }
            else
            {               
                baglanti.Open();
                komut.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Kayıt başarıyla eklendi.");
                this.Close();
                AnaEkran ae = new AnaEkran();
                ae.Show();
            }

        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            AnaEkran ae = new AnaEkran();
            this.Hide();
            ae.Show();
        }

        private void simpleButton2_Click(object sender, EventArgs e)  // SİL
        {
            baglanti = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=CihazEnvanter;Integrated Security=True");
            string sorgu = "DELETE from Cihaz where CalisanId=@CalisanId";
            komut = new SqlCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@CalisanId",textEdit3.Text);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kayıt başarıyla silindi.");
            //EnvanterGoruntule();
        }
        private void comboBox1_TextChanged(object sender, EventArgs e)
        {

            if (comboBox1.Text == "Bizim")
            {
                textEdit12.Enabled = false;
            }
            else
            {
                textEdit12.Enabled = true;
            }
           
        }

        private void simpleButton1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void simpleButton2_Click_1(object sender, EventArgs e)
        { // EKLE
            AnaEkran anaekran = new AnaEkran();
            baglanti = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=CihazEnvanter;Integrated Security=True");
            string qry = (@"
                       insert into Cihaz (CihazPcAdi,CalisanId,CihazDiskId,CihazİslemciId,CihazMarkaId,CihazRamId,CihazTipId,CihazTurId,CihazSeriNo,CihazModel,CihazEkranId,CihazGarantiBaslangic,CihazGarantiBitis,CihazAidiyet,CihazAlinanFirma,CihazFaturaTarih,CihazFaturaNo,CihazFaturaFoto) 
                            values
                            ( @CihazPcAdi,@CalisanId,@CihazDiskId,@CihazİslemciId,@CihazMarkaId,@CihazMarkaId,@CihazRamId,@CihazTipId,@CihazTurId,@CihazSeriNo,@CihazModel,@CihazEkranId,@CihazGarantiBaslangic,@CihazGarantiBitis,@CihazAidiyet,@CihazAlinanFirma,@CihazFaturaTarih,@CihazFaturaNo,@CihazFaturaFoto)");
            //string qry2 = (@"insert into CihazMarka (CihazMarkaAdi) values (@CihazMarkaAdi)");
            //SqlCommand komut2 = new SqlCommand(qry2, baglanti);

            //komut2.Parameters.AddWithValue("@CihazMarkaAdi", comboBox3.Text);
            komut = new SqlCommand(qry, baglanti);
            komut.Parameters.AddWithValue("@CihazPcAdi", textEdit2.Text);
            komut.Parameters.AddWithValue("@CalisanId", textEdit3.Text);
            komut.Parameters.AddWithValue("@CihazDiskId", textEdit4.Text);
            komut.Parameters.AddWithValue("@CihazİslemciId", textEdit5.Text);
            komut.Parameters.AddWithValue("@CihazMarkaId", textEdit6.Text);
            komut.Parameters.AddWithValue("@CihazRamId", textEdit7.Text);
            komut.Parameters.AddWithValue("@CihazTipId", textEdit8.Text);
            komut.Parameters.AddWithValue("@CihazTurId", textEdit9.Text);
            komut.Parameters.AddWithValue("@CihazSeriNo", textEdit18.Text);
            komut.Parameters.AddWithValue("@CihazModel", textEdit17.Text);
            komut.Parameters.AddWithValue("@CihazEkranId", textEdit16.Text);
            komut.Parameters.AddWithValue("@CihazGarantiBaslangic", dateTimePicker1.Value);
            komut.Parameters.AddWithValue("@CihazGarantiBitis", dateTimePicker2.Value);
            komut.Parameters.AddWithValue("@CihazAidiyet", comboBox1.Text);
            komut.Parameters.AddWithValue("@CihazAlinanFirma", textEdit12.Text);
            komut.Parameters.AddWithValue("@CihazFaturaTarih", dateTimePicker3.Value);
            komut.Parameters.AddWithValue("@CihazFaturaNo", textEdit10.Text);
            komut.Parameters.AddWithValue("@CihazFaturaFoto", textEdit1.Text);

            if (textEdit3.Text == "")
            {
                MessageBox.Show("Çalışan ID boş geçilemez.");
            }
            else if (textEdit2.Text == "" || textEdit4.Text == "" || textEdit5.Text == ""||textEdit6.Text=="" || textEdit7.Text == ""
                || textEdit8.Text == "" || textEdit9.Text == "" || textEdit18.Text == "" || textEdit17.Text == "" || textEdit16.Text == "" || comboBox1.Text == "" || textEdit10.Text == "" || dateTimePicker1.Text == "" || dateTimePicker2.Text == "" || dateTimePicker3.Text == "")
            {
                if (DialogResult.Yes == MessageBox.Show("Boş alanlar var.Yine de veri eklensin mi ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                {
                    baglanti.Open();
                    komut.ExecuteNonQuery();
                    baglanti.Close();                 
                    MessageBox.Show("Kayıt başarıyla eklendi.");
                    anaekran.EnvanterGoruntule();
                    this.Close();
                }
                else
                {
                    textEdit2.Text += this.Text;
                    textEdit3.Text += this.Text.ToString();
                    textEdit4.Text += this.Text.ToString();
                    textEdit5.Text += this.Text.ToString();
                   // textEdit6.Text += this.Text.ToString();
                    textEdit7.Text += this.Text.ToString();
                    textEdit8.Text += this.Text.ToString();
                    textEdit9.Text += this.Text.ToString();
                    textEdit18.Text += this.Text.ToString();
                    textEdit17.Text += this.Text;
                    textEdit16.Text += this.Text.ToString();
                    dateTimePicker1.Text += this.Text.ToString();
                    dateTimePicker2.Text += this.Text.ToString();
                    comboBox1.Text += this.Text;
                    textEdit12.Text += this.Text;
                    dateTimePicker3.Text += this.Text.ToString();
                    textEdit10.Text += this.Text.ToString();
                    textEdit1.Text += this.Text;
                }
            }
            else
            {
                baglanti.Open();
                komut.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Kayıt başarıyla eklendi.");
                this.Close();
            }
        }
    }
}
