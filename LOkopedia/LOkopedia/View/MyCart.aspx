<%@ Page Title="" Language="C#" MasterPageFile="~/masterpage.Master" AutoEventWireup="true" CodeBehind="MyCart.aspx.cs" Inherits="LOkopedia.View.MyCart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <%if (flag != 0)
            {%>
    <div class="container mt-5" style="min-height:70vh;">
            <asp:ListView ID="ListView1" runat="server">
                <ItemTemplate>
        <div class="row border mb-3 shadow">
                    <div class="col-2">
                        <img Width="100" Height="100" src="<%#Eval("ProductImage")%>" class="mt-3 ml-5"></img>
                    </div>
                    <div class="col-8">
                        <div class="mt-4 font-weight-bold">
                            <p><%#Eval("ProductName")%></p>
                            <p>₩ <%#Eval("ProductPrice")%></p>
                            <p>Quantity: <%#Eval("Quantity")%></p>
                         </div>
                    </div>
                    <div class="col-2">
                        <asp:Button ID="deleteBtn" CommandArgument='<%#:Eval("ProductId")%>' OnClick="deleteBtn_Click" CssClass="btn-danger font-weight-bold btn mt-5" Font-Bold="true" Width="110" ForeColor="White" Font-Size="10" runat="server" Text="Remove" />
               </div>
        </div>
                </ItemTemplate>
            </asp:ListView>
        <center>
           <asp:Button ID="checkOutBtn" OnClick="checkOutBtn_Click" CssClass="btn-primary font-weight-bold btn mt-5" Font-Bold="true" Width="110" ForeColor="White" Font-Size="10" runat="server" Text="Check Out" />
        </center>
    </div>
        <%}%><%else
                 { %>
        <div class="container text-center font-weight-bold mt-5" style="min-height:70vh; font-size:30px;">
                <br /><br /><br /><br /><br /><br /><br />
                Your cart is empty !
        </div>
    <%} %>
    <br />
</asp:Content>
