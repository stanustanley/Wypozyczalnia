using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication19.ViewModel
{
    public class Zlecenie_wyp
    { 
     public DateTime Data_wyp { get; set; }
    public DateTime Data_odd { get; set; }
    public string Imie_prac { get; set; }
    public string Nazw_prac { get; set; }
    public string Imie_klienta { get; set; }
    public string Nazw_klienta { get; set; }
    public string Telefon_klienta { get; set; }
    public string Nazwa_sam { get; set; }
    public decimal Cena { get; set; }
        public int Id_wyp { get; set; }

    public Zlecenie_wyp(DateTime Data_wyp, DateTime Data_odd, string Imie_prac, string Nazw_prac, string Imie_klienta, string Nazw_klienta, string Telefon_klienta, string Nazwa_sam, decimal Cena, int Id_wyp)
    {
            this.Data_wyp = Data_wyp;
            this.Data_odd = Data_odd;
            this.Imie_prac = Imie_prac;
            this.Nazw_prac = Nazw_prac;
            this.Imie_klienta = Imie_klienta;
            this.Nazw_klienta = Nazw_klienta;
            this.Telefon_klienta = Telefon_klienta;
            this.Nazwa_sam = Nazwa_sam;
            this.Cena = Cena;
            this.Id_wyp = Id_wyp;
    }
}
}