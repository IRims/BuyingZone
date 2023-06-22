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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=HAIER-PC;Initial Catalog=StoreDB;Integrated Security=True");
        SqlCommand cmd;SqlDataAdapter da;
        private bool validate(string name, string role)
        {
            try
            {
                con.Open();
                string query = "exec p_login @name , @role";
                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@name",name);
                cmd.Parameters.AddWithValue("@role", role);
                da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count == 1)
                {
                    int id = int.Parse(Convert.ToString(dt.Rows[0][0]));
                    Models.StaffInfo.Staff_Id = id;
                    return true;
                }
                else return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {

            string name = UserNameTxt.Text.Trim(); string pass = PasswordTxt.Text.Trim();
            string role = RoleCb.Text;
            if (name == "" || pass == "" || role == "" || role == "Select a Role")
            {
                Lblnotify.Text = "Fill complete information";
            }
            else if (validate(name, role))
            {
                MessageBox.Show("Login sucessfull");
                if (role == "Seller")
                {
                    Billing bil = new Billing();
                    bil.Show();
                    Visible = false;
                }
                else if (role == "Manager")
                {
                    //Manager manager = new Manager();
                    //manager.Show();
                    //Visible = false;
                }
                if (role == "Staff")
                {
                    //Billing bil = new Billing();
                    //bil.Show();
                    //Visible = false;
                }
                else if (role == "Admin")
                {
                    //Billing bil = new Billing();
                    //bil.Show();
                    //Visible = false;
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
