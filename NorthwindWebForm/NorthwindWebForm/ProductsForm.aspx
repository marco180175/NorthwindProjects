<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductsForm.aspx.cs" Inherits="NorthwindWebForm.ProductTable" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <table border="1">
        <tr>
            <td>
                <table border="1" width=100%>
                    <tr>
                        <td>
                            <asp:Button ID="Button1" runat="server" Text="Create" OnClick="Button1_Click" />
                        </td>
                        <td>Filter Name</td>
                        <td>
                            <asp:DropDownList ID="ddlFilterName" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlFilterName_SelectedIndexChanged"></asp:DropDownList>
                        </td>
                        <td>Filter Value</td>
                        <td>
                            <asp:DropDownList ID="ddlFilterValue" runat="server"></asp:DropDownList>
                        </td>
                        <td>
                            <asp:Button ID="btnFilter" runat="server" Text="Filter" OnClick="btnFilter_Click" />
                        </td>
                    </tr>
                </table>
                
            </td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand">
        <Columns>
            <asp:BoundField DataField="ProductID" HeaderText="ProductID" InsertVisible="False" ReadOnly="True" SortExpression="ProductID" />
            <asp:BoundField DataField="ProductName" HeaderText="ProductName" SortExpression="ProductName" />
            <asp:BoundField DataField="Supplier" HeaderText="Supplier" SortExpression="Supplier" />
            <asp:BoundField DataField="Category" HeaderText="Category" SortExpression="Category" />            
            <asp:BoundField DataField="UnitPrice" HeaderText="UnitPrice" SortExpression="UnitPrice" />
            <asp:BoundField DataField="UnitsInStock" HeaderText="UnitsInStock" SortExpression="UnitsInStock" />
            <asp:BoundField DataField="UnitsOnOrder" HeaderText="UnitsOnOrder" SortExpression="UnitsOnOrder" />            
            <asp:CheckBoxField DataField="Discontinued" HeaderText="Discontinued" SortExpression="Discontinued" />
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>                             
                    <asp:LinkButton ID="btEdit" runat="server" CausesValidation="false" CommandName="Edit"
                            Text="Edit" CommandArgument='<%# Eval("ProductID") %>' />
                </ItemTemplate>                                            
            </asp:TemplateField>
                                            
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>                             
                    <asp:LinkButton ID="btDelete" runat="server" CausesValidation="false" CommandName="Delete"
                        OnClientClick ="if (!window.confirm('Confirms the deletion of this record ?')) return false;"
                        Text="Delete" CommandArgument='<%# Eval("ProductID") %>' />
                </ItemTemplate>                                            
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
            </td>
        </tr>
    </table>

    
    
    
</asp:Content>
