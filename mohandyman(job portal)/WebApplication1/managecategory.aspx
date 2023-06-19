<%@ Page Title="" Language="C#" MasterPageFile="~/home.Master" AutoEventWireup="true" CodeBehind="managecategory.aspx.cs" Inherits="WebApplication1.managecategory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">


      <style>
        .bbox{
            background-color:aliceblue;
        }
    </style>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="maincontent" runat="server">


     <div class="bbox">
        <h4>Manage category</h4>
        <hr />
      <div>

           
        <div class="form-group row justify-content-center">
            <asp:Label runat="server"
                CssClass="col-md-2 col-form-label"></asp:Label>
            <div class="col-md-8">
                <asp:TextBox runat="server" ID="txtcatId" Visible="false"
                    CssClass="form-control" />
            </div>
        </div>
        <div class="form-group row justify-content-center">
            <asp:Label runat="server" CssClass="col-md-2 col-form-label">Category:</asp:Label>
            <div class="col-md-8">
                <asp:TextBox runat="server" ID="txtcatname"
                    CssClass="form-control" />
            </div>
        </div>
      
       
        </div>
      
        <div class="form-group row justify-content-center">
            <div class="offset-md-2 col-md-8">
                <asp:Button runat="server" ID="btnAddcategory" Visible="true"  OnClick="btnAddcategory_Click"  Text="Add Category"
                    CssClass="btn btn-block btn-outline-primary" />
                <asp:Button runat="server" ID="btnupdate" OnClick="btnupdate_Click"  Text="Update Category"
                    Visible="false" CssClass="btn btn-block btn-outline-primary" />
                <asp:Button runat="server" ID="btndelete"  OnClick="btndelete_Click"  Text="Delete Category"
                    Visible="false" CssClass="btn btn-block btn-outline-primary" OnClientClick="return confirm('Are you sure you want to delete?')" />
                <asp:Button runat="server" ID="btncancel" Text="Cancel"  OnClick="btncancel_Click" 
                    Visible="false" CssClass="btn btn-block btn-outline-primary" />
                <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
               
                <asp:Label ID="lblMsgr" runat="server" Text=""></asp:Label>
            </div>
        </div>
    
    <hr />
    <asp:GridView ID="gvs" AutoGenerateColumns="false" DataKeyNames="category_id" OnSelectedIndexChanged="gvs_SelectedIndexChanged"  ClientIDMode="Static"
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
            <asp:TemplateField HeaderText="Category">
                <ItemTemplate>
                    
                    <asp:Label ID="lblcat" Text='<%#Eval("category")%>'
                        runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
   
        </Columns>
    </asp:GridView>
    </div>


</asp:Content>
