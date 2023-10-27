using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace cafeManagementStudtio
{
    public partial class UserOrder : Form
    {
        public UserOrder()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-5E3ATDF;Initial Catalog=cafeDb;Integrated Security=True");

        private void label6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 login = new Form1();
            login.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            itemsForm item = new itemsForm();
            item.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            UsersForm user = new UsersForm();
            user.Show();
        }
        private void populateDgv()
        {
            try
            {
                con.Open();
                string query = "select * from ItemTbl  ";
                SqlDataAdapter sda = new SqlDataAdapter(query, con);
                SqlCommandBuilder builder = new SqlCommandBuilder(sda);
                var ds = new DataSet();
                sda.Fill(ds);
                itemsGridView.DataSource = ds.Tables[0];

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        int num = 0;
        int price, total;
        string item, cat;

        private void button4_Click(object sender, EventArgs e)
        {
            if (QtyTb.Text == "")
            {
                MessageBox.Show("What is the Quality of Items");
            }
            else if (flag == 0)
            {
                MessageBox.Show("Select The Product To be Ordered");
            }
            else
            {
                num = num + 1;
                total = price * Convert.ToInt32(QtyTb.Text);
                table.Rows.Add(num, item, cat, price, total);
                OrderDataDV.DataSource = table;
                flag = 0;
            }
            sum = sum + total;
            LabelAmount.Text = "Rs" + sum;
        }
        DataTable table = new DataTable();
        int flag = 0;
        int sum = 0;
        private void QtyTb_TextChanged(object sender, EventArgs e)
        {

        }

        private void UserOrder_Load(object sender, EventArgs e)
        {
            populateDgv();
            table.Columns.Add("Num", typeof(int));
            table.Columns.Add("Item", typeof(string));
            table.Columns.Add("Category", typeof(string));
            table.Columns.Add("UnitPrice", typeof(int));
            table.Columns.Add("Total", typeof(int));
            OrderDataDV.DataSource = table;
        }



        private void itemsGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            item = itemsGridView.SelectedRows[0].Cells[1].Value.ToString();
            cat = itemsGridView.SelectedRows[0].Cells[2].Value.ToString();
            price = Convert.ToInt32(itemsGridView.SelectedRows[0].Cells[3].Value.ToString());
            flag = 1;

        }

        private void itemsGridView_Click_1(object sender, EventArgs e)
        {
            item = itemsGridView.SelectedRows[0].Cells[1].Value.ToString();
            cat = itemsGridView.SelectedRows[0].Cells[2].Value.ToString();
            price = Convert.ToInt32(itemsGridView.SelectedRows[0].Cells[3].Value.ToString());
            flag = 1;
        }

        private void labelAmount_Click(object sender, EventArgs e)
        {

        }

        private void itemsGridView_Click(object sender, EventArgs e)
        {

        }
        private void UserOrder_Click(object sender, EventArgs e)
        {
        }
    }
}