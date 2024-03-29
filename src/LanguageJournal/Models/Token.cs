﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LanguageJournal.Models {
    // This could probably be a PostgreSQL array type
    public class Token {
        [Key]
        [Required]
        [ForeignKey("UserId")]
        public User User { get; set; }
        [Key]
        [Required]
        public string Value { get; set; }
    }
}