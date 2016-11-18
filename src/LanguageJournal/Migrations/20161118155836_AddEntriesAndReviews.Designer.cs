using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using LanguageJournal.Services;
using LanguageJournal.Models;

namespace LanguageJournal.Migrations
{
    [DbContext(typeof(PostgresDbContext))]
    [Migration("20161118155836_AddEntriesAndReviews")]
    partial class AddEntriesAndReviews
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752");

            modelBuilder.Entity("LanguageJournal.Models.Entry", b =>
                {
                    b.Property<int>("EntryId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Body")
                        .IsRequired();

                    b.Property<int?>("LanguageId")
                        .IsRequired();

                    b.Property<int>("Status");

                    b.Property<string>("Title");

                    b.Property<int?>("UserId")
                        .IsRequired();

                    b.Property<int>("Visibility");

                    b.HasKey("EntryId");

                    b.HasIndex("LanguageId");

                    b.HasIndex("UserId");

                    b.ToTable("Entries");
                });

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

            modelBuilder.Entity("LanguageJournal.Models.Review", b =>
                {
                    b.Property<int>("ReviewId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Body")
                        .IsRequired();

                    b.Property<int?>("EntryId")
                        .IsRequired();

                    b.Property<int?>("UserId")
                        .IsRequired();

                    b.Property<int>("Visibility");

                    b.HasKey("ReviewId");

                    b.HasIndex("EntryId");

                    b.HasIndex("UserId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("LanguageJournal.Models.Token", b =>
                {
                    b.Property<string>("Value")
                        .ValueGeneratedOnAdd();

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

            modelBuilder.Entity("LanguageJournal.Models.Entry", b =>
                {
                    b.HasOne("LanguageJournal.Models.Language", "Language")
                        .WithMany()
                        .HasForeignKey("LanguageId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("LanguageJournal.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("LanguageJournal.Models.Review", b =>
                {
                    b.HasOne("LanguageJournal.Models.Entry", "Entry")
                        .WithMany()
                        .HasForeignKey("EntryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("LanguageJournal.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
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
