using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AppProductos.Models;
using AppProductos.Services;

namespace AppProductos.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IProductoService _productoService;

    public HomeController(ILogger<HomeController> logger, IProductoService productoService)
    {
        _logger = logger;
        _productoService = productoService;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult Products()
    {
        var productos = _productoService.ObtenerTodos();
        return View(productos);
    }

    public IActionResult AddProduct()
    {
        return View();
    }

    public IActionResult AgregarProducto()
    {
        return View();
    }

    [HttpPost]
    public IActionResult AgregarProducto(Producto producto)
    {
        if (ModelState.IsValid)
        {
            _productoService.Agregar(producto);
            return RedirectToAction("Products");
        }
        return View(producto);
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
