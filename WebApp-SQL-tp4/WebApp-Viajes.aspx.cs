using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
// using System.Data;

namespace WebApp_SQL_tp4
{
  public partial class WebApp_Viajes : System.Web.UI.Page
  {
    // VARIABLE DE NUESTRO SERVER LOCAL
    private const string conectingString = @"Data Source=DESKTOP-LFTFVP5\SQLEXPRESS;Initial Catalog=Viajes;Integrated Security=True";
    const string sqlConsultaProvincias = "Select * From Provincias";

    
    protected void Page_Load(object sender, EventArgs e)
    {
      if (!IsPostBack)
      {
        // Establecemos la coxexion con el SERVER LOCAL
        SqlConnection sqlConnectionServer = new SqlConnection(conectingString);
        sqlConnectionServer.Open();

        // Establecemos el comando de consulta con la conexion
        SqlCommand sqlCommand = new SqlCommand(sqlConsultaProvincias, sqlConnectionServer);

        // Ejecutamos la consulta: 
        SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

        // Agregamos los valores al ddlFromProvince. 
        // Indicamos el origen de los datos:
        ddlFromProvince.DataSource = sqlDataReader;
        ddlFromProvince.DataTextField = "NombreProvincia";
        ddlFromProvince.DataValueField = "IdProvincia";
        ddlFromProvince.DataBind();
        // Cerramos la conexion:
        sqlConnectionServer.Close();
      }
    }
    
    protected void ddlFromProvince_SelectedIndexChanged(object sender, EventArgs e)
    {
      // lblSelectedText.Text = ddlFromProvince.SelectedItem.ToString();
      int IdProvincia = Convert.ToInt32(ddlFromProvince.SelectedValue.ToString());
      string sqlConsultaLocality = "Select * From Localidades Where IdProvincia = " + IdProvincia;
      // Destino Final: 
      string sqlConsultaToProvince = "Select * From Provincias Where IdProvincia != " + IdProvincia;

      if ( IdProvincia > 0)
      {
        // lblSelectedValue.Text = "Select * From Localidades Where IdProvincia = " + IdProvincia ;
        // Abrir la conexión a la base de datos LOCALIDADES.
        SqlConnection sqlConnectionLocality = new SqlConnection(conectingString);
        sqlConnectionLocality.Open();

        SqlConnection sqlConnectionProvince = new SqlConnection(conectingString);
        sqlConnectionProvince.Open();
        // Ejecutar la consulta:
        // para obtener localidades.
        SqlCommand sqlCommandFromLocality = new SqlCommand(sqlConsultaLocality, sqlConnectionLocality);
        SqlDataReader sqlDataReaderFromLocality = sqlCommandFromLocality.ExecuteReader();

        // para obtener las provincias "Desitino final"
        SqlCommand sqlCommandtoProvince = new SqlCommand(sqlConsultaToProvince, sqlConnectionProvince);
        SqlDataReader sqlDataReaderToProvince = sqlCommandtoProvince.ExecuteReader();

        // Limpiar el DropDownList Localidades "Destino inicio" para evitar acumulación de ítems.
        ddlFromLocality.Items.Clear();
        // Asignar la fuente de datos y hacer el binding.
        ddlFromLocality.DataSource = sqlDataReaderFromLocality;
        ddlFromLocality.DataTextField = "NombreLocalidad";
        ddlFromLocality.DataValueField = "IdLocalidad";
        ddlFromLocality.DataBind();
        // Agregar el ítem por defecto.
        ddlFromLocality.Items.Insert(0, new ListItem("-- Seleccionar --", "0"));

        // DropDownList Provincias "Destino final" :
        ddlToProvince.Items.Clear();
        // DropDownList Provincias "Destino final": 
        ddlToProvince.DataSource = sqlDataReaderToProvince;
        ddlToProvince.DataTextField = "NombreProvincia";
        ddlToProvince.DataValueField = "IdProvincia";
        ddlToProvince.DataBind();
        ddlToProvince.Items.Insert(0, new ListItem("-- Seleccionar --", "0"));

        sqlConnectionLocality.Close();
        sqlConnectionProvince.Close();

      }
      else
      {
        ddlFromLocality.Items.Clear();
        ddlToProvince.Items.Clear();
        ddlFromLocality.Items.Insert(0, new ListItem("-- Seleccionar --", "0"));
        ddlToProvince.Items.Insert(0, new ListItem("-- Seleccionar --", "0"));
        ddlToLocality.Items.Clear();
        ddlToLocality.Items.Insert(0, new ListItem("-- Seleccionar --", "0"));
      }
    }

    protected void ddlToProvince_SelectedIndexChanged(object sender, EventArgs e)
    {
      // lblSelectedValue.Text = ddlToProvince.SelectedValue.ToString();
      int IdProvincia = Convert.ToInt32(ddlToProvince.SelectedValue.ToString());
      // lblSelectedText.Text = ddlToProvince.SelectedItem.ToString();
      
      string sqlConsultaLocality = "Select * From Localidades Where IdProvincia = " + IdProvincia;


      if (IdProvincia > 0)
      {
        SqlConnection sqlConnection = new SqlConnection(conectingString);
        sqlConnection.Open();

        SqlCommand sqlCommandToLocality = new SqlCommand(sqlConsultaLocality, sqlConnection);

        SqlDataReader sqlDataReader = sqlCommandToLocality.ExecuteReader();

        ddlToLocality.Items.Clear();
        ddlToLocality.DataSource = sqlDataReader;


        ddlToLocality.DataTextField = "NombreLocalidad";
        ddlToLocality.DataValueField = "IdLocalidad";
        ddlToLocality.DataBind();

        ddlToLocality.Items.Insert(0, new ListItem("-- Seleccionar --", "0"));

        sqlConnection.Close();
      }
      else
      {
        ddlToLocality.Items.Clear();
        ddlToLocality.Items.Insert(0, new ListItem("-- Seleccionar --", "0"));
      }
    }

  }
}


/*
 // Agregar el ítem por defecto.

    // al principio de la lista.
        ddlFromLocality.Items.Insert(0, new ListItem("-- Seleccionar --", "0"));
    // Al final de la lista.
        ListItem listItemFromLocality = new ListItem();
        listItemFromLocality.Text = "-- Seleccionar --";
        listItemFromLocality.Value = "0";
        ddlFromLocality.Items.Add(listItemFromLocality);
 */