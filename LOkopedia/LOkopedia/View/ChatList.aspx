<%@ Page Title="" Language="C#" MasterPageFile="~/masterpage.Master" AutoEventWireup="true" CodeBehind="ChatList.aspx.cs" Inherits="LOkopedia.View.ChatList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="container mt-5 mb-5" style="min-height:65vh;">
         <asp:ListView ID="ListView1" runat="server">
             <ItemTemplate>
                <div class="row border mb-3 shadow">
                            <div class="col-2">
                                <img Width="100" Height="100" src="<%#Eval("UserPhoto")%>" class="rounded-circle mt-3 ml-5 mb-3"></img>
                            </div>
                            <div class="col-8">
                                <div class="mt-5">
                                    <h5 class="font-weight-bold"><%#Eval("UserName")%></h5>
                                 </div>
                            </div>
                            <div class="col-2">
                                <asp:Button ID="chatBtn" CommandArgument='<%#Eval("UserId")%>' OnClick="chatBtn_Click" CssClass="btn-primary font-weight-bold btn mt-5" Font-Bold="true" Width="110" ForeColor="White" Font-Size="10" runat="server" Text="Chat" />
                       </div>
                </div>
             </ItemTemplate>
         </asp:ListView>
    </div>
</asp:Content>
