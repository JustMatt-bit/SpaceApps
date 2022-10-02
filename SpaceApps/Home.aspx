<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="SpaceApps.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="styles/styles.css" />
   
</head>
<body>
    <video autoplay muted loop id="background-video">
        <source src="styles/gif" type="video/mp4">
        Your browser does not support HTML5 video.
    </video>

    <!--bandau> <div class="text">Caption Text</div></!-->
    <div class="slideshow-container">

        <!-- Full-width images with number and caption text 512 -->
        <div class="mySlides fade">
            <img src="images/1.jpg" style="width: 512px">
        </div>
        <div class="mySlides fade">
            <img src="images/2.jpg" style="width: 512px">
        </div>
        <div class="mySlides fade">
            <img src="images/3.jpg" style="width: 512px">
        </div>
        <div class="mySlides fade">
            <img src="images/4.jpg" style="width: 512px">
        </div>
        <div class="mySlides fade">
            <img src="images/5.jpg" style="width: 512px">
        </div>
        <div class="mySlides fade">
            <img src="images/6.jpg" style="width: 512px">
        </div>
        <div class="mySlides fade">
            <img src="images/7.jpg" style="width: 512px">
        </div>
        <div class="mySlides fade">
            <img src="images/8.jpg" style="width: 512px">
        </div>
        <div class="mySlides fade">
            <img src="images/9.jpg" style="width: 512px">
        </div>
        <div class="mySlides fade">
            <img src="images/10.jpg" style="width: 512px">
        </div>

        <div class="mySlides fade">
            <img src="images/11.jpg" style="width: 512px">
        </div>
        <div class="mySlides fade">
            <img src="images/12.jpg" style="width: 512px">
        </div>
        <div class="mySlides fade">
            <img src="images/13.jpg" style="width: 512px">
        </div>
        <div class="mySlides fade">
            <img src="images/14.jpg" style="width: 512px">
        </div>
        <div class="mySlides fade">
            <img src="images/15.jpg" style="width: 512px">
        </div>
        <div class="mySlides fade">
            <img src="images/16.jpg" style="width: 512px">
        </div>
        <div class="mySlides fade">
            <img src="images/17.jpg" style="width: 512px">
        </div>
        <div class="mySlides fade">
            <img src="images/18.jpg" style="width: 512px">
        </div>
        <div class="mySlides fade">
            <img src="images/19.jpg" style="width: 512px">
        </div>
        <div class="mySlides fade">
            <img src="images/20.jpg" style="width: 512px">
        </div>
        <!-- Next and previous buttons -->
        <a class="prev" onclick="plusSlides(-1)">&#10094;</a>
        <a class="next" onclick="plusSlides(1)">&#10095;</a>
    </div>

    <script>
        let slideIndex = 1;



showSlides(slideIndex);

function plusSlides(n) {
    showSlides(slideIndex += n);
    document.getElementById('ValueHiddenField').value = slideIndex;
}

function currentSlide(n) {
  showSlides(slideIndex = n);
}

function showSlides(n) {



  let i;
  let slides = document.getElementsByClassName("mySlides");
 
  
  if (n > slides.length) {slideIndex = 1}    
  if (n < 1) {slideIndex = slides.length}
// patikriname ar glima perjungti img 
  for (i = 0; i < slides.length; i++) {
    slides[i].style.display = "none";  
  }
    slides[slideIndex - 1].style.display = "block";
    document.getElementById('ValueHiddenField').value = slideIndex;
}
    </script>
    <style>
    .grid-container {
        display: grid;
        gap: 20px 200px;
    }

    .item1 {
        grid-column-start: 1;
        grid-column-end: 3;
    }

    }
    </style>

    <form name="search" runat="server">
        <asp:HiddenField ID="ValueHiddenField" Value="1" runat="server" />

        <div class="grid-container">
            <div class="box">

                <input id="inputBoxPrompt" type="text" class="input" name="txt" runat="server">

                <i class="fas fa-search"></i>


            </div>
            <div class="box" runat="server">
                <asp:Button class="button-6" ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
            </div>
            <div class="item7">
                <br />
                <asp:Label Style=" display: block; text-align: center" ID="Label1" runat="server" ForeColor="White" Text="Label"></asp:Label>
            </div>
        </div>

    </form>
    <a href="https://www.youtube.com/c/ShortCode" target="_blank" id="ytb">
        <i class="fab fa-youtube"></i>
    </a>


</body>
</html>
