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
    public partial class Payslip : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            Load_Data();
        }
        private void Load_Data()
        {
            string conn = "server=localhost; user=root;database=dbconn;password=";
            //string conn = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            string queryRegister = $"SELECT p.*, e.f_name, e.l_name, e.salary_rate, e.salary_ot_rate FROM `payslip_tbl` p LEFT JOIN employee_info_tbl e ON p.emp_id=e.emp_id;";

            //Run the SQL Query
            MySqlConnection connect = new MySqlConnection(conn);
            MySqlCommand cmd = new MySqlCommand(queryRegister, connect);
            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);

            payslip_GridView.DataSource = dt;
            payslip_GridView.DataBind();
        }
        protected void submit_Click(object sender, EventArgs e)
        {
            string emp_id;
            emp_id = empIDFilter.Text;
            PayrollInfos.ClaimedPayroll(emp_id);
            Response.Redirect(Request.Url.AbsoluteUri);

        }
    }
}