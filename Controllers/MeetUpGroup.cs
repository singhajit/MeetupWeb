using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Meetup.Data.Models;
using MeetUp.Reo.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MeetupWeb.Controllers
{
    public class MeetUpGroupController : Controller
    {
        private IGroupService groupService;
        public MeetUpGroupController(IGroupService service)
        {
            this.groupService = service;
        }
        // GET: MeetUpGroup
        public ActionResult Index()
        {
            this.groupService.GetAll();
            return View();
        }

        // GET: MeetUpGroup/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // POST: MeetUpGroup/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MeetUpGroup meetup)
        {
            try
            {
                this.groupService.Insert(meetup);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MeetUpGroup/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MeetUpGroup/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MeetUpGroup meetUp)
        {
            try
            {
                this.groupService.Modify(id, meetUp);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MeetUpGroup/Delete/5
        public ActionResult Delete(int id)
        {
            this.groupService.Remove(id);
            return View();
        }
    }
}
