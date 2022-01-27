<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SumarioValidacaoModalPopup.ascx.cs" Inherits="TesteValidadores.UserControl.ModalPopupValidacao" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<style type="text/css">
    .modalBackground
    {
        background-color: #999;
        filter: alpha(opacity-]=70);
        opacity:0.5;
    }

    .modalPopup
    {
        background-color: #fffddd;
        padding: 3px;
        z-index: 10001;
    }
</style>

<asp:HiddenField ID="HiddenField1" runat="server" />
        
<cc1:ModalPopupExtender ID="ModalPopupExtender1" runat="server"
    TargetControlID="HiddenField1"
    PopupControlID="Panel1"
    BackgroundCssClass="modalBackground"
    DropShadow="true"
    OkControlID="" 
    OnOkScript="ok()"  
    CancelControlID="btnFechar">
</cc1:ModalPopupExtender>

<asp:Panel ID="Panel1" runat="server" CssClass="modalPopup" Style="display: table" Height="300px" Width="600px" >            
    <table border="1" style="width:600px; height:300px;" >
        <tr>
            <th>Validação</th>
        </tr>
        <tr>
            <td align="center" >
                <asp:ListBox ID="ListBox1" runat="server" Width="590px" ForeColor="Red" Height="236px"></asp:ListBox>
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:Button ID="btnFechar" runat="server" Text="Fechar" Width="70px" CausesValidation="False" />
            </td>                    
        </tr>
    </table>
</asp:Panel>
