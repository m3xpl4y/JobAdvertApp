using System.ComponentModel.DataAnnotations;

namespace JobAdvert.Main.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "{0} is required!")]
        [MaxLength(50, ErrorMessage = "Name is to long!")]
        [Display(Name = "Category Name")]
        public string Name { get; set; } = string.Empty;
        [MaxLength(450, ErrorMessage = "Description is to long!")]
        [Display(Name = "Description")]
        public string Description { get; set; } = string.Empty;
    }
}