using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AdvancePOS.Models;

namespace AdvancePOS.Report
{
    public partial class UserLog : System.Web.UI.Page
    {
        AdvancePOSDataContext db = new AdvancePOSDataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                PopulateUserLog();
            }
        }

        private void PopulateUserLog()
        {
            var userLog = from u in db.tblUsers
                          join u1 in db.tblUserLogs on u.ID equals u1.UserID
                          orderby u1.LogTime descending
                          select new { u.UserName, u1.IPAddress, u1.LogTime, u1.Message, u1.MoreInfo };
            gvUserLog.DataSource = userLog;
            gvUserLog.DataBind();

            if (userLog.Count() > 0)
            {
                gvUserLog.UseAccessibleHeader = true;
                gvUserLog.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "gridview", "$('#MainContent_gvUserLog').DataTable();", true);
        }
    }
}