using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models
{
    public class Address
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        public string StreetNumber { get; set; }
        [StringLength(50)]
        public string City { get; set; }
        [StringLength(50)]
        public string State { get; set; }


    }
}
