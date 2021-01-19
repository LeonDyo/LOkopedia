<%@ Page Title="" Language="C#" MasterPageFile="~/masterpage.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="LOkopedia.View.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="container mt-5">
        <div class="d-flex justify-content-center">
            <div class="col-4 card p-4">
                <asp:Label ID="regText" runat="server" CssClass="text-center font-weight-bold" Font-Size="Larger" Text="Register"></asp:Label>
                <form class="dropdown-menu">
                    <div class="form-group mt-3">
                      <asp:Label ID="username" Font-Bold="true" runat="server" Text="Username"></asp:Label>
                      <asp:TextBox ID="usernameInput" Width="320" Height="30" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                  <div class="form-group">
                      <asp:Label ID="email" Font-Bold="true" runat="server" Text="Email"></asp:Label>
                      <asp:TextBox ID="emailInput" Width="320" Height="30" CssClass="form-control" runat="server"></asp:TextBox>
                  </div>
                    <div class="form-group">
                      <asp:Label ID="phone" Font-Bold="true" runat="server" Text="Phone"></asp:Label>
                      <asp:TextBox ID="phoneInput" Width="320" Height="30" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                        <asp:Label ID="DOBText" Font-Bold="true" runat="server" Text="Date of Birth"></asp:Label>
                    <div class="form-group" style="display:flex;">
                        <input id="days" type="text" style="width:3vw; height:1.5vw;" class="form-control text-center mr-2 font-weight-bold" runat="server" />
                         <h4>/</h4>
                        <input id="months" type="text" style="width:3vw; height:1.5vw;" class="form-control text-center mr-2 ml-2 font-weight-bold" runat="server" />
                      <h4>/</h4>
                        <input id="years" type="text" style="width:4vw; height:1.5vw;" class="form-control text-center mr-2 ml-2 font-weight-bold" runat="server" />
                       </div>
                  <div class="form-group">
                    <asp:Label ID="password" Font-Bold="true" runat="server" Text="Password"></asp:Label>
                      <asp:TextBox ID="passInput" TextMode="Password" Width="320" Height="30" CssClass="form-control" runat="server"></asp:TextBox>
                  </div>
                  <div class="form-group">
                    <asp:Label ID="confirmPassword" Font-Bold="true" runat="server" Text="Confirm Password"></asp:Label>
                      <asp:TextBox ID="confirm" TextMode="Password" Width="320" Height="30" CssClass="form-control" runat="server"></asp:TextBox>
                  </div>

                    <asp:Label ID="errorMsg" CssClass="text-center" ForeColor="Red" Font-Bold="true" runat="server"></asp:Label>
                    <asp:Button ID="signIn" OnClick="signIn_Click" CssClass="btn btn-primary mt-3" runat="server" Text="Register" />
                </form>
            </div>
          </div>
    </div>
    <script>
        <%if(flag == 1){%>
        alert("Success Registered !");
        <%}%>
    </script>
</asp:Content>
