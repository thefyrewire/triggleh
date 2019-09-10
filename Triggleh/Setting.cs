using System.ComponentModel.DataAnnotations;

namespace Triggleh
{
    public class Setting
    {
        [Key, Required]
        public int ID { get; set; }

        [MaxLength]
        public string Application { get; set; }

        [MaxLength(25)]
        public string Username { get; set; }

        [MaxLength]
        public string ProfilePicture { get; set; }

        [Required]
        public bool LoggingEnabled { get; set; }
    }
}
