using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProductManagement.Mvc.WebApi.ModelView.Products;

public class ProductViewModel
{
    public int Id { get; set; }

    [DisplayName("Nazwa produktu")]
    [StringLength(50, MinimumLength = 5)]
    [Required(ErrorMessage = "Pole nazwa produktu jest wymagane")]
    public string Name { get; set; }

    [DisplayName("Opis produktu")]
    public string? Description { get; set; }

    [DisplayName("Cena")]
    [Range(1, 10000)]
    public decimal Price { get; set; }

    public DateTime? CreateDate { get; set; }
    public DateTime? UpdateDate { get; set; }
}