<%@ Page 
    Language="C#" 
    AutoEventWireup="true" 
    CodeBehind="WebForm-LibrosListado.aspx.cs" 
    Inherits="WebApp_SQL_tp4.WebForm_LibrosListado" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <h1>Listado de libros</h1>
        <div>
            <%--<span>Tema elejido: </span>--%>
            <asp:Label runat="server" ID="lblSelectedTopic"></asp:Label>
        </div>
        <%-- Control GRID VIEW --%>
        <div>
            <asp:GridView ID="gridLirbros" runat="server">
            </asp:GridView>
        </div>
        <br />
        <div>
            <asp:Button ID="btnBackLibreria" runat="server" Text="Consultar otro tema" OnClick="btnBackLibreria_Click" />        
        </div>

    </form>
</body>
</html>
