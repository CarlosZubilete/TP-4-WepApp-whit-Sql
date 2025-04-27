<%@ Page 
    Language="C#" 
    AutoEventWireup="true" 
    CodeBehind="WebApp-Neptuno.aspx.cs" 
    Inherits="WebApp_SQL_tp4.WebApp_Neptuno" 
    UnobtrusiveValidationMode="None"
    %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <h1>Base de datos - Neptuno </h1>
    <form id="form1" runat="server">
        <%-- FILTRO ID PRODUCTO --%>
        <div>
            <span>Id Producto: </span>
            <asp:DropDownList runat="server" ID="ddlIdProduct" 
                AutoPostBack="true"
                OnSelectedIndexChanged="ddlIdProduct_SelectedIndexChanged">
                <asp:ListItem Enabled="True" Value="0">Igual a:</asp:ListItem>
                <asp:ListItem Enabled="True" Value="1">Mayor a: </asp:ListItem>
                <asp:ListItem Enabled="True" Value="2">Menor a:</asp:ListItem>
            </asp:DropDownList>
            <asp:TextBox runat="server" ID="txtIdProduct"></asp:TextBox>
            <asp:RangeValidator ID="rangeIdProduct" runat="server" ControlToValidate="txtIdProduct" MaximumValue="77" MinimumValue="1" Type="Integer">No se encontraron resultados</asp:RangeValidator>
        </div>
        <%-- Filtro ID CATRGORIA --%>
        <div>
            <span>Id Categoria: </span>
            <asp:DropDownList runat="server" ID="DropDownList1" 
                AutoPostBack="true">
                <asp:ListItem Enabled="True" Value="0">Igual a:</asp:ListItem>
                <asp:ListItem Enabled="True" Value="1">Mayor a: </asp:ListItem>
                <asp:ListItem Enabled="True" Value="2">Menor a:</asp:ListItem>
            </asp:DropDownList>
            <asp:TextBox runat="server" ID="txtIdCategory"></asp:TextBox>
            <asp:RangeValidator ID="rangeIdCategory" runat="server" ControlToValidate="txtIdCategory" MaximumValue="8" MinimumValue="1" Type="Integer">No se encontraron resultados</asp:RangeValidator>
        </div>
            <asp:Button ID="btnFilter" runat="server" Text="Filtrar" OnClick="btnFilter_Click" />
        <br />    
            <asp:Label ID="lblShow" runat="server"></asp:Label>

        <%-- GRID VIUW --%>
        <h3>Tabla de Productos:</h3>
        <asp:GridView ID="gvProducts" runat="server">
        </asp:GridView>
        <br />

    </form>
</body>
</html>
