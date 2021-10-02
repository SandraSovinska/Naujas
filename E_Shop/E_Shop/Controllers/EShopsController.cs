using EShop.Models;
using EShop.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EShopsController : ControllerBase
    {
        [HttpPost]

        public IActionResult Create(EShops eShop)
        {
            if (eShop.ProductType == "")
            {

                return ValidationProblem("Nenurodete prekes!");
            }

            if (eShop.NameOfProducts == "")
            {
                return ValidationProblem("Nenurodete pavadinimo!");
            }

            if (eShop.KindOfProduct == "")
            {
                return ValidationProblem("Nenurodete norimos rušies!");

            }

            if (eShop.BarCode == "")
            {
                return ValidationProblem("Nenurodete  barkodo!");
            }

            if (eShop.PriceProduct == 0)
            {
                return ValidationProblem("Nenurodete norimos kainos");
            }

            var service = new EShopsServices();
            service.CreateEShops(eShop);


            return Ok();
        }

        [HttpGet("list")]
        public IActionResult List()
        {
            var service = new EShopsServices();
            var eshops = service.GetEShops();
            return new OkObjectResult(eshops);
        }

        [HttpGet]
        public IActionResult Get(string barCode)
        {
            var service = new EShopsServices();
            var eshops = service.GetEShop(barCode);

            return new OkObjectResult(eshops);
        }
      }
  }













    

