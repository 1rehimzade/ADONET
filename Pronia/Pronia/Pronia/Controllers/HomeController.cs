﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pronia.Models;
using Pronia.ViewModels;
using Pronia.DAL;

namespace Pronia.Countollers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {


            List<Slide> slides = await _context.Slides.OrderBy(s => s.Order).Take(2).ToListAsync();

            List<Product> products = await _context.Products
                .Include(p => p.ProductImages.Where(pi => pi.IsPrimary != null)).ToListAsync();

            //_context.Slides.AddRange(slides);
            //_context.SaveChanges();

            HomeVM home = new HomeVM
            {
                Slides = slides,
                Products = products
            };

            return View(home);
        }

        public IActionResult About()
        {
            return View();
        }
    }
}
