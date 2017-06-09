using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Festen.Models
{
    public class Participant
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Fältet krävs")]
        public string Firstname { get; set; }
        [Required(ErrorMessage = "Fältet krävs")]
        public string Lastname { get; set; }
        public int CompletedMissions { get; set; }
    }
}
