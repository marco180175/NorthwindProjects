<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Shopping.aspx.cs" Inherits="NorthwindWebForm.Shopping" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style type="text/css">
        .WordWrap
        {
            width: 100%;
            word-break: break-all;
        }
        .WordBreak
        {
            width: 100px;
            overflow: hidden;
            text-overflow: ellipsis;
        }
    </style>
    <table id="tblMain" border="1">
        <tr>
            <td>
                <asp:Button ID="btAdd" runat="server" Text="Add" OnClick="btAdd_Click" Width="100px" />
            </td>
        </tr>
        <tr>
            <td>
                <div class="WordWrap">
                    <asp:GridView ID="GridView1"   runat="server" CssClass="gridview"  AutoGenerateColumns="False" 
                        
                         CellPadding="1" CellSpacing="1" OnRowCommand="GridView1_RowCommand" OnRowDeleting="GridView1_RowDeleting">
                        <Columns>
                            <asp:TemplateField HeaderText="ShoppingCartID">                        
                                <ItemTemplate>
                                    <asp:Label ID="lbId" runat="server" Text='<%#Eval("ShoppingCartID") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="CustomerID">
                                <ItemTemplate>                               
                                    <asp:Label ID="lbCustomerID" runat="server" Text='<%#Eval("CustomerID") %>'></asp:Label>
                                </ItemTemplate>                                            
                            </asp:TemplateField> 
                            
                            <asp:TemplateField HeaderText="PurchaseDate">
                                <ItemStyle Width="10%" />
                                <ItemTemplate>                             
                                    <asp:Label ID="lbDate" runat="server" Text='<%#Eval("PurchaseDate","{0:dd/MM/yyyy}") %>'></asp:Label>
                                </ItemTemplate>                                            
                            </asp:TemplateField>  
                            
                            <asp:Boundfield datafield="Description" headertext="Description">
                                <ItemStyle Width="35%" />
                            </asp:Boundfield>                            

                            <asp:TemplateField HeaderText="Count">
                                <ItemTemplate>                             
                                    <asp:Label ID="lbCount" runat="server" Text='<%#Eval("Count") %>'></asp:Label>
                                </ItemTemplate>                                            
                            </asp:TemplateField> 

                            <asp:TemplateField ShowHeader="False">
                                <ItemTemplate>                             
                                    <asp:Button ID="btEdit" runat="server" CausesValidation="false" CommandName="Edit"
                                            Text="Edit" CommandArgument='<%# Eval("ShoppingCartID") %>' />
                                </ItemTemplate>                                            
                            </asp:TemplateField>
                
                            <asp:TemplateField ShowHeader="False">
                                <ItemTemplate>                             
                                    <asp:Button ID="btList" runat="server" CausesValidation="false" CommandName="List"
                                            Text="List" CommandArgument='<%# Eval("ShoppingCartID") %>' />
                                </ItemTemplate>                                            
                            </asp:TemplateField>

                            <asp:TemplateField ShowHeader="False">
                                <ItemTemplate>                             
                                    <asp:Button ID="btDelete" runat="server" CausesValidation="false" CommandName="Delete"
                                        OnClientClick ="if (!window.confirm('Confirms the deletion of this record ?')) return false;"
                                        Text="Delete" CommandArgument='<%# Eval("ShoppingCartID") %>' />
                                </ItemTemplate>                                            
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView> 
                </div>
            </td>
        </tr>
    </table>
    
    
</asp:Content>
