<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Delete.aspx.cs" Inherits="CuestionarioWebApp.Correos.Delete" %>

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
            <h3>Esta seguro de borrar el correo?</h3>
            <asp:FormView runat="server"
                ItemType="CuestionarioWebApp.S_Correos_Cuestionario" DataKeyNames="Corporativo,Hotel,Tipo_Cuestionario,Email"
                DeleteMethod="DeleteItem" SelectMethod="GetItem"
                OnItemCommand="ItemCommand" RenderOuterTable="false">
                <EmptyDataTemplate>
                    No hay resultados para correos <%: Request.QueryString["Corporativo"] %>
                </EmptyDataTemplate>
                <ItemTemplate>
                    <fieldset class="form-horizontal">
                        <legend>Delete Correos</legend>
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
                                <strong>Email</strong>
                            </div>
                            <div class="col-sm-4">
                                <asp:DynamicControl runat="server" DataField="Email" ID="Email" Mode="ReadOnly" />
                            </div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="col-sm-2 text-left">
                                <strong>Descripción</strong>
                            </div>
                            <div class="col-sm-4">
                                <asp:DynamicControl runat="server" DataField="Descripcion" ID="Descripcion" Mode="ReadOnly" />
                            </div>
                        </div>
                       <br />
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
