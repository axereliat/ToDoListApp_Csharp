using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToDoListApp2.Models;

namespace ToDoListApp2.Controllers
{
    public class TaskController : Controller
    {
        // GET: Index
        public ActionResult Index()
        {
            return RedirectToAction("List");
        }

        // GET: List
        public ActionResult List()
        {
            using (var database = new ApplicationDbContext())
            {
                var tasks = database.Tasks
                    .Include(a => a.Author)
                    .ToList();

                return View(tasks);
            }
        }

        // GET: Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Create

        [HttpPost]
        public ActionResult Create(TaskTodo task)
        {
            if (ModelState.IsValid)
            {
                using (var database = new ApplicationDbContext())
                {
                    var authorId = database.Users
                        .Where(u => u.UserName == this.User.Identity.Name)
                        .First()
                        .Id;

                    task.DueDate = DateTime.ParseExact(task.DueDateString, "dd MMMM yyyy - HH:mm", CultureInfo.InvariantCulture);
                    task.AuthorId = authorId;
                    database.Tasks.Add(task);
                    database.SaveChanges();
                    //return RedirectToAction("Create");
                }
            }
            return RedirectToAction("List");
        }
    }
}