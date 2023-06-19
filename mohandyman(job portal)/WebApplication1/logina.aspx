<%@ Page Title="" Language="C#" MasterPageFile="~/home.Master" AutoEventWireup="true" CodeBehind="logina.aspx.cs" Inherits="WebApplication1.logina" %>

<%@ Register Src="~/logadd.ascx" TagPrefix="uc" TagName="login" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="maincontent" runat="server">


    <div id="container">
        <div id="leftSide">
            <fieldset>
                <legend>Member Login</legend>
                <div class="form">
                    <uc:login runat="server" id="adminlogin" />

                    <br />
                    <br />
                    <asp:Button ID="btnLogin" runat="server"
                        CssClass="btn btn-outline-primary" Text="Log in" />
                </div>
            </fieldset>
            <fieldset>
                <asp:Label ID="lblmsg" runat="server" Text=""></asp:Label><br />
                <asp:Button ID="btnRegister" runat="server"
                    PostBackUrl="register.aspx" Text="Don’t have an account yet? Join now"
                    CausesValidation="false" CssClass="btn btn-outline-warning" /><br />
            </fieldset>
        </div>
    </div>
</asp:Content>
