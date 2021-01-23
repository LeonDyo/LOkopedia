<%@ Page Title="" Language="C#" MasterPageFile="~/masterpage.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="LOkopedia.View.Search" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%if (flag > 0)
        {%>
    <div class="container mt-5 mb-5 shadow" style="min-height:66vh;">
            <div class="row">
    <asp:ListView ID="ListView1" runat="server">
        <ItemTemplate>
                <div class="card col-3 border-0 text-center">
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
    <%} %>
    <%else
        { %>
            <div class="container text-center font-weight-bold mt-5" style="min-height:70vh; font-size:30px;">
                <br /><br /><br /><br /><br /><br /><br />
                Product Not Found !
        </div>
    <%} %>
</asp:Content>
