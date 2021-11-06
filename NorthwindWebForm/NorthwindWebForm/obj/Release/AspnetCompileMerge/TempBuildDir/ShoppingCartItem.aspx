<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShoppingCartItem.aspx.cs" Inherits="NorthwindWebForm.ShoppingCartItem" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <table>
            <tr>
                <td>
                    Count:
                </td>
                <td>
                    <asp:TextBox ID="TextBox1" runat="server" TextMode="Number">1</asp:TextBox>
                    <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="RangeValidator" ControlToValidate="TextBox1" MaximumValue="9999" MinimumValue="1"></asp:RangeValidator>
                </td>
            </tr>
            <tr>
                <td>
                    CategoryName:
                </td>
                <td>
                    <asp:DropDownList ID="ddlCategories" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCategories_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    Products:
                </td>
                <td>
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" AllowPaging="True" OnPageIndexChanging="GridView1_PageIndexChanging" PageSize="5" OnRowCommand="GridView1_RowCommand" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
            <Columns>                
                <asp:TemplateField HeaderText="ProductID">                        
                        <ItemTemplate>
                            <asp:Label ID="lbId1" runat="server" Text='<%#Eval("ProductID") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="ProductName">                        
                        <ItemTemplate>
                            <asp:Label ID="lbId2" runat="server" Text='<%#Eval("ProductName") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="UnitPrice">                        
                        <ItemTemplate>
                            <asp:Label ID="lbId3" runat="server" Text='<%#Eval("UnitPrice") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                <asp:TemplateField ShowHeader="False">
                                <ItemTemplate>                             
                                    <asp:Button ID="btSelect" runat="server" CausesValidation="false" CommandName="Select"
                                            Text="Select" CommandArgument='<%# Eval("ProductID") %>' />
                                </ItemTemplate>                                            
                            </asp:TemplateField>
                </Columns>
        </asp:GridView>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btSave" runat="server" Text="Save" OnClick="btSave_Click" />
                </td>
                <td>
                    <asp:Button ID="btExit" runat="server" Text="Exit" OnClick="btExit_Click" />
                </td>
            </tr>
        </table>        
    </form>
</body>
</html>
