﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WeatherStack.Client.Views.Home
{
    public class TempController : Controller
    {
        // GET: TempController
        public ActionResult Index()
        {
            return View();
        }

        // GET: TempController/Details/5
        public ActionResult DetailsByCity(string city)
        {
            return View();
        }
        public ActionResult DetailsByZip(string zip)
        {
            return View();
        }

        // GET: TempController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TempController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TempController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TempController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TempController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TempController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
