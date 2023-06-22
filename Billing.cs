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
    public partial class Billing : Form
    {
        public Billing()
        {
            
            InitializeComponent();
            billDetails();
            DateTxt.Text = DateTime.Now.ToString(@"yyyy-MM-dd");
            PnlShipping.Hide();
            CategoryCb.Text = "Select any Products";
            ProductIDTxt.Text = "Select products from table";
            Populate();
           // GetCategory(); GetCustomer();
            OrderIdTXT.Text = Convert.ToString(getOrderid());
            PnlPlaceBilling.Hide();
            getStaffId(); Stlbl.Text = Convert.ToString(getStaffId());
        }
        SqlTransaction transaction = null;
        SqlConnection con = new SqlConnection("Data Source=HAIER-PC;Initial Catalog=StoreDB;Integrated Security=True");
        SqlCommand cmd; SqlDataAdapter  da;
        int CustomerId { get; set; }
        int orderid { get; set; }
        string opt; // shipper
        private int getStaffId()
        {
            return Models.StaffInfo.Staff_Id;
        }
        private int  getOrderid()
        {
           
                con.Open();
                string query = "getorderid";
                cmd = new SqlCommand(query, con);
                cmd.CommandType = CommandType.StoredProcedure;
                da = new SqlDataAdapter(cmd);
                con.Close();
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    int id = int.Parse(Convert.ToString(dt.Rows[0][0]));
                    return orderid = id + 1;
                }
                else return 0;
        }

        private void billDetails()
        {
            BillGdv.ColumnCount = 5;
            BillGdv.Columns[0].Name = "Product Id";
            BillGdv.Columns[1].Name = "Product Name";
            BillGdv.Columns[2].Name = "Unit Price";
            BillGdv.Columns[3].Name = "Quantity";
            BillGdv.Columns[4].Name = "Sub Total";
            //For equl weidth 
            Clear();
            BillGdv.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            BillGdv.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            BillGdv.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            BillGdv.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            BillGdv.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
        void Populate()
        {
            try
            {
                con.Open();
                string query = "exec prodgridviewfill";
                SqlDataAdapter sda = new SqlDataAdapter(query, con);
                SqlCommandBuilder builder = new SqlCommandBuilder(sda);
                var ds = new DataSet();
                sda.Fill(ds);
                ProductGdv.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
        }
        
        private void GetCustomer()
        {
            try
            {
                con.Open();
                string query = "getcustname1";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd = new SqlCommand(query, con);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    custCb.Items.Add(dr[0]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
               
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
        }
        private void GetCustomername(string inp)
        {
            try
            {
                int len = inp.Length;
                con.Open();
                string query = "exec getcustname1";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@len", len);
                cmd.Parameters.AddWithValue("@input", inp);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    int custId = dr.GetInt32(0);
                    custCb.Items.Add(custId);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
        }

        private void GetCategory()
        {
            try
            {
                con.Open();
                string query = "exec getcatname";
                cmd = new SqlCommand(query, con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    CategoryCb.Items.Add(dr[0]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
        }
        private void AddTCartBtn_Click(object sender, EventArgs e)
        {
            AddTCart();
            Clear();
        }
        private void AddTCart()
        {
            if (QuantityTxt.Text.Trim() == "" || int.Parse(QuantityTxt.Text) == 0)
            {
                MessageBox.Show("select Quantity");
                QuantityTxt.Focus();
            }
            else
            {
                try
                {
                    int size = BillGdv.RowCount;
                    for (int i = 0; i < size; i++)
                    {
                        DataGridViewRow newrow = new DataGridViewRow();
                        newrow.CreateCells(BillGdv);
                        newrow.Cells[0].Value = ProductIDTxt.Text;
                        newrow.Cells[1].Value = NameTxt.Text;
                        newrow.Cells[2].Value = UnitPriseTxt.Text;
                        newrow.Cells[3].Value = QuantityTxt.Text;
                        newrow.Cells[4].Value = ProductAmountTxt.Text;
                        BillGdv.Rows.Add(newrow);
                        break;
                    }
                    CalculateTotal();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Selet Item and their prices form Product List!" + ex);
                }

            }
        }
        private void CalculateTotal()
        {
            int total = 0;
            for (int i = 0; i < BillGdv.Rows.Count; i++)
            {
                total += Convert.ToInt32(BillGdv.Rows[i].Cells["Sub Total"].Value);
            }
            TotalAmountLbl.Text = total.ToString();
        }
        private void CategoryCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("exec prodgridviewfillcat '"+CategoryCb.Text+"'", con);
                SqlCommandBuilder cmd = new SqlCommandBuilder(sda);
                var ds = new DataSet();
                sda.Fill(ds);
                ProductGdv.DataSource = ds.Tables[0];

            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
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

        private void ProductAmountTxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void QuantityTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }

        }

        private void QuantityTxt_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double qty = Convert.ToDouble(QuantityTxt.Text);
                double price = Convert.ToDouble(UnitPriseTxt.Text);
                double total = price * qty;
                ProductAmountTxt.Text = (total).ToString();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void Clear()
        {
            ProductIDTxt.Text="Select product from table";
            NameTxt.Text = "";
            QuantityTxt.Text = "0";
            ProductAmountTxt.Text ="0";
            UnitPriseTxt.Text = "0";
        }


        private void ProductGdv_DoubleClick(object sender, EventArgs e)
        {
            ProductIDTxt.Text = ProductGdv.SelectedRows[0].Cells[0].Value.ToString();
            NameTxt.Text = ProductGdv.SelectedRows[0].Cells[1].Value.ToString();
            UnitPriseTxt.Text = ProductGdv.SelectedRows[0].Cells[2].Value.ToString();
        }

        private void ConfirmBillBtn_Click(object sender, EventArgs e)
        {
            if (custCb.Text!=""|| custCb.Text == "Select Customerid") {
                string opt = "Inserted";
                ConfirmBill(opt);
            }
            else { 
                MessageBox.Show("Customer Id is not selected");
            }
        }

        private void ConfirmBill(string opt)
        {
            try
            {
                 
                //    transaction = con.BeginTransaction();
                string query = " INSERT INTO orders (stid, custid, date, amount) VALUES(@stid, @custid, @date, @amount); ";
                con.Open();
                cmd = new SqlCommand(query, con);
                //    cmd.Parameters.AddWithValue("@stid ", getStaffId());
                cmd.Parameters.AddWithValue("@stid ", 7);
                cmd.Parameters.AddWithValue("@custid", 2);
                cmd.Parameters.AddWithValue("@date", DateTime.Now.ToString(@"yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@amount", 100);
               // cmd.Transaction = transaction;
                cmd.ExecuteNonQuery();
                con.Close();
                for (int i = 0; i < BillGdv.Rows.Count; i++)
                    {
                        int ProductID = Convert.ToInt32(BillGdv.Rows[i].Cells["Product Id"].Value);
                        double Unitprice = Convert.ToDouble(BillGdv.Rows[i].Cells["Unit Price"].Value);
                        int qantity = Convert.ToInt32(BillGdv.Rows[i].Cells["Quantity"].Value);
                         query = " proc_ord_detadd @ordid, @prodid, @unitprice,@quan";
                    con.Open();
                        cmd = new SqlCommand(query, con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ordid", OrderIdTXT);
                        cmd.Parameters.AddWithValue("@prodid", 1);
                        cmd.Parameters.AddWithValue("@unitprice", 100);
                        cmd.Parameters.AddWithValue("@quan", 2);
                  //      cmd.Transaction = transaction;
                        cmd.ExecuteNonQuery();
                    con.Close();
                }
              
              //  transaction.Commit();
              //  con.Close();
                MessageBox.Show("Order " + opt + " sucessfully!!");
            }
            catch (SqlException ex)
            {
               // transaction.Rollback();
               // MessageBox.Show("Transaction was roll back with Error message\n"+ex.Message+":"+ex.GetType());
            }
            finally
            {
                if(con.State== ConnectionState.Open)
                con.Close();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {

            Audit aud = new Audit();
            aud.Show();
            Visible = false;
            //HeaderLbl.Text = "Shippers log";
            //PnlshipperLog.Show();
            //PnlChangePassword.Hide();
            //PnlManageShipper.Hide();
            //ShipperDatashow();
        }
       
        private void button4_Click(object sender, EventArgs e)
        {

            Shippers sh = new Shippers();
            sh.Show();
            Visible = false;
        //    HeaderLbl.Text = "Manage Shippers";
        //    PnlManageShipper.Show();
        //    PnlshipperLog.Hide();
        //    PnlShipping.Hide(); PopulateShippers();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            HeaderLbl.Text = "Shipping Orders";
            PnlPlaceBilling.Show();
            PnlShipping.Hide();
            GetShippers();
            textBox3.Text = Convert.ToString(getOrderid());
            textBox1.Text = DateTime.Now.ToString(@"yyyy-MM-dd");
        }

        private void GetAllBillings()
        { try {
                    con.Open();
                    // string query = "v_shippers_audit";
                    string query = "select * from shipment;";
                    SqlCommand cmd = new SqlCommand(query, con);
                    SqlDataReader reader = cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(reader);
                    ShippingOrderGD.DataSource = dt;
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

        private void AddBtn_Click(object sender, EventArgs e)
        {
            string opt = "inserted";
            ShippmentOperadd(1,opt);
        }

        private void ShippmentOperadd(int action, string opt)
            {
                try
                {
                    string query = "exec p_shipment  @action ,@id , @shipperid ,@orderid ,@sdate, @strack ,@status";
                    con.Open();
                    cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@action", action);
                    cmd.Parameters.AddWithValue("@id", shippingIdTxt.Text);
                    cmd.Parameters.AddWithValue("@shipperid", comboBox2.Text);
                    cmd.Parameters.AddWithValue("@orderid", textBox3.Text);
                    cmd.Parameters.AddWithValue("@sdate", DateTime.Now.ToString(@"yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@strack", textBox4.Text);
                    cmd.Parameters.AddWithValue("@status", comboBox1.Text);
                    cmd.ExecuteNonQuery();
                    GetAllBillings();
                    con.Close();
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


        private void ShippmentOper(int action, string opt)
        {
            try
            {   
                string query = "exec p_shipment  @action ,@id , @shipperid ,@orderid ,@sdate, @strack ,@status";
                con.Open();
                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@action", action);
                cmd.Parameters.AddWithValue("@id", shippingIdTxt.Text);
                cmd.Parameters.AddWithValue("@shipperid", shipperIdCb.Text);
                cmd.Parameters.AddWithValue("@orderid", ShOrderIdTxt.Text);
                cmd.Parameters.AddWithValue("@sdate", DateTime.Now.ToString(@"yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@strack", TrackingTxt.Text);
                cmd.Parameters.AddWithValue("@status", StatusCb.Text);
                cmd.ExecuteNonQuery();
                GetAllBillings();
                con.Close();
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

        private void shipperIdCb_SelectedIndexChanged(object sender, EventArgs e)
        {
           // GetShippersName();
        }

        private void GetShippersName()
        {
            try
            {
                con.Open();
                string query = "exec p_getshipper";
                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", int.Parse(shipperIdCb.Text));
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    shipperIdCb.Items.Add(dr[0]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
        }

        private void GetShippers()
        {
            if (con.State == ConnectionState.Open)
                con.Close();
            try { 
            
                con.Open();
                string query = "  p_getshipperid";
                cmd = new SqlCommand(query, con);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    shipperIdCb.Items.Add(dr[0]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            PnlShipping.Hide();
            PnlPlaceBilling.Hide();
        }

        private void StatusCkB_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void SSuppNameTxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            int rowIndex = BillGdv.CurrentCell.RowIndex;
            BillGdv.Rows.RemoveAt(rowIndex);
            CalculateTotal();
            MessageBox.Show("Item removed successfully!");
        }

      
        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            string opt = "Updated";
            ShippmentOper(2, opt);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string opt = "Deleted";
            ShippmentOper(3, opt);
        }

        private void DateTxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void PnlshipperLog_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ShippingOrderGD_DoubleClick(object sender, EventArgs e)
        {
            shippingIdTxt.Text = ProductGdv.SelectedRows[0].Cells[0].Value.ToString();
            shipperIdCb.Text = ProductGdv.SelectedRows[0].Cells[1].Value.ToString();
            ShOrderIdTxt.Text = ProductGdv.SelectedRows[0].Cells[2].Value.ToString();
            TrackingTxt.Text = ProductGdv.SelectedRows[0].Cells[4].Value.ToString();
            StatusCb.Text = ProductGdv.SelectedRows[0].Cells[5].Value.ToString();
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            HeaderLbl.Text = "Shipping Orders";
            PnlShipping.Show();
            GetShippers();
            BillDateTxt.Text = DateTime.Now.ToString(@"yyyy-MM-dd");
            GetAllBillings();
           
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            PnlPlaceBilling.Hide();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            ClearBilling();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            ClearBilling();
        }

        private void ClearBilling()
        {
            shippingIdTxt.Text = "";
            shipperIdCb.Text = "";
            ShOrderIdTxt.Text = "";
            TrackingTxt.Text = "";
            StatusCb.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            Visible = false;
        }

        private void custCb_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
