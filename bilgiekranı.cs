using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UretimTakibi_SahaTablet
{
    public partial class bilgiekranı : Form
    {
        public bilgiekranı()
        {
            InitializeComponent();

        }
       int sayac = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
           
            if (sayac<4000)
            {
                Genel.F_giriş = new Giriş();
                Genel.F_giriş.Show();
                this.Close();
            }
            sayac++;
        }

        private void bilgiekranı_Load(object sender, EventArgs e)
        {
            timer1.Interval = 4000;
               timer1.Start();
              
        }
    }
}
