<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MovieSearch.ascx.cs" Inherits="TopTenMoviesOfRightNow.UserControls.MovieSearch" %>

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
    <tr>
        <td>        
            <asp:Repeater ID="movieSearchResults"  runat="server">
                <HeaderTemplate>
                    <div style="max-height: 500px; max-width: 500px; width: 500px; overflow: auto;">
                        <table>
                            <tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td>
                            <asp:CheckBox ID="ckbChooseMovie" runat="server" />
                            <asp:Label ID="lblTitle" Text='<%# DataBinder.Eval(Container.DataItem, "Title") %>' runat="server"></asp:Label>                 
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Image ID="imgLogo" ImageUrl='<%# "https://image.tmdb.org/t/p/w154" + DataBinder.Eval(Container.DataItem, "ImagePath") %>' runat="server" />
                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                            </tr>
                        </table>
                    </div>
                </FooterTemplate>
            </asp:Repeater>                   
        </td>
    </tr>
    <tr>
        <td>
            <asp:LinkButton ID="btnPrevious" runat="server" OnClick="btnPrevious_Click" Text="Previous"></asp:LinkButton>
        </td>
        <td>
            <asp:LinkButton ID="btnNext" runat="server" OnClick="btnNext_Click" Text="Next"></asp:LinkButton>
        </td>
        <td>
            <asp:Button ID="btnAddToList" Text="Add Movies to List" runat="server" OnClick="btnAddToList_Click" />
        </td>
    </tr>
</table>

