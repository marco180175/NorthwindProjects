<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShoppingCartItem.aspx.cs" Inherits="NorthwindWebForm.ShoppingCartItem" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/UserControl/ProdutosModalPopup.ascx" TagPrefix="uc1" TagName="ProdutosModalPopup" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
                        
        <table id="table1" border="1">
            <tr>
                <td>
                    Quantity:
                </td>
                <td>
                    <asp:TextBox ID="tbQuantity" runat="server" TargetControlID="tbQuantity">1</asp:TextBox>                    
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="tbQuantity" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>
                    <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="RangeValidator" ControlToValidate="tbQuantity" MaximumValue="10" MinimumValue="1" Type="Integer"></asp:RangeValidator>
                    <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" Mask="99" MaskType="Number" TargetControlID="tbQuantity"></cc1:MaskedEditExtender>
                </td>
                <td></td>
            </tr>
            <tr>
                <td>
                    CategoryName:
                </td>
                <td>
                    <asp:DropDownList ID="ddlCategories" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCategories_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:Button ID="Button1" runat="server" Text="Products" OnClick="Button1_Click" />
                </td>
            </tr>
            <tr>
                <td>
                    ProductID:
                </td>
                <td>
                    
                    <asp:TextBox ID="TextBox1" runat="server" ReadOnly="True"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>
                    
                </td>
                <td></td>
            </tr>
            <tr>
                <td>
                    UnitPrice:
                </td>
                <td>
                    
                    <asp:TextBox ID="TextBox2" runat="server" ReadOnly="True"></asp:TextBox>
                    
                </td>
                <td></td>
            </tr>
            <tr>
                <td align="center">
                    <asp:Button ID="btSave" runat="server" Text="Save" OnClick="btSave_Click" Width="70px" />
                </td>
                <td align="center">
                    <asp:Button ID="btExit" runat="server" Text="Exit" OnClick="btExit_Click" CausesValidation="False" Width="70px" />
                </td>
                <td></td>
            </tr>
        </table>           
        
        <uc1:ProdutosModalPopup runat="server" id="ProdutosModalPopup1" />


    </form>
</body>
</html>
