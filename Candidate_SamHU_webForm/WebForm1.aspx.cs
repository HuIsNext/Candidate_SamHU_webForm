using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Candidate_SamHU_webForm
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var DT = new DataTable("PersonalFile");
                DataColumn DC = DT.Columns.Add("姓名", typeof(string));
                DT.Columns.Add("年齡", typeof(int));
                DT.Columns.Add("生日", typeof(DateTime));

                DataRow dr = DT.NewRow();
                dr["姓名"] = "SaM";
                dr["年齡"] = 18;
                dr["生日"] = Convert.ToDateTime("02 /18/2023");
                DT.Rows.Add(dr);
                GridView1.DataSource = DT;
                GridView1.DataBind();
                ViewState["CurrentTable"] = DT;

            }
        }
        

        protected void btnShow_Click(object Sender, EventArgs e)
        {
            DataTable DT = (DataTable)ViewState["CurrentTable"];
            DataRow dr = DT.NewRow();
            dr["姓名"] = Context.Request.Form["txtName"].ToString();
            dr["年齡"] = Convert.ToInt16(Context.Request.Form["txtAGE"].ToString());
            dr["生日"] = Convert.ToDateTime(Request.Form["txtBday"].ToString());
            DT.Rows.Add(dr);
            GridView1.DataSource = DT;
            GridView1.DataBind();
            ViewState["CurrentTable"] = DT;
        }

        //protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        //{
        //  if(e.CommandName.Equals("DeleteRow"))           
        //   {
        //   }
        //}

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Del")
            {
                //取得 custid 的值
                var custid = e.CommandArgument;
                // ... 做後面要做的事情 .....
            }
        }
        void ContactsGridView_RowCommand(Object sender, GridViewCommandEventArgs e)
        {
        }


        public override void VerifyRenderingInServerForm(Control control)
        {
            //'XX'型別 必須置於有 runat=server 的表單標記之中
        }

    }
}