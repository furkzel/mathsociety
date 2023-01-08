using mathsociety.DAL;
using mathsociety.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace mathsociety.Controllers
{
    public class AnnouncementController : Controller
    {
        private readonly AnnouncementDbContext _context;

        public AnnouncementController(AnnouncementDbContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var announceList = _context.Announcement.ToList();

            if (announceList != null)
            {
                List<AnnouncementViewModel> announceViewModelList = new List<AnnouncementViewModel>();
                foreach (var announce in announceList)
                {
                    var AnnouncementViewModel = new AnnouncementViewModel()
                    {
                        AnnouncementID = announce.AnnouncementID,
                        Title = announce.Title,
                        Content = announce.Content,
                        Date = announce.Date,
                        Author = announce.Author
                    };
                    announceViewModelList.Add(AnnouncementViewModel);
                }
                return View(announceList);
            }
            return View(announceList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(AnnouncementViewModel announcementViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var announcement = new Announcement()
                    {
                        AnnouncementID = announcementViewModel.AnnouncementID,
                        Title = announcementViewModel.Title,
                        Content = announcementViewModel.Content,
                        Date = announcementViewModel.Date,
                        Author = announcementViewModel.Author
                    };
                    _context.Announcement.Add(announcement);
                    _context.SaveChanges();
                    TempData["Success"] = "Announcement created successfully";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["Message"] = "Invalid data";
                    return View();
                }
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
        }
    }
}
