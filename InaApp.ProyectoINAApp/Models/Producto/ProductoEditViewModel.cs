using System.ComponentModel.DataAnnotations;

namespace InaApp.ProyectoINAApp.Models.Producto
{
    public class ProductoEditViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Nombre del producto")]
        [Required(ErrorMessage = "EL nombre es obligatorio.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "El nombre debe tener entre 3 y 100 carancteres.")]
        public string Nombre { get; set; } = string.Empty;

        [Display(Name = "Precio de producto")]
        [Required(ErrorMessage = "El precio es obligatorio.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "EL precio debe ser mayour que cero.")]
        [DataType(DataType.Currency)]
        public decimal Precio { get; set; } = 0;

        [Display(Name = "Stock de producto")]
        [Required(ErrorMessage = "EL stock es obligatorio.")]
        [Range(1, int.MaxValue, ErrorMessage = "El stock no  puede ser un negatvo o 0.")]
        public int Stock { get; set; } = 0;

        [Display(Name = "Descripción de producto")]
        [StringLength(500, ErrorMessage = "El maximo de caracteres para la descripción son 500 y el minimo 10.")]
        public string? Descripcion { get; set; } = string.Empty;

        [Display(Name = "Categoria de producto")]
        [Required(ErrorMessage = "La categoría es obligatoria.")]
        public int CategoriaId { get; set; } = 1;
    }
}
