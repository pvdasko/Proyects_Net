using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity;
using CuestionarioWebApp;
using System.Text;

namespace CuestionarioWebApp.Preguntas
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
                var item = new CuestionarioWebApp.C_Preguntas_Cuestionario();

                TryUpdateModel(item);

                if (ModelState.IsValid)
                {
                    // Save changes
                    _db.C_Preguntas_Cuestionario.Add(item);
                    try
                    {
                        _db.SaveChanges();
                    }
                    catch (System.Data.Entity.Validation.DbEntityValidationException e)
                    {

                        StringBuilder sb = new StringBuilder();
                        foreach (var eve in e.EntityValidationErrors)
                        {
                            sb.AppendLine(string.Format("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                                                            eve.Entry.Entity.GetType().Name,
                                                            eve.Entry.State));
                            foreach (var ve in eve.ValidationErrors)
                            {
                                sb.AppendLine(string.Format("- Property: \"{0}\", Error: \"{1}\"",
                                                            ve.PropertyName,
                                                            ve.ErrorMessage));
                            }
                        }
                        throw new System.Data.Entity.Validation.DbEntityValidationException(sb.ToString(), e);
            
                    }

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