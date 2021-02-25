<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="PurchaseWholesale.aspx.cs" Inherits="_3TierPurchaseWork.Admin.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td>
                Invoice:
                </td>
            <td>
                 <asp:TextBox ID="txtInvoice" runat="server"></asp:TextBox><br />
            </td>
           
            
            
        </tr>
        <tr>
            <td>
                 Supplier:
                </td>
            <td>
                  <asp:DropDownList runat="server" ID="ddlSupplier" AutoPostBack="true"  OnSelectedIndexChanged="ddlSupplier_SelectedIndexChanged" >
                
            </asp:DropDownList>
            </td>
          
            
        </tr>
        <tr>
            <td>
                Date:
                </td>
            <td>
                <asp:TextBox ID="txtDate" runat="server" TextMode="Date"></asp:TextBox><br />
            </td>
            
            
        </tr>
        <tr>
            <td>
                 Item:
                     </td>
            <td>
                 <asp:DropDownList ID="ddlItem" runat="server" >

            </asp:DropDownList>
       
            </td>
           
        </tr>
        <tr>
            <td>
                 Quantity:
                 </td>
            <td>
            <asp:TextBox ID="txtQuantity" runat="server"></asp:TextBox><br />

            </td>
           
        </tr>
        <tr>
            <td>
                  
           
            Rate:
                 </td>
            <td>
                 <asp:TextBox ID="txtRate" runat="server"></asp:TextBox><br />
            </td>
           
           
        </tr>
        <tr>
            <td>
                 <asp:Button  runat="server" ID="btnAdd" Text="Add" OnClick="btnAdd_Click" />
            </td>
        </tr>
        <tr>
            <td>
                 GrandTotal:<asp:TextBox ID="txtGrandTotal" runat="server"></asp:TextBox><br />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
            </td>
        </tr>
        <tr>
            <td>
                 <asp:Label ID="lblAvailQnty" runat="server" Visible="false"></asp:Label>
            <asp:Label ID="lblGivenQnty" runat="server" Visible="false"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                 <asp:GridView runat="server" ID="grdPurchase" AutoGenerateColumns="false" OnRowDataBound="grdPurchase_RowDataBound1">
                <Columns>
                   

                        <asp:TemplateField HeaderText="Item" >
                            <ItemTemplate>
                                <asp:Label ID="lblItem" runat="server" Text='<%#Eval("Item") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                     <asp:TemplateField HeaderText="Quantity">
                            <ItemTemplate>
                                <asp:Label ID="lblQuantity" runat="server" Text='<%#Eval("Quantity") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                     <asp:TemplateField HeaderText="Rate">
                            <ItemTemplate>
                                <asp:Label ID="lblRate" runat="server" Text='<%#Eval("Rate") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    <asp:TemplateField HeaderText="Total">
                            <ItemTemplate>
                                <asp:Label ID="lblTotal" runat="server" Text='<%#Eval("Total") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                     <%--<asp:TemplateField HeaderText="Delete">
                            <ItemTemplate>
                                <asp:LinkButton ID="lkbtnDelete" runat="server" CommandArgument='<%# Eval("d") %>' CommandName="del">Delete</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>--%>
                
                </Columns>
               
            
            </asp:GridView>
            </td>
        </tr>
      
       
     
    </table>
</asp:Content>
      
           
            
         
           
           
          
           
            
        
           
           
           

