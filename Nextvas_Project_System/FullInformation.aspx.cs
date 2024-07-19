using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Nextvas_Project_System
{
    public partial class FullInformation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Request.Cookies["viewID"]["emp_id"] != null)
                {
                    var id = Request.Cookies["viewID"]["emp_id"];
                    LoadData(id);
                }
            }
            catch(Exception ex)
            {

            }

            try
            {
                if (Request.QueryString["viewID"] != null)
                {
                    var viewId = Request.QueryString["viewID"];
                    LoadData(viewId);
                }
            }catch(Exception ex)
            {

            }
            
            
        }

        private void LoadData(string emp_id)
        {
            var empInfo = EmployeeInfos.GetAllInfo(emp_id);

            profile_img.ImageUrl = empInfo["profile_pic"];
            qr_img.ImageUrl = empInfo["qr_code"];

            empIdAccess.Text = $"{empInfo["emp_id"]}, {empInfo["accessibility"]}";
            empName.Text = $"{empInfo["f_name"]}, {empInfo["l_name"]} {empInfo["m_name"][0]}.";
            empGender.Text = $"{empInfo["sex"]}";
            empStatus.Text = $"{empInfo["status"]}";
            empBirthday.Text = $"{empInfo["bday"]}";
            empAge.Text = $"{ComputeBday(empInfo["bday"])}";
            empNation.Text = $"{empInfo["nationality"]}";
            empReligion.Text = $"{empInfo["religion"]}";
            empTimeSched.Text = $"{empInfo["time_in_sched"]} ~ {empInfo["time_out_sched"]}";
            empSalaryRange.Text = $"{empInfo["salary_rate"]} ~ {empInfo["salary_ot_rate"]}";

            empHomeAdd.Text = $"{empInfo["home_add"]}";
            empEmailAdd.Text = $"{empInfo["email_add"]}";
            empContNum.Text = $"{empInfo["cont_num"]}";
            empTelNum.Text = $"{empInfo["tel_num"]}";
        }
        private int ComputeBday(string bday)
        {
            DateTime today = DateTime.Today;
            DateTime birthDay = DateTime.Parse(bday);

            var age = today.Year - birthDay.Year - (birthDay.DayOfYear < birthDay.DayOfYear ? 0 : 1);
            return age > 0 ? age : 0;
        }
    }
}