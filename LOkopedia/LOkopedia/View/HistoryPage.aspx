<%@ Page Title="" Language="C#" MasterPageFile="~/masterpage.Master" AutoEventWireup="true" CodeBehind="HistoryPage.aspx.cs" Inherits="LOkopedia.View.HistoryPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-5" style="min-height:70vh;">
        <asp:ListView ID="ListView1" runat="server">
            <ItemTemplate>
        <div class="row border mb-3 shadow">
                    <div class="col-2 pb-3">
                        <img Width="100" Height="100" src="https://icons-for-free.com/iconfiles/png/512/halloween+pumpkin+icon-1320183496270053917.png" class="mt-3 ml-5"></img>
                    </div>
                    <div class="col-8 font-weight-bold">
                        <div class="mt-4">
                            <p>Transaction <%#Eval("HistoryId")%></p>
                            <p><%#Eval("HistoryDate")%></p>
                         </div>
                    </div>
                    <div class="col-2">
                        <asp:Button ID="detailBtn" OnClick="detailBtn_Click" CommandArgument='<%#Eval("HistoryId") %>' CssClass="btn-primary font-weight-bold btn mt-5" Font-Bold="true" Width="110" ForeColor="White" Font-Size="10" runat="server" Text="Check Details" />
               </div>
        </div>
                </ItemTemplate>
            </asp:ListView>
    </div>
</asp:Content>
