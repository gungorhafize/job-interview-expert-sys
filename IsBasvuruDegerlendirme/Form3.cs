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
    public partial class Form3 : Form
    {
        MySqlConnection conn = new MySqlConnection("server=localhost;user id=root;database=isbasvurudb; sslmode=none");

        const int spacer = 1;
        public Form3()
        {
            InitializeComponent();
        }
        private ComboBox[] cmb;
        private Label[] lbl;
        private void Form3_Load(object sender, EventArgs e)
        {


               Content p;
               Content content = new Content();
                panel1.Controls.Add(content);
          

                if (panel1.Controls.Count < 3)
                {
                content.Location = new Point(0, 0);
                }

                else
                {
                    p = (Content)panel1.Controls[panel1.Controls.Count - 3];
                content.Location = new Point(0, p.Location.X + p.Height + spacer);
                }

                content.Width = panel1.Width;
                content.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top
                | System.Windows.Forms.AnchorStyles.Left));

     
       
        
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "select COUNT(KriterAdi) from tblkriter";
            conn.Open();
            int rows = Convert.ToInt32((cmd.ExecuteScalar()));
            

            cmd.CommandText = "select KriterAdi from tblkriter";
            cmd.ExecuteNonQuery();

            MySqlDataReader mdr = cmd.ExecuteReader();

            int i = 0;
            lbl = new Label[rows];
            cmb = new ComboBox[rows];
          

            while(mdr.Read())
            {

                lbl[i] = new Label();
                lbl[i].Location = new Point(70, 40 * i);
                lbl[i].Size = new Size(96, 20);
                lbl[i].BackColor = Color.Coral;
                lbl[i].Text = mdr["KriterAdi"].ToString();
                this.Controls.Add(lbl[i]);

                //cmb[i] = new ComboBox();
                //cmb[i].Location = new Point(180, 40 * i);
                //cmb[i].Size = new Size(75, 17);
                //cmb[i].DropDownStyle = ComboBoxStyle.DropDownList;
                //cmb[i].Items.Add(mdr.GetString("KriterAdi"));
                //this.Controls.Add(cmb[i]);



                cmd.Connection = conn;
               
                i++;

            }




            mdr.Close();
            conn.Close();
                


         
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
             int puan=0;
            
            if (true)
            {
                if (comboBox1.SelectedItem.ToString() =="1 YILDAN AZ")
                {
                    puan += 1;
                }
                else if (comboBox1.SelectedItem.ToString() == "1-2 YIL")
                {
                    puan = puan + 2;
                }
                else if (comboBox1.SelectedItem.ToString() == "3-2 YIL")
                {
                    puan = puan + 3;
                }
                else if (comboBox1.SelectedItem.ToString() == "3-5 YIL")
                {
                    puan = puan + 4;
                }
                else if (comboBox1.SelectedItem.ToString() == "5+ YIL")
                {
                    puan = puan + 5;
                }
            }
            if (comboBox2.SelectedItem.ToString() == "<2.00")
            {
                puan = puan + 1;
            }
            else if (comboBox2.SelectedItem.ToString() == "2.00-2.50")
            {
                puan = puan + 2;
            }
            else if (comboBox2.SelectedItem.ToString() == "2.50-3.00")
            {
                puan = puan + 3;
            }
            else if (comboBox2.SelectedItem.ToString() == "3.00-3.50")
            {
                puan = puan + 4;
            }
            else if (comboBox2.SelectedItem.ToString() == ">3.50")
            {
                puan = puan + 5;
            }

           else if (comboBox4.SelectedItem.ToString()== "OKUMAMIS")
            {
                puan = puan + 0;
            }

            else if (comboBox4.SelectedItem.ToString()== "İLKOKUL")
            {
                puan = puan + 1;
            }
            else if (comboBox4.SelectedItem.ToString() == "ORTAOKUL")
            {
                puan = puan + 2;
            }
            else if (comboBox4.SelectedItem.ToString() == "LİSE")
            {
                puan = puan + 3;
            }
            else if (comboBox4.SelectedItem.ToString() == "ÖNLİSANS")
            {
                puan = puan + 4;
            }
            else if (comboBox4.SelectedItem.ToString() == "LİSANS")
            {
                puan = puan + 5;
            }
            else if (comboBox4.SelectedItem.ToString() == "YÜKSEK LİSANS")
            {
                puan = puan + 6;
            }
            else if (comboBox4.SelectedItem.ToString() == "DOKTORA")
            {
                puan = puan + 7;
            }
            else if (comboBox4.SelectedItem.ToString() == "DOKTORA")
            {
                puan = puan + 7;
            }
            else if (comboBox7.SelectedItem.ToString() == "İNGİLİZCE")
            {
                puan = puan + 1;
            }
            if (checkBox1.Checked) //sigara
            {
                puan = puan - 1;
            }
            if(checkBox2.Checked) //alkol
            {
                puan = puan - 1;
            }
            if (checkBox3.Checked) // sicil kaydı var
            {
                puan = puan - 1;
            }
            if(checkBox4.Checked) // sicil kaydı yok
            {
                puan = puan + 1;
            }
            else if (comboBox7.SelectedItem.ToString() == "ALMANCA")
            {
                puan = puan + 1;

            }
            else if (comboBox7.SelectedItem.ToString() == "JAPONCA")
            {
                puan = puan + 2;
            }
            else if (comboBox7.SelectedItem.ToString() == "TÜRKÇE")
            {
                puan = puan + 0;
            }

            else if (comboBox6.SelectedItem.ToString() == "18-25")
            {
                puan = puan + 4;
            }
            else if (comboBox6.SelectedItem.ToString() == "25-35")
            {
                puan = puan + 4;
            }
            else if (comboBox6.SelectedItem.ToString() == "35-45")
            {
                puan = puan + 4;
            }
            else if (comboBox6.SelectedItem.ToString() == "45-55")
            {
                puan = puan + 4;
            }
            else if (comboBox6.SelectedItem.ToString() == "55-65")
            {
                puan = puan + 0;
            }
            else if (comboBox6.SelectedItem.ToString() == "65-75")
            {
                puan = puan - 1;
            }
            else if (comboBox6.SelectedItem.ToString() == "75-85")
            {
                puan = puan - 2;
            }

            if (checkBox8.Checked) //C#
            {
                puan = puan + 1;
            }

            if (checkBox9.Checked) //java
            {
                puan = puan + 1;
            }

            if (checkBox10.Checked) //python
            {
                puan = puan + 2;
            }

            if (checkBox11.Checked) //C++
            {
                puan = puan + 2;
            }

            if (checkBox12.Checked) //asssembly
            {
                puan = puan + 2;
            }

            if (checkBox13.Checked) //php
            {
                puan = puan + 1;
            }

            if (checkBox14.Checked) //js
            {
                puan = puan + 1;
            }

            if (checkBox15.Checked) //html-css
            {
                puan = puan + 1;
            }

            if (checkBox16.Checked) //ruby
            {
                puan = puan + 1;
            }

            if (checkBox17.Checked) //swift
            {
                puan = puan + 1;
            }



           
            label2.Text = puan.ToString();
            if (puan < 10)
            {
                MessageBox.Show("BAŞVURU SONUCUNUZ REDDEDİLDİ!", "BAŞVURU SONUÇ EKRANI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show("BAŞVURU SONUCUNUZ KABUL EDİLDİ!", "BAŞVURU SONUÇ EKRANI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
           
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}

