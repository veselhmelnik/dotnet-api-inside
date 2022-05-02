
namespace dotnet_api_inside.Models
{
    public class Project
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Link { get; set; }
        public DateTime Date { get; set; }
        public string? Team { get; set; }
        public string? ProjectId { get; set; }
        public bool? Build { get; set; }
        public DateTime Check { get; set; }
        public DateTime Finish { get; set; }
        public string? Organization { get; set; }
        public string? Package { get; set; }
    }
}
