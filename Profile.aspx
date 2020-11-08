<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Profile.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


      <div class="dashboard-panel">
        <div class="container-fluid pl-0 pr-0">

            <!-- view profile | starts -->
            <div class="profile-panel">
                <div class="profile-box">
                    <div class="text-center pb-50">
                        <div><asp:LinkButton runat="server" ID="lnkpass" OnClick="lnkpass_Click" class="change-pwd">Change Password?</asp:LinkButton></div>
                        <div><asp:LinkButton runat="server" ID="lnkinfo" OnClick="lnkinfo_Click" class="info-text">Edit Information</asp:LinkButton></div>
                    </div>
                    <!-- change pwd info | starts -->
                    <div class="pwd-info" runat="server" id="divpass">
                        <div class="form-group">
                            <label>Current Password</label>
                            <asp:TextBox class="form-control" type="password" runat="server" ID="txtcpass" placeholder="Enter your Current Password"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label>New Password</label>
                            <asp:TextBox class="form-control" type="password" runat="server" ID="txtnpass" placeholder="Enter your New Password"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label>Re-enter Password</label>
                            <asp:TextBox class="form-control" type="password" runat="server" ID="txtrpass" placeholder="Re-enter your New Password"></asp:TextBox>
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
                                <label>First Name</label>
                                <asp:TextBox id="txtfname" runat="server" class="form-control" placeholder="First Name"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label>Last Name</label>
                                <asp:TextBox runat="server" ID="txtlname" class="form-control" placeholder="Last Name"></asp:TextBox>
                            </div>
                            
                            <div class="row">
                                <div class="col-lg-6">
                                    <div class="form-group">
                                        <label>Email Id</label>
                                        <asp:TextBox runat="server" ID="txtemail" ReadOnly="true" class="form-control" placeholder="Email Id"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-lg-6">
                                    <div class="form-group">
                                        <label>Phone Number</label>
                                        <asp:TextBox runat="server" ID="txtphone" type="number" class="form-control" placeholder="Phone Number"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="form-group">
                                <label>City</label>
                                <asp:TextBox runat="server" ID="txtcity" class="form-control" placeholder="Enter City"></asp:TextBox>
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

