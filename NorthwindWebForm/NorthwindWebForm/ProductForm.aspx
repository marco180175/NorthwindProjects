<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductForm.aspx.cs" Inherits="NorthwindWebForm.ProductItem" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/UserControl/SumarioValidacaoModalPopup.ascx" TagPrefix="uc1" TagName="ValidacaoModalPopup" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <table>
                <tr>
                    <td>
                        Name
                    </td>
                    <td>
                        UnitPrice 
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="txbProductName" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txbProductName"></asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:TextBox ID="txbUnitPrice" runat="server"></asp:TextBox>
                        <cc1:MaskedEditExtender ID="txbUnitPrice_MaskedEditExtender" runat="server" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder="" DisplayMoney="Left" Enabled="True" Mask="9,99" MaskType="Number" TargetControlID="txbUnitPrice">
                        </cc1:MaskedEditExtender>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txbUnitPrice"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        Supplier
                    </td>
                    <td>
                        UnitsInStock
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:DropDownList ID="ddlSupplier" runat="server"></asp:DropDownList>
                        <asp:CustomValidator ID="CustomValidator1" runat="server" ControlToValidate="ddlSupplier" ErrorMessage="CustomValidator" OnServerValidate="CustomValidator1_ServerValidate"></asp:CustomValidator>
                    </td>
                    <td>
                        <asp:TextBox ID="txbUnitsInStock" runat="server"></asp:TextBox>
                        <cc1:MaskedEditExtender ID="txbUnitsInStock_MaskedEditExtender" runat="server" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder="" Enabled="True" Mask="999" MaskType="Number" TargetControlID="txbUnitsInStock">
                        </cc1:MaskedEditExtender>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txbUnitsInStock"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        Category
                    </td>
                    <td>
                        UnitsOnOrder
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:DropDownList ID="ddlCategory" runat="server"></asp:DropDownList>
                        <asp:CustomValidator ID="CustomValidator2" runat="server" ControlToValidate="ddlCategory" ErrorMessage="CustomValidator" OnServerValidate="CustomValidator2_ServerValidate"></asp:CustomValidator>
                    </td>
                    <td>
                        <asp:TextBox ID="txbUnitsOnOrder" runat="server"></asp:TextBox>
                        <cc1:MaskedEditExtender ID="txbUnitsOnOrder_MaskedEditExtender" runat="server" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder="" Enabled="True" Mask="99" MaskType="Number" TargetControlID="txbUnitsOnOrder">
                        </cc1:MaskedEditExtender>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txbUnitsOnOrder"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        QuantityPerUnit
                    </td>
                    <td>
                        ReorderLevel
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="txbQuantityPerUnit" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="txbReorderLevel" runat="server"></asp:TextBox>
                        <cc1:MaskedEditExtender ID="txbReorderLevel_MaskedEditExtender" runat="server" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder="" Enabled="True" Mask="99" TargetControlID="txbReorderLevel">
                        </cc1:MaskedEditExtender>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txbReorderLevel"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:CheckBox ID="ckbDiscontinued" runat="server" Text="Discontinued" />
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
        </div>
        <uc1:ValidacaoModalPopup runat="server" id="ctlValidacaoModalPopup1" />
    </form>
</body>
</html>
