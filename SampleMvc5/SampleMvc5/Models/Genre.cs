using System.ComponentModel.DataAnnotations;

namespace SampleMvc5.Models
{
    public class Genre
    {
        public int Id { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
    }
}