using FridgeProduct.Entities;
using FridgeProduct.Entities.Models;
using FridgeProduct.Repository;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FridgeProduct.Controllers
{
    public class HomeController : Controller
    {
        /*RepositoryContext _context;
        IWebHostEnvironment _appEnvironment;
        public HomeController(RepositoryContext context, IWebHostEnvironment appEnvironment)
        {
            _context = context;
            _appEnvironment = appEnvironment;
        }*/
        RepositoryContext _context;
        public HomeController(RepositoryContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
            //return View(_context.Fridges.ToList());
            //return View(_context.Files.ToList());
        }
    }
}