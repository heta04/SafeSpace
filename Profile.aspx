<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Profile.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script type="text/javascript">
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


      <div class="dashboard-panel">
        <div class="container-fluid pl-0 pr-0">

            <!-- view profile | starts -->
            <div class="profile-panel">
                <div class="profile-box">
                    <div class="text-center pb-50">
                        <div><asp:LinkButton runat="server" ID="lnkpass" CausesValidation="false" OnClick="lnkpass_Click" class="change-pwd">Change Password?</asp:LinkButton></div>
                        <div><asp:LinkButton runat="server" ID="lnkinfo" CausesValidation="false" OnClick="lnkinfo_Click" class="info-text">Edit Information</asp:LinkButton></div>
                    </div>
                    <!-- change pwd info | starts -->
                    <div class="pwd-info" runat="server" id="divpass">
                        <div class="form-group">
                            <label>Current Password<span style="color:red">*</span></label>
                            <asp:TextBox class="form-control" type="password" runat="server" ID="txtcpass" placeholder="Enter your Current Password"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtcpass" runat="server" ForeColor="Red" ErrorMessage="*"></asp:RequiredFieldValidator>

                        </div>
                        <div class="form-group">
                            <label>New Password<span style="color:red">*</span></label>
                            <asp:TextBox class="form-control" type="password" runat="server" ID="txtnpass" placeholder="Enter your New Password"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtnpass" runat="server" ForeColor="Red" ErrorMessage="*"></asp:RequiredFieldValidator>

                        </div>
                        <div class="form-group">
                            <label>Re-enter Password<span style="color:red">*</span></label>
                            <asp:TextBox class="form-control" type="password" runat="server" ID="txtrpass" placeholder="Re-enter your New Password"></asp:TextBox>
                          <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="txtrpass" runat="server" ForeColor="Red" ErrorMessage="*"></asp:RequiredFieldValidator>
                              <asp:CompareValidator ID="CompareValidator1" runat="server"
                                  ForeColor="Red" ControlToValidate="txtrpass" ControlToCompare="txtnpass" 
                                  ErrorMessage="Password doesnot match"></asp:CompareValidator>

                        </div>
                        <div class="btn-grp d-flex align-items-end justify-content-end">
                            <asp:Label ID="Label2" runat="server" ForeColor="Red"></asp:Label>
                            <asp:Button runat="server" id="btnpsubmit" OnClick="btnpsubmit_Click" Text="Submit" class="btn-primary btn-small mr-10"></asp:Button>
                            <asp:Button runat="server" ID="btnpcancel" OnClick="btnpcancel_Click" Text="Cancel" class="btn-primary btn-small"></asp:Button>
                        </div>
                    </div>
                    <!-- change pwd info | ends -->

                    <!-- edit info | starts -->
                    <div class="info-panel" runat="server" visible="false" id="divinfo">
                        <div class="">
                            <div class="form-group">
                                <label>First Name<span style="color:red">*</span></label>
                                <asp:TextBox id="txtfname" runat="server" class="form-control" onkeypress="return isOnlyAlphabet(event)" placeholder="First Name"></asp:TextBox>
                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="txtfname" runat="server" ForeColor="Red" ErrorMessage="*"></asp:RequiredFieldValidator>

                                </div>
                            <div class="form-group">
                                <label>Last Name<span style="color:red">*</span></label>
                                <asp:TextBox runat="server" ID="txtlname" class="form-control"  onkeypress="return isOnlyAlphabet(event)" placeholder="Last Name"></asp:TextBox>
                           <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ControlToValidate="txtlname" runat="server" ForeColor="Red" ErrorMessage="*"></asp:RequiredFieldValidator>
                                </div>
                            
                            <div class="row">
                                <div class="col-lg-6">
                                    <div class="form-group">
                                        <label>Email Id<span style="color:red">*</span></label>
                                        <asp:TextBox runat="server" ID="txtemail" ReadOnly="true" class="form-control" placeholder="Email Id"></asp:TextBox>
                                   <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ControlToValidate="txtemail" runat="server" ForeColor="Red" ErrorMessage="*"></asp:RequiredFieldValidator>
                                           <asp:RegularExpressionValidator ID="regexEmailValid" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtemail" ForeColor="Red" ErrorMessage="Invalid Email Format"></asp:RegularExpressionValidator>

                                        </div>
                                </div>
                                <div class="col-lg-6">
                                    <div class="form-group">
                                        <label>Phone Number</label>
                                        <asp:TextBox runat="server" ID="txtphone"  onkeypress="return isIntKey(event)"  class="form-control" placeholder="Phone Number"></asp:TextBox>
                                     <asp:RegularExpressionValidator ID="RegularExpressionValidator1"
                                     runat="server"
                                    ValidationExpression="^[01]?[- .]?(\([2-9]\d{2}\)|[2-9]\d{2})[- .]?\d{3}[- .]?\d{4}$" 
                                         ControlToValidate="txtphone" ForeColor="Red" ErrorMessage="Invalid Phone-Number"></asp:RegularExpressionValidator>

                                        </div>
                                </div>
                            </div>
                            <div class="form-group">
                                <label>City<span style="color:red">*</span></label>
                                <asp:TextBox runat="server" ID="txtcity" class="form-control" placeholder="Enter City"></asp:TextBox>
                           <asp:RequiredFieldValidator ID="RequiredFieldValidator7" ControlToValidate="txtcity" runat="server" ForeColor="Red" ErrorMessage="*"></asp:RequiredFieldValidator>

                                </div>
                            <div class="text-right">
                                <asp:Label ID="Label1" runat="server" ForeColor="Red"></asp:Label>
                                     <asp:Button runat="server" ID="btnisubmit" OnClick="btnisubmit_Click" Text="Submit" class="btn-primary btn-small mr-10"></asp:Button>
                            <asp:Button runat="server" ID="btnicancel" OnClick="btnicancel_Click" Text="Cancel" class="btn-primary btn-small"></asp:Button>
                      </div>
                        </div>
                    </div>
                    <!-- edit info | ends -->
                </div>
            </div>
            <!-- view profile | ends -->
        </div>

</div>

</asp:Content>

