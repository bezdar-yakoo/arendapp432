using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ArendApp.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Название товара")]
        [Description("Название товара")]
        public string Name { get; set; }
        [Required]
        [Description("Описание товара")]
        [Display(Name = "Описание товара")]
        public string Description { get; set; }
        [Description("Главное изображение")]
        [Display(Name = "Главное изображение")]
        [Required]
        public string MainImage { get; set; }
        [Description("Список второстепенных изображений")]
        [Display(Name = "Список второстепенных изображений (указать через \" | \")")]
        public string SecondImages { get; set; }

        [Required]
        [Description("Актуальная цена")]
        [Display(Name = "Актуальная цена")]
        public double OncePrice { get; set; }
        [Description("Старая цена")]
        [Display(Name = "Старая цена")]
        public double OldPrice { get; set; }

        [Required]
        [Description("Ёмкость")]
        [Display(Name = "Ёмкость")]
        public string Capacity { get; set; }
        [Required]
        [Description("Произодитель")]
        [Display(Name = "Производитель")]
        public string Brand { get; set; }
        [Required]
        [Description("Наличие быстрой зарядки")]
        [Display(Name = "Наличие быстрой зарядки")]
        public bool IsQuickCharge { get; set; }

    }
}
