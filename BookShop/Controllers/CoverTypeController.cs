using BookShop.Heplers;
using BookShop.Models;
using BookShop.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookShop.Controllers
{
    [Authorize(Roles = "SuperAdmin, Admin")]
    public class CoverTypeController : Controller
    {
        private readonly ICoverAndTypeService _coverAndTypeService;
        private readonly IPublishingHauseService _publishingService;

        public CoverTypeController(ICoverAndTypeService coverAndTypeService,
                                   IPublishingHauseService publishingHauseService)
        {
            _coverAndTypeService = coverAndTypeService;
            _publishingService = publishingHauseService;
        }

        public IActionResult AddCover()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCover(CoverViewModel cover)
        {
            if (ModelState.IsValid)
            {
                _coverAndTypeService.AddCover(cover);
                return RedirectToAction();
            }

            return View();
        }

        public IActionResult AddType()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddType(TypeOfBookViewModel type)
        {
            if (ModelState.IsValid)
            {
                _coverAndTypeService.AddType(type);
                return RedirectToAction();
            }

            return View();
        }

        public IActionResult AddPubHause()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddPubHause(PublishingHauseViewModel hause)
        {
            if (ModelState.IsValid)
            {
                var files = HttpContext.Request.Form.Files;
                if (files.Any())
                    hause.Logo =  FileConverter.ConverToByte(files[0]);

                _publishingService.Create(hause);
                return RedirectToAction();
            }

            return View();
        }
    }
}
