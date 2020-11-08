<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" EnableEventValidation="false" CodeFile="ViewPost.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link rel="stylesheet" href="css/view-post.css" />
   

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="view-post-panel">
        <div class="panel-header"><span class="">View Your Post</span></div>
        <!-- details datatables | starts -->


        <div>
            <asp:GridView class="table" ID="GridView1" OnRowCommand="GridView1_RowCommand" runat="server" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField HeaderText="Category" DataField="category" />
                    <asp:BoundField HeaderText="Title" DataField="Title" />
                    <asp:BoundField HeaderText="Description" DataField="Description" />

                    <asp:TemplateField HeaderText="Action">

                        <ItemTemplate >
                            <div class="d-flex">
                                <a class="mr-10 position-relative tooltip-pill">
                                    <asp:ImageButton runat="server" src="Images/orange-edit.svg" alt="edit" class="default-icon" />
                                    <asp:ImageButton runat="server" CommandName="Editclick" CommandArgument='<%#Eval("CId") %>' ID="btnedit" src="Images/orange-edit-hover.svg" alt="edit" class="hover-icon" />
                                    <p>Edit</p>
                                </a>
                                <a class="mr-10 position-relative tooltip-pill">
                                    <asp:ImageButton runat="server" src="Images/orange-view.svg" alt="view" class="default-icon" />
                                    <asp:ImageButton runat="server" CommandName="Viewclick" CommandArgument='<%#Eval("CId") %>' src="Images/orange-view-hover.svg" alt="view" class="hover-icon" />
                                    <p>View</p>
                                </a>
                                <a class="mr-10 position-relative tooltip-pill">
                                    <asp:ImageButton runat="server" src="Images/orange-delete.svg" alt="delete" class="default-icon" />
                                    <asp:ImageButton runat="server" CommandName="Deleteclick" CommandArgument='<%#Eval("CId") %>' OnClientClick="return confirm('Are you sure you want to delete ?');" src="Images/orange-delete-hover.svg" alt="delete" class="hover-icon" />
                                    <p>Delete</p>
                                </a>
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>



                            
        <!-- edit details popup | starts -->
        <asp:Panel runat="server" ID="divpopup" style="display:none" class=" popup">
            <div class="popup-dialog">
                <div class="popup-header d-flex justify-content-between align-items-center">
                    <div><span class="popup-title">Edit Details</span></div>
                    <div class="">
                        <a>
                            <asp:ImageButton runat="server" ID="btnclose" OnClick="btnclose_Click" src="Images/cancel-orange-default.svg" alt="cancel"></asp:ImageButton></a>
                    </div>
                </div>
                <div class="popup-body">
                    <div class="">
                        <div class="form-group">
                            <label>First Name</label>
                            <asp:TextBox runat="server" ID="txtfname" class="form-control" placeholder="First Name"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label>Last Name</label>
                            <asp:TextBox runat="server" ID="txtlname" class="form-control" placeholder="Last Name"></asp:TextBox>
                        </div>
                        <div class="row">
                            <div class="col-lg-6">
                                <div class="form-group">
                                    <label>Email Id</label>
                                    <asp:TextBox runat="server" ID="txtemail" class="form-control" placeholder="Email Id"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-lg-6">
                                <div class="form-group">
                                    <label>Phone Number</label>
                                    <asp:TextBox runat="server" ID="txtpno" class="form-control" placeholder="Phone Number"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <label>Addressline 1</label>
                            <asp:TextBox runat="server" ID="txtadd" class="form-control" placeholder="Enter Address"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label>City</label>
                            <asp:TextBox runat="server" ID="txtcity" class="form-control" placeholder="Enter City"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label>Province</label>
                            <asp:TextBox runat="server" ID="txtprovince" class="form-control" placeholder="Enter Province"></asp:TextBox>
                        </div>
                        <div class="row">
                            <div class="col-lg-6">
                                <div class="form-group">
                                    <label>Country</label>
                                    <asp:TextBox runat="server" ID="txtcountry" type="text" class="form-control" placeholder="Enter Country"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-lg-6">
                                <div class="form-group">
                                    <label>Zip Code</label>
                                    <asp:TextBox runat="server" ID="txtzipcode" class="form-control" placeholder="Enter Zip Code"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <label>Title</label>
                            <asp:TextBox ID="txttitle" runat="server" class="form-control"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label>Description</label>
                            <asp:TextBox runat="server" TextMode="MultiLine" Height="5%" ID="txtDesc" class="form-control"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label>Category</label>
                            <asp:DropDownList ID="ddlcatageory" runat="server" class="form-control">
                                <asp:ListItem Selected="True">Choose</asp:ListItem>
                                <asp:ListItem>Accomodation</asp:ListItem>
                                <asp:ListItem>Food</asp:ListItem>
                                <asp:ListItem>Entertainment</asp:ListItem>
                                <asp:ListItem>Medical</asp:ListItem>
                                <asp:ListItem>House-help</asp:ListItem>
                                <asp:ListItem>Job</asp:ListItem>
                                <asp:ListItem>Ride</asp:ListItem>
                                <asp:ListItem>Others</asp:ListItem>

                            </asp:DropDownList>
                        </div>
                    </div>
                </div>
                <div class="popup-footer text-right">
                    <asp:Label ID="Label1" runat="server" ForeColor="Red"></asp:Label>
                    <asp:Button runat="server" ID="btnupdate" Text-="Update" OnClick="btnupdate_Click" class="btn-large btn-primary"></asp:Button>
                    <asp:Button runat="server" ID="btncancel" Text="Cancel" OnClick="btncancel_Click" class="btn-large btn-primary ml-10"></asp:Button>
                </div>
            </div>
        </asp:Panel>

        <!-- edit details popup | ends -->

    </div>





</asp:Content>

