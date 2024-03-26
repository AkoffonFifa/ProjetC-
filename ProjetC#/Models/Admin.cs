using System.ComponentModel.DataAnnotations;

namespace ProjetC_.Models
{
    public class Admin
    {

        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }

        [Required]
        public string? email { get; set; }
        [Required]
        public string? password { get; set; }
        [Required]
        public string? telephone { get; set; }

    }
}
