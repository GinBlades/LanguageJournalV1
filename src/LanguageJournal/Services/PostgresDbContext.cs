﻿using LanguageJournal.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LanguageJournal.Services {
    public class PostgresDbContext : DbContext {
        public PostgresDbContext(DbContextOptions options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<UserLanguage> UserLanguages { get; set; }
        public DbSet<Token> Tokens { get; set; }
        public DbSet<Entry> Entries { get; set; }
        public DbSet<Review> Reviews { get; set; }

        protected override void OnModelCreating(ModelBuilder builder) {
            base.OnModelCreating(builder);

            builder.Entity<Token>().HasKey(t => new { t.UserId, t.Value });

            // https://docs.microsoft.com/en-us/ef/core/modeling/relational/fk-constraints
            builder.Entity<Token>().HasOne(t => t.User)
                .WithMany(u => u.Tokens)
                .HasForeignKey(t => t.UserId);
        }
    }
}