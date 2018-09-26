using System.ComponentModel.DataAnnotations;

namespace AbpCoreMvcIdentiyServer.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}