using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LanguageJournal.Models {
    public class User {
        [Key]
        [Required]
        public int UserId { get; set; }
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Username { get; set; }
        public string Bio { get; set; }
        [Required]
        public string Password { get; set; }

        [JsonIgnore]
        public virtual List<Token> Tokens { get; set; }
        public virtual List<UserLanguage> UserLanguages { get; set; }
    }
}