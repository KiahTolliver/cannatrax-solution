using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using AdvancePOS.Models;
using AdvancePOS.Helper;

namespace AdvancePOS.Employee
{
    public partial class ManageEmployee : System.Web.UI.Page
    {
        AdvancePOSDataContext db = new AdvancePOSDataContext();
        GeneralHelper dHelper = new GeneralHelper();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                txtDOB.Attributes.Add("readonly", "readonly");
                txtPassword.Attributes["type"] = "password";
                txtConfirmPassword.Attributes["type"] = "password";
                PopulateEmployee();
                PopulateRole();
                PoplateStore();
                txtFirstName.Focus();
                dHelper.LogAction("User View Employee Master");
            }
        }

        private void PoplateStore()
        {
            var store = db.sp_GetShop();
            ddlStore.DataSource = store;
            ddlStore.DataValueField = "ID";
            ddlStore.DataTextField = "Name";
            ddlStore.DataBind();
        }

        private void PopulateRole()
        {
            var roles = db.sp_GetRole(null);
            ddlRole.DataSource = roles;
            ddlRole.DataValueField = "ID";
            ddlRole.DataTextField = "Name";
            ddlRole.DataBind();
        }

        private void PopulateEmployee()
        {
            var employee = db.sp_GetEmployee().ToList();
            gvEmployee.DataSource = employee;
            gvEmployee.DataBind();
            if (employee.Count() > 0)
            {
                gvEmployee.UseAccessibleHeader = true;
                gvEmployee.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "gridview", "$('#MainContent_gvEmployee').DataTable();", true);
        }

        //Get Employe Status (Active/Inactive)
        protected string GetStatusString(string status)
        {
            if (status == "True")
                return "<button type=\"button\" class=\"btn btn-success btn-xs\"><i class=\"fa fa-check\"></i> Active</button>";
            else if (status == "False")
                return "<button type=\"button\" class=\"btn btn-danger btn-xs\"><i class=\"fa fa-times-circle-o\"></i> InActive</button>";            
            else
                return "";
        }

        //Edit Employee
        protected void LinkEdit_Click(object sender, EventArgs e)
        {
            LinkButton l = (LinkButton)sender;
            HiddenID.Value = l.CommandArgument;
            var employee = db.tblUsers.FirstOrDefault(s => s.ID == Convert.ToInt32(HiddenID.Value));
            if (employee != null)
            {
                ltrTitle.Text = "Edit Employee : " + employee.FirstName;
                txtFirstName.Text = employee.FirstName;
                txtLastName.Text = employee.LastName;
                txtAddress.Text = employee.Address;
                txtPhoneNo.Text = employee.PhoneNo;
                txtDepartment.Text = employee.Department;
                txtDesignation.Text = employee.Designation;
                txtSupervisor.Text = employee.Supervisor;
                txtEmail.Text = employee.Email;
                if (employee.DateOfBirth != null)
                    txtDOB.Text = employee.DateOfBirth.Value.ToString("dd/MMM/yyyy");
                txtUseraName.Text = employee.UserName;
                txtPassword.Text = employee.Password;
                txtConfirmPassword.Text = employee.Password;
                HiddenFilename.Value = employee.PhotoPath;

                String logoPhoto = Server.MapPath("~/" + employee.PhotoPath);
                if (File.Exists(logoPhoto))
                    ImagePhoto.ImageUrl = employee.PhotoPath;
                else
                    ImagePhoto.ImageUrl = "/Images/Profile/default.jpg";

                dHelper.LogAction("User Edit Employee " + employee.FirstName);
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "mymodal", "$('#edit').modal({backdrop: 'static', keyboard: false});", true);

                PopulateEmployee();
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "date", "$('#MainContent_txtDOB').datepicker();", true);
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "gridview", "$('#MainContent_gvEmployee').DataTable();", true);
                upModal.Update();
            }
        }

        //Delete Employee
        protected void LinkDelete_Click(object sender, EventArgs e)
        {
            PnError.Visible = false;
            LinkButton l = (LinkButton)sender;

            var employee = db.tblUsers.FirstOrDefault(s => s.ID == Convert.ToInt32(l.CommandArgument));
            if (employee != null)
            {
                if (GeneralHelper.IsDeleteEnable == true)
                {
                    employee.IsDeleted = true;
                    db.SubmitChanges();
                    dHelper.LogAction("User Delete Employee " + employee.FirstName);
                }
                else
                {
                    PnError.Visible = true;
                    ltrError.Text = "disable delete action in demo.!!!";
                }
                SetDefaultValue();
            }
        }

        //Save and Update Employee
        protected void btnSave_Click(object sender, EventArgs e)
        {
            int UserID = 0;
            if (Session["UserID"] != null)
                UserID = Convert.ToInt32(Session["UserID"].ToString());
            if (FileUploadProfile.HasFile)
            {
                if (HiddenID.Value != "")
                {
                    String logoPhoto = Server.MapPath("~/" + HiddenFilename.Value);
                    if (File.Exists(logoPhoto))
                        File.Delete(logoPhoto);
                }
                String fileName = Guid.NewGuid().ToString() + Path.GetExtension(FileUploadProfile.FileName);
                HiddenFilename.Value = "/Images/Profile/" + fileName;
                FileUploadProfile.SaveAs(Server.MapPath("~/Images/Profile/" + fileName));
            }
            if (HiddenID.Value == "")
            {
                if (HiddenFilename.Value == "")
                    HiddenFilename.Value = "/Images/default.jpg";
                db.sp_EmployeeAdd(Convert.ToInt32(ddlRole.SelectedValue), Convert.ToInt32(ddlStore.SelectedValue), txtFirstName.Text, txtLastName.Text, txtPhoneNo.Text,
                    txtEmail.Text, txtDepartment.Text, txtDesignation.Text, txtSupervisor.Text, Convert.ToDateTime(txtDOB.Text), txtAddress.Text, HiddenFilename.Value,
                    txtUseraName.Text, txtPassword.Text, UserID, UserID);
                dHelper.LogAction("User Add Employee " + txtFirstName.Text);
            }
            else
            {
                db.sp_EmployeeUpdate(Convert.ToInt32(HiddenID.Value),Convert.ToInt32(ddlRole.SelectedValue), Convert.ToInt32(ddlStore.SelectedValue), txtFirstName.Text, 
                    txtLastName.Text, txtPhoneNo.Text,txtEmail.Text, txtDepartment.Text, txtDesignation.Text, txtSupervisor.Text, Convert.ToDateTime(txtDOB.Text), 
                    txtAddress.Text, HiddenFilename.Value, txtUseraName.Text, txtPassword.Text, UserID);
                dHelper.LogAction("User Update Employee " + txtFirstName.Text);
            }
            
            SetDefaultValue();
        }

         //Update Employee Status (Active/Inactive)
        protected void LinkActive_Click(object sender, EventArgs e)
        {            
            LinkButton l = (LinkButton)sender;
            if (GeneralHelper.IsDeleteEnable == true)
            {
                var employee = db.tblUsers.FirstOrDefault(s => s.ID == Convert.ToInt32(l.CommandArgument));
                if (employee != null)
                {
                    if (employee.IsActive == true)
                    {
                        employee.IsActive = false;
                        dHelper.LogAction("User Update Employe " + employee.FirstName + " Status Inactive");
                    }
                    else
                    {
                        employee.IsActive = true;
                        dHelper.LogAction("User Update Employe " + employee.FirstName + " Status Active");
                    }
                    employee.LastModifiedDate = DateTime.Now;
                    db.SubmitChanges();

                    SetDefaultValue();
                }
            }
            else
            {
                PnError.Visible = true;
                ltrError.Text = "disable change status in demo.!!!";
            }
            SetDefaultValue();
        }

        protected void btnClose_Click(object sender, EventArgs e)
        {
            SetDefaultValue();
        }

        public void SetDefaultValue()
        {
            PopulateEmployee();
            HiddenID.Value = "";
            ltrTitle.Text = "Add Employee";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtAddress.Text = "";
            txtPhoneNo.Text = "";
            txtDepartment.Text = "";
            txtDesignation.Text = "";
            txtSupervisor.Text = "";
            txtEmail.Text = "";
            txtDOB.Text = "";
            txtUseraName.Text = "";
            txtPassword.Text = "";
            txtConfirmPassword.Text = "";
            ImagePhoto.ImageUrl = "";
            HiddenFilename.Value = "";

            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#edit').modal('hide');", true);
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "gridview", "$('#MainContent_gvEmployee').DataTable();", true);
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "date", "$('#MainContent_txtDOB').datepicker();", true);
            upModal.Update();
        }
    }
}