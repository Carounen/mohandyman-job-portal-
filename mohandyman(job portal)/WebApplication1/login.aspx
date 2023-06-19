<%@ Page Title="Login" Language="C#" MasterPageFile="~/home.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="WebApplication1.login" %>

<%@ Register Src="~/logadd.ascx" TagPrefix="uc" TagName="login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .bb{
            background-color:white;
        }
    </style>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="maincontent" runat="server">

    <div class="bb" id="container">
        <div id="leftSide">
            <fieldset>
                <legend>Member Login</legend>
                <div class="form">

                    <uc:login runat="server" ID="userlogin" ValidationGroup="usergroup" />

                    <br />
                    <br />
                    <asp:Button ID="btnLogin" OnClick="btnLogin_Click" ValidationGroup="usergroup" runat="server"
                        CssClass="btn btn-outline-primary" Text="Log in" />
                </div>
            </fieldset>
            <fieldset>
                <asp:Label ID="lblmsg" runat="server" Text=""></asp:Label><br />
                <asp:Button ID="btnRegister" runat="server"
                    PostBackUrl="~/Tutorial/week5/register.aspx" Text="Don’t have an account yet? Join now"
                    CausesValidation="false" CssClass="btn btn-outline-warning" /><br />
            </fieldset>

        </div>
    </div>
</asp:Content>
