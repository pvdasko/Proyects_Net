<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Insert.aspx.cs" Inherits="CuestionarioWebApp.Tipos.Insert" %>

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
                ItemType="CuestionarioWebApp.C_Tipos_Cuestionario" DefaultMode="Insert"
                InsertItemPosition="FirstItem" InsertMethod="InsertItem"
                OnItemCommand="ItemCommand" RenderOuterTable="false">
                <InsertItemTemplate>
                    <fieldset class="form-horizontal">
                        <legend>Insert Tipos Cuestionario</legend>
                        <asp:ValidationSummary runat="server" CssClass="alert alert-danger" />
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
                                    Mode="Insert"
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
                                    Mode="Insert"
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
                                <asp:DynamicControl runat="server" DataField="Tipo_Cuestionario" ID="Tipo_Cuestionario"  Mode ="Insert" />                                
                            </div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="col-sm-2 text-left">
                                <strong>Descripción</strong>
                            </div>
                            <div class="col-sm-4">
                                <asp:DynamicControl runat="server" DataField="Descripcion" ID="Descripcion" Mode ="Insert"  CssClass="texto400"/>
                            </div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="col-sm-2 text-left">
                                <strong>Descripción Ingles</strong>
                            </div>
                            <div class="col-sm-4">
                                <asp:DynamicControl runat="server" DataField="Descripcion_Ingles" ID="Descripcion_Ingles" Mode ="Insert"  CssClass="texto400"/>
                            </div>
                        </div>
                        <br />
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
