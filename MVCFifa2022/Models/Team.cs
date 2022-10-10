using MessagePack;
using Microsoft.Build.Framework;

namespace MVCFifa2022.Models
{
    public class Team
    {        
        public int? TeamId { get; set; }

        [Required]
        public string? TeamName { get; set; }

    }
}
