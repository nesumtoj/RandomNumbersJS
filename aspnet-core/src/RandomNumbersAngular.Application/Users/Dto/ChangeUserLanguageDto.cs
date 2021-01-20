using System.ComponentModel.DataAnnotations;

namespace RandomNumbersAngular.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}