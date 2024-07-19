<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SearchTimesheet.aspx.cs" Inherits="Nextvas_Project_System.SearchTimesheet" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Nextvas Login</title>
    <link href="../SearchTime.css" rel="stylesheet" />
</head>
<body>
    <div class="center">
        <form method="post" runat="server">
        
            <div class="txt_field">
                <div>
            <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Assets/Icons/340.png" ImageAlign="Left" Height="20px" Width="20px" OnClick="back" />
                <asp:GridView ID="timeSheet_GridView" runat="server" AutoGenerateColumns="False" Width="80%" HorizontalAlign="Center">
                    <Columns>
                        <asp:HyperLinkField HeaderText="Employee ID" DataNavigateUrlFormatString="FullInformation.aspx?viewID={0}" DataTextField="emp_id" />
                        <asp:BoundField DataField="time_in" HeaderText="Time In" />
                        <asp:BoundField DataField="time_out" HeaderText="Time Out" />
                        <asp:BoundField DataField="late" HeaderText="Late" />
                        <asp:BoundField DataField="absent" HeaderText="Absent" />
                    </Columns>
                </asp:GridView>
            </div>
            </div>

        </form>

    </div>
</body>

</html>
