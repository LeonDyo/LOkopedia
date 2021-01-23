<%@ Page Title="" Language="C#" MasterPageFile="~/masterpage.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="LOkopedia.View.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container" style="min-height:15vh;"></div>    
    <div class="container mt-5 mb-5">
            <div class="d-flex justify-content-center">
                <div class="col-4 card p-4 shadow">
                    <asp:Label ID="logText" runat="server" CssClass="text-center font-weight-bold" Font-Size="Larger" Text="Login"></asp:Label>
                    <form class="dropdown-menu">
                      <div class="form-group">
                          <asp:Label ID="email" CssClass="font-weight-bold" runat="server" Text="Email"></asp:Label>
                          <asp:TextBox ID="emailInput" Width="320" Height="30" CssClass="form-control" runat="server"></asp:TextBox>
                      </div>
                      <div class="form-group">
                        <asp:Label ID="password" CssClass="font-weight-bold" runat="server" Text="Password"></asp:Label>
                          <asp:TextBox ID="passInput" TextMode="Password" Width="320" Height="30" CssClass="form-control" runat="server"></asp:TextBox>
                      </div>
                      <div class="form-check">
                          <asp:CheckBox ID="rememberMe" CssClass="form-check-input" runat="server" Text="Remember Me" />
                      </div>
                        <asp:Button ID="signIn" OnClick="signIn_Click" CssClass="btn btn-primary mt-5 font-weight-bold" runat="server" Text="Sign In" />
                    </form>
                       <asp:Label ID="errorMsg" runat="server" CssClass="text-center mt-2 font-weight-bold" ForeColor="Red" Text=""></asp:Label>
                </div>
              </div>
        </div>
</asp:Content>
