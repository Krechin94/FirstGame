using System.ComponentModel.DataAnnotations;

namespace PizdelovoGame.SavesService.Model
{
    public class PlayerDto
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [Required]
        [StringLength(100)]
        public string Nation { get; set; }
        [Required]
        [Range(0,200)]
        public int HP { get; set; }
        [Required]
        [Range(0, 20)]
        public int Mana { get; set; }
    }
}
