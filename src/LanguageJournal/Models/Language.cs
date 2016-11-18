using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LanguageJournal.Models {
    public class Language {
        [Key]
        [Required]
        public int LanguageId { get; set; }
        [Required]
        public string Name { get; set; }
        public string Summary { get; set; }
        public virtual List<UserLanguage> UserLanguages { get; set; }
    }
}