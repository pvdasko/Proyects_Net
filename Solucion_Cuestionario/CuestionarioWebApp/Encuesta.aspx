<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Encuesta.aspx.cs" Inherits="CuestionarioWebApp.Encuesta" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.2/jquery.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <link href="css/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="navbar navbar-default navbar-fixed-top" role="navigation">
                <div class="container">
                    <div class="navbar-header">
                        <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#bs-example-navbar-collapse-1" aria-expanded="false">
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
            <div class="panel panel-default">
                <div class="panel-body">

                    <asp:Repeater ID="RprEncuesta" runat="server">
                        <HeaderTemplate>
                            <table>
                                <%--<%#encuestaHeader()%>--%>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <%#encuestaItem(Container.DataItem)%>
                        </ItemTemplate>
                        <FooterTemplate>
                            </table>
                        </FooterTemplate>
                    </asp:Repeater>
                    <div class="col-sm-offset-2 col-sm-10">
                        <asp:Button ID="btnSend" runat="server" Text="Enviar / Send" CssClass="btn btn-default" OnClick="btnSend_Click" />                        
                    </div>
                </div>

            </div>

            <div class="panel-footer">Blue Key 2016</div>
        </div>
    </form>
</body>
</html>
