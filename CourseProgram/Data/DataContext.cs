using CourseProgram.Models;
using Microsoft.EntityFrameworkCore;
using Program.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseProgram.Data
{
    public class DataContext : DbContext
    {
         public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
       
        }
        public DbSet<Character> Characters { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Weapon> Weapons { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<CharacterSkill> CharacterSkills { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            /*
             * to make the primary key in the characater skills table 
             * which is created as a result of many to many relation between
             * Characters and skills
             */
            modelBuilder.Entity<CharacterSkill>()
                .HasKey(cs => new { cs.CharacterId, cs.SkillId });

            /*
             * To make the default Role of the user to Player
             */
            modelBuilder.Entity<User>()
                .Property(user => user.Role).HasDefaultValue("Player");


            //Seeding the data for the skills
            modelBuilder.Entity<Skill>().HasData(
                new Skill { Id = 1, Name = "FireBall", Damage = 30 },
                new Skill { Id = 2, Name = "Frenzy", Damage = 50 },
                new Skill { Id = 3, Name = "Blizzard", Damage = 20 },
                new Skill { Id = 4, Name = "Water Cannon", Damage = 10 },
                new Skill { Id = 5, Name = "Frosty", Damage = 40 }
                );

            //seeding the data for Users
            Utitlity.CreatepasswordHash("123456", out byte[] passwordHash, out byte[] passwordSalt);
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, PasswordHash = passwordHash, PasswordSalt = passwordSalt, UserName = "User-1" ,Role="Admin"},
                new User { Id = 2, PasswordHash = passwordHash, PasswordSalt = passwordSalt, UserName = "User-2" , Role = "Player" },
                new User { Id = 3, PasswordHash = passwordHash, PasswordSalt = passwordSalt, UserName = "User-3", Role = "Player" },
                new User { Id = 4, PasswordHash = passwordHash, PasswordSalt = passwordSalt, UserName = "User-4", Role = "Player" }
                );

            modelBuilder.Entity<Character>().HasData(
                new Character { Id = 1, Name = "Frodo", Class = RpgClass.Mage, HitPoints = 100, Strength = 20, Defense = 10, Intelligence = 10, UserId = 2 },
                new Character { Id = 2, Name = "Sword", Class = RpgClass.Knight, HitPoints = 100, Strength = 18, Defense = 10, Intelligence = 10, UserId = 3 },
                new Character { Id = 3, Name = "Hatred", Class = RpgClass.Cleric, HitPoints = 100, Strength = 15, Defense = 10, Intelligence = 9, UserId = 4 },
                new Character { Id = 4, Name = "Legion", Class = RpgClass.Knight, HitPoints = 100, Strength = 19, Defense = 10, Intelligence = 8, UserId = 1 }
                );

            modelBuilder.Entity<Weapon>().HasData(
                new Weapon { Id = 1, name = "Axe", Damage = 30, CharacterId = 4 },
                new Weapon { Id = 2, name = "Spear", Damage = 40, CharacterId = 3 },
                new Weapon { Id = 3, name = "Canon", Damage = 50, CharacterId = 1 },
                new Weapon { Id = 4, name = "Arrow", Damage = 20, CharacterId = 2 }
                );

            modelBuilder.Entity<CharacterSkill>().HasData(
                new CharacterSkill { SkillId = 1,CharacterId = 1 },
                new CharacterSkill { SkillId = 2,CharacterId = 2 },
                new CharacterSkill { SkillId = 3,CharacterId = 3 },
                new CharacterSkill { SkillId = 4,CharacterId = 4 },
                new CharacterSkill { SkillId = 5, CharacterId = 1 }
                

                );
        }

    }
}
