using System.ComponentModel.DataAnnotations;

namespace GameWiki.Data
{
    public class Developer
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Enter a Name")]
        [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Enter a City")]
        [StringLength(100, ErrorMessage = "City cannot exceed 100 characters")]
        public string City { get; set; } = string.Empty;

        [Required(ErrorMessage = "Enter a Country")]
        [StringLength(100, ErrorMessage = "Country cannot exceed 100 characters")]
        public string Country { get; set; } = string.Empty;
    }
}
