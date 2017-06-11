using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity;
using CuestionarioWebApp;

namespace CuestionarioWebApp.Configuracion
{

    public partial class Default : System.Web.UI.Page
    {
        protected CuestionarioEntities  _db = new CuestionarioEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        // Model binding method to get List of S_Corporativos entries
        // USAGE: <asp:ListView SelectMethod="GetData">
        public IQueryable<CuestionarioWebApp.S_Configuracion_Cuestionario> GetData()
        {
            return _db.S_Configuracion_Cuestionario;
        }
    }
}