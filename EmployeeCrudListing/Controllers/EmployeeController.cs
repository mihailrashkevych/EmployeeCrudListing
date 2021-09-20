using EmployeeCrudListing.Models;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeCrudListing.Controllers
{
    public class EmployeeController : Controller
    {
        private static List<Employee> employees = new() { 
            new Employee() { Id = 101, Name = "Palinski", Age = 25, Department = "Aerospace"},
            new Employee() { Id = 102, Name = "Dubrovski", Age = 27, Department = "Satelite" },
            new Employee() { Id = 103, Name = "Clarkson", Age = 32, Department = "Space Engines"}
        };

        [HttpGet]
        public IActionResult Index()
        {
            return View(employees);
        }

        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id != null)
            {
                var employee = employees.Where(s => s.Id == id).FirstOrDefault();
                if (employee != null)
                    return View(employee);
            }
            return NotFound();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            employees.Add(employee);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id != null)
            {
                var employee = employees.Where(s => s.Id == id).FirstOrDefault();
                if (employee != null)
                    return View(employee);
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult Edit(Employee employee)
        {
            var index = employees.FindIndex(c => c.Id == employee.Id); ;
            employees[index] = employee;
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id != null)
            {
                var employee = employees.Where(s => s.Id == id).FirstOrDefault();
                if (employee != null)
                    return View(employee);
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult Delete(Employee employee)
        {
            employees.Remove(employees.Find(e => e.Id == employee.Id));
            return RedirectToAction("Index");
        }
    }
}
