namespace BlogWebApp.Models
{
    public class BlogInfo
    {
        public int BlogId { get; set; }
        public string Title { get; set; } = null!;
        public string Subject { get; set; } = null!;
        public DateTime DateOfCreation { get; set; }
        public string BlogUrl { get; set; } = null!;
        public string? EmpEmailId { get; set; }

        public virtual EmpInfo? EmpEmail { get; set; }
    }
}
