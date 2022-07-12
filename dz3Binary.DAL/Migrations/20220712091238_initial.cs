using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dz3Binary.DAL.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeamId = table.Column<int>(type: "int", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    RegisteredAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BirthDay = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TeamId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Users_Teams_TeamId1",
                        column: x => x.TeamId1,
                        principalTable: "Teams",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AuthorId = table.Column<int>(type: "int", nullable: false),
                    TeamId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deadline = table.Column<DateTime>(type: "datetime2", maxLength: 100, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Projects_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Projects_Users_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    PerformerId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    State = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FinishedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ProjectId1 = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tasks_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tasks_Projects_ProjectId1",
                        column: x => x.ProjectId1,
                        principalTable: "Projects",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tasks_Users_PerformerId",
                        column: x => x.PerformerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tasks_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "CreatedAt", "Name" },
                values: new object[] { 1, new DateTime(2022, 7, 10, 2, 50, 15, 257, DateTimeKind.Local).AddTicks(9675), "Cassin - Murphy" });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "CreatedAt", "Name" },
                values: new object[] { 2, new DateTime(2022, 4, 19, 21, 0, 31, 937, DateTimeKind.Local).AddTicks(4915), "Nolan - Rau" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "BirthDay", "Email", "FirstName", "LastName", "RegisteredAt", "TeamId", "TeamId1" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 6, 1, 0, 13, 19, 373, DateTimeKind.Local).AddTicks(3474), "Meaghan_Watsica@yahoo.com", "Anahi", "Hyatt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, null },
                    { 2, new DateTime(2021, 8, 14, 7, 27, 41, 361, DateTimeKind.Local).AddTicks(989), "Colleen_Feest51@yahoo.com", "Paxton", "Miller", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null },
                    { 3, new DateTime(2021, 11, 10, 16, 55, 31, 486, DateTimeKind.Local).AddTicks(6950), "Cielo.Roberts@gmail.com", "Omari", "Funk", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, null },
                    { 4, new DateTime(2021, 8, 21, 11, 54, 44, 16, DateTimeKind.Local).AddTicks(7842), "Mallie_Bechtelar@yahoo.com", "Conrad", "Lang", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null },
                    { 5, new DateTime(2021, 11, 24, 2, 46, 53, 295, DateTimeKind.Local).AddTicks(9520), "Norwood.Murazik37@hotmail.com", "Eliezer", "Quitzon", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "AuthorId", "CreatedAt", "Deadline", "Description", "Name", "TeamId" },
                values: new object[] { 1, 2, new DateTime(2022, 3, 20, 1, 42, 18, 353, DateTimeKind.Local).AddTicks(4792), new DateTime(2022, 8, 27, 10, 9, 17, 708, DateTimeKind.Local).AddTicks(8451), "Aut impedit nihil cum dolores consequatur maxime.", "Paradigm", 2 });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "AuthorId", "CreatedAt", "Deadline", "Description", "Name", "TeamId" },
                values: new object[] { 2, 2, new DateTime(2022, 2, 11, 11, 28, 16, 681, DateTimeKind.Local).AddTicks(5790), new DateTime(2022, 11, 11, 13, 56, 40, 276, DateTimeKind.Local).AddTicks(7181), "Id qui ullam ducimus ex ut aliquam.", "Mobility", 1 });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "AuthorId", "CreatedAt", "Deadline", "Description", "Name", "TeamId" },
                values: new object[] { 3, 4, new DateTime(2021, 11, 18, 12, 49, 6, 588, DateTimeKind.Local).AddTicks(4401), new DateTime(2023, 1, 10, 17, 29, 28, 457, DateTimeKind.Local).AddTicks(3528), "Minus totam eos nam voluptas neque consectetur.", "Optimization", 1 });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "CreatedAt", "Description", "FinishedAt", "Name", "PerformerId", "ProjectId", "ProjectId1", "State", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 10, 19, 11, 41, 56, 824, DateTimeKind.Local).AddTicks(9676), "Qui sit ea eaque repellat.", null, "Maudie", 2, 3, null, 2, null },
                    { 2, new DateTime(2021, 10, 14, 7, 56, 52, 425, DateTimeKind.Local).AddTicks(7705), "Voluptatem nemo in fuga itaque.", null, "Leann", 3, 3, null, 1, null },
                    { 3, new DateTime(2022, 5, 29, 15, 44, 41, 788, DateTimeKind.Local).AddTicks(7811), "Aut consequatur est quia inventore.", new DateTime(2022, 5, 7, 12, 33, 47, 717, DateTimeKind.Local).AddTicks(8826), "Percival", 2, 1, null, 0, null },
                    { 4, new DateTime(2021, 12, 17, 4, 28, 10, 600, DateTimeKind.Local).AddTicks(1459), "Velit tempora saepe est iure.", new DateTime(2022, 1, 18, 17, 16, 24, 372, DateTimeKind.Local).AddTicks(2542), "Ethyl", 5, 2, null, 2, null },
                    { 5, new DateTime(2022, 1, 30, 0, 35, 6, 971, DateTimeKind.Local).AddTicks(1038), "Sit harum sint sit laboriosam.", new DateTime(2022, 2, 17, 23, 36, 0, 95, DateTimeKind.Local).AddTicks(5374), "Lina", 2, 1, null, 3, null },
                    { 6, new DateTime(2022, 7, 1, 22, 21, 3, 236, DateTimeKind.Local).AddTicks(7798), "Quasi illo perspiciatis sit ea.", null, "Alverta", 5, 2, null, 3, null },
                    { 7, new DateTime(2022, 6, 26, 20, 28, 46, 872, DateTimeKind.Local).AddTicks(6515), "Consequatur consectetur velit odio aut.", new DateTime(2021, 9, 24, 17, 34, 23, 588, DateTimeKind.Local).AddTicks(9517), "Garnett", 4, 3, null, 0, null },
                    { 8, new DateTime(2022, 2, 1, 4, 50, 29, 710, DateTimeKind.Local).AddTicks(1588), "Nam voluptas ut non sit.", null, "Magnus", 4, 2, null, 0, null },
                    { 9, new DateTime(2021, 9, 25, 23, 5, 33, 476, DateTimeKind.Local).AddTicks(5947), "Aut itaque totam qui ab.", new DateTime(2022, 6, 19, 9, 8, 29, 720, DateTimeKind.Local).AddTicks(8091), "Tom", 2, 1, null, 1, null },
                    { 10, new DateTime(2022, 2, 6, 9, 38, 6, 146, DateTimeKind.Local).AddTicks(6594), "Aut tenetur vel possimus non.", new DateTime(2022, 3, 27, 15, 50, 55, 979, DateTimeKind.Local).AddTicks(4880), "Alexzander", 4, 1, null, 0, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Projects_AuthorId",
                table: "Projects",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_TeamId",
                table: "Projects",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_PerformerId",
                table: "Tasks",
                column: "PerformerId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_ProjectId",
                table: "Tasks",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_ProjectId1",
                table: "Tasks",
                column: "ProjectId1");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_UserId",
                table: "Tasks",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_TeamId",
                table: "Users",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_TeamId1",
                table: "Users",
                column: "TeamId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Teams");
        }
    }
}
