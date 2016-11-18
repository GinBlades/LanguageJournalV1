using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LanguageJournal.Models {
    public class UserLanguage {
        [Key]
        [Required]
        public int UserLanguageId { get; set; }

        [Required]
        [ForeignKey("UserId")]
        public User User { get; set; }

        [Required]
        [ForeignKey("LanguageId")]
        public Language Language { get; set; }
    }
}