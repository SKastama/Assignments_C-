using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using System.Collections.Generic;
using productsCategories.Models;

namespace productsCategories.Controllers
{
    public class HomeController : Controller   
    {
        private MyContext _context;

        public HomeController(MyContext context)
        {
            _context = context;
        }
        

        // Routes: Products
        [HttpGet("")]   
        public IActionResult AllProducts()
        {
            ViewBag.existingProducts = _context.Products
                .ToList();

            return View();
        }

        [HttpPost("products/submit")]   
        public IActionResult SubmitProduct(Product newProduct)
        {
            if (ModelState.IsValid)
            {
                _context.Add(newProduct);
                _context.SaveChanges();
                return RedirectToAction("AllProducts");
            }
            return View("AllProducts", newProduct);
        }

        [HttpGet("products/{ProductId}")]   
        public IActionResult OneProduct(int ProductId)
        {
            ViewBag.inProduct = _context.Products
                .Include(product => product.Associations)
                    .ThenInclude(assoc => assoc.Category)
                .FirstOrDefault(product => product.ProductId == ProductId);
                
            ViewBag.notInProduct = _context.Categories
                .Include(category => category.Associations)
                    .ThenInclude(asso => asso.Product)
                .Where(category => category.Associations.All(product => product.ProductId != ProductId))
                .ToList();
            
            ViewBag.productId = ProductId;

            return View();
        }

        [HttpPost("products/{ProductId}/submit")]   
        public IActionResult SubmitAddCategory(Association newCat)
        {
            if (ModelState.IsValid)
            {
                _context.Add(newCat);
                _context.SaveChanges();
                return RedirectToAction("OneProduct");
            }
            return View("OneProduct", newCat);
        }


        // Routes: Categories
        [HttpGet("categories")]   
        public IActionResult AllCategories()
        {
            ViewBag.existingCategories = _context.Categories
                .ToList();
            
            return View();
        }

        [HttpPost("categories/submit")]   
        public IActionResult SubmitCategory(Category newCategory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(newCategory);
                _context.SaveChanges();
                return RedirectToAction("AllCategories");
            }
            return View("AllCategories", newCategory);
        }

        [HttpGet("categories/{CategoryId}")]   
        public IActionResult OneCategory(int CategoryId)
        {
            ViewBag.inCategory = _context.Categories
                .Include(category => category.Associations)
                    .ThenInclude(asso => asso.Product)
                .FirstOrDefault(category => category.CategoryId == CategoryId);
                
            ViewBag.notInCategory = _context.Products
                .Include(product => product.Associations)
                    .ThenInclude(asso => asso.Category)
                .Where(product => product.Associations.All(category => category.CategoryId != CategoryId))
                .ToList();

            ViewBag.categoryId = CategoryId;

            return View();
        }

        [HttpPost("categories/{CategoryId}/submit")]   
        public IActionResult SubmitAddProduct(Association newPdt)
        {
            if (ModelState.IsValid)
            {
                _context.Add(newPdt);
                _context.SaveChanges();
                return RedirectToAction("OneCategory");
            }
            return View("OneCategory", newPdt);
        }
    }
}