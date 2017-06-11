using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity;
using Microsoft.AspNet.FriendlyUrls.ModelBinding;
using CuestionarioWebApp;

namespace CuestionarioWebApp.Respuestas
{
    public partial class Delete : System.Web.UI.Page
    {
        int pcorpo;
        string photel;
        string ptipo;
        int  pnopregunta;
        int pnorespuesta;
        protected CuestionarioEntities _db = new CuestionarioEntities();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void DeleteItem(long Corporativo, string Hotel, string Tipo_Cuestionario , long No_Pregunta, long No_Respuesta)
        {
            using (_db)
            {
                var item = _db.C_Respuestas_Cuestionario.Where(m => m.Corporativo == Corporativo && m.Hotel == Hotel && m.Tipo_Cuestionario == Tipo_Cuestionario && m.No_Pregunta == No_Pregunta && m.No_Respuesta == No_Respuesta ).FirstOrDefault();

                
                if (item != null)
                {
                    _db.C_Respuestas_Cuestionario.Remove(item);
                    _db.SaveChanges();
                }
            }
            Response.Redirect("../Respuetas/Default.aspx");
        }


        public CuestionarioWebApp.C_Respuestas_Cuestionario GetItem()
        {
            pcorpo = int.Parse(Request.QueryString["corpo"]);            
            photel = Request.QueryString["hotel"];
            ptipo  = Request.QueryString["tipo"];
            pnopregunta  = int.Parse ( Request.QueryString["nopregunta"]);
            pnorespuesta = int.Parse(Request.QueryString["norespuesta"]);
            if (pcorpo == null)
            {
                return null;
            }

            using (_db)
            {
                return _db.C_Respuestas_Cuestionario.Where(m => m.Corporativo == pcorpo && m.Hotel == photel && m.Tipo_Cuestionario == ptipo && m.No_Pregunta == pnopregunta && m.No_Respuesta == pnorespuesta ).FirstOrDefault();
            }
        }

        protected void ItemCommand(object sender, FormViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Cancel", StringComparison.OrdinalIgnoreCase))
            {
                Response.Redirect("../Respuestas/Default.aspx");
            }
        }
    }
}