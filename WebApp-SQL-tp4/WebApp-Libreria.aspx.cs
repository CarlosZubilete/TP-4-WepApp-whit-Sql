using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace WebApp_SQL_tp4
{
  public partial class WebApp_Libreria : System.Web.UI.Page
  {

    private const string connectingString = @"Data Source=DESKTOP-LFTFVP5\SQLEXPRESS;Initial Catalog=Libreria;Integrated Security=True";
    const string sqlConsulta = "Select * from Temas";

    protected void Page_Load(object sender, EventArgs e)
    {
      if (!IsPostBack)
      {
        SqlConnection sqlConnection = new SqlConnection(connectingString);
        sqlConnection.Open();

        SqlCommand sqlCommand = new SqlCommand(sqlConsulta, sqlConnection);
        SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

        ddlTopics.DataSource = sqlDataReader;

        ddlTopics.DataTextField = "Tema";
        ddlTopics.DataValueField = "IdTema";
        ddlTopics.DataBind();

        sqlConnection.Close();
      }
    }

    protected void btnSend_Click(object sender, EventArgs e)
    {

      if (ddlTopics.SelectedValue.ToString() != "0")
      {
        // tranferimos datos directamente usando -> Context.Items
        Context.Items["SelectedTopic"] = ddlTopics.SelectedValue.ToString();
        Server.Transfer("WebForm-LibrosListado.aspx");
      }
      
    }

    protected void ddlTopics_SelectedIndexChanged(object sender, EventArgs e)
    {
      //if(ddlTopics.SelectedValue.ToString() != "0")
      //{
      //  lblShowSelected.Text = ddlTopics.SelectedValue.ToString();
      //}
      //else
      //{
      //  lblShowSelected.Text = String.Empty;
      //}
    }
  }
}