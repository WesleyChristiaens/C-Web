using MessagePack;
using Microsoft.Build.Framework;
using MVCFifa2022.Controllers;

namespace MVCFifa2022.Models
{
    public class Team
    {        
        public int? TeamId { get; set; }

        [Required]
        public string? TeamName { get; set; }

        public ICollection<TeamPlayer> TeamPlayers { get; set; }

    }
}
