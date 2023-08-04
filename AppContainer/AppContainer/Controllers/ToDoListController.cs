using AppContainer.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace AppContainer.Controllers
{
    public class ToDoListController : Controller
    {
        private readonly ToDoContext _context;

        public ToDoListController(ToDoContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.ToDoLists.ToList());
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Create([Bind("Id,AddDate,ToDoListItem,IsDone")] ToDoList toDoList)
        {
            if (ModelState.IsValid)
            {
                _context.Add(toDoList);
                _context.SaveChanges();

                return Json(toDoList);
            }
            return NotFound();
        }
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var toDoList = _context.ToDoLists.Find(id);
            if (toDoList == null)
            {
                return NotFound();
            }
            return View(toDoList);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Edit(int id, [Bind("Id,AddDate,ToDoListItem, IsDone ")] ToDoList toDoList)
        {
            if (id != toDoList.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(toDoList);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ToDoListExists(toDoList.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }

                }
                return RedirectToAction(nameof(Index));

            }
            return View(toDoList);
        }

        
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var toDoList = await _context.ToDoLists
                .FirstOrDefaultAsync(m => m.Id == id);

            if (toDoList == null)
            {
                return NotFound();
            }

            _context.ToDoLists.Remove(toDoList);
            await _context.SaveChangesAsync();

            return Json(new { success = true });
        }

        private bool ToDoListExists(int id)
        {
            return _context.ToDoLists.Any(e => e.Id == id);
        }

    }
}