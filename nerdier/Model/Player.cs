using System.ComponentModel.DataAnnotations;

namespace nerdier.Model
{
    public class Player
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        public int? Pontos { get; set; }
    }
}
