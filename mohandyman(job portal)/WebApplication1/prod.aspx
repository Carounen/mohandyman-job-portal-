<%@ Page Title="" Language="C#" MasterPageFile="~/home.Master" AutoEventWireup="true" CodeBehind="prod.aspx.cs" Inherits="WebApplication1.prod" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="maincontent" runat="server">
    <div class="column">
        <!-- This DataList will be used to display list of movies depending on
which category is selected from the previous page -->
        <asp:DataList
            ID="dlstMovieDetails"
            RepeatColumns="1"
            runat="server">
            <ItemTemplate>
                <div class="card bg-warning text-white h-50"
                    style="width: 600px; float: left; margin: 30px;">
                    <asp:Image runat="server" ImageUrl='<%# Eval("pictures", "~/images/{0}")%>'
                        ID="Image1" CssClass="card-img-top mx-auto" Width="190px" Height="200px" />
                    <div class="card-body h">
                        <h2 class="card-title"><%# Eval("product_name")%></h2>
                        <p class="card-text text-dark">
                            Movie Description:
                            <%#Eval("description") %>

                        </p>
                        <p class="card-text">
                            <span><strong>Box Office Totals:<br />
                            </strong></span>
                            <span class="text-dark">
                                <%# Eval("cost","{0:c}")%>
                            </span>
                        </p>
                    </div>
                </div>
            </ItemTemplate>
        </asp:DataList>
    </div>
</asp:Content>
