using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cuestionario.DataAccesComponent;

namespace Cuestionario.BusinessRuleComponent
{
    public class Preguntas
    {

        #region vars&const
        private string _errorMessage;
        #endregion

        public DataTable getTipoPreguntas()
        {
            DataAccess dao = new DataAccess();
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            ds = dao.ExecuteDataSet("uSP_TipoDeclaracionConsulta");
            if (ds.Tables.Count > 0)
                dt = ds.Tables[0];

            return dt;
        }

        public bool agregaPregunta(int DeclaracionID, string Nombre, string Usuario, DateTime Periodo)
        {
            bool returnValue = false;

            DataAccess dao = new DataAccess();
            SqlParameter[] parameters = new SqlParameter[4];
            parameters[0] = new SqlParameter("@DeclaracionID", DeclaracionID);
            parameters[1] = new SqlParameter("@Nombre", Nombre);
            parameters[2] = new SqlParameter("@Usuario", Usuario);
            parameters[3] = new SqlParameter("@Periodo", Periodo);

            dao.ExecuteNonQuery("uSP_InsertaConceptoDeclaracion", parameters);
            try
            {
                returnValue = true;

            }
            catch (Exception error)
            {
                _errorMessage = error.Message;
                returnValue = false;

            }
            return returnValue;

        }

        public bool eliminaPregunta(int DeclaracionID, int ConceptoID)
        {
            bool returnValue = false;

            DataAccess dao = new DataAccess();
            SqlParameter[] parameters = new SqlParameter[2];
            parameters[0] = new SqlParameter("@DeclaracionID", DeclaracionID);
            parameters[1] = new SqlParameter("@ConceptoID", ConceptoID);
            dao.ExecuteNonQuery("uSP_EliminaConceptoDeclaracion", parameters);
            try
            {
                returnValue = true;

            }
            catch (Exception error)
            {
                _errorMessage = error.Message;
                returnValue = false;

            }
            return returnValue;

        }

    }
}
