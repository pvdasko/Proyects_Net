using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CuestionarioWebApp
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            List<C_Preguntas_Cuestionario> allPreguntas = null;
            using (CuestionarioEntities dp = new CuestionarioEntities())
            {
                var pregunta= (from a in dp.C_Preguntas_Cuestionario 
                               select new {a});
                if (pregunta != null)
                {
                    allPreguntas = new List<C_Preguntas_Cuestionario>();
                    foreach (var i  in pregunta)
                    {
                        C_Preguntas_Cuestionario c = i.a;
                        allPreguntas.Add (c);
                    }
                }

                if (allPreguntas == null || allPreguntas.Count == 0)
                { 
                    allPreguntas.Add (new C_Preguntas_Cuestionario());
                    GridView1.DataSource = allPreguntas ;
                    GridView1.DataBind ();

                
                }
                else
                {
                            GridView1.DataSource = allPreguntas ;
                    GridView1.DataBind ();

                }

            }

        }
    }
}