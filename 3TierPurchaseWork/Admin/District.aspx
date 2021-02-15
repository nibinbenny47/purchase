<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="District.aspx.cs" Inherits="_3TierPurchaseWork.Admin.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      Name:<asp:TextBox ID="txtName" runat="server" ></asp:TextBox><br />
    <asp:Button runat="server" ID="btnSave" Text="Save" OnClick="btnSave_Click"/><br />
    <asp:Repeater runat="server" ID="rptrDistrict" OnItemCommand="rptrDistrict_ItemCommand">
        <HeaderTemplate>
            <table border ="1">
                <tr>
                    <td>
                        Name
                    </td>
                    <td>
                        Actions
                    </td>
                    
                </tr>
          
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td>
                     <%#Eval("district_name") %>
                </td>
          
            
                <td>
            <asp:LinkButton runat="server" ID="lktbtnDelete" CommandArgument='<%#Eval("district_id") %>' CommandName="deleteDistrict">Delete</asp:LinkButton>
             </td>
                    <td>
                <asp:LinkButton runat="server" ID="lkbtnEdit" CommandArgument='<%#Eval("district_id") %>' CommandName="editDistrict">Edit</asp:LinkButton>
            </td>
              </tr>
               
           
        </ItemTemplate>
        <FooterTemplate>
              </table>
        </FooterTemplate>

    </asp:Repeater>
</asp:Content>
