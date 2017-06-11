<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="CuestionarioWebApp.Tipos.Edit" %>

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
                ItemType="CuestionarioWebApp.C_Tipos_Cuestionario" DefaultMode="Edit" DataKeyNames="Corporativo,Hotel,Tipo_Cuestionario"
                UpdateMethod="UpdateItem" SelectMethod="GetItem"
                OnItemCommand="ItemCommand" RenderOuterTable="false">
                <EmptyDataTemplate>
                    No se pueden encontrar tipos cuestionario para el Corporativo <%: Request.QueryString["Corporativo"] %>
                </EmptyDataTemplate>
                <EditItemTemplate>
                    <fieldset class="form-horizontal">
                        <legend>Edit Tipos Cuestionario</legend>
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
                                <strong>Descripción</strong>
                            </div>
                            <div class="col-sm-4">
                                <asp:DynamicControl runat="server" DataField="Descripcion" ID="Descripcion" Mode="Edit" />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-2 text-left">
                                <strong>Descripción Ingles</strong>
                            </div>
                            <div class="col-sm-4">
                                <asp:DynamicControl runat="server" DataField="Descripcion_Ingles" ID="Descripcion_Ingles" Mode="Edit" />
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
