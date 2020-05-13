using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MvcTestingSample.Models;
using MvcTestingSample.Models.Interfaces;

namespace MvcTestingSample.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductRepository _repo;

        public ProductsController(IProductRepository repo)
        {
            _repo = repo;
        }

        public async Task<IActionResult> Index()
        {
            // TODO: Resume video W6D1.1@14:25

            List<Product> products = await _repo.GetAllProductsAsync();
            return View(products);
        }
    }
}