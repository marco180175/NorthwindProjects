<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShoppingItem.aspx.cs" Inherits="NorthwindWebForm.ShoppingItem" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    
    <form id="form1" runat="server">
        <asp:Button ID="btAdd" runat="server" Text="Add" Width="95px" OnClick="Button1_Click" />
        <div>
            <asp:GridView ID="GridView1" runat="server"  AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand" OnRowDeleting="GridView1_RowDeleting" >
                <Columns>
                    <asp:TemplateField HeaderText="ShoppingCartItemID">                        
                                <ItemTemplate>
                                    <asp:Label ID="lbId1" runat="server" Text='<%#Eval("ShoppingCartItemID") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                    <asp:TemplateField HeaderText="ShoppingCartID">                        
                                <ItemTemplate>
                                    <asp:Label ID="lbId2" runat="server" Text='<%#Eval("ShoppingCartID") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                    <asp:TemplateField HeaderText="ProductID">                        
                                <ItemTemplate>
                                    <asp:Label ID="lbId3" runat="server" Text='<%#Eval("ProductID") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                    <asp:TemplateField HeaderText="Quantity">                        
                                <ItemTemplate>
                                    <asp:Label ID="lbId4" runat="server" Text='<%#Eval("Quantity") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                    <asp:TemplateField HeaderText="UnitPrice">                        
                                <ItemTemplate>
                                    <asp:Label ID="lbId5" runat="server" Text='<%#Eval("UnitPrice") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                    <asp:TemplateField HeaderText="Total">                        
                                <ItemTemplate>
                                    <asp:Label ID="lbId6" runat="server" Text='<%#Eval("Tolal") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField ShowHeader="False">
                                <ItemTemplate>                             
                                    <asp:Button ID="btEdit" runat="server" CausesValidation="false" CommandName="Edit"
                                            Text="Edit" CommandArgument='<%# Eval("ShoppingCartItemID") %>' />
                                </ItemTemplate>                                            
                            </asp:TemplateField>
                            <asp:TemplateField ShowHeader="False">
                                <ItemTemplate>                             
                                    <asp:Button ID="btDelete" runat="server" CausesValidation="false" CommandName="Delete"
                                        OnClientClick ="if (!window.confirm('Confirma a exclusão deste registro ?')) return false;"
                                        Text="Delete" CommandArgument='<%# Eval("ShoppingCartItemID") %>' />
                                </ItemTemplate>                                            
                            </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        <asp:Button ID="btBack" runat="server" OnClick="Button1_Click1" Text="Back" Width="87px" />
    </form>
    </body>
</html>
