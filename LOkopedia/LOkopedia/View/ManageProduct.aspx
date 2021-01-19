<%@ Page Title="" Language="C#" MasterPageFile="~/masterpage.Master" AutoEventWireup="true" CodeBehind="ManageProduct.aspx.cs" Inherits="LOkopedia.View.ManageProduct" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="mt-4 ml-3">
        <asp:Button ID="insertBtn" OnClick="insertBtn_Click" Font-Bold="true" CssClass="btn btn-primary" Width="150" runat="server" Text="Insert Product" />
    </div>
    <%if (flag == 1){%>
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
            <input id="productPrice" class="card p-2" style="width:20vw;" placeholder="Product Price" type="text" runat="server" />
        </div>
        <div class="mt-3">
            <textarea id="productDescription" class="card p-2" style="width:20vw; height:15vh;" placeholder="Product Description" rows="2" cols="20" runat="server"></textarea>
        </div>
        <div class="mt-3">
            <div class="container-fluid row">
                <div class="col-6">
                    <div class="dropdown float-right pr-5">
                      <button class="btn btn-success dropdown-toggle font-weight-bold" type="button" id="dropdownMenuButton" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                          <asp:Label ID="productCategory" runat="server" Text="Category"></asp:Label>
                      </button>
                          <div class="dropdown-menu" aria-labelledby="dropdownMenuButton">
                              <asp:LinkButton ID="beverageBtn" OnClick="beverageBtn_Click" CssClass="dropdown-item font-weight-bold" runat="server">Beverages</asp:LinkButton>
                              <asp:LinkButton ID="fashionBtn" OnClick="fashionBtn_Click" CssClass="dropdown-item font-weight-bold" runat="server">Fashion</asp:LinkButton>
                              <asp:LinkButton ID="electronicBtn" OnClick="electronicBtn_Click" CssClass="dropdown-item font-weight-bold" runat="server">Electronic</asp:LinkButton>
                              <asp:LinkButton ID="beautyBtn" OnClick="beautyBtn_Click" CssClass="dropdown-item font-weight-bold" runat="server">Beauty</asp:LinkButton>
                            </div>
                        </div>
                    </div>
                <div class="col-6">
                    <asp:FileUpload ID="productImage" CssClass="btn-block float-left" runat="server"></asp:FileUpload>
                </div>
            </div>
        </div>
             <asp:Button ID="addBtn" CssClass="btn-success font-weight-bold btn mt-5" Font-Bold="true" Width="110" ForeColor="White" Font-Size="10" runat="server" Text="Add" />
        </center>
    </div>
    <%}%>

        <div class="container mt-5 mb-5">
            <div class="row">
    <%for (int i = 0; i < 16; i++){%>
                    <div class="card col-3 text-center">
                        <div class="card-body">
                                <img alt="" width="210" height="230" src="https://redbottle.com.au/wp-content/uploads/2019/12/jinro-chamisul-soju.jpg"/>
                                <div class="font-weight-bold">Soju</div>
                                <div class="font-weight-bold">₩ 120</div>
                            <input id="manageBtn" class="btn-outline-success font-weight-bold btn mt-1 ml-2" onclick="goToManage(<%=i%>)" type="button" value="Manage" />
                           </div>
                     </div>
    <%}%>
            </div>
    </div>
    <script>
        function goToManage(a) {
            var temp = "Manage.aspx?id="
            var loc = String(temp)+a
            location.href = loc
        }
    </script>
</asp:Content>
