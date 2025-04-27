<%@ Page Language="C#" 
    AutoEventWireup="true" 
    CodeBehind="WebApp-Viajes.aspx.cs" 
    Inherits="WebApp_SQL_tp4.WebApp_Viajes" 
    UnobtrusiveValidationMode="None"
    %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

</head>
<body>
    <h1>Viajes</h1>
    <form id="form1" runat="server">
        <h3>DESTINO INICIO</h3>
        <div>
            <span>PROVINCIA: 
            </span>
            <asp:DropDownList ID="ddlFromProvince" runat="server" AppendDataBoundItems="true" AutoPostBack="True" OnSelectedIndexChanged="ddlFromProvince_SelectedIndexChanged">
                <asp:ListItem Enabled="true" Value="0">-- Seleccionar --</asp:ListItem>
            </asp:DropDownList>
        </div>
        <div>
            <span>LOCALIDAD: 
            </span>
            <asp:DropDownList ID="ddlFromLocality" runat="server" AppendDataBoundItems="true" >
                <asp:ListItem Enabled="true" Value="0">-- Seleccionar --</asp:ListItem>
            </asp:DropDownList>
        </div>
        <%-- DESTINO  --%>
        <h3>DESTINO FINAL</h3>
        <div>
            <span>PROVINCIA: 
            </span>
            <asp:DropDownList ID="ddlToProvince" runat="server" 
                AutoPostBack="True"
                AppendDataBoundItems="true"
                OnSelectedIndexChanged="ddlToProvince_SelectedIndexChanged" >
            <asp:ListItem Enabled="true" Value="0">-- Seleccionar --</asp:ListItem>
            </asp:DropDownList>
        </div>
        <asp:Label runat="server" ID="lblSelectedText"></asp:Label>
        <br />
        <asp:Label runat="server" ID="lblSelectedValue"></asp:Label>
        <div>
            <span>LOCALIDAD: 
            </span>
            <asp:DropDownList ID="ddlToLocality" runat="server" AppendDataBoundItems="true">
                <asp:ListItem Enabled="true" Value="0">-- Seleccionar --</asp:ListItem>
            </asp:DropDownList>
        </div>
    </form>
</body>
</html>
