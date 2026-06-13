using LapTopCartMVC.Data;
using LapTopCartMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace LapTopCartMVC.Controllers
{
    public class CartController : Controller
    {
        public readonly ApplicationDbContext _context;
        public CartController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var userdId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var cartproduct = _context.CartItems.Where(p => p.UserId == userdId).Include(p => p.Product).ToList();
            return View(cartproduct);
        }

        public async Task<IActionResult> Plus(int cartId)
        {
            var cartFromDb = _context.CartItems.FirstOrDefault(u => u.Id == cartId);
            if (cartFromDb == null)
                return NotFound();

            cartFromDb.Quantity += 1;
            _context.CartItems.Update(cartFromDb);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Minus(int cartId)
        {
            var cartFromDb = _context.CartItems.FirstOrDefault(u => u.Id == cartId);
            if (cartFromDb == null)
                return NotFound();

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (cartFromDb.Quantity <= 1)
            {
                _context.CartItems.Remove(cartFromDb);
                await _context.SaveChangesAsync();

                var count = _context.CartItems.Count(x => x.UserId == userId);
                HttpContext.Session.SetInt32(SD.SessionCart, count);
            }
            else
            {
                cartFromDb.Quantity -= 1;
                _context.CartItems.Update(cartFromDb);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Remove(int cartId)
        {
            var cartFromDb = _context.CartItems.FirstOrDefault(u => u.Id == cartId);
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            _context.CartItems.Remove(cartFromDb);

            HttpContext.Session.SetInt32(SD.SessionCart, _context.CartItems.Count(x => x.UserId == userId) - 1);
            _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}

