﻿namespace CialMVC.Models
{
    public class SocialMedia
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<WorkerSM>? WorkerSMs { get; }
    }
}
