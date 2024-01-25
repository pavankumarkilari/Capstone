namespace BlogMVC.Models
{
    public class Employee
    {
        public Employee()
        {
            BlogInfos = new HashSet<Blog>();
        }

        public string EmailId { get; set; } = null!;
        public string Name { get; set; } = null!;
        public DateTime DateOfJoining { get; set; }
        public int? PassCode { get; set; }

        public virtual ICollection<Blog> BlogInfos { get; set; }
    }
}