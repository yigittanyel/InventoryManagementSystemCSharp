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
    public partial class AnaEkran : Form
    {
        SqlConnection baglanti;
        SqlCommand komut;
        SqlDataAdapter da;
        public AnaEkran()
        {
            InitializeComponent();
        }
        public void EnvanterGoruntule()
        {
            baglanti = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=CihazEnvanter;Integrated Security=True");
            baglanti.Open();
            da = new SqlDataAdapter(@"Select Ci.CihazId,Ci.CihazPcAdi,ca.CalisanIysKod as 'Çalışan Iys Kodu',Ca.CalisanBolum as 'Bölüm',Ca.CalisanAdSoyad as 'Çalışan Adı-Soyadı',Ca.CalisanUnvan as 'Unvan',Cm.CihazMarkaAdi,Ci.CihazModel,Ci.CihazSeriNo as 'Seri No',Cisl.CihazİslemciAdi as 'İşlemci',Cisl.CihazİslemciMarkasi as 'İşlemci Markası',ct.CihazTipiAdi as 'Cihaz Tipi',Ctur.CihazTuru as 'Cihaz Türü',Cr.CihazRamGb as 'Ram',cd.CihazDiskTuru as 'Disk Türü',Cd.CihazDiskGb as 'Disk GB',Ctur.CihazTuru as 'Cihaz Türü',Cekr.CihazEkranModel as 'Ekran Modeli',Cekr.CihazEkranBoyut as 'Ekran Boyutu',Ci.CihazAidiyet as 'Kiralık/Bizim',ISNULL(Ci.CihazAlinanFirma,'-') as 'Cihazın Alındığı Firma',Ci.CihazGarantiBaslangic as 'Garanti Başlangıç',Ci.CihazGarantiBitis as 'Garanti Bitiş',Ci.CihazFaturaTarih as 'Fatura Tarihi',Ci.CihazFaturaNo as 'Fatura No',Ci.CihazFaturaFoto as 'Fatura Fotoğraf'                        
                from Cihaz Ci
                LEFT JOIN Calisanlar Ca on Ci.CalisanId=Ca.CalisanId
                LEFT JOIN CihazDisk Cd on Ci.CihazDiskId=Cd.CihazDiskId
                LEFT JOIN CihazEkran Ce on Ce.CihazEkranId=Ci.CihazEkranId
                LEFT JOIN Cihazİslemci Cisl on Cisl.CihazİslemciId=Ci.CihazİslemciId
                LEFT JOIN CihazMarka Cm on Cm.CihazMarkaId=Ci.CihazMarkaId
                LEFT JOIN CihazRam Cr on Cr.CihazRamId=Ci.CihazRamId
                LEFT JOIN CihazTipi Ct on Ct.CihazTipId=Ci.CihazTipId
                LEFT JOIN CihazEkran Cekr on Cekr.CihazEkranId=Ci.CihazEkranId
                LEFT JOIN CihazTur Ctur on Ctur.CihazTurId=Ci.CihazTurId
                ", baglanti);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();

        }


        private void AnaEkran_Load(object sender, EventArgs e)
        {
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            /*if (radioButton1.Checked == true)
            {
                AidiyetFaturaListele();
            }*/

        }
        private void BtnEkle_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Hide();
            EklemeEkrani ee = new EklemeEkrani();
            ee.Show();
                
            
            

        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {   //LİSTELE
            EnvanterGoruntule();
        }

        private void barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {   //EKLEYE BASTIĞIMIZDA EKLE EKRANINA YÖNLENDİRİR.
            EklemeEkrani ae = new EklemeEkrani();
            this.Hide();
            ae.Show();
        }

        private void barButtonItem8_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {   //SİL
            baglanti = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=CihazEnvanter;Integrated Security=True");
            string sorgu = "DELETE from Cihaz where CihazId=@CihazId";
            komut = new SqlCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@CihazId", dataGridView1.CurrentRow.Cells[0].Value);//onemli!!!
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kayıt başarıyla silindi.");
            EnvanterGoruntule();
        }

        private void barButtonItem9_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {   //GÜNCELLE  --  datagrid editable
            panel1.Visible = true;
            baglanti = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=CihazEnvanter;Integrated Security=True");
            SqlCommand komut = new SqlCommand("UPDATE Cihaz set CihazPcAdi=@CihazPcAdi,CalisanId=@CalisanId,CihazDiskId=@CihazDiskId,CihazİslemciId=@CihazİslemciId,CihazMarkaId=@CihazMarkaId,CihazRamId=@CihazRamId,CihazTipId=@CihazTipId,CihazTurId=@CihazTurId,CihazSeriNo=@CihazSeriNo,CihazModel=@CihazModel,CihazEkranId=@CihazEkranId,CihazGarantiBaslangic=@CihazGarantiBaslangic,CihazGarantiBitis=@CihazGarantiBitis,CihazAidiyet=@CihazAidiyet,CihazAlinanFirma=@CihazAlinanFirma,CihazFaturaTarih=@CihazFaturaTarih,CihazFaturaNo=@CihazFaturaNo where CihazId=@CihazId", baglanti);
            textBox3.Text = dataGridView1.CurrentRow.Cells["CihazId"].Value.ToString();
            textBox9.Text = dataGridView1.CurrentRow.Cells["CihazModel"].Value.ToString();
            textBox10.Text = dataGridView1.CurrentRow.Cells["Seri No"].Value.ToString();        
            dateTimePicker1.Text= dataGridView1.CurrentRow.Cells["Garanti Başlangıç"].Value.ToString();
            dateTimePicker2.Text= dataGridView1.CurrentRow.Cells["Garanti Bitiş"].Value.ToString();
            textBox11.Text = dataGridView1.CurrentRow.Cells["Kiralık/Bizim"].Value.ToString();
            textBox13.Text = dataGridView1.CurrentRow.Cells["Cihazın Alındığı Firma"].Value.ToString();
            dateTimePicker3.Text= dataGridView1.CurrentRow.Cells["Fatura Tarihi"].Value.ToString();
            textBox14.Text = dataGridView1.CurrentRow.Cells["CihazPcAdi"].Value.ToString();

        }
        private void barButtonItem10_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //textBox1.Text = "";
            //panel1.Visible = false;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            
            //EnvanterGoruntule();
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
           // panel2.Visible = false;

        }
    }
}

//
//komut.Parameters.AddWithValue("@CihazPcAdi", dataGridView1.CurrentRow.Cells[1].Value.ToString());
//SqlCommand komut2 = new SqlCommand("SELECT CalisanIysKod from Calisanlar", baglanti);
//komut2.Parameters.AddWithValue("@CalisanIysKod", dataGridView1.CurrentRow.Cells[2].Value);
//SqlCommand komut3 = new SqlCommand("SELECT CalisanBolum from Calisanlar", baglanti);
//komut3.Parameters.AddWithValue("@CalisanBolum", dataGridView1.CurrentRow.Cells[3].Value.ToString());
//SqlCommand komut4 = new SqlCommand("SELECT CalisanAdSoyad from Calisanlar", baglanti);
//komut4.Parameters.AddWithValue("@CalisanAdSoyad", dataGridView1.CurrentRow.Cells[4].Value.ToString());
//SqlCommand komut5 = new SqlCommand("SELECT CalisanUnvan from Calisanlar", baglanti);
//komut5.Parameters.AddWithValue("@CalisanUnvan", dataGridView1.CurrentRow.Cells[5].Value.ToString());
//baglanti.Open();
//komut.ExecuteNonQuery();
//baglanti.Close();
//MessageBox.Show("Güncelleme işlemi başarılı.");

//komut.Parameters.AddWithValue("@CalisanId", textEdit3.Text);
//komut.Parameters.AddWithValue("@CihazDiskId", textEdit4.Text);
//komut.Parameters.AddWithValue("@CihazİslemciId", textEdit5.Text);
//komut.Parameters.AddWithValue("@CihazMarkaId", textEdit6.Text);
//komut.Parameters.AddWithValue("@CihazRamId", textEdit7.Text);
//komut.Parameters.AddWithValue("@CihazTipId", textEdit8.Text);
//komut.Parameters.AddWithValue("@CihazTurId", textEdit9.Text);
//komut.Parameters.AddWithValue("@CihazSeriNo", textEdit18.Text);
//komut.Parameters.AddWithValue("@CihazModel", textEdit17.Text);
//komut.Parameters.AddWithValue("@CihazEkranId", textEdit16.Text);
//komut.Parameters.AddWithValue("@CihazGarantiBaslangic", dateTimePicker1.Value);
//komut.Parameters.AddWithValue("@CihazGarantiBitis", dateTimePicker2.Value);
//komut.Parameters.AddWithValue("@CihazAidiyet", comboBox1.Text);
//komut.Parameters.AddWithValue("@CihazAlinanFirma", textEdit12.Text);
//komut.Parameters.AddWithValue("@CihazFaturaTarih", dateTimePicker3.Value);
//komut.Parameters.AddWithValue("@CihazFaturaNo", textEdit10.Text);
//baglanti.Open();
//komut.ExecuteNonQuery();
//baglanti.Close();
//MessageBox.Show("Kayıt başarıyla güncellendi.");
//EnvanterGoruntule();




