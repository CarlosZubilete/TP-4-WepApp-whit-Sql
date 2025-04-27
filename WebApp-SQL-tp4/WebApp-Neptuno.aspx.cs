using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace WebApp_SQL_tp4
{
  public partial class WebApp_Neptuno : System.Web.UI.Page
  {
    private const string connectingString = @"Data Source=DESKTOP-LFTFVP5\SQLEXPRESS;Initial Catalog=Neptuno;Integrated Security=True";
    private string sqlConsulta = "Select IdProducto, NombreProducto, IdCategoría , CantidadPorUnidad, PrecioUnidad From Productos ";
    
    private void CargarProductos(string query)
    {
      using (SqlConnection connection = new SqlConnection(connectingString))
      {
        connection.Open();
        SqlCommand command = new SqlCommand(query, connection);
        SqlDataReader reader = command.ExecuteReader();
        gvProducts.DataSource = reader;
        gvProducts.DataBind();
      }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
      if (!IsPostBack)
      {
        CargarProductos(sqlConsulta); 
      }
      
    }

    private const string where = " Where ";
    protected void ddlIdProduct_SelectedIndexChanged(object sender, EventArgs e)
    {
      //txtIdProduct.Text = ddlIdProduct.SelectedItem.ToString();
      //txtIdProduct.Text = ddlIdProduct.SelectedValue.ToString();
      // int ddlValue = Convert.ToInt32(ddlIdProduct.SelectedValue.ToString());
      //string consulta = this.getSqlConsulta(ddlValue, txtIdProduct.Text);
    }

    protected string getSqlConsulta(int operadorRacional)
    {
      /*
        0 -> '=' (igual)
        1 -> '>' - (mayor)
        2 -> '<' - menor 
        Where IdProducto >(operador logico) 5(input)
      */
      string consulta = "";
      switch (operadorRacional)
      {
        case 0:
          consulta = " IdProducto = ";
          break;
        case 1:
          consulta = " IdProducto > ";
          break;
        case 2:
          consulta = " IdProducto < ";
          break;
      }

      return consulta;
    }

  
    protected void btnFilter_Click(object sender, EventArgs e)
    {
      int ddlValue = Convert.ToInt32(ddlIdProduct.SelectedValue.ToString());

      string sentenciaRacional = this.getSqlConsulta(ddlValue);

      string idProduct = txtIdProduct.Text;
      string queryIdFiltrado = sqlConsulta + where + sentenciaRacional + idProduct;

      lblShow.Text = queryIdFiltrado; 

      if(txtIdProduct.Text.Trim().Length > 0)
      {
        CargarProductos(queryIdFiltrado);
      }
      else
      {
        CargarProductos(sqlConsulta);
      }

    }
  }
}

/*
  SqlConnection sqlConnection = new SqlConnection(conectingString);
  sqlConnection.Open();

  SqlCommand sqlCommand = new SqlCommand(sqlConsulta,sqlConnection);

  SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

  gvProducts.DataSource = sqlDataReader;
  gvProducts.DataBind();

  sqlConnection.Close();
*/