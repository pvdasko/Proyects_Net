using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cuestionario.DataAccesComponent;

namespace Cuestionario.BusinessRuleComponent
{
    public class Cuestionario
    {

        #region vars&const
        public long Corporativo { get; set; }
        public string Hotel { get; set; }
        public string Tipo_Cuestionario { get; set; }
        public int No_Pregunta { get; set; }
        public string Tipo_Pregunta { get; set; }
        public string Pregunta { get; set; }
        public string Pregunta_Ingles { get; set; }
        public int Calificacion_Maxima { get; set; }
        public int No_Respuesta { get; set; }
        public string Respuesta { get; set; }
        public string Respuesta_Ingles { get; set; }
        public bool Respuesta_Abierta { get; set; }
        public string Folio { get; set; }



        #endregion

        public DataTable getCuestionario()
        {
            DataAccess dao = new DataAccess();
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            SqlParameter[] parameters = new SqlParameter[3];
            parameters[0] = new SqlParameter("@Corporativo", Corporativo);
            parameters[1] = new SqlParameter("@Hotel", Hotel);
            parameters[2] = new SqlParameter("@Tipo", Tipo_Cuestionario);
            ds = dao.ExecuteDataSet("[ConsultaEncuesta]", parameters);
            if (ds.Tables.Count > 0)
                dt = ds.Tables[0];

            return dt;
        }


        public DataTable getCuestionarioResp()
        {
            DataAccess dao = new DataAccess();
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            SqlParameter[] parameters = new SqlParameter[4];
            parameters[0] = new SqlParameter("@Corporativo", Corporativo);
            parameters[1] = new SqlParameter("@Hotel", Hotel);
            parameters[2] = new SqlParameter("@Tipo", Tipo_Cuestionario);
            parameters[3] = new SqlParameter("@Folio", Folio);
            ds = dao.ExecuteDataSet("[ConsultaEncuestaResp]", parameters);
            if (ds.Tables.Count > 0)
                dt = ds.Tables[0];

            return dt;
        }


        public string construyeHeader(string pTextoSuperior, string pTextoSuperiorIng)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<div class=\"row\"><span class=\"text-encabezado\" style = \"text-align: justify;\"><strong>" + pTextoSuperior + " / " + pTextoSuperiorIng + "</strong></span></div>");
            sb.Append("</br> ");
            return sb.ToString();
        }



        public string construyeItem(object datos)
        {
            StringBuilder sb = new StringBuilder();
            DataRowView info;
            string dnopregunta;
            string dtipopregunta;
            string dpregunta;
            int dcalifmax;
            string drespuesta;
            string dnorespuesta;
            bool drespabierta;
            int maximo;

            info = (DataRowView)datos;

            dnopregunta = info["No Pregunta"].ToString();
            dtipopregunta = info["Tipo Pregunta"].ToString();
            dpregunta = info["Pregunta"].ToString();
            dcalifmax = int.Parse(info["Calificacion Maxima"].ToString());
            drespuesta = info["Respuesta"].ToString();
            dnorespuesta = info["No Respuesta"].ToString();
            drespabierta = bool.Parse(info["Respuesta Abierta"].ToString());
            maximo = int.Parse(info["Maximo"].ToString());

            
            if (dnorespuesta == "1")
            {
               
                sb.Append("<div class=\"container-fluid\">");
                sb.Append("<div class=\"row\"><span class=\"text-pregunta\"><strong >" + dpregunta + "</strong></span></div>");
                sb.Append("</br> ");
                if (dtipopregunta == "Calif")
                {
                    sb.Append("<div class=\"row visible-sep\"><div class=\"col-sm-4 \">&nbsp</div>");
                    for (int i = 1; i <= dcalifmax; i++)
                    {
                        sb.Append("<div class=\"col-sm-1\" style = \"text-align: center;\" ><span class=\"visible-label\">" + i.ToString() + "</span></div>");
                     
                    }
                    sb.Append("<div class=\"col-sm-1\" style = \"text-align: center;\" ><span class=\"visible-label\">N/A</span></div><hr></div>");
                    //sb.Append("<hr> ");
                }
              
            }


            switch (dtipopregunta)
            {

                case "Abier":
                    sb.Append("<div class=\"row\"><input id=" + dtipopregunta + dnopregunta + "_" + dnorespuesta + " type=\"text\" onblur=\"myFunction(this.value, this.id)\" onkeypress=\"return soloLetras(event)\"  required style=\"width: 70%;\"/>&nbsp<h4><span class=\"text-respuesta\" >" + drespuesta + "</span>");
                    sb.Append("</div>");
                    sb.Append("</br> ");
                    break;

                case "Calif":
                    sb.Append("<div class=\"row\">");
                    sb.Append("<div class=\"col-sm-4\"><span class=\"text-respuesta\">" + drespuesta + "</span></div>");
                    for (int i = 1; i <= dcalifmax; i++)
                    {
                        sb.Append("<div class=\"col-sm-1\" style = \"text-align: center;\" >");
                        sb.Append("<input id = " + dtipopregunta + dnopregunta + "_" + dnorespuesta + "#" + i.ToString() + " name=\"Rad" + dnopregunta + dnorespuesta + "\" type=\"radio\" class=\"rach\" onchange=\"myFunction(this.value, this.id)\"  required/>");
                        sb.Append("&nbsp<span class=\"hidden-label\">" + i.ToString() + "</span>");
                        sb.Append("</div>");
                    }
                    sb.Append("<div class=\"col-sm-1\" style = \"text-align: center;\">");
                    sb.Append("<input id = " + dtipopregunta + dnopregunta + "_" + dnorespuesta + "#0 name=\"Rad" + dnopregunta + dnorespuesta + "\" type=\"radio\"  class=\"rach\" onchange=\"myFunction(this.value, this.id)\" required/>");
                    sb.Append("&nbsp<span class=\"hidden-label\">N/A</span>");
                    sb.Append("</div>");                    
                    sb.Append("</div>");
                  
                    break;

                case "Opcio":                    
                    if (!drespabierta)
                    {
                        sb.Append("<div class=\"row\">");
                        sb.Append("<input id = " + dtipopregunta + dnopregunta + "_" + dnorespuesta + " name=\"Rad" + dnopregunta + "\" type=\"radio\" onchange=\"myFunction(this.value, this.id)\" class=\"rach\" required/>");
                        sb.Append("&nbsp<span class=\"text-respuesta\" >" + drespuesta + "</span></div>");
                     
                    }
                    else
                    {
                        sb.Append("<div class=\"row\">");
                        sb.Append("<input name=\"Rad" + dnopregunta + "\" type=\"radio\" class=\"rach\"  required/>");
                        sb.Append("&nbsp<span><input id=" + dtipopregunta + dnopregunta + "_" + dnorespuesta + " type=\"text\" onblur=\"myFunction(this.value, this.id)\" onkeypress=\"return soloLetras(event)\" placeholder=\"" + drespuesta + "\" style=\"width: 70%;\" /></span></div>");
                      
                    }                   
                    break;

                case "Selec":                   
                    if (!drespabierta)
                    {
                         sb.Append("<div class=\"row\">");
                         sb.Append("<input id=" + dtipopregunta + dnopregunta + "_" + dnorespuesta + "  type=\"checkbox\"  onchange=\"myFunction(this.value, this.id)\" class=\"rach\" />");
                         sb.Append("&nbsp<span class=\"text-respuesta\" >" + drespuesta + "</span></div>");
                     

                    }
                    else
                    {
                        sb.Append("<div class=\"row\">");
                        sb.Append("<input type=\"checkbox\" class=\"rach\" />&nbsp<span><input id=" + dtipopregunta + dnopregunta + "_" + dnorespuesta + " type=\"text\" onblur=\"myFunction(this.value, this.id)\" onkeypress=\"return soloLetras(event)\" placeholder=\"" + drespuesta + "\" style=\"width: 70%;\"/></span></div>");                       
                    }
                    
                    break;
            }

            //if (dtipopregunta == "Calif" && int.Parse(dnorespuesta) == maximo)
            //    sb.Append("<tbody/></tr></table>");

            if (int.Parse(dnorespuesta) == maximo)
                sb.Append("</div></br>");
            return sb.ToString();


        }


    }
}