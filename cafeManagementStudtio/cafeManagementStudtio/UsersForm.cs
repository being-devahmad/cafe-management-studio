using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms; 

namespace cafeManagementStudtio
{
    public partial class UsersForm : Form
    {
        public UsersForm()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-5E3ATDF;Initial Catalog=cafeDb;Integrated Security=True");
        private void button1_Click(object sender, EventArgs e)
        {
            UserOrder uorder = new UserOrder();
            uorder.Show();
            this.Hide();
        }
        private void populateDgv()
        {
           try
            {
                con.Open();
                string query = "select * from UsersTb1  ";
                SqlDataAdapter sda = new SqlDataAdapter(query, con);
                SqlCommandBuilder builder = new SqlCommandBuilder(sda);
                var ds = new DataSet();
                sda.Fill(ds);
                userGridView.DataSource = ds.Tables[0];

                con.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            itemsForm item = new itemsForm();
            item.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 login = new Form1();
            login.Show();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void addUsers()
        {
            try
            {
                con.Open();
                string query = "insert into UsersTb1 values ('" + usernameTb.Text + "' , '" + uphoneTb.Text + "' , '" + upassTb.Text + "')";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("User Sucessfully Created");

                usernameTb.Clear();
                uphoneTb.Clear();
                upassTb.Clear();

                con.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            addUsers();
            populateDgv();
        }

        private void usernameTb_TextChanged(object sender, EventArgs e)
        {

        }

        private void UsersForm_Load(object sender, EventArgs e)
        {
            populateDgv();
        }

        private void userGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
        private void deleteData()
        {
           try
            {
                if (uphoneTb.Text == "")
                {
                    MessageBox.Show("Select the user to be deleted ");
                }
                else
                {
                    
                        con.Open();
                        SqlCommand cmd = new SqlCommand("DELETE  from UsersTb1 WHERE Upassword = '" + upassTb.Text+"'", con);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("User succesfully deleted");
                        con.Close();

                    }
                    
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void button6_Click(object sender, EventArgs e)
        {
            deleteData();
            populateDgv();
        }
        private void editItems()
        {
            try
            {
                if (uphoneTb.Text == "" || upassTb.Text == "" || usernameTb.Text == "")
                {
                    MessageBox.Show("Fill all fields first");
                }
                else
                {
                        con.Open();
                        string query = "UPDATE UsersTb1 set Uname = @username, Uphone = @Uphone where  Upassword =@Upassword ";
                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@username", usernameTb.Text);
                        cmd.Parameters.AddWithValue("@Upassword", upassTb.Text);
                        cmd.Parameters.AddWithValue("@Uphone", uphoneTb.Text);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Item succesfully updated");
                        con.Close();
                        populateDgv();

                    }
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            editItems();
            populateDgv();
        }

        private void userGridView_Click(object sender, EventArgs e)
        {
            usernameTb.Text = userGridView.SelectedRows[0].Cells[0].Value.ToString();
            uphoneTb.Text = userGridView.SelectedRows[0].Cells[1].Value.ToString();
            upassTb.Text = userGridView.SelectedRows[0].Cells[2].Value.ToString();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Click(object sender, EventArgs e)
        {
            
        }
    }
}