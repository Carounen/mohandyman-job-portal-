<%@ Page Title="Register" Language="C#" MasterPageFile="~/home.Master" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="WebApplication1.register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">



     <script type="text/javascript">

        function validatePassword(source, args) {
            if (args.value.length >= 7 && args.value.length <= 12)
                args.IsValid = true;
            else
                args.IsValid = false;
        }

     </script>

    <style>
         .b{
           background-color: rgba(255, 0, 0, 0.2);
       }


    </style>
    

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="maincontent" runat="server">

    <asp:ValidationSummary ID="ValidationSummary1"
            HeaderText="Errors in the form are:"
            ShowMessageBox="true"
            ShowSummary="false"
            runat="server" />

      <h2 class="title"><%: Title %></h2>
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>
    <h4 class="title">Create a new account.</h4>
    <hr />



           <%---   <div class="form-group row justify-content-center">
            <asp:Label runat="server" CssClass="col-md-2 col-form-label">Select
a Location</asp:Label>
            <div class="col-md-8">
                <asp:DropDownList ID="ddlloc" runat="server"
                    CssClass="form-control">
                </asp:DropDownList>
            </div>
        </div> ---%>  
    <div class="b">

     <div class="mb-2 title" >
        <asp:Label runat="server"
            CssClass="form-label">First Name</asp:Label>

        <asp:TextBox runat="server" ID="first"
            placeholder="Enter firstname"
            CssClass="form-control" />


         <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Display="Dynamic" SetFocusOnError="true" ControlToValidate="first" runat="server" ForeColor="Red" ErrorMessage="First name is required"></asp:RequiredFieldValidator>
    </div>


     <div class="mb-3 title" >
        <asp:Label runat="server"
            CssClass="form-label">Last Name</asp:Label>

        <asp:TextBox runat="server" ID="Last"
            placeholder="Last Name"
            CssClass="form-control" />

         <asp:RequiredFieldValidator ID="RequiredFieldValidator2" Display="Dynamic" SetFocusOnError="true" ControlToValidate="Last" runat="server" ForeColor="Red" ErrorMessage="Last name is required"></asp:RequiredFieldValidator>

    </div>


     <div class="mb-3 title" >
        <asp:Label runat="server"
            CssClass="form-label">Address</asp:Label>

        <asp:TextBox runat="server" ID="address"
            placeholder="Enter Address"
            CssClass="form-control" />

         <asp:RequiredFieldValidator  Display="Dynamic" SetFocusOnError="true" ControlToValidate="address" runat="server" ForeColor="Red" ErrorMessage="Last name is required"></asp:RequiredFieldValidator>

    </div>



     <div class="form-group row justify-content-center">
            <asp:Label runat="server"
                CssClass="col-md-2 col-form-label">DOB</asp:Label>
            <div class="col-md-8">
                <asp:TextBox runat="server" ID="DOB" TextMode="Date"
                    CssClass="form-control" />
            </div>
        </div>


     <div class="mb-3 title" >
        <asp:Label runat="server"
            CssClass="form-label">Phone Number</asp:Label>

        <asp:TextBox runat="server" ID="pnum"
            placeholder="Enter Phone Number"
            CssClass="form-control" />

       <%--  <asp:RequiredFieldValidator  Display="Dynamic" SetFocusOnError="true" ControlToValidate="pnum" runat="server" ForeColor="Red" ErrorMessage="Phone number is required"></asp:RequiredFieldValidator>--%>


         <asp:CompareValidator ID="CompareValidator2"
                        ControlToValidate="pnum"
                        Operator="DataTypeCheck"
                        Type="Integer"
                        runat="server" ErrorMessage="Wrong data type"></asp:CompareValidator>

    </div>





    <div class="mb-3 title" >
        <asp:Label runat="server"
            CssClass="form-label">User Name</asp:Label>

        <asp:TextBox runat="server" ID="txtuse"
            placeholder="Enter username"
            CssClass="form-control" />

        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" Display="Dynamic" SetFocusOnError="true" ControlToValidate="txtuse" runat="server" ForeColor="Red" ErrorMessage="Username is mandatory"></asp:RequiredFieldValidator>

    </div>




     <div class="mb-3 title" >
        <asp:Label runat="server"
            CssClass="form-label">Email Address</asp:Label>

        <asp:TextBox runat="server" ID="mail"
            placeholder="Enter Email Address"
            CssClass="form-control" />

         <asp:RequiredFieldValidator  Display="Dynamic" SetFocusOnError="true" ControlToValidate="mail" runat="server" ForeColor="Red" ErrorMessage="Email is required"></asp:RequiredFieldValidator>

    </div>

  <div class="form-group row justify-content-center">
            <asp:Label runat="server"
                CssClass="col-md-2 col-form-label">Profile Picture</asp:Label>
            <div class="col-md-8">
                <asp:FileUpload ID="picture" runat="server" CssClass="" />
                <asp:Image ID="images" runat="server" Visible="true" Width="75"
                    Height="100" />
            </div>
        </div> 



    <div class="mb-3 title" >
        <asp:Label runat="server"
            CssClass="form-label">Password</asp:Label>

        <asp:TextBox runat="server" ID="txtpas"
            placeholder="Enter password"
             TextMode="Password"
            CssClass="form-control" />

        <asp:CustomValidator ID="CustomValidator1" runat="server" OnServerValidate="CustomValidator1_ServerValidate" ControlToValidate="txtpas" ForeColor="Red" ClientValidationFunction="validatePassword" ValidateEmptyText="true" ErrorMessage="Password must be between 7 to 12 characters"></asp:CustomValidator>

    </div>
    <div class="mb-3 title" >
        <asp:Label runat="server"
            CssClass="form-label">confirm password</asp:Label>

        <asp:TextBox runat="server" ID="txtc"
            placeholder="confirm password"
             TextMode="Password"
            CssClass="form-control" />

        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txtc" ControlToCompare="txtpas" Operator="Equal" initialValue="-1" ForeColor="Red" ErrorMessage="Password does not match"></asp:CompareValidator>



    </div>
    <div class="mb-3">
        <asp:Button runat="server" Text="Register"
            CssClass="col-12 btn btn-outline-primary btn-lg" ID="lblMsg" OnClick="Unnamed_Click" BackColor="Blue" ForeColor="White" />
    </div>
    <asp:LinkButton ID="lnkreset" CssClass="col-12 btn btn-outline-warning btn-lg" OnClick="lnkreset_Click" OnClientClick="return confirm('Are you sure you want to reset form?')" runat="server" BackColor="Orange" ForeColor="White">Reset</asp:LinkButton>
    <br>
    <br>
    <asp:LinkButton ID="lexit" CssClass="col-12 btn btn-outline-warning btn-lg"  OnClick="lexit_Click" runat="server" BackColor="Red" ForeColor="White">Exit</asp:LinkButton>
</div>
    <br>
    <br>

</asp:Content>
