using Microsoft.Extensions.Hosting;

namespace CialMVC.Models
{
    public class WorkerSM
    {
        public int ID { get; set; }
        public int SocialMediaID { get; set; }
        public int WorkerID { get; set; }
        public SocialMedia? SocialMedias { get; set; }
        public Worker? Worker { get; set; }
    }
}
