using AppProductos.Models;
using AppProductos.Repositories;

namespace AppProductos.Services;

public interface IProductoService
{
    IEnumerable<Producto> ObtenerTodos();
    Producto ObtenerPorId(int id);
    void Agregar(Producto producto);
    void Actualizar(Producto producto);
    void Eliminar(Producto producto);
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

    public Producto ObtenerPorId(int id)
    {
        return _productoRepository.ObtenerPorId(id);
    }

    public void Agregar(Producto producto)
    {
        _productoRepository.Agregar(producto);
    }

    public void Actualizar(Producto producto)
    {
        _productoRepository.Actualizar(producto);
    }

    public void Eliminar(Producto producto)
    {
        _productoRepository.Eliminar(producto);
    }
}