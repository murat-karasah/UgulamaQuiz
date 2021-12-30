using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UgulamaQuiz
{
    public partial class Form1 : Form
    {
        public Form1()
        {

            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
             


            int sayim = 1;
            for (int i = 1; i < 85; i++)
            {
                Button btn = new Button();
                btn.Width = btn.Height = 37;
                btn.Tag = i;

                for (int a = 3; a < 85; a=a+5)
                {
                    if (i==a)
                    {
                        btn.Tag = 0;
                        btn.Height = 0;
                        btn.Text = 0.ToString();

                    }
                  
                }

                
                btn.Padding = new Padding(0);
                flwPanel.Controls.Add(btn);
                btn.Click += btn_Click;

                if (btn.Height != 0)
                {
                    btn.Text = sayim.ToString();
                    btn.Tag = sayim;
                    sayim++;
                    if (sayim>54)
                    {
                        Label lblKapı2 = new Label();
                        lblKapı2.Width = 37;
                        lblKapı2.Height = 37;
                        lblKapı2.Padding = new Padding(0);

                        flwPanel.Controls.Add(lblKapı2);

                        Label lblKapı = new Label();
                        lblKapı.Width = 77;
                        lblKapı.Height = 37;
                        lblKapı.BorderStyle = BorderStyle.FixedSingle;
                        lblKapı.BackColor = Color.Cornsilk;
                        lblKapı.Text = "KAPI";
                        lblKapı.Padding = new Padding(0);
  
                        flwPanel.Controls.Add(lblKapı);
                        break;
                    }

                }

            }


            grbKisisel.Enabled = false;

            
        }

        private void btn_Click(object sender, EventArgs e)
        {
            Button basilan = sender as Button;
            int basilankoltuk=Convert.ToInt32(basilan.Tag);
            grbKisisel.Enabled = true;
            txtKoltuk.Text = basilankoltuk.ToString();
            

        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            string cinsiyet="";
            if (rdbBay.Checked)
            {
                 cinsiyet ="Erkek";
                foreach (Control item in flwPanel.Controls)
                {
                    if (item is Button)
                    {
                        if (item.Text == txtKoltuk.Text)
                        {
                            item.BackgroundImage = Image.FromFile("../../resimler/man.png");
                            item.BackgroundImageLayout = ImageLayout.Stretch;
                            item.Enabled = false;
                            break;
                        }
                    }

                }

                
            }
            else if(rdnBayan.Checked)
            {
                 cinsiyet ="Bayan";
                foreach (Control item in flwPanel.Controls)
                {
                    if (item is Button)
                    {
                        if (item.Text == txtKoltuk.Text)
                        {
                            item.BackgroundImage = Image.FromFile("../../resimler/woman.png");
                            item.BackgroundImageLayout = ImageLayout.Stretch;
                            item.Enabled = false;
                            break;
                        }
                    }

                }





            }
            else
            {
                MessageBox.Show("Lütfen Cinsiyet giriniz!");
            }



            string ad = txtAd.Text;
            string soyad = txtSoyad.Text;
            string tel = txtTelNo.Text;
            string numara = txtKoltuk.Text;

            if (ad == "" || soyad == "" || tel == "" || numara =="")
            {
                MessageBox.Show("Lütfen Bilgileri eksiksiz giriniz!");


            }
            else
            {
                lboxSatilankoltuklar.Items.Add($"{numara} nolu koltuk :{ad} {soyad} {cinsiyet} Tel no : {tel} ");

            }

            temizle();

        }

        private void temizle()
        {
            txtAd.Clear();
            txtSoyad.Clear();
            txtTelNo.Clear();
            txtKoltuk.Clear();
            grbKisisel.Enabled = false;
            rdbBay.Checked = false;
            rdnBayan.Checked = false;

        }
    }
}
