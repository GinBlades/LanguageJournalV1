using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LanguageJournal.Models {
    public class Review {
        [Key]
        [Required]
        public int ReviewId { get; set; }
        [Required]
        [ForeignKey("UserId")]
        public User User { get; set; }
        [Required]
        [ForeignKey("EntryId")]
        public Entry Entry { get; set; }
        [Required]
        public string Body { get; set; }
        public Visibility Visibility { get; set; }
    }
}
