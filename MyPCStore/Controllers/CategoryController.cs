﻿using Microsoft.AspNetCore.Mvc;
using MyPCStore.Data;
using MyPCStore.Models;
using System.Collections.Generic;

namespace MyPCStore.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Category> objList = _db.Category;

            return View(objList);
        }

        //GET - CREATE
        public IActionResult Create()
        {
            return View();
        }

        //POST - CREATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            _db.Category.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
