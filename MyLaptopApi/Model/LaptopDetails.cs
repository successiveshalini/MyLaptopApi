using System.ComponentModel.DataAnnotations;

namespace MyLaptopApi.Model
{
    public class LaptopDetails
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Description { get; set; }
        [Required]
        public float Price { get; set; }
    }
}
