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
    public partial class ManageTax : System.Web.UI.Page
    {
        AdvancePOSDataContext db = new AdvancePOSDataContext();
        GeneralHelper dHelper = new GeneralHelper();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                PopulateTax();
                dHelper.LogAction("User View Tax Master");
            }
        }

        private void PopulateTax()
        {
            var tax = db.sp_GetTax().ToList();
            gvTax.DataSource = tax;
            gvTax.DataBind();
            if (tax.Count() > 0)
            {
                gvTax.UseAccessibleHeader = true;
                gvTax.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "gridview", "$('#MainContent_gvTax').DataTable();", true);
        }

        //Save and Update Tax
        protected void btnSave_Click(object sender, EventArgs e)
        {
            int UserID = 0;
            if (Session["UserID"] != null)
                UserID = Convert.ToInt32(Session["UserID"].ToString());

            if (HiddenID.Value == "")
            {
                db.sp_TaxAdd(txtName.Text,Convert.ToDecimal(txtTaxRate.Text), UserID);
                dHelper.LogAction("User Add Tax " + txtName.Text);
            }
            else
            {
                db.sp_TaxUpdate(Convert.ToInt32(HiddenID.Value), txtName.Text,Convert.ToDecimal(txtTaxRate.Text), UserID);
                dHelper.LogAction("User Update Tax " + txtName.Text);
            }

            SetDefaultValue();
        }

        //Edit Tax
        protected void LinkEdit_Click(object sender, EventArgs e)
        {
            LinkButton l = (LinkButton)sender;
            HiddenID.Value = l.CommandArgument;
            var tax = db.tblTaxes.FirstOrDefault(s => s.ID == Convert.ToInt32(HiddenID.Value));
            if (tax != null)
            {
                ltrTitle.Text = "Edit Tax : " + tax.Name;
                txtName.Text = tax.Name;
                txtTaxRate.Text = tax.TaxRate.ToString();

                dHelper.LogAction("User Edit Tax " + tax.Name);
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "mymodal", "$('#edit').modal({backdrop: 'static', keyboard: false});", true);

                PopulateTax();
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "gridview", "$('#MainContent_gvTax').DataTable();", true);
                upModal.Update();
            }
        }

        //Delete Tax
        protected void LinkDelete_Click(object sender, EventArgs e)
        {
            PnError.Visible = false;
            LinkButton l = (LinkButton)sender;

            var tax = db.tblTaxes.FirstOrDefault(s => s.ID == Convert.ToInt32(l.CommandArgument));
            if (tax != null)
            {
                if (GeneralHelper.IsDeleteEnable == true)
                {
                    tax.IsDeleted = true;
                    db.SubmitChanges();
                    dHelper.LogAction("User Delete Tax " + tax.Name);
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
            PopulateTax();
            HiddenID.Value = "";
            ltrTitle.Text = "Add Tax";
            txtName.Text = "";
            txtTaxRate.Text = "";

            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#edit').modal('hide');", true);
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "gridview", "$('#MainContent_gvTax').DataTable();", true);
            upModal.Update();
        }

        //Get Tax Status (Active/Inactive)
        protected string GetStatusString(string status)
        {
            if (status == "True")
                return "<button type=\"button\" class=\"btn btn-success btn-xs\"><i class=\"fa fa-check\"></i> Active</button>";
            else if (status == "False")
                return "<button type=\"button\" class=\"btn btn-danger btn-xs\"><i class=\"fa fa-times-circle-o\"></i> InActive</button>";
            else
                return "";
        }

        //Update Employee Status (Active/Inactive)
        protected void LinkActive_Click(object sender, EventArgs e)
        {
            LinkButton l = (LinkButton)sender;

            var tax = db.tblTaxes.FirstOrDefault(s => s.ID == Convert.ToInt32(l.CommandArgument));
            if (tax != null)
            {
                if (tax.IsActive == true)
                {
                    tax.IsActive = false;                    
                    dHelper.LogAction("User Update Tax " + tax.Name + " Status Inactive");
                }
                else
                {
                    tax.IsActive = true;
                    dHelper.LogAction("User Update Tax " + tax.Name + " Status Active");
                }
                tax.LastModifiedDate = DateTime.Now;
                db.SubmitChanges();

                SetDefaultValue();
            }
        }
    }
}