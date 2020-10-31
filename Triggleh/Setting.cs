using System;
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
        public string UserID { get; set; }

        [MaxLength(24)]
        public string TrigglehToken { get; set; }

        [MaxLength]
        public string ProfilePicture { get; set; }

        [Required]
        public int GlobalCooldown { get; set; }

        [Required]
        public int GlobalCooldownUnit { get; set; }

        public DateTime GlobalLastTriggered { get; set; }

        [Required]
        public bool LoggingEnabled { get; set; }
    }
}
