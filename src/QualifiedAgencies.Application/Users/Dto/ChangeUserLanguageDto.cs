using System.ComponentModel.DataAnnotations;

namespace QualifiedAgencies.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}