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
    
    public partial class NUM_RUN_DEIL
    {
        public short NUM_RUNID { get; set; }
        public System.DateTime STARTTIME { get; set; }
        public Nullable<System.DateTime> ENDTIME { get; set; }
        public short SDAYS { get; set; }
        public Nullable<short> EDAYS { get; set; }
        public Nullable<int> SCHCLASSID { get; set; }
        public Nullable<int> OverTime { get; set; }
    }
}
