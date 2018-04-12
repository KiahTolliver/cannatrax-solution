using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AdvancePOS.Models;
using AdvancePOS.Helper;

namespace AdvancePOS.Items
{
    public partial class ManageCategory : Page
    {
        AdvancePOSDataContext db = new AdvancePOSDataContext();
        GeneralHelper dHelper = new GeneralHelper();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                PopulateCategory();
                dHelper.LogAction("User View Category Master");
            }
        }

        private void PopulateCategory()
        {
            var category = db.sp_GetCategory().ToList();
            gvCategory.DataSource = category;
            gvCategory.DataBind();
            if (category.Count() > 0)
            {
                gvCategory.UseAccessibleHeader = true;
                gvCategory.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "gridview", "$('#MainContent_gvCategory').DataTable();", true);
        }

        //Save and Update Category
        protected void btnSave_Click(object sender, EventArgs e)
        {
            int UserID = 0;
            if (Session["UserID"] != null)
                UserID = Convert.ToInt32(Session["UserID"].ToString());

            if (HiddenID.Value == "")
            {
                db.sp_CategoryAdd(txtName.Text, UserID);
                dHelper.LogAction("User Add Category " + txtName.Text);
            }
            else
            {
                db.sp_CategoryUpdate(Convert.ToInt32(HiddenID.Value), txtName.Text, UserID);
                dHelper.LogAction("User Update Category " + txtName.Text);
            }

            SetDefaultValue();
        }

        //Edit Category
        protected void LinkEdit_Click(object sender, EventArgs e)
        {
            LinkButton l = (LinkButton)sender;
            HiddenID.Value = l.CommandArgument;
            var category = db.tblCategories.FirstOrDefault(s => s.ID == Convert.ToInt32(HiddenID.Value));
            if (category != null)
            {
                ltrTitle.Text = "Edit Category : " + category.Name;
                txtName.Text = category.Name;                

                dHelper.LogAction("User Edit Category " + category.Name);
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "mymodal", "$('#edit').modal({backdrop: 'static', keyboard: false});", true);

                PopulateCategory();
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "gridview", "$('#MainContent_gvCategory').DataTable();", true);
                upModal.Update();
            }
        }

        //Delete Category
        protected void LinkDelete_Click(object sender, EventArgs e)
        {
            PnError.Visible = false;
            LinkButton l = (LinkButton)sender;

            var category = db.tblCategories.FirstOrDefault(s => s.ID == Convert.ToInt32(l.CommandArgument));
            if (category != null)
            {
                if (GeneralHelper.IsDeleteEnable == true)
                {
                    category.IsDeleted = true;
                    db.SubmitChanges();
                    dHelper.LogAction("User Delete Category " + category.Name);
                }
                else
                {
                    PnError.Visible = true;
                    ltrError.Text = "disable delete action in demo.!!!";
                }
                SetDefaultValue();
            }
        }

        protected void btnClose_Click(object sender, EventArgs e)
        {
            SetDefaultValue();
        }

        public void SetDefaultValue()
        {
            PopulateCategory();
            HiddenID.Value = "";
            ltrTitle.Text = "Add Category";
            txtName.Text = "";            

            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#edit').modal('hide');", true);
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "gridview", "$('#MainContent_gvCategory').DataTable();", true);
            upModal.Update();
        }
    }
}