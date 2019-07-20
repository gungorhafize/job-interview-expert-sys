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
    public partial class Form2 : Form
    {

        MySqlConnection con = new MySqlConnection("server=localhost;user id=root; Database=isbasvurudb; sslmode=none");

        public Form2()
        {

            InitializeComponent();
        }
        public void RefreshingGrid()
        {
            string selectQuery = "select tblkriter.kriterID, tblkriter.KriterAdi, tbldetay.Detay, tbldetay.EtkiYuzdesi from tbldetay inner join tblkriter on tblkriter.kriterID = tbldetay.kriterID";
            DataTable table = new DataTable();
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter(selectQuery, con);
            dataAdapter.Fill(table);
            dataGridView1.DataSource = table;

        }
        public void RefreshingCombo()
        {
            string selectQuery = "select * from isbasvurudb.tblkriter";
            con.Open();
            MySqlCommand command = new MySqlCommand(selectQuery, con);
            MySqlDataReader dr = command.ExecuteReader();
            while (dr.Read())
            {
                if(comboBox1.Items.Contains("kriterID"))
                {
                    continue;
                }
                else
                {
                    comboBox1.Items.Add(dr.GetString("kriterID"));
                }
               
                
            }


        }
        public void Clear()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            RefreshingGrid();
            RefreshingCombo();
            con.Close();



        }
        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            textBox3.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
        }



        private void button2_Click_1(object sender, EventArgs e)
        {

            con.Open();
            MySqlCommand cmd = con.CreateCommand();
            MySqlTransaction transaction;
            transaction = con.BeginTransaction();
            cmd.Connection = con;
            cmd.Transaction = transaction;
            con.Close();

            try
            {
                
                con.Open();
                cmd.CommandText = "delete from tblkriter where tblkriter.kriterID= '" + this.textBox3.Text + "'";
                cmd.ExecuteNonQuery();
                transaction.Commit();
                Clear();
                RefreshingGrid();
                con.Close();
                RefreshingCombo();
                con.Close();

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            con.Open();
            MySqlCommand cmd = con.CreateCommand();
            MySqlTransaction transaction;
            transaction = con.BeginTransaction();
            cmd.Connection = con;
            cmd.Transaction = transaction;
            con.Close();

            try
            {
                con.Open();
                cmd.CommandText = "insert into tblkriter(KriterAdi) values('" + textBox1.Text + "'); select last_insert_id()";
                int id = Convert.ToInt32(cmd.ExecuteScalar());
                cmd.CommandText = "insert into tbldetay(kriterID, Detay, EtkiYuzdesi) values(" + id + " , '" + textBox2.Text + "','" + textBox6.Text + "')";
                cmd.ExecuteNonQuery();
                transaction.Commit();
                Clear();
                RefreshingGrid();
                con.Close();
                RefreshingCombo();
                con.Close();



            }
            catch (Exception)
            {

                throw;
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {

            Form3 f3 = new Form3();
            f3.Show();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            con.Open();
            MySqlCommand cmd = con.CreateCommand();
            cmd.Connection = con;
        
            cmd.CommandText = "insert into tbldetay(kriterID, Detay, EtkiYuzdesi) values(" + comboBox1.SelectedItem + " , '" + textBox4.Text + "','" + textBox5.Text+ "')";
            cmd.ExecuteNonQuery();
            Clear();
            RefreshingGrid();
            con.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4();
            f4.Show();
        }
    }
}
