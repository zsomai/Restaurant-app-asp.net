using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

using tema2.Models;
using tema2.Utils;
using tema2.BL;
using tema2.DAO;

namespace team2.Controllers;

public class OrderController : Controller
{
    ///TODO: Dependency Injection
    OrderService service;
    public OrderController(OrderService _service)
    {
        service = _service;
    }

    // 
    // GET: /Order/
    public async Task<IActionResult> Index()
    {
        return View(service.getAll());
    }


    // GET: /Order/Status/
    public async Task<IActionResult> Status(int id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var order = service.getOne((int)id);
        if (order == null)
        {
            return NotFound();
        }
        return View(order);
    }

    // POST: Order/Status/
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Status(int id, [Bind("Id,Status,Date")] Order order)
    {
        if (id != order.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            await service.update(order);
            return RedirectToAction(nameof(Index));
        }
        return View(order);
    }



    // GET: /Order/New/
    public async Task<IActionResult> New()
    {
        List<Meal> meals = (List<Meal>)service.getAllMeals();

        return View(meals);
    }

    // POST: Order/New/
    [HttpPost]
    public async Task<IActionResult> New(Dictionary<int, int> mealQuantities)
    {
        
        Order order = new Order{Date = DateTime.Now, Status = tema2.Models.Status.RECIVED};
        await service.ProcessOrder(order, mealQuantities);
        return RedirectToAction(nameof(Index));
    }

    // GET: Order/Details/
    public ActionResult Details(int id){
        ViewOrder order = service.getOne(id);
        return View(order);
    }

}