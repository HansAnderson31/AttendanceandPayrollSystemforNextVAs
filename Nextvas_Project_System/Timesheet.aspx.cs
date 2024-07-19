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
    public partial class Timesheet : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            var empInfo = EmployeeInfos.GetAllInfo(Session["employeeID"].ToString());
            if (empInfo["accessibility"] == "Hr")
            {
                canvas_above.Visible = false;
                Load_Data3();
            }
            else
            {
                Load_Data();
                Load_Data2();
            }
        }
        private void FindData(string findID)
        {
            string conn = "server=localhost; user=root;database=dbconn;password=";
            var leadfName = EmployeeInfos.GetAllInfo(Session["employeeID"].ToString())["f_name"];
            var leadlName = EmployeeInfos.GetAllInfo(Session["employeeID"].ToString())["l_name"];
            string fullName = leadfName + " " + leadlName;
            if (time_in_TextBox.Text != "" && time_out_TextBox.Text != "" && searchEmp.Text != "")
            {
                DateTime time1 = DateTime.Parse(time_in_TextBox.Text);
                string time2 = time1.ToString("dd/MM/yyyy HH:mm");
                DateTime time3 = DateTime.Parse(time_out_TextBox.Text);
                string time4 = time3.ToString("dd/MM/yyyy HH:mm");
                string queryRegister = $"SELECT t.*, e.f_name, e.l_name FROM `time_sheet_tbl` t " +
                    $"LEFT JOIN employee_info_tbl e ON t.emp_id = e.emp_id " +
                    $"where t.time_in >= '{time2}' and t.time_out <='{time4}' and t.emp_id = '{findID}'";
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
            else if (time_in_TextBox.Text != "" && time_out_TextBox.Text != "")
            {

                DateTime time1 = DateTime.Parse(time_in_TextBox.Text);
                string time2 = time1.ToString("dd/MM/yyyy HH:mm");
                DateTime time3 = DateTime.Parse(time_out_TextBox.Text);
                string time4 =  time3.ToString("dd/MM/yyyy HH:mm");
                string queryRegister = $"SELECT t.*, e.f_name, e.l_name FROM `time_sheet_tbl` t " +
                    $"LEFT JOIN employee_info_tbl e ON t.emp_id = e.emp_id " +
                    $"where t.time_in >= '{time2}' and t.time_out <= '{time4}'";
                MySqlConnection connect = new MySqlConnection(conn);
                MySqlCommand cmd = new MySqlCommand(queryRegister, connect);
                MySqlDataAdapter da = new MySqlDataAdapter();
                da.SelectCommand = cmd;
                DataTable dt = new DataTable();
                da.Fill(dt);

                timeSheet_GridView.DataSource = dt;
                timeSheet_GridView.DataBind();
                
            }
            else
            {

                string queryRegister = $"SELECT t.*, e.f_name, e.l_name FROM `time_sheet_tbl` t LEFT JOIN employee_info_tbl e ON t.emp_id = e.emp_id where t.emp_id = '{findID}'";
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
            
        }

        private void Load_Data()
        {
            string conn = "server=localhost; user=root;database=dbconn;password=";

            var leadfName = EmployeeInfos.GetAllInfo(Session["employeeID"].ToString())["f_name"];
            var leadlName = EmployeeInfos.GetAllInfo(Session["employeeID"].ToString())["l_name"];
            string fullName = leadfName + " " + leadlName;
            
            string queryRegister = $"SELECT t.*,e.emp_id, e.f_name, e.l_name FROM `time_sheet_tbl` t " +
                $"LEFT JOIN employee_info_tbl e ON  t.emp_id = e.emp_id " +
                $"WHERE e.t_leader = '{fullName}'";
            

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
        private void Load_Data2()
        {
            
            string conn = "server=localhost; user=root;database=dbconn;password=";
            //string conn = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            //string queryRegister = $"select * from time_sheet_tbl";
            var leadfName = EmployeeInfos.GetAllInfo(Session["employeeID"].ToString())["f_name"];
            var leadlName = EmployeeInfos.GetAllInfo(Session["employeeID"].ToString())["l_name"];
            string fullName = leadfName + " " + leadlName;
            string queryRegister = $"SELECT e.emp_id, e.l_name, e.f_name, e.time_in_sched, e.time_out_sched, t.attend_status, sum(t.late) as late_count, sum(t.absent) as absent_count " +
                $"FROM `time_sheet_tbl` t " +
                $"LEFT JOIN employee_info_tbl e ON t.emp_id = e.emp_id where e.t_leader = '{fullName}' group by emp_id";
            // 


            //Run the SQL Query
            MySqlConnection connect = new MySqlConnection(conn);
            MySqlCommand cmd = new MySqlCommand(queryRegister, connect);
            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);

            GridView2.DataSource = dt;
            GridView2.DataBind();
        }
        private void Load_Data3()
        {
            string conn = "server=localhost; user=root;database=dbconn;password=";
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

        protected void searchBtn_Click(object sender, EventArgs e)
        {
            FindData(searchEmp.Text);
        }

        protected void clearBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.Url.AbsoluteUri);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string employeeID = empID.Text;
            if (!EmployeeInfos.EmployeeIDExist(employeeID))
            {
                //Invalid
                Response.Write($"<script>alert('Employee ID does not exist');</script>");
                return;
            }
            else
            {
                Attendance.UpdateAbsent(employeeID);
                Response.Redirect(Request.Url.AbsoluteUri);
            }
            
        }
    }
}