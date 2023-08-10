using System.ComponentModel.DataAnnotations;

namespace BharatLaw.Models
{
    public class ResearchBook
    {
        [Key]
        public int id { get; set; }
        [Required] public string Name { get; set; }
        public DateTime LastModified { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
