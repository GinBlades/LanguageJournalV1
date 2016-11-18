using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LanguageJournal.Models {
    public class Entry {
        [Key]
        [Required]
        public int EntryId { get; set; }
        [Required]
        [ForeignKey("UserId")]
        public User User { get; set; }
        [Required]
        [ForeignKey("LanguageId")]
        public Language Language { get; set; }
        public string Title { get; set; }
        [Required]
        public string Body { get; set; }
        public EntryStatus Status { get; set; }
        public Visibility Visibility { get; set; }
    }

    public enum EntryStatus { Draft, Reviewed, Complete }
}
