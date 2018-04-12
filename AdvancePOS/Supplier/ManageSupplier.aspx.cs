using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AdvancePOS.Models;
using AdvancePOS.Helper;

namespace AdvancePOS.Supplier
{
    public partial class ManageSupplier : System.Web.UI.Page
    {
        AdvancePOSDataContext db = new AdvancePOSDataContext();
        GeneralHelper dHelper = new GeneralHelper();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {                
                PopulateSupplier();
                dHelper.LogAction("User View Supplier Master");
            }
        }

        private void PopulateSupplier()
        {
            var supplier = db.sp_GetSupplier().ToList();
            gvSupplier.DataSource = supplier;
            gvSupplier.DataBind();
            if (supplier.Count() > 0)
            {
                gvSupplier.UseAccessibleHeader = true;
                gvSupplier.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "gridview", "$('#MainContent_gvSupplier').DataTable();", true);
        }

        //Save and Update Supplier
        protected void btnSave_Click(object sender, EventArgs e)
        {
            int UserID = 0;
            if (Session["UserID"] != null)
                UserID = Convert.ToInt32(Session["UserID"].ToString());

            if (HiddenID.Value == "")
            {
                db.sp_SupplierAdd(txtName.Text, txtCompanyame.Text, txtAddress.Text, txtPhoneNo.Text, txtCity.Text, txtEmail.Text, ddlSupplierType.SelectedValue, UserID, UserID);
                dHelper.LogAction("User Add Supplier " + txtName.Text);
            }
            else
            {
                db.sp_SupplierUpdate(Convert.ToInt32(HiddenID.Value), txtName.Text, txtCompanyame.Text, txtAddress.Text, txtPhoneNo.Text, txtCity.Text, txtEmail.Text, ddlSupplierType.SelectedValue, UserID);
                dHelper.LogAction("User Update Supplier " + txtName.Text);
            }

            SetDefaultValue();
        }     

        //Edit Supplier
        protected void LinkEdit_Click(object sender, EventArgs e)
        {
            LinkButton l = (LinkButton)sender;
            HiddenID.Value = l.CommandArgument;
            var supplier = db.tblSuppliers.FirstOrDefault(s => s.ID == Convert.ToInt32(HiddenID.Value));
            if (supplier != null)
            {
                ltrTitle.Text = "Edit Supplier : " + supplier.Name;
                txtName.Text = supplier.Name;
                txtCompanyame.Text = supplier.CompanyName;
                txtAddress.Text = supplier.Address;
                txtPhoneNo.Text = supplier.PhoneNo;
                txtEmail.Text = supplier.Email;
                txtCity.Text = supplier.City;
                ddlSupplierType.SelectedValue = supplier.SupplierType;

                dHelper.LogAction("User Edit Supplier " + supplier.Name);
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "mymodal", "$('#edit').modal({backdrop: 'static', keyboard: false});", true);

                PopulateSupplier();
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "gridview", "$('#MainContent_gvSupplier').DataTable();", true);
                upModal.Update();
            }
        }

        //Delete Customer
        protected void LinkDelete_Click(object sender, EventArgs e)
        {
            PnError.Visible = false;
            LinkButton l = (LinkButton)sender;

            var spplier = db.tblSuppliers.FirstOrDefault(s => s.ID == Convert.ToInt32(l.CommandArgument));
            if (spplier != null)
            {
                if (GeneralHelper.IsDeleteEnable == true)
                {
                    spplier.IsDeleted = true;
                    db.SubmitChanges();
                    dHelper.LogAction("User Delete Supplier " + spplier.Name);
                }
                else
                {
                    PnError.Visible = true;
                    ltrError.Text = "Enable to delete in demo.!!!";
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
            PopulateSupplier();
            HiddenID.Value = "";
            ltrTitle.Text = "Add Supplier";
            txtName.Text = "";
            txtAddress.Text = "";
            txtPhoneNo.Text = "";
            txtEmail.Text = "";
            txtCompanyame.Text = "";
            txtCity.Text = "";

            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#edit').modal('hide');", true);
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "gridview", "$('#MainContent_gvSupplier').DataTable();", true);
            upModal.Update();
        }
    }
}