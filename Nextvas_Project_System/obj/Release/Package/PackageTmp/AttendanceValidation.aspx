<%@ Page Title="" Language="C#" MasterPageFile="~/WebBase.Master" AutoEventWireup="true" CodeBehind="AttendanceValidation.aspx.cs" Inherits="Nextvas_Project_System.AttendanceValidation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <div class="input_qr_id" >
            <div>
                <asp:TextBox ID="emp_id_InputBox" placeholder="Enter Employee ID" Font-Size="20pt" runat="server" style="font-size:20pt; margin: 30px 0;"></asp:TextBox>
            </div>
            <div class="status_button">
                <div>
                    <asp:Button ID="in_time_btn" runat="server" Text="Time In" OnClick="scan_btn_Click" />
                    <asp:Button ID="out_time_btn" runat="server" Text="Time Out" OnClick="out_time_btn_Click" />
                </div>
                <div>
                    
                </div>
                <div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
