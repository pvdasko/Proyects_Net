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
    
    public partial class S_Correos_Cuestionario
    {
        public long Corporativo { get; set; }
        public string Hotel { get; set; }
        public string Tipo_Cuestionario { get; set; }
        public string Email { get; set; }
        public string Descripcion { get; set; }
    
        public virtual C_Tipos_Cuestionario C_Tipos_Cuestionario { get; set; }
        public virtual S_Hoteles S_Hoteles { get; set; }
    }
}
