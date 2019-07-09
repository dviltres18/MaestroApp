using System.ComponentModel.DataAnnotations;

namespace MaestroApp.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}