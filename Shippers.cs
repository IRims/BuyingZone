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
using TheBuyingZone.Models;
namespace TheBuyingZone
{
    public partial class Shippers : Form
    {
        public Shippers()
        {
            InitializeComponent();
            PopulateShippers();
            Stlbl.Text = Convert.ToString(Models.StaffInfo.Staff_Id);
        }
        string opt;
        SqlConnection con = new SqlConnection("Data Source=HAIER-PC;Initial Catalog=StoreDB;Integrated Security=True");
        SqlCommand cmd;
        private void PopulateShippers()
        {
            try
            {
                con.Open();
                string query = "exec v_shippers_audit";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                ShipperManageGD.DataSource = dt;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
        }


        private void AddBtn_Click(object sender, EventArgs e)
        {
            opt = "added";
            Operation(1,opt);
            ClearShipper();
        }

        private void Operation(int action,string opt)
        { 
            try
            {   string query = "exec p_shippers  @action,@id ,@sname,@contact,@email";
                con.Open();
                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@action", action);
                cmd.Parameters.AddWithValue("@id", ShipperIDTxt.Text); 
                cmd.Parameters.AddWithValue("@sname", ShNameTxt.Text);
                cmd.Parameters.AddWithValue("@contact", ShContactTxt.Text);
                cmd.Parameters.AddWithValue("@email", ShEmailTxt.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                PopulateShippers();
                MessageBox.Show("Data" + opt + "sucessfully!!");
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
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

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            opt = "updated";
            Operation(2, opt);
            ClearShipper();
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            opt = "deleted";
            Operation(3, opt);
            ClearShipper();
        }

        private void supplierGD_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ShipperIDTxt.Text = ShipperManageGD.SelectedRows[0].Cells[0].Value.ToString();
            ShNameTxt.Text = ShipperManageGD.SelectedRows[0].Cells[1].Value.ToString();
            ShContactTxt.Text = ShipperManageGD.SelectedRows[0].Cells[2].Value.ToString();
            ShEmailTxt.Text = ShipperManageGD.SelectedRows[0].Cells[3].Value.ToString();
        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            ClearShipper();
        }

        private void ClearShipper()
        {
            ShipperIDTxt.Text = "";
            ShNameTxt.Text = "";
            ShEmailTxt.Text = "";
            ShContactTxt.Text = "";
        }

        private void shipperGD_DoubleClick(object sender, EventArgs e)
        {
            ShipperIDTxt.Text = ShipperManageGD.SelectedRows[0].Cells[0].Value.ToString();
            ShNameTxt.Text = ShipperManageGD.SelectedRows[0].Cells[1].Value.ToString();
            ShContactTxt.Text = ShipperManageGD.SelectedRows[0].Cells[2].Value.ToString();
            ShEmailTxt.Text = ShipperManageGD.SelectedRows[0].Cells[3].Value.ToString();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BillingBtn_Click(object sender, EventArgs e)
        {
            Billing bill = new Billing();
            bill.Show();
            Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Billing bill = new Billing();
            bill.Show();
            Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            Visible = false;

        }

        private void BtnShiping_Click(object sender, EventArgs e)
        {
            Billing bill = new Billing();
            bill.Show();
            Visible = false;
        }
    }
}
