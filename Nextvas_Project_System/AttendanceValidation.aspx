<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="AttendanceValidation.aspx.cs" Inherits="Nextvas_Project_System.AttendanceValidation" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Nextvas Login</title>
    <link href="../AttendanceVal.css" rel="stylesheet" />
</head>
<body>
    <div class="center">
        <form method="post" runat="server">
        <h1>Attendance <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Assets/Icons/search.png" ImageAlign="Right" Height="30px" Width="30px" OnClick="ImageButton1_Click" />

        </h1>
        
            <div class="txt_field">
                <asp:TextBox ID="emp_id_InputBox" placeholder="Enter Employee ID" Font-Size="20pt" runat="server" style="font-size:20pt; margin: 30px 0;"></asp:TextBox>
                <asp:Button CssClass="time" ID="in_time_btn" runat="server" Text="Time In" OnClick="scan_btn_Click" />
                    <asp:Button CssClass="time" ID="out_time_btn" runat="server" Text="Time Out" OnClick="out_time_btn_Click" />
            </div>
            <div class="status_button">
                <div>
                    
                    <asp:HyperLink CssClass="submit" ID="HyperLink1" runat="server" NavigateUrl="~/LoginPage.aspx">Login</asp:HyperLink>
                   
                </div>
            </div>

        </form>

    </div>
</body>

</html>

