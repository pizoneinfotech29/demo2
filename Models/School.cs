namespace task.Models
{
    public class School
    {
        public int Id { get; set; }
        public string  Name { get; set; }
        public string Location { get; set; }
        public List <Class> Classes { get; set; }
        
    }
}
