<%@ Page Title="" Language="C#" MasterPageFile="~/masterpage.Master" AutoEventWireup="true" CodeBehind="ManageProduct.aspx.cs" Inherits="LOkopedia.View.ManageProduct" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="mt-4 ml-3">
        <asp:Button ID="insertBtn" OnClick="insertBtn_Click" Font-Bold="true" CssClass="btn btn-primary" Width="150" runat="server" Text="Insert Product" />
    </div>
    <%if (flag == 1) {%>
    <div class="container p-5 mt-3 border shadow">
        <div class="text-right">
             <asp:Button ID="close" OnClick="close_Click" CssClass="font-weight-bold btn" Font-Bold="true" ForeColor="Gray" Font-Size="10" runat="server" Text="X" />
            </div>
        <center>
        <asp:Label ID="ads" Font-Bold="true" Font-Size="Larger" runat="server">Insert Product</asp:Label>
        <div class="mt-3">
            <input id="productName" class="card p-2" style="width:20vw;" placeholder="Product Name" type="text" runat="server" />
        </div>
        <div class="mt-3">
            <input id="productPrice" class="card p-2" style="width:20vw;" placeholder="Product Price" type="number" runat="server" />
        </div>
        <div class="mt-3">
            <textarea id="productDescription" class="card p-2" style="width:20vw; height:15vh;" placeholder="Product Description" rows="2" cols="20" runat="server"></textarea>
        </div>
        <div class="mt-3 ml-5">
            <div class="container-fluid row pb-3 justify-content-center ml-5 pl-4">
                <asp:DropDownList ID="DropDownList1" Width="110" CssClass="btn-success btn ml-5" runat="server">
                    <asp:ListItem Value="0" Text="Category"></asp:ListItem>
                    <asp:ListItem Value="1" Text="Beverages"></asp:ListItem>
                    <asp:ListItem Value="2" Text="Fashion"></asp:ListItem>
                    <asp:ListItem Value="3" Text="Electronic"></asp:ListItem>
                    <asp:ListItem Value="4" Text="Beauty"></asp:ListItem>
                </asp:DropDownList>
                <div class="col-6">
                    <asp:FileUpload ID="productImage" CssClass="btn-block ml-5" runat="server"></asp:FileUpload>
                </div>
            </div>
             <asp:Label ID="errorMsg" runat="server" CssClass="font-weight-bold" ForeColor="Red" Text=""></asp:Label>
        </div>
             <asp:Button ID="addBtn" CssClass="btn-success font-weight-bold btn mt-3" OnClick="addBtn_Click" Font-Bold="true" Width="110" ForeColor="White" Font-Size="10" runat="server" Text="Add" />
        </center>
    </div>
    <%}%>

    <%if (count > 0)
        {%>
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
                            <input id="manageBtn" class="btn-outline-success font-weight-bold btn mt-1" onclick="goToManage(<%#Eval("ProductId")%>)" type="button" value="Manage" />
                    </div>
                </div>
        </ItemTemplate>
    </asp:ListView>
            </div>
    </div>
    <%}%>
    <%else{ %>
            <div class="container text-center font-weight-bold mt-5" style="min-height:70vh; font-size:30px;">
                <br /><br /><br /><br /><br /><br /><br />
                Your have no product !
        </div>
    <%} %>


    <script>
        function goToManage(a) {
            var temp = "Manage.aspx?id="
            var loc = temp + a;
            location.href = loc;
        }
    </script>
</asp:Content>
