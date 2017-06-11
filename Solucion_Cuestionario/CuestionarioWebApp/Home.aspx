<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="CuestionarioWebApp.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.2/jquery.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <link href="css/BlueKey.css" rel="stylesheet" />
</head>
<body class=".body">
    <form id="form1" runat="server">
        <div>
            <div class="navbar navbar-default navbar-fixed-top" role="navigation">
                <div class="container">
                    <div class="navbar-header">
                        <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target=".navbar-collapse">
                            <span class="sr-only">Toggle navigation</span>
                            <span class="icon-bar"></span>
                            <span class="icon-bar"></span>
                            <span class="icon-bar"></span>
                        </button>
                        <a class="navbar-brand" href="Home.aspx"><span>
                            <img alt="Brand" src="img/logo_only.png" height="30" /></span> Encuesta</a>
                    </div>

                    <div class="navbar-collapse collapse">
                        <ul class="nav navbar-nav navbar-right">
                            <li class="active"><a href="Home.aspx">Home</a></li>
                            <li class="dropdown">
                                <a class="dropdown-toggle" data-toggle="dropdown" href="#">Admin
                                <span class="caret"></span></a>
                                <ul class="dropdown-menu">
                                      <li><a href="Configuracion/Default.aspx">Configuración</a></li>
                                      <li><a href="Correos/Default.aspx">Correos</a></li>
                                    <li><a href="Tipos/Default.aspx">Tipos Cuestionario</a></li>
                                      <li><a href="Preguntas/Default.aspx">Preguntas</a></li>
                                </ul>
                            </li>
                          
                            <li><a href="#">Contact</a></li>
                        </ul>
                    </div>
                </div>
            </div>

            <br />
            <br />
            <br />

            <div class="panel panel-default">
                <div class="container body-content">
                    <h2>Test web app</h2>
                    <br />
                    <asp:Label ID="lblCorpo" runat="server" Width="120px"><h5>Corporativo</h5></asp:Label>
                    <asp:DropDownList ID="ddlCorpo" runat="server" AutoPostBack="True" CssClass="dropdown-men" OnSelectedIndexChanged="ddlCorpo_SelectedIndexChanged" Width="150px"></asp:DropDownList>
                    <br />
                    <asp:Label ID="lblHotel" runat="server" Text="Hotel" Width="120px"><h5>Hotel</h5></asp:Label>
                    <asp:DropDownList ID="ddlHotel" runat="server" AutoPostBack="True" CssClass="dropdown-men" OnSelectedIndexChanged="ddlHotel_SelectedIndexChanged" Width="150px"></asp:DropDownList>
                    <br />
                    <asp:Label ID="lbltipo" runat="server" Text="Cuestionario" Width="120px"><h5>Cuestionario</h5></asp:Label>
                    <asp:DropDownList ID="ddlTipo" runat="server" AutoPostBack="True" CssClass="dropdown-men" OnSelectedIndexChanged="ddlTipo_SelectedIndexChanged" Width="150px"></asp:DropDownList>
                    <br />
                    <asp:Label ID="lblfolio" runat="server" Text="Folio" Width="120px"><h5>Folio</h5></asp:Label>
                    <span>
                        <input type="text" placeholder="Folio" aria-describedby="sizing-addon3" id="txtFolio" runat="server" /></span>
                    <br />
                    <br />
                    <asp:Button ID="btnTest" Text="Test Page" runat="server" OnClick="btnTest_Click1" CssClass="btn btn-default btn-lm" Width="100px" />
                    <br />
                    <br />
                    <asp:Button ID="btnMail" runat="server" Text="Enviar" OnClick="btnMail_Click" CssClass="btn btn-default btn-lm" Width="100px" Visible="False" />

                </div>
            </div>

            <div class="panel-footer">
                <p>&copy; <%: DateTime.Now.Year %> - BlueKey</p>
            </div>
        </div>
    </form>
</body>
</html>
