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
    public partial class AttendanceValidation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
        }
        

        protected void scan_btn_Click(object sender, EventArgs e)
        {
            string emp_id = emp_id_InputBox.Text;
            emp_id_InputBox.Text = "";
            //If ID is invalid
            if (!EmployeeInfos.EmployeeIDExist(emp_id))
            {
                //Invalid
                string errorMassage = "Invalid ID";
                Response.Write($"<script>alert('{errorMassage}');</script>");
                return;
            }

            //Valid
            if (Attendance.IsEmployeeTimedIn(emp_id))
            {
                //Already time in
                string errorMassage = "The ID is already time in";
                Response.Write($"<script>alert('{errorMassage}');</script>");
            }
            else
            {
                //not yet time in
                string errorMassage = "Valid ID. Time In";
                Response.Write($"<script>alert('{errorMassage}');</script>");

                var getEmpID = Request.Cookies["emp_id"] != null ? Request.Cookies["emp_id"].Value : "";

                Attendance.RegisterAttendance(emp_id, getEmpID);
                Attendance.UpdateTimeIn(emp_id);
            }
            
        }

        protected void out_time_btn_Click(object sender, EventArgs e)
        {
            string errorMassage = "";
            string emp_id = emp_id_InputBox.Text;
            emp_id_InputBox.Text = "";

            //If ID is invalid
            if (!EmployeeInfos.EmployeeIDExist(emp_id)) 
            {
                //Invalid
                errorMassage = "Invalid ID";
                Response.Write($"<script>alert('{errorMassage}');</script>");

                return; 
            }

            //Employee is not yet time in
            if (!Attendance.IsEmployeeTimedIn(emp_id))
            {
                //Employee is not there yet
                errorMassage = "ID is not yet time in";
                Response.Write($"<script>alert('{errorMassage}');</script>");

                return;
            }


            //Valid
            //Employee is time in
            errorMassage = "Valid ID. Time Out";
            Response.Write($"<script>alert('{errorMassage}');</script>");

            Attendance.UpdateTimeOut(emp_id);
            PayrollInfos.UpdatePayroll(emp_id);
            
        }


        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Session["emp_id"] = emp_id_InputBox.Text;
            Response.Redirect("SearchTimesheet.aspx");
        }
    }
}