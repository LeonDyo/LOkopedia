<%@ Page Title="" Language="C#" MasterPageFile="~/masterpage.Master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="LOkopedia.View.Manage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="container p-5 mt-3 border shadow" style="min-height:75vh;">
            <center>
                    <asp:Label ID="ads" Font-Bold="true" Font-Size="Larger" runat="server">Manage Product</asp:Label>
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
                        <input id="productPrice" class="card p-2 font-weight-bold" min="0" style="width:20vw;" type="number" runat="server" />
                    </div>
                    <div class="mt-3">
                        <textarea id="productDescription" class="card p-2 font-weight-bold" style="width:20vw; height:15vh;" rows="2" cols="20" runat="server"></textarea>
                    </div>
                    <div class="mt-3">
                         <asp:FileUpload ID="productImage" CssClass="btn-block" runat="server"></asp:FileUpload>
                    </div>
                    <div class="mt-3 ml-5">
                        <asp:Label ID="errorMsg" Font-Bold="true" Font-Size="Medium" ForeColor="Red" Visible="false" Text="" runat="server"></asp:Label>
                    </div>
                         <asp:Button ID="updateBtn" OnClick="updateBtn_Click" CssClass="btn-success font-weight-bold btn mt-3" Font-Bold="true" Width="110" ForeColor="White" Font-Size="10" runat="server" Text="Update" />
                         <asp:Button ID="deleteBtn" OnClick="deleteBtn_Click" CssClass="btn-danger font-weight-bold btn mt-3 ml-5" Font-Bold="true" Width="110" ForeColor="White" Font-Size="10" runat="server" Text="Delete" />
                </div>
            </div>
    </div>
</asp:Content>
