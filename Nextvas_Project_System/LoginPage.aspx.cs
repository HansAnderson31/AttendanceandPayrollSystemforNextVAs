using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Nextvas_Project_System
{
    public partial class LoginPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            errorMsg.Visible = false;

        }

        protected void submit_Btn_Click(object sender, EventArgs e)
        {
            var inputEmpID = id_Textbox.Text;
            var inputPass = password_Textbox.Text;
            Session["employeeID"] = id_Textbox.Text;
            errorMsg.Visible = !Access.CheckAccount(inputEmpID, inputPass);

            if (Access.CheckAccount(inputEmpID, inputPass))
            {
                //Valid Account
                if(EmployeeInfos.GetAllInfo(inputEmpID)["accessibility"] == "Employee")
                {
                    //If the user id is employee then return
                    Response.Write("<script>alert('Employee do not allowed')</script>");
                    return;
                }


                HttpCookie cookie = new HttpCookie("emp_id");
                cookie.Value = inputEmpID;
                cookie.Expires = DateTime.Now.AddHours(5);
                Response.SetCookie(cookie);

                HttpCookie cookie2 = new HttpCookie("viewID");
                cookie2["emp_id"] = inputEmpID;
                Response.AppendCookie(cookie2);


                errorMsg.Visible = false;
                Response.Write("<script>alert('Login success')</script>");
                if (EmployeeInfos.GetAllInfo(inputEmpID)["accessibility"] == "Hr")
                {
                    Response.Redirect("~/AddEmployee.aspx", true);
                    return;
                }
                else if (EmployeeInfos.GetAllInfo(inputEmpID)["accessibility"] == "Accountant")
                {
                    Response.Redirect("~/Payroll.aspx", true);
                    return;
                }
                else if (EmployeeInfos.GetAllInfo(inputEmpID)["accessibility"] == "Team Leader")
                {
                    Response.Redirect("~/Timesheet.aspx", true);
                    return;
                }

            }
            else
            {
                //Invalid Account
                errorMsg.Visible = true;
                errorMsg.Text = "Incorrect Account";
            }

        }

        protected void back(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("AttendanceValidation.aspx");
        }
    }
}