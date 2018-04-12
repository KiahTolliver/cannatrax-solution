using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AdvancePOS.Models;
using AdvancePOS.Helper;

namespace AdvancePOS.User
{
    public partial class ManageRole : System.Web.UI.Page
    {
        GeneralHelper dHelper = new GeneralHelper();
        AdvancePOSDataContext db = new AdvancePOSDataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {                
                try
                {
                    if (Session["RoleID"] != null)
                    {
                        dHelper.LogAction("User View Role Master");
                        var role = db.tblRoles.FirstOrDefault(s => s.ID == Convert.ToInt32(Session["RoleID"].ToString()));
                        if (role != null)
                            HiddenRoleID.Value = role.ID.ToString();
                    }
                    PopulateRoles();
                    PopulateModuels();
                }
                catch { }                
            }
        }

        //Get All Modules
        private void PopulateModuels()
        {
            var modules = db.sp_ModuleList(null);
            CheckBoxListModule.DataSource = modules;
            CheckBoxListModule.DataValueField = "ID";
            CheckBoxListModule.DataTextField = "FullName";
            CheckBoxListModule.DataBind();
        }

        //Get All Roles
        private void PopulateRoles()
        {
            var roles = db.sp_GetRole(null).ToList();
            gvRole.DataSource = roles;
            gvRole.DataBind();
            if (roles.Count() > 0)
            {
                gvRole.UseAccessibleHeader = true;
                gvRole.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        //Save and Update Role
        protected void btnSave_Click(object sender, EventArgs e)
        {
            System.Data.Common.DbTransaction transaction;
            db.Connection.Open();
            transaction = db.Connection.BeginTransaction();
            db.Transaction = transaction;
            int? roleID = 0;
            int UserID = 0;
            if (Session["UserID"] != null)
                UserID = Convert.ToInt32(Session["UserID"].ToString());

            if (HiddenID.Value == "")
            {
                db.sp_RoleAdd(txtName.Text, UserID, UserID, ref roleID);
                dHelper.LogAction("User Add Role " + txtName.Text);
            }
            else
            {
                db.sp_RoleUpdate(Convert.ToInt32(HiddenID.Value), txtName.Text, UserID);
                dHelper.LogAction("User Update Role " + txtName.Text);
            }
            
            //Delete all role permission
            if (HiddenID.Value != "")
            {
                var userModules = db.tblUserPermissions.Where(s => s.RoleID == Convert.ToInt32(HiddenID.Value));
                db.tblUserPermissions.DeleteAllOnSubmit(userModules);
                roleID = Convert.ToInt32(HiddenID.Value);
            }

            //Add role permission
            foreach (ListItem l in CheckBoxListModule.Items)
            {
                if (l.Selected)
                {
                    Models.tblUserPermission userMod = new Models.tblUserPermission();
                    userMod.RoleID = roleID;
                    userMod.ModuleID = Convert.ToInt32(l.Value);
                    db.tblUserPermissions.InsertOnSubmit(userMod);
                    db.SubmitChanges();
                }
            }
            db.SubmitChanges();
            transaction.Commit();
            PopulateRoles();
            SetDefaultValue();
        }

        //Delete Role
        protected void LinkDelete_Click(object sender, EventArgs e)
        {
            PnError.Visible = false;
            LinkButton l = (LinkButton)sender;

            var role = db.tblRoles.FirstOrDefault(s => s.ID == Convert.ToInt32(l.CommandArgument));
            if (role != null)
            {
                if (GeneralHelper.IsDeleteEnable == true)
                {
                    if (role.IsDefault == true)
                    {
                        PnError.Visible = true;
                        ltrError.Text = "Delete disable to default role.!!!";
                    }
                    else
                    {
                        //Delete all role permission
                        var rolePermission = db.tblUserPermissions.Where(s => s.RoleID == role.ID);
                        db.tblUserPermissions.DeleteAllOnSubmit(rolePermission);
                        role.IsDeleted = true;
                        db.SubmitChanges();
                        dHelper.LogAction("User Delete Role " + txtName.Text);
                    }
                }
                else
                {
                    PnError.Visible = true;
                    ltrError.Text = "disable delete action in demo.!!!";
                }
                PopulateRoles();
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "gridview", "$('#MainContent_gvRole').DataTable();", true);
            }            
        }

        //Edit Roles
        protected void LinkEdit_Click(object sender, EventArgs e)
        {

            PnError.Visible = false;
            LinkButton l = (LinkButton)sender;
            HiddenID.Value = l.CommandArgument.ToString();
            var role = db.tblRoles.FirstOrDefault(s => s.ID == Convert.ToInt32(l.CommandArgument));
            if (role != null)
            {                
                if (role.IsDefault == true)
                {
                    PnError.Visible = true;
                    ltrError.Text = "Edit disable to default role.!!!";
                }
                else
                {
                    ltrTitle.Text = "Edit Role " + role.Name;
                    txtName.Text = role.Name;
                    var userModule = db.tblUserPermissions.Where(s => s.RoleID == role.ID);
                    foreach (var c in userModule)
                    {
                        ListItem lcheck = CheckBoxListModule.Items.FindByValue(c.ModuleID.Value.ToString());
                        if (lcheck != null)
                            lcheck.Selected = true;
                    }
                    dHelper.LogAction("User Edit Role " + role.Name);
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#edit').modal({backdrop: 'static', keyboard: false});", true);
                }                
                
                PopulateRoles();
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "gridview", "$('#MainContent_gvRole').DataTable();", true);
                upModal.Update();
            }
        }

        protected void btnClose_Click(object sender, EventArgs e)
        {            
            PopulateRoles();
            SetDefaultValue();            
        }

        public void SetDefaultValue()
        {
            PopulateModuels();
            ltrTitle.Text = "Add Role";                        
            txtName.Text = "";            
            HiddenID.Value = "";
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#edit').modal('hide');", true);
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "gridview", "$('#MainContent_gvRole').DataTable();", true);
            upModal.Update();
        }
    }
}