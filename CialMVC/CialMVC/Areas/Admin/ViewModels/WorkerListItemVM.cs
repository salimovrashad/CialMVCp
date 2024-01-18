using CialMVC.Models;

namespace CialMVC.Areas.Admin.ViewModels
{
    public class WorkerListItemVM
    {
        public int Id { get; set; }
        public string ImageURL { get; set; }
        public string Name { get; set; }
        public string SocialMedia { get; set; }
        public ICollection<SocialMedia>? SocialMedias { get; set; }
    }
}
