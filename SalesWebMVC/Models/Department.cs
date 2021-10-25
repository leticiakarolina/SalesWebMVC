
namespace SalesWebMVC.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Department()
        {
        }

        public Department(int id, string nome)
        {
            Id = id;
            Name = nome;
        }
    }
}
