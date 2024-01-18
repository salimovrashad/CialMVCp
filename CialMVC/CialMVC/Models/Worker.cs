namespace CialMVC.Models
{
    public class Worker
    {
        public int Id { get; set; }
        public string ImageURL { get; set; }
        public string Name { get; set; }
        public string? SocialMedia {  get; set; }
        public ICollection<WorkerSM>? WorkerSMs { get; set; }

    }
}