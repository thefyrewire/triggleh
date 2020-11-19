using System;
using System.Collections.Generic;
using System.Linq;

using System.Data.Entity.Core;
using System.ComponentModel.DataAnnotations;

namespace Triggleh
{
    public class Trigger
    {
        [Key, Required]
        public int ID { get; set; }

        [MaxLength, Required]
        public string Name { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }


        [Required]
        public bool BitsEnabled { get; set; }

        [Required]
        public int BitsCondition { get; set; }

        [Required]
        public int BitsAmount { get; set; }

        [Required]
        public int BitsAmount2 { get; set; }


        [Required]
        public bool UserLevelEveryone { get; set; }

        [Required]
        public bool UserLevelSubs { get; set; }

        [Required]
        public bool UserLevelVips { get; set; }

        [Required]
        public bool UserLevelMods { get; set; }


        [Required]
        public string Keywords { get; set; }


        [Required]
        public string CharAnimTriggerKeyChar { get; set; }

        [Required]
        public int CharAnimTriggerKeyValue { get; set; }



        [Required]
        public int Cooldown { get; set; }

        [Required]
        public int CooldownUnit { get; set; }

        public DateTime LastTriggered { get; set; }


        [MaxLength(45)]
        public string RewardName { get; set; }
    }
}
