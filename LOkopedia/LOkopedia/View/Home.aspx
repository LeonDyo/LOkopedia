<%@ Page Title="" Language="C#" MasterPageFile="~/masterpage.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="LOkopedia.View.Guest" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="min-height:100%; position:relative;" class="container">
        <div class="d-flex justify-content-center">
            <div id="carouselExampleIndicators" class="carousel slide" data-ride="carousel">
          <ol class="carousel-indicators">
            <li data-target="#carouselExampleIndicators" data-slide-to="0" class="active"></li>
            <li data-target="#carouselExampleIndicators" data-slide-to="1"></li>
            <li data-target="#carouselExampleIndicators" data-slide-to="2"></li>
            <li data-target="#carouselExampleIndicators" data-slide-to="3"></li>
          </ol>
          <div class="carousel-inner">
            <div class="carousel-item active">
              <img class="d-block" width="1500" height="300" src="https://pbs.twimg.com/media/DxARZjEWoAA0In_.jpg" alt="First slide">
            </div>
            <div class="carousel-item">
              <img class="d-block" width="1500" height="300" src="https://naturerepublickh.com/wp-content/uploads/2019/04/header_banner.jpg" alt="Second slide">
            </div>
            <div class="carousel-item">
              <img class="d-block" width="1500" height="300" src="https://cdn.shopify.com/s/files/1/2597/8324/files/Hotpot-banner-3402x850.jpg?v=1578783228" alt="Third slide">
            </div>
            <div class="carousel-item">
              <img class="d-block" width="1500" height="300" src="https://static-sg.zacdn.com/cms/DY/Mar19/HCONNECT_BANNER_SG1.jpg" alt="Third slide">
            </div>
          </div>
          <a class="carousel-control-prev" href="#carouselExampleIndicators" role="button" data-slide="prev">
            <span class="carousel-control-prev-icon" aria-hidden="true"></span>
            <span class="sr-only">Previous</span>
          </a>
          <a class="carousel-control-next" href="#carouselExampleIndicators" role="button" data-slide="next">
            <span class="carousel-control-next-icon" aria-hidden="true"></span>
            <span class="sr-only">Next</span>
          </a>
        </div>
      </div>
    </div>

    <div class="container mt-5 mb-5 shadow" style="min-height:65vh;">
            <div class="row">
    <asp:ListView ID="ListView1" runat="server">
        <ItemTemplate>
                <div class="card col-3 text-center">
                    <div class="card-body">
                        <a style="color:black; text-decoration:none" href="ProductDetail.aspx?id=<%#Eval("ProductId")%>">
                            <img alt="" width="210" height="230" src="<%#Eval("ProductImage")%>"/>
                            <div class="font-weight-bold"><%#Eval("ProductName")%></div>
                        </a>
                            <div class="font-weight-bold">₩ <%#Eval("ProductPrice")%></div>
                    </div>
                </div>
        </ItemTemplate>
    </asp:ListView>
            </div>
    </div>
</asp:Content>
