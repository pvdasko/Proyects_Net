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

        public string construyeHeader()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<tr><td>Encuesta de satisafacci�n / Satisfaction survey</td></tr>");
            return sb.ToString();
        }



        public string construyeItem(object datos)
        {
            StringBuilder sb = new StringBuilder();
            DataRowView info;
            string dnopregunta;
            string dtipopregunta;
            string dpregunta;
            int    dcalifmax;
            string drespuesta;
            string dnorespuesta;
            bool  drespabierta;

            info= (DataRowView) datos;

            dnopregunta = info["No Pregunta"].ToString ();
            dtipopregunta = info["Tipo Pregunta"].ToString();
            dpregunta = info["Pregunta"].ToString();
            dcalifmax = int.Parse (info["Calificacion Maxima"].ToString ()); 
            drespuesta = info["Respuesta"].ToString();
            dnorespuesta = info["No Respuesta"].ToString();
            drespabierta = bool.Parse (info["Respuesta Abierta"].ToString ());

            if (dnorespuesta == "1")
            {
                sb.Append("<tr><td><span class=\"text\"><strong >" + dpregunta + "</strong></span></td></tr>");               
                sb.Append("<tr><td>&nbsp</td></tr> ");
                if (dtipopregunta == "Calif")
                {
                    sb.Append("<tr>");
                    sb.Append("<td>");
                    for (int i = 1; i<=dcalifmax ; i++ )
                    {
                        sb.Append( i.ToString () + "&nbsp|&nbsp");
                    }
                    sb.Append("&nbspN/A");
                    sb.Append("</td>");
                    sb.Append("</tr>");
                    sb.Append("<tr><td>&nbsp</td></tr> ");
                }
            }


            switch (dtipopregunta )
            {

                case "Abier":
                    sb.Append("<tr>");
                    sb.Append("<td><input id=" + dtipopregunta  + dnopregunta + "_" + dnorespuesta + "\" type=\"text\" onchange=\"myFunction(this.value, this.id)\" class=\"form-control\" aria-describedby=\"sizing-addon2\" />&nbsp<span>" + drespuesta + "</span></td>");
                    sb.Append("</tr>");
                    sb.Append("<tr><td>&nbsp</td></tr> ");
                    break;

                case "Calif":
                    sb.Append("<tr><td>");
                    for (int i = 1; i <= dcalifmax + 1; i++)
                    {
                        sb.Append("&nbsp<input id = " + dtipopregunta + dnopregunta + "_" + dnorespuesta + "#" + i.ToString() + " name=\"Rad" + dnopregunta + dnorespuesta + "\" type=\"radio\" onchange=\"myFunction(this.value, this.id)\"/>");
                    }

                    sb.Append("&nbsp<span class=\"text\">" + drespuesta + "</span></td></tr>");                  
                    sb.Append("<tr><td>&nbsp</td></tr> ");
                    break;

                case "Opcio":
                    sb.Append("<tr>");
                    if (!drespabierta)
                    {
                        sb.Append("<td><input id = " + dtipopregunta  + dnopregunta + "_" + dnorespuesta + " name=\"Rad" + dnopregunta + "\" type=\"radio\" onchange=\"myFunction(this.value, this.id)\"/>&nbsp<span class=\"text\">" + drespuesta + "</span></td>");
                        sb.Append("<tr><td>&nbsp</td></tr> ");
                    }
                    else
                    {
                        sb.Append("<td class=\"col-sm-10\"><span>" + dtipopregunta + drespuesta + "&nbsp<input id=" + dnopregunta + "_" + dnorespuesta + "\" type=\"text\" onchange=\"myFunction(this.value, ths.id)\" class=\"form-control\" aria-label=\"...\"\"/></span></td>");
                        sb.Append("<tr><td>&nbsp</td></tr> ");
                     
                    }
                    sb.Append("</tr>");
                    break;

                case "Selec":
                    sb.Append("<tr>");
                    sb.Append("<td><input id=" + dtipopregunta + dnopregunta + "_" + dnorespuesta + "\" type=\"checkbox\"  onchange=\"myFunction(this.value, this.id)\" />&nbsp<span class=\"text\">" + drespuesta + "</span></td>");
                    sb.Append("</tr>");
                    sb.Append("<tr><td>&nbsp</td></tr> ");
                    break;
            }
            

            
            return sb.ToString();


        }


    }
}