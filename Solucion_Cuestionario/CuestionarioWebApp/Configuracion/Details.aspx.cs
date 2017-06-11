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

namespace CuestionarioWebApp.Configuracion
{
    public partial class Details : System.Web.UI.Page
    {
        int  pcorpo;
        string photel;
        string ptipo;
       
        protected CuestionarioEntities _db = new CuestionarioEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        // This is the Select methd to selects a single S_Corporativos item with the id
        // USAGE: <asp:FormView SelectMethod="GetItem">
        public CuestionarioWebApp.S_Configuracion_Cuestionario GetItem()
        {
            pcorpo = int.Parse(Request.QueryString["corpo"]);
            photel = Request.QueryString["hotel"];
            ptipo = Request.QueryString["tipo"];
          
            if (pcorpo == null)
            {
                return null;
            }

            using (_db)
            {
                return _db.S_Configuracion_Cuestionario.Where(m => m.Corporativo == pcorpo && m.Hotel == photel && m.Tipo_Cuestionario == ptipo ).FirstOrDefault();
            }
        }

        protected void ItemCommand(object sender, FormViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Cancel", StringComparison.OrdinalIgnoreCase))
            {
                Response.Redirect("../Configuracion/Default.aspx");
            }
        }
    }
}