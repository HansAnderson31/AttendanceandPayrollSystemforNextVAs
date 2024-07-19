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
    public partial class SearchTimesheet : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            FindData(Session["emp_id"].ToString());
        }
        private void Load_Data()
        {
            string conn = "server=localhost; user=root;database=dbconn;password=";
            //string conn = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            //string queryRegister = $"select * from time_sheet_tbl";
            string queryRegister = $"SELECT t.*, e.f_name, e.l_name FROM `time_sheet_tbl` t LEFT JOIN employee_info_tbl e ON t.emp_id = e.emp_id";


            //Run the SQL Query
            MySqlConnection connect = new MySqlConnection(conn);
            MySqlCommand cmd = new MySqlCommand(queryRegister, connect);
            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);

            timeSheet_GridView.DataSource = dt;
            timeSheet_GridView.DataBind();
        }
        private void FindData(string findID)
        {
            string conn = "server=localhost; user=root;database=dbconn;password=";
            string queryRegister = $"SELECT emp_id, time_in, time_out, t.late, t.absent FROM `time_sheet_tbl` t where t.emp_id = '{findID}'";
            //Run the SQL Query
            MySqlConnection connect = new MySqlConnection(conn);
            MySqlCommand cmd = new MySqlCommand(queryRegister, connect);
            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);

            timeSheet_GridView.DataSource = dt;
            timeSheet_GridView.DataBind();
        }
        protected void back(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("AttendanceValidation.aspx");
        }
    }
}