<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShoppingCart.aspx.cs" Inherits="NorthwindWebForm.ShoppingCart" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/UserControl/SumarioValidacaoModalPopup.ascx" TagPrefix="uc1" TagName="ValidacaoModalPopup" %>
<%@ Register Src="~/UserControl/ContaCaracter.ascx" TagPrefix="uc1" TagName="ContaCaracter" %>



<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">    
        //conta numero de caracteres
        function counterCharacter(textBoxID,labelID,maxLength) {
            
            var textbox = document.getElementById(textBoxID);
            var value = textbox.value;            
            var l = value.length;
            var t = maxLength;
            var formatString = '{0} / {1} caracteres';
            for (var i = 0; i < value.length; i++) {
                if (value[i] == '\n')
                    l++;
        }
        var label = document.getElementById(labelID);
        label.innerHTML = formatString.replace('{0}', l).replace('{1}', t);
    }    
</script>
    <style type="text/css">
        .auto-style1 {
            width: 213px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <table id="tblMain" border="1" width="600px">
            <tr>
                <td >
                    CustomerID:
                </td>
                <td width="60%">
                    <asp:DropDownList ID="ddlCustomerID" runat="server">
                    </asp:DropDownList>
                    <asp:CustomValidator ID="cvCustomerID" runat="server" ErrorMessage="Selecione um CustomerID" ControlToValidate="ddlCustomerID" OnServerValidate="cvCustomerID_ServerValidate" ForeColor="Red">*</asp:CustomValidator>
                </td>
            </tr>
            <tr>
                <td>
                    Date:
                </td>
                <td class="auto-style1">
                    <asp:TextBox ID="tbDate" runat="server" TextMode="DateTime"></asp:TextBox>
                    <asp:Image ID="imgCalendar" runat="server" CssClass="middle" ImageUrl="~/img/calendar.png" />
                    <cc1:MaskedEditExtender id="MeeEVDataInicio" 
                                            runat="server" ClearMaskOnLostFocus="False" ClipboardEnabled="False" ClipboardText="Por favor utilize o teclado para inserir os dados."
                                            CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" CultureDateFormat=""
                                            CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder=""
                                            CultureTimePlaceholder="" Enabled="True" ErrorTooltipEnabled="True" Mask="99/99/9999" CultureName="pt-BR"
                                            TargetControlID="tbDate">
                    </cc1:MaskedEditExtender> 
                    <cc1:CalendarExtender ID="calEVDthNascimento" runat="server" BehaviorID="calEVDthNascimento"
                        Format="dd/MM/yyyy" PopupButtonID="imgCalendar" TargetControlID="tbDate">
                    </cc1:CalendarExtender>
                    <asp:CustomValidator ID="cvDate" runat="server" ErrorMessage="Date field must be filled" ControlToValidate="tbDate" OnServerValidate="cvDate_ServerValidate" ForeColor="Red">*</asp:CustomValidator>
                </td>
            </tr>
            <tr>
                <td>
                    Description:<br />
                    <uc1:ContaCaracter runat="server" id="ContaCaracter1" />
                </td>
                <td margin="right">
                    <asp:TextBox ID="tbDescription" runat="server" 
                        TextMode="MultiLine" CausesValidation="True" Height="53px" MaxLength="50" Width="178px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfDescription" runat="server" ControlToValidate="tbDescription" ErrorMessage="Digite a descrição.">*</asp:RequiredFieldValidator>
                    <asp:CustomValidator ID="cvDescription" runat="server" ErrorMessage="Maximum characters in Description must be 50" ControlToValidate="tbDescription" OnServerValidate="cvDescription_ServerValidate" ForeColor="Red">*</asp:CustomValidator>
                    <br/>
                    
                </td>
            </tr>
            <tr>
                <td align="center">
                    <asp:Button ID="btSave" runat="server" Text="Save" OnClick="btSave_Click" CausesValidation="False" />
                </td>
                <td align="center">
                    <asp:Button ID="btExit" runat="server" Text="Exit" OnClick="btExit_Click" CausesValidation="False" />
                </td>
            </tr>
        </table> 
        
        <uc1:ValidacaoModalPopup runat="server" id="ctlValidacaoModalPopup1" />
    </form>
</body>
</html>
