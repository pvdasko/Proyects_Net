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
    
    public partial class O_Respuestas_Cuestionario_Huespedes
    {
        public long Corporativo { get; set; }
        public string Hotel { get; set; }
        public string Tipo_Cuestionario { get; set; }
        public int No_Pregunta { get; set; }
        public string Id { get; set; }
        public int No_Respuesta { get; set; }
        public int Calificacion { get; set; }
        public string Texto { get; set; }
    
        public virtual C_Respuestas_Cuestionario C_Respuestas_Cuestionario { get; set; }
        public virtual O_Huespedes O_Huespedes { get; set; }
        public virtual S_Hoteles S_Hoteles { get; set; }
    }
}
