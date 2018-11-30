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
    public partial class Giriş : Form
    {
        SqlConnection baglan = new SqlConnection("");
        
        public Giriş()
        {
            InitializeComponent();
        }
        public static String personelkodu;
        public static String projekodu;     
        public static String resim;
        private void tb_kartkodu_KeyPress(object sender, KeyPressEventArgs e)
        {
          //  label2.Text = " ";
            if (tb_kartkodu.Text != "" && e.KeyChar == (Char)Keys.Enter)
            {
                try
                {
                    baglan.Open();
                    SqlCommand komut = baglan.CreateCommand();
                    komut.CommandText = "select  personelkodu,fotograf from ut_personeller where kartkodu='" + tb_kartkodu.Text + "' and durumu=1";
                    SqlDataReader dr = komut.ExecuteReader();
                    if (dr.HasRows)
                    {
                        dr.Read();
                      
                            resim = dr["fotograf"].ToString();
                            personelkodu = dr["personelkodu"].ToString();
                            label2.Text = "kayıt var";
                            dr.Close();
                            komut.CommandText = "select ph.projekodu,ph.durumu as phdurumu from ut_personeller as per left join ut_projehareketleri as ph on  per.personelkodu=ph.personelkodu  where per.kartkodu='" + tb_kartkodu.Text + "'  order by ph.durumu desc";
                            dr = komut.ExecuteReader();
                            dr.Read();
                            projekodu = dr["projekodu"].ToString();
                            if (dr["phdurumu"].ToString() == "0" || dr["phdurumu"].ToString().Equals(""))
                            {
                                baglan.Close();
                                Genel.F_projesecimi = new projesecimi();
                                Genel.F_projesecimi.kartkodu = tb_kartkodu.Text;
                                Genel.F_projesecimi.resim = resim;
                                Genel.F_projesecimi.Show();
                                this.Hide();
                                tb_kartkodu.Text = "";
                            }
                            else
                            {
                                baglan.Close();
                                Genel.F_bitirmeekranı = new bitirmeekranı();
                                Genel.F_bitirmeekranı.personelkodu = personelkodu;
                                Genel.F_bitirmeekranı.projekodu = projekodu;
                                Genel.F_bitirmeekranı.resim = resim;
                                Genel.F_bitirmeekranı.Show();                              
                               this.Hide();
                                tb_kartkodu.Text = "";
                            }
                        
                    }
                    else
                    {
                        label2.Text = "    !!! KAYIT  YOK  !!! ";
                        label3.Text = "KAYIT YAPTIRIP TEKRAR  DENEYİNİZ";
                        tb_kartkodu.Text = "";
                        baglan.Close();
                    }
                }
                catch (Exception ex)
                {                   
                   MessageBox.Show("hata:" + ex);
                }
            }
                     
        }

        private void bkapat_Click(object sender, EventArgs e)
        {
            Genel.F_kapatma = new kapatma();
            Genel.F_kapatma.Show();
            this.Hide();

        }

    }  
}
