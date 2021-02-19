<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="PurchaseWholesale.aspx.cs" Inherits="_3TierPurchaseWork.Admin.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      Invoice:
            <asp:TextBox ID="txtInvoice" runat="server"></asp:TextBox><br />
            Supplier:
            <asp:DropDownList runat="server" ID="ddlSupplier" AutoPostBack="true"  OnSelectedIndexChanged="ddlSupplier_SelectedIndexChanged" >
                
            </asp:DropDownList><br />
            Date:
            <asp:TextBox ID="txtDate" runat="server" TextMode="Date"></asp:TextBox><br />
            Item:
            <asp:DropDownList ID="ddlItem" runat="server" >

            </asp:DropDownList><br />
            Quantity:
            <asp:TextBox ID="txtQuantity" runat="server"></asp:TextBox><br />
            Rate:
            <asp:TextBox ID="txtRate" runat="server"></asp:TextBox><br />
            <asp:Button  runat="server" ID="btnAdd" Text="Add" OnClick="btnAdd_Click1" />
            <asp:Button runat="server" ID="btnClear" Text="Clear" OnClick="btnClear_Click" />
            <asp:GridView runat="server" ID="grdPurchase" ShowFooter="true" >
            
            </asp:GridView><br />
            GrandTotal:<asp:TextBox ID="txtGrandTotal" runat="server"></asp:TextBox><br />
            <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click"/>
</asp:Content>
