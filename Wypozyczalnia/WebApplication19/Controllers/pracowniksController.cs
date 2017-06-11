using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication19.Models;

namespace WebApplication19.Controllers
{
    public class pracowniksController : Controller
    {
        private WypozyczalniaEntities db = new WypozyczalniaEntities();

        // GET: pracowniks
        public ActionResult Index()
        {
            var pracownik = db.pracownik.Include(p => p.uzytkownicy);
            return View(pracownik.ToList());
        }

        // GET: pracowniks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pracownik pracownik = db.pracownik.Find(id);
            if (pracownik == null)
            {
                return HttpNotFound();
            }
            return View(pracownik);
        }

        // GET: pracowniks/Create
        public ActionResult Create()
        {
            ViewBag.uzytkownicy_id_uzytkownika = new SelectList(db.uzytkownicy, "id_uzytkownika", "nazwa_uzytkownika");
            return View();
        }

        // POST: pracowniks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_pracownika,imie,nazwisko,kod_miasta,miasto,ulica,uzytkownicy_id_uzytkownika")] pracownik pracownik)
        {
            if (ModelState.IsValid)
            {
                db.pracownik.Add(pracownik);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.uzytkownicy_id_uzytkownika = new SelectList(db.uzytkownicy, "id_uzytkownika", "nazwa_uzytkownika", pracownik.uzytkownicy_id_uzytkownika);
            return View(pracownik);
        }

        // GET: pracowniks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pracownik pracownik = db.pracownik.Find(id);
            if (pracownik == null)
            {
                return HttpNotFound();
            }
            ViewBag.uzytkownicy_id_uzytkownika = new SelectList(db.uzytkownicy, "id_uzytkownika", "nazwa_uzytkownika", pracownik.uzytkownicy_id_uzytkownika);
            return View(pracownik);
        }

        // POST: pracowniks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_pracownika,imie,nazwisko,kod_miasta,miasto,ulica,uzytkownicy_id_uzytkownika")] pracownik pracownik)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pracownik).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.uzytkownicy_id_uzytkownika = new SelectList(db.uzytkownicy, "id_uzytkownika", "nazwa_uzytkownika", pracownik.uzytkownicy_id_uzytkownika);
            return View(pracownik);
        }

        // GET: pracowniks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pracownik pracownik = db.pracownik.Find(id);
            if (pracownik == null)
            {
                return HttpNotFound();
            }
            return View(pracownik);
        }

        // POST: pracowniks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            pracownik pracownik = db.pracownik.Find(id);
            db.pracownik.Remove(pracownik);
            db.SaveChanges();
            return RedirectToAction("Index");
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
