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
        SqlDataAdapter da;
        public EklemeEkrani()
        {
            InitializeComponent();
        }
        /*public void EnvanterGoruntule()
         {
             baglanti = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=CihazEnvanter;Integrated Security=True");
             baglanti.Open();
             da = new SqlDataAdapter(@"Select Ci.CihazId,Ci.CihazPcAdi,ISNULL(ca.CalisanIysKod,'--') as 'Çalışan Iys Kodu',Ca.CalisanBolum as 'Bölüm',Ca.CalisanAdSoyad as 'Çalışan Adı-Soyadı',Ca.CalisanUnvan as 'Unvan',Cm.CihazMarkaAdi,Ci.CihazModel,Ci.CihazSeriNo as 'Seri No',Cisl.CihazİslemciAdi as 'İşlemci',Cisl.CihazİslemciMarkasi as 'İşlemci Markası',ct.CihazTipiAdi as 'Cihaz Tipi',Ctur.CihazTuru as 'Cihaz Türü',Cr.CihazRamGb as 'Ram',cd.CihazDiskTuru as 'Disk Türü',Cd.CihazDiskGb as 'Disk GB',Ctur.CihazTuru as 'Cihaz Türü',Cekr.CihazEkranModel as 'Ekran Modeli',Cekr.CihazEkranBoyut as 'Ekran Boyutu',Ci.CihazAidiyet as 'Kiralık/Bizim',ISNULL(Ci.CihazAlinanFirma,'-') as 'Cihazın Alındığı Firma',Ci.CihazGarantiBaslangic as 'Garanti Başlangıç',Ci.CihazGarantiBitis as 'Garanti Bitiş',Ci.CihazFaturaTarih as 'Fatura Tarihi',Ci.CihazFaturaNo as 'Fatura No',Ci.CihazFaturaFoto as 'Fatura Fotoğraf'                        
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

         }*/

        private void EklemeEkrani_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("Kiralık");
            comboBox1.Items.Add("Bizim");
            

           
        }

        private void simpleButton1_Click(object sender, EventArgs e) //ekle
        {
            baglanti = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=CihazEnvanter;Integrated Security=True");
            string qry = (@"
                       insert into Cihaz (CihazPcAdi,CalisanId,CihazDiskId,CihazİslemciId,CihazMarkaId,CihazRamId,CihazTipId,CihazTurId,CihazSeriNo,CihazModel,CihazEkranId,CihazGarantiBaslangic,CihazGarantiBitis,CihazAidiyet,CihazAlinanFirma,CihazFaturaTarih,CihazFaturaNo) 
                            values
                            ( @CihazPcAdi,@CalisanId,@CihazDiskId,@CihazİslemciId,@CihazMarkaId,@CihazRamId,@CihazTipId,@CihazTurId,@CihazSeriNo,@CihazModel,@CihazEkranId,@CihazGarantiBaslangic,@CihazGarantiBitis,@CihazAidiyet,@CihazAlinanFirma,@CihazFaturaTarih,@CihazFaturaNo)");
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
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kayıt başarıyla eklendi.");
            //EnvanterGoruntule();

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

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
           /* textEdit2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();//pc adi
            textEdit17.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();//cihaz model
            textEdit18.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();//seri no
            comboBox1.Text = dataGridView1.CurrentRow.Cells[19].Value.ToString();//kiralık
            textEdit12.Text = dataGridView1.CurrentRow.Cells[20].Value.ToString();//alinan firma
            dateTimePicker1.Text = dataGridView1.CurrentRow.Cells[21].Value.ToString();//garanti başlangıc
            dateTimePicker2.Text = dataGridView1.CurrentRow.Cells[22].Value.ToString();//garanti bitis
            dateTimePicker3.Text = dataGridView1.CurrentRow.Cells[23].Value.ToString();//fatura tarihi
            textEdit10.Text = dataGridView1.CurrentRow.Cells[24].Value.ToString();//fatura no
            
            */


        }

        private void simpleButton3_Click(object sender, EventArgs e) //GUNCELLE
        {
            /*
            baglanti = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=CihazEnvanter;Integrated Security=True");
            string sorgu = "UPDATE Cihaz set CihazPcAdi=@CihazPcAdi,CalisanId=@CalisanId,CihazDiskId=@CihazDiskId,CihazİslemciId=@CihazİslemciId,CihazMarkaId=@CihazMarkaId,CihazRamId=@CihazRamId,CihazTipId=@CihazTipId,CihazTurId=@CihazTurId,CihazSeriNo=@CihazSeriNo,CihazModel=@CihazModel,CihazEkranId=@CihazEkranId,CihazGarantiBaslangic=@CihazGarantiBaslangic,CihazGarantiBitis=@CihazGarantiBitis,CihazAidiyet=@CihazAidiyet,CihazAlinanFirma=@CihazAlinanFirma,CihazFaturaTarih=@CihazFaturaTarih,CihazFaturaNo=@CihazFaturaNo where CalisanId=@CalisanId or CihazSeriNo=@CihazSeriNo";
            komut = new SqlCommand(sorgu, baglanti); //SqlCommand komut=new SqlCommand()
            komut.Parameters.AddWithValue("@CihazPcAdi",);
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
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kayıt başarıyla güncellendi.");
            //EnvanterGoruntule();
            */
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
    }
}
