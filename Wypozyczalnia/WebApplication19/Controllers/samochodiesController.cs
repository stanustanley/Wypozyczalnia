using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using WebApplication19.Models;
using WebApplication19.Linq;
using Microsoft.AspNet.Identity;
using WebApplication19.ViewModel;

namespace WebApplication19.Controllers
{
    public class samochodiesController : Controller
    {
        private WypozyczalniaEntities db = new WypozyczalniaEntities();

        projektDataContext pdc = new projektDataContext();
        private DateTime dzisiaj = DateTime.Today;

        [HttpGet]
        [Authorize(Users = "prac0@mobilek.pl,prac1@mobilek.pl,prac2@mobilek.pl,prac3@mobilek.pl,prac4@mobilek.pl,prac5@mobilek.pl,prac6@mobilek.pl,prac7@mobilek.pl,prac8@mobilek.pl,prac9@mobilek.pl,prac10@mobilek.pl")]
        public ActionResult StrefaPracownika()
        {
            return View();
        }

        [HttpGet]
        [Authorize(Users = "prac0@mobilek.pl,prac1@mobilek.pl,prac2@mobilek.pl,prac3@mobilek.pl,prac4@mobilek.pl,prac5@mobilek.pl,prac6@mobilek.pl,prac7@mobilek.pl,prac8@mobilek.pl,prac9@mobilek.pl,prac10@mobilek.pl")]
        public ActionResult WyszukajSamochod_prac()
        {
            return View();
        }
        [Authorize(Users = "prac0@mobilek.pl,prac1@mobilek.pl,prac2@mobilek.pl,prac3@mobilek.pl,prac4@mobilek.pl,prac5@mobilek.pl,prac6@mobilek.pl,prac7@mobilek.pl,prac8@mobilek.pl,prac9@mobilek.pl,prac10@mobilek.pl")]
        [HttpPost]
        public ActionResult WyszukajSamochod_prac(int? i, string typ)
        {

            {


                if (typ == "wszystkie")
                {
                    if (i == null) { i = 999999; }
                    var samochody_db = db.samochody.ToList();
                    //Func<Models.cena_wynajmu, bool> warunek = d => d.koniec_obowiazywania_ceny >= DateTime.Now && d.poczatek_obowiazywania_ceny <= DateTime.Now;

                    var samochod_dobra_data = samochody_db
                        .Where(x => x.cena_wynajmu
                        //.Where(warunek)
                        .FirstOrDefault() != null && (x.deleted == 0 &&
                        x.cena_wynajmu.FirstOrDefault(y => y.samochody_id_samochodu == x.id_samochodu).cena_wynajmu1 < i))
                        .Select(x => new samochody
                        {
                            dane_samochodu = x.dane_samochodu,
                            deleted = x.deleted,
                            id_samochodu = x.id_samochodu,
                            nazwa_samochodu = x.nazwa_samochodu,
                            wypozyczenia = x.wypozyczenia,
                            cena_wynajmu = x.cena_wynajmu/*.Where(warunek)*/.ToList()
                        })
                        .ToList();


                    var samochody = samochod_dobra_data
                        .Select(
                        x => new Samochod_Dane_Cena(
                        x.dane_samochodu.FirstOrDefault().marka,
                        x.cena_wynajmu.FirstOrDefault().cena_wynajmu1,
                        x.id_samochodu,
                        x.cena_wynajmu.FirstOrDefault().koniec_obowiazywania_ceny,
                        x.dane_samochodu.FirstOrDefault().kolor,
                        x.dane_samochodu.FirstOrDefault().poj_silnika,
                        x.dane_samochodu.FirstOrDefault().przebieg,
                        x.dane_samochodu.FirstOrDefault().typ,
                        x.dane_samochodu.FirstOrDefault().rok_produkcji,
                        x.nazwa_samochodu,
                        x.deleted,
                        x.dane_samochodu.FirstOrDefault().dane_samochodu1
                        )).ToList();
                    return View("WidokPracownika_Wszystkie", samochody);
                }

                else
                {

                    if (i == null) { i = 999999; }
                    var samochody_db = db.samochody.ToList();
                    //Func<Models.cena_wynajmu, bool> warunek = d => d.koniec_obowiazywania_ceny >= DateTime.Now && d.poczatek_obowiazywania_ceny <= DateTime.Now;

                    var samochod_dobra_data = samochody_db
                        .Where(x => x.cena_wynajmu
                        //.Where(warunek)
                        .FirstOrDefault() != null && (x.deleted == 0 &&
                        x.cena_wynajmu.FirstOrDefault(y => y.samochody_id_samochodu == x.id_samochodu).cena_wynajmu1 < i) &&
                        x.dane_samochodu.FirstOrDefault(y => y.id_samochodu == x.id_samochodu).typ == typ)
                        .Select(x => new samochody
                        {
                            dane_samochodu = x.dane_samochodu,
                            deleted = x.deleted,
                            id_samochodu = x.id_samochodu,
                            nazwa_samochodu = x.nazwa_samochodu,
                            wypozyczenia = x.wypozyczenia,
                            cena_wynajmu = x.cena_wynajmu/*.Where(warunek)*/.ToList()
                        })
                        .ToList();


                    var samochody = samochod_dobra_data
                        .Select(
                        x => new Samochod_Dane_Cena(
                        x.dane_samochodu.FirstOrDefault().marka,
                        x.cena_wynajmu.FirstOrDefault().cena_wynajmu1,
                        x.id_samochodu,
                        x.cena_wynajmu.FirstOrDefault().koniec_obowiazywania_ceny,
                        x.dane_samochodu.FirstOrDefault().kolor,
                        x.dane_samochodu.FirstOrDefault().poj_silnika,
                        x.dane_samochodu.FirstOrDefault().przebieg,
                        x.dane_samochodu.FirstOrDefault().typ,
                        x.dane_samochodu.FirstOrDefault().rok_produkcji,
                        x.nazwa_samochodu,
                        x.deleted,
                        x.dane_samochodu.FirstOrDefault().dane_samochodu1
                        )).ToList();
                    return View("WidokPracownika_Wszystkie", samochody);
                }
            }
        }

        [Authorize(Users = "prac0@mobilek.pl,prac1@mobilek.pl,prac2@mobilek.pl,prac3@mobilek.pl,prac4@mobilek.pl,prac5@mobilek.pl,prac6@mobilek.pl,prac7@mobilek.pl,prac8@mobilek.pl,prac9@mobilek.pl,prac10@mobilek.pl")]
        public ActionResult WidokPracownika_AktualnaCena()
        {
            var samochody_db = db.samochody.ToList();
            Func<Models.cena_wynajmu, bool> warunek = d => d.koniec_obowiazywania_ceny >= DateTime.Now && d.poczatek_obowiazywania_ceny <= DateTime.Now;

            var samochod_dobra_data = samochody_db
                .Where(x => x.cena_wynajmu
                    .Where(warunek)
                .FirstOrDefault() != null && (x.deleted == 0 || x.deleted == 2))               
                .Select(x => new samochody
                {
                    dane_samochodu = x.dane_samochodu,
                    deleted = x.deleted,
                    id_samochodu = x.id_samochodu,
                    nazwa_samochodu = x.nazwa_samochodu,
                    wypozyczenia = x.wypozyczenia,
                    cena_wynajmu = x.cena_wynajmu.Where(warunek).ToList()
                })
                .ToList();            
                

            var samochody = samochod_dobra_data
                .Select(
                x => new Samochod_Dane_Cena(
                x.dane_samochodu.FirstOrDefault().marka,
                x.cena_wynajmu.FirstOrDefault().cena_wynajmu1,
                x.id_samochodu,
                x.cena_wynajmu.FirstOrDefault().koniec_obowiazywania_ceny,
                x.dane_samochodu.FirstOrDefault().kolor,
                x.dane_samochodu.FirstOrDefault().poj_silnika,
                x.dane_samochodu.FirstOrDefault().przebieg,
                x.dane_samochodu.FirstOrDefault().typ,
                x.dane_samochodu.FirstOrDefault().rok_produkcji,
                x.nazwa_samochodu,
                x.deleted,
                x.dane_samochodu.FirstOrDefault().dane_samochodu1
                )).ToList();
            return View(samochody);
        }

        [Authorize(Users = "prac0@mobilek.pl,prac1@mobilek.pl,prac2@mobilek.pl,prac3@mobilek.pl,prac4@mobilek.pl,prac5@mobilek.pl,prac6@mobilek.pl,prac7@mobilek.pl,prac8@mobilek.pl,prac9@mobilek.pl,prac10@mobilek.pl")]
        public ActionResult WidokPracownika_Wszystkie()
        {

            var samochody = db.samochody.ToList()
                .Where(x => x.deleted == 0 || x.deleted == 2)               
                .Select(
                x => new Samochod_Dane_Cena(
                x.dane_samochodu.FirstOrDefault(y => y.id_samochodu == x.id_samochodu).marka,
                x.cena_wynajmu.FirstOrDefault().cena_wynajmu1,
                x.id_samochodu,
                x.cena_wynajmu.FirstOrDefault(y=>y.samochody_id_samochodu == x.id_samochodu).koniec_obowiazywania_ceny,
                x.dane_samochodu.FirstOrDefault(y => y.id_samochodu == x.id_samochodu).kolor,
                x.dane_samochodu.FirstOrDefault(y => y.id_samochodu == x.id_samochodu).poj_silnika,
                x.dane_samochodu.FirstOrDefault(y => y.id_samochodu == x.id_samochodu).przebieg,
                x.dane_samochodu.FirstOrDefault(y => y.id_samochodu == x.id_samochodu).typ,
                x.dane_samochodu.FirstOrDefault(y => y.id_samochodu == x.id_samochodu).rok_produkcji,
                x.nazwa_samochodu,
                x.deleted,
                x.dane_samochodu.FirstOrDefault(y => y.id_samochodu == x.id_samochodu).dane_samochodu1
                )).ToList();
            return View(samochody);

        }
        public ActionResult WidokKlienta()
        {
            var samochody_db = db.samochody.ToList();
            Func<Models.cena_wynajmu, bool> warunek = d => d.koniec_obowiazywania_ceny >= DateTime.Now && d.poczatek_obowiazywania_ceny <= DateTime.Now;

            var samochod_dobra_data = samochody_db
                .Where(x => x.cena_wynajmu
                    .Where(warunek)
                .FirstOrDefault() != null && x.deleted == 0)
                .Select(x => new samochody
                {
                    dane_samochodu = x.dane_samochodu,
                    deleted = x.deleted,
                    id_samochodu = x.id_samochodu,
                    nazwa_samochodu = x.nazwa_samochodu,
                    wypozyczenia = x.wypozyczenia,
                    cena_wynajmu = x.cena_wynajmu.Where(warunek).ToList()
                })
                .ToList();


            var samochody = samochod_dobra_data
                .Select(
                x => new Samochod_Dane_Cena(
                x.dane_samochodu.FirstOrDefault().marka,
                x.cena_wynajmu.FirstOrDefault().cena_wynajmu1,
                x.id_samochodu,
                x.cena_wynajmu.FirstOrDefault().koniec_obowiazywania_ceny,
                x.dane_samochodu.FirstOrDefault().kolor,
                x.dane_samochodu.FirstOrDefault().poj_silnika,
                x.dane_samochodu.FirstOrDefault().przebieg,
                x.dane_samochodu.FirstOrDefault().typ,
                x.dane_samochodu.FirstOrDefault().rok_produkcji,
                x.nazwa_samochodu,
                x.deleted,
                x.dane_samochodu.FirstOrDefault(y => y.id_samochodu == x.id_samochodu).dane_samochodu1
                )).ToList();
            return View(samochody);

        }
        [HttpGet]
        [AllowAnonymous]
        public ActionResult WyszukajSamochod_klient()
        {
            return View();
        }

        [Authorize]
        public ActionResult Zlecenie_wypozyczenia(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Models.samochody samochod =  db.samochody.FirstOrDefault(x => x.id_samochodu == id);
            if (samochod == null)
            {
                return HttpNotFound();
            }
            var wypozyczenie = samochod.wypozyczenia.FirstOrDefault(x => x.id_samochodu == samochod.id_samochodu);
            var SamochodWypozyczenie = new EdycjaStan() { Samochod = samochod, Wypozyczenie = wypozyczenie };
            return View(SamochodWypozyczenie);
        }


        [Authorize]
        [HttpPost, ActionName("Zlecenie_wypozyczenia")]
        [ValidateAntiForgeryToken]
        public ActionResult Zlecenie_wypozyczenia(EdycjaStan samochod_wypozyczenie, DateTime data1, DateTime data2)
        {
            
            if (ModelState.IsValid)
            {
                string uzytkownik = User.Identity.GetUserName();
                Models.wypozyczenia wypozyczenie_temp = new Models.wypozyczenia();
                Models.samochody samochod_temp = db.samochody.FirstOrDefault(x => x.id_samochodu == samochod_wypozyczenie.Samochod.id_samochodu);
                Models.klient klient = db.klient.FirstOrDefault(x => x.uzytkownicy.nazwa_uzytkownika == uzytkownik) ;
                wypozyczenie_temp.klient = klient;
                wypozyczenie_temp.id_pracownika = 2;
                wypozyczenie_temp.samochody = samochod_temp;
                wypozyczenie_temp.data_wypozyczenia = DateTime.Today;
                wypozyczenie_temp.stan_wypozyczenia = 1;
                wypozyczenie_temp.data_wypozyczenia = data1;
                wypozyczenie_temp.data_oddania = data2;



                db.Entry(wypozyczenie_temp).State = EntityState.Added;


                db.SaveChanges();
                return RedirectToAction("WidokKlienta");
            }

                return RedirectToAction("WidokKlienta");
            
        }
        [Authorize(Users = "prac0@mobilek.pl,prac1@mobilek.pl,prac2@mobilek.pl,prac3@mobilek.pl,prac4@mobilek.pl,prac5@mobilek.pl,prac6@mobilek.pl,prac7@mobilek.pl,prac8@mobilek.pl,prac9@mobilek.pl,prac10@mobilek.pl")]
        public ActionResult ZleconeWypozyczenia()
        {

            var wypozyczenia_db = db.wypozyczenia.ToList()
                .Where(x => x.id_pracownika == 2)
                .Select(

                x => new Zlecenie_wyp(
                x.data_wypozyczenia,
                x.data_oddania,
                x.pracownik.imie,
                x.pracownik.nazwisko,
                x.klient.imie,
                x.klient.nazwisko,
                x.klient.telefon,
                x.samochody.nazwa_samochodu,
                x.samochody.cena_wynajmu.FirstOrDefault(y => y.samochody_id_samochodu == x.samochody.id_samochodu).cena_wynajmu1 * (x.data_oddania.Day - x.data_wypozyczenia.Day),
                x.id_wypozyczenia
                )).ToList();
            return View(wypozyczenia_db);
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult WyszukajSamochod_klient(int? i, string typ)
        {


            if (typ == "wszystkie")
            {
                if (i == null) { i = 999999; }
                var samochody_db = db.samochody.ToList();
                Func<Models.cena_wynajmu, bool> warunek = d => d.koniec_obowiazywania_ceny >= DateTime.Now && d.poczatek_obowiazywania_ceny <= DateTime.Now;

                var samochod_dobra_data = samochody_db
                    .Where(x => x.cena_wynajmu
                        .Where(warunek)
                    .FirstOrDefault() != null && (x.deleted == 0 &&
                    x.cena_wynajmu.FirstOrDefault(y => y.samochody_id_samochodu == x.id_samochodu).cena_wynajmu1 < i))
                    .Select(x => new samochody
                    {
                        dane_samochodu = x.dane_samochodu,
                        deleted = x.deleted,
                        id_samochodu = x.id_samochodu,
                        nazwa_samochodu = x.nazwa_samochodu,
                        wypozyczenia = x.wypozyczenia,
                        cena_wynajmu = x.cena_wynajmu.Where(warunek).ToList()
                    })
                    .ToList();


                var samochody = samochod_dobra_data
                    .Select(
                    x => new Samochod_Dane_Cena(
                    x.dane_samochodu.FirstOrDefault().marka,
                    x.cena_wynajmu.FirstOrDefault().cena_wynajmu1,
                    x.id_samochodu,
                    x.cena_wynajmu.FirstOrDefault().koniec_obowiazywania_ceny,
                    x.dane_samochodu.FirstOrDefault().kolor,
                    x.dane_samochodu.FirstOrDefault().poj_silnika,
                    x.dane_samochodu.FirstOrDefault().przebieg,
                    x.dane_samochodu.FirstOrDefault().typ,
                    x.dane_samochodu.FirstOrDefault().rok_produkcji,
                    x.nazwa_samochodu,
                    x.deleted,
                    x.dane_samochodu.FirstOrDefault().dane_samochodu1
                    )).ToList();
                return View("WidokKlienta", samochody);
            }

            else
            {

                if (i == null) { i = 999999; }
                var samochody_db = db.samochody.ToList();
                Func<Models.cena_wynajmu, bool> warunek = d => d.koniec_obowiazywania_ceny >= DateTime.Now && d.poczatek_obowiazywania_ceny <= DateTime.Now;

                var samochod_dobra_data = samochody_db
                    .Where(x => x.cena_wynajmu
                        .Where(warunek)
                    .FirstOrDefault() != null && (x.deleted == 0 &&
                    x.cena_wynajmu.FirstOrDefault(y => y.samochody_id_samochodu == x.id_samochodu).cena_wynajmu1 < i) &&
                    x.dane_samochodu.FirstOrDefault(y => y.id_samochodu == x.id_samochodu).typ == typ)
                    .Select(x => new samochody
                    {
                        dane_samochodu = x.dane_samochodu,
                        deleted = x.deleted,
                        id_samochodu = x.id_samochodu,
                        nazwa_samochodu = x.nazwa_samochodu,
                        wypozyczenia = x.wypozyczenia,
                        cena_wynajmu = x.cena_wynajmu.Where(warunek).ToList()
                    })
                    .ToList();


                var samochody = samochod_dobra_data
                    .Select(
                    x => new Samochod_Dane_Cena(
                    x.dane_samochodu.FirstOrDefault().marka,
                    x.cena_wynajmu.FirstOrDefault().cena_wynajmu1,
                    x.id_samochodu,
                    x.cena_wynajmu.FirstOrDefault().koniec_obowiazywania_ceny,
                    x.dane_samochodu.FirstOrDefault().kolor,
                    x.dane_samochodu.FirstOrDefault().poj_silnika,
                    x.dane_samochodu.FirstOrDefault().przebieg,
                    x.dane_samochodu.FirstOrDefault().typ,
                    x.dane_samochodu.FirstOrDefault().rok_produkcji,
                    x.nazwa_samochodu,
                    x.deleted,
                    x.dane_samochodu.FirstOrDefault().dane_samochodu1
                    )).ToList();
                return View("WidokKlienta", samochody);
            }
        }

        [Authorize(Users = "prac0@mobilek.pl,prac1@mobilek.pl,prac2@mobilek.pl,prac3@mobilek.pl,prac4@mobilek.pl,prac5@mobilek.pl,prac6@mobilek.pl,prac7@mobilek.pl,prac8@mobilek.pl,prac9@mobilek.pl,prac10@mobilek.pl")]
        public ActionResult Create()
        {

               return View();
        }


        [Authorize(Users = "prac0@mobilek.pl,prac1@mobilek.pl,prac2@mobilek.pl,prac3@mobilek.pl,prac4@mobilek.pl,prac5@mobilek.pl,prac6@mobilek.pl,prac7@mobilek.pl,prac8@mobilek.pl,prac9@mobilek.pl,prac10@mobilek.pl")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( SamochodDaneCena samochod_dane_cena)
        {

                WebApplication19.Models.samochody samochod1 = new samochody();
                samochod1.dane_samochodu.Add(samochod_dane_cena.Dane);
                samochod1.cena_wynajmu.Add(samochod_dane_cena.Cena);
                samochod1.deleted = 0;                
                samochod1.nazwa_samochodu = samochod_dane_cena.Samochod.nazwa_samochodu;
                samochod1.cena_wynajmu.FirstOrDefault().samochody = samochod1;
                
                db.Entry(samochod1).State = EntityState.Added;

                db.SaveChanges();
                return RedirectToAction("WidokPracownika_Wszystkie");
            

        }

        [Authorize(Users = "prac0@mobilek.pl,prac1@mobilek.pl,prac2@mobilek.pl,prac3@mobilek.pl,prac4@mobilek.pl,prac5@mobilek.pl,prac6@mobilek.pl,prac7@mobilek.pl,prac8@mobilek.pl,prac9@mobilek.pl,prac10@mobilek.pl")]
        public ActionResult DodajCene()
        {
            ViewBag.samochody_id_samochodu = new SelectList(db.samochody, "id_samochodu", "nazwa_samochodu");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DodajCene([Bind(Include = "id_cena_wynajmu,cena_wynajmu1,poczatek_obowiazywania_ceny,koniec_obowiazywania_ceny,samochody_id_samochodu")] Models.cena_wynajmu model, int id)
        {
            {
                Models.cena_wynajmu cena_temp = new Models.cena_wynajmu();
                cena_temp.cena_wynajmu1 = model.cena_wynajmu1;
                cena_temp.poczatek_obowiazywania_ceny = model.poczatek_obowiazywania_ceny;
                cena_temp.samochody_id_samochodu = id;
                cena_temp.koniec_obowiazywania_ceny = model.koniec_obowiazywania_ceny;
                db.Entry(cena_temp).State = EntityState.Added;
                db.SaveChanges();
                return RedirectToAction("WidokPracownika_Wszystkie");
            }


        }

        [Authorize(Users = "prac0@mobilek.pl,prac1@mobilek.pl,prac2@mobilek.pl,prac3@mobilek.pl,prac4@mobilek.pl,prac5@mobilek.pl,prac6@mobilek.pl,prac7@mobilek.pl,prac8@mobilek.pl,prac9@mobilek.pl,prac10@mobilek.pl")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Models.samochody samochod = db.samochody.FirstOrDefault(x => x.id_samochodu == id);
            if (samochod == null)
            {
                return HttpNotFound();
            }
            var dane_samochodu = samochod.dane_samochodu.FirstOrDefault(x => x.id_samochodu == samochod.id_samochodu);
            var cena_wynajmu = samochod.cena_wynajmu.FirstOrDefault(x => x.samochody_id_samochodu == samochod.id_samochodu);
            var dane_samochod_cena = new SamochodDaneCena() { Samochod = samochod, Dane = dane_samochodu, Cena = cena_wynajmu };
            return View(dane_samochod_cena);
        }

        [Authorize(Users = "prac0@mobilek.pl,prac1@mobilek.pl,prac2@mobilek.pl,prac3@mobilek.pl,prac4@mobilek.pl,prac5@mobilek.pl,prac6@mobilek.pl,prac7@mobilek.pl,prac8@mobilek.pl,prac9@mobilek.pl,prac10@mobilek.pl")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( SamochodDaneCena dane_samochod_cena)
        {
            if (ModelState.IsValid)
            {
                var samochod1 = db.samochody.FirstOrDefault(x => x.id_samochodu == dane_samochod_cena.Samochod.id_samochodu);
                var dane1 = samochod1.dane_samochodu.FirstOrDefault(x => x.id_samochodu == dane_samochod_cena.Dane.id_samochodu);
                var cena1 = db.cena_wynajmu.FirstOrDefault(x => x.id_cena_wynajmu == dane_samochod_cena.Cena.id_cena_wynajmu);

                dane1.kolor = dane_samochod_cena.Dane.kolor;
                dane1.przebieg = dane_samochod_cena.Dane.przebieg;
                dane1.poj_silnika = dane_samochod_cena.Dane.poj_silnika;
                cena1.cena_wynajmu1 = dane_samochod_cena.Cena.cena_wynajmu1;
                samochod1.deleted = dane_samochod_cena.Samochod.deleted;
                dane1.dane_samochodu1 = dane_samochod_cena.Dane.dane_samochodu1;
                db.Entry(samochod1).State = EntityState.Modified;
                db.Entry(dane1).State = EntityState.Modified;
                db.Entry(cena1).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("WidokPracownika_AktualnaCena");
            }
            Models.samochody samochod = db.samochody.FirstOrDefault(x => x.id_samochodu == dane_samochod_cena.Samochod.id_samochodu);
            var dane_samochodu = samochod.dane_samochodu.FirstOrDefault(x => x.id_samochodu == samochod.id_samochodu);
            var cena_wynajmu = samochod.cena_wynajmu.FirstOrDefault(x => x.samochody_id_samochodu == samochod.id_samochodu);

            var dane_samochod_cena_do_edycji = new SamochodDaneCena() { Samochod = samochod, Dane = dane_samochodu, Cena=cena_wynajmu };
            return View(dane_samochod_cena_do_edycji);
        }

        // GET: samochodies/Delete/5
        [Authorize(Users = "prac0@mobilek.pl,prac1@mobilek.pl,prac2@mobilek.pl,prac3@mobilek.pl,prac4@mobilek.pl,prac5@mobilek.pl,prac6@mobilek.pl,prac7@mobilek.pl,prac8@mobilek.pl,prac9@mobilek.pl,prac10@mobilek.pl")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Models.samochody samochod = db.samochody.FirstOrDefault(x => x.id_samochodu == id);
            if (samochod == null)
            {
                return HttpNotFound();
            }
            var dane_samochodu = samochod.dane_samochodu.FirstOrDefault(x => x.id_samochodu == samochod.id_samochodu);
            var cena_wynajmu = samochod.cena_wynajmu.FirstOrDefault(x => x.samochody_id_samochodu == samochod.id_samochodu);
            var dane_samochod_cena = new SamochodDaneCena() { Samochod = samochod, Dane = dane_samochodu, Cena = cena_wynajmu };
            return View(dane_samochod_cena);
        }

        // POST: samochodies/Delete/5
        [Authorize(Users = "prac0@mobilek.pl,prac1@mobilek.pl,prac2@mobilek.pl,prac3@mobilek.pl,prac4@mobilek.pl,prac5@mobilek.pl,prac6@mobilek.pl,prac7@mobilek.pl,prac8@mobilek.pl,prac9@mobilek.pl,prac10@mobilek.pl")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed( SamochodDaneCena dane_samochod_cena)
        {
            if (ModelState.IsValid)
            {
                var samochod1 = db.samochody.FirstOrDefault(x => x.id_samochodu == dane_samochod_cena.Samochod.id_samochodu);

                samochod1.deleted = 1;

                db.Entry(samochod1).State = EntityState.Modified;

                db.SaveChanges();
                return RedirectToAction("WidokPracownika_Wszystkie");
            }
            Models.samochody samochod = db.samochody.FirstOrDefault(x => x.id_samochodu == dane_samochod_cena.Samochod.id_samochodu);
            var dane_samochodu = samochod.dane_samochodu.FirstOrDefault(x => x.id_samochodu == samochod.id_samochodu);
            var cena_wynajmu = samochod.cena_wynajmu.FirstOrDefault(x => x.samochody_id_samochodu == samochod.id_samochodu);

            var dane_samochod_cena_do_edycji = new SamochodDaneCena() { Samochod = samochod, Dane = dane_samochodu, Cena = cena_wynajmu };
            return View(dane_samochod_cena_do_edycji);
        }

        [Authorize(Users = "prac0@mobilek.pl,prac1@mobilek.pl,prac2@mobilek.pl,prac3@mobilek.pl,prac4@mobilek.pl,prac5@mobilek.pl,prac6@mobilek.pl,prac7@mobilek.pl,prac8@mobilek.pl,prac9@mobilek.pl,prac10@mobilek.pl")]
        public ActionResult WypozyczoneSamochody()
        {
            var wypozyczenia_db = db.wypozyczenia.ToList()
                .Where(x => x.stan_wypozyczenia == 2)
                .Select(
                x => new Zlecenie_wyp(
                x.data_wypozyczenia,
                x.data_oddania,
                x.pracownik.imie,
                x.pracownik.nazwisko,
                x.klient.imie,
                x.klient.nazwisko,
                x.klient.telefon,
                x.samochody.nazwa_samochodu,
                x.samochody.cena_wynajmu.FirstOrDefault(y => y.samochody_id_samochodu == x.samochody.id_samochodu).cena_wynajmu1 * (x.data_oddania.Day - x.data_wypozyczenia.Day),
                x.id_wypozyczenia
                )).ToList();
            return View(wypozyczenia_db);
        }

        [Authorize(Users = "prac0@mobilek.pl,prac1@mobilek.pl,prac2@mobilek.pl,prac3@mobilek.pl,prac4@mobilek.pl,prac5@mobilek.pl,prac6@mobilek.pl,prac7@mobilek.pl,prac8@mobilek.pl,prac9@mobilek.pl,prac10@mobilek.pl")]
        public ActionResult PotwierdzeniePrzywrocenia()
        {
            return View();
        }

        [Authorize(Users = "prac0@mobilek.pl,prac1@mobilek.pl,prac2@mobilek.pl,prac3@mobilek.pl,prac4@mobilek.pl,prac5@mobilek.pl,prac6@mobilek.pl,prac7@mobilek.pl,prac8@mobilek.pl,prac9@mobilek.pl,prac10@mobilek.pl")]
        [HttpPost, ActionName("PotwierdzeniePrzywrocenia")]
        [ValidateAntiForgeryToken]
        public ActionResult PotwierdzeniePrzywrocenia(int id)
        {

            if (ModelState.IsValid)
            {
                string uzytkownik = User.Identity.GetUserName();
                Models.wypozyczenia wypozyczenie_temp = db.wypozyczenia.FirstOrDefault(x => x.id_wypozyczenia == id);

                Models.pracownik pracownik = db.pracownik.FirstOrDefault(x => x.uzytkownicy.nazwa_uzytkownika == uzytkownik);
                wypozyczenie_temp.id_pracownika = pracownik.id_pracownika;
                wypozyczenie_temp.stan_wypozyczenia = 0;
                wypozyczenie_temp.samochody.deleted = 0;
                db.Entry(wypozyczenie_temp).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("WypozyczoneSamochody");
            }

            return RedirectToAction("WypozyczoneSamochody");

        }

        [Authorize(Users = "prac0@mobilek.pl,prac1@mobilek.pl,prac2@mobilek.pl,prac3@mobilek.pl,prac4@mobilek.pl,prac5@mobilek.pl,prac6@mobilek.pl,prac7@mobilek.pl,prac8@mobilek.pl,prac9@mobilek.pl,prac10@mobilek.pl")]
        public ActionResult Potwierdzenie_wyp()
        {
            return View();
        }

        [Authorize(Users = "prac0@mobilek.pl,prac1@mobilek.pl,prac2@mobilek.pl,prac3@mobilek.pl,prac4@mobilek.pl,prac5@mobilek.pl,prac6@mobilek.pl,prac7@mobilek.pl,prac8@mobilek.pl,prac9@mobilek.pl,prac10@mobilek.pl")]
        [HttpPost, ActionName("Potwierdzenie_wyp")]
        [ValidateAntiForgeryToken]
        public ActionResult Potwierdzenie_wyp(int id)
        {

            if (ModelState.IsValid)
            {
                string uzytkownik = User.Identity.GetUserName();
                Models.wypozyczenia wypozyczenie_temp = db.wypozyczenia.FirstOrDefault(x => x.id_wypozyczenia == id);

                Models.pracownik pracownik = db.pracownik.FirstOrDefault(x => x.uzytkownicy.nazwa_uzytkownika == uzytkownik);
                wypozyczenie_temp.id_pracownika = pracownik.id_pracownika;
                wypozyczenie_temp.stan_wypozyczenia = 2;
                wypozyczenie_temp.samochody.deleted = 2;
                db.Entry(wypozyczenie_temp).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ZleconeWypozyczenia");
            }

            return RedirectToAction("ZleconeWypozyczenia");

        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
