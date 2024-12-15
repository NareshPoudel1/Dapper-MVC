using DapperMVC.Data.Models.Domain;
using DapperMVC.Data.Repository;
using Microsoft.AspNetCore.Mvc;

namespace DapperMVC.Ui.Controllers
{
    public class PersonController : Controller
    {
        private readonly IPersonRepository _personRepository;

        public PersonController(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(Person person)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(person);

                var addPersonResult = await _personRepository.AddAsync(person);
                TempData["msg"] = addPersonResult ? "Successfully added" : "Couldn't add";
            }
            catch (Exception ex)
            {
                // Proper logging can be added here
                TempData["msg"] = "Couldn't add";
            }

            return RedirectToAction(nameof(DisplayAll));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var person = await _personRepository.GetByIdAsync(id);
            if (person == null)
                return NotFound();

            return View(person);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Person person)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(person);

                var updateResult = await _personRepository.UpdateAsync(person);
                TempData["msg"] = updateResult ? "Updated successfully" : "Couldn't update";
            }
            catch (Exception ex)
            {
                // Proper logging can be added here
                TempData["msg"] = "Couldn't update";
            }

            return RedirectToAction(nameof(DisplayAll));
        }

        public async Task<IActionResult> DisplayAll()
        {
            var people = await _personRepository.GetAllAsync();
            return View(people);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var deleteResult = await _personRepository.DeleteAsync(id);
            TempData["msg"] = deleteResult ? "Deleted successfully" : "Couldn't delete";

            return RedirectToAction(nameof(DisplayAll));
        }
    }
}
