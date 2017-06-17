<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Encuesta.aspx.cs" Inherits="CuestionarioWebApp.Encuesta" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0, user-scalable=no" />
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

        function soloLetras(e) {
            key = e.keyCode || e.which;
            tecla = String.fromCharCode(key).toLowerCase();
            letras = " áéíóúabcdefghijklmnñopqrstuvwxyz";
            especiales = "8-37-39-46";

            tecla_especial = false
            for (var i in especiales) {
                if (key == especiales[i]) {
                    tecla_especial = true;
                    break;
                }
            }

            if (letras.indexOf(tecla) == -1 && !tecla_especial) {
                return false;
            }
        }
        function onMetodoOk(resultado) {
            // Acciones para realizar con resultado

        }

        function onMetodoError(error) {
            alert(error.get_message());
        }
    </script>
    <script src="js/bootstrap.min.js"></script>
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <link href="css/BlueKey.css" rel="stylesheet" />
    <%--<link href="css/Encuesta.css" rel="stylesheet" />--%>
    <style>
        a:hover {
            background-color: lightgray;
        }

        .contenedorEncuesta {
            width: 100%;
            margin: 0 auto;
            overflow: hidden;
        }

        body {
            font-family: "Helvetica Neue",Helvetica,Arial,sans-serif;
        }

        .main {
            width: 100%;
            padding: 20px;
            float: left;
            box-sizing: border-box;
        }

        span.hidden-label {
            visibility: hidden;
        }

        span.visible-label {
            visibility: visible;
        }

        row.visible-sep {
            display: block;
        }

        .rach {
            width: 1.8em;
            height: 1.8em;
        }

        @media screen and (max-width: 767px) {
            .contenedorEncuesta {
                width: 100%;
                margin: 0 auto;
                overflow: hidden;
            }

            .main {
                width: 100%;
                padding: 10px;
                float: left;
                box-sizing: border-box;
            }

            body {
                font-size: 1.2em;
                font-family: "Helvetica Neue",Helvetica,Arial,sans-serif;
            }

            hr.hidden {
                visibility: hidden;
            }

            span.hidden-label {
                visibility: visible;
            }

            span.visible-label {
                visibility: hidden;
            }

            row.visible-sep {
                display: none;
            }

            .rach {
                width: 1.5em;
                height: 1.5em;
            }
        }

        @media screen and (max-width: 400px) {
            .contenedorEncuesta {
                width: 100%;
                margin: 0 auto;
                overflow: hidden;
            }

            .main {
                width: 100%;
                padding: 5px;
                float: left;
                box-sizing: border-box;
            }

            body {
                font-size: 1em;
                font-family: "Helvetica Neue",Helvetica,Arial,sans-serif;
            }

            hr.hidden {
                visibility: hidden;
            }

            span.hidden-label {
                visibility: visible;
            }

            span.visible-label {
                visibility: hidden;
            }

            row.visible-sep {
                display: none;
            }

            .rach {
                width: 1.4em;
                height: 1.4em;
            }
        }

        .text-pregunta {
            color: #aa6708;
        }

        .text-respuesta {
            color: #29293d;
        }

        .text-titulo {
            color: #1b809e;
        }

        .text-encabezado {
            color: #a94442;
        }
    </style>
</head>
<body class="body ">
    <form id="form1" runat="server" data-toggle="validator">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="container-fluid">
            <div class="navbar navbar-default navbar-fixed-top" role="navigation">
                <div class="container">
                    <div class="navbar-header">
                        <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                            <span class="sr-only">Toggle navigation</span>
                            <span class="icon-bar"></span>
                            <span class="icon-bar"></span>
                            <span class="icon-bar"></span>
                        </button>
                        <a class="navbar-brand" href="#"><span>
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
            <%--     <div class="panel panel-default">
                <div class="container body-content">
                    <div class="page-header">--%>
            <section class="main">
                <div>
                    <div>
                        <div>
                            <h1><small class="text-titulo">Satisfacción del visitante
                            </small></h1>
                        </div>
                        <asp:Repeater ID="RprEncuesta" runat="server">
                            <HeaderTemplate>
                                <div class="container-fluid">
                                    <%#encuestaHeader()%>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <%#encuestaItem(Container.DataItem)%>
                            </ItemTemplate>
                            <FooterTemplate>
                                </div>
                       
                            </FooterTemplate>
                        </asp:Repeater>
                        <asp:Button ID="btnSend" runat="server" Text="Enviar / Send" OnClick="btnSend_Click" CssClass="btn btn-info" />

                        <br />
                        <br />
                    </div>

                </div>
            </section>


        </div>
        <footer>
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

        </footer>
    </form>
</body>
</html>
