<%@ Page Title="" Language="C#" MasterPageFile="~/masterpage.Master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="LOkopedia.View.Manage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="container p-5 mt-3 border shadow">
            <center>
                    <asp:Label ID="ads" Font-Bold="true" Font-Size="Larger" runat="server">Update Product</asp:Label>
            </center>
            <div class="row">
                <div class="col-6 text-center">
                    <asp:Image ID="myPhoto" Width="400" Height="350" ImageUrl="/Upload/image1.jpg" CssClass="mt-5 mb-3" runat="server"></asp:Image>
                </div>
                <div class="col-6">
                    <div class="mt-5">
                        <input id="productName" class="card p-2 font-weight-bold" style="width:20vw;" value="Soju" type="text" runat="server" />
                    </div>
                    <div class="mt-3">
                        <input id="productPrice" class="card p-2 font-weight-bold" style="width:20vw;" type="text" runat="server" />
                    </div>
                    <div class="mt-3">
                        <textarea id="productDescription" class="card p-2 font-weight-bold" style="width:20vw; height:15vh;" rows="2" cols="20" runat="server"></textarea>
                    </div>
                    <div class="mt-3">
                         <asp:FileUpload ID="productImage" CssClass="btn-block" runat="server"></asp:FileUpload>
                    </div>
                         <asp:Button ID="addBtn" CssClass="btn-success font-weight-bold btn mt-5" Font-Bold="true" Width="110" ForeColor="White" Font-Size="10" runat="server" Text="Save" />
                </div>
            </div>
    </div>
</asp:Content>
