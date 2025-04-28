<%@ Page 
    Language="C#" 
    AutoEventWireup="true" 
    CodeBehind="WebApp-Libreria.aspx.cs" 
    Inherits="WebApp_SQL_tp4.WebApp_Libreria" 
    UnobtrusiveValidationMode="None"
    %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <h1>Base de datos - Libreria </h1>
    <form id="form1" runat="server">
        <div>
            <span>Selecciona un tema</span>
            <asp:DropDownList ID="ddlTopics" 
                AppendDataBoundItems="true"
                runat="server" 
                AutoPostBack="True" OnSelectedIndexChanged="ddlTopics_SelectedIndexChanged">
                <asp:ListItem Value="0" Enabled="True">-- Selecicionar --</asp:ListItem>
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="requiredTopic" 
                runat="server" ControlToValidate="ddlTopics" 
                InitialValue="0">Debe elejir un tema
            </asp:RequiredFieldValidator>
            <br />

        </div>
            <asp:Button ID="btnSend" runat="server" Text="Ver libros" OnClick="btnSend_Click" />
            <br />
            <asp:Label ID="lblShowSelected" runat="server"></asp:Label>
   
    </form>
</body>
</html>
