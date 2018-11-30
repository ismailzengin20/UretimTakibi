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

namespace UretimTakibi_SahaTablet
{
    public partial class bitirmeekranı : Form
    {
        SqlConnection baglan = new SqlConnection("Server=IBMSERVER;Database=URETIMTAKIBI;User ID = uretim; Password=Akcelik31;");
       
        public bitirmeekranı()
        {
            InitializeComponent();         
        }     
        public String personelkodu { get; set; }
        public String projekodu { get; set; }
        public String resim { get; set; }
        String projeismi,gorev;
        public String uzantı = ".jpg";

        private void bitirmeekranı_Load(object sender, EventArgs e)
        {
            pictureBox2.Image = Image.FromFile(@"\\IBMSERVER\AK Çelik Yazılımları\_Görseller\Uygulama\Üretim Takibi - Yönetim\Personeller\" + resim + "");
            try
            {
                baglan.Open();
                SqlCommand komut = baglan.CreateCommand();
                komut.CommandText = " select  p.isim as projeismi , gt.isim from ut_projeler as p inner join ut_projehareketleri as ph on p.projekodu = ph.projekodu inner join ut_gorevler as gt on gt.gorevkodu = ph.gorevkodu   where personelkodu = '"+ personelkodu.ToString() +"' and ph.durumu=1";
                SqlDataReader dr = komut.ExecuteReader();
                dr.Read();
                projeismi = dr["projeismi"].ToString();
                projeismi = projeismi.Remove(0, projeismi.IndexOf('-') + 2);
                gorev = dr["isim"].ToString();
                baglan.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("hata" + ex);
            }
            label5.Text = projeismi;
            label1.Text = "  projesindeki ";
            label6.Text=  gorev;
            label4.Text = " görevini sonlandırmak İstiyormusunuz ?";
            try
            {
                baglan.Open();
                SqlCommand komut = baglan.CreateCommand();
                komut.CommandText = "select isim,unvan,personelkodu from ut_personeller where personelkodu='" + personelkodu.ToString() + "'";
                SqlDataReader dr = komut.ExecuteReader();
                while (dr.Read())
                {
                    tb_isim.Text = dr["isim"].ToString();
                    tb_ünvan.Text = dr["unvan"].ToString();                 
                }
                baglan.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("hata" + ex);
            }
        }   
        private void b_HAYIR_Click(object sender, EventArgs e)
        {
            Genel.F_giriş = new Giriş();
            Genel.F_giriş.Show();
            this.Hide();
        }

        private void b_EVET_Click(object sender, EventArgs e)
        {          
            try
            {
                baglan.Open();
                SqlCommand komut = baglan.CreateCommand();
                komut.CommandText = "update ut_projehareketleri set  bitistarihi='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "' where personelkodu='" + personelkodu+"' and durumu=1" ;
                komut.ExecuteNonQuery();
                komut.CommandText = "UPDATE ut_projehareketleri " + 
                    "SET durumu = 0,sure = round((datediff(minute, prh.baslangictarihi, prh.bitistarihi) / 60.0), 2), " +
                    "maliyet = round( round((datediff(minute, prh.baslangictarihi, prh.bitistarihi) / 60.0), 2) * per.saatucreti,2) " +
                    "FROM ut_projehareketleri as prh " +
                    "INNER JOIN ut_personeller as per  ON prh.personelkodu = per.personelkodu " +
                    "where prh.personelkodu = '"+personelkodu+"' and prh.durumu = 1";
                komut.ExecuteNonQuery();
                baglan.Close();

                Genel.F_giriş = new Giriş();
                Genel.F_giriş.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("hata"+ex);
            }
        }    
    }
}
