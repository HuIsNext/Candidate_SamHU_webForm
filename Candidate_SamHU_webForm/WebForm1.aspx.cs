using System;
using System.Data;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace Candidate_SamHU_webForm
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        int custid;
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
                dr["生日"] = Convert.ToDateTime("02/18/2023");
                DT.Rows.Add(dr);
                GridView1.DataSource = DT;
                GridView1.DataBind();
                ViewState["CurrentTable"] = DT;
            }
        }
        protected void btnShow_Click(object Sender, EventArgs e)
        {
            DataTable DT = (DataTable)ViewState["CurrentTable"];
            try
            {
                if (btnSend.Text == "送出檔案")
                {
                    DataRow dr = DT.NewRow();
                    dr["姓名"] = txtName.Value.ToString();
                    dr["年齡"] = txtAGE.Value.ToString();
                    dr["生日"] = Convert.ToDateTime(datepicker.Value.ToString());

                    DT.Rows.Add(dr);
                    GridView1.DataSource = DT;
                    GridView1.DataBind();
                    ViewState["CurrentTable"] = DT;
                }
                else if (btnSend.Text == "修改帳號")
                {
                    custid = Convert.ToInt16(txtIndex.Text);
                    DT.Rows[custid]["姓名"] = txtName.Value;
                    DT.Rows[custid]["年齡"] = txtAGE.Value;
                    DT.Rows[custid]["生日"] = Convert.ToDateTime(datepicker.Value.ToString());
                    GridView1.DataSource = DT;
                    GridView1.DataBind();
                    ViewState["CurrentTable"] = DT;
                    btnSend.Text = "送出檔案";
                }
            }
            catch (Exception ex)
            {
              
            }
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            //'XX'型別 必須置於有 runat=server 的表單標記之中
        }
        protected void CustomersGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            custid = Convert.ToInt16(e.CommandArgument);
            DataTable DT = (DataTable)ViewState["CurrentTable"];
            if (e.CommandName == "deleteItem")
            {
                //取得 custid 的值
                DT.Rows.RemoveAt(custid);
                GridView1.DataSource = DT;
                GridView1.DataBind();
                ViewState["CurrentTable"] = DT;
            }
            else if (e.CommandName == "editItem")
            {
                btnSend.Text = "修改帳號";
                txtIndex.Text = custid.ToString();
                txtName.Value = DT.Rows[custid]["姓名"].ToString();
                txtAGE.Value = DT.Rows[custid]["年齡"].ToString();
                datepicker.Value = DT.Rows[custid]["生日"].ToString();
            }
        }
    }
}