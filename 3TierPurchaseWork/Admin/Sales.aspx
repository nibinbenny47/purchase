<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Sales.aspx.cs" Inherits="_3TierPurchaseWork.Admin.WebForm4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       Bill NO:
            <asp:TextBox ID="txtInvoice" runat="server"></asp:TextBox><br />
            
            
                
            
            Date:
            <asp:TextBox ID="txtDate" runat="server" TextMode="Date"></asp:TextBox><br />
            Item:
            <asp:DropDownList ID="ddlItem" runat="server" >

            </asp:DropDownList><br />
            Quantity:
            <asp:TextBox ID="txtQuantity" runat="server"></asp:TextBox><br />
            Rate:
            <asp:TextBox ID="txtRate" runat="server"></asp:TextBox><br />
            <asp:Button  runat="server" ID="btnAdd" Text="Add" OnClick="btnAdd_Click" />
            <asp:GridView runat="server" ID="grdSales" ShowFooter="true" >
            
            </asp:GridView><br />
            GrandTotal:<asp:TextBox ID="txtGrandTotal" runat="server"></asp:TextBox><br />
            <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
            <asp:Label runat="server" ID="lblQuantity" Visible="false"></asp:Label>
            <asp:Label runat="server" ID="lblsaleQnty" Visible="false"></asp:Label>
            
            

</asp:Content>
