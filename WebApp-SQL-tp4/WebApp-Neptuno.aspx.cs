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


    protected string getOperadorRacional(string operadorRacional)
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
        case "0":
          consulta = " = ";
          break;
        case "1":
          consulta = " > ";
          break;
        case "2":
          consulta = " < ";
          break;
        default:
          consulta = " ";
          break;
      }

      return consulta;
    }


    protected void btnFilter_Click(object sender, EventArgs e)
    {

      string filtros = ""; 

      if (txtIdProduct.Text.Trim().Length > 0)
      {
        filtros += " IdProducto " + this.getOperadorRacional(ddlIdProduct.SelectedValue.ToString()) + txtIdProduct.Text;
      }

      if (txtIdCategory.Text.Trim().Length > 0)
      {
        if (filtros.Length > 0)
        {
          filtros += " AND ";
        }
        filtros += "IdCategoría" + this.getOperadorRacional(ddlIdCategory.SelectedValue.ToString()) + txtIdCategory.Text;
      }

      string query = sqlConsulta;

      if (filtros.Length > 0)
        query += " WHERE " + filtros;

      lblShow.Text = filtros;
      CargarProductos(query);

    }

    protected void btnCleanFilter_Click(object sender, EventArgs e)
    {
      txtIdCategory.Text = string.Empty;
      txtIdProduct.Text = string.Empty;
      lblShow.Text = String.Empty; 
      CargarProductos(sqlConsulta);
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

/*
  string operadorIdProducto = "";
  string idProduct = "";
  string queryIdFiltrado = "";

  string operadorIdCategory = "";
  string idCategory = "";

  if (txtIdProduct.Text.Trim().Length > 0 && txtIdCategory.Text.Trim().Length > 0)
  {

    operadorIdProducto = this.getOperadorRacional(ddlIdProduct.SelectedValue.ToString());
    idProduct = txtIdProduct.Text;

    operadorIdCategory = this.getOperadorRacional(ddlIdCategory.SelectedValue.ToString());
    idCategory = txtIdCategory.Text;

    queryIdFiltrado = sqlConsulta + where + " IdProducto " + operadorIdProducto + idProduct + " AND IdCategoría " + operadorIdCategory + idCategory;

    lblShow.Text = queryIdFiltrado;

    //CargarProductos(queryIdFiltrado);
  }
  if (txtIdProduct.Text.Trim().Length > 0 && txtIdCategory.Text.Trim().Length == 0)
  {
    operadorIdProducto = this.getOperadorRacional(ddlIdProduct.SelectedValue.ToString());
    idProduct = txtIdProduct.Text;

    queryIdFiltrado = sqlConsulta + where + " IdProducto " + operadorIdProducto + idProduct;

    lblShow.Text = queryIdFiltrado;
    //CargarProductos(queryIdFiltrado);
  }
  if (txtIdProduct.Text.Trim().Length == 0 && txtIdCategory.Text.Trim().Length > 0)
  {
    operadorIdCategory = this.getOperadorRacional(ddlIdCategory.SelectedValue.ToString());
    idCategory = txtIdCategory.Text;

    queryIdFiltrado = sqlConsulta + where + " IdCategoría " + operadorIdCategory + idCategory;

    lblShow.Text = queryIdFiltrado;

    //CargarProductos(queryIdFiltrado);
  }
  else
  {
    // CargarProductos(sqlConsulta);
  }

*/