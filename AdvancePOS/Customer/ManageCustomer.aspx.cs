using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AdvancePOS.Models;
using AdvancePOS.Helper;

namespace AdvancePOS.Customer
{
    public partial class ManageCustomer : System.Web.UI.Page
    {
        AdvancePOSDataContext db = new AdvancePOSDataContext();
        GeneralHelper dHelper = new GeneralHelper();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {   
                PopulateCustomer();
                dHelper.LogAction("User View Customer Master");
            }
        }

        private void PopulateCustomer()
        {
            var customer = db.sp_GetCustomer().ToList();
            gvCustomer.DataSource = customer;
            gvCustomer.DataBind();
            if (customer.Count() > 0)
            {
                gvCustomer.UseAccessibleHeader = true;
                gvCustomer.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "gridview", "$('#MainContent_gvCustomer').DataTable();", true);
        }

        //Get Customer Status (Active/Inactive)
        protected string GetStatusString(string status)
        {
            if (status == "True")
                return "<button type=\"button\" class=\"btn btn-success btn-xs\"><i class=\"fa fa-check\"></i> Active</button>";
            else if (status == "False")
                return "<button type=\"button\" class=\"btn btn-danger btn-xs\"><i class=\"fa fa-times-circle-o\"></i> InActive</button>";
            else
                return "";
        }

        //Save and Update Customer
        protected void btnSave_Click(object sender, EventArgs e)
        {
            int UserID = 0;
            if (Session["UserID"] != null)
                UserID = Convert.ToInt32(Session["UserID"].ToString());
            
            if (HiddenID.Value == "")
            {
                db.sp_CustomerAdd(txtName.Text, txtAddress.Text, txtPhoneNo.Text, txtEmail.Text, UserID, UserID);
                dHelper.LogAction("User Add Customer " + txtName.Text);
            }
            else
            {
                db.sp_CustomerUpdate(Convert.ToInt32(HiddenID.Value), txtName.Text, txtAddress.Text, txtPhoneNo.Text, txtEmail.Text, UserID);
                dHelper.LogAction("User Update Customer " + txtName.Text);
            }

            SetDefaultValue();
        }

        //Update Customer Status (Active/Inactive)
        protected void LinkActive_Click(object sender, EventArgs e)
        {
            LinkButton l = (LinkButton)sender;

            var employee = db.tblCustomers.FirstOrDefault(s => s.ID == Convert.ToInt32(l.CommandArgument));
            if (employee != null)
            {
                if (employee.IsActive == true)
                {
                    employee.IsActive = false;
                    dHelper.LogAction("User Update Customer " + employee.Name + " Status Inactive");
                }
                else
                {
                    employee.IsActive = true;
                    dHelper.LogAction("User Update Customer " + employee.Name + " Status Active");
                }

                db.SubmitChanges();

                SetDefaultValue();
            }
        }

        //Edit Customer
        protected void LinkEdit_Click(object sender, EventArgs e)
        {
            LinkButton l = (LinkButton)sender;
            HiddenID.Value = l.CommandArgument;
            var customer = db.tblCustomers.FirstOrDefault(s => s.ID == Convert.ToInt32(HiddenID.Value));
            if (customer != null)
            {
                ltrTitle.Text = "Edit Customer : " + customer.Name;
                txtName.Text = customer.Name;                
                txtAddress.Text = customer.Address;
                txtPhoneNo.Text = customer.PhoneNo;                
                txtEmail.Text = customer.Email;        

                dHelper.LogAction("User Edit Customer " + customer.Name);
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "mymodal", "$('#edit').modal({backdrop: 'static', keyboard: false});", true);

                PopulateCustomer();                
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "gridview", "$('#MainContent_gvEmployee').DataTable();", true);
                upModal.Update();
            }
        }

        //Delete Customer
        protected void LinkDelete_Click(object sender, EventArgs e)
        {
            PnError.Visible = false;
            LinkButton l = (LinkButton)sender;

            var customer = db.tblCustomers.FirstOrDefault(s => s.ID == Convert.ToInt32(l.CommandArgument));
            if (customer != null)
            {
                if (GeneralHelper.IsDeleteEnable == true)
                {
                    customer.IsDeleted = true;
                    db.SubmitChanges();
                    dHelper.LogAction("User Delete Customer " + customer.Name);
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
            PopulateCustomer();
            HiddenID.Value = "";
            ltrTitle.Text = "Add Customer";
            txtName.Text = "";            
            txtAddress.Text = "";
            txtPhoneNo.Text = "";            
            txtEmail.Text = "";            
            
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#edit').modal('hide');", true);
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "gridview", "$('#MainContent_gvCustomer').DataTable();", true);            
            upModal.Update();
        }

       
    }
}