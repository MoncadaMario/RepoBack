using Microsoft.EntityFrameworkCore;
using RepoBackEnd.Data;
using RepoBackEnd.Models;

namespace RepoBackEnd.Services;

public class ProductoService
{
    private readonly DataContext _context;

    public ProductoService(DataContext context)
    {
        _context = context;
    }

    //obtener todos los productos
    public async Task<List<Producto>> ObtenerProductos()
    {
        return await _context.Productos.ToListAsync();
    }

    //agregar producto
    public async Task<Producto> CrearProducto(Producto producto)
    {
        producto.Id = Guid.NewGuid();

        _context.Productos.Add(producto);
        await _context.SaveChangesAsync();

        return producto;
    }

    //actualizar producto
    public async Task<bool> ActualizarProducto(Guid id, Producto productoActualizado)
    {
        var producto = await _context.Productos.FindAsync(id);
        if (producto == null) return false;

        producto.Nombre = productoActualizado.Nombre;
        producto.Categoria = productoActualizado.Categoria;
        producto.Precio = productoActualizado.Precio;
        producto.Cantidad = productoActualizado.Cantidad;

        await _context.SaveChangesAsync();
        return true;
    }

    //eliminar producto
    public async Task<bool> EliminarProducto(Guid id)
    {
        var producto = await _context.Productos.FindAsync(id);
        if (producto == null) return false;

        _context.Productos.Remove(producto);
        await _context.SaveChangesAsync();
        return true;
    }
}