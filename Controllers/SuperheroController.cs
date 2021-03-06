﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Superhero.Data;
using Superhero.Models;

namespace Superhero.Controllers
{
    public class SuperheroController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SuperheroController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CRUD
        public ActionResult Index()
        {
            return View(_context.Superheroes.ToList());
        }

        // GET: CRUD/Details/5
        public ActionResult Details(int id)
        {
            
            return View(_context.Superheroes.Find(id));
        }

        // GET: CRUD/Create
        public ActionResult Create()
        {
            SuperheroModel superhero = new SuperheroModel();
            return View(superhero);
        }

        // POST: CRUD/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SuperheroModel superhero)
        {
            if (ModelState.IsValid)
            {
                _context.Superheroes.Add(superhero);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(superhero);
            }
        }

        // GET: CRUD/Edit/5
        public ActionResult Edit(int id)
        {
            var superhero = _context.Superheroes.Find(id);
            return View(superhero);            
        }

        // POST: CRUD/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SuperheroModel superhero)
        {
            if (ModelState.IsValid)
            {
                var newHero = _context.Superheroes.Where(a => a.Id == superhero.Id).SingleOrDefault();
                newHero.Name = superhero.Name;
                newHero.AlterEgo = superhero.AlterEgo;
                newHero.PrimaryAbility = superhero.PrimaryAbility;
                newHero.SecondaryAbility = superhero.SecondaryAbility;
                newHero.CatchPrase = superhero.CatchPrase;
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View();
            }
        }

        // GET: CRUD/Delete/5
        public ActionResult Delete(int id)
        {
            var superhero = _context.Superheroes.Find(id);
            return View(superhero);
        }

        // POST: CRUD/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(SuperheroModel superhero)
        {
            if (ModelState.IsValid)
            {
                _context.Superheroes.Remove(superhero);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(superhero);
            }
        }
    }
}