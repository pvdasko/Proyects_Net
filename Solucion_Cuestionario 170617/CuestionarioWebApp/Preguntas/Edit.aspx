﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="CuestionarioWebApp.Preguntas.Edit" %>

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
                ItemType="CuestionarioWebApp.C_Preguntas_Cuestionario" DefaultMode="Edit" DataKeyNames="Corporativo,Hotel,Tipo_Cuestionario,No_Pregunta"
                UpdateMethod="UpdateItem" SelectMethod="GetItem"
                OnItemCommand="ItemCommand" RenderOuterTable="false">
                <EmptyDataTemplate>
                    No se pueden encontrar preguntas para el Corporativo <%: Request.QueryString["Corporativo"] %>
                </EmptyDataTemplate>
                <EditItemTemplate>
                    <fieldset class="form-horizontal">
                        <legend>Edit Preguntas</legend>
                        <asp:ValidationSummary runat="server" CssClass="alert alert-danger" />
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
                                <strong>Tipo Pregunta</strong>
                            </div>
                            <div class="col-sm-4">
                                <asp:DynamicControl runat="server" DataField="Tipo_Pregunta" ID="Tipo_Pregunta" Mode="Edit" />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-2 text-left">
                                <strong>Pregunta</strong>
                            </div>
                            <div class="col-sm-4">
                                <asp:DynamicControl runat="server" DataField="Pregunta" ID="Pregunta" Mode="Edit"  CssClass="texto400"/>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-2 text-left">
                                <strong>Pregunta Ingles</strong>
                            </div>
                            <div class="col-sm-4">
                                <asp:DynamicControl runat="server" DataField="Pregunta_Ingles" ID="Pregunta_Ingles" Mode="Edit" CssClass="texto400" />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-2 text-left">
                                <strong>Calificacion Maxima</strong>
                            </div>
                            <div class="col-sm-4">
                                <asp:DynamicControl runat="server" DataField="Calificacion_Maxima" ID="Calificacion_Maxima" Mode="Edit" />
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-sm-offset-2 col-sm-10">
                                <asp:Button runat="server" ID="UpdateButton" CommandName="Update" Text="Update" CssClass="btn btn-primary" />
                                <asp:Button runat="server" ID="CancelButton" CommandName="Cancel" Text="Cancel" CausesValidation="false" CssClass="btn btn-default" />
                            </div>
                        </div>
                    </fieldset>
                </EditItemTemplate>
            </asp:FormView>
        </div>
    </form>
</body>
</html>
