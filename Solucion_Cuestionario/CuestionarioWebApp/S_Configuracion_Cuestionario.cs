//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CuestionarioWebApp
{
    using System;
    using System.Collections.Generic;
    
    public partial class S_Configuracion_Cuestionario
    {
        public long Corporativo { get; set; }
        public string Hotel { get; set; }
        public string Tipo_Cuestionario { get; set; }
        public string Email_Saliente { get; set; }
        public string Servidor_SMTP { get; set; }
        public string Usuario_SMTP { get; set; }
        public string Contrasena_SMTP { get; set; }
        public long Puerto_SMTP { get; set; }
        public string Texto_Superior { get; set; }
        public string Texto_Superior_Ingles { get; set; }
    
        public virtual C_Tipos_Cuestionario C_Tipos_Cuestionario { get; set; }
        public virtual S_Hoteles S_Hoteles { get; set; }
    }
}
