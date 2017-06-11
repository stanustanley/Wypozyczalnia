using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication19.ViewModel
{
    public class Samochod_Dane_Cena
    {
        public string marka { get; set; }
        // public string model { get; set; }
        public decimal cena { get; set; }
        public string pojemnosc { get; set; }
        public string kolor { get; set; }
        public string przebieg { get; set; }
        public DateTime rok_produkcji { get; set; }
        public string typ { get; set; }

        public int id { get; set; }

        public DateTime koniec_ceny { get; set; }

        public string nazwa_samochodu { get; set; }

        public int? deleted { get; set; }
        public string dane { get; set; }
        public Samochod_Dane_Cena(string marka, decimal cena, int id, DateTime koniec_ceny, string kolor, string pojemnosc, string przebieg, string typ, DateTime rok_produkcji, string nazwa, int? deleted, string dane)
        {
            this.marka = marka;
            this.cena = cena;
            this.id = id;
            this.koniec_ceny = koniec_ceny;
            this.kolor = kolor;
            this.pojemnosc = pojemnosc;
            this.przebieg = przebieg;
            this.typ = typ;
            this.rok_produkcji = rok_produkcji;
            this.nazwa_samochodu = nazwa;
            this.deleted = deleted;
            this.dane = dane;
        }
    }
}

