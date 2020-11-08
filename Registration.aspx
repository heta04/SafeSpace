<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Registration.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <div class="container-fluid">
        <div class="post-header">
            <div class=""></div>
        </div>
        <div class="post-body">
            <div class="card-header text-center">
                <label class="mb-0">Registration</label>
            </div>
            <div class="content-body">
                
                    <div class="form-panel mt-20 mb-20">

                        <div class="">

                            <div class="form-group">
                                <label>First Name<span style="color:red">*</span></label>
                                <asp:Textbox runat="server" ID="txtfname" class="form-control" placeholder="First Name"></asp:Textbox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtfname" runat="server" ForeColor="Red" ErrorMessage="*"></asp:RequiredFieldValidator>
                           
                                </div>
                            <div class="form-group">
                                <label>Last Name<span style="color:red">*</span></label>
                                <asp:Textbox runat="server" ID="txtlname" class="form-control" placeholder="Last Name"></asp:Textbox>
                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtlname" runat="server" ForeColor="Red" ErrorMessage="*"></asp:RequiredFieldValidator>
                           
                                </div>
                            <div class="form-group">
                                <label>Password<span style="color:red">*</span></label>
                                <asp:Textbox runat="server" ID="txtpass" type="password" class="form-control" placeholder="Password"></asp:Textbox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="txtpass" runat="server" ForeColor="Red" ErrorMessage="*"></asp:RequiredFieldValidator>
                                </div>
                            <div class="form-group">
                                <label>Confirm Password<span style="color:red">*</span></label>
                                <asp:Textbox runat="server" ID="txtrpass" type="password" class="form-control" placeholder="Confirm Password"></asp:Textbox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="txtrpass" runat="server" ForeColor="Red" ErrorMessage="*"></asp:RequiredFieldValidator>
                              <asp:CompareValidator ID="CompareValidator1" runat="server" ForeColor="Red" ControlToValidate="txtrpass" ControlToCompare="txtpass" ErrorMessage="Password doesnot match"></asp:CompareValidator>
                             
                                </div>
                            
                            <div class="row">
                                <div class="col-lg-6">
                                    <div class="form-group">
                                        <label>Email Id<span style="color:red">*</span></label>
                                        <asp:Textbox runat="server" ID="txtemail" class="form-control" placeholder="Email Id"></asp:Textbox>
                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ControlToValidate="txtemail" runat="server" ForeColor="Red" ErrorMessage="*"></asp:RequiredFieldValidator>
                                           <asp:RegularExpressionValidator ID="regexEmailValid" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtemail" ForeColor="Red" ErrorMessage="Invalid Email Format"></asp:RegularExpressionValidator>

                                    </div>
                                </div>
                                <div class="col-lg-6">
                                    <div class="form-group">
                                        <label>Phone Number</label>
                                        <asp:Textbox runat="server" ID="txtpnumber" class="form-control" placeholder="Phone Number"></asp:Textbox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ValidationExpression="^[01]?[- .]?(\([2-9]\d{2}\)|[2-9]\d{2})[- .]?\d{3}[- .]?\d{4}$"  ControlToValidate="txtpnumber" ForeColor="Red" ErrorMessage="Invalid Phone-Number"></asp:RegularExpressionValidator>

                                    </div>
                                </div>
                            </div>
                            <div class="form-group">
                                <label>City<span style="color:red">*</span></label>
                                <asp:Textbox runat="server" ID="txtcity" class="form-control" placeholder="Enter City"></asp:Textbox>
                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ControlToValidate="txtcity" runat="server" ForeColor="Red" ErrorMessage="*"></asp:RequiredFieldValidator>
                           
                            </div>
                            <div class="text-center">
                                <asp:Label ID="Label1" runat="server" ForeColor="Red"></asp:Label>
                                <asp:Button runat="server" ID="btnsubmit" Text="Submit" CausesValidation="true" OnClick="btnsubmit_Click" class="btn btn-primary mr-10"></asp:Button>
                                <asp:Button runat="server" ID="btnCancel" Text="Cancel" CausesValidation="false" OnClick="btnCancel_Click" class="btn btn-secondary"></asp:Button>
                            </div>
                            <div class="or-block d-flex align-items-center justify-content-center mt-15">
                                <div class="border-top"></div>
                                <div><span class="or-text ml-5 mr-5">OR</span></div>
                                <div class="border-top"></div>
                            </div>
                            <div class="text-center mt-5">
                                <asp:LinkButton ID="lnklogin" OnClick="lnklogin_Click" runat="server" CausesValidation="false" CssClass="login-text">Login Here</asp:LinkButton>
                                </div>
                        </div>

                    </div>
               
            </div>
        </div>
        <div class="post-header"></div>
    </div>

</asp:Content>

