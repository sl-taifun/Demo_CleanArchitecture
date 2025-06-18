using System.ComponentModel.DataAnnotations;

namespace DemoCleanArchitecture.Presentation.WebAPI.Dto.Input
{
    public class MemberCredentialInputDTO
    {
        [Required]
        [EmailAddress]
        [MaxLength(320)]
        public required string Email { get; set; }
        [Required]
        [RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[^a-zA-Z0-9]).{8,}$")]
        [MinLength(8)]
        public required string Password { get; set; }
    }
}
