using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoList.Data;
using ToDoList.Models;

namespace ToDoList.Controllers
{
    public class ToDoController : Controller
    {
        private readonly ToDoContext _context;

        public ToDoController(ToDoContext context)
        {
            _context = context;
        }


        //get all todo cards
        public async Task<IActionResult> GetCards() => View( await _context.ToDoLists.ToListAsync());

        public async Task<IActionResult> Search(string search)
        {
            if(search is null)
                return RedirectToAction("GetCards");
            
            return View(await _context.ToDoLists.Where(x => x.Name.Contains(search)).ToListAsync());
        }


        //create todo card view
        public async Task<IActionResult> Create() => View();
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ToDoCard card)
        {
            if(ModelState.IsValid)
            {
                await _context.AddAsync(card);
                await _context.SaveChangesAsync();
                return RedirectToAction("GetCards");
            }
            return View(card);
        }
        


        [HttpPost, ActionName("delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteCard(int id)
        {
            if(id == 0)
                return NotFound();
            var item = await _context.ToDoLists.FirstOrDefaultAsync(x => x.Id == id);
            if(item is null)
                return NotFound();
            _context.Remove(item);
            await _context.SaveChangesAsync();
            return RedirectToAction("GetCards");
        }
    }
}