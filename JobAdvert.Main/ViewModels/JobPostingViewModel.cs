using JobAdvert.Main.Models;

namespace JobAdvert.Main.ViewModels
{
    public class JobPostingViewModel
    {
        public int Id { get; set; }
        public string JobTitle { get; set; }
        public string JobDescription { get; set; }
        public DateTime Published { get; set; }
        public int CategoryId { get; set; }
        public List<Category> CategoryList { get; set; }
    }
}
