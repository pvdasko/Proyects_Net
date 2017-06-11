<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Encuesta.aspx.cs" Inherits="CuestionarioWebApp.Encuesta" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.2/jquery.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <script>
        function myFunction(val, id) {
            //alert("The input value has changed. The new value is: " + val + " id:" + id);           
            $.ajax({
                type: "POST",
                data: "{ idrespuesta: '" + id + "', valor: '" + val + "' }",
                url: "Encuesta.aspx/insRespuesta",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (msg) {
                    $("#lblMensajes").append(msg);
                    $("#lblMensajes").append("<br />");
                },
                error: function (msg) { alert("Error al insertar registro."); }
            });
        }

        function onMetodoOk(resultado) {
            // Acciones para realizar con resultado

        }

        function onMetodoError(error) {
            alert(error.get_message());
        }
    </script>
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <link href="css/BlueKey.css" rel="stylesheet" />
    <link href="css/Encuesta.css" rel="stylesheet" />
    <style>
        a:hover {
            background-color: lightgray ;
        }
    </style>
</head>
<body class="body">
    <form id="form1" runat="server" data-toggle="validator">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div>
            <div class="navbar navbar-default navbar-fixed-top" role="navigation">
                <div class="container">
                    <div class="navbar-header">
                        <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
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
                            <li class="active"><a href="Encuesta.aspx">Encuesta</a></li>
                            <li><a href="#">About</a></li>
                            <li><a href="#">Contac</a></li>
                        </ul>
                    </div>
                </div>
            </div>
            <br />
            <br />
            <br />
            <div class="panel panel-default">
                <div class="container body-content">
                    <div class="page-header">
                        <h1><small>Satisfacción del visitante
                        </small></h1>
                    </div>
                    <asp:Repeater ID="RprEncuesta" runat="server">
                        <HeaderTemplate>

                            <table>
                                <%#encuestaHeader()%>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <%#encuestaItem(Container.DataItem)%>
                        </ItemTemplate>
                        <FooterTemplate>
                            </table>
                            
                       
                        </FooterTemplate>
                    </asp:Repeater>
                    <asp:Button ID="btnSend" runat="server" Text="Enviar / Send" OnClick="btnSend_Click" />

                    <br />
                    <br />
                </div>

            </div>
            <label id="lblMensajes" />
            <div class="panel-footer">
                <p>&copy; <%: DateTime.Now.Year %> - BlueKey</p>
            </div>

            <!-- Bootstrap Modal Dialog -->
            <div class="modal fade" id="myModal" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                <div class="modal-dialog">
                    <asp:UpdatePanel ID="upModal" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div class="modal-content">
                                <div class="modal-header">
                                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                    <h4 class="modal-title">
                                        <asp:Label ID="lblModalTitle" runat="server" Text=""></asp:Label></h4>
                                </div>
                                <div class="modal-body">
                                    <asp:Label ID="lblModalBody" runat="server" Text=""></asp:Label>
                                </div>
                                <div class="modal-footer">
                                    <button class="btn btn-info" data-dismiss="modal" aria-hidden="true">Close</button>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
