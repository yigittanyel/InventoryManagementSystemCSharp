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
using DevExpress.XtraEditors;


namespace EnvanterProgramıDeneme
{
    public partial class AnaEkran : XtraForm
    {
        SqlConnection baglanti;
        SqlCommand komut;
        SqlDataAdapter da;
        DataTable tablo;
        public AnaEkran()
        {
            InitializeComponent();
        }
        public void EnvanterGoruntule()
        {
            baglanti = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=CihazEnvanter;Integrated Security=True");
            baglanti.Open();
            da = new SqlDataAdapter(@"Select Ci.CihazId,Ci.CihazPcAdi,ca.CalisanIysKod as 'Çalışan_Iys_Kodu',Ca.CalisanBolum as 'Bölüm',Ca.CalisanAdSoyad as 'ÇalışanAdSoyad',Ca.CalisanUnvan as 'Unvan',Cm.CihazMarkaAdi,Ci.CihazModel,Ci.CihazSeriNo as 'Seri_No',Cisl.CihazİslemciAdi as 'İşlemci',Cisl.CihazİslemciMarkasi as 'İşlemci_Marka',ct.CihazTipiAdi as 'Cihaz_Tipi',Ctur.CihazTuru as 'Cihaz_Türü',Cr.CihazRamGb as 'Ram',cd.CihazDiskTuru as 'Disk_Türü',Cd.CihazDiskGb as 'Disk_GB',Cekr.CihazEkranModel as 'Ekran_Modeli',Cekr.CihazEkranBoyut as 'Ekran_Boyutu',Ci.CihazAidiyet as 'Kiralık/Bizim',ISNULL(Ci.CihazAlinanFirma,'-') as 'Cihazın Alındığı Firma',Ci.CihazGarantiBaslangic as 'Garanti Başlangıç',Ci.CihazGarantiBitis as 'Garanti Bitiş',Ci.CihazFaturaTarih as 'Fatura Tarihi',Ci.CihazFaturaNo as 'Fatura No',Ci.CihazFaturaFoto as 'Fatura Fotoğraf'                        
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
            tablo = new DataTable();
            da.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();
            //dataGridView1.Sort(dataGridView1.Columns[0], ListSortDirection.Descending);
        }
        private void AnaEkran_Load(object sender, EventArgs e)
        {
            EnvanterGoruntule();
            comboBox1.Items.Add("Kiralık");
            comboBox1.Items.Add("Bizim");
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;

            comboBox2.Items.Add("Cihaz Pc Adı");
            comboBox2.Items.Add("Çalışan IYS Kodu");
            comboBox2.Items.Add("Bölüm");
            comboBox2.Items.Add("Ad Soyad");
            comboBox2.Items.Add("Ünvan");
            comboBox2.Items.Add("Marka Adı");
            comboBox2.Items.Add("Model");
            comboBox2.Items.Add("Seri No");
            comboBox2.Items.Add("İşlemci");
            comboBox2.Items.Add("İşlemci Markası");
            comboBox2.Items.Add("Cihaz Tipi");
            comboBox2.Items.Add("Cihaz Türü");
            comboBox2.Items.Add("Ram");
            comboBox2.Items.Add("Disk Türü");
            comboBox2.Items.Add("Disk GB");
            comboBox2.Items.Add("Ekran Modeli");
            comboBox2.Items.Add("Ekran Boyutu");
            comboBox2.Items.Add("Kiralık/Bizim");
            comboBox2.Items.Add("Alınan Firma");

          


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
            panel1.Visible = false;
        }

        private void barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {   //EKLEYE BASTIĞIMIZDA EKLE EKRANINA YÖNLENDİRİR.
            EklemeEkrani ae = new EklemeEkrani();
            ae.Show();

        }
        private void barButtonItem8_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {   //SİL
            if (DialogResult.Yes == MessageBox.Show("Silmek istediğinizden emin misiniz ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
            {
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
            else
            {
                EnvanterGoruntule();
            }       
        }

        private void barButtonItem9_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {   //GÜNCELLE  --  datagrid editable
            panel1.Visible = true;
            textBox3.Text = dataGridView1.CurrentRow.Cells["CihazId"].Value.ToString();
            textBox9.Text = dataGridView1.CurrentRow.Cells["CihazModel"].Value.ToString();
            textBox10.Text = dataGridView1.CurrentRow.Cells["Seri_No"].Value.ToString();        
            dateTimePicker1.Text= dataGridView1.CurrentRow.Cells["Garanti Başlangıç"].Value.ToString();
            dateTimePicker2.Text= dataGridView1.CurrentRow.Cells["Garanti Bitiş"].Value.ToString();
            comboBox1.Text = dataGridView1.CurrentRow.Cells["Kiralık/Bizim"].Value.ToString();
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

        private void button1_Click_2(object sender, EventArgs e)
        { //RESİM SEÇ BUTONU
            OpenFileDialog dosya = new OpenFileDialog();
            dosya.Filter = "Resim Dosyası |*.jpg;*.nef;*.png |  Tüm Dosyalar |*.*";
            dosya.ShowDialog();
            string dosyayolu = dosya.FileName;
            textBox1.Text = dosyayolu;
            pictureBox1.ImageLocation = dosyayolu;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        { //GÜNCELLE
            if (DialogResult.Yes == MessageBox.Show("İlgili kayıtlar güncellenecektir.İşlemi onaylıyor musunuz ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
            {
                baglanti = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=CihazEnvanter;Integrated Security=True");
                SqlCommand komut = new SqlCommand("UPDATE Cihaz set CihazPcAdi=@CihazPcAdi,CihazSeriNo=@CihazSeriNo,CihazModel=@CihazModel,CihazFaturaFoto=@CihazFaturaFoto,CihazGarantiBaslangic=@CihazGarantiBaslangic,CihazGarantiBitis=@CihazGarantiBitis,CihazAidiyet=@CihazAidiyet,CihazAlinanFirma=@CihazAlinanFirma,CihazFaturaTarih=@CihazFaturaTarih,CihazFaturaNo=@CihazFaturaNo where CihazId=@CihazId", baglanti);
                komut.Parameters.AddWithValue("@CihazId", textBox3.Text.ToString());
                komut.Parameters.AddWithValue("@CihazPcAdi", textBox14.Text);
                komut.Parameters.AddWithValue("@CihazAidiyet", comboBox1.Text);
                komut.Parameters.AddWithValue("@CihazAlinanFirma", textBox13.Text);
                komut.Parameters.AddWithValue("@CihazSeriNo", textBox10.Text.ToString());
                komut.Parameters.AddWithValue("@CihazModel", textBox9.Text);
                komut.Parameters.AddWithValue("@CihazFaturaFoto", textBox1.Text.ToString());
                komut.Parameters.AddWithValue("@CihazGarantiBaslangic", dateTimePicker1.Value);
                komut.Parameters.AddWithValue("@CihazGarantiBitis", dateTimePicker2.Value);
                komut.Parameters.AddWithValue("@CihazFaturaTarih", dateTimePicker3.Value);
                komut.Parameters.AddWithValue("@CihazFaturaNo", textBox2.Text.ToString());
                baglanti.Open();
                komut.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Güncelleme işlemi başarılı.");
                this.Close();
                AnaEkran ae = new AnaEkran();
                ae.Show();
                EnvanterGoruntule();
            }
            else
            {
                panel1.Visible = false;
                EnvanterGoruntule();
            }
                
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Kiralık")
            {
                textBox13.Visible = true;
            }
            else if (comboBox1.Text == "Bizim")
            {
                textBox13.Visible = false;
            }
        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if(comboBox2.Text=="Ad Soyad")
            {
                DataView dv = tablo.DefaultView;
                dv.RowFilter = "ÇalışanAdSoyad Like '" + txtSearch.Text + "%'";
                dataGridView1.DataSource = dv;
            }
            else if(comboBox2.Text== "Cihaz Pc Adı")
            {
                DataView dv = tablo.DefaultView;
                dv.RowFilter = "CihazPcAdi Like '" + txtSearch.Text + "%'";
                dataGridView1.DataSource = dv;
            }
            else if(comboBox2.Text== "Çalışan IYS Kodu")
            {
                DataView dv = tablo.DefaultView;
                dv.RowFilter = "Çalışan_Iys_Kodu Like '" + txtSearch.Text + "%'";
                dataGridView1.DataSource = dv;
            }
            else if (comboBox2.Text == "Bölüm")
            {
                DataView dv = tablo.DefaultView;
                dv.RowFilter = "Bölüm Like '" + txtSearch.Text + "%'";
                dataGridView1.DataSource = dv;
            }
            else if (comboBox2.Text == "Ünvan")
            {
                DataView dv = tablo.DefaultView;
                dv.RowFilter = "Unvan Like '" + txtSearch.Text + "%'";
                dataGridView1.DataSource = dv;
            }
            else if (comboBox2.Text == "Marka Adı")
            {
                DataView dv = tablo.DefaultView;
                dv.RowFilter = "CihazMarkaAdi Like '" + txtSearch.Text + "%'";
                dataGridView1.DataSource = dv;
            }
            else if (comboBox2.Text == "Model")
            {
                DataView dv = tablo.DefaultView;
                dv.RowFilter = "CihazModel Like '" + txtSearch.Text + "%'";
                dataGridView1.DataSource = dv;
            }
            else if (comboBox2.Text == "Seri No")
            {
                DataView dv = tablo.DefaultView;
                dv.RowFilter = "Seri_No Like '" + txtSearch.Text + "%'";
                dataGridView1.DataSource = dv;
            }
            else if (comboBox2.Text == "İşlemci")
            {
                DataView dv = tablo.DefaultView;
                dv.RowFilter = "İşlemci Like '" + txtSearch.Text + "%'";
                dataGridView1.DataSource = dv;
            }
            else if (comboBox2.Text == "İşlemci Markası")
            {
                DataView dv = tablo.DefaultView;
                dv.RowFilter = "İşlemci_Marka Like '" + txtSearch.Text + "%'";
                dataGridView1.DataSource = dv;
            }
            





        }
    }
 }




