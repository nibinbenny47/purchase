<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Place.aspx.cs" Inherits="_3TierPurchaseWork.Admin.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     District:<asp:DropDownList ID="ddlDistrict" runat="server" ></asp:DropDownList><br />
     Name:<asp:TextBox ID="txtName" runat="server" ></asp:TextBox ><br />
    <asp:Button runat="server" ID="btnSave" Text="Save" OnClick="btnSave_Click" /><br />
    <asp:Repeater runat="server" ID="rptrPlace" OnItemCommand="rptrPlace_ItemCommand" >

   
    
        <HeaderTemplate>
            <table border ="1">
                <tr>
                    <td>
                       Place Name
                    </td>
                    <td>
                       District Name
                    </td>
                    <td>
                        Actions
                    </td>
                    
                </tr>
          
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td>
                     <%#Eval("place_name") %>
                </td>
                <td>
                     <%#Eval("district_name") %>
                </td>
          
            
                <td>
            <asp:LinkButton runat="server" ID="lktbtnDelete" CommandArgument='<%#Eval("place_id") %>' CommandName="deletePlace">Delete</asp:LinkButton>
             </td>
                    <td>
                <asp:LinkButton runat="server" ID="lkbtnEdit" CommandArgument='<%#Eval("place_id") %>' CommandName="editPlace">Edit</asp:LinkButton>
            </td>
              </tr>
               
           
        </ItemTemplate>
        <FooterTemplate>
              </table>
        </FooterTemplate>
         </asp:Repeater>
</asp:Content>
