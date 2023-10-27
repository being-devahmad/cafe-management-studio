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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-5E3ATDF;Initial Catalog=cafeDb;Integrated Security=True");
        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            /*this.Hide();
            GuestOrder guest = new GuestOrder();
            guest.Show();*/
        }
        private void loginBtn()
        {
            if (usernameTb.Text == "" || passwordTb.Text == "")
            {
                MessageBox.Show("Enter a username or password");
            }
            else
            {
                    con.Open();
                    SqlDataAdapter sda = new SqlDataAdapter("select count(*) from UsersTb1 where Uname = '" + usernameTb.Text + "' and Upassword = '" + passwordTb.Text + "'", con);
                    DataTable DT = new DataTable();
                    sda.Fill(DT);
                    if (DT.Rows[0][0].ToString() == "1")
                    {
                        UserOrder uorder = new UserOrder();
                        uorder.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Wrong Username or password");
                    }
                    con.Close();
                
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            
            loginBtn();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
