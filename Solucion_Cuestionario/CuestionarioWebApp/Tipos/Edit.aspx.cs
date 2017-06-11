using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity;
using CuestionarioWebApp;

namespace CuestionarioWebApp.Tipos
{
    public partial class Edit : System.Web.UI.Page
    {
        int pcorpo;
        string photel;
        string ptipo;
        
        protected CuestionarioEntities _db = new CuestionarioEntities();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void UpdateItem(long Corporativo, string Hotel, string Tipo_Cuestionario )
        {
            using (_db)
            {
                var item = _db.C_Tipos_Cuestionario.Where(m => m.Corporativo == Corporativo && m.Hotel == Hotel && m.Tipo_Cuestionario == Tipo_Cuestionario ).FirstOrDefault();

                if (item == null)
                {
                    // The item wasn't found
                    ModelState.AddModelError("", String.Format("Item with id {0} was not found", Tipo_Cuestionario));
                    return;
                }

                TryUpdateModel(item);

                if (ModelState.IsValid)
                {
                    // Save changes here
                    _db.SaveChanges();
                    Response.Redirect("../Tipos/Default.aspx");
                }
            }
        }

        public CuestionarioWebApp.C_Tipos_Cuestionario GetItem()
        {
            pcorpo = int.Parse(Request.QueryString["corpo"]);
            photel = Request.QueryString["hotel"];
            ptipo = Request.QueryString["tipo"];
           

            if (pcorpo == null )
            {
                return null;
            }

            using (_db)
            {
                return _db.C_Tipos_Cuestionario.Where(m => m.Corporativo == pcorpo && m.Hotel == photel && m.Tipo_Cuestionario == ptipo ).FirstOrDefault();
            }
        }

        protected void ItemCommand(object sender, FormViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Cancel", StringComparison.OrdinalIgnoreCase))
            {
                Response.Redirect("../Tipos/Default.aspx");
            }
        }
    }
}