using Lec03CRRUDSingle.Models.Entity;
using Lec03CRRUDSingle.Services;
using Microsoft.AspNetCore.Mvc;

namespace Lec03CRRUDSingle.Controllers;

public class PersonController(IPersonRepository personRepo) : Controller
{
    private readonly IPersonRepository _personRepo = personRepo;

    public async Task<IActionResult> Index()
    {
        var allPeople = await _personRepo.ReadAllAsync();
        return View(allPeople);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Person newPerson)
    {
        if (ModelState.IsValid)
        {
            await _personRepo.CreateAsync(newPerson);
            return RedirectToAction("Index");
        }
        return View(newPerson);
    }

    public async Task<IActionResult> Details(int id)
    {
        var person = await _personRepo.ReadAsync(id);
        if (person == null)
        {
            return RedirectToAction("Index");
        }
        return View(person);
    }

    public async Task<IActionResult> Edit(int id)
    {
        var person = await _personRepo.ReadAsync(id);
        if (person == null)
        {
            return RedirectToAction("Index");
        }
        return View(person);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(Person person)
    {
        if (ModelState.IsValid)
        {
            await _personRepo.UpdateAsync(person.Id, person);
            return RedirectToAction("Index");
        }
        return View(person);
    }

    public async Task<IActionResult> Delete(int id)
    {
        var person = await _personRepo.ReadAsync(id);
        if (person == null)
        {
            return RedirectToAction("Index");
        }
        return View(person);
    }

    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _personRepo.DeleteAsync(id);
        return RedirectToAction("Index");
    }

}
