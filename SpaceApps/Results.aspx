<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Results.aspx.cs" Inherits="SpaceApps.Results" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" type="text/css" href="styles/results_style/styles.css" />
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.0.0/dist/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div id="logo">
            
        </div>
        <div id="label">
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        </div>
            <div id="parent">
                <div class="photos" id="photos1">
                 <asp:GridView ID="GridView1" runat="server"></asp:GridView>
            </div>
            <div  class="photos" id="photos2">
                <asp:GridView ID="GridView2" runat="server"></asp:GridView>
            </div>
        </div>
        
        <div id="button_container" >
            <asp:Button ID="Button1"   class="btn btn-warning btn-lg" runat="server"  Text="Button" />
        </div>
        
    </form>
</body>
</html>
