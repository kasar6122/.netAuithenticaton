using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public int AddressId { get; set; }
        public Address? Address { get; set; }


    }
}
