<%@ Page Title="Addprod" Language="C#" MasterPageFile="~/home.Master" AutoEventWireup="true" CodeBehind="addprod.aspx.cs" Inherits="WebApplication1.addprod" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <style>
        .bbox{
            background-color:cornflowerblue;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="maincontent" runat="server">

  <div class="bbox">
        <h4>Add Product</h4>
        <hr />
      <div>

           <div class="form-group row justify-content-center">
            <asp:Label runat="server" CssClass="col-md-2 col-form-label">Select
a Category</asp:Label>
            <div class="col-md-8">
                <asp:DropDownList ID="ddlcat" runat="server"
                    CssClass="form-control">
                </asp:DropDownList>
            </div>
        </div>
        <div class="form-group row justify-content-center">
            <asp:Label runat="server"
                CssClass="col-md-2 col-form-label"></asp:Label>
            <div class="col-md-8">
                <asp:TextBox runat="server" ID="txtproductId" Visible="false"
                    CssClass="form-control" />
            </div>
        </div>
        <div class="form-group row justify-content-center">
            <asp:Label runat="server" CssClass="col-md-2 col-form-label">Product 
name</asp:Label>
            <div class="col-md-8">
                <asp:TextBox runat="server" ID="txtproductname"
                    CssClass="form-control" />
            </div>
        </div>
        <div class="form-group row justify-content-center">
            <asp:Label runat="server"
                CssClass="col-md-2 col-form-label">Cost</asp:Label>
            <div class="col-md-8">
                <asp:TextBox runat="server" ID="txtcost"
                    CssClass="form-control" />
            </div>
        </div>
       
        </div>
        <div class="form-group row justify-content-center">
            <asp:Label runat="server"
                CssClass="col-md-2 col-form-label">Description</asp:Label>
            <div class="col-md-8">
                <asp:TextBox runat="server" ID="txtdesc" TextMode="Multiline"
                    CssClass="form-control" />
            </div>
        </div>


         <div class="form-group row justify-content-center">
            <asp:Label runat="server"
                CssClass="col-md-2 col-form-label">Brand</asp:Label>
            <div class="col-md-8">
                <asp:TextBox runat="server" ID="txtbrand"
                    CssClass="form-control" />
            </div>
        </div>





         <div class="form-group row justify-content-center">
            <asp:Label runat="server"
                CssClass="col-md-2 col-form-label">Usage Time</asp:Label>
            <div class="col-md-8">
                <asp:TextBox runat="server" ID="use" 
                    CssClass="form-control" />
            </div>
        </div>



         <div class="form-group row justify-content-center">
            <asp:Label runat="server"
                CssClass="col-md-2 col-form-label">Expiry date</asp:Label>
            <div class="col-md-8">
                <asp:TextBox runat="server" ID="txtexp" TextMode="Date"
                    CssClass="form-control" />
            </div>
        </div>


           <div class="form-group row justify-content-center">
            <asp:Label runat="server"
                CssClass="col-md-2 col-form-label">Location of product</asp:Label>
            <div class="col-md-8">
                <asp:TextBox runat="server" ID="txtloc" 
                    CssClass="form-control" />
            </div>
        </div>


       

        <div class="form-group row justify-content-center">
            <asp:Label runat="server"
                CssClass="col-md-2 col-form-label">Picture</asp:Label>
            <div class="col-md-8">
                <asp:FileUpload ID="picture" runat="server" CssClass="" />
                <asp:Image ID="images" runat="server" Visible="true" Width="75"
                    Height="100" />
            </div>
        </div>



         <div class="form-group row justify-content-center">
            <asp:Label runat="server"
                CssClass="col-md-2 col-form-label">Document</asp:Label>
            <div class="col-md-8">
                <asp:FileUpload ID="doc" runat="server" CssClass="" />
                <asp:Image ID="Image2" runat="server" Visible="false" Width="75"
                    Height="100" />
            </div>
        </div>
       
       
        <div class="form-group row justify-content-center">
            <asp:Label runat="server"
                CssClass="col-md-2 col-form-label"></asp:Label>
            <div class="col-md-8">
                <div class="form-check-inline">
                    <asp:CheckBox runat="server" ID="chkstatus"
                        CssClass="form-check-input" />
                    <asp:Label runat="server"
                        CssClass="form-check-label">Status</asp:Label>
                </div>
            </div>
        </div>
        <div class="form-group row justify-content-center">
            <div class="offset-md-2 col-md-8">
                <asp:Button runat="server" ID="btnAddproduct" OnClick="btnAddproduct_Click" Text="Add Product"
                    CssClass="btn btn-block btn-outline-primary" />
               
              
               
                <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
            </div>
        </div>
      </div>
    
    <hr />
</asp:Content>
