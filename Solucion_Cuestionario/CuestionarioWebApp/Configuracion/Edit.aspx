<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="CuestionarioWebApp.Configuracion.Edit" %>

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
                ItemType="CuestionarioWebApp.S_Configuracion_Cuestionario" DefaultMode="Edit" DataKeyNames="Corporativo,Hotel,Tipo_Cuestionario"
                UpdateMethod="UpdateItem" SelectMethod="GetItem"
                OnItemCommand="ItemCommand" RenderOuterTable="false">
                <EmptyDataTemplate>
                    No se pueden encontrar correos para el Corporativo <%: Request.QueryString["Corporativo"] %>
                </EmptyDataTemplate>
                <EditItemTemplate>
                    <fieldset class="form-horizontal">
                        <legend>Edit Configuración</legend>
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
                                <strong>Email Saliente</strong>
                            </div>
                            <div class="col-sm-4">
                                <asp:DynamicControl runat="server" DataField="Email_Saliente" ID="Email_Saliente" Mode="Edit" />
                            </div>
                        </div>
                         <div class="row">
                            <div class="col-sm-2 text-left">
                                <strong>Servidor SMTP</strong>
                            </div>
                            <div class="col-sm-4">
                                <asp:DynamicControl runat="server" DataField="Servidor_SMTP" ID="Servidor_SMTP" Mode="Edit" />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-2 text-left">
                                <strong>Usuario SMTP</strong>
                            </div>
                            <div class="col-sm-4">
                                <asp:DynamicControl runat="server" DataField="Usuario_SMTP" ID="Usuario_SMTP" Mode="Edit" />
                            </div>
                        </div>
                         <div class="row">
                            <div class="col-sm-2 text-left">
                                <strong>Contrasena SMTP</strong>
                            </div>
                            <div class="col-sm-4">
                                <asp:DynamicControl runat="server" DataField="Contrasena_SMTP" ID="Contrasena_SMTP" Mode="Edit" />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-2 text-left">
                                <strong>Puerto SMTP</strong>
                            </div>
                            <div class="col-sm-4">
                                <asp:DynamicControl runat="server" DataField="Puerto_SMTP" ID="Puerto_SMTP" Mode="Edit" />
                            </div>
                        </div>
                         <div class="row">
                            <div class="col-sm-2 text-left">
                                <strong>Texto Superior</strong>
                            </div>
                            <div class="col-sm-4">
                                <asp:DynamicControl runat="server" DataField="Texto_Superior" ID="Texto_Superior" Mode="Edit"  />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-2 text-left">
                                <strong>Texto Superior Ingles</strong>
                            </div>
                            <div class="col-sm-4">
                                <asp:DynamicControl runat="server" DataField="Texto_Superior_Ingles" ID="Texto_Superior_Ingles" Mode="Edit"/>
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
