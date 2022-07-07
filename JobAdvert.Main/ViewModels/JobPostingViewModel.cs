using JobAdvert.Main.Models;
using System.ComponentModel.DataAnnotations;

namespace JobAdvert.Main.ViewModels
{
    public class JobPostingViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "{0} is required!")]
        [MaxLength(100, ErrorMessage = "Title to long!")]
        [Display(Name = "Job Title")]
        public string JobTitle { get; set; } = string.Empty;
        [Required(ErrorMessage = "{0} is required!")]
        [MaxLength(500, ErrorMessage = "Description to long!")]
        [Display(Name = "Job Description")]
        public string JobDescription { get; set; } = string.Empty;
        public DateTime Published { get; set; }
        public int CategoryId { get; set; }
        public List<Category>? CategoryList { get; set; }
    }
}
