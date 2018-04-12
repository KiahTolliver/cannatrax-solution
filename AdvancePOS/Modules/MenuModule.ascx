<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MenuModule.ascx.cs"
    Inherits="AdvancePOS.Modules.MenuModule" %>
<asp:HiddenField ID="HiddenRoleID" runat="server" />
<asp:HiddenField ID="HiddenSlug" runat="server" />
<asp:HiddenField ID="HiddenMenuType" runat="server" />
<asp:HiddenField ID="HiddenIsSuperAdmin" runat="server" />
<asp:Repeater ID="RepeaterMenu" runat="server" OnItemDataBound="RepeaterMenu_ItemDataBound">
    <ItemTemplate>
        <li id='<%#Eval("Pageslug") %>' class="treeview"><a href='<%#Eval("PageUrl","{0}") %>'>
            <i class='<%#Eval("PageIcon","fa {0}") %>'></i><span class="menu-title">
                <%#Eval("ModuleName") %></span>
            <asp:Literal ID="ltrArrow" runat="server" /></a>
            <asp:Literal ID="ltrSubMenu" runat="server" />
        </li>
    </ItemTemplate>
</asp:Repeater>
<li id="limodule" runat="server" visible="false"><a href="/User/ModuleList.aspx"><i
    class="fa fa-book"></i><span>Module</span></a></li>
<script type="text/javascript">
    jQuery(document).ready(function () {
        var currentMenu = $('#Menu1_HiddenSlug').val();
        $('#side-menu li').removeClass('active');
        $('#' + currentMenu).parent('ul').addClass('in');
        $('#' + currentMenu).parent().parent().addClass('active');
        $('#' + currentMenu).addClass('active');
        if (currentMenu == "")
            $('#side-menu li:first').addClass('active');
    });
</script>
