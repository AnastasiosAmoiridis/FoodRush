using System.ComponentModel.DataAnnotations;

namespace Models.Entities
{
    public enum GlobalProductCategoryType
    {
        [Display(Name = "Πίτσες")]
        Pizza,

        [Display(Name = "Μπέργκερ")]
        Burger,

        [Display(Name = "Καφέδες")]
        Coffee,

        [Display(Name = "Μαγειρευτά")]
        CookedDish,

        [Display(Name = "Ζυμαρικά")]
        Pasta,

        [Display(Name = "Σουβλάκια")]
        Souvlaki,

        [Display(Name = "Σάντουιτς")]
        Sandwich,

        [Display(Name = "Γλυκά")]
        Dessert,

        [Display(Name = "Ποτά")]
        Drink,

        [Display(Name = "Σαλάτες")]
        Salad,

        [Display(Name = "Άλλο")]
        Other
    }

    public class GlobalProductCategory
    {
        public Guid Id { get; set; }

        public required GlobalProductCategoryType Type { get; set; }

        public ICollection<Brand> Brands { get; set; } = new List<Brand>();
    }
}
