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
    public partial class ModuleList : System.Web.UI.Page
    {
        AdvancePOSDataContext db = new AdvancePOSDataContext();
        GeneralHelper dHelper = new GeneralHelper();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                PopulateModulelist();
                PopulateParentModule();
            }
        }

        private void PopulateParentModule()
        {
            var moduleList = db.sp_ModuleList(null).OrderBy(s => s.FullName);
            ddlParentModule.DataSource = moduleList;
            ddlParentModule.DataValueField = "ID";
            ddlParentModule.DataTextField = "FullName";
            ddlParentModule.DataBind();
        }

        //get all modules
        private void PopulateModulelist()
        {
            var module = db.sp_ModuleList(null).ToList();
            gvModule.DataSource = module;
            gvModule.DataBind();
            if (module.Count() > 0)
            {
                gvModule.UseAccessibleHeader = true;
                gvModule.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            tblModule module;
            if (HiddenID.Value == "")
                module = new tblModule();
            else
                module = db.tblModules.FirstOrDefault(s => s.ID == Convert.ToInt32(HiddenID.Value));
            if (module != null)
            {
                if (ddlParentModule.SelectedIndex > 0)
                    module.ParentModuleID = Convert.ToInt32(ddlParentModule.SelectedValue);
                else
                    module.ParentModuleID = 0;
                module.DisplayOrder = Convert.ToInt32(txtDisplayOrder.Text);
                module.ModuleName = txtModuleName.Text;
                module.PageIcon = txtPageIcon.Text;
                module.PageSlug = dHelper.GetModuleSlug(txtModuleName.Text, module.ParentModuleID.Value);
                module.PageUrl = txtPageUrl.Text;
                module.IsActive = true;
                module.IsDeleted = false;
                module.IsShow = true;
                if (HiddenID.Value == "")
                    db.tblModules.InsertOnSubmit(module);
                db.SubmitChanges();
                PopulateModulelist();
                PopulateParentModule();
                SetDefaultValue();
            }
        }

        protected void btnClose_Click(object sender, EventArgs e)
        {
            PopulateModulelist();
            SetDefaultValue();
        }

        public void SetDefaultValue()
        {
            ltrTitle.Text = "Add Module";
            txtDisplayOrder.Text = "";
            ddlParentModule.SelectedValue = "0";
            txtModuleName.Text = "";
            txtPageIcon.Text = "";
            txtPageUrl.Text = "";
            HiddenID.Value = "";
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#edit').modal('hide');", true);
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "gridview", "$('#MainContent_gvModule').DataTable();", true);
            upModal.Update();
        }
    }
}