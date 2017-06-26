<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Insert.aspx.cs" Inherits="CuestionarioWebApp.Configuracion.Insert" %>

<%@ Register TagPrefix="FriendlyUrls" Namespace="Microsoft.AspNet.FriendlyUrls" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../css/bootstrap.min.css" rel="stylesheet" />
    <style>
        .texto250 .DDTextBox {
            width: 250px;
        }

        .texto300 .DDTextBox {
            width: 300px;
        }

        .texto400 .DDTextBox {
            width: 400px;
        }

        .texto500 .DDTextBox {
            width: 4500px;
        }
    </style>
    
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <p>&nbsp;</p>
            <asp:FormView runat="server"
                ItemType="CuestionarioWebApp.S_Configuracion_Cuestionario" DefaultMode="Insert"
                InsertItemPosition="FirstItem" InsertMethod="InsertItem"
                OnItemCommand="ItemCommand" RenderOuterTable="false">
                <InsertItemTemplate>
                    <fieldset class="form-horizontal">
                        <legend>Insert Configuración</legend>
                        <asp:ValidationSummary runat="server" CssClass="alert alert-danger" />
                        <div class="row">
                            <div class="col-sm-2 text-left">
                                <strong>Corporativo</strong>
                            </div>
                            <div class="col-sm-4">
                                <asp:DynamicControl runat="server" DataField="Corporativo" ID="Corporativo" Mode="Insert" />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-2 text-left">
                                <strong>Hotel</strong>
                            </div>
                            <div class="col-sm-4">
                                <asp:DynamicControl runat="server" DataField="Hotel" ID="Hotel" Mode="Insert" />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-2 text-left">
                                <strong>Tipo Cuestionario</strong>
                            </div>
                            <div class="col-sm-4">
                                <asp:DynamicControl runat="server" DataField="Tipo_Cuestionario" ID="Tipo_Cuestionario" Mode="Insert" />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-2 text-left">
                                <strong>Email Saliente</strong>
                            </div>
                            <div class="col-sm-4">
                                <asp:DynamicControl runat="server" DataField="Email_Saliente" ID="Email_Saliente" Mode="Insert" CssClass ="texto250" />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-2 text-left">
                                <strong>Servidor SMTP</strong>
                            </div>
                            <div class="col-sm-4">
                                <asp:DynamicControl runat="server" DataField="Servidor_SMTP" ID="Servidor_SMTP" Mode="Insert" />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-2 text-left">
                                <strong>Usuario SMTP</strong>
                            </div>
                            <div class="col-sm-4">
                                <asp:DynamicControl runat="server" DataField="Usuario_SMTP" ID="Usuario_SMTP" Mode="Insert" />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-2 text-left">
                                <strong>Contrasena SMTP</strong>
                            </div>
                            <div class="col-sm-4">
                                <asp:DynamicControl runat="server" DataField="Contrasena_SMTP" ID="Contrasena_SMTP" Mode="Insert" />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-2 text-left">
                                <strong>Puerto SMTP</strong>
                            </div>
                            <div class="col-sm-4">
                                <asp:DynamicControl runat="server" DataField="Puerto_SMTP" ID="Puerto_SMTP" Mode="Insert" />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-2 text-left">
                                <strong>Texto Superior</strong>
                            </div>
                            <div class="col-sm-4">
                                <asp:DynamicControl runat="server" DataField="Texto_Superior" ID="Texto_Superior" Mode="Insert"  CssClass ="texto400"/>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-2 text-left">
                                <strong>Texto Superior Ingles</strong>
                            </div>
                            <div class="col-sm-4">
                                <asp:DynamicControl runat="server" DataField="Texto_Superior_Ingles" ID="Texto_Superior_Ingles" Mode="Insert"   CssClass ="texto400"/>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-2 text-left">
                                <strong>Página Reinicio</strong>
                            </div>
                            <div class="col-sm-4">
                                <asp:DynamicControl runat="server" DataField="Pagina_Reinicio" ID="Pagina_Reinicio" Mode="Insert"   CssClass ="texto250"/>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-sm-offset-2 col-sm-10">
                                <asp:Button runat="server" ID="InsertButton" CommandName="Insert" Text="Insert" CssClass="btn btn-primary" />
                                <asp:Button runat="server" ID="CancelButton" CommandName="Cancel" Text="Cancel" CausesValidation="false" CssClass="btn btn-default" />
                            </div>
                        </div>
                    </fieldset>
                </InsertItemTemplate>
            </asp:FormView>
        </div>
    </form>
</body>
</html>
