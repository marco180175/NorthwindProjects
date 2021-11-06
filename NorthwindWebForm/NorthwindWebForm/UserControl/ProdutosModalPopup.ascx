<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProdutosModalPopup.ascx.cs" Inherits="NorthwindWebForm.UserControl.ProdutosModalPopup" %>
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
    CancelControlID="HiddenField1">
</cc1:ModalPopupExtender>

<asp:Panel ID="Panel1" runat="server" CssClass="modalPopup" Style="display: table" Height="500px" Width="300px" >            
    <table border="1" style="height:500px; width:300px;" >
        <tr>
            <th colspan="2" height="28px">Lista de produtos</th>
        </tr>
        <tr>
            <td valign="top" colspan="2">
                <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" 
                    OnPageIndexChanging="GridView1_PageIndexChanging" 
                    OnRowCommand="GridView1_RowCommand" 
                    OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
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
                                <asp:LinkButton ID="btSelect" runat="server" CausesValidation="false" CommandName="Select"
                                        Text="Select" CommandArgument='<%# Eval("ProductID") %>' />
                            </ItemTemplate>                                            
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td align="center" height="28px">
                <asp:Button ID="btnSelecionar" runat="server" Text="Selecionar" Width="70px" CausesValidation="False" OnClick="btnSelecionar_Click" />
            </td>                    
            <td align="center" height="28px">
                <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" Width="70px" CausesValidation="False" OnClick="btnCancelar_Click" />
            </td> 
        </tr>
    </table>
</asp:Panel>