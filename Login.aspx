<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <div class="container-fluid">
        <div class="post-header">
            <div class=""></div>
        </div>
               
        <div class="login-body">
            <div class="card-header text-center">
                <label class="mb-0">Login</label>
            </div>
            <div class="content-body">
               
                    <div class="form-panel mt-20 mb-20">

                        <div class="">

                            <div class="form-group">
                                <label>Email Id</label>   <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtemail" runat="server" ForeColor="Red" ErrorMessage="*"></asp:RequiredFieldValidator>
                             
                                <asp:Textbox runat="server" ID="txtemail" class="form-control" placeholder="Email Id"></asp:Textbox>
                               <asp:RegularExpressionValidator ID="regexEmailValid" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtemail" ForeColor="Red" ErrorMessage="Invalid Email Format"></asp:RegularExpressionValidator>

                            </div>
                            <div class="form-group">
                                <label>Password</label> <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtpass" runat="server" ForeColor="Red" ErrorMessage="*"></asp:RequiredFieldValidator>
                            
                                <asp:Textbox runat="server" ID="txtpass" type="password" class="form-control" placeholder="Password"></asp:Textbox>
                            
                                </div>
                            <div style="text-align:center" class="form-group">
                            <asp:Label ID="Label1" runat="server" ForeColor="Red"></asp:Label>
                            </div>
                            <div class="text-center mt-50">
                                <asp:button runat="server" ID="btnsubmit" CausesValidation="true" OnClick="btnsubmit_Click" Text="Log In" class="btn btn-primary mr-10"></asp:button>
                                <asp:button runat="server" ID="btncancel" CausesValidation="false" OnClick="btncancel_Click" Text="Cancel" class="btn btn-secondary"></asp:button>
                            </div>
                            <div class="text-center mt-50">
                                <span class="new-user color-black font-18">New User ?</span>
                                <asp:LinkButton  runat="server" ID="btnsignup" CausesValidation="false" Text="Sign Up" OnClick="signup_Click" class="btn-signup font-18"></asp:LinkButton>
                               </div>
                              
                        </div>

                    </div>
               
            </div>
        </div>
               
        <div class="post-header"></div>
    </div>

</asp:Content>

