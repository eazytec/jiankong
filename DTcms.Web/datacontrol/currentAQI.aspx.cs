using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DTcms.DBUtility;

namespace DTcms.Web.datacontrol
{
    public partial class currentAQI : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        private void GetControl()
        {
            string sql = "select stationId,stationName from dbo.stationInfo ";
            DataTable dt = DbHelperSQL.Query(sql).Tables[0];
        }


        private void CreateControl()
        {
           
           


        }

    }
}