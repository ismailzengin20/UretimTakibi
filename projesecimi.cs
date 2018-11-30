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
   
    public partial class projesecimi : Form
    {
        SqlConnection baglan = new SqlConnection("");
 
        public projesecimi()
        {
            InitializeComponent();
          
        }
        public String kartkodu { get; set; }
        public String personelkodu;
        public String projekoduu="";
        public String resim="";
        public String projeadı = "";

        private void projesecimi_Load(object sender, EventArgs e)
        {
            label1.Text = "Proje Seç";
            dataGridView2.Visible = false;
            bprojesec.Visible = false;
            pictureBox2.Image = Image.FromFile(
                @"\\IBMSERVER\AK Çelik Yazılımları\_Görseller\Uygulama\Üretim Takibi - Yönetim\Personeller\" + resim+"");
        //    pictureBox2.Image = Image.FromFile("C:\\Users\\ismail\\Desktop\\"+resim+uzantı+"");
            dataGridView1.Columns[0].HeaderCell.Style.Font = new Font("Tahoma", 16F, FontStyle.Bold);        
            dataGridView1.Columns[1].HeaderCell.Style.Font = new Font("Tahoma", 15F, FontStyle.Bold);
            dataGridView1.ColumnHeadersHeight = 35;
            dataGridView2.Columns[0].HeaderCell.Style.Font = new Font("Tahoma", 13F, FontStyle.Bold);
            dataGridView2.Columns[1].HeaderCell.Style.Font = new Font("Tahoma", 14F, FontStyle.Bold);
            dataGridView2.ColumnHeadersHeight = 35;
            this.dataGridView1.DefaultCellStyle.Font = new Font("Tahoma", 18, FontStyle.Bold);
            this.dataGridView2.DefaultCellStyle.Font = new Font("Tahoma", 18, FontStyle.Bold);
            proje_listele();
            lisim.Text = kartkodu.ToString();
            try
            {
                baglan.Open();
                SqlCommand komut = baglan.CreateCommand();
                komut.CommandText = "select isim,unvan,personelkodu from ut_personeller where kartkodu='" + kartkodu.ToString()+"'";
                SqlDataReader dr = komut.ExecuteReader();
                while (dr.Read())
                {
                    lisim.Text = dr["isim"].ToString();
                    lunvan.Text = dr["unvan"].ToString();
                    personelkodu = dr["personelkodu"].ToString();
                }
                baglan.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("hata" + ex);
            }
        }      
        public void proje_listele()
        {         
            try
            {
                baglan.Open();
                SqlCommand komut = baglan.CreateCommand();
                komut.CommandText = "select projekodu,isim from ut_projeler where durumu=1";
                SqlDataReader dr = komut.ExecuteReader();
                String projeismi = "";
                    while (dr.Read())
                    {
                    projeismi = dr["isim"].ToString();
                    projeismi = projeismi.Remove(0, projeismi.IndexOf('-')+2);
                        dataGridView1.Rows.Add(dr["projekodu"], projeismi );
                    }                            
                baglan.Close();
                dataGridView1.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("hata"+ex);
            }
        }
        private void tb_gorevadı_TextChanged(object sender, EventArgs e)
        {
            if (tb_gorevadı.Text.Length > 0)
                b_basla.Visible = true;
            else
                b_basla.Visible = false;
        }
        private void b_iptal_Click(object sender, EventArgs e)
        {
            Genel.F_giriş = new Giriş();
            Genel.F_giriş.Show();
            this.Hide();
        }
        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {  
            tb_gorevadı.Text = "";
            tb_gorevkodu.Text = "";
            label5.Text = "";
            tb_projekodu.Text = "";
            if (e.RowIndex>=0){
            label1.Text = "Görev Seç";
            dataGridView2.Visible = true;
                bprojesec.Visible = true;
                dataGridView1.Visible = false;
            var item = dataGridView1.Rows[e.RowIndex].Cells[1].Value;
            var item1 = dataGridView1.Rows[e.RowIndex].Cells[0].Value;
            projeadı = item.ToString();
            projekoduu = item1.ToString();
            if (projeadı.Length > 0 && projekoduu.Length > 0)
            {
                    tb_projekodu.Text = projekoduu;
                    label5.Text = projeadı;
                try
                 {
                    dataGridView2.Rows.Clear();
                     baglan.Open();
                     SqlCommand komut = baglan.CreateCommand();

                     komut.CommandText = "select  ut_gorevler.gorevkodu, isim  from  ut_projegorevtanimlamalari left join ut_gorevler on ut_gorevler.gorevkodu = ut_projegorevtanimlamalari.gorevkodu  left join  ut_personelgorevtanimlari on ut_personelgorevtanimlari.gorevkodu = ut_gorevler.gorevkodu where projekodu = '"+tb_projekodu.Text+"' and personelkodu = '"+personelkodu.ToString()+"'";
                     SqlDataReader dr = komut.ExecuteReader();
                     while (dr.Read())
                     {
                         dataGridView2.Rows.Add(dr["gorevkodu"],dr["isim"]);
                     }
                     baglan.Close();
                        dataGridView2.ClearSelection();
                    }
                 catch (Exception ex)
                 {
                     MessageBox.Show("hata" + ex);
                 }
            }
            }
        }
        private void dataGridView2_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var item = dataGridView2.Rows[e.RowIndex].Cells[1].Value;
                var item1 = dataGridView2.Rows[e.RowIndex].Cells[0].Value;

                label5.Text = projeadı;
                tb_projekodu.Text = projekoduu;
                tb_gorevadı.Text = item.ToString();
                tb_gorevkodu.Text = item1.ToString();
            }
        }
        private void b_basla_Click(object sender, EventArgs e)
        {
            if (lisim.Text.Length > 0 && tb_gorevadı.Text.Length > 0 && tb_gorevkodu.Text.Length > 0 && lunvan.Text.Length > 0 && label5.Text.Length > 0 && tb_projekodu.Text.Length > 0)
            {
                try
                {
                    baglan.Open();
                    SqlCommand komut = baglan.CreateCommand();
                    komut.CommandText = "select durumu from  ut_projehareketleri  where personelkodu='"+personelkodu.ToString()+"' order by durumu desc";
                    SqlDataReader dr = komut.ExecuteReader();
                    if (dr.HasRows)
                    {
                        dr.Read();
                        if (dr["durumu"].ToString() != "1")
                        {
                            dr.Close();
                            komut.CommandText = "INSERT INTO ut_projehareketleri VALUES(@projekodu,@personelkodu,@gorevkodu,@baslangictarihi,@bitistarihi,@sure,@maliyet,@durumu)";
                            komut.Parameters.Add("@projekodu", tb_projekodu.Text);
                            komut.Parameters.Add("@personelkodu", personelkodu.ToString());
                            komut.Parameters.Add("@gorevkodu", tb_gorevkodu.Text);
                            komut.Parameters.Add("@baslangictarihi", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                            komut.Parameters.Add("@bitistarihi", DBNull.Value);
                            komut.Parameters.AddWithValue("@durumu", 1);
                            komut.Parameters.AddWithValue("@sure", 0.0);
                            komut.Parameters.AddWithValue("@maliyet",0.0);
                            komut.ExecuteNonQuery();
                            baglan.Close();                           
                            Genel.F_bilgiekranı = new bilgiekranı();
                            Genel.F_bilgiekranı.Show();
                            Genel.F_bilgiekranı.label2.Text = (label5.Text.Length > 27 ? label5.Text.Remove(27) + "..." : label5.Text);
                            Genel.F_bilgiekranı.label4.Text = tb_gorevadı.Text;
                            this.Close();
                            
                        }
                        else
                        {
                            baglan.Close();
                            MessageBox.Show("Şuan görevlisin");
                            Genel.F_giriş = new Giriş();
                            Genel.F_giriş.Show();
                            this.Close();

                        }
                    }
                    else {
                        dr.Close();
                        komut.CommandText = "INSERT INTO ut_projehareketleri VALUES(@projekodu,@personelkodu,@gorevkodu,@baslangictarihi,@bitistarihi,@sure,@maliyet,@durumu)";
                        komut.Parameters.Add("@projekodu", tb_projekodu.Text);
                        komut.Parameters.Add("@personelkodu", personelkodu.ToString());
                        komut.Parameters.Add("@gorevkodu", tb_gorevkodu.Text);
                        komut.Parameters.Add("@baslangictarihi", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        komut.Parameters.Add("@bitistarihi", DBNull.Value);
                        komut.Parameters.AddWithValue("@durumu", 1);
                        komut.Parameters.AddWithValue("@maliyet", 0.0);
                        komut.Parameters.AddWithValue("@sure", 0.0);
                        komut.ExecuteNonQuery();
                        baglan.Close();
                        Genel.F_bilgiekranı = new bilgiekranı();
                        Genel.F_bilgiekranı.Show();
                        Genel.F_bilgiekranı.label2.Text = (label5.Text.Length > 27 ? label5.Text.Remove(27) + "..." : label5.Text);
                        Genel.F_bilgiekranı.label4.Text = tb_gorevadı.Text;
                        this.Close();
                    }

                }
                catch(Exception ex)
                {
                    MessageBox.Show("hata:"+ex);
                }
            }
            
            else
            {
                MessageBox.Show("tekrar dene ");
            }
        }

        private void bprojesec_Click(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
            dataGridView1.Visible = true;
            bprojesec.Visible = false;
            dataGridView2.Visible = false;
            label1.Text = "Proje Seç";
            tb_gorevadı.Text = "";
            tb_gorevkodu.Text = "";
            label5.Text = "";
            tb_projekodu.Text = "";
        }

        private void dataGridView2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
               e.Handled=true;
        }

    }
}
