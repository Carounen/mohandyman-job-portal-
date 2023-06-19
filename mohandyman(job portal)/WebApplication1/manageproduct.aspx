<%@ Page Title="manageproduct" Language="C#" MasterPageFile="~/home.Master" AutoEventWireup="true" CodeBehind="manageproduct.aspx.cs" Inherits="WebApplication1.manageproduct" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .bbox{
            background-color:aliceblue;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="maincontent" runat="server">
    <div class="bbox">
        <h4>Manage Product</h4>
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
                <asp:Button runat="server" ID="btnAddproduct" Visible="true"  OnClick="btnAddproduct_Click" Text="Add Product"
                    CssClass="btn btn-block btn-outline-primary" />
                <asp:Button runat="server" ID="btnupdate" OnClick="btnupdate_Click" Text="Update Product"
                    Visible="false" CssClass="btn btn-block btn-outline-primary" />
                <asp:Button runat="server" ID="btndelete"  OnClick="btndelete_Click" Text="Delete Product"
                    Visible="false" CssClass="btn btn-block btn-outline-primary" OnClientClick="return confirm('Are you sure you want to delete?')" />
                <asp:Button runat="server" ID="btncancel" Text="Cancel"  OnClick="btncancel_Click"
                    Visible="false" CssClass="btn btn-block btn-outline-primary" />
                <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
               
                <asp:Label ID="lblMsgr" runat="server" Text=""></asp:Label>
            </div>
        </div>
    
    <hr />
    <asp:GridView ID="gvs" AutoGenerateColumns="false" DataKeyNames="product_id" OnSelectedIndexChanged="gvs_SelectedIndexChanged" ClientIDMode="Static"
        Width="800" runat="server">
        <HeaderStyle BackColor="LightGreen" ForeColor="White" Font-Bold="true"
            Height="30" />

        <AlternatingRowStyle BackColor="#f5f5f5" />
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID="lbtnSelect" runat="server"
                        CssClass="btn btn-outline-info" CommandName="Select" Text="Select" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Product Name">
                <ItemTemplate>
                    <!-- display the movie name -->
                    <asp:Label ID="lblproductName" Text='<%#Eval("product_name")%>'
                        runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <%-- add an imagefield here to display the poster--%>
        </Columns>
    </asp:GridView>
    </div>
</asp:Content>
