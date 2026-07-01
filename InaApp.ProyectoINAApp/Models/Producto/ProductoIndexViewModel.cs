using inaApp.DTOs.Categoria;

namespace InaApp.ProyectoINAApp.Models.Producto
{
    public class ProductoIndexViewModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public string? Descripcion { get; set; }
        public CategoriaResponseDTO Categoria { get; set; }
    }
}
