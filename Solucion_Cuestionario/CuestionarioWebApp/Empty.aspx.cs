using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace CuestionarioWebApp
{
    public partial class Empty : System.Web.UI.Page
    {
        int pcorpo;
        string photel;
        string ptipo;
        string pfolio;
        string ppagreinicio;
        string paction; // 1 folio ya enviado, 2, folio inexistente, 3 encuesta enviada, 4 sesion expirada
        protected void Page_Load(object sender, EventArgs e)
        {
            paction = Request.QueryString["paction"];
            ppagreinicio = HttpContext.Current.Session["sweb"].ToString();

            this.paginaredirect.Value = "http://" + ppagreinicio  +"/";
            if (paction == "1")
            {
                lblModalTitle.Text = "Gracias por su visita";
                lblModalBody.Text = "Folio ya enviado";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
                upModal.Update();

            } 
            else if (paction == "2")
            {
                lblModalTitle.Text = "Gracias por su visita";
                lblModalBody.Text = "Folio inexistente";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
                upModal.Update();
            }
            else if (paction == "3")
            {
                lblModalTitle.Text = "Gracias por su visita";
                lblModalBody.Text = "Sus respuestas fueron enviadas";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
                upModal.Update();
                terminaSesion();
            }
            else if (paction == "4")
            {
                borraFolio();
                lblModalTitle.Text = "Su sesión expiro";
                lblModalBody.Text = "Por favor!,  vuelva a ingresar al link de la encuesta";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
                upModal.Update();
                terminaSesion();
               
            }

            if (!IsPostBack)
            {

                Response.Cache.SetCacheability(HttpCacheability.ServerAndNoCache);
                Response.Cache.SetAllowResponseInBrowserHistory(false);
                Response.Cache.SetNoStore();
            }           
        }

        protected string ClientIDPageRedirect()
        {
            return this.paginaredirect.ClientID; 
        }

        protected void borraFolio()
        {
            try
            {
                pcorpo = int.Parse(HttpContext.Current.Session["scorpo"].ToString());
                photel = HttpContext.Current.Session["shotel"].ToString();
                ptipo = HttpContext.Current.Session["stipo"].ToString();
                pfolio = HttpContext.Current.Session["sfolio"].ToString();


                using (CuestionarioEntities context = new CuestionarioEntities())
                {
                    var respDel = context.O_Respuestas_Cuestionario_Huespedes.Where(a =>
                                              a.Corporativo == pcorpo
                                              && a.Hotel == photel
                                              && a.Tipo_Cuestionario == ptipo
                                              && a.Id == pfolio).ToList();
                    foreach (O_Respuestas_Cuestionario_Huespedes resHues in respDel)
                    {
                        context.O_Respuestas_Cuestionario_Huespedes.Remove(resHues);
                    }
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                Response.Redirect("http://" + ppagreinicio  +"/"); 
            }
            
        }

        private void terminaSesion()
        {
            Session.Remove("scorpo");
            Session.Remove("shotel");
            Session.Remove("stipo");
            Session.Remove("sfolio");
            Session.Remove("paction");
            
        }
    }
}