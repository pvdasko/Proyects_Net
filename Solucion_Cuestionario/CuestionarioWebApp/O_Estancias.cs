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
    
    public partial class O_Estancias
    {
        public long Corporativo { get; set; }
        public string Hotel { get; set; }
        public string Id { get; set; }
        public long Linea { get; set; }
        public string Habitacion { get; set; }
        public int Cuartos { get; set; }
        public Nullable<System.DateTime> Llegada { get; set; }
        public long Noches { get; set; }
        public Nullable<System.DateTime> Salida { get; set; }
        public int Adultos { get; set; }
        public int Ninos { get; set; }
        public int Juniors { get; set; }
        public Nullable<System.DateTime> Llegada_Original { get; set; }
        public Nullable<System.DateTime> Salida_Original { get; set; }
        public Nullable<System.TimeSpan> Hora_Entrada { get; set; }
        public Nullable<System.TimeSpan> Hora_Salida { get; set; }
        public string Up_Down_Grade { get; set; }
        public string Codigo_Tarifa { get; set; }
        public decimal Tarifa { get; set; }
        public string Divisa { get; set; }
        public string Tipo_Tarifa { get; set; }
    
        public virtual O_Huespedes O_Huespedes { get; set; }
        public virtual S_Hoteles S_Hoteles { get; set; }
    }
}
