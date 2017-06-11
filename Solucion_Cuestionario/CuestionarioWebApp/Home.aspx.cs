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
        int pcorpo;
        string photel;
        string ptipo;
        string pfolio;
               

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargaListas();
            }
            
        }

        private  void  cargaListas(  )
        {
            List<S_Corporativos> corporativo = PopulateCorporativo();

            ddlCorpo.Items.Clear();
            ddlCorpo.Items.Add (new ListItem {Text ="Seleccione Corporativo", Value= "0"} );
            ddlCorpo.AppendDataBoundItems = true;
            ddlCorpo.DataTextField = "Nombre_Corporativo";
            ddlCorpo.DataValueField = "Corporativo";
            ddlCorpo.DataSource = corporativo;
            ddlCorpo.DataBind ();

          

        }

        private List <S_Corporativos > PopulateCorporativo()
        {
            using (CuestionarioEntities  db = new CuestionarioEntities ())
            {
                return db.S_Corporativos.OrderBy(a => a.Corporativo).ToList(); 

            }


        }

        private List<S_Hoteles> PopulateHotel(int pCorpo)
        {
            using (CuestionarioEntities db = new CuestionarioEntities())

            {
                return db.S_Hoteles.Where(a => a.Corporativo.Equals(pCorpo)).ToList();
            }
        }

        private List<C_Tipos_Cuestionario> PopulateTipos(int pCorpo, string pHotel)
        { 
            using (CuestionarioEntities db = new CuestionarioEntities ())
            {

                return db.C_Tipos_Cuestionario.Where(a => a.Corporativo == pCorpo && a.Hotel == pHotel).ToList();
            }
        
        }
            
               
        protected void ddlHotel_SelectedIndexChanged(object sender, EventArgs e)
        {
            pcorpo = (int)Session["sCorpo"];
            photel = ddlHotel.SelectedValue; 
            List<C_Tipos_Cuestionario > tipo =PopulateTipos (pcorpo, photel );

            ddlTipo.Items.Clear();
            ddlTipo.Items.Add(new ListItem { Text = "Selecciones Tipo", Value = "0" });
            ddlTipo.AppendDataBoundItems = true;
            ddlTipo.DataTextField = "Descripcion";
            ddlTipo.DataValueField = "Tipo_Cuestionario";
            ddlTipo.DataSource = tipo;
            ddlTipo.DataBind();
            Session["sHotel"] = photel;
        }

        protected void ddlCorpo_SelectedIndexChanged(object sender, EventArgs e)
        {
            pcorpo = ddlCorpo.SelectedIndex;
            List<S_Hoteles> hotel = PopulateHotel(pcorpo);

            ddlHotel.Items.Clear();
            ddlHotel.Items.Add(new ListItem { Text = "Selecciones Hotel", Value = "0" });
            ddlHotel.AppendDataBoundItems = true;
            ddlHotel.DataTextField = "Nombre_Hotel";
            ddlHotel.DataValueField = "Hotel";
            ddlHotel.DataSource = hotel;
            ddlHotel.DataBind();
            Session["sCorpo"] = pcorpo;
            
        }
               
        protected void ddlTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["sTipo"] = ddlTipo.SelectedValue;
                        
        }
        

        protected void testmail_Click(object sender, EventArgs e)
        {
           
            Mail correo = new Mail();
            correo.SMTP = "smtp.gmail.com"; //"mail.bluekey.com.mx";
            correo.MailFrom = "pvdasko@gmail.com";               //"mauricio.miranda@bluekey.com.mx";
            correo.MailTo = "noe_rom@outlook.com";
            correo.IsHTML = true;
            correo.sendMail("mensaje de prueba", "este es el cuerpo del mensaje");

        
        }

        protected void btnTest_Click1(object sender, EventArgs e)
        {
            pcorpo = (int)Session["sCorpo"];
            photel = (string)Session["sHotel"];
            ptipo = (string)Session["sTipo"];
            pfolio = txtFolio.Value  ;
            Response.Redirect("Encuesta.aspx?Corpo=" + pcorpo + "&hotel=" + photel + "&tipo=" + ptipo + "&folio=" + pfolio);

        }

        protected void btnMail_Click(object sender, EventArgs e)
        {
            Mail correo = new Mail();
            correo.SMTP = "mail.bluekey.com.mx";
            correo.MailFrom = "mauricio.miranda@bluekey.com.mx";
            correo.MailTo = "noe_rom@outlook.com";
            correo.IsHTML = true;
            correo.sendMail("mensaje de prueba", "este es el cuerpo del mensaje");

            ClientScript.RegisterStartupScript(this.GetType(), "SHOW_MESSAGE", "<script type='text/javascript'>alert('Correo end¿viado')</script>");
        }

        
      

      
      
        
    }
}