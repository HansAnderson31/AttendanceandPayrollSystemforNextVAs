using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Nextvas_Project_System
{
    public partial class Payroll : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            Load_Data();
            //date_range.Visible = false;
        }
        private void Load_Data()
        {
            string conn = "server=localhost; user=root;database=dbconn;password=";
            //string conn = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            string queryRegister = $"SELECT p.*, e.f_name, e.l_name, e.salary_rate, e.salary_ot_rate FROM `payroll_tbl` p LEFT JOIN employee_info_tbl e ON p.emp_id=e.emp_id;";

            //Run the SQL Query
            MySqlConnection connect = new MySqlConnection(conn);
            MySqlCommand cmd = new MySqlCommand(queryRegister, connect);
            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);

            payslip_GridView.DataSource = dt;
            payslip_GridView.DataBind();

            int time = Convert.ToInt32(DateTime.Now.ToString("dd"));
            if (time == 5 || time == 21)
            {
                submit_btn.Visible = true;
                start_date_TextBox.Visible = true;
                end_date_TextBox.Visible = true;
                Label1.Visible = true;
                Label2.Visible = true;
            }
        }
        protected void payroll_GridView_Load(object sender, EventArgs e)
        {

        }

        protected void submit_Click(object sender, EventArgs e)
        {
            string conn, queryRegister;
            DateTime startDate = DateTime.Parse(start_date_TextBox.Text);
            string time1 = startDate.ToString("yyyy-MM-dd");
            DateTime endDate = DateTime.Parse(end_date_TextBox.Text);
            string time2 = endDate.ToString("yyyy-MM-dd");
            //
            conn = "server=localhost; user=root;database=dbconn;password=";
            queryRegister = $"INSERT INTO payslip_tbl select *, 'unclaimed', '', '{time1}','{time2}' from payroll_tbl WHERE total_hr!='0';";
            using (MySqlConnection connection = new MySqlConnection(conn))
            {
                MySqlCommand command = new MySqlCommand(queryRegister, connection);
                command.Connection.Open();
                command.ExecuteNonQuery();
                command.Connection.Close();

            }
            //
            queryRegister = $"update payroll_tbl " +
                $"set total_hr='0', total_ot='0', total_sal='0', total_tax='0', computed_sal='0'";
            using (MySqlConnection connection = new MySqlConnection(conn))
            {
                MySqlCommand command = new MySqlCommand(queryRegister, connection);
                command.Connection.Open();
                command.ExecuteNonQuery();
                command.Connection.Close();
            }

            Response.Redirect("Payslip.aspx");
        }

    }
}