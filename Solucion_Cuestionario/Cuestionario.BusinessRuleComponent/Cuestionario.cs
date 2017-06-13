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
            sb.Append("<tr><td style = \"text-align: justify;\">" + pTextoSuperior + " / " + pTextoSuperiorIng + "</td></tr>");
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
                sb.Append("<tr><td><h4><span class=\"text-danger\"><strong >" + dpregunta + "</strong></span></h4></td></tr>");
                sb.Append("<tr><td>&nbsp</td></tr> ");
                if (dtipopregunta == "Calif")
                {
                    sb.Append("<tr>");
                    sb.Append("<td>");
                    sb.Append(" <div class=\"table-responsive\"><table class=\"table table-condensed\"><tr><th>&nbsp</th>");
                    for (int i = 1; i <= dcalifmax; i++)
                    {
                        sb.Append("<th style = \"text-align: center;\">");
                        sb.Append("<h5>&nbsp" + i.ToString() + "&nbsp</h5>");
                        sb.Append("</th>");
                    }
                    sb.Append("<th style = \"text-align: center;\">");
                    sb.Append("<h5>&nbspN/A&nbsp</h5>");
                    sb.Append("</th>");
                    sb.Append("</tr>");

                }
            }


            switch (dtipopregunta)
            {

                case "Abier":
                    sb.Append("<tr>");
                    sb.Append("<td><input id=" + dtipopregunta + dnopregunta + "_" + dnorespuesta + " type=\"text\" onblur=\"myFunction(this.value, this.id)\" onkeypress=\"validar()\" class=\"form-control input-lg\" aria-label=\"...\" required/>&nbsp<h4><span>" + drespuesta + "</span></h4></td>");
                    sb.Append("</tr>");
                    sb.Append("<tr><td>&nbsp</td></tr> ");
                    break;

                case "Calif":
                    sb.Append("<tr><td>");
                    sb.Append("<h4><span class=\"text\">" + drespuesta + "</span></h4></td>");
                    for (int i = 1; i <= dcalifmax; i++)
                    {
                        sb.Append("<td align=\"center\">");
                        sb.Append("<h4>&nbsp<input id = " + dtipopregunta + dnopregunta + "_" + dnorespuesta + "#" + i.ToString() + " name=\"Rad" + dnopregunta + dnorespuesta + "\" type=\"radio\" class=\"selector-box\" aria-label=\"...\" onchange=\"myFunction(this.value, this.id)\"  required/></h4>");
                        sb.Append("</td>");
                    }
                    sb.Append("<td align=\"center\">");
                    sb.Append("<h4>&nbsp<input id = " + dtipopregunta + dnopregunta + "_" + dnorespuesta + "#0 name=\"Rad" + dnopregunta + dnorespuesta + "\" type=\"radio\"  class=\"selector-box\" aria-label=\"...\" onchange=\"myFunction(this.value, this.id)\" required/></h4>");
                    sb.Append("</td>");
                    break;

                case "Opcio":
                    sb.Append("<tr>");
                    if (!drespabierta)
                    {
                        sb.Append("<td><h4><input id = " + dtipopregunta + dnopregunta + "_" + dnorespuesta + " name=\"Rad" + dnopregunta + "\" type=\"radio\" class=\"selector-box\" onchange=\"myFunction(this.value, this.id)\" required/>&nbsp<span class=\"text\" aria-label=\"...\" >" + drespuesta + "</span></h4></td>");

                    }
                    else
                    {
                        sb.Append("<td><h4><input name=\"Rad" + dnopregunta + "\" type=\"radio\" class=\"selector-box\" required/><span><input id=" + dtipopregunta + dnopregunta + "_" + dnorespuesta + " type=\"text\" onblur=\"myFunction(this.value, this.id)\" onkeypress=\"validar()\" placeholder=\"" + drespuesta + "\" style=\"width: 200px;\" /></span></h4></td>");

                    }
                    sb.Append("<tr><td>&nbsp</td></tr> ");
                    sb.Append("</tr>");
                    break;

                case "Selec":
                    sb.Append("<tr>");
                    if (!drespabierta)
                    {
                        sb.Append("<td><h4><input id=" + dtipopregunta + dnopregunta + "_" + dnorespuesta + "  type=\"checkbox\"  onchange=\"myFunction(this.value, this.id)\"  class=\"selector-box\" />&nbsp<span class=\"text\" >" + drespuesta + "</span></h4></td>");

                    }
                    else
                    {
                        sb.Append("<td><h4><input type=\"checkbox\"  class=\"selector-box\" /><span><input id=" + dtipopregunta + dnopregunta + "_" + dnorespuesta + " type=\"text\" onblur=\"myFunction(this.value, this.id)\" onkeypress=\"validar()\" placeholder=\"" + drespuesta + "\" style=\"width: 200px;\"/></span></td>");

                    }
                    sb.Append("</tr>");
                    sb.Append("<tr><td>&nbsp</td></tr> ");
                    break;
            }

            if (dtipopregunta == "Calif" && int.Parse(dnorespuesta) == maximo)
                sb.Append("</tr></table></div>");

            if (int.Parse(dnorespuesta) == maximo)
                sb.Append("<tr><td>&nbsp</td></tr> ");

            return sb.ToString();


        }


    }
}