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
namespace TheBuyingZone
{
    public partial class Audit : Form
    {
        public Audit()
        {
            
            InitializeComponent();
            Stlbl.Text = Convert.ToString(Models.StaffInfo.Staff_Id);
        }
        SqlConnection con = new SqlConnection("Data Source=HAIER-PC;Initial Catalog=StoreDB;Integrated Security=True");
        SqlCommand cmd;
        private void ShipperDatashow()
        {
            try
            {
                con.Open();
                // string query = "v_shippers_audit";
                string query = "select * from shippers_audit;";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                DgshipperAudit.DataSource = dt;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message +":"+ex.GetType());
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BillingBtn_Click(object sender, EventArgs e)
        {
            Billing bill = new Billing();
            bill.Show();
            Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Shippers sh = new Shippers();
            sh.Show();
            Visible = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Billing bill = new Billing();
            bill.Show();
            Visible = false;
        }

        private void BtnShiping_Click(object sender, EventArgs e)
        {
            Billing bill = new Billing();
            bill.Show();
            Visible = false;
            HeaderLbl.Text = "Shipping Orders";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            Visible = false;
        }
        private void orderDatashow()
        {
            try
            {
                con.Open();
                string query = " select * from v_order_;";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                DgshipperAudit.DataSource = dt;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ":" + ex.GetType());
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }

        }

        private void custCb_SelectedValueChanged(object sender, EventArgs e)
        {
            if(custCb.Text== "View Orders")
            {
                orderDatashow();

            }
            else if (custCb.Text == "View Shippers logs")
            {
                ShipperDatashow();
            }
        }
    }
}
