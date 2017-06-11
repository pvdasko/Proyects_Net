using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity;
using CuestionarioWebApp;

namespace CuestionarioWebApp.Respuestas
{
    public partial class Default : System.Web.UI.Page
    {
        int pcorpo;
        string photel;
        string ptipo;
        int pnopregunta;        
        protected CuestionarioEntities _db = new CuestionarioEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["corpo"] != null)
            {
                pcorpo = int.Parse(Request.QueryString["corpo"]);
                Session["scorpo"] = pcorpo;
            }
            if (Request.QueryString["hotel"] != null)
            {
                photel = Request.QueryString["hotel"];
                Session["shotel"] = photel;
            }

            if ( Request.QueryString["tipo"] != null )
            {
                ptipo = Request.QueryString["tipo"];
                Session["stipo"] = ptipo;
            }

            if (Request.QueryString["nopregunta"] != null) 
            { 
                pnopregunta = int.Parse(Request.QueryString["nopregunta"]);
                Session["snopregunta"] = pnopregunta;
            }
        }

        // Model binding method to get List of S_Corporativos entries
        // USAGE: <asp:ListView SelectMethod="GetData">
        public IQueryable<CuestionarioWebApp.C_Respuestas_Cuestionario> GetData()
        {
            int pcorpo = int.Parse(HttpContext.Current.Session["scorpo"].ToString());
            string photel = HttpContext.Current.Session["shotel"].ToString();
            string ptipo = HttpContext.Current.Session["stipo"].ToString();
            int pnopregunta = int.Parse(HttpContext.Current.Session["snopregunta"].ToString());

            //return _db.C_Respuestas_Cuestionario.Where(m => m.Corporativo == pcorpo && m.Hotel == photel && m.Tipo_Cuestionario == ptipo && m.No_Pregunta == pnopregunta).FirstOrDefault();
            return _db.C_Respuestas_Cuestionario.Where(m => m.Corporativo == pcorpo && m.Hotel == photel && m.Tipo_Cuestionario == ptipo && m.No_Pregunta == pnopregunta);
           
        }
    }
}