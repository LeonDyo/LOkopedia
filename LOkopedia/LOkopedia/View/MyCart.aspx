<%@ Page Title="" Language="C#" MasterPageFile="~/masterpage.Master" AutoEventWireup="true" CodeBehind="MyCart.aspx.cs" Inherits="LOkopedia.View.MyCart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-5">
        <%for (int i = 0; i < 5; i++)
            {%>
        <div class="row border mb-3 shadow">
            <div class="col-2">
                <asp:Image ID="productImage" Width="100" Height="100" ImageUrl="/Upload/image1.jpg" CssClass="mt-3 ml-5" runat="server"></asp:Image>
            </div>
            <div class="col-8">
                <div class="mt-4">
                    <asp:Label ID="productName" Font-Bold="true" Font-Size="Large" runat="server">Soju</asp:Label>
                </div>
                <div>
                    <asp:Label ID="productPrice" Font-Bold="true" Font-Size="Large" runat="server">₩ 12</asp:Label>
                </div>
                <div>
                    <asp:Label ID="quantity" Font-Bold="true" Font-Size="Large" runat="server">Quantity: 19</asp:Label>
                </div>
            </div>
            <div class="col-2">
                <asp:Button ID="deleteBtn" CssClass="btn-danger font-weight-bold btn mt-5" Font-Bold="true" Width="110" ForeColor="White" Font-Size="10" runat="server" Text="Remove" />
            </div>
        </div>
        <%}%>
    </div>
</asp:Content>
