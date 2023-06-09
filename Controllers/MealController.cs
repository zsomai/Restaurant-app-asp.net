using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using tema2.Models;
using tema2.BL;

using System.Text.Encodings.Web;


namespace tema2.Controllers;


public class MealController : Controller
{
    MealService service;
    public MealController(MealService _service){
        service = _service;
    }

    // 
    // GET: /Meal/
    public IActionResult Index()
    {
        return View(service.getAll());
    }

    //DELETE: /Meal/
    public async Task<IActionResult> Delete(int id){
        await service.remove_by_id(id);
        return RedirectToAction("Index");
    }

    // GET: Meal/Edit/
    public IActionResult Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var meal = service.getOne((int)id);
        if (meal == null)
        {
            return NotFound();
        }
        return View(meal);
    }

    // POST: Movies/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Price,Stock")] Meal meal)
    {
        if (id != meal.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            await service.update(meal);
            return RedirectToAction(nameof(Index));
        }
        return View(meal);
    }

    // GET: Meal/New/
    public IActionResult New()
    {
        return View();
    }

    // POST: Movies/New/
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> New([Bind("Name,Price,Stock")] Meal meal)
    {
        if (ModelState.IsValid)
        {
            await service.save(meal);
            return RedirectToAction(nameof(Index));
        }
        return View();
    }


}


