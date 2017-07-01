using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Cuestionario.BusinessRuleComponent;

namespace CuestionarioWebApp
{
    public partial class Encuesta : System.Web.UI.Page
    {
        int pcorpo;
        string photel;
        string ptipo;
        string pfolio;
        public Cuestionario.BusinessRuleComponent.Cuestionario objCuestionario;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                validaHuesped();

            }

            Page.RegisterRedirectOnSessionEndScript();            

        }


        private void validaHuesped()
        {
            pcorpo = int.Parse(Request.QueryString["corpo"]);
            photel = Request.QueryString["hotel"];
            ptipo = Request.QueryString["tipo"];
            pfolio = Request.QueryString["folio"];

            Session["scorpo"] = pcorpo;
            Session["shotel"] = photel;
            Session["stipo"] = ptipo;
            Session["sfolio"] = pfolio;

            using (CuestionarioEntities context = new CuestionarioEntities())
            {

                var pag = context.S_Configuracion_Cuestionario.Where(m => m.Corporativo == pcorpo && m.Hotel == photel && m.Tipo_Cuestionario == ptipo).FirstOrDefault();
                Session["sweb"] = pag.Pagina_Reinicio.ToString();
  
                var huesped = (from h in context.O_Huespedes
                               where h.Corporativo == pcorpo && h.Hotel == photel && h.Id == pfolio
                               select new
                               {
                                   h
                               });

                if (huesped.Count() > 0)
                {
                    if (!validaEncuesta())
                    {
                        cargaEncuesta();
                    }
                    
                }
                else
                {

                    Response.Redirect("Empty.aspx?paction=2");  

                }


            }

        }

        private bool validaEncuesta()
        {

            bool valida = true;

            pcorpo = int.Parse(Request.QueryString["corpo"]);
            photel = Request.QueryString["hotel"];
            ptipo = Request.QueryString["tipo"];
            pfolio = Request.QueryString["folio"];

            using (CuestionarioEntities context = new CuestionarioEntities())
            {
                var cuestionario = (from c in context.O_Respuestas_Cuestionario_Huespedes
                                    where c.Corporativo == pcorpo && c.Hotel == photel && c.Tipo_Cuestionario == ptipo && c.Id == pfolio
                                    select new
                                    {
                                        c
                                    });

                if (cuestionario.Count() == 0)
                {

                    valida = false;

                }
                else
                {
                    Response.Redirect("Empty.aspx?paction=1");  
                  

                }



            }

            return valida;

        }

        private void cargaEncuesta()
        {
            pcorpo = int.Parse(Request.QueryString["corpo"]);
            photel = Request.QueryString["hotel"];
            ptipo = Request.QueryString["tipo"];
            pfolio = Request.QueryString["folio"];


            this.objCuestionario = new Cuestionario.BusinessRuleComponent.Cuestionario();
            objCuestionario.Corporativo = pcorpo;
            objCuestionario.Hotel = photel;
            objCuestionario.Tipo_Cuestionario = ptipo;


            this.RprEncuesta.DataSource = objCuestionario.getCuestionario();
            this.RprEncuesta.DataBind();

        }


        protected string encuestaHeader()
        {
            pcorpo = int.Parse(Request.QueryString["corpo"]);
            photel = Request.QueryString["hotel"];
            ptipo = Request.QueryString["tipo"];
            string ptxt ;
            string ptxting;

            using (CuestionarioEntities context = new CuestionarioEntities())
            {
               
                var textSupIng = (from c in context.S_Configuracion_Cuestionario 
                                    where c.Corporativo == pcorpo && c.Hotel == photel && c.Tipo_Cuestionario == ptipo 
                                    select new
                                    {                                       
                                        c
                                        
                                    }).SingleOrDefault ();

                ptxt =  textSupIng.c.Texto_Superior ;
                ptxting = textSupIng.c.Texto_Superior_Ingles ;

                
            }
            return this.objCuestionario.construyeHeader(ptxt, ptxting );
        }

        protected string encuestaItem(object datos)
        {
            return this.objCuestionario.construyeItem(datos);
        }



        protected void btnSend_Click(object sender, EventArgs e)
        {
            string body;
            body = construyeCuerpo();
            enviaCorreo(body);
            Response.Redirect("Empty.aspx?paction=3");  
            
        }


        private string construyeCuerpo()
        {
            DataTable dtable = new DataTable();
            Cuestionario.BusinessRuleComponent.Cuestionario objCuestionarioResp = new Cuestionario.BusinessRuleComponent.Cuestionario();

            objCuestionarioResp.Corporativo = int.Parse(HttpContext.Current.Session["scorpo"].ToString());
            objCuestionarioResp.Hotel = HttpContext.Current.Session["shotel"].ToString();
            objCuestionarioResp.Tipo_Cuestionario = HttpContext.Current.Session["stipo"].ToString();
            objCuestionarioResp.Folio = HttpContext.Current.Session["sfolio"].ToString();

            dtable = objCuestionarioResp.getCuestionarioResp();

            StringBuilder sb = new StringBuilder();

            string dnopregunta;
            string dtipopregunta;
            string dpregunta;
            int dcalifmax;
            string drespuesta;
            string dnorespuesta;
            bool drespabierta;
            int maximo;
            string dnorespuestaHuesped;
            string dtexto;
            string dcalificacion;
            string ptxt;
            string ptxting;

            using (CuestionarioEntities context = new CuestionarioEntities())
            {

                var textSupIng = (from c in context.S_Configuracion_Cuestionario
                                  where c.Corporativo == objCuestionarioResp.Corporativo && c.Hotel == objCuestionarioResp.Hotel && c.Tipo_Cuestionario == objCuestionarioResp.Tipo_Cuestionario
                                  select new
                                  {
                                      c

                                  }).SingleOrDefault();

                ptxt = textSupIng.c.Texto_Superior;
                ptxting = textSupIng.c.Texto_Superior_Ingles;


            }
            sb.Append("<html xmlns=\"http://www.w3.org/1999/xhtml\"><body>");
            sb.Append("<h3 align=\"left\">Satisfacción del visitante / Satisfaction of the visitor</h3>");
            sb.Append("</br>");
            sb.Append("<h4 align=\"justify\">" + ptxt + " / " + ptxting + "</h4>");

            foreach (DataRow info in dtable.Rows)
            {

                dnopregunta = info["No Pregunta"].ToString();
                dtipopregunta = info["Tipo Pregunta"].ToString();
                dpregunta = info["Pregunta"].ToString();
                dcalifmax = int.Parse(info["Calificacion Maxima"].ToString());
                drespuesta = info["Respuesta"].ToString();
                dnorespuesta = info["No Respuesta"].ToString();
                drespabierta = bool.Parse(info["Respuesta Abierta"].ToString());
                maximo = int.Parse(info["Maximo"].ToString());
                dnorespuestaHuesped = info["RespuestaHuesped"].ToString();
                dtexto = info["Texto"].ToString();
                dcalificacion = info["Calificacion"].ToString();

                if (dnopregunta == "1")
                    sb.Append("<table>");


                if (dnorespuesta == "1")
                {
                    sb.Append("<tr><td><span class=\"text-danger\"><strong >" + dpregunta + "</strong></span></td></tr>");
                    sb.Append("<tr><td></td></tr> ");
                    if (dtipopregunta == "Calif")
                    {
                        sb.Append("<tr><td>");
                        sb.Append(" <div class=\"table table-condensed\"><table class=\"table\"><tr><th></th>");
                        for (int i = 1; i <= dcalifmax; i++)
                        {
                            sb.Append("<th align=\"center\">");
                            sb.Append( i.ToString());
                            sb.Append("</th>");
                        }
                        sb.Append("<th>");
                        sb.Append("N/A");
                        sb.Append("</th>");
                        sb.Append("</tr>");

                    }
                }



                switch (dtipopregunta)
                {

                    case "Abier":
                        sb.Append("<tr>");
                        sb.Append("<td><span class=\"text\">" + dtexto + "</span></td>");
                        sb.Append("</tr>");
                        sb.Append("<tr><td></td></tr> ");
                        break;

                    case "Calif":
                        sb.Append("<tr><td>");
                        sb.Append("<span class=\"text\">" + drespuesta + "</span></td>");
                        for (int i = 1; i <= dcalifmax + 1; i++)
                        {
                            if (int.Parse(dcalificacion) == i || dcalificacion == "0")
                            {
                                sb.Append("<td align=\"center\">");
                                sb.Append("<input id = " + dtipopregunta + dnopregunta + "_" + dnorespuesta + "#" + i.ToString() + " name=\"Rad" + dnopregunta + dnorespuesta + "\" type=\"radio\"  aria-label=\"...\" checked />");
                                sb.Append("</td>");
                            }
                            else
                            {
                                sb.Append("<td align=\"center\">");
                                sb.Append("<input id = " + dtipopregunta + dnopregunta + "_" + dnorespuesta + "#" + i.ToString() + " name=\"Rad" + dnopregunta + dnorespuesta + "\" type=\"radio\"  aria-label=\"...\" />");
                                sb.Append("</td>");
                            }
                        }

                        break;

                    case "Opcio":
                        sb.Append("<tr>");
                        if (!drespabierta)
                        {
                            if (dnorespuesta == dnorespuestaHuesped)
                            {
                                sb.Append("<td><input id = " + dtipopregunta + dnopregunta + "_" + dnorespuesta + " name=\"Rad" + dnopregunta + "\" type=\"radio\" checked/>&nbsp<span class=\"text\" aria-label=\"...\" >" + drespuesta + "</span></td>");
                                sb.Append("<tr><td></td></tr> ");
                            }
                            else
                            {
                                sb.Append("<td><input id = " + dtipopregunta + dnopregunta + "_" + dnorespuesta + " name=\"Rad" + dnopregunta + "\" type=\"radio\" />&nbsp<span class=\"text\" aria-label=\"...\" >" + drespuesta + "</span></td>");
                                sb.Append("<tr><td></td></tr> ");
                            }
                        }
                        else
                        {
                            if (dnorespuesta == dnorespuestaHuesped)
                            {
                                sb.Append("<td><span class=\"text\">" + drespuesta + " : " + dtexto + "</span></td>");
                                sb.Append("<tr><td></td></tr> ");
                            }
                            else
                            {
                                sb.Append("<td></td>");
                                sb.Append("<tr><td></td></tr> ");
                            }

                        }
                        sb.Append("</tr>");
                        break;

                    case "Selec":
                        sb.Append("<tr>");
                        if (!drespabierta)
                        {
                            if (dnorespuesta == dnorespuestaHuesped)
                            {
                                sb.Append("<td><input id=" + dtipopregunta + dnopregunta + "_" + dnorespuesta + " type=\"checkbox\" checked />&nbsp<span class=\"text\" >" + drespuesta + "</span></td>");
                                sb.Append("</tr>");
                                sb.Append("<tr><td></td></tr> ");
                            }
                            else
                            {
                                sb.Append("<td><input id=" + dtipopregunta + dnopregunta + "_" + dnorespuesta + " type=\"checkbox\" />&nbsp<span class=\"text\" >" + drespuesta + "</span></td>");
                                sb.Append("</tr>");
                                sb.Append("<tr><td></td></tr> ");
                            }
                        }
                        else
                        {
                            if (dnorespuesta == dnorespuestaHuesped)
                            {
                                sb.Append("<td><span class=\"text\">" + drespuesta + " : " + dtexto + "</span></td>");
                                sb.Append("<tr><td></td></tr> ");
                            }
                            else
                            {
                                sb.Append("<td>&#160</td>");
                                sb.Append("<tr><td></td></tr> ");
                            }
                        }
                        break;
                }

                if (dtipopregunta == "Calif" && int.Parse(dnorespuesta) == maximo)
                    sb.Append("</tr></table></div>");

                if (int.Parse(dnorespuesta) == maximo)
                    sb.Append("<tr><td></td></tr> ");

            }

            sb.Append("</table> ");
            sb.Append("</body></html>");
            return sb.ToString();

        }

        private void terminaSesion()
        {
            Session.Remove("scorpo");
            Session.Remove("shotel");
            Session.Remove("stipo");
            Session.Remove("sfolio");
            string script = "window.close();";
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "closewindow", script, true);

        }
        private void enviaCorreo(string pbody)
        {
            Mail correo = new Mail();
            StringBuilder sb = new StringBuilder();

            int pcorpo = int.Parse(HttpContext.Current.Session["scorpo"].ToString());
            string photel = HttpContext.Current.Session["shotel"].ToString();
            string ptipo = HttpContext.Current.Session["stipo"].ToString();

            using (CuestionarioEntities context = new CuestionarioEntities())
            {

                var config = (from c in context.S_Configuracion_Cuestionario
                                  where c.Corporativo == pcorpo && c.Hotel == photel && c.Tipo_Cuestionario == ptipo
                                  select new
                                  {
                                      c

                                  }).SingleOrDefault();

                var mails = (from m in context.S_Correos_Cuestionario
                             where m.Corporativo == pcorpo && m.Hotel == photel && m.Tipo_Cuestionario == ptipo
                             select new
                             {
                                 m

                             }).ToList ();

                foreach (var m in mails  )
                {
                    sb.Append(m.m.Email);
                    sb.Append(";");

                }

                correo.SMTP = config.c.Servidor_SMTP;
                correo.MailFrom = config.c.Email_Saliente;
                correo.Port = int.Parse (config.c.Puerto_SMTP.ToString ());   
                correo.IsHTML = true;

              
                 
                
            }
            correo.MailTo = sb.ToString().TrimEnd (';');
            correo.sendMail("Encuesta de Satisfacción", pbody);
        }


        [System.Web.Services.WebMethod]
        public static void insRespuesta(string idrespuesta, string valor)
        {


            int pcorpo = int.Parse(HttpContext.Current.Session["scorpo"].ToString());
            string photel = HttpContext.Current.Session["shotel"].ToString();
            string ptipo = HttpContext.Current.Session["stipo"].ToString();
            string pfolio = HttpContext.Current.Session["sfolio"].ToString();
            int nr = 0;
            string tp = idrespuesta.Substring(0, 5);
            int ip = idrespuesta.IndexOf("_");
            int ic = idrespuesta.IndexOf("#");
            int np = int.Parse(idrespuesta.Substring(5, ip - 5));

            if (ic < 0)
            {
                nr = int.Parse(idrespuesta.Substring(ip + 1));
            }
            else
            {
                nr = int.Parse(idrespuesta.Substring(ip + 1, ic - ip - 1));
            }

            int cal = 0;
            if (ic > 0)
                cal = int.Parse(idrespuesta.Substring(ic + 1));

            using (CuestionarioEntities context = new CuestionarioEntities())
            {

                List<O_Respuestas_Cuestionario_Huespedes> respuesta = PopulateResp(pcorpo, photel, ptipo, np, pfolio, nr, tp);

                if (tp == "Opcio" && respuesta.Count > 0)
                {
                    O_Respuestas_Cuestionario_Huespedes respDel = context.O_Respuestas_Cuestionario_Huespedes.First(a =>
                                          a.Corporativo == pcorpo
                                          && a.Hotel == photel
                                          && a.Tipo_Cuestionario == ptipo
                                          && a.No_Pregunta == np
                                          && a.Id == pfolio);
                    context.O_Respuestas_Cuestionario_Huespedes.Remove(respDel);
                    context.SaveChanges();
                }
                else if ((tp == "Calif" || tp == "Abier") && respuesta.Count > 0)
                {
                    O_Respuestas_Cuestionario_Huespedes respDel = context.O_Respuestas_Cuestionario_Huespedes.First(a =>
                                          a.Corporativo == pcorpo
                                          && a.Hotel == photel
                                          && a.Tipo_Cuestionario == ptipo
                                          && a.No_Pregunta == np
                                          && a.Id == pfolio
                                          && a.No_Respuesta == nr);
                    context.O_Respuestas_Cuestionario_Huespedes.Remove(respDel);
                    context.SaveChanges();
                }
                else if (tp == "Selec" && respuesta.Count > 0)
                {
                    O_Respuestas_Cuestionario_Huespedes respDel = context.O_Respuestas_Cuestionario_Huespedes.First(a =>
                                          a.Corporativo == pcorpo
                                          && a.Hotel == photel
                                          && a.Tipo_Cuestionario == ptipo
                                          && a.No_Pregunta == np
                                          && a.Id == pfolio
                                          && a.No_Respuesta == nr);
                    context.O_Respuestas_Cuestionario_Huespedes.Remove(respDel);
                    context.SaveChanges();
                    return;
                }

                O_Respuestas_Cuestionario_Huespedes resp = new O_Respuestas_Cuestionario_Huespedes();
                resp.Corporativo = pcorpo;
                resp.Hotel = photel;
                resp.Tipo_Cuestionario = ptipo;
                resp.No_Pregunta = np;
                resp.Id = pfolio;
                resp.No_Respuesta = nr;
                resp.Calificacion = cal;
                resp.Texto = valor == "on" ? "" : valor;
                context.O_Respuestas_Cuestionario_Huespedes.Add(resp);
                context.SaveChanges();
                                
            }
        }

        [System.Web.Services.WebMethod]
        public static List<O_Respuestas_Cuestionario_Huespedes> PopulateResp(int pCorpo, string pHotel, string ptipo, int pnp, string pfolio, int pnr, string ptp)
        {
            using (CuestionarioEntities db = new CuestionarioEntities())
            {
                if (ptp == "Opcio")
                {
                    return db.O_Respuestas_Cuestionario_Huespedes.Where(a => a.Corporativo == pCorpo && a.Hotel == pHotel && a.Tipo_Cuestionario == ptipo && a.No_Pregunta == pnp && a.Id == pfolio).ToList();
                }
                else
                {
                    return db.O_Respuestas_Cuestionario_Huespedes.Where(a => a.Corporativo == pCorpo && a.Hotel == pHotel && a.Tipo_Cuestionario == ptipo && a.No_Pregunta == pnp && a.Id == pfolio && a.No_Respuesta == pnr).ToList();
                }
            }

        }









    }
}