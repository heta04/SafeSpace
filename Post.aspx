<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Post.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link rel="stylesheet" href="http://code.jquery.com/ui/1.9.1/themes/base/jquery-ui.css" />
    <script src="http://code.jquery.com/jquery-1.8.2.js"></script>
    <script src="http://code.jquery.com/ui/1.9.1/jquery-ui.js"></script>
   
    <script>

        $("[id*=txtDesc]").live("keyup",function () {
        const settings = {
            "async": true,
            "crossDomain": true,
            "url": "https://community-purgomalum.p.rapidapi.com/containsprofanity?text='" + $("[id*=txtDesc]").val()+"'",
            "method": "GET",
            "headers": {
                "x-rapidapi-key": "e9f8243caemsh4bc90479a6a7c91p10af77jsne6f9df32a0fd",
                "x-rapidapi-host": "community-purgomalum.p.rapidapi.com"
            }
        };

            $.ajax(settings).done(function (response) {
                debugger;

                if (response == "true") {
                    alert("such porfinaity statments are not allowed");
                    const settings = {
                        "async": true,
                        "crossDomain": true,
                        "url": "https://community-purgomalum.p.rapidapi.com/json?text='" + $("[id*=txtDesc]").val() + "'",
                        "method": "GET",
                        "headers": {
                            "x-rapidapi-key": "e9f8243caemsh4bc90479a6a7c91p10af77jsne6f9df32a0fd",
                            "x-rapidapi-host": "community-purgomalum.p.rapidapi.com"
                        }
                    };

                    $.ajax(settings).done(function (response) {
                        debugger;
                        $("[id*=txtDesc]").val((response["result"].slice(1,-1)));
                        
                    });

                }
        });
        });

        function isDecimalKey(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode != 46 && charCode > 31
            && (charCode < 48 || charCode > 57)) {

                alert("Please Enter Only Numbers.");
                return false;
            }
            return true;
        }
        function isIntKey(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode != 46 && charCode > 31
            && (charCode < 48 || charCode > 57)) {

                alert("Please Enter Only Numbers.");
                return false;
            }
            if (charCode == 46) {
                alert("Please Enter Only Numbers.");
                return false;
            }
            return true;
        }
        function isOnlyAlphabet(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode >= 48 && charCode <= 57) {
                alert("Please Enter Only  Alphabets.");
                return false;
            }
            return true;
        }

    </script>
   </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="container-fluid">
        <div class="post-header">
            <div class=""></div>
        </div>
        <div class="post-body">
                <div class="form-panel mt-20 mb-20">
                    <div class="">
                        <div class="">
                            <div class="form-group">
                                <label>First Name</label><span style="color:red">*</span>
                               
                         <asp:TextBox ID="txtFName"  class="form-control" onkeypress="return isOnlyAlphabet(event);" placeholder="First Name" runat="server"></asp:TextBox></div>
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtFName" runat="server" ForeColor="Red" ErrorMessage="First Name required"></asp:RequiredFieldValidator>
                           
                            <div class="form-group">
                                <label>Last Name</label><span style="color:red">*</span>
                                 <asp:TextBox ID="txtLName" runat="server" onkeypress="return isOnlyAlphabet(event);"  class="form-control" placeholder="Last Name" ></asp:TextBox></div>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtLName" runat="server" ForeColor="Red" ErrorMessage="Last Name required"></asp:RequiredFieldValidator>
                           
                            </div>
                            <div class="row">
                                <div class="col-lg-6">
                                    <div class="form-group">

                                        <label>Email Id</label><span style="color:red">*</span> <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="txtemail" runat="server" ForeColor="Red" ErrorMessage="*"></asp:RequiredFieldValidator>
                           
                                        <asp:TextBox ID="txtemail" runat="server" type="text" class="form-control" placeholder="Email Id"></asp:TextBox>
                                   <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="txtLName" runat="server" ForeColor="Red" ErrorMessage="Email required"></asp:RequiredFieldValidator>
                           
                                        <asp:RegularExpressionValidator ID="regexEmailValid" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                        ControlToValidate="txtemail" ErrorMessage="Invalid Email Format" ForeColor="Red"></asp:RegularExpressionValidator>

                                        
                                         </div>
                                </div>
                                <div class="col-lg-6">
                                    <div class="form-group">
                                        <label>Phone Number</label>
                                        <asp:TextBox ID="txtPNo" runat="server" class="form-control" Type="number" placeholder="Phone Number"></asp:TextBox>
                                        
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"  
                                        ControlToValidate="txtPNo" ErrorMessage="Enter Valid Number"  ForeColor="Red" 
                                          ValidationExpression="[0-9]{10}"></asp:RegularExpressionValidator>  

                                    </div>
                                </div>
                            </div>
                            <div class="form-group">
                                <label>Address</label> 
                                <asp:TextBox ID="txtAdd" runat="server" type="text" class="form-control" placeholder="Enter Address"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label>City</label><span style="color:red">*</span>
                               
                                <asp:TextBox ID="txtCity" runat="server" type="text" class="form-control" placeholder="Enter City"></asp:TextBox>
                           <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ControlToValidate="txtCity" runat="server" ForeColor="Red" ErrorMessage="City required"></asp:RequiredFieldValidator>
                           
                                </div>
                            <div class="form-group">
                                <label>Province</label><span style="color:red">*</span>
                                <asp:TextBox ID="txtProvince" runat="server" type="text" class="form-control" placeholder="Enter Province"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" ControlToValidate="txtProvince" runat="server" ForeColor="Red" ErrorMessage="Province Required"></asp:RequiredFieldValidator>
                           
                                </div>
                            <div class="row">
                                <div class="col-lg-6">
                                    <div class="form-group">
                                        <label>Country</label>
                                        <asp:TextBox ID="txtCountry" runat="server" text="Canada" ReadOnly="true" class="form-control" placeholder="Enter Country"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-lg-6">
                                    <div class="form-group">
                                        <label>Zip Code</label> 
                                        <asp:TextBox ID="txtZip" runat="server" type="number" class="form-control" placeholder="Enter Zip Code"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                         <div class="form-group">
                                <label>Title</label> <span style="color:red">*</span>
                            
                                <asp:TextBox ID="txttitle" runat="server" class="form-control" ></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" ControlToValidate="txttitle" runat="server" ForeColor="Red" ErrorMessage="Title Required"></asp:RequiredFieldValidator>
                           
                             </div>
                           
                            <div class="form-group">
                                <label>Description</label> <span style="color:red">*</span>
                               
                                <asp:TextBox TextMode="MultiLine" Height="5%" ID="txtDesc" runat="server" class="form-control" ></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" ControlToValidate="txtDesc" runat="server" ForeColor="Red" ErrorMessage="Description required"></asp:RequiredFieldValidator>
                           
                                </div>
                            <div class="form-group">
                                <label>Category</label><span style="color:red">*</span>
                                
                                <asp:dropdownlist id="ddlcatageory" runat="server" class="form-control">
                                    <asp:ListItem selected="True">Choose</asp:ListItem>
                                    <asp:ListItem>Accomodation</asp:ListItem>
                                    <asp:ListItem>Food</asp:ListItem>
                                    <asp:ListItem>Entertainment</asp:ListItem>
                                    <asp:ListItem>Medical</asp:ListItem>
                                    <asp:ListItem>House-help</asp:ListItem>
                                    <asp:ListItem>Job</asp:ListItem>
                                    <asp:ListItem>Ride</asp:ListItem>
                                    <asp:ListItem>Others</asp:ListItem>
                                   
                                </asp:dropdownlist>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator12" ControlToValidate="ddlcatageory" InitialValue="Choose" runat="server" ForeColor="Red" ErrorMessage="Category required"></asp:RequiredFieldValidator>
                           
                            </div>
                            <div class="text-right">
                                <asp:Button runat="server" id="btnSubmit" CausesValidation="true" Text="Submit" OnClick="btnSubmit_Click" class="btn btn-primary mr-10"> </asp:Button>
                                <asp:Button runat="server" id="btncancel" CausesValidation="false" Text="Cancel" OnClick="btncancel_Click" class="btn btn-secondary"></asp:Button>
                            </div>
                        </div>
                    </div>
                </div>
        </div>
        <div class="post-header"></div>
    




</asp:Content>

