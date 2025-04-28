using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace WebApp_SQL_tp4
{
  public partial class WebForm_LibrosListado : System.Web.UI.Page
  {

    private const string connectingString = @"Data Source=DESKTOP-LFTFVP5\SQLEXPRESS;Initial Catalog=Libreria;Integrated Security=True";
    protected void Page_Load(object sender, EventArgs e)
    {

      string ddlValueSelected ;
      string sqlConsulta; 

      if (Context.Items["SelectedTopic"] != null)
      {
        ddlValueSelected = Context.Items["SelectedTopic"].ToString();
        // ddlValueSelected = ((Label)PreviousPage.FindControl("lblShowSelected")).Text;
        // lblSelectedTopic.Text = " Select * from Libros Where IdTema = " + ddlValueSelected;
        // Select * from Libros Where IdTema = 1
        sqlConsulta = " Select * from Libros Where IdTema = " + ddlValueSelected;

        SqlConnection sqlConnection = new SqlConnection(connectingString);
        sqlConnection.Open();

        SqlCommand sqlCommand = new SqlCommand(sqlConsulta, sqlConnection);
        SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

        gridLirbros.DataSource = sqlDataReader;
        gridLirbros.DataBind();

        sqlConnection.Close();
      }

    }

    protected void btnBackLibreria_Click(object sender, EventArgs e)
    {
      Server.Transfer("WebApp-Libreria.aspx");
    }
  }
}