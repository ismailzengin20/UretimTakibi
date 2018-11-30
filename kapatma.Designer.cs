namespace UretimTakibi_SahaTablet
{
    partial class kapatma
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(kapatma));
            this.label2 = new System.Windows.Forms.Label();
            this.tb_kapat = new System.Windows.Forms.TextBox();
            this.b_iptal = new System.Windows.Forms.Button();
            this.b_cıkısyap = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 48F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(172, 156);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(973, 74);
            this.label2.TabIndex = 6;
            this.label2.Text = "Çıkış Yapmak İçin Şifre Giriniz ";
            // 
            // tb_kapat
            // 
            this.tb_kapat.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tb_kapat.Location = new System.Drawing.Point(449, 281);
            this.tb_kapat.Name = "tb_kapat";
            this.tb_kapat.PasswordChar = '*';
            this.tb_kapat.Size = new System.Drawing.Size(319, 38);
            this.tb_kapat.TabIndex = 7;
            this.tb_kapat.Enter += new System.EventHandler(this.tb_kapat_Enter);
            this.tb_kapat.Leave += new System.EventHandler(this.tb_kapat_Leave);
            // 
            // b_iptal
            // 
            this.b_iptal.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.b_iptal.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.b_iptal.Image = ((System.Drawing.Image)(resources.GetObject("b_iptal.Image")));
            this.b_iptal.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.b_iptal.Location = new System.Drawing.Point(449, 371);
            this.b_iptal.Name = "b_iptal";
            this.b_iptal.Size = new System.Drawing.Size(145, 64);
            this.b_iptal.TabIndex = 20;
            this.b_iptal.Text = "      İPTAL";
            this.b_iptal.UseVisualStyleBackColor = true;
            this.b_iptal.Click += new System.EventHandler(this.b_iptal_Click);
            // 
            // b_cıkısyap
            // 
            this.b_cıkısyap.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.b_cıkısyap.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.b_cıkısyap.Image = ((System.Drawing.Image)(resources.GetObject("b_cıkısyap.Image")));
            this.b_cıkısyap.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.b_cıkısyap.Location = new System.Drawing.Point(609, 371);
            this.b_cıkısyap.Name = "b_cıkısyap";
            this.b_cıkısyap.Size = new System.Drawing.Size(159, 64);
            this.b_cıkısyap.TabIndex = 19;
            this.b_cıkısyap.Text = "     ÇIKIŞ YAP";
            this.b_cıkısyap.UseVisualStyleBackColor = true;
            this.b_cıkısyap.Click += new System.EventHandler(this.b_cıkısyap_Click);
            // 
            // kapatma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SandyBrown;
            this.ClientSize = new System.Drawing.Size(1280, 788);
            this.ControlBox = false;
            this.Controls.Add(this.b_iptal);
            this.Controls.Add(this.b_cıkısyap);
            this.Controls.Add(this.tb_kapat);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "kapatma";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Üretim Takibi";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Shown += new System.EventHandler(this.kapatma_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_kapat;
        private System.Windows.Forms.Button b_iptal;
        private System.Windows.Forms.Button b_cıkısyap;
    }
}