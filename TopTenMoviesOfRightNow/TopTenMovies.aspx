<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TopTenMovies.aspx.cs" Inherits="TopTenMoviesOfRightNow.TopTenMovies" %>
<%@ Register TagPrefix="ttm" TagName="MovieSearch" Src="~/Controls/MovieSearch.ascx" %>
<%@ Register TagPrefix="ttm" TagName="UsersTopTenMovies" Src="~/Controls/UsersTopTenMovies.ascx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>
    </title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Image ID="imgTheMovieDB" runat="server" ImageUrl="https://www.themoviedb.org/assets/static_cache/9b3f9c24d9fd5f297ae433eb33d93514/images/v4/logos/408x161-powered-by-rectangle-green.png" />
    </div>
    <div>
        <ttm:MovieSearch runat="server" id="movieSearch"></ttm:MovieSearch>
        <ttm:UsersTopTenMovies runat="server" ID="usersTopTenMovies" />
    </div>
    </form>
</body>
</html>
