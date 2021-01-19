<%@ Page Title="" Language="C#" MasterPageFile="~/masterpage.Master" AutoEventWireup="true" CodeBehind="ProductDetail.aspx.cs" Inherits="LOkopedia.View.ProductDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-5 shadow">
        <div class="card border-0">
            <div class="row">
                <div class="col-6 p-5">
                    <div class="card">
                        <center>
                            <asp:Image ID="productImage" Width="300" Height="300" CssClass="mt-5 mb-3" runat="server"></asp:Image>
                        </center>
                    </div>
                </div>
                <div class="col-6 p-5">
                    <asp:Label ID="productName" Font-Size="Large" CssClass="font-weight-bold" runat="server"></asp:Label>
                    <div class="row mt-3 ml-0">

                        <asp:Label ID="ratingView" CssClass="pr-2" Font-Size="Medium" runat="server"></asp:Label>
                        <%for (int i = 0; i < getRating(); i++){ %>
                            <asp:Image ID="rate" Width="20" Height="20" ImageUrl="https://www.freepnglogos.com/uploads/star-png/star-vector-png-transparent-image-pngpix-21.png" runat="server"></asp:Image>
                        <%}%>
                        <asp:Label ID="sold" CssClass="ml-3" Font-Size="Medium" runat="server">10000 Products Sold</asp:Label>
                    </div>
                    <div class="row mt-3">
                        <div class="col-4">
                            <asp:Label ID="priceText" Font-Size="Medium" runat="server">Price</asp:Label>
                        </div>
                        <div class="col-7">
                            <asp:Label ID="productPrice" Font-Size="Medium" runat="server"></asp:Label>
                        </div>
                    </div>
                    <div class="row mt-3">
                        <div class="col-4">
                            <asp:Label ID="dateText" Font-Size="Medium" runat="server">Upload date</asp:Label>
                        </div>
                        <div class="col-7">
                            <asp:Label ID="uploadDate" Font-Size="Medium" runat="server"></asp:Label>
                        </div>
                    </div>
                    <div class="row mt-5">
                        <div class="col-7">
                          <div class="btn-toolbar" role="toolbar" aria-label="Toolbar with button groups">
                          <div class="btn-group me-2" role="group" aria-label="First group">
                              <input id="Button1" class="btn btn-primary" type="button" onclick="decrease()" value="-" />
                           </div>
                              <div class="mt-2">
                                  <asp:TextBox CssClass="border-0 ml-3 text-center" Width="40" ID="quantity" Text="0" ClientIDMode="Static" runat="server"></asp:TextBox>
                              </div>
                          <div class="btn-group me-2 ml-3" role="group" aria-label="Second group">
                              <input id="Button2" class="btn btn-primary" onclick="increment()" type="button" value="+" />
                           </div>
                        </div>
                        </div>
                        <div class="col-5">
                            <asp:Button ID="addBtn" Width="100" OnClick="addBtn_Click" CssClass="btn btn-primary" runat="server" Text="Add" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="container border mt-5">
        <div class="container mt-4">
            <nav class="navbar navbar-expand-lg">
                  <div class="container-fluid">
                    <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarNavAltMarkup" aria-controls="navbarNavAltMarkup" aria-expanded="false" aria-label="Toggle navigation">
                      <span class="navbar-toggler-icon"></span>
                    </button>
                    <div class="collapse navbar-collapse" id="navbarNavAltMarkup">
                      <div class="navbar-nav">
                        <asp:LinkButton ID="descriptionBtn" Font-Bold="true" OnClick="descriptionBtn_Click" ForeColor="Gray" CssClass="nodecoration" runat="server">Description</asp:LinkButton>
                        <asp:LinkButton ID="forumBtn" Font-Bold="true" OnClick="forumBtn_Click" CssClass="nodecoration ml-5" ForeColor="Gray" runat="server">Forum</asp:LinkButton>
                      </div>
                    </div>
                  </div>
            </nav>
        </div>
        <hr />
        <div class="container pb-5">
                <div class="row mt-3">
            <%if (flag == 1) {%>
                    <div class="col-6">
                        <asp:Label ID="description" Font-Size="Medium" runat="server"></asp:Label>
                    </div>
            <%}%>
            <%else if (flag == 2) {%>
              <%for (int i = 0; i < 5; i++){%>
               <div class="col-12 mt-5">
                   <div class="card bg-light">
                       <div class="row">
                           <div class="col-1">
                               <asp:ImageButton ID="ImageButton1" Width="40" Height="35" CssClass="mt-2 ml-5 rounded-circle" ImageUrl="https://images.soco.id/852-nam-do-san-2.jpg.jpg" runat="server" />
                           </div>
                           <div class="col-5 m-3">
                                <asp:Label ID="userName" Font-Bold="true" Font-Size="Medium" runat="server">Nam Do San</asp:Label>
                           </div>
                       </div>
                   </div>
                   <div class="card border-top-0">
                       <div class="row m-4">
                           <div class="col-12">
                                <asp:Label ID="forum" Font-Bold="true" Font-Size="Medium" runat="server">This PC is really cool and nice ! ! !</asp:Label>
                           </div>
                       </div>
                   </div>
               </div>
                    <%}%>
                    
            <div class="col-12 mt-5 mb-5">
                   <div class="card bg-light">
                       <div class="row mt-2">
                           <div class="col-1">
                               <asp:ImageButton ID="ImageButton" Width="40" Height="35" CssClass="mt-2 ml-5 rounded-circle" ImageUrl="https://images.soco.id/852-nam-do-san-2.jpg.jpg" runat="server" />
                           </div>
                           <div class="col-5 m-3">
                                <asp:Label ID="useame" Font-Bold="true" Font-Size="Medium" runat="server">Nam Do San</asp:Label>
                           </div>
                       </div>
                       <div class="pb-4">
                           <asp:TextBox ID="search" CssClass="nav-item nav-link ml-5 mt-2" Height="130" Width="980" runat="server"></asp:TextBox>
                            <asp:Button ID="sendBtn" CssClass="btn btn-primary mt-4 ml-5" Width="100" runat="server" Text="Send" />
                       </div>
                   </div>
              </div>
            <%}%>
                </div>
            </div>
         </div>
        <br /><br />
    <script>
        function increment() {
            var a = parseInt(document.getElementById('quantity').value, 10);
            a = isNaN(a) ? 0 : a;
            a++;
            document.getElementById('quantity').value = a;
            console.log(a)
            console.log(document.getElementById('quantity').value)
        }

        function decrease() {
            var a = parseInt(document.getElementById('quantity').value, 10);
            a = isNaN(a) ? 0 : a;
            if (a != 0) {
                a--;
            }
            document.getElementById('quantity').value = a;
        }

    </script>
</asp:Content>
