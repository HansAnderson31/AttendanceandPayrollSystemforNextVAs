<%@ Page Title="" Language="C#" MasterPageFile="~/WebBase.Master" AutoEventWireup="true" CodeBehind="FullInformation.aspx.cs" Inherits="Nextvas_Project_System.FullInformation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Styles/FullInformation.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <div class="row1">
            <div class="image_area">
                <div>
                    <asp:Image CssClass="img" ID="profile_img" runat="server" ImageUrl="~/Assets/Icons/Profile Icon.png" />
                </div>
                <div>
                    <asp:Image CssClass="img" ID="qr_img" runat="server" ImageUrl="~/Assets/Icons/qrcode.png" />
                </div>
            </div>
            <div class="personal_information">
                <div>
                    <asp:Label ID="empIdAccess" runat="server" Font-Size="15pt" Text="214532508745, Admin" style="font-weight:700"></asp:Label>
                </div>
                <div>
                    <asp:Label ID="empName" runat="server" Font-Size="30pt" Text="Fernand, Bautista B." style="font-weight:900"></asp:Label>
                </div>
                <div>
                    <table>
                        <tr>
                            <td>
                                <asp:Label CssClass="labelStyle" ID="label" runat="server" Text="Gender: "></asp:Label>
                                <asp:Label CssClass="dataStyle" ID="empGender" runat="server" Text="Male"></asp:Label>
                            </td>
                            <td>
                                <asp:Label CssClass="labelStyle" ID="Label4" runat="server" Text="Status: "></asp:Label>
                                <asp:Label CssClass="dataStyle" ID="empStatus" runat="server" Text="Single"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label CssClass="labelStyle" ID="Label5" runat="server" Text="Birthday: "></asp:Label>
                                <asp:Label CssClass="dataStyle" ID="empBirthday" runat="server" Text="Jan 23, 1992"></asp:Label>
                            </td>
                            <td>
                                <asp:Label CssClass="labelStyle" ID="Label6" runat="server" Text="Age: "></asp:Label>
                                <asp:Label CssClass="dataStyle" ID="empAge" runat="server" Text="23"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label CssClass="labelStyle" ID="Label7" runat="server" Text="Nationality: "></asp:Label>
                                <asp:Label CssClass="dataStyle" ID="empNation" runat="server" Text="Filipino"></asp:Label>
                            </td>
                            <td>
                                <asp:Label CssClass="labelStyle" ID="Label8" runat="server" Text="Religion: "></asp:Label>
                                <asp:Label CssClass="dataStyle" ID="empReligion" runat="server" Text="Catholic"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label CssClass="labelStyle" ID="Label9" runat="server" Text="Time Schedule: "></asp:Label>
                                <asp:Label CssClass="dataStyle" ID="empTimeSched" runat="server" Text="8:00 am ~ 9:00 am"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label CssClass="labelStyle" ID="Label10" runat="server" Text="Salary Range: "></asp:Label>
                                <asp:Label CssClass="dataStyle" ID="empSalaryRange" runat="server" Text="200 ~ 300 /hr"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
            <div class="contact_information">
                <div>
                    <asp:Label CssClass="labelStyle" ID="Label19" runat="server" Text="Home Address: "></asp:Label>
                    <asp:Label CssClass="dataStyle" ID="empHomeAdd" runat="server" Text="dawiododkoadkokdoawkdowa"></asp:Label>
                </div>
                <div>
                    <asp:Label CssClass="labelStyle" ID="Label21" runat="server" Text="Email Address: "></asp:Label>
                    <asp:Label CssClass="dataStyle" ID="empEmailAdd" runat="server" Text="admin@admin.com"></asp:Label>
                </div>
                <div>
                    <table>
                        <tr>
                            <td>
                                <asp:Label CssClass="labelStyle" ID="Label23" runat="server" Text="Contact Number: "></asp:Label>
                                <asp:Label CssClass="dataStyle" ID="empContNum" runat="server" Text="09854756324"></asp:Label>
                            </td>
                            <td>
                                <asp:Label CssClass="labelStyle" ID="Label25" runat="server" Text="Telephone Number: "></asp:Label>
                                <asp:Label CssClass="dataStyle" ID="empTelNum" runat="server" Text="52015248"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
