using AppProductos.Models;
using AppProductos.Data;

namespace AppProductos.Repositories;

public interface IProductoRepository
{
    IEnumerable<Producto> ObtenerTodos();
    Producto ObtenerPorId(int id);
    void Agregar(Producto producto);
    void Actualizar(Producto producto);
    void Eliminar(Producto producto);
}

public class ProductoRepository : IProductoRepository
{
    private readonly AppDbContext _context;

    public ProductoRepository(AppDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Producto> ObtenerTodos()
    {
        return _context.Productos.ToList();
    }

    public Producto ObtenerPorId(int id)
    {
        var producto = _context.Productos.Find(id);
        if (producto == null)
        {
            throw new KeyNotFoundException($"Producto con el id {id} no encontrado.");
        }
        return producto;
    }

    public void Agregar(Producto producto)
    {
        _context.Productos.Add(producto);
        _context.SaveChanges();
    }

    public void Actualizar(Producto producto)
    {
        _context.Productos.Update(producto);
        _context.SaveChanges();
    }

    public void Eliminar(Producto producto)
    {
        _context.Productos.Remove(producto);
        _context.SaveChanges();
    }
}