using System.ComponentModel.DataAnnotations;

namespace JobAdvert.Main.Models
{
    public class Job
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "{0} is required!")]
        [MaxLength(100, ErrorMessage = "Title to long!")]
        [Display(Name = "Job Title")]
        public string Title { get; set; } = string.Empty;
        [Required(ErrorMessage = "{0} is required!")]
        [MaxLength(500, ErrorMessage = "Description to long!")]
        [Display(Name = "Job Description")]
        public string Description { get; set; } = string.Empty;
        [Display(Name = "Job was published on")]
        public DateTime Published { get; set; }
        public Category Category { get; set; }
    }
}
