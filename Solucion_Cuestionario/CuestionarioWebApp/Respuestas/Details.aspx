<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Details.aspx.cs" Inherits="CuestionarioWebApp.Respuestas.Details" %>

<%@ Register TagPrefix="FriendlyUrls" Namespace="Microsoft.AspNet.FriendlyUrls" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <link href="../css/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div  class="container">
            <p>&nbsp;</p>

            <asp:FormView runat="server"
                ItemType="CuestionarioWebApp.C_Respuestas_Cuestionario" DataKeyNames="Corporativo,Hotel,Tipo_Cuestionario,No_Pregunta, No_Respuesta"
                SelectMethod="GetItem"
                OnItemCommand="ItemCommand" RenderOuterTable="false">
                <EmptyDataTemplate>
                    No se pueden encontrar respuestas para el Corporativo <%: Request.QueryString["Corporativo"] %>
                </EmptyDataTemplate>
                <ItemTemplate>
                    <fieldset class="form-horizontal">
                        <legend>Detalle Respuesta <%: Request.QueryString["Corporativo"] %></legend>
                        <div class="row">
                            <div class="col-sm-2 text-left">
                                <strong>Corporativo</strong>
                            </div>
                            <div class="col-sm-4">
                                <asp:DynamicControl runat="server" DataField="Corporativo" ID="Corporativo" Mode="ReadOnly" />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-2 text-left">
                                <strong>Hotel</strong>
                            </div>
                            <div class="col-sm-4">
                                <asp:DynamicControl runat="server" DataField="Hotel" ID="Hotel" Mode="ReadOnly" />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-2 text-left">
                                <strong>Tipo Cuestionario</strong>
                            </div>
                            <div class="col-sm-4">
                                <asp:DynamicControl runat="server" DataField="Tipo_Cuestionario" ID="Tipo_Cuestionario" Mode="ReadOnly" />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-2 text-left">
                                <strong>No Pregunta</strong>
                            </div>
                            <div class="col-sm-4">
                                <asp:DynamicControl runat="server" DataField="No_Pregunta" ID="No_Pregunta" Mode="ReadOnly" />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-2 text-left">
                                <strong>No Respuesta</strong>
                            </div>
                            <div class="col-sm-4">
                                <asp:DynamicControl runat="server" DataField="No_Respuesta" ID="No_Respuesta" Mode="ReadOnly" />
                            </div>
                        </div>
                         <div class="row">
                            <div class="col-sm-2 text-left">
                                <strong>Respuesta</strong>
                            </div>
                            <div class="col-sm-4">
                                <asp:DynamicControl runat="server" DataField="Respuesta" ID="Respuesta" Mode="ReadOnly" />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-2 text-left">
                                <strong>Respuesta Ingles</strong>
                            </div>
                            <div class="col-sm-4">
                                <asp:DynamicControl runat="server" DataField="Respuesta_Ingles" ID="Respuesta_Ingles" Mode="ReadOnly" />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-2 text-left">
                                <strong>Respuesta Abierta</strong>
                            </div>
                            <div class="col-sm-4">
                                <asp:DynamicControl runat="server" DataField="Respuesta_Abierta" ID="Respuesta_Abierta" Mode="ReadOnly" />
                            </div>
                        </div>
                        <div class="row">
                            &nbsp;
                        </div>
                        <div class="form-group">
                            <div class="col-sm-offset-2 col-sm-10">
                                <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Back" CssClass="btn btn-default" />
                            </div>
                        </div>
                    </fieldset>
                </ItemTemplate>
            </asp:FormView>
        </div>
    </form>
</body>
</html>
