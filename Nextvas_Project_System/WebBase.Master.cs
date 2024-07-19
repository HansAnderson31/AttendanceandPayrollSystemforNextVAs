using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Nextvas_Project_System
{
    public partial class WebBase : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Request.Cookies["emp_id"] != null)
            {
                var emp_id = Request.Cookies["emp_id"].Value;
                var empInfo = EmployeeInfos.GetAllInfo(emp_id);
                labelName.Text = empInfo["f_name"];

                switch (empInfo["accessibility"])
                {
                    case "Accountant":
                        addEmpList.Visible = false;
                        viewEmpList.Visible = false;
                        timeSheetList.Visible = false;
                        payRollList.Visible = true;
                        paySlipList.Visible = true;
                        break;
                    case "Hr":
                        addEmpList.Visible = true;
                        viewEmpList.Visible = true;
                        timeSheetList.Visible = true;
                        payRollList.Visible = false;
                        paySlipList.Visible = false;
                        break;
                    case "Team Leader":
                        addEmpList.Visible = false;
                        viewEmpList.Visible = false;
                        timeSheetList.Visible = true;
                        payRollList.Visible = false;
                        paySlipList.Visible = false;
                        break;
                    default:
                        break;
                }
            }
        }
    }
}