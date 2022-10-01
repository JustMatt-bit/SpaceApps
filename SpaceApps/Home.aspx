<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="SpaceApps.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="styles/styles.css" />
</head>
<body>
     <video autoplay muted loop id="background-video">
     <source src="styles/gif" type="video/mp4"> Your browser does not support HTML5 video.
    </video>
   <div class="box">
    <form name="search" runat="server">
        <input type="text" class="input" name="txt" onmouseout="this.value = ''; this.blur();">
    </form>
    <i class="fas fa-search"></i>

</div>
<a href="https://www.youtube.com/c/ShortCode" target="_blank" id="ytb">
<i class="fab fa-youtube"> </i>
</a>


</body>
</html>
