using System.ComponentModel.DataAnnotations;

namespace MVCFifa2022.Models
{
    public class Player
    {

        public int PLayerId { get; set; }

        [Required]
        public  string? FirstName { get; set; }

        [Required]
        public string? LastName { get; set; }
        public string? ImageLink { get; set; }

        public ICollection<TeamPlayer> TeamPlayers { get; set; }
    }
}
