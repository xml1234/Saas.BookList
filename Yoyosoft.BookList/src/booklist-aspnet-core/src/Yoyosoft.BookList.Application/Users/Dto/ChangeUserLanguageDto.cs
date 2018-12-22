using System.ComponentModel.DataAnnotations;

namespace Yoyosoft.BookList.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}