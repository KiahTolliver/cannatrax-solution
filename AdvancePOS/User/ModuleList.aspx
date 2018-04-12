<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="ModuleList.aspx.cs" Inherits="AdvancePOS.User.ModuleList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="content-wrapper">
        <!-- Content Header (Page header) -->
        <section class="content-header">
      <h1>
        Module List        
      </h1>
      <ol class="breadcrumb">
        <li><a href="/default.aspx"><i class="fa fa-dashboard"></i> Home</a></li>        
        <li class="active">Module List</li>
      </ol>
    </section>
        <!-- Main content -->
        <section class="content">
      <div class="row">
        <div class="col-xs-12">          
            <!-- /.box -->
          <div class="box box-primary">           
            <!-- /.box-header -->
            <div class="box-body">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>            
            <button type="button" class="btn margin btn-success btn-sm" data-toggle="modal" data-target="#edit">Add New Module</button>
             <asp:GridView ID="gvModule" runat="server" CssClass="table table-bordered table-striped"
                    AutoGenerateColumns="false">
                    <Columns>
                      <asp:TemplateField HeaderText="Sr.No#">
                        <ItemStyle Width="30px" HorizontalAlign="Center" />
                        <ItemTemplate>
                            <%# Container.DataItemIndex + 1 %>
                        </ItemTemplate>
                    </asp:TemplateField>
                        <asp:TemplateField HeaderText="Name">
                            <ItemTemplate>
                                <asp:Literal ID="ltrName" Text='<%#Eval("FullName") %>' runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>                      
                    </Columns>
                </asp:GridView>     
                </ContentTemplate>
            </asp:UpdatePanel>                   
            </div>
            <!-- /.box-body -->
          </div>
          <!-- /.box -->
        </div>
        <!-- /.col -->
      </div>
      <!-- /.row -->
    </section>
        <!-- /.content -->
    </div>
    <div class="modal fade" id="edit" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
        <div class="modal-dialog" role="document">
            <asp:UpdatePanel ID="upModal" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
                <ContentTemplate>
                    <div class="modal-content">
                        <div class="modal-header">
                            <asp:LinkButton ID="LinkButtonClose" CssClass="close" runat="server" OnClick="btnClose_Click"><span aria-hidden="true">&times;</span></asp:LinkButton>
                            <h4 class="modal-title">
                                <asp:HiddenField ID="HiddenID" runat="server" />
                                <asp:Literal ID="ltrTitle" runat="server" Text="Add Module" /></h4>
                        </div>
                        <div class="tab-content">
                            <div class="modal-body">
                                <div class="col-md-12 col-sm-12">
                                    <div class="row">
                                        <div class="col-md-12 col-sm-12">
                                            <div class="form-group">
                                                <label for="role">
                                                    Display Order
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtDisplayOrder"
                                                        ForeColor="Red" ValidationGroup="module" SetFocusOnError="true" ErrorMessage="This field is require !!!"></asp:RequiredFieldValidator></label>
                                                <asp:TextBox ID="txtDisplayOrder" runat="server" CssClass="form-control" />
                                            </div>
                                            <div class="form-group">
                                                <label>
                                                    Parent Module
                                                </label>
                                                <asp:DropDownList ID="ddlParentModule" runat="server" CssClass="form-control"
                                                    Width="100%" AppendDataBoundItems="true">
                                                    <asp:ListItem Value="0">-----Select-----</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                            <div class="form-group">
                                                <label for="role">
                                                    Module Name
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtModuleName"
                                                        ForeColor="Red" ValidationGroup="module" SetFocusOnError="true" ErrorMessage="This field is require !!!"></asp:RequiredFieldValidator></label>
                                                <asp:TextBox ID="txtModuleName" runat="server" CssClass="form-control" />
                                            </div>
                                            <div class="form-group">
                                                <label for="role">
                                                    Page Icon</label>
                                                <asp:TextBox ID="txtPageIcon" runat="server" CssClass="form-control" placeholder="fa-dashboard" />
                                            </div>
                                            <div class="form-group">
                                                <label for="role">
                                                    Page Url
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtPageUrl"
                                                        ForeColor="Red" ValidationGroup="module" SetFocusOnError="true" ErrorMessage="This field is require !!!"></asp:RequiredFieldValidator></label>
                                                <asp:TextBox ID="txtPageUrl" runat="server" CssClass="form-control" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="modal-footer">
                            <asp:Button ID="btnClose" runat="server" Text="Close" CssClass="btn btn-default"
                                OnClick="btnClose_Click" />
                            <asp:Button ID="btnSave" runat="server" Text="Save Changes" CssClass="btn btn-primary"
                                ValidationGroup="module" OnClick="btnSave_Click" />
                        </div>
                    </div>
                </ContentTemplate>
                <Triggers>
                    <%--<asp:PostBackTrigger ControlID="btnSave" />--%>
                </Triggers>
            </asp:UpdatePanel>
        </div>
    </div>
    <script>
        $(function () {
            $("#MainContent_gvModule").DataTable();
            $(".select2").select2();
        });
    </script>
</asp:Content>
