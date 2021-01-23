<%@ Page Title="" Language="C#" MasterPageFile="~/masterpage.Master" AutoEventWireup="true" CodeBehind="MyProfile.aspx.cs" Inherits="LOkopedia.View.MyProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-5 mb-5 shadow" style="min-height:75vh;">
        <div class="card border-0">
            <div class="row">
                <div class="col-6 p-5">
                    <div class="card" style="background: linear-gradient(to bottom right, #86cf46, #379df0)">
                        <center>
                            <asp:Image ID="myPhoto" Width="300" Height="250" CssClass="mt-5 mb-3 rounded-circle" runat="server"></asp:Image>
                        </center>
                        <div class="mb-3">
                            <center>
                                <asp:Label ID="myName" Font-Size="XX-Large" CssClass="font-weight-bold" ForeColor="White" runat="server" Text=""></asp:Label>
                            </center>
                        </div>
                        <div class="bg-white pt-3">
                            <center>
                                <asp:Label ID="errorMessage" CssClass="font-weight-bold" ForeColor="Red" runat="server" Text=""></asp:Label>
                                <asp:FileUpload ID="myPicture" CssClass="ml-5 mt-3 pb-4" runat="server"></asp:FileUpload>
                            </center>
                        </div>
                    </div>
                </div>
                <div class="col-6 p-5">
                    <asp:Label ID="profileText" Font-Size="XX-Large" CssClass="font-weight-bold" runat="server" Text="My Profile"></asp:Label>
                    <div class="row mt-5">
                        <div class="col-5">
                            <asp:Label ID="nameText" Font-Size="Larger" CssClass="font-weight-bold" runat="server" Text="Name"></asp:Label>
                        </div>
                        <div class="col-7">
                            <input id="nameInput" class="border-0 font-weight-bold" type="text" value="" runat="server"/>
                            </div>
                    </div>
                    <div class="row mt-4">
                        <div class="col-5">
                            <asp:Label ID="emailText" Font-Size="Larger" CssClass="font-weight-bold" runat="server" Text="Email"></asp:Label>
                        </div>
                        <div class="col-7">
                            <input id="emailInput" class="border-0 font-weight-bold" type="text" value="" runat="server"/>
                        </div>
                    </div>
                    <div class="row mt-4">
                        <div class="col-5">
                            <asp:Label ID="phoneText" Font-Size="Larger" CssClass="font-weight-bold" runat="server" Text="Phone Number"></asp:Label>
                        </div>
                        <div class="col-7">
                            <input id="phoneInput" class="border-0 font-weight-bold" type="text" value="" runat="server"/>
                        </div>
                    </div>
                    <div class="row mt-4">
                        <div class="col-5">
                            <asp:Label ID="DobText" Font-Size="Larger" CssClass="font-weight-bold" runat="server" Text="Day of Birth"></asp:Label>
                        </div>
                        <div class="col-7">
                            <asp:Label ID="dob" Font-Size="Medium" CssClass="font-weight-bold" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                    <div class="row mt-4">
                        <div class="col-5">
                            <asp:Label ID="joinText" Font-Size="Larger" CssClass="font-weight-bold" runat="server" Text="Join Date"></asp:Label>
                        </div>
                        <div class="col-7">
                            <asp:Label ID="join" Font-Size="Medium" CssClass="font-weight-bold" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                    <div class="row mt-4">
                        <div style="margin-left:-0.5vw;">
                            <asp:Button ID="Save" OnClick="Save_Click" CssClass="m-4 pl-5 pr-5 btn bg-light border-dark font-weight-bold" runat="server" Text="Save" />
                        <asp:Label ID="errorMsg" Font-Size="Larger" CssClass="font-weight-bold" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
