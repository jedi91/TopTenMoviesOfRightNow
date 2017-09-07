<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MovieSearch.ascx.cs" Inherits="TopTenMoviesOfRightNow.MovieSearch" %>
<table>
    <tr>
        <td>
            <asp:label ID="lblMovieSearch" CssClass="lblMovieSearch" runat="server" Text="Search For Your Favorite Movies"></asp:label>
        </td>
    </tr>
    <tr>
        <td>
            <asp:TextBox ID="txbMovieSearch" CssClass="lblMovieSearch" runat="server"></asp:TextBox>           
        </td>
        <td>
            <asp:Button ID="btnSearch" CssClass="btnSearch" Text="Search" OnClick="btnSearch_Click" runat="server" />
        </td>
    </tr>  
    <asp:Repeater ID="movieSearchResults" runat="server">
        <ItemTemplate>
            <tr>
                <td>
                    <asp:CheckBox ID="ckbChooseMovie" runat="server" />
                    <asp:Label ID="lblTitle" Text='<%# DataBinder.Eval(Container.DataItem, "Title") %>' runat="server"></asp:Label>
                    <asp:Image ID="imgLogo" ImageUrl='<%# DataBinder.Eval(Container.DataItem, "ImagePath") %>' runat="server" />
                </td>
            </tr>
        </ItemTemplate>
    </asp:Repeater> 
    <tr>
        <td>
            <asp:LinkButton ID="btnPrevious" runat="server" OnClick="btnPrevious_Click" Text="Previous"></asp:LinkButton>
        </td>
        <td>
            <asp:LinkButton ID="btnNext" runat="server" OnClick="btnNext_Click" Text="Next"></asp:LinkButton>
        </td>
    </tr>
</table>
