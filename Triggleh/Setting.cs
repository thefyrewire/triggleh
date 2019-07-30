using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Triggleh
{
    public class Setting
    {
        [Key, Required]
        public int ID { get; set; }

        [MaxLength(25)]
        public string Username { get; set; }

        [MaxLength]
        public string ProfilePicture { get; set; }

        [Required]
        public bool LoggingEnabled { get; set; }
    }
}
