﻿// <auto-generated />
using System;
using CourseProgram.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CourseProgram.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.4");

            modelBuilder.Entity("CourseProgram.Models.CharacterSkill", b =>
                {
                    b.Property<int>("CharacterId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SkillId")
                        .HasColumnType("INTEGER");

                    b.HasKey("CharacterId", "SkillId");

                    b.HasIndex("SkillId");

                    b.ToTable("CharacterSkills");

                    b.HasData(
                        new
                        {
                            CharacterId = 1,
                            SkillId = 1
                        },
                        new
                        {
                            CharacterId = 2,
                            SkillId = 2
                        },
                        new
                        {
                            CharacterId = 3,
                            SkillId = 3
                        },
                        new
                        {
                            CharacterId = 4,
                            SkillId = 4
                        },
                        new
                        {
                            CharacterId = 1,
                            SkillId = 5
                        });
                });

            modelBuilder.Entity("CourseProgram.Models.Skill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Damage")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Skills");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Damage = 30,
                            Name = "FireBall"
                        },
                        new
                        {
                            Id = 2,
                            Damage = 50,
                            Name = "Frenzy"
                        },
                        new
                        {
                            Id = 3,
                            Damage = 20,
                            Name = "Blizzard"
                        },
                        new
                        {
                            Id = 4,
                            Damage = 10,
                            Name = "Water Cannon"
                        },
                        new
                        {
                            Id = 5,
                            Damage = 40,
                            Name = "Frosty"
                        });
                });

            modelBuilder.Entity("CourseProgram.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("BLOB");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("BLOB");

                    b.Property<string>("Role")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasDefaultValue("Player");

                    b.Property<string>("UserName")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            PasswordHash = new byte[] { 250, 139, 250, 176, 213, 91, 6, 126, 203, 212, 139, 6, 240, 112, 95, 89, 241, 62, 160, 190, 249, 164, 234, 107, 156, 189, 5, 45, 16, 145, 163, 27, 178, 61, 199, 179, 81, 121, 46, 183, 242, 138, 154, 36, 72, 130, 146, 58, 73, 198, 254, 29, 186, 56, 141, 189, 116, 197, 169, 219, 105, 1, 17, 209 },
                            PasswordSalt = new byte[] { 10, 227, 22, 77, 47, 207, 184, 25, 83, 92, 244, 31, 249, 202, 226, 169, 183, 61, 224, 147, 70, 114, 62, 185, 21, 176, 201, 82, 102, 213, 130, 142, 184, 119, 162, 99, 255, 191, 220, 162, 160, 53, 76, 48, 71, 85, 214, 117, 128, 152, 195, 68, 183, 45, 221, 111, 213, 132, 187, 66, 17, 199, 140, 22, 65, 88, 138, 38, 150, 123, 84, 187, 205, 88, 145, 30, 11, 186, 193, 134, 168, 17, 108, 247, 243, 57, 29, 252, 201, 119, 41, 229, 8, 5, 38, 119, 166, 219, 167, 14, 59, 162, 34, 72, 126, 197, 66, 248, 190, 25, 221, 117, 58, 244, 221, 210, 123, 37, 201, 103, 64, 26, 80, 232, 40, 138, 225, 99 },
                            Role = "Admin",
                            UserName = "User-1"
                        },
                        new
                        {
                            Id = 2,
                            PasswordHash = new byte[] { 250, 139, 250, 176, 213, 91, 6, 126, 203, 212, 139, 6, 240, 112, 95, 89, 241, 62, 160, 190, 249, 164, 234, 107, 156, 189, 5, 45, 16, 145, 163, 27, 178, 61, 199, 179, 81, 121, 46, 183, 242, 138, 154, 36, 72, 130, 146, 58, 73, 198, 254, 29, 186, 56, 141, 189, 116, 197, 169, 219, 105, 1, 17, 209 },
                            PasswordSalt = new byte[] { 10, 227, 22, 77, 47, 207, 184, 25, 83, 92, 244, 31, 249, 202, 226, 169, 183, 61, 224, 147, 70, 114, 62, 185, 21, 176, 201, 82, 102, 213, 130, 142, 184, 119, 162, 99, 255, 191, 220, 162, 160, 53, 76, 48, 71, 85, 214, 117, 128, 152, 195, 68, 183, 45, 221, 111, 213, 132, 187, 66, 17, 199, 140, 22, 65, 88, 138, 38, 150, 123, 84, 187, 205, 88, 145, 30, 11, 186, 193, 134, 168, 17, 108, 247, 243, 57, 29, 252, 201, 119, 41, 229, 8, 5, 38, 119, 166, 219, 167, 14, 59, 162, 34, 72, 126, 197, 66, 248, 190, 25, 221, 117, 58, 244, 221, 210, 123, 37, 201, 103, 64, 26, 80, 232, 40, 138, 225, 99 },
                            Role = "Player",
                            UserName = "User-2"
                        },
                        new
                        {
                            Id = 3,
                            PasswordHash = new byte[] { 250, 139, 250, 176, 213, 91, 6, 126, 203, 212, 139, 6, 240, 112, 95, 89, 241, 62, 160, 190, 249, 164, 234, 107, 156, 189, 5, 45, 16, 145, 163, 27, 178, 61, 199, 179, 81, 121, 46, 183, 242, 138, 154, 36, 72, 130, 146, 58, 73, 198, 254, 29, 186, 56, 141, 189, 116, 197, 169, 219, 105, 1, 17, 209 },
                            PasswordSalt = new byte[] { 10, 227, 22, 77, 47, 207, 184, 25, 83, 92, 244, 31, 249, 202, 226, 169, 183, 61, 224, 147, 70, 114, 62, 185, 21, 176, 201, 82, 102, 213, 130, 142, 184, 119, 162, 99, 255, 191, 220, 162, 160, 53, 76, 48, 71, 85, 214, 117, 128, 152, 195, 68, 183, 45, 221, 111, 213, 132, 187, 66, 17, 199, 140, 22, 65, 88, 138, 38, 150, 123, 84, 187, 205, 88, 145, 30, 11, 186, 193, 134, 168, 17, 108, 247, 243, 57, 29, 252, 201, 119, 41, 229, 8, 5, 38, 119, 166, 219, 167, 14, 59, 162, 34, 72, 126, 197, 66, 248, 190, 25, 221, 117, 58, 244, 221, 210, 123, 37, 201, 103, 64, 26, 80, 232, 40, 138, 225, 99 },
                            Role = "Player",
                            UserName = "User-3"
                        },
                        new
                        {
                            Id = 4,
                            PasswordHash = new byte[] { 250, 139, 250, 176, 213, 91, 6, 126, 203, 212, 139, 6, 240, 112, 95, 89, 241, 62, 160, 190, 249, 164, 234, 107, 156, 189, 5, 45, 16, 145, 163, 27, 178, 61, 199, 179, 81, 121, 46, 183, 242, 138, 154, 36, 72, 130, 146, 58, 73, 198, 254, 29, 186, 56, 141, 189, 116, 197, 169, 219, 105, 1, 17, 209 },
                            PasswordSalt = new byte[] { 10, 227, 22, 77, 47, 207, 184, 25, 83, 92, 244, 31, 249, 202, 226, 169, 183, 61, 224, 147, 70, 114, 62, 185, 21, 176, 201, 82, 102, 213, 130, 142, 184, 119, 162, 99, 255, 191, 220, 162, 160, 53, 76, 48, 71, 85, 214, 117, 128, 152, 195, 68, 183, 45, 221, 111, 213, 132, 187, 66, 17, 199, 140, 22, 65, 88, 138, 38, 150, 123, 84, 187, 205, 88, 145, 30, 11, 186, 193, 134, 168, 17, 108, 247, 243, 57, 29, 252, 201, 119, 41, 229, 8, 5, 38, 119, 166, 219, 167, 14, 59, 162, 34, 72, 126, 197, 66, 248, 190, 25, 221, 117, 58, 244, 221, 210, 123, 37, 201, 103, 64, 26, 80, 232, 40, 138, 225, 99 },
                            Role = "Player",
                            UserName = "User-4"
                        });
                });

            modelBuilder.Entity("CourseProgram.Models.Weapon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CharacterId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Damage")
                        .HasColumnType("INTEGER");

                    b.Property<string>("name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CharacterId")
                        .IsUnique();

                    b.ToTable("Weapons");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CharacterId = 4,
                            Damage = 30,
                            name = "Axe"
                        },
                        new
                        {
                            Id = 2,
                            CharacterId = 3,
                            Damage = 40,
                            name = "Spear"
                        },
                        new
                        {
                            Id = 3,
                            CharacterId = 1,
                            Damage = 50,
                            name = "Canon"
                        },
                        new
                        {
                            Id = 4,
                            CharacterId = 2,
                            Damage = 20,
                            name = "Arrow"
                        });
                });

            modelBuilder.Entity("Program.Models.Character", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Class")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Defeats")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Defense")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Fights")
                        .HasColumnType("INTEGER");

                    b.Property<int>("HitPoints")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Intelligence")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int>("Strength")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Victories")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Characters");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Class = 2,
                            Defeats = 0,
                            Defense = 10,
                            Fights = 0,
                            HitPoints = 100,
                            Intelligence = 10,
                            Name = "Frodo",
                            Strength = 20,
                            UserId = 2,
                            Victories = 0
                        },
                        new
                        {
                            Id = 2,
                            Class = 1,
                            Defeats = 0,
                            Defense = 10,
                            Fights = 0,
                            HitPoints = 100,
                            Intelligence = 10,
                            Name = "Sword",
                            Strength = 18,
                            UserId = 3,
                            Victories = 0
                        },
                        new
                        {
                            Id = 3,
                            Class = 3,
                            Defeats = 0,
                            Defense = 10,
                            Fights = 0,
                            HitPoints = 100,
                            Intelligence = 9,
                            Name = "Hatred",
                            Strength = 15,
                            UserId = 4,
                            Victories = 0
                        },
                        new
                        {
                            Id = 4,
                            Class = 1,
                            Defeats = 0,
                            Defense = 10,
                            Fights = 0,
                            HitPoints = 100,
                            Intelligence = 8,
                            Name = "Legion",
                            Strength = 19,
                            UserId = 1,
                            Victories = 0
                        });
                });

            modelBuilder.Entity("CourseProgram.Models.CharacterSkill", b =>
                {
                    b.HasOne("Program.Models.Character", "Character")
                        .WithMany("CharacterSkills")
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CourseProgram.Models.Skill", "Skill")
                        .WithMany("CharacterSkillS")
                        .HasForeignKey("SkillId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Character");

                    b.Navigation("Skill");
                });

            modelBuilder.Entity("CourseProgram.Models.Weapon", b =>
                {
                    b.HasOne("Program.Models.Character", "Character")
                        .WithOne("Weapon")
                        .HasForeignKey("CourseProgram.Models.Weapon", "CharacterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Character");
                });

            modelBuilder.Entity("Program.Models.Character", b =>
                {
                    b.HasOne("CourseProgram.Models.User", "User")
                        .WithMany("Characters")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("CourseProgram.Models.Skill", b =>
                {
                    b.Navigation("CharacterSkillS");
                });

            modelBuilder.Entity("CourseProgram.Models.User", b =>
                {
                    b.Navigation("Characters");
                });

            modelBuilder.Entity("Program.Models.Character", b =>
                {
                    b.Navigation("CharacterSkills");

                    b.Navigation("Weapon");
                });
#pragma warning restore 612, 618
        }
    }
}
