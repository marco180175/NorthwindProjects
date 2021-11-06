<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Tables.aspx.cs" Inherits="NorthwindWebForm.Tables" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br>
    <table>
        <tr>
            <td>
                <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="Button2" runat="server" Text="Button" OnClick="Button2_Click" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:LinkButton ID="LinkButton3" runat="server">LinkButton</asp:LinkButton>
            </td>
        </tr>
    </table>
</asp:Content>
