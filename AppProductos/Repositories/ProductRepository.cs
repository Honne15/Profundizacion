using AppProyectos.Models;

namespace AppProyectos.Repositories;

public interface IProductoRepository
{
    IEnumerable<Producto> ObtenerTodos();

    //Producto ObtenerPorId(int id);

    //void Agregar(Producto producto);

    //void Actualizar(Producto producto);

    //void Eliminar(int id);
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
}