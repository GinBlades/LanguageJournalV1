using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using LanguageJournal.Services;

namespace LanguageJournal.Migrations
{
    [DbContext(typeof(PostgresDbContext))]
    partial class PostgresDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1");

            modelBuilder.Entity("LanguageJournal.Models.Language", b =>
                {
                    b.Property<int>("LanguageId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Summary");

                    b.HasKey("LanguageId");

                    b.ToTable("Languages");
                });

            modelBuilder.Entity("LanguageJournal.Models.Token", b =>
                {
                    b.Property<string>("Value");

                    b.Property<int?>("UserId")
                        .IsRequired();

                    b.HasKey("Value");

                    b.HasIndex("UserId");

                    b.ToTable("Tokens");
                });

            modelBuilder.Entity("LanguageJournal.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Bio");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("Name");

                    b.Property<string>("Password")
                        .IsRequired();

                    b.Property<string>("Username")
                        .IsRequired();

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("LanguageJournal.Models.UserLanguage", b =>
                {
                    b.Property<int>("UserLanguageId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("LanguageId")
                        .IsRequired();

                    b.Property<int?>("UserId")
                        .IsRequired();

                    b.HasKey("UserLanguageId");

                    b.HasIndex("LanguageId");

                    b.HasIndex("UserId");

                    b.ToTable("UserLanguages");
                });

            modelBuilder.Entity("LanguageJournal.Models.Token", b =>
                {
                    b.HasOne("LanguageJournal.Models.User", "User")
                        .WithMany("Tokens")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("LanguageJournal.Models.UserLanguage", b =>
                {
                    b.HasOne("LanguageJournal.Models.Language", "Language")
                        .WithMany("UserLanguages")
                        .HasForeignKey("LanguageId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("LanguageJournal.Models.User", "User")
                        .WithMany("UserLanguages")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
