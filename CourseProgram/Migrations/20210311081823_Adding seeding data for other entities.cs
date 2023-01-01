using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CourseProgram.Migrations
{
    public partial class Addingseedingdataforotherentities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Damage = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserName = table.Column<string>(type: "TEXT", nullable: true),
                    PasswordHash = table.Column<byte[]>(type: "BLOB", nullable: true),
                    PasswordSalt = table.Column<byte[]>(type: "BLOB", nullable: true),
                    Role = table.Column<string>(type: "TEXT", nullable: false, defaultValue: "Player")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Characters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    HitPoints = table.Column<int>(type: "INTEGER", nullable: false),
                    Strength = table.Column<int>(type: "INTEGER", nullable: false),
                    Defense = table.Column<int>(type: "INTEGER", nullable: false),
                    Intelligence = table.Column<int>(type: "INTEGER", nullable: false),
                    Class = table.Column<int>(type: "INTEGER", nullable: false),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    Fights = table.Column<int>(type: "INTEGER", nullable: false),
                    Victories = table.Column<int>(type: "INTEGER", nullable: false),
                    Defeats = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Characters_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CharacterSkills",
                columns: table => new
                {
                    CharacterId = table.Column<int>(type: "INTEGER", nullable: false),
                    SkillId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterSkills", x => new { x.CharacterId, x.SkillId });
                    table.ForeignKey(
                        name: "FK_CharacterSkills_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharacterSkills_Skills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Weapons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(type: "TEXT", nullable: true),
                    Damage = table.Column<int>(type: "INTEGER", nullable: false),
                    CharacterId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weapons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Weapons_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "Damage", "Name" },
                values: new object[] { 1, 30, "FireBall" });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "Damage", "Name" },
                values: new object[] { 2, 50, "Frenzy" });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "Damage", "Name" },
                values: new object[] { 3, 20, "Blizzard" });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "Damage", "Name" },
                values: new object[] { 4, 10, "Water Cannon" });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "Damage", "Name" },
                values: new object[] { 5, 40, "Frosty" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "PasswordHash", "PasswordSalt", "Role", "UserName" },
                values: new object[] { 1, new byte[] { 250, 139, 250, 176, 213, 91, 6, 126, 203, 212, 139, 6, 240, 112, 95, 89, 241, 62, 160, 190, 249, 164, 234, 107, 156, 189, 5, 45, 16, 145, 163, 27, 178, 61, 199, 179, 81, 121, 46, 183, 242, 138, 154, 36, 72, 130, 146, 58, 73, 198, 254, 29, 186, 56, 141, 189, 116, 197, 169, 219, 105, 1, 17, 209 }, new byte[] { 10, 227, 22, 77, 47, 207, 184, 25, 83, 92, 244, 31, 249, 202, 226, 169, 183, 61, 224, 147, 70, 114, 62, 185, 21, 176, 201, 82, 102, 213, 130, 142, 184, 119, 162, 99, 255, 191, 220, 162, 160, 53, 76, 48, 71, 85, 214, 117, 128, 152, 195, 68, 183, 45, 221, 111, 213, 132, 187, 66, 17, 199, 140, 22, 65, 88, 138, 38, 150, 123, 84, 187, 205, 88, 145, 30, 11, 186, 193, 134, 168, 17, 108, 247, 243, 57, 29, 252, 201, 119, 41, 229, 8, 5, 38, 119, 166, 219, 167, 14, 59, 162, 34, 72, 126, 197, 66, 248, 190, 25, 221, 117, 58, 244, 221, 210, 123, 37, 201, 103, 64, 26, 80, 232, 40, 138, 225, 99 }, "Admin", "User-1" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "PasswordHash", "PasswordSalt", "Role", "UserName" },
                values: new object[] { 2, new byte[] { 250, 139, 250, 176, 213, 91, 6, 126, 203, 212, 139, 6, 240, 112, 95, 89, 241, 62, 160, 190, 249, 164, 234, 107, 156, 189, 5, 45, 16, 145, 163, 27, 178, 61, 199, 179, 81, 121, 46, 183, 242, 138, 154, 36, 72, 130, 146, 58, 73, 198, 254, 29, 186, 56, 141, 189, 116, 197, 169, 219, 105, 1, 17, 209 }, new byte[] { 10, 227, 22, 77, 47, 207, 184, 25, 83, 92, 244, 31, 249, 202, 226, 169, 183, 61, 224, 147, 70, 114, 62, 185, 21, 176, 201, 82, 102, 213, 130, 142, 184, 119, 162, 99, 255, 191, 220, 162, 160, 53, 76, 48, 71, 85, 214, 117, 128, 152, 195, 68, 183, 45, 221, 111, 213, 132, 187, 66, 17, 199, 140, 22, 65, 88, 138, 38, 150, 123, 84, 187, 205, 88, 145, 30, 11, 186, 193, 134, 168, 17, 108, 247, 243, 57, 29, 252, 201, 119, 41, 229, 8, 5, 38, 119, 166, 219, 167, 14, 59, 162, 34, 72, 126, 197, 66, 248, 190, 25, 221, 117, 58, 244, 221, 210, 123, 37, 201, 103, 64, 26, 80, 232, 40, 138, 225, 99 }, "Player", "User-2" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "PasswordHash", "PasswordSalt", "Role", "UserName" },
                values: new object[] { 3, new byte[] { 250, 139, 250, 176, 213, 91, 6, 126, 203, 212, 139, 6, 240, 112, 95, 89, 241, 62, 160, 190, 249, 164, 234, 107, 156, 189, 5, 45, 16, 145, 163, 27, 178, 61, 199, 179, 81, 121, 46, 183, 242, 138, 154, 36, 72, 130, 146, 58, 73, 198, 254, 29, 186, 56, 141, 189, 116, 197, 169, 219, 105, 1, 17, 209 }, new byte[] { 10, 227, 22, 77, 47, 207, 184, 25, 83, 92, 244, 31, 249, 202, 226, 169, 183, 61, 224, 147, 70, 114, 62, 185, 21, 176, 201, 82, 102, 213, 130, 142, 184, 119, 162, 99, 255, 191, 220, 162, 160, 53, 76, 48, 71, 85, 214, 117, 128, 152, 195, 68, 183, 45, 221, 111, 213, 132, 187, 66, 17, 199, 140, 22, 65, 88, 138, 38, 150, 123, 84, 187, 205, 88, 145, 30, 11, 186, 193, 134, 168, 17, 108, 247, 243, 57, 29, 252, 201, 119, 41, 229, 8, 5, 38, 119, 166, 219, 167, 14, 59, 162, 34, 72, 126, 197, 66, 248, 190, 25, 221, 117, 58, 244, 221, 210, 123, 37, 201, 103, 64, 26, 80, 232, 40, 138, 225, 99 }, "Player", "User-3" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "PasswordHash", "PasswordSalt", "Role", "UserName" },
                values: new object[] { 4, new byte[] { 250, 139, 250, 176, 213, 91, 6, 126, 203, 212, 139, 6, 240, 112, 95, 89, 241, 62, 160, 190, 249, 164, 234, 107, 156, 189, 5, 45, 16, 145, 163, 27, 178, 61, 199, 179, 81, 121, 46, 183, 242, 138, 154, 36, 72, 130, 146, 58, 73, 198, 254, 29, 186, 56, 141, 189, 116, 197, 169, 219, 105, 1, 17, 209 }, new byte[] { 10, 227, 22, 77, 47, 207, 184, 25, 83, 92, 244, 31, 249, 202, 226, 169, 183, 61, 224, 147, 70, 114, 62, 185, 21, 176, 201, 82, 102, 213, 130, 142, 184, 119, 162, 99, 255, 191, 220, 162, 160, 53, 76, 48, 71, 85, 214, 117, 128, 152, 195, 68, 183, 45, 221, 111, 213, 132, 187, 66, 17, 199, 140, 22, 65, 88, 138, 38, 150, 123, 84, 187, 205, 88, 145, 30, 11, 186, 193, 134, 168, 17, 108, 247, 243, 57, 29, 252, 201, 119, 41, 229, 8, 5, 38, 119, 166, 219, 167, 14, 59, 162, 34, 72, 126, 197, 66, 248, 190, 25, 221, 117, 58, 244, 221, 210, 123, 37, 201, 103, 64, 26, 80, 232, 40, 138, 225, 99 }, "Player", "User-4" });

            migrationBuilder.InsertData(
                table: "Characters",
                columns: new[] { "Id", "Class", "Defeats", "Defense", "Fights", "HitPoints", "Intelligence", "Name", "Strength", "UserId", "Victories" },
                values: new object[] { 4, 1, 0, 10, 0, 100, 8, "Legion", 19, 1, 0 });

            migrationBuilder.InsertData(
                table: "Characters",
                columns: new[] { "Id", "Class", "Defeats", "Defense", "Fights", "HitPoints", "Intelligence", "Name", "Strength", "UserId", "Victories" },
                values: new object[] { 1, 2, 0, 10, 0, 100, 10, "Frodo", 20, 2, 0 });

            migrationBuilder.InsertData(
                table: "Characters",
                columns: new[] { "Id", "Class", "Defeats", "Defense", "Fights", "HitPoints", "Intelligence", "Name", "Strength", "UserId", "Victories" },
                values: new object[] { 2, 1, 0, 10, 0, 100, 10, "Sword", 18, 3, 0 });

            migrationBuilder.InsertData(
                table: "Characters",
                columns: new[] { "Id", "Class", "Defeats", "Defense", "Fights", "HitPoints", "Intelligence", "Name", "Strength", "UserId", "Victories" },
                values: new object[] { 3, 3, 0, 10, 0, 100, 9, "Hatred", 15, 4, 0 });

            migrationBuilder.InsertData(
                table: "CharacterSkills",
                columns: new[] { "CharacterId", "SkillId" },
                values: new object[] { 4, 4 });

            migrationBuilder.InsertData(
                table: "CharacterSkills",
                columns: new[] { "CharacterId", "SkillId" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "CharacterSkills",
                columns: new[] { "CharacterId", "SkillId" },
                values: new object[] { 1, 5 });

            migrationBuilder.InsertData(
                table: "CharacterSkills",
                columns: new[] { "CharacterId", "SkillId" },
                values: new object[] { 2, 2 });

            migrationBuilder.InsertData(
                table: "CharacterSkills",
                columns: new[] { "CharacterId", "SkillId" },
                values: new object[] { 3, 3 });

            migrationBuilder.InsertData(
                table: "Weapons",
                columns: new[] { "Id", "CharacterId", "Damage", "name" },
                values: new object[] { 1, 4, 30, "Axe" });

            migrationBuilder.InsertData(
                table: "Weapons",
                columns: new[] { "Id", "CharacterId", "Damage", "name" },
                values: new object[] { 3, 1, 50, "Canon" });

            migrationBuilder.InsertData(
                table: "Weapons",
                columns: new[] { "Id", "CharacterId", "Damage", "name" },
                values: new object[] { 4, 2, 20, "Arrow" });

            migrationBuilder.InsertData(
                table: "Weapons",
                columns: new[] { "Id", "CharacterId", "Damage", "name" },
                values: new object[] { 2, 3, 40, "Spear" });

            migrationBuilder.CreateIndex(
                name: "IX_Characters_UserId",
                table: "Characters",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterSkills_SkillId",
                table: "CharacterSkills",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_Weapons_CharacterId",
                table: "Weapons",
                column: "CharacterId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CharacterSkills");

            migrationBuilder.DropTable(
                name: "Weapons");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropTable(
                name: "Characters");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
