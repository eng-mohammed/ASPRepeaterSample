using ASPRepeaterSample.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace ASPRepeaterSample
{
    public partial class Index : System.Web.UI.Page
    {

        List<employee> employees = new List<employee>();
        int[] array1 = { 1 };
        int[] array2 = { 1, 2, 3 };

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {




                repeater.DataSource = array1;
                repeater.DataBind();

                repeater1.DataSource = array2;
                repeater1.DataBind();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            var txt = repeater.Items[0].FindControl("txtName") as TextBox;
            var chkbox = repeater.Items[0].FindControl("chkIsActive") as CheckBox;
            SqlConnection sqlConnection = new SqlConnection("Data Source=.;Initial Catalog=EmployeeDB;Integrated Security=True");
            sqlConnection.Open();
            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandText = "insert into emp_tb (Name,IsActive) values (@Name,@act)";
            sqlCommand.Parameters.Clear();
            sqlCommand.Parameters.AddWithValue("@Name", txt.Text);
            sqlCommand.Parameters.AddWithValue("@act", chkbox.Checked);
            var res = sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();

            if (res > 0)
            {
                lblmsg.Text = "Added successfully";
                txt.Text = string.Empty;
                chkbox.Checked = false;

            }
            else
            {
                lblmsg.Text = "Added not successfully";
            }
            lblmsg.Visible = true;


            Timer1.Interval = 2000;
            Timer1.Enabled = true;

        }


        protected void Timer1_Tick(object sender, EventArgs e)
        {
            lblmsg.Visible = false;
            Timer1.Enabled = false;
        }

        protected void btnSave2_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection sqlConnection = new SqlConnection("Data Source=.;Initial Catalog=EmployeeDB;Integrated Security=True");
                sqlConnection.Open();
                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandText = "insert into emp_tb (Name,IsActive) values (@Name,@act)";

                foreach (RepeaterItem item in repeater1.Items)
                {
                    var txt = item.FindControl("txtName") as TextBox;
                    var chkbox = item.FindControl("chkIsActive") as CheckBox;
                    sqlCommand.Parameters.Clear();
                    sqlCommand.Parameters.AddWithValue("@Name", txt.Text);
                    sqlCommand.Parameters.AddWithValue("@act", chkbox.Checked);
                    sqlCommand.ExecuteNonQuery();
                    txt.Text = string.Empty;
                    chkbox.Checked = false;
                }
                lblmsg.Text = "Added successfully";
                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                lblmsg.Text = ex.Message;
            }
            finally
            {
                lblmsg.Visible = true;
                Timer1.Interval = 2000;
                Timer1.Enabled = true;
            }


        }
    }
}