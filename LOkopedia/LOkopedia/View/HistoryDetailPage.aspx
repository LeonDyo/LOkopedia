<%@ Page Title="" Language="C#" MasterPageFile="~/masterpage.Master" AutoEventWireup="true" CodeBehind="HistoryDetailPage.aspx.cs" Inherits="LOkopedia.View.HistoryDetailPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-5" style="min-height:70vh;">
            <asp:ListView ID="ListView1" runat="server">
                <ItemTemplate>
        <div class="row border mb-3 shadow">
                    <div class="col-2">
                        <img Width="100" Height="100" src="<%#Eval("ProductImage")%>" class="mt-3 ml-5"></img>
                    </div>
                    <div class="col-8 font-weight-bold">
                        <div class="mt-4">
                            <p><%#Eval("ProductName")%></p>
                            <p>₩ <%#Eval("ProductPrice")%></p>
                            <p>Quantity: <%#Eval("Quantity")%></p>
                         </div>
                    </div>
        </div>
                </ItemTemplate>
            </asp:ListView>
    </div>
    <br />
</asp:Content>
