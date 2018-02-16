<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UsersTopTenMovies.ascx.cs" Inherits="TopTenMoviesOfRightNow.UserControls.UsersTopTenMovies" %>
<asp:Repeater ID="rptTopTenMovies" runat="server">
    <HeaderTemplate>
        <table>
    </HeaderTemplate>
    <ItemTemplate>
        <tr>
            <td>
                <asp:Label ID="lblRank" Text='<%# Container.ItemIndex + 1%>' runat="server"></asp:Label>
                <asp:Label ID="lblTitle" Text='<%# DataBinder.Eval(Container.DataItem, "Title") %>' runat="server"></asp:Label>   
                <asp:LinkButton ID="btnRemove" runat="server" Text="Remove" OnClick="btnRemove_Click"></asp:LinkButton> 
          </td>
        </tr>
    </ItemTemplate>
    <FooterTemplate>
        </table>
        <asp:Button ID="btnSubmitTopTen" runat="server" Text="Submit the Top Ten Movies From Your List" OnClick="btnSubmitTopTen_Click" />
    </FooterTemplate>
</asp:Repeater>
