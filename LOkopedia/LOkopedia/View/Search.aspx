<%@ Page Title="" Language="C#" MasterPageFile="~/masterpage.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="LOkopedia.View.Search" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
            <div class="container mt-5 mb-5">
            <div class="row">
    <%for (int i = 0; i < 16; i++)
        {%>
                    <div class="card col-3 text-center">
                        <div class="card-body">
                                <img alt="" width="210" height="230" src="https://redbottle.com.au/wp-content/uploads/2019/12/jinro-chamisul-soju.jpg"/>
                                <div class="font-weight-bold">Soju</div>
                                <div class="font-weight-bold">₩ 120</div>
                        </div>
                    </div>
    <%} %>
            </div>
    </div>
</asp:Content>
