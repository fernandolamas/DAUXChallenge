using DauxChallengeCommon.Models;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace DauxChallengeCommon.Models
{
    public class IdentityViewModel
    {
        [Required(ErrorMessage = ErrorMessages.IsRequired)]
        [MinLength(3, ErrorMessage = $"{ErrorMessages.MinimunLengthRequired} 3")]
        [Display(Name = "Nombre")]
        [JsonProperty("nombre")]
        public string Firstname { get; set; } = null!;

        [Required(ErrorMessage = ErrorMessages.IsRequired)]
        [MinLength(3, ErrorMessage = $"{ErrorMessages.MinimunLengthRequired} 3")]
        [Display(Name = "Apellido")]
        [JsonProperty("apellido")]
        public string Lastname { get; set; } = null!;
        public string Message { get; set; } = string.Empty;
    }
}
