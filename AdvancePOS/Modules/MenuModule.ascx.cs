using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AdvancePOS.Models;

namespace AdvancePOS.Modules
{
    public partial class MenuModule : System.Web.UI.UserControl
    {
        AdvancePOSDataContext db = new AdvancePOSDataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                try
                {
                    if (Session["UserID"] != null)
                    {
                        int UserID = Convert.ToInt32(Session["UserID"]);
                        var userInfo = db.tblUsers.FirstOrDefault(s => s.ID == UserID);
                        if (userInfo != null)
                        {
                            HiddenRoleID.Value = userInfo.RoleID.ToString();                            
                        }
                    }
                }
                catch (NullReferenceException)
                {
                    Response.Redirect("/Login.aspx");
                }
                PopulateMenus();
            }
        }

        // get all parent menus
        private void PopulateMenus()
        {
            var menus = db.tblModules.Where(s => s.ParentModuleID == 0 && s.IsDeleted == false).OrderBy(s => s.DisplayOrder).ToList();
            if (HiddenRoleID.Value != "")
            {
                var role = db.tblRoles.FirstOrDefault(s => s.ID == Convert.ToInt32(HiddenRoleID.Value));
                if (role != null)
                {
                    HiddenIsSuperAdmin.Value = role.IsSuperAdmin.ToString();
                    CheckUserPermission();
                    if (role.IsSuperAdmin == false)
                    {
                        //check user permission
                        menus = (from m in menus
                                 join u in db.tblUserPermissions on m.ID equals u.ModuleID
                                 where u.RoleID == Convert.ToInt32(HiddenRoleID.Value)
                                 select m).ToList();
                    }
                    else if (role.IsSuperAdmin == true)
                        limodule.Visible = true;
                }
            }

            RepeaterMenu.DataSource = menus;
            RepeaterMenu.DataBind();
        }

        protected void RepeaterMenu_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Literal lArrow = (Literal)e.Item.FindControl("ltrArrow");
                Literal lSubMenu = (Literal)e.Item.FindControl("ltrSubMenu");
                Repeater rMenu = (Repeater)e.Item.FindControl("RepeaterSubMenu");
                var sMenu = db.tblModules.Where(s => s.ParentModuleID == Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "ID").ToString()) && s.IsDeleted == false).ToList();

                if (HiddenRoleID.Value != "")
                {
                    var role = db.tblRoles.FirstOrDefault(s => s.ID == Convert.ToInt32(HiddenRoleID.Value));
                    if (role != null)
                    {
                        if (!role.IsSuperAdmin.Value)
                        {
                            sMenu = (from m in sMenu
                                     join u in db.tblUserPermissions on m.ID equals u.ModuleID
                                     where u.RoleID == Convert.ToInt32(HiddenRoleID.Value)
                                     select m).ToList();
                        }
                    }
                }
                if (sMenu.Count() > 0)
                {
                    String str = "";
                    lArrow.Text = "<i class=\"fa fa-angle-left pull-right\"></i>";
                    str = "<ul class=\"treeview-menu\">";                    

                    foreach (var m in sMenu)
                    {
                        String ModuleName = m.ModuleName;
                        str += String.Format("<li id='{0}'><a href=\"{1}\"><i class=\"fa {3}\"></i><span class=\"submenu-title\"> &nbsp;{2}</span></a></li>", m.PageSlug, m.PageUrl, ModuleName, m.PageIcon);
                    }
                    str += "</ul>";
                    lSubMenu.Text = str;
                }
            }
        }

        private void CheckUserPermission()
        {
            string url = Request.Path.ToLower();

            if (url.EndsWith(".aspx"))
            {
                
                string[] LinkUrl = url.Split('/');
                string slug = LinkUrl[LinkUrl.Length - 1];
                url = url.Replace("/advancepos", "");
                var module = db.tblModules.FirstOrDefault(s => s.PageUrl.ToLower() == url.ToLower()); //check menu name 
                if (module != null)
                {
                    HiddenSlug.Value = module.PageSlug;
                    if (HiddenIsSuperAdmin.Value == "False")
                    {
                        if (Session["UserID"] != null)
                        {
                            int UserID = Convert.ToInt32(Session["UserID"]);
                            var userInfo = db.tblUsers.FirstOrDefault(s => s.ID == UserID);
                            if (userInfo != null)
                            {
                                var Rmodule = (from m in db.tblUserPermissions
                                               where m.RoleID == userInfo.RoleID
                                               where m.ModuleID == module.ID
                                               select m).FirstOrDefault();
                                if (Rmodule == null)
                                    Response.Redirect("/Default.aspx");
                            }
                        }
                    }
                }
            }
        }
    }
}