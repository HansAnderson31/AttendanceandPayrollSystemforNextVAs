<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="Nextvas_Project_System.LoginPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Nextvas Login</title>
    <link href="../Styles/LoginPage.css" rel="stylesheet" />
</head>
<body>
    <div class="center">
        <form method="post" runat="server" defaultbutton="submit_Btn">
        <h1>
            <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Assets/Icons/340.png" ImageAlign="Left" Height="20px" Width="20px" OnClick="back" />
            Login</h1>
            <div class="txt_field">
                <asp:TextBox CssClass="input" ID="id_Textbox" runat="server"></asp:TextBox>
                <asp:Label CssClass="label" ID="Label1" runat="server" Text="ID Number"></asp:Label>
            </div>
            <div class="txt_field">
                <asp:TextBox CssClass="input" ID="password_Textbox" runat="server" TextMode="Password"></asp:TextBox>
                <asp:Label CssClass="label" ID="Label2" runat="server" Text="Password"></asp:Label>
            </div>

            <asp:Label CssClass="errorMsg" ID="errorMsg" runat="server" Text="Error"></asp:Label>
            <asp:Button CssClass="submit" ID="submit_Btn" runat="server" Text="Submit" OnClick="submit_Btn_Click" />
        </form>
    </div>
</body>
</html>
