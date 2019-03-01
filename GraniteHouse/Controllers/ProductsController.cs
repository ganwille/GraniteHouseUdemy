using GraniteHouse.Data;
using GraniteHouse.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace GraniteHouse.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _db;

        [BindProperty]
        public ProductsViewModel ProductsVM { get; set; }

        public ProductsController(ApplicationDbContext db)
        {
            _db = db;
            ProductsVM = new ProductsViewModel()
            {
                ProductTypes = _db.ProductTypes.ToList(),
                SpecialTags = _db.SpecialTags.ToList(),
                Products = new Models.Products()
            };
        }

        public async Task<IActionResult> Index()
        {
            var products =  _db.Products.Include(m => m.ProductTypes).Include(m => m.SpecialTags);
            return View(await products.ToListAsync());
        }
    }
}