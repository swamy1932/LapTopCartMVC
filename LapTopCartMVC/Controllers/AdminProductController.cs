using LapTopCartMVC.Data;
using LapTopCartMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LapTopCartMVC.Controllers
{
    public class AdminProductController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public AdminProductController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            if (product.Name?.Trim().ToLower() == "test")
            {
                ModelState.AddModelError("Name", "The product name can not 'Test'");
            }
            if (product.ImageFile != null && product.ImageFile.Length > 0)
            {
                // Get the wwwroot path from the environment
                string wwwRootPath = _webHostEnvironment.WebRootPath;

                // Clean and generate a unique filename
                string originalFileName = Path.GetFileNameWithoutExtension(product.ImageFile.FileName)
                    .Replace(" ", "_"); // Remove spaces
                string extension = Path.GetExtension(product.ImageFile.FileName);
                string uniqueFileName = $"{originalFileName}_{Guid.NewGuid():N}{extension}";

                // Ensure the /images folder exists
                string imagesFolder = Path.Combine(wwwRootPath, "images");
                if (!Directory.Exists(imagesFolder))
                {
                    Directory.CreateDirectory(imagesFolder);
                }
                // Path to save the image physically
                string filePath = Path.Combine(imagesFolder, uniqueFileName);

                // Save file to server
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await product.ImageFile.CopyToAsync(stream);
                }

                // Save relative path (for Razor <img src =... >)
                product.ImagePath = "/images/" + uniqueFileName;

                // [Optional] Verify file was saved - useful for debugging
                string confirmPath = Path.Combine(wwwRootPath, product.ImagePath.TrimStart('/'));
                if (!System.IO.File.Exists(confirmPath))
                {
                    throw new FileNotFoundException("Image was not saved correctly", confirmPath);
                }
            }

            if (ModelState.IsValid)
            {
                _context.Products.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            else
            {
                return View(product);
            }
        }
    }
}


