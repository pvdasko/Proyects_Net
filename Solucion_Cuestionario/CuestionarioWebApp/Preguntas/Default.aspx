<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CuestionarioWebApp.Preguntas.Default" %>
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
            <h2>Preguntas</h2>
            <p>
                <asp:HyperLink runat="server" NavigateUrl="Insert.aspx" Text="Create new" />
                  &nbsp;&nbsp; &nbsp;&nbsp;
                <asp:HyperLink runat="server" NavigateUrl="/" Text="Back Home" />
            </p>
            <div>
                <asp:ListView ID="ListView1" runat="server"
                    DataKeyNames="Corporativo,Hotel,Tipo_Cuestionario,No_Pregunta"
                    ItemType="CuestionarioWebApp.C_Preguntas_Cuestionario"
                    SelectMethod="GetData">
                    <EmptyDataTemplate>
                        No hay resultados para preguntas
                    </EmptyDataTemplate>
                    <LayoutTemplate>
                        <table class="table">
                            <thead>
                                <tr>
                                    <th>
                                        <asp:LinkButton Text="Corporativo" CommandName="Sort" CommandArgument="Corporativo" runat="Server" />
                                    </th>
                                    <th>
                                        <asp:LinkButton Text="Hotel" CommandName="Sort" CommandArgument="Hotel" runat="Server" />
                                    </th>
                                    <th>
                                        <asp:LinkButton Text="Tipo Cuestionario" CommandName="Sort" CommandArgument="Tipo_Cuestionario" runat="Server" />
                                    </th>
                                    <th>
                                        <asp:LinkButton Text="No Pregunta" CommandName="Sort" CommandArgument="No_Pregunta" runat="Server" />
                                    </th>
                                    <th>
                                        <asp:LinkButton Text="Pregunta" CommandName="Sort" CommandArgument="Pregunta" runat="Server" />
                                    </th>
                                    <th>&nbsp;</th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr runat="server" id="itemPlaceholder" />
                            </tbody>
                        </table>
                        <asp:DataPager PageSize="5" runat="server">
                            <Fields>
                                <asp:NextPreviousPagerField ShowLastPageButton="False" ShowNextPageButton="False" ButtonType="Button" ButtonCssClass="btn" />
                                <asp:NumericPagerField ButtonType="Button" NumericButtonCssClass="btn" CurrentPageLabelCssClass="btn disabled" NextPreviousButtonCssClass="btn" />
                                <asp:NextPreviousPagerField ShowFirstPageButton="False" ShowPreviousPageButton="False" ButtonType="Button" ButtonCssClass="btn" />
                            </Fields>
                        </asp:DataPager>
                    </LayoutTemplate>
                    <ItemTemplate>
                        <tr>
                            <td>
                                <asp:DynamicControl runat="server" DataField="Corporativo" ID="Corporativo" Mode="ReadOnly" />
                            </td>
                            <td>
                                <asp:DynamicControl runat="server" DataField="Hotel" ID="Hotel" Mode="ReadOnly" />
                            </td>
                            <td>
                                <asp:DynamicControl runat="server" DataField="Tipo_Cuestionario" ID="Tipo_Cuestionario" Mode="ReadOnly" />
                            </td>
                            <td>
                                <asp:DynamicControl runat="server" DataField="No_Pregunta" ID="No_Pregunta" Mode="ReadOnly" />
                            </td>
                            <td>
                                <asp:DynamicControl runat="server" DataField="Pregunta" ID="Pregunta" Mode="ReadOnly" />
                            </td>
                            <td>
                                <asp:HyperLink runat="server" NavigateUrl='<%# String.Format("~/Preguntas/Details.aspx?corpo={0}&hotel={1}&tipo={2}&nopregunta={3}", DataBinder.Eval(Container.DataItem, "Corporativo"), DataBinder.Eval(Container.DataItem, "Hotel"), DataBinder.Eval(Container.DataItem, "Tipo_Cuestionario"), DataBinder.Eval(Container.DataItem, "No_Pregunta")) %>' Text="Details" />
                                | 
					    <asp:HyperLink runat="server" NavigateUrl='<%# String.Format("~/Preguntas/Edit.aspx?corpo={0}&hotel={1}&tipo={2}&nopregunta={3}", DataBinder.Eval(Container.DataItem, "Corporativo"), DataBinder.Eval(Container.DataItem, "Hotel"), DataBinder.Eval(Container.DataItem, "Tipo_Cuestionario"), DataBinder.Eval(Container.DataItem, "No_Pregunta")) %>' Text="Edit" />
                                | 
                        <asp:HyperLink runat="server"   NavigateUrl= '<%# String.Format("~/Preguntas/Delete.aspx?corpo={0}&hotel={1}&tipo={2}&nopregunta={3}", DataBinder.Eval(Container.DataItem, "Corporativo"), DataBinder.Eval(Container.DataItem, "Hotel"), DataBinder.Eval(Container.DataItem, "Tipo_Cuestionario"), DataBinder.Eval(Container.DataItem, "No_Pregunta")) %>' Text="Delete" />
                                | 
                        <asp:HyperLink runat="server"   NavigateUrl= '<%# String.Format("~/Respuestas/Default.aspx?corpo={0}&hotel={1}&tipo={2}&nopregunta={3}", DataBinder.Eval(Container.DataItem, "Corporativo"), DataBinder.Eval(Container.DataItem, "Hotel"), DataBinder.Eval(Container.DataItem, "Tipo_Cuestionario"), DataBinder.Eval(Container.DataItem, "No_Pregunta")) %>' Text="Respuestas" />
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:ListView>
            </div>

        </div>
    </form>
</body>
</html>
