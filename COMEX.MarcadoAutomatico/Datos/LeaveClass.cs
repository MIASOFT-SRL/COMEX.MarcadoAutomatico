//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace COMEX.MarcadoAutomatico.Datos
{
    using System;
    using System.Collections.Generic;
    
    public partial class LeaveClass
    {
        public int LeaveId { get; set; }
        public string LeaveName { get; set; }
        public double MinUnit { get; set; }
        public short Unit { get; set; }
        public short RemaindProc { get; set; }
        public short RemaindCount { get; set; }
        public string ReportSymbol { get; set; }
        public double Deduct { get; set; }
        public int Color { get; set; }
        public short Classify { get; set; }
    }
}
