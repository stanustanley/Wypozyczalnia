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
    
    public partial class pracownik
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public pracownik()
        {
            this.wypozyczenia = new HashSet<wypozyczenia>();
        }
    
        public int id_pracownika { get; set; }
        public string imie { get; set; }
        public string nazwisko { get; set; }
        public string kod_miasta { get; set; }
        public string miasto { get; set; }
        public string ulica { get; set; }
        public int uzytkownicy_id_uzytkownika { get; set; }
    
        public virtual uzytkownicy uzytkownicy { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<wypozyczenia> wypozyczenia { get; set; }
    }
}
