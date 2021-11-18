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
    public partial class VeriEkrani : Form
    {
        SqlConnection baglanti;
        SqlDataAdapter da;
        public VeriEkrani()
        {
            InitializeComponent();
        }

        private void labelControl1_Click(object sender, EventArgs e)
        {

        }
        void Listele()
        {
            baglanti = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=CihazEnvanter;Integrated Security=True");
            baglanti.Open();
            da = new SqlDataAdapter(@"Select Ci.CihazPcAdi,ISNULL(ca.CalisanIysKod,'--') as 'Çalışan Iys Kodu',Ca.CalisanBolum as 'Bölüm',Ca.CalisanAdSoyad as 'Çalışan Adı-Soyadı',Ca.CalisanUnvan as 'Unvan',Cm.CihazMarkaAdi,Ci.CihazModel,Ci.CihazSeriNo as 'Seri No',Cisl.CihazİslemciAdi as 'İşlemci',Cisl.CihazİslemciMarkasi as 'İşlemci Markası',ct.CihazTipiAdi as 'Cihaz Tipi',Ctur.CihazTuru as 'Cihaz Türü',Cr.CihazRamGb as 'Ram',cd.CihazDiskTuru as 'Disk Türü',Cd.CihazDiskGb as 'Disk GB',Ctur.CihazTuru as 'Cihaz Türü',Cekr.CihazEkranModel as 'Ekran Modeli',Cekr.CihazEkranBoyut as 'Ekran Boyutu',Ci.CihazAidiyet as 'Kiralık/Bizim',ISNULL(Ci.CihazAlinanFirma,'-') as 'Cihazın Alındığı Firma',Ci.CihazGarantiBaslangic as 'Garanti Başlangıç',Ci.CihazGarantiBitis as 'Garanti Bitiş',Ci.CihazFaturaTarih as 'Fatura Tarihi',Ci.CihazFaturaNo as 'Fatura No',Ci.CihazFaturaFoto as 'Fatura Fotoğraf'                        
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
            gridControl1.DataSource = tablo;
            baglanti.Close();
        }
        private void VeriEkrani_Load(object sender, EventArgs e)
        {
            Listele();
        }
    }
}
