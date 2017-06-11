<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Delete.aspx.cs" Inherits="CuestionarioWebApp.Tipos.Delete" %>

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
        <h3>Esta seguro de borrar el tipo cuestionario?</h3>
        <asp:FormView runat="server"
            ItemType="CuestionarioWebApp.C_Tipos_Cuestionario" DataKeyNames="Corporativo,Hotel,Tipo_Cuestionario"
            DeleteMethod="DeleteItem" SelectMethod="GetItem"
            OnItemCommand="ItemCommand" RenderOuterTable="false">
            <EmptyDataTemplate>
                   No hay resultados para el tipo cuestionario <%: Request.QueryString["Corporativo"] %>
            </EmptyDataTemplate>
            <ItemTemplate>
                <fieldset class="form-horizontal">
                    <legend>Delete Correos</legend>
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
                                <asp:DynamicControl runat="server" DataField="Descripcion" ID="Descripcion" Mode="ReadOnly" />
                            </div>
                        </div>
                         <div class="row">
                            <div class="col-sm-2 text-left">
                                <strong>Descripción Ingles</strong>
                            </div>
                            <div class="col-sm-4">
                                <asp:DynamicControl runat="server" DataField="Descripcion_Ingles" ID="Descripcion_Ingles" Mode="ReadOnly" />
                            </div>
                        </div>
                 	<div class="row">
					  &nbsp;
					</div>
					<div class="form-group">
						<div class="col-sm-offset-2 col-sm-10">
							<asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="Delete" CssClass="btn btn-danger" />
							<asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Cancel" CssClass="btn btn-default" />
						</div>
					</div>
                </fieldset>
            </ItemTemplate>
        </asp:FormView>
    </div>
    </form>
</body>
</html>
