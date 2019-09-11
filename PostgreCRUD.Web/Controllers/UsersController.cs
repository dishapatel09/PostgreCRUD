using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PostgreCRUD.Web.Context;
using PostgreCRUD.Web.Models;
using PostgreCRUD.Web.Repository;

namespace PostgreCRUD.Web.Controllers
{
    public class UsersController : Controller
    {
        private readonly UserRepository userRepository;
        public UsersController(UsersContext usersContext)
        {
            userRepository = new UserRepository(usersContext);
        }

        // GET: Users
        public ActionResult Index()
        {
            List<User> users = userRepository.FindAll().ToList();
            return View(users);
        }

        // GET: Users/Details/5
        public ActionResult Details(int id)
        {
            User user = userRepository.FindByID(id);
            return View(user);
        }

        // GET: Users/Create
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                userRepository.Add(user);
                return RedirectToAction("Index");
            }
            return View(user);
        }

        // Get: Users/Edit/5
        public ActionResult Edit(int id)
        {
            User user = userRepository.FindByID(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(User user)
        {

            if (ModelState.IsValid)
            {
                userRepository.Update(user);
                return RedirectToAction("Index");
            }
            return View(user);
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int id)
        {            
            userRepository.Remove(id);
            return RedirectToAction("Index");
        }     
    }
}