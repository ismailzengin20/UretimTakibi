using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace UretimTakibi_SahaTablet
{
    public partial class kapatma : Form
    {
        bool acik = false;
        public kapatma()
        {
            InitializeComponent();
        }
        private void b_iptal_Click(object sender, EventArgs e)
        {
            Genel.F_giriş = new Giriş();
            Genel.F_giriş.Show();
            this.Hide();
            Process[] workers = Process.GetProcessesByName("osk");
            foreach (Process worker in workers)
            {
                worker.Kill();
                worker.WaitForExit();
                worker.Dispose();
            }
        }
        private void b_cıkısyap_Click(object sender, EventArgs e)
        {
            if (tb_kapat.Text == "saha123*")
            {
                Application.Exit();
                Process[] workers = Process.GetProcessesByName("osk");
                foreach (Process worker in workers)
                {
                    worker.Kill();
                    worker.WaitForExit();
                    worker.Dispose();
                }
            }
            else
                MessageBox.Show("Şifre Yanlış.Kontrol Edip Tekrar Deneyiniz.");
        } 
        private void tb_kapat_Enter(object sender, EventArgs e)
        {
            if (acik == true)
                Process.Start(Environment.SystemDirectory + @"\osk.exe");
        }
        private void kapatma_Shown(object sender, EventArgs e)
        {
            acik = true;
            b_cıkısyap.Focus();
            tb_kapat.Focus();
        }
        private void tb_kapat_Leave(object sender, EventArgs e)
        {            
        }
    }
}
