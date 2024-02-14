namespace task.Models
{
    public class Class
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int NumberOfStudents { get; set; }
        public int SchoolId {get; set;}
        public School School { get; set; }
    }
}
