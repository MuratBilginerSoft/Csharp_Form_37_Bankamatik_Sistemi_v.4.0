using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Bankamatik_Sistemi
{
    public partial class Form1 : Form
    {
        #region Değişkenler
        string yol = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=İşBankası.accdb";
        string sorgu;
        OleDbConnection bağlantı;
        OleDbCommand komut;
        OleDbDataAdapter kayıt;
        DataTable tablo;
        int t;

        int para;

        #endregion

        #region Metodlar

        public void parayıver(int x)

        {
            parasayısı[0] = x / 200;
            x = x % 200;
            parasayısı[1] = x / 100;
            x = x % 100;
            parasayısı[2] = x / 50;
            x = x % 50;
            parasayısı[3] = x / 20;
            x = x % 20;
            parasayısı[4] = x / 10;
            x = x % 10;
            parasayısı[5] = x / 5;
            x = x % 5;

            if (x!=0)
            {
                MessageBox.Show("Şu anda bankamatikte bu işleminizi gerçekleştirecek banknot bulunmamaktadır","Bilgilendirme",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }

            else
            {
                groupBox1.Visible = true;
                label7.Text = parasayısı[0].ToString() + " Adet";
                label6.Text = parasayısı[1].ToString() + " Adet";
                label5.Text = parasayısı[2].ToString() + " Adet";
                label4.Text = parasayısı[3].ToString() + " Adet";
                label3.Text = parasayısı[4].ToString() + " Adet";
                label2.Text = parasayısı[5].ToString() + " Adet";
            }
        }

        public void bağlan()
        {

            try
            {
                bağlantı = new OleDbConnection(yol);
            }
            catch (OleDbException ex)
            {

                MessageBox.Show(" " + ex, "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        
        
        }

        public void kişibilgileri()
        {
            sorgu = "Select * from Kişiler";
            komut = new OleDbCommand(sorgu,bağlantı);
            kayıt = new OleDbDataAdapter(komut);
            tablo = new DataTable();

            bağlantı.Open();
            kayıt.Fill(tablo);
            bağlantı.Close();
        
        }

        public void butondurumu()
        {
            if (para>=200)
            {
                button1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;
                button4.Enabled = true;
                button5.Enabled = true;
                button6.Enabled = true;
            }

            else if (para>=100)
            {
                button1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;
                button4.Enabled = true;
                button5.Enabled = true;
            }

            else if (para>=50)
            {
                button1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;
                button4.Enabled = true;
            }

            else if (para>=20)
            {
                button1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;
            }
            else if (para>=10)
            {
                button1.Enabled = true;
                button2.Enabled = true;
            }

            else if (para>=5)
            {
                button1.Enabled = true;
            }
        }

        public void butonfalse()
        {
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
            button6.Enabled = false;
        
        
        }
        

        #endregion

       

        #region Tanımlamalar

        int[] parasayısı=new int[6];

        #endregion
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            butonfalse();
            bağlan();
            kişibilgileri();
            t = Giriş.i;
            para = Convert.ToInt32(tablo.Rows[t]["Karttaki_Miktar"]);
            label11.Text = tablo.Rows[t]["Karttaki_Miktar"].ToString()+" TL";
            label13.Text = tablo.Rows[t]["Son_Islem"].ToString().Substring(0, 9);
            timer1.Start();
            groupBox1.Visible = false;
            label9.Text = Giriş.ad + " " + Giriş.soyad;
            butondurumu();


        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label15.Text = DateTime.Now.ToLongTimeString();
            label14.Text = DateTime.Now.ToLongDateString();
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            try
            {
                para = Convert.ToInt32(textBox1.Text);

                parayıver(para);
            }
            catch (Exception)
            {

                MessageBox.Show("Lütfen Geçerli Bir Değer Giriniz", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            parayıver(int.Parse(button1.Text.Substring(0, 1)));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            parayıver(int.Parse(button2.Text.Substring(0, 2)));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            parayıver(int.Parse(button3.Text.Substring(0, 2)));
        }

        private void button4_Click(object sender, EventArgs e)
        {
            parayıver(int.Parse(button4.Text.Substring(0, 3)));
        }

        private void button5_Click(object sender, EventArgs e)
        {
            parayıver(int.Parse(button5.Text.Substring(0, 3)));
        }

        private void button6_Click(object sender, EventArgs e)
        {
            parayıver(int.Parse(button6.Text.Substring(0, 2)));
        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {

        }
    }
}
