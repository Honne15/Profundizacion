using AppProductos.Models;
using AppProductos.Repositories;

namespace AppProductos.Services;

public interface IProductoService
{
    IEnumerable<Producto> ObtenerTodos();
    void Agregar(Producto producto);
}

public class ProductoService : IProductoService
{
    private readonly IProductoRepository _productoRepository;

    public ProductoService(IProductoRepository productoRepository)
    {
        _productoRepository = productoRepository;
    }

    public IEnumerable<Producto> ObtenerTodos()
    {
        return _productoRepository.ObtenerTodos();
    }

    public void Agregar(Producto producto)
    {
        _productoRepository.Agregar(producto);
    }
}