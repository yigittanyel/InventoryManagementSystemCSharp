using DevExpress.XtraEditors;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace EnvanterProgramıDeneme
{
    public partial class Login : XtraForm
    {
        SqlConnection baglanti;
        SqlCommand komut;
        SqlDataReader dr;
        public Login()
        {
            InitializeComponent();
        }
        //ÇIKIŞ
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        //GİRİŞ
        private void simpleButton1_Click(object sender, EventArgs e)
        {         
            if (textBox2.Text == "" || textBox1.Text == "")
            {
                MessageBox.Show("Kullanıcı adı veya şifre eksik ", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            string sorgu = "SELECT * FROM KullanıcıLogin where KullanıcıUsername=@kadi AND KullanıcıSifre=@sifre";
            baglanti = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=CihazEnvanter;Integrated Security=True");
            komut = new SqlCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@kadi", textBox2.Text);
            komut.Parameters.AddWithValue("@sifre", textBox1.Text);
            baglanti.Open();
            dr = komut.ExecuteReader();
            if (dr.Read())
            {
                this.Hide();
                AnaEkran newPage = new AnaEkran();
                newPage.Show();
            }
            else if(textBox2.Text!="" && textBox1.Text != "") 
            {
                if (textBox1.Text != "@sifre") 
                {
                    textBox1.Text = "";
                    textBox2.Text = "";
                    MessageBox.Show("Kullanıcı adı veya şifre eksik ya da hatalı.Tekrar deneyin. ", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (textBox2.Text != "@kadi")
                {
                    textBox2.Text = "";
                    textBox1.Text = "";
                    MessageBox.Show("Kullanıcı adı eksik ya da hatalı.Tekrar deneyin. ", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    this.Hide();
                    Login tekrar = new Login();
                    tekrar.Show();
                }
            }
            baglanti.Close();
        }
        //ŞİFREYİ GİZLİ GÖSTERME
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            {
                if (checkBox1.Checked)
                {
                    //karakteri göster.
                    textBox1.PasswordChar = char.Parse("\0");
                }
                else
                {
                    textBox1.PasswordChar = '*';
                }
                
            }
        }
    }
}
