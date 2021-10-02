using _6._4Uzduotis.Models;
using _6._4Uzduotis.Models.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _6._4Uzduotis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudensController : ControllerBase
    {
        [HttpPost]
        public IActionResult Create(Student student)
        {
            if (student.Name == "")
            {
                return ValidationProblem("Nenurodete vardo!");
            }

            if (student.Surname == "")
            {
                return ValidationProblem("Nenurodete pavardes!");
            }

            if (student.BirthDay == DateTime.MinValue) 
            {
                return ValidationProblem("Nenurodete Gimimo dtaos!");
            }

            var service = new StudentService();
            service.CreateStudent(student);

            return Ok();
        }

        [HttpGet("list")]
        public IActionResult List()
        {
            var service = new StudentService();
            var students = service.GetStudents();
            return new OkObjectResult(students);
        }

        [HttpGet]
        public IActionResult Get(string documentId)
        {
            var service = new StudentService();
            var student = service.GetStudent(documentId);

            return new OkObjectResult(student);
        }

    }



}
        
        
       




