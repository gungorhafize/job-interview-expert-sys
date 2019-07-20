using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace IsBasvuruDegerlendirme
{
    public partial class Form1 : Form
    {
        MySqlConnection con = new MySqlConnection("server=localhost;user id=root;database=isbasvurudb; sslmode=none");

        public Form1()
        {
            InitializeComponent();
            InitialData();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void InitialData()
        {
            if (Properties.Settings.Default.u_name != string.Empty)
            {
                if (Properties.Settings.Default.remember == "yes")
                {

                    textBox1.Text = Properties.Settings.Default.u_name;
                    textBox2.Text = Properties.Settings.Default.password;
                    checkBox1.Checked = true;
                }
                else
                {
                    textBox1.Text = Properties.Settings.Default.u_name;
                }
            }
        }

        private void SaveData()
        {
            if (checkBox1.Checked)
            {
                Properties.Settings.Default.u_name = textBox1.Text;
                Properties.Settings.Default.password = textBox2.Text;
                Properties.Settings.Default.remember = "yes";
                Properties.Settings.Default.Save();
            }

            else
            {
                Properties.Settings.Default.u_name = textBox1.Text;
                Properties.Settings.Default.password = null;
                Properties.Settings.Default.remember = "no";
                Properties.Settings.Default.Save();
            }
        }


        private void BtnGiris_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select * from tbladmin where userName='" + textBox1.Text + "' and password='" + textBox2.Text + "'", con);
                MySqlDataReader mdr = cmd.ExecuteReader();
                while (mdr.Read())
                {
                    MessageBox.Show("Sisteme giriş yaptınız!", "HOŞGELDİNİZ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    SaveData();
                    this.Hide();
                    Form2 f = new Form2();
                    f.Show();
                }
                mdr.Close();
                con.Close();
                label3.Text = "Eksik veya hatalı giriş yaptınız...\nLütfen giriş bilgilerini kontrol ediniz!";

            }
            catch (Exception)
            {
                MessageBox.Show("Bir hata oluştu!");
            }
        }


    }
}
