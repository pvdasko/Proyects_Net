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
    public class Cuestionario
    {

         #region vars&const
            private PagosProvisionalesDataContext dac;
            private string _errorMessage;
            decimal tax_a;
            decimal liminf_a;
            decimal exce_a;
            decimal porc_a;
            decimal marg_a;
            decimal fixb_a;
            decimal income_a;
            decimal taxrate_a;

            decimal Total_a ;
            int     Dias_a ;
            decimal Porcion_a ;
            decimal Acumulado_a;
            decimal SeccionI_a ;
            decimal FraccionII_a ;
            decimal FraccionIII_a;
            decimal TotalBase_a;
            decimal ISR15_a ;
            decimal ISR30_a ;
            decimal TotalISR_a;

        #endregion

            private DataSet dsDetalleDeclaracion;
            public DataSet _dsDetalleDeclaracion
            {
                get { return dsDetalleDeclaracion; }
                set { dsDetalleDeclaracion = value; }
            }
        public Declaracion()
        {
            dac = new PagosProvisionalesDataContext();  
        }
        public List<tblTipoDeclaracion> TipoDeclaracionConsulta()
        {
            List<tblTipoDeclaracion> resultado = new List<tblTipoDeclaracion>();

            var res = from TD in dac.tblTipoDeclaracions
                                   select TD;

            foreach (var elemento in res)
            {
                tblTipoDeclaracion tipoDeclaracion = new tblTipoDeclaracion();
                tipoDeclaracion.Nombre = elemento.Nombre;
                tipoDeclaracion.PK_TipoDeclaracionID = elemento.PK_TipoDeclaracionID;
                resultado.Add(tipoDeclaracion);
            }

            return resultado;
          
        }

        public bool  InsertaContribuyenteDeclaracion(string Nombre, string ApellidoP, string ApellidoM, string Empresa, 
                                                     string EmpleadoIDCadena, string RFC,  DateTime Periodo, int TipoDeclaracionId, 
                                                    int TipoGrossUpID, int MonedaID, int TipoNominaID, string Usuario, int EmpleadoID )
        {
            bool returnValue = false;
            try
            {
                //declara tablas de linq
                tblContribuyente contribuyente = new tblContribuyente();
                tblDeclaracion declaracion = new tblDeclaracion();
                tblEmpleadoDeclaracion empladodeclaracion = new tblEmpleadoDeclaracion();
                
                // asigna valores a los campos de la tabla
                contribuyente.Nombre = Nombre;
                contribuyente.ApellidoPaterno = ApellidoP;
                contribuyente.ApellidoMaterno = ApellidoM;
                contribuyente.Empresa = Empresa;
                contribuyente.EmpleadoID = EmpleadoIDCadena;
                contribuyente.RFC = RFC; 
                contribuyente.UltimaModificacion = DateTime.Now; 
                contribuyente.Usuario = Usuario; 
                
                // inserta registos en la tabla de contribuyentes
                dac.tblContribuyentes.InsertOnSubmit(contribuyente);

                //asigna los valores a la tabla
                declaracion.tblContribuyente = contribuyente;
                declaracion.Periodo = Periodo;
                declaracion.FK_TipoDeclaracionID = TipoDeclaracionId;
                declaracion.FK_TipoGrossupID = TipoGrossUpID;
                declaracion.FK_MonedaID = MonedaID;
                declaracion.FK_TipoNominaID = TipoNominaID;
                declaracion.UltimaModificacion = DateTime.Now;
                declaracion.Usuario = Usuario; 
 
                //inserta registo en la tabla de declaracion
                dac.tblDeclaracions.InsertOnSubmit(declaracion);

                //asigna los valores de tabla empleadodeclaracion
                empladodeclaracion.FK_EmpleadoID = EmpleadoID;
                empladodeclaracion.tblDeclaracion = declaracion;
                empladodeclaracion.UltimaModificacion = DateTime.Now;
                
                //inserta registro en la tabla de empleadodeclaracion
                dac.tblEmpleadoDeclaracions.InsertOnSubmit(empladodeclaracion);  
                
                dac.SubmitChanges();               
                returnValue = true;                
                
            }
            catch (Exception error) 
            {
                _errorMessage = error.Message;
                returnValue = false ;
            }

            return returnValue;

        }

        public bool  InsertaDeclaracion (  int ContribuyenteID, DateTime  Periodo, int TipoDeclaracionId, int TipoGrossUpID,
            int MonedaID, int TipoNominaID, string Usuario, int EmpleadoID)
        {
            bool returnValue = false;      
            
            try
            {
                tblDeclaracion declaracion = new tblDeclaracion();
                tblEmpleadoDeclaracion empladodeclaracion = new tblEmpleadoDeclaracion();               

                //asigna los valores a la tabla
                declaracion.FK_ContribuyenteID = ContribuyenteID;
                declaracion.Periodo = Periodo;
                declaracion.FK_TipoDeclaracionID = TipoDeclaracionId;
                declaracion.FK_TipoGrossupID = TipoGrossUpID;
                declaracion.FK_MonedaID = MonedaID;
                declaracion.FK_TipoNominaID  = TipoNominaID;
                declaracion.UltimaModificacion = DateTime.Now ;  
                declaracion.Usuario = Usuario; 

                //inserta registo en la tabla de declaracion
                dac.tblDeclaracions.InsertOnSubmit(declaracion);

                //asigna los valores de tabla empleadodeclaracion
                empladodeclaracion.FK_EmpleadoID = EmpleadoID;
                empladodeclaracion.tblDeclaracion = declaracion;
                empladodeclaracion.UltimaModificacion = DateTime.Now ;

                //insert los valores en la tabla empleadodeclaracion
                dac.tblEmpleadoDeclaracions.InsertOnSubmit(empladodeclaracion);             
                                  
                dac.SubmitChanges();                              
                returnValue = true;
               
            }
            catch (Exception error)
            {
                _errorMessage = error.Message;
                returnValue = false;
            }
            return returnValue;
        }
        
        public bool insertaConceptos(int DeclaracionID, int ConceptoId, string ConceptoNombre, string Usuario)
        {
            bool returnValue = false;
                       
            tblConcepto  conceptodeclaracion = new tblConcepto  ();                                                  

            try 
            {
                //asigna los valores de la tabla concepto
                conceptodeclaracion.FK_DeclaracionID = DeclaracionID;    
                conceptodeclaracion.FK_CatalogoConceptoID  = ConceptoId;
                conceptodeclaracion.Nombre = ConceptoNombre;
                conceptodeclaracion.UltimaModificacion = DateTime.Now;
                conceptodeclaracion.Usuario = Usuario;
                //inserta registro en la tabla de concepto
                dac.tblConceptos.InsertOnSubmit(conceptodeclaracion);
                dac.SubmitChanges();
                    
                returnValue = true;

            }
            catch  (Exception error) 
            {
                _errorMessage = error.Message;
                returnValue = false ;
                
            }

            return returnValue;
        }

        public bool UpdateContribuyenteDeclaracion(string Nombre, string ApellidoP, string ApellidoM, string Empresa,
                                                    string EmpleadoIDCadena, string RFC, DateTime Periodo, int TipoDeclaracionId, 
                                                    int TipoGrossUpID, int MonedaID, int TipoNominaID, string Usuario, int contribuyenteID, int declaracionID)
        {
            bool returnValue = false;
            try
            {
                //declara tablas de linq
                //tblContribuyente contribuyente = new tblContribuyente();
                //tblDeclaracion declaracion = new tblDeclaracion();
                var contribuyente = (from c in dac.GetTable <tblContribuyente>()
                                     where c.PK_PersonaID == contribuyenteID
                                     select c).SingleOrDefault();

                               
                // asigna valores a los campos de la tabla                
                contribuyente.Nombre = Nombre;
                contribuyente.ApellidoPaterno = ApellidoP;
                contribuyente.ApellidoMaterno = ApellidoM;
                contribuyente.Empresa = Empresa;
                contribuyente.EmpleadoID = EmpleadoIDCadena;
                contribuyente.RFC = RFC;
                contribuyente.UltimaModificacion = DateTime.Now;
                contribuyente.Usuario = Usuario;

                var declaracion = (from d in dac.GetTable<tblDeclaracion>()
                                   where d.PK_DeclaracionID == declaracionID
                                   select d).SingleOrDefault();
              
                //asigna los valores a la tabla                                
                declaracion.Periodo = Periodo;
                declaracion.FK_TipoDeclaracionID = TipoDeclaracionId;
                declaracion.FK_TipoGrossupID = TipoGrossUpID;
                declaracion.FK_MonedaID = MonedaID;
                declaracion.FK_TipoNominaID = TipoNominaID;
                declaracion.UltimaModificacion = DateTime.Now;
                declaracion.Usuario = Usuario;
                               
                dac.SubmitChanges();
                returnValue = true;

            }
            catch (Exception error)
            {
                _errorMessage = error.Message;
                returnValue = false;
            }

            return returnValue;

        }

        public DataTable  getDeclaracionesEmpleado( string paramUsuario, int paramAccesTypeID)
        {
            DataAccess dao = new DataAccess ();
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            SqlParameter[] parameters = new SqlParameter[2];
            parameters[0] = new SqlParameter("@Usuario", paramUsuario);
            parameters[1] = new SqlParameter("@AccesTypeID", paramAccesTypeID);
            ds = dao.ExecuteDataSet("uSP_EmpleadoDeclaraciones", parameters);
            if (ds.Tables.Count > 0)
                dt = ds.Tables[0];

            return dt;
        }

        public DataTable getBuscaDeclaracion(int? paramDeclaracionID, int paramAccessTypeID)
        {

            DataAccess dao = new DataAccess();
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("@DeclaracionID", paramDeclaracionID);            
            ds = dao.ExecuteDataSet("uSP_BuscaDeclaracion", parameters);
            if (ds.Tables.Count > 0)
                dt = ds.Tables[0];

            return dt;
        }

        public DataTable getBuscaDeclaracion(string paramDeclaracionID)
        {

            DataAccess dao = new DataAccess();
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("@Cadena", paramDeclaracionID);           
            ds = dao.ExecuteDataSet("uSP_BuscaDeclaracionCadena", parameters);
            if (ds.Tables.Count > 0)
                dt = ds.Tables[0];
            return dt;
        }
        
        public DataTable getDeclaracionID(string paramUsuario)
        {
            DataAccess dao = new DataAccess();
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("@usuario", paramUsuario);
            ds = dao.ExecuteDataSet("uSP_DeclaracionID", parameters);
            if (ds.Tables.Count > 0)
                dt = ds.Tables[0];

            return dt;
        }

        public DataTable getCargaDeclaracionID(int? paramDeclaracionID)
        {
            DataAccess dao = new DataAccess();
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("@DeclaracionID", paramDeclaracionID);
            ds = dao.ExecuteDataSet("uSP_DeclaracionIncialConsulta", parameters);
            if (ds.Tables.Count > 0)
                dt = ds.Tables[0];

            return dt;
        }
                
        public DataTable getGeneralesDeclaracion(int DeclaracionID)
        {
            DataAccess dao = new DataAccess();
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("@DeclaracionId", DeclaracionID);
            ds = dao.ExecuteDataSet("uSP_GeneralesDeclaracion", parameters);
            if (ds.Tables.Count > 0)
                dt = ds.Tables[0];

            return dt;
        }
        
        public DataTable getCalculoImpuesto(int paramDeclaracionID)
        {
            DatosAdoNet convertidorAdoNet = new DatosAdoNet();
            DataAccess dao = new DataAccess();
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            DataTable dtCalculo = new DataTable();
            int i;
            string[] concepto = new string[12];
            decimal[] tax = new decimal[12];
            decimal[] liminf = new decimal[12];
            decimal[] exce = new decimal[12];
            decimal[] porc = new decimal[12];
            decimal[] marg = new decimal[12];
            decimal[] fixb = new decimal[12];
            decimal[] income = new decimal[12];
            decimal[] taxrate = new decimal[12];

            dtCalculo.Columns.Add("Concepto", typeof(string));
            dtCalculo.Columns.Add("Anual", typeof(string));
            dtCalculo.Columns.Add("Mes1", typeof(string));
            dtCalculo.Columns.Add("Mes2", typeof(string));
            dtCalculo.Columns.Add("Mes3", typeof(string));
            dtCalculo.Columns.Add("Mes4", typeof(string));
            dtCalculo.Columns.Add("Mes5", typeof(string));
            dtCalculo.Columns.Add("Mes6", typeof(string));
            dtCalculo.Columns.Add("Mes7", typeof(string));
            dtCalculo.Columns.Add("Mes8", typeof(string));
            dtCalculo.Columns.Add("Mes9", typeof(string));
            dtCalculo.Columns.Add("Mes10", typeof(string));
            dtCalculo.Columns.Add("Mes11", typeof(string));
            dtCalculo.Columns.Add("Mes12", typeof(string));

            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("@DeclaracionID", paramDeclaracionID);
            ds = dao.ExecuteDataSet("uSP_ProcesaDeclaracion", parameters);
            if (ds.Tables.Count > 0)
                dt = ds.Tables[0];

            i=0;           
            
            foreach (DataRow row in dt.Rows )
            {
                tax[i]    = convertidorAdoNet.validaDecimal (dt.Rows[i]["Total"]) ;
                tax_a += tax[i];
                liminf[i] = convertidorAdoNet.validaDecimal (dt.Rows[i]["LimiteInferior"]);
                liminf_a += liminf[i];
                exce[i]   = convertidorAdoNet.validaDecimal (dt.Rows[i]["ExcedenteLimiteInferior"]);
                exce_a += exce[i];
                porc[i]   = convertidorAdoNet.validaDecimal (dt.Rows[i]["Porcentaje"]);
                porc_a += porc[i];
                marg[i]   = convertidorAdoNet.validaDecimal (dt.Rows[i]["ImpuestoMarginal"]);
                marg_a += marg[i];
                fixb[i]   = convertidorAdoNet.validaDecimal (dt.Rows[i]["Cuotafija"]);
                fixb_a += fixb[i];
                income [i]= convertidorAdoNet.validaDecimal (dt.Rows [i]["Impuesto"]); 
                income_a += income [i];
                if (tax[i] == 0 || income[i] == 0)
                {
                    taxrate[i] = 0;
                }
                else
                {
                    taxrate[i] = income[i] / tax[i];
 
                }
                taxrate_a += taxrate[i];
                i++;
            }

            dtCalculo.Rows.Add("Taxable income", tax_a.ToString ("0,0.00"), tax[0].ToString ("0,0.00"), tax[1].ToString ("0,0.00"), tax[2].ToString ("0,0.00"), tax[3].ToString ("0,0.00"), tax[4].ToString ("0,0.00"), tax[5].ToString ("0,0.00"), tax[6].ToString ("0,0.00"), tax[7].ToString ("0,0.00"), tax[8].ToString ("0,0.00"), tax[9].ToString ("0,0.00"), tax[10].ToString ("0,0.00"), tax[11].ToString ("0,0.00"));
            dtCalculo.Rows.Add("minus:", "", "", "", "", "", "", "", "", "", "", "", "", "");
            dtCalculo.Rows.Add("Inferior Limit per Art. 113", liminf_a , liminf[0], liminf[1], liminf[2], liminf[3], liminf[4], liminf[5], liminf[6], liminf[7], liminf[8], liminf[9], liminf[10], liminf[11]);
            dtCalculo.Rows.Add("Excedent on Inferior Limit", exce_a.ToString("0,0.00"), exce[0].ToString("0,0.00"), exce[1].ToString("0,0.00"), exce[2].ToString("0,0.00"), exce[3].ToString("0,0.00"), exce[4].ToString("0,0.00"), exce[5].ToString("0,0.00"), exce[6].ToString("0,0.00"), exce[7].ToString("0,0.00"), exce[8].ToString("0,0.00"), exce[9].ToString("0,0.00"), exce[10].ToString("0,0.00"), exce[11].ToString("0,0.00"));
            dtCalculo.Rows.Add("times:","", "", "", "", "", "", "", "", "", "", "", "", "");
            dtCalculo.Rows.Add("% Aplicable on Exedent", porc_a.ToString("00.00%"), porc[0].ToString("00.00%"), porc[1].ToString("00.00%"), porc[2].ToString("00.00%"), porc[3].ToString("00.00%"), porc[4].ToString("00.00%"), porc[5].ToString("00.00%"), porc[6].ToString("00.00%"), porc[7].ToString("00.00%"), porc[8].ToString("00.00%"), porc[9].ToString("00.00%"), porc[10].ToString("00.00%"), porc[11].ToString("00.00%"));
            dtCalculo.Rows.Add("Marginal Tax", marg_a.ToString("0,0.00"), marg[0].ToString("0,0.00"), marg[1].ToString("0,0.00"), marg[2].ToString("0,0.00"), marg[3].ToString("0,0.00"), marg[4].ToString("0,0.00"), marg[5].ToString("0,0.00"), marg[6].ToString("0,0.00"), marg[7].ToString("0,0.00"), marg[8].ToString("0,0.00"), marg[9].ToString("0,0.00"), marg[10].ToString("0,0.00"), marg[11].ToString("0,0.00"));
            dtCalculo.Rows.Add("plus:", "", "", "", "", "", "", "", "", "", "", "", "", "");
            dtCalculo.Rows.Add("Fixed base", fixb_a, fixb[0], fixb[1], fixb[2], fixb[3], fixb[4], fixb[5], fixb[6], fixb[7], fixb[8], fixb[9], fixb[10], fixb[11]);
            dtCalculo.Rows.Add("Income Tax  per Article 113", income_a.ToString("0,0.00"), income[0].ToString("0,0.00"), income[1].ToString("0,0.00"), income[2].ToString("0,0.00"), income[3].ToString("0,0.00"), income[4].ToString("0,0.00"), income[5].ToString("0,0.00"), income[6].ToString("0,0.00"), income[7].ToString("0,0.00"), income[8].ToString("0,0.00"), income[9].ToString("0,0.00"), income[10].ToString("0,0.00"), income[11].ToString("0,0.00"));
            dtCalculo.Rows.Add("", "", "", "", "", "", "", "", "", "", "", "", "", "");
            dtCalculo.Rows.Add("EFFECTIVE TAX RATE", taxrate_a.ToString("00.00%"), taxrate[0].ToString("00.00%"), taxrate[1].ToString("00.00%"), taxrate[2].ToString("00.00%"), taxrate[3].ToString("00.00%"), taxrate[4].ToString("00.00%"), taxrate[5].ToString("00.00%"), taxrate[6].ToString("00.00%"), taxrate[7].ToString("00.00%"), taxrate[8].ToString("00.00%"), taxrate[9].ToString("00.00%"), taxrate[10].ToString("00.00%"), taxrate[11].ToString("00.00%"));

            return dtCalculo;

        }

        public DataTable getCalculoImpuestoNoResindente(int paramDeclaracionID)
        {
            DatosAdoNet convertidorAdoNet = new DatosAdoNet();
            DataAccess dao = new DataAccess();
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            DataTable dtCalculo = new DataTable();
            int i;
            string formatS = "0,0.00";
            decimal[] Total = new decimal[12];
            int    [] Dias = new  int [12];
            decimal[] Porcion = new decimal [12];
            decimal[] Acumulado = new decimal[12];
            decimal[] SeccionI = new decimal[12];
            decimal[] FraccionII = new decimal[12];
            decimal[] FraccionIII = new decimal[12];
            decimal[] TotalBase = new decimal[12];
            decimal[] ISR15 = new decimal[12];
            decimal[] ISR30 = new decimal[12];
            decimal[] TotalISR = new decimal[12];

            dtCalculo.Columns.Add("Concepto", typeof(string));           
            dtCalculo.Columns.Add("Mes1", typeof(string));
            dtCalculo.Columns.Add("Mes2", typeof(string));
            dtCalculo.Columns.Add("Mes3", typeof(string));
            dtCalculo.Columns.Add("Mes4", typeof(string));
            dtCalculo.Columns.Add("Mes5", typeof(string));
            dtCalculo.Columns.Add("Mes6", typeof(string));
            dtCalculo.Columns.Add("Mes7", typeof(string));
            dtCalculo.Columns.Add("Mes8", typeof(string));
            dtCalculo.Columns.Add("Mes9", typeof(string));
            dtCalculo.Columns.Add("Mes10", typeof(string));
            dtCalculo.Columns.Add("Mes11", typeof(string));
            dtCalculo.Columns.Add("Mes12", typeof(string));
            dtCalculo.Columns.Add("Anual", typeof(string));

            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("@DeclaracionID", paramDeclaracionID);
            ds = dao.ExecuteDataSet("uSP_ProcesaDeclaracion", parameters);
            if (ds.Tables.Count > 0)
                dt = ds.Tables[0];

            i = 0;

            foreach (DataRow row in dt.Rows)
            {
                Total       [i] = convertidorAdoNet.validaDecimal(dt.Rows[i]["Total"]);
                Total_a += Total[i];
                Dias        [i] = convertidorAdoNet.validaInteger(dt.Rows[i]["DiasTrabajados"]);
                Dias_a += Dias[i];
                Porcion     [i] = convertidorAdoNet.validaDecimal(dt.Rows[i]["Porcion"]);              
                Porcion_a += Porcion [i];
                Acumulado   [i] = convertidorAdoNet.validaDecimal(dt.Rows[i]["Acumulado"]);
                Acumulado_a += Acumulado[i];
                SeccionI    [i] = convertidorAdoNet.validaDecimal(dt.Rows[i]["FraccionI"]);
                SeccionI_a += SeccionI[i];
                FraccionII [i] = convertidorAdoNet.validaDecimal(dt.Rows[i]["FraccionII"]);
                FraccionII_a += FraccionII[i];
                FraccionIII [i] = convertidorAdoNet.validaDecimal(dt.Rows[i]["FraccionIII"]);
                FraccionIII_a += FraccionIII[i];
                TotalBase [i] = convertidorAdoNet.validaDecimal(dt.Rows[i]["TotalBase"]);
                TotalBase_a += TotalBase[i];
                ISR15       [i] = convertidorAdoNet.validaDecimal(dt.Rows[i]["ISR15"]);
                ISR15_a += ISR15[i];
                ISR30       [i] = convertidorAdoNet.validaDecimal(dt.Rows[i]["ISR30"]);
                ISR30_a += ISR30[i];
                TotalISR    [i] = convertidorAdoNet.validaDecimal(dt.Rows[i]["TotalISR"]);
                TotalISR_a += TotalISR[i];                
                i++;
            }

            dtCalculo.Rows.Add("Income", Total[0].ToString(formatS), Total[1].ToString(formatS), Total[2].ToString(formatS), Total[3].ToString(formatS), Total[4].ToString(formatS), Total[5].ToString(formatS), Total[6].ToString(formatS), Total[7].ToString(formatS), Total[8].ToString(formatS), Total[9].ToString(formatS), Total[10].ToString(formatS), Total[11].ToString(formatS), Total_a.ToString(formatS));
            dtCalculo.Rows.Add("Days worked in Mexico", Dias[0].ToString(), Dias[1].ToString(), Dias[2].ToString(), Dias[3].ToString(), Dias[4].ToString(), Dias[5].ToString(), Dias[6].ToString(), Dias[7].ToString(), Dias[8].ToString(), Dias[9].ToString(), Dias[10].ToString(), Dias[11].ToString(), Dias_a.ToString());
            dtCalculo.Rows.Add("TAXABLE INCOME (worked days  portion)", Porcion[0].ToString(formatS), Porcion[1].ToString(formatS), Porcion[2].ToString(formatS), Porcion[3].ToString(formatS), Porcion[4].ToString(formatS), Porcion[5].ToString(formatS), Porcion[6].ToString(formatS), Porcion[7].ToString(formatS), Porcion[8].ToString(formatS), Porcion[9].ToString(formatS), Porcion[10].ToString(formatS), Porcion[11].ToString(formatS), Porcion_a.ToString(formatS));
            dtCalculo.Rows.Add("ACCRUED TAXABLE INCOME MONTHLY", Acumulado[0].ToString(formatS), Acumulado[1].ToString(formatS), Acumulado[2].ToString(formatS), Acumulado[3].ToString(formatS), Acumulado[4].ToString(formatS), Acumulado[5].ToString(formatS), Acumulado[6].ToString(formatS), Acumulado[7].ToString(formatS), Acumulado[8].ToString(formatS), Acumulado[9].ToString(formatS), Acumulado[10].ToString(formatS), Acumulado[11].ToString(formatS), Acumulado_a.ToString(formatS));
            dtCalculo.Rows.Add("", "", "", "", "", "", "", "", "", "", "", "", "", "");          
            dtCalculo.Rows.Add("FRACCION I", SeccionI[0].ToString(formatS), SeccionI[1].ToString(formatS), SeccionI[2].ToString(formatS), SeccionI[3].ToString(formatS), SeccionI[4].ToString(formatS), SeccionI[5].ToString(formatS), SeccionI[6].ToString(formatS), SeccionI[7].ToString(formatS), SeccionI[8].ToString(formatS), SeccionI[9].ToString(formatS), SeccionI[10].ToString(formatS), SeccionI[11].ToString(formatS), SeccionI_a.ToString(formatS));           
            dtCalculo.Rows.Add("FRACTION II", FraccionII[0].ToString(formatS), FraccionII[1].ToString(formatS), FraccionII[2].ToString(formatS), FraccionII[3].ToString(formatS), FraccionII[4].ToString(formatS), FraccionII[5].ToString(formatS), FraccionII[6].ToString(formatS), FraccionII[7].ToString(formatS), FraccionII[8].ToString(formatS), FraccionII[9].ToString(formatS), FraccionII[10].ToString(formatS), FraccionII[11].ToString(formatS), FraccionII_a.ToString(formatS));           
            dtCalculo.Rows.Add("FRACTION III", FraccionIII[0].ToString(formatS), FraccionIII[1].ToString(formatS), FraccionIII[2].ToString(formatS), FraccionIII[3].ToString(formatS), FraccionIII[4].ToString(formatS), FraccionIII[5].ToString(formatS), FraccionIII[6].ToString(formatS), FraccionIII[7].ToString(formatS), FraccionIII[8].ToString(formatS), FraccionIII[9].ToString(formatS), FraccionIII[10].ToString(formatS), FraccionIII[11].ToString(formatS), FraccionIII_a.ToString(formatS));
            dtCalculo.Rows.Add("", "", "", "", "", "", "", "", "", "", "", "", "", "");
            dtCalculo.Rows.Add("Taxable Income at 15%", FraccionII[0].ToString(formatS), FraccionII[1].ToString(formatS), FraccionII[2].ToString(formatS), FraccionII[3].ToString(formatS), FraccionII[4].ToString(formatS), FraccionII[5].ToString(formatS), FraccionII[6].ToString(formatS), FraccionII[7].ToString(formatS), FraccionII[8].ToString(formatS), FraccionII[9].ToString(formatS), FraccionII[10].ToString(formatS), FraccionII[11].ToString(formatS), FraccionII_a.ToString(formatS));
            dtCalculo.Rows.Add("Taxable income at 30%", FraccionIII[0].ToString(formatS), FraccionIII[1].ToString(formatS), FraccionIII[2].ToString(formatS), FraccionIII[3].ToString(formatS), FraccionIII[4].ToString(formatS), FraccionIII[5].ToString(formatS), FraccionIII[6].ToString(formatS), FraccionIII[7].ToString(formatS), FraccionIII[8].ToString(formatS), FraccionIII[9].ToString(formatS), FraccionIII[10].ToString(formatS), FraccionIII[11].ToString(formatS), FraccionIII_a.ToString(formatS));
            dtCalculo.Rows.Add("TOTAL TAXABLE INCOME", TotalBase[0].ToString(formatS), TotalBase[1].ToString(formatS), TotalBase[2].ToString(formatS), TotalBase[3].ToString(formatS), TotalBase[4].ToString(formatS), TotalBase[5].ToString(formatS), TotalBase[6].ToString(formatS), TotalBase[7].ToString(formatS), TotalBase[8].ToString(formatS), TotalBase[9].ToString(formatS), TotalBase[10].ToString(formatS), TotalBase[11].ToString(formatS), TotalBase_a.ToString(formatS));
            dtCalculo.Rows.Add("", "", "", "", "", "", "", "", "", "", "", "", "", "");
            dtCalculo.Rows.Add("Income Tax at 15%", ISR15[0].ToString(formatS), ISR15[1].ToString(formatS), ISR15[2].ToString(formatS), ISR15[3].ToString(formatS), ISR15[4].ToString(formatS), ISR15[5].ToString(formatS), ISR15[6].ToString(formatS), ISR15[7].ToString(formatS), ISR15[8].ToString(formatS), ISR15[9].ToString(formatS), ISR15[10].ToString(formatS), ISR15[11].ToString(formatS), ISR15_a.ToString(formatS));
            dtCalculo.Rows.Add("Income Tax at 30%", ISR30[0].ToString(formatS), ISR30[1].ToString(formatS), ISR30[2].ToString(formatS), ISR30[3].ToString(formatS), ISR30[4].ToString(formatS), ISR30[5].ToString(formatS), ISR30[6].ToString(formatS), ISR30[7].ToString(formatS), ISR30[8].ToString(formatS), ISR30[9].ToString(formatS), ISR30[10].ToString(formatS), ISR30[11].ToString(formatS), ISR30_a.ToString(formatS));
            dtCalculo.Rows.Add("TOTAL PAYABLE INCOME TAX", TotalISR[0].ToString(formatS), TotalISR[1].ToString(formatS), TotalISR[2].ToString(formatS), TotalISR[3].ToString(formatS), TotalISR[4].ToString(formatS), TotalISR[5].ToString(formatS), TotalISR[6].ToString(formatS), TotalISR[7].ToString(formatS), TotalISR[8].ToString(formatS), TotalISR[9].ToString(formatS), TotalISR[10].ToString(formatS), TotalISR[11].ToString(formatS), TotalISR_a.ToString(formatS));

            return dtCalculo;          


        }
      
        public DataSet getDeclaracionIncial(int paramDeclaracionID)
        {
            DataAccess dao = new DataAccess();
            DataSet dset = new DataSet();            
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("@DeclaracionID", paramDeclaracionID);
            dset = dao.ExecuteDataSet("uSP_DeclaracionDetalle", parameters);           
            return dset;

        }

        public DataSet getDeclaracionTotales(int paramDeclaracionID)
        {
            DataAccess dao = new DataAccess();
            DataSet dset = new DataSet();
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("@DeclaracionID", paramDeclaracionID);
            dset = dao.ExecuteDataSet("[uSP_DeclaracionTotalesConsulta]", parameters);
            return dset;
        }
        public Boolean actualizaConceptoValor(int conceptoID, DateTime periodo, Boolean valorPesos, float? valor, string usuario)
        {
            DataAccess dao = new DataAccess();
            SqlParameter[] parameters = new SqlParameter[5];
            parameters[0] = new SqlParameter("@ConceptoID", conceptoID);
            parameters[1] = new SqlParameter("@Periodo", periodo);
            parameters[2] = new SqlParameter("@ValorPesos", valorPesos);
            parameters[3] = new SqlParameter("@Valor", valor);
            parameters[4] = new SqlParameter("@Usuario", usuario);
            DataSet ds = dao.ExecuteDataSet("uSP_ConceptoMontoActualiza", parameters);
            return true;
            
        }
        
       

        public bool DeclaracionConceptosActualiza(int DeclaracionID, DateTime Periodo, int ConceptoID, 
        float MontoExtranjero, string Usuario )
        {
            bool returnValue=false ;

            DataAccess dao = new DataAccess ();
            SqlParameter[] parameters = new SqlParameter[5];
            parameters[0] = new SqlParameter("@DeclaracionId", DeclaracionID );
            parameters[1] = new SqlParameter("@Periodo", Periodo);
            parameters[2] = new SqlParameter("@ConceptoID", ConceptoID);         
            parameters[3] = new SqlParameter("@MontoExtranjero", MontoExtranjero);
            parameters[4] = new SqlParameter("@Usuario", Usuario);
            dao.ExecuteNonQuery("uSP_DeclaracionConceptoActualiza", parameters);             
            try
            {
             returnValue = true;

            }
            catch  (Exception error) 
            {
                _errorMessage = error.Message;
                returnValue = false ;
                
            }
            return returnValue;
        }


        public bool DeclaracionConceptosActualizaPesos(int DeclaracionID, DateTime Periodo, int ConceptoID,
        float MontoPesos, string Usuario)
        {
            bool returnValue = false;

            DataAccess dao = new DataAccess();
            SqlParameter[] parameters = new SqlParameter[5];
            parameters[0] = new SqlParameter("@DeclaracionId", DeclaracionID);
            parameters[1] = new SqlParameter("@Periodo", Periodo);
            parameters[2] = new SqlParameter("@ConceptoID", ConceptoID);
            parameters[3] = new SqlParameter("@MontoPesos", MontoPesos);            
            parameters[4] = new SqlParameter("@Usuario", Usuario);
            dao.ExecuteNonQuery("uSP_DeclaracionConceptoActualizaPesos", parameters);
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

        public bool DeclaracionActualizaTotales(int DeclaracionID)
        {
            bool returnValue = false;
            DataAccess dao = new DataAccess();
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("@DeclaracionId", DeclaracionID);
            dao.ExecuteNonQuery("uSP_ProcesoTotalConcepto", parameters);
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

        public string getDeclaracionNombre(int declaracionID, int accessTypeID)
        {            
            DataAccess dao = new DataAccess();
            SqlParameter[] parameters = new SqlParameter[2];
            parameters[0] = new SqlParameter("@DeclaracionID", declaracionID);
            parameters[1] = new SqlParameter("@AccesTypeId", accessTypeID);
            DataSet ds = dao.ExecuteDataSet("uSP_DeclaracionNombre", parameters);
            if (ds.Tables.Count != 0 && ds.Tables[0].Rows.Count != 0)
                return ds.Tables[0].Rows[0][0].ToString();
            else
                return "No existe informacion";
        }
        public Boolean getDeclaracionDetalleConcepto(int declaracionID, DateTime periodo1, DateTime periodo2)
        {    
                DataAccess dao = new DataAccess();
                SqlParameter[] parameters = new SqlParameter[3];
                parameters[0] = new SqlParameter("@DeclaracionID", declaracionID);
                parameters[1] = new SqlParameter("@Periodo1", periodo1);
                parameters[2] = new SqlParameter("@Periodo2", periodo2);
                this.dsDetalleDeclaracion = dao.ExecuteDataSet("uSP_DeclaracionDetalleConcepto", parameters);
                return true;
        }
        public string construyeRenglon(object datos)
        {
            DataRowView info;
            int fechasExistentes;
            int conceptoID;
            int numeroPeriodos;
            string nombreColumna = "";
            string nombreestiloRenglon = "";
            string nombreEstiloTDElemento = "tdGridConcepto";
            string nombreEstiloConceptoEspecial = "";
            string enPesos = "";
            DateTime fecha;
            string fechaCadena;
            float valor;
            float numeroFloat;
            Boolean permiteEditar;
            DataTable dtDias;
            DataTable dtMeses;
            int conceptoTipo;

            dtDias = this.dsDetalleDeclaracion.Tables[1];
            dtMeses = this.dsDetalleDeclaracion.Tables[2];
            permiteEditar = true;
            StringBuilder sb = new StringBuilder();
            info = (DataRowView) datos;
            fechasExistentes = this.dsDetalleDeclaracion.Tables[1].Rows.Count;

            switch (info["ConceptoID"].ToString())
            {
                case "-1":
                    nombreestiloRenglon = "Renglon_1";
                    permiteEditar = false;
                    break;
                case "-2":
                    nombreestiloRenglon = "Renglon_2";
                    permiteEditar = false;
                    break;
                case "-3":
                    nombreestiloRenglon = "Renglon_1";
                    permiteEditar = false;
                    break;
                case "-4":
                    nombreestiloRenglon = "Renglon_1"; //INgreso en pesos
                    nombreEstiloTDElemento = "tdGridConceptoConColSpan";
                    permiteEditar = false;
                    break;
                case "-5":
                    nombreestiloRenglon = "Renglon_2"; //Sub total en pesos
                    permiteEditar = false;
                    nombreEstiloTDElemento = "tdGridConceptoConColSpan";
                    break;
                case "-6":
                    nombreestiloRenglon = "Renglon_1"; //Gross Up
                    nombreEstiloTDElemento = "tdGridConceptoConColSpan";
                    nombreColumna = "GrossUp";
                    permiteEditar = false;
                    break;
                case "-7":
                    nombreestiloRenglon = "Renglon_3";
                    permiteEditar = false;
                    nombreColumna = "Resultado";
                    break;
                case "-8": //Info en dolares
                    nombreEstiloConceptoEspecial = "ConceptoScript";
                    nombreEstiloTDElemento = "tdGridConceptoInformativo";
                    permiteEditar = false;
                    break;
                case "-9": //Info en pesos
                    nombreEstiloConceptoEspecial = "ConceptoScript";
                    nombreEstiloTDElemento = "tdGridConceptoInformativo";
                    permiteEditar = false;
                    break;
                case "-10": //Ingreso Mensual
                    nombreestiloRenglon = "Renglon_1";
                    nombreEstiloTDElemento = "tdGridConceptoConColSpan";
                    nombreColumna = "IngresoMes";
                    permiteEditar = false;
                    break;
                case "-11": //TC Euros
                    nombreestiloRenglon = "Renglon_2";
                    permiteEditar = false;
                    break;
                default:
                    nombreestiloRenglon = "";
                    break;
            }

            if (!Int32.TryParse(info["ConceptoTipo"].ToString(), out conceptoTipo))
                conceptoTipo = 1;
            switch (conceptoTipo)
            {
                case 2:
                    nombreestiloRenglon = "Renglon_Negativos";
                    break;
                default:
                    break;
            }

            //Agrega la primer columna
            if (nombreestiloRenglon.Length == 0)
                sb.Append("<tr> ");
            else
                sb.Append("<tr class=\"" + nombreestiloRenglon + "\"> ");

            if (nombreEstiloConceptoEspecial == string.Empty)
                sb.Append("<td nowrap style=\"height:10px;\" class=\"tdCampoConceptoNombre\"> ");
            else
                sb.Append("<td nowrap style=\"height:10px;\" class=\"" + nombreEstiloConceptoEspecial + "\"> ");
            sb.Append(info["Nombre"].ToString());
            sb.Append("</td> ");

            //Agrega las columnas con informacion
            switch (info["ConceptoID"].ToString())
            {
                case "-10": //Totales por periodo
                case "-6":
                case "-7":
                    for (int indice = 1; indice <= dtMeses.Rows.Count; indice++)
                    {
                        if (!float.TryParse(dtMeses.Rows[indice - 1][nombreColumna].ToString(), out valor))
                            valor = 0;
                        if (!Int32.TryParse(dtMeses.Rows[indice - 1]["NumPeriodo"].ToString(), out numeroPeriodos))
                            numeroPeriodos = 1;
                        sb.Append("<td align=\"right\" colspan=\"" + numeroPeriodos.ToString() + "\" class=\"" + nombreEstiloTDElemento + "\"> ");
                        sb.Append("<span class=\"gridConcepto\">" + valor.ToString("C") + "</span>");
                        sb.Append("</td> ");
                    }
                        break;
                default:
                    for (int indice = 1; indice <= fechasExistentes; indice++)
                    {
                        nombreColumna = (indice < 10) ? "P0" + indice.ToString() : "P" + indice.ToString();
                        if (!Int32.TryParse(info["ConceptoID"].ToString(), out conceptoID))
                            return "ERROR";
                        if (!DateTime.TryParse(dtDias.Rows[indice - 1]["Periodo"].ToString(), out fecha))
                            return "ERROR Al convertir la fecha";
                        enPesos = info["Pesos"].ToString();
                        fechaCadena = fecha.Year.ToString() + "-" + fecha.Month.ToString() + "-" + fecha.Day.ToString();
                        sb.Append("<td align=\"right\"  class=\"" + nombreEstiloTDElemento + "\"> ");
                        if (permiteEditar)
                        {
                            if (!float.TryParse(info[nombreColumna].ToString(), out numeroFloat))
                                numeroFloat = 0;
                            sb.Append("<input type=\"text\" value=\"" + numeroFloat.ToString("N") + "\" size=\"9\" class=\"gridConceptoParaEditar\"/ parametroPesos=\"" + enPesos + "\" parametroFecha=\"" + fechaCadena + "\" parametroConceptoID=\"" + conceptoID.ToString() + "\" onchange=\"CambioTexto(this)\">");
                        }
                        else
                        {
                            if (!float.TryParse(info[nombreColumna].ToString(), out valor))
                                valor = 0;
                            if (info[nombreColumna].ToString() == string.Empty)
                            {
                                if (nombreEstiloConceptoEspecial == string.Empty)
                                {
                                    valor = 0;

                                    sb.Append("<span class=\"gridConcepto\">" + valor.ToString("C") + "</span>");
                                }
                                else
                                    sb.Append("<span class=\"gridConcepto\">&nbsp;</span>");
                            }
                            else
                            {
                                switch (info["ConceptoID"].ToString())
                                {
                                    case "-2": //Tipo de Cambio
                                        sb.Append("<span class=\"gridConcepto\">" + valor.ToString("#.0000") + "</span>");
                                        break;
                                    case "-11": //Tipo de Cambio Euros
                                        sb.Append("<span class=\"gridConcepto\">" + valor.ToString("#.0000") + "</span>");
                                        break;
                                    default:
                                        sb.Append("<span class=\"gridConcepto\">" + valor.ToString("C") + "</span>");
                                        break;
                                }
                            }
                        }
                        sb.Append("</td> ");
                    }
                    break;
            }
            sb.Append("</tr> ");
            sb.Append(" ");
            sb.Append(" ");
            sb.Append(" ");
        
            return sb.ToString();
        }
        public string construyeEncabezado()
        {
            DateTime periodo;
            int numeroPeriodos;
            int numeroFechas;
            DataTable dtPeriodos;
            DataTable dtDias;
            StringBuilder sb = new StringBuilder();

            dtPeriodos = this.dsDetalleDeclaracion.Tables[2];
            dtDias = this.dsDetalleDeclaracion.Tables[1];
            numeroFechas = dtDias.Rows.Count;

            //Para establecer los anchos de las columnas
            sb.Append("<thead> ");
            sb.Append("<tr> ");
            sb.Append("<td class=\"HeaderColumnaConcepto\"></td> ");

            for (int i = 1; i <= numeroFechas; i ++)
            {
                sb.Append("<td class=\"HeaderColumnaCantidad\"></td> ");
            }
            sb.Append("</tr> ");
            sb.Append("</thead> ");
            
            sb.Append("<tr> ");
            //Columna Concepto
            sb.Append("<td align=\"center\" rowspan=\"2\" class=\"TDEncabezadoGrid\"> ");
            sb.Append("Concept");
            sb.Append("</td> ");
            sb.Append(" ");

            
            //Por cada Periodo agrego la columna con el nombre del mes
            foreach (DataRow elemento in dtPeriodos.Rows)
            {
                if (!DateTime.TryParse(elemento["Periodo"].ToString(), out periodo))
                    return "Error";
                if (!Int32.TryParse(elemento["NumPeriodo"].ToString(), out numeroPeriodos))
                    return "Error";
                sb.Append("<td align=\"center\"  colspan=\"" + numeroPeriodos.ToString() + "\" class=\"TDEncabezadoGrid\"> ");
                sb.Append(periodo.ToString("MMMM yyyy").ToUpper());
                sb.Append("</td> ");
            }
               //<td colspan="2">
               //         Enero 2009
               //     </td>         
            sb.Append("</tr> ");

            //Por cada día agrego el numero
            sb.Append("<tr> ");
            //Columna Concepto
            foreach (DataRow elemento in dtDias.Rows)
            {
                if (!DateTime.TryParse(elemento["Periodo"].ToString(), out periodo))
                    return "Error";
                sb.Append("<td align=\"center\" class=\"TDEncabezadoGrid\"> ");
                sb.Append(periodo.Day.ToString());
                sb.Append("</td> ");
            }
            sb.Append("</td> ");   
            return sb.ToString();
        }

    }
}
