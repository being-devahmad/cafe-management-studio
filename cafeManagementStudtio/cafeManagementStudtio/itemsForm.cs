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
    public partial class itemsForm : Form
    {
        public itemsForm()
        {
            InitializeComponent();
        }

        private void label8_Click(object sender, EventArgs e)
        {

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
            this.Hide();
            UserOrder order = new UserOrder();
            order.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            UsersForm uform = new UsersForm();
            uform.Show();
            this.Hide();
        }

        private void itemsForm_Load(object sender, EventArgs e)
        {
            populateDgv();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {
            Application.Exit();
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
        private void addItems()
        {
            if (itemNum.Text == "" || itemName.Text == "" || itemPrice.Text == "")
            {
                MessageBox.Show("Fill the data first");
            }
            else {
                try
                {
                    con.Open();
                    string query = "insert into ItemTbl values ('" + itemNum.Text + "' , '" + itemName.Text + "' ,  '" + catCombo.SelectedItem.ToString() + "' , '" + itemPrice.Text + "')";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("User Sucessfully Created");

                    itemName.Clear();
                    itemNum.Clear();
                    itemPrice.Clear();

                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void editItems()
        {
            if (itemNum.Text == "" || itemName.Text == "" || itemPrice.Text == "" )
            {
                MessageBox.Show("Fill all fields first");
            }
            else
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("UPDATE ItemTbl set ItemName =  ' " + itemName.Text + " ', itemPrice = ' " + itemPrice.Text + " ' where  ItemNum = ' " + itemNum.Text + " ' ", con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Item succesfully updated");
                    con.Close();
                    //populateDgv();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void deleteItems()
        {
            if (itemNum.Text == "" )
            {
                MessageBox.Show("Select the user to be deleted ");
            }
            else
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("DELETE  from ItemTbl WHERE ItemNum ='"+itemNum.Text+"' ", con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show(" Item succesfully deleted");
                    con.Close();
                    //populateDgv();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            addItems();
            populateDgv();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void itemsGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
     
        }

        private void button6_Click(object sender, EventArgs e)
        {
            deleteItems();
            populateDgv();
        }

        private void catCombo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void itemsGridView_Click(object sender, EventArgs e)
        {
            itemNum.Text = itemsGridView.SelectedRows[0].Cells[0].Value.ToString();
            itemName.Text = itemsGridView.SelectedRows[0].Cells[1].Value.ToString();
            catCombo.SelectedText = itemsGridView.SelectedRows[0].Cells[2].Value.ToString();
            itemPrice.Text = itemsGridView.SelectedRows[0].Cells[3].Value.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            editItems();
            populateDgv();   
        }
    }
}
