//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Warenbestand_Fahrradladen
{
    using System;
    using System.Collections.Generic;
    
    public partial class log
    {
        public int ID_LogNr { get; set; }
        public Nullable<int> hinzufügen { get; set; }
        public Nullable<int> entfernen { get; set; }
        public Nullable<System.DateTime> Datum { get; set; }
        public Nullable<int> fk_WarenID { get; set; }
        public Nullable<int> fk_NutzerId { get; set; }
    
        public virtual Benutzer Benutzer { get; set; }
        public virtual Ware Ware { get; set; }
    }
}