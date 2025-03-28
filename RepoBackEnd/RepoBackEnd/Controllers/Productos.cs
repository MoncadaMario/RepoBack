using Microsoft.AspNetCore.Mvc;
using RepoBackEnd.Models;
using RepoBackEnd.Services;

namespace TestWebApi.Controllers;

[Route("api/[controller]")]
[ApiController]

public class ProductosController : ControllerBase
{
    private readonly ProductoService _productoService;

    public ProductosController(ProductoService productoService)
    {
        _productoService = productoService;
    }

    [HttpGet]
    public async Task<ActionResult<List<Producto>>> ObtenerProductos()
    {
        var productos = await _productoService.ObtenerProductos();
        return Ok(productos);
    }

    [HttpPost]
    public async Task<ActionResult> CrearProducto([FromBody] Producto producto)
    {
        if (producto== null)
        {
            return BadRequest("Producto Invalido");
        }
        var nuevoProducto = await _productoService.CrearProducto(producto);
        return Ok(nuevoProducto);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> ActualizarProducto(Guid id, [FromBody] Producto productoActualizado)
    {
        if (productoActualizado == null)
        {
            return BadRequest("Producto Invalido");
        }

        var response = await _productoService.ActualizarProducto(id, productoActualizado);

        if (response == false)
        {
            return NotFound("Producto no encontrado");
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> EliminarProducto(Guid id)
    {
        var response = await _productoService.EliminarProducto(id);
        if (response == false)
        {
            return NotFound("Producto no encontrado");
        }
        return NoContent();
    }

}