<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Insert.aspx.cs" Inherits="CuestionarioWebApp.Respuestas.Insert" %>

<%@ Register TagPrefix="FriendlyUrls" Namespace="Microsoft.AspNet.FriendlyUrls" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../css/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <p>&nbsp;</p>
            <asp:FormView runat="server"
                ItemType="CuestionarioWebApp.C_Respuestas_Cuestionario" DefaultMode="Insert"
                InsertItemPosition="FirstItem" InsertMethod="InsertItem"
                OnItemCommand="ItemCommand" RenderOuterTable="false">
                <InsertItemTemplate>
                    <fieldset class="form-horizontal">
                        <legend>Insert Respuestas</legend>
                        <asp:ValidationSummary runat="server" CssClass="alert alert-danger" />
                        <div class="row">
                            <div class="col-sm-2 text-left">
                                <strong>Corporativo</strong>
                            </div>
                            <div class="col-sm-4">
                                <asp:DynamicControl runat="server" DataField="Corporativo" ID="Corporativo" Mode ="Insert"  />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-2 text-left">
                                <strong>Hotel</strong>
                            </div>
                            <div class="col-sm-4">
                                <asp:DynamicControl runat="server" DataField="Hotel" ID="Hotel" Mode ="Insert" />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-2 text-left">
                                <strong>Tipo Cuestionario</strong>
                            </div>
                            <div class="col-sm-4">
                                <asp:DynamicControl runat="server" DataField="Tipo_Cuestionario" ID="Tipo_Cuestionario"  Mode ="Insert" />
                            </div>
                        </div>
                         <div class="row">
                            <div class="col-sm-2 text-left">
                                <strong>No Pregunta</strong>
                            </div>
                            <div class="col-sm-4">
                                <asp:DynamicControl runat="server" DataField="No_Pregunta" ID="No_Pregunta" Mode="Insert" />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-2 text-left">
                                <strong>No Respuesta</strong>
                            </div>
                            <div class="col-sm-4">
                                <asp:DynamicControl runat="server" DataField="No_Respuesta" ID="No_Respuesta" Mode="Insert" />
                            </div>
                        </div>
                         <div class="row">
                            <div class="col-sm-2 text-left">
                                <strong>Respuesta</strong>
                            </div>
                            <div class="col-sm-4">
                                <asp:DynamicControl runat="server" DataField="Respuesta" ID="Respuesta" Mode="Insert" />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-2 text-left">
                                <strong>Respuesta Ingles</strong>
                            </div>
                            <div class="col-sm-4">
                                <asp:DynamicControl runat="server" DataField="Respuesta_Ingles" ID="Respuesta_Ingles" Mode="Insert" />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-2 text-left">
                                <strong>Respuesta Abierta</strong>
                            </div>
                            <div class="col-sm-4">
                                <asp:DynamicControl runat="server" DataField="Respuesta_Abierta" ID="Respuesta_Abierta" Mode="Insert" />
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
