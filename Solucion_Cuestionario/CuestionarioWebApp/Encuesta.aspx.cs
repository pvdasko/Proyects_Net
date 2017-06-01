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
                cargaEncuesta();
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
        }

        [System.Web.Services.WebMethod]
        public static void insRespuesta(string idrespuesta, string valor )
        {
            string tp = idrespuesta.Substring(0, 5);
            int ip = idrespuesta.IndexOf("_");
            int ic = idrespuesta.IndexOf("#");
            int np = int.Parse(idrespuesta.Substring(7,ip-5));
            int nr = int.Parse(idrespuesta.Substring(ip + 1, ic));
            
            int cal = 0;
            if (ic > 0)
               cal = int.Parse( idrespuesta.Substring(ic + 1));

            using (CuestionarioEntities context = new CuestionarioEntities())
            {
                O_Respuestas_Cuestionario_Huespedes resp = new O_Respuestas_Cuestionario_Huespedes();


                resp.Corporativo = 1;
                resp.Hotel = "BK";
                resp.Tipo_Cuestionario = "H";
                resp.No_Pregunta = np;
                resp.Id = "0000001";
                resp.No_Respuesta = nr;
                resp.Calificacion = cal;
                resp.Texto = valor =="on" ? "": valor ;


                context.O_Respuestas_Cuestionario_Huespedes.Add(resp);
                context.SaveChanges();
            }
        }

    }
}