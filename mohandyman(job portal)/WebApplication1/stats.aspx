<%@ Page Title="" Language="C#" MasterPageFile="~/home.Master" AutoEventWireup="true" CodeBehind="stats.aspx.cs" Inherits="WebApplication1.stats" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="maincontent" runat="server">

     <div class="container-fluid">
        <div class="row">
            <div class="col-xl-3 col-md-6">
                <div class="card bg-primary text-white mb-4">
                    <div class="card-body">Category Available:</div>
                    <div class="card-footer d-flex align-items-center justify-content-
between">
                        <asp:HyperLink ID="hycat" runat="server" CssClass="small
text-white stretched-link"></asp:HyperLink>
                                                <a class="small text-white stretched-link"  href="viewcategory.aspx">.....View
Details</a>
                        <div class="small text-white">
                            <i class="fas fa-angle-
right"></i>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-xl-3 col-md-6">
                <div class="card bg-warning text-white mb-4">
                    <div class="card-body">Product in store</div>
                    <div class="card-footer d-flex align-items-center justify-content-
between">
                        <asp:HyperLink ID="hyprod" runat="server" CssClass="small
text-white stretched-link"></asp:HyperLink>
                        <a class="small text-white stretched-link"  href="viewprod.aspx">.....View
Details</a>
                        <div class="small text-white">
                            <i class="fas fa-angle-
right"></i>
                        </div>
                    </div>
                </div>
            </div>
          
            <div class="col-xl-3 col-md-6">
                <div class="card bg-danger text-white mb-4">
                    <div class="card-body">Number of user</div>
                    <div class="card-footer d-flex align-items-center justify-content-
between">
                        <asp:HyperLink ID="hyuser" runat="server" CssClass="small text-
white stretched-link"></asp:HyperLink>
                                                <a class="small text-white stretched-link"  href="viewuser.aspx">.....View
Details</a>
                        <div class="small text-white">
                            <i class="fas fa-angle-
right"></i>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
