//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication10.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Rezervari
    {
        public int Id { get; set; }
        public string Nume { get; set; }
        public string Prenume { get; set; }
        public Nullable<int> Telefon { get; set; }
        public string Oras { get; set; }
        public string Strada { get; set; }
        public Nullable<int> NrTrotinete { get; set; }
        public Nullable<int> NrOre { get; set; }
        public Nullable<System.DateTime> DataRezervare { get; set; }
    }
}
