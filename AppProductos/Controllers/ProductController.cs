using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AppProductos.Models;
using AppProductos.Services;

namespace AppProductos.Controllers;

public class ProductController : Controller 
{
    private readonly ILogger<HomeController> _logger;
    private readonly IProductoService _productoService;

    public ProductController(ILogger<HomeController> logger, IProductoService productoService)
    {
        _logger = logger;
        _productoService = productoService;
    }
    public IActionResult Index(string searchTerm = "")
    {
        var productos = _productoService.ObtenerTodos(searchTerm);
        ViewBag.SearchTerm = searchTerm;
        return View(productos);
    }

    public IActionResult Add()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Add(Producto producto)
    {
        if (ModelState.IsValid)
        {
            _productoService.Agregar(producto);
            return RedirectToAction("Index");
        }
        return View(producto);
    }

    public IActionResult Edit(int id)
    {
        var producto = _productoService.ObtenerPorId(id);
        return producto == null ? NotFound(): View(producto);
    }

    [HttpPost]
    public IActionResult Edit(Producto producto)
    {
        if (ModelState.IsValid)
        {
            _productoService.Actualizar(producto);
            return RedirectToAction("Index");
        }
        return View(producto);
    }

    public IActionResult Delete(int id)
    {
        var producto = _productoService.ObtenerPorId(id);
        return producto == null ? NotFound(): View(producto);
    }

    [HttpPost]
    public IActionResult ConfirmDelete(int id)
    {
        _productoService.Eliminar(id);
        return RedirectToAction("Index");
    }
}