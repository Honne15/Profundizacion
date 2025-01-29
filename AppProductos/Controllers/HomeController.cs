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

    public IActionResult ProductId(int id)
    {
        var producto = _productoService.ObtenerPorId(id);
        return View(producto);
    }

    public IActionResult AddProduct()
    {
        return View();
    }

    public IActionResult UpdateProduct()
    {
        return View();
    }

    [HttpPost]
    public IActionResult AddProduct(Producto producto)
    {
        if (ModelState.IsValid)
        {
            _productoService.Agregar(producto);
            return RedirectToAction("Products");
        }
        return View(producto);
    }

    [HttpGet]
    public IActionResult UpdateProduct(int id)
    {
        var producto = _productoService.ObtenerPorId(id);
        return View(producto);
    }

    [HttpPost]
    public IActionResult UpdateProduct(Producto producto)
    {
        if (ModelState.IsValid)
        {
            _productoService.Actualizar(producto);
            return RedirectToAction("Products");
        }
        return View(producto);
    }

     [HttpPost]
    public IActionResult DeleteProduct(int id)
    {
        var producto = _productoService.ObtenerPorId(id);
        if (producto != null)
        {
            _productoService.Eliminar(producto);
        }
        return RedirectToAction("Products");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
