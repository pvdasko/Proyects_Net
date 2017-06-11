using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity;
using CuestionarioWebApp;

namespace CuestionarioWebApp.Tipos
{
    public partial class Insert : System.Web.UI.Page
    {
        protected CuestionarioEntities _db = new CuestionarioEntities();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void InsertItem()
        {
            using (_db)
            {
                var item = new CuestionarioWebApp.C_Tipos_Cuestionario();

                TryUpdateModel(item);

                if (ModelState.IsValid)
                {
                    // Save changes
                    _db.C_Tipos_Cuestionario.Add(item);
                    _db.SaveChanges();

                    Response.Redirect("Default.aspx");
                }
            }
        }

        protected void ItemCommand(object sender, FormViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Cancel", StringComparison.OrdinalIgnoreCase))
            {
                Response.Redirect("Default.aspx");
            }
        }
    }
}