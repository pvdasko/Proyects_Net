using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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
                //validaEncuesta();
               
            }

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
                var huesped = (from h in context.O_Huespedes 
                                where  h.Corporativo == pcorpo && h.Hotel == photel  && h.Id == pfolio                                      
                                select new 
                                {
                                    h
                                });

                if (huesped.Count() > 0)
                {
                    cargaEncuesta();
                    
                }
                else
                {
                    terminaSesion();
                    ClientScript.RegisterStartupScript(this.GetType(), "SHOW_MESSAGE", "<script type='text/javascript'>alert('Registro np Valido / Invalid registration ')</script>");
                    ClientScript.RegisterStartupScript(this.GetType(), "SHOW_MESSAGE", "<script type='text/javascript'>window.close(); return false;</script>");
                   
                    
                }

                
            }
        
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
            return this.objCuestionario.construyeHeader();
        }

        protected string encuestaItem(object datos)
        {
            return this.objCuestionario.construyeItem(datos);
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            //ClientScript.RegisterStartupScript(this.GetType(), "SHOW_MESSAGE", "<script type='text/javascript'>alert(\"Enviado / Send\")</script>");
            //ClientScript.RegisterStartupScript(this.GetType(), "SHOW_MESSAGE", "<script type='text/javascript'>window.close();</script>");
            //enviaCorreo();
            terminaSesion();
        }

        private void terminaSesion()
        {
            Session.Remove("scorpo");
            Session.Remove("shotel");
            Session.Remove("stipo");
            Session.Remove("sfolio");
        }
        private void enviaCorreo()
        {
            Mail correo = new Mail();
            correo.SMTP = "smtp.gmail.com";
            correo.MailFrom = "mauricio.miranda@bluekey.com.mx";
            correo.MailTo = "noe_rom@outlook.com";
            correo.IsHTML = true;
            correo.sendMail("mensaje de prueba", "este es el cuerpo del mensaje");

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