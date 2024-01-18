using CialMVC.Models;

namespace CialMVC.Areas.Admin.ViewModels
{
    public class WorkerCreateItemVM
    {
        public IFormFile ImageURL { get; set; }
        public string Name { get; set; }
        public ICollection<int>? SocialMediaId { get; set; }
    }
}
