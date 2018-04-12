using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AdvancePOS.Models;
using AdvancePOS.Helper;
using System.IO;   

namespace AdvancePOS.User
{
    public partial class UserProfile : System.Web.UI.Page
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
                PopulateRole();
                PoplateStore();
                dHelper.LogAction("User View Profile. ");
                if (Session["UserUpdate"] != null)
                {
                    pnMessage.Visible = true;
                    Session.Remove("UserUpdate");
                }        

                if (Session["UserID"] == null)
                    Response.Redirect("/Login.aspx?return=" + Request.RawUrl);
                else
                {
                    var userInfo = db.tblUsers.FirstOrDefault(s => s.ID == Convert.ToInt32(Session["UserID"]));
                    if (userInfo != null)
                    {
                        HiddenFilename.Value = userInfo.PhotoPath;
                        ltrFullName.Text = userInfo.FirstName + " " + userInfo.LastName;                        
                        ltrDepartment.Text = userInfo.Department;
                        ImagePhoto.ImageUrl = userInfo.PhotoPath;
                        txtFirstName.Text = userInfo.FirstName;
                        txtLastName.Text = userInfo.LastName;
                        txtPhoneNo.Text = userInfo.PhoneNo;
                        txtEmail.Text = userInfo.Email;
                        txtDepartment.Text = userInfo.Department;
                        txtDesignation.Text = userInfo.Designation;
                        txtSupervisor.Text = userInfo.Supervisor;
                        txtDOB.Text = userInfo.DateOfBirth == null ? "" : userInfo.DateOfBirth.Value.ToString("dd-MMM-yyyy");
                        txtAddress.Text = userInfo.Address;
                        txtUserName.Text = userInfo.UserName;
                        txtPassword.Text = userInfo.Password;
                        txtConfirmPassword.Text = userInfo.Password;
                        ddlRole.SelectedValue = userInfo.RoleID.ToString();
                        ddlStore.SelectedValue = userInfo.ShopID.ToString();
                        if (GeneralHelper.IsDeleteEnable == false)
                        {
                            txtPassword.Enabled = false;
                            txtConfirmPassword.Enabled = false;
                        }
                    }
                }
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

        //Save and Update Employee
        protected void btnSave_Click(object sender, EventArgs e)
        {
            pnMessage.Visible = false;
            int UserID = 0;
            if (Session["UserID"] != null)
            {
                UserID = Convert.ToInt32(Session["UserID"].ToString());
                if (FileUploadProfile.HasFile)
                {                    
                    if (UserID > 0)
                    {
                        String logoPhoto = Server.MapPath("~/" + HiddenFilename.Value);
                        if (File.Exists(logoPhoto))
                            File.Delete(logoPhoto);
                    }
                    String fileName = Guid.NewGuid().ToString() + Path.GetExtension(FileUploadProfile.FileName);
                    HiddenFilename.Value = "/Images/Profile/" + fileName;
                    FileUploadProfile.SaveAs(Server.MapPath("~/Images/Profile/" + fileName));
                }
                db.sp_EmployeeUpdate(UserID, Convert.ToInt32(ddlRole.SelectedValue), Convert.ToInt32(ddlStore.SelectedValue), txtFirstName.Text,
                    txtLastName.Text, txtPhoneNo.Text, txtEmail.Text, txtDepartment.Text, txtDesignation.Text, txtSupervisor.Text, Convert.ToDateTime(txtDOB.Text),
                    txtAddress.Text, HiddenFilename.Value, txtUserName.Text, txtPassword.Text, UserID);
                dHelper.LogAction("User Update Profile " + txtFirstName.Text);
                Session["UserUpdate"] = "Update";
                Response.Redirect(Request.Path);
            }
        }
    }
}