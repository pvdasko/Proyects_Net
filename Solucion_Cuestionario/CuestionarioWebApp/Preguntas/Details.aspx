<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Details.aspx.cs" Inherits="CuestionarioWebApp.Preguntas.Details" %>

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
                ItemType="CuestionarioWebApp.C_Preguntas_Cuestionario" DataKeyNames="Corporativo,Hotel,Tipo_Cuestionario,No_Pregunta"
                SelectMethod="GetItem"
                OnItemCommand="ItemCommand" RenderOuterTable="false">
                <EmptyDataTemplate>
                    No se pueden encontrar preguntas para el Corporativo <%: Request.QueryString["Corporativo"] %>
                </EmptyDataTemplate>
                <ItemTemplate>
                    <fieldset class="form-horizontal">
                        <legend>Detalle Preguntas</legend>
                        <div class="row">
                            <div class="col-sm-2 text-left">
                                <strong>Corporativo</strong>
                            </div>
                            <div class="col-sm-4">
                                <asp:DropDownList ID="ddlCorporativo"
                                    DataSourceID="sdsCorporativo"
                                    DataTextField="Nombre_Corporativo"
                                    DataValueField="Corporativo"
                                    SelectedValue='<%# Bind("Corporativo") %>'
                                    runat="server"
                                    Mode="ReadOnly"
                                    Width="300px"
                                    AutoPostBack="True">
                                </asp:DropDownList>
                                <asp:SqlDataSource ID="sdsCorporativo" runat="server" ConnectionString="<%$ ConnectionStrings:CuestionarioConnectionString %>" SelectCommand="SELECT [Corporativo], [Nombre Corporativo] AS Nombre_Corporativo FROM [S_Corporativos]"></asp:SqlDataSource>
                            </div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="col-sm-2 text-left">
                                <strong>Hotel</strong>
                            </div>
                            <div class="col-sm-4">
                                <asp:DropDownList ID="ddlHotel"
                                    DataSourceID="sdsHotel"
                                    DataTextField="Nombre_Hotel"
                                    DataValueField="Hotel"
                                    SelectedValue='<%# Bind("Hotel") %>'
                                    runat="server"
                                    Mode="ReadOnly"
                                    Width="300px"
                                    AutoPostBack="True">
                                </asp:DropDownList>
                                <asp:SqlDataSource ID="sdsHotel" runat="server" ConnectionString="<%$ ConnectionStrings:CuestionarioConnectionString %>" SelectCommand="SELECT [Hotel], [Nombre Hotel] AS Nombre_Hotel FROM [S_Hoteles] WHERE ([Corporativo] = @Corporativo)">
                                    <SelectParameters>
                                        <asp:ControlParameter Name="Corporativo"
                                            ControlID="ddlCorporativo"
                                            PropertyName="SelectedValue" />
                                    </SelectParameters>
                                </asp:SqlDataSource>
                            </div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="col-sm-2 text-left">
                                <strong>Tipo Cuestionario</strong>
                            </div>
                            <div class="col-sm-4">
                                <asp:DropDownList ID="ddlTipoCuestionario"
                                    DataSourceID="sdsTipoCuestionario"
                                    DataTextField="Descripcion"
                                    DataValueField="Tipo_Cuestionario"
                                    SelectedValue='<%# Bind("Tipo_Cuestionario") %>'
                                    runat="server"
                                    Mode="ReadOnly"
                                    Width="300px"
                                    AutoPostBack="True">
                                </asp:DropDownList>
                                <asp:SqlDataSource ID="sdsTipoCuestionario" runat="server" ConnectionString="<%$ ConnectionStrings:CuestionarioConnectionString %>" SelectCommand="SELECT [Tipo Cuestionario] AS Tipo_Cuestionario, [Descripcion] FROM [C_Tipos Cuestionario] WHERE (([Corporativo] = @Corporativo) AND ([Hotel] = @Hotel))">
                                    <SelectParameters>
                                        <asp:ControlParameter Name="Corporativo"
                                            ControlID="ddlCorporativo"
                                            PropertyName="SelectedValue" />
                                        <asp:ControlParameter Name="Hotel"
                                            ControlID="ddlHotel"
                                            PropertyName="SelectedValue" />
                                    </SelectParameters>
                                </asp:SqlDataSource>
                            </div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="col-sm-2 text-left">
                                <strong>No Pregunta</strong>
                            </div>
                            <div class="col-sm-4">
                                <asp:DynamicControl runat="server" DataField="No_Pregunta" ID="No_Pregunta" Mode="ReadOnly" />
                            </div>
                        </div>
                        <br />
                         <div class="row">
                            <div class="col-sm-2 text-left">
                                <strong>Tipo Pregunta</strong>
                            </div>
                            <div class="col-sm-4">
                                <asp:DropDownList ID="ddlTipoPregunta"
                                    DataSourceID="sdsTipoPregunta"
                                    DataTextField="Descripcion"
                                    DataValueField="Tipo_Pregunta"
                                    SelectedValue='<%# Bind("Tipo_Pregunta") %>'
                                    runat="server"
                                    Mode="ReadOnly"
                                    Width="300px"
                                    AutoPostBack="True">
                                </asp:DropDownList>
                                <asp:SqlDataSource ID="sdsTipoPregunta" runat="server" ConnectionString="<%$ ConnectionStrings:CuestionarioConnectionString %>" SelectCommand="SELECT [Tipo Pregunta] AS Tipo_Pregunta, [Descripcion] FROM [C_Tipos Pregunta Cuestionario] WHERE (([Corporativo] = @Corporativo) AND ([Hotel] = @Hotel))">
                                    <SelectParameters>
                                        <asp:ControlParameter Name="Corporativo"
                                            ControlID="ddlCorporativo"
                                            PropertyName="SelectedValue" />
                                        <asp:ControlParameter Name="Hotel"
                                            ControlID="ddlHotel"
                                            PropertyName="SelectedValue" />
                                    </SelectParameters>
                                </asp:SqlDataSource>
                            </div>                           
                        </div>
                        <br />
                        <div class="row">
                            <div class="col-sm-2 text-left">
                                <strong>Pregunta</strong>
                            </div>
                            <div class="col-sm-4">
                                <asp:DynamicControl runat="server" DataField="Pregunta" ID="Pregunta" Mode="ReadOnly" />
                            </div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="col-sm-2 text-left">
                                <strong>Pregunta Ingles</strong>
                            </div>
                            <div class="col-sm-4">
                                <asp:DynamicControl runat="server" DataField="Pregunta_Ingles" ID="Pregunta_Ingles" Mode="ReadOnly" />
                            </div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="col-sm-2 text-left">
                                <strong>Calificacion Maxima</strong>
                            </div>
                            <div class="col-sm-4">
                                <asp:DynamicControl runat="server" DataField="Calificacion_Maxima" ID="Calificacion_Maxima" Mode="ReadOnly" />
                            </div>
                        </div>
                        <br />
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
