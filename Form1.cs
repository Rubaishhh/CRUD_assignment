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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CRUD_Application
{
    public partial class Form1 : Form
    {
        string id;

        public Form1()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        SqlConnection con = new SqlConnection("Data Source=NEMESIS\\SQLEXPRESS;Initial Catalog=CRUD_app;Integrated Security=True;Encrypt=False");
        private void button3_Click(object sender, EventArgs e)
        {
            //input validation
            if (string.IsNullOrWhiteSpace(txt_pass.Text) ||
                string.IsNullOrWhiteSpace(txt_uname.Text) ||
                cmb_gen.SelectedItem == null)
            {
                //Show error message if any field is empty or gender is not selected
                MessageBox.Show("Please fill in all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                con.Open();

                
                SqlCommand cmd = new SqlCommand(
                    "INSERT INTO user_info (name, password, userid, gender) VALUES ('"
                    + txt_name.Text + "', '"
                    + txt_pass.Text + "', '"
                    + txt_uname.Text + "', '"
                    + cmb_gen.SelectedItem.ToString() + "')", con);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Registration successful!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                //Ensure the connection is closed
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }

            // refresh data
            BindData();
        }

        void BindData()
        {

            SqlCommand cmd = new SqlCommand("select * from user_info", con);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            dataAdapter.Fill(dt);
            if(dt.Rows.Count > 0 )
                dataGridView1.DataSource = dt;

        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            BindData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("update user_info set name = '"+ txt_name.Text + "',password = '" + txt_pass.Text + "',userid = '" + txt_uname.Text + "',gender = '" + cmb_gen.SelectedItem.ToString() + "' where userid = '" + id + "'", con);
            cmd.ExecuteNonQuery();
            con.Close();
            BindData();
            MessageBox.Show("Successfully updated!!!");
            
            }

        private void button1_Click(object sender, EventArgs e)
        {

            txt_name.Text = "";
            txt_pass.Text = "";
            txt_uname.Text = "";
            cmb_gen.SelectedIndex = 0;

        }

        private void button4_Click(object sender, EventArgs e)
        {
           

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }
        
        private void button3_Click_1(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("delete from user_info where userid = '"+id+"'",con);
            cmd.ExecuteNonQuery();
            BindData();
            txt_name.Text = "";
            txt_pass.Text = "";
            txt_uname.Text = "";
            MessageBox.Show("User Deleted!!");
            con.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void txt_uname_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                dataGridView1.CurrentRow.Selected = true;
                txt_name.Text = dataGridView1.Rows[e.RowIndex].Cells["name"].Value.ToString();
                txt_pass.Text = dataGridView1.Rows[e.RowIndex].Cells["password"].Value.ToString();
                txt_uname.Text = dataGridView1.Rows[e.RowIndex].Cells["userid"].Value.ToString();
                cmb_gen.Text = dataGridView1.Rows[e.RowIndex].Cells["gender"].Value.ToString();
                id = dataGridView1.Rows[e.RowIndex].Cells["userid"].Value.ToString();
            }

        }
    }
}
