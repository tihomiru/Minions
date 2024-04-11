using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Minioni
{
    public partial class Form1 : Form
    {
        //1
        string connectionString = "server=10.42.42.64;port=3306;user=PC1;password=1111;database=minions";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //2
            MySqlConnection dbMinions = new MySqlConnection(connectionString);
            dbMinions.Open();
            MessageBox.Show("connection is open now");
            //4
            MySqlCommand com = new MySqlCommand("select * from towns", dbMinions);
            //5
            MySqlDataReader reader = com.ExecuteReader();
            //6
            List<ComboItem> iteams = new List<ComboItem>();
            while (reader.Read())
            {
                ComboItem item = new ComboItem();
                item.ID = (int)reader[0];
                item.Name = (string)reader[1];
                iteams.Add(item);

            }
            reader.Close();

            comboBox1.DataSource = iteams;
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "Id";

            dbMinions.Close();

        }

        private void btn_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"ti vuvede minion s {textBox1.Text} ID na ime {textBox2.Text} koito e na {textBox3.Text} ot {comboBox1.Text} ---> {comboBox1.SelectedValue}");


            string insertSQL = "ISERT INTO ,minions.minions" +
                "(id,`name`,age,town_id)" +
                $"VALUES (108,@townName,@age,@Town_id)";
            com.Parameters.AddWithValue("@townName",  insertSQL);

        }
    }
}
