//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication19.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class dane_samochodu
    {
        public int id_danych_samochodu { get; set; }
        public string marka { get; set; }
        public string typ { get; set; }
        public System.DateTime rok_produkcji { get; set; }
        public string kolor { get; set; }
        public string poj_silnika { get; set; }
        public string przebieg { get; set; }
        public string dane_samochodu1 { get; set; }
        public int id_samochodu { get; set; }
    
        public virtual samochody samochody { get; set; }
    }
}