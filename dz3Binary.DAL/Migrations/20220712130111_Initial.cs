using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dz3Binary.DAL.Migrations
{
    public partial class Initial : Migration
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
                    BirthDay = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                    RenamedName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    State = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FinishedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
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
                values: new object[] { 1, new DateTime(2021, 11, 4, 5, 44, 44, 388, DateTimeKind.Local).AddTicks(4973), "Dibbert - Fritsch" });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "CreatedAt", "Name" },
                values: new object[] { 2, new DateTime(2021, 12, 3, 17, 50, 9, 661, DateTimeKind.Local).AddTicks(1570), "Mayert - Block" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "BirthDay", "Email", "FirstName", "LastName", "RegisteredAt", "TeamId" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 8, 20, 17, 28, 45, 981, DateTimeKind.Local).AddTicks(6979), "Sven_Goldner18@yahoo.com", "Danielle", "Nitzsche", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 2, new DateTime(2022, 5, 14, 2, 47, 40, 984, DateTimeKind.Local).AddTicks(4786), "Jensen.Goldner39@gmail.com", "Jacklyn", "Mohr", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 3, new DateTime(2022, 7, 1, 5, 23, 23, 160, DateTimeKind.Local).AddTicks(7612), "Maye.Kiehn79@yahoo.com", "Ruby", "Farrell", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 4, new DateTime(2021, 10, 10, 8, 14, 1, 869, DateTimeKind.Local).AddTicks(9169), "Agustin88@hotmail.com", "Viola", "Hand", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 5, new DateTime(2021, 11, 18, 19, 45, 31, 806, DateTimeKind.Local).AddTicks(4507), "Winston_Kirlin@yahoo.com", "Fletcher", "Williamson", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 6, new DateTime(2021, 11, 28, 0, 3, 37, 682, DateTimeKind.Local).AddTicks(2740), "Talon55@gmail.com", "Greyson", "Streich", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 7, new DateTime(2022, 2, 11, 12, 48, 55, 217, DateTimeKind.Local).AddTicks(1745), "Jean59@gmail.com", "Kendrick", "Pouros", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 8, new DateTime(2021, 8, 23, 3, 56, 35, 946, DateTimeKind.Local).AddTicks(2435), "Ricardo81@yahoo.com", "Gregorio", "Doyle", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 9, new DateTime(2022, 6, 11, 15, 30, 53, 282, DateTimeKind.Local).AddTicks(8595), "Wilfrid_Hackett@yahoo.com", "Bryce", "Kuvalis", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 10, new DateTime(2021, 9, 16, 22, 35, 17, 144, DateTimeKind.Local).AddTicks(3837), "Vito_Schneider63@hotmail.com", "Catalina", "Moen", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 11, new DateTime(2021, 8, 6, 15, 2, 4, 26, DateTimeKind.Local).AddTicks(5476), "Jayde79@gmail.com", "Roderick", "Kutch", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 12, new DateTime(2022, 6, 20, 5, 49, 43, 781, DateTimeKind.Local).AddTicks(5044), "Pauline.Yundt39@gmail.com", "Newell", "Gleichner", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 13, new DateTime(2022, 1, 3, 12, 1, 44, 516, DateTimeKind.Local).AddTicks(6657), "Jaren.Rippin@yahoo.com", "Virgie", "Rohan", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 14, new DateTime(2022, 2, 16, 10, 9, 25, 798, DateTimeKind.Local).AddTicks(4380), "Ed_Mann@hotmail.com", "Gayle", "Muller", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 15, new DateTime(2021, 8, 31, 9, 54, 4, 130, DateTimeKind.Local).AddTicks(2829), "Austyn.Fisher49@hotmail.com", "Addison", "Hoppe", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 16, new DateTime(2021, 11, 15, 16, 22, 23, 978, DateTimeKind.Local).AddTicks(9041), "Milton_Mosciski@gmail.com", "Clair", "Kuhn", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 17, new DateTime(2022, 4, 21, 22, 29, 27, 839, DateTimeKind.Local).AddTicks(1644), "Austen.Dare72@hotmail.com", "Britney", "Schimmel", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 18, new DateTime(2021, 11, 21, 10, 11, 23, 354, DateTimeKind.Local).AddTicks(9757), "Annetta.Effertz@yahoo.com", "Elroy", "Abernathy", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 19, new DateTime(2022, 7, 7, 0, 38, 12, 206, DateTimeKind.Local).AddTicks(2502), "Rolando7@hotmail.com", "Josefina", "Hettinger", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 20, new DateTime(2021, 12, 4, 3, 4, 10, 385, DateTimeKind.Local).AddTicks(3691), "Marjolaine.Satterfield@gmail.com", "Neva", "O'Hara", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 21, new DateTime(2022, 3, 10, 12, 21, 5, 52, DateTimeKind.Local).AddTicks(902), "Oswaldo97@yahoo.com", "Ettie", "Ziemann", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 22, new DateTime(2021, 12, 28, 3, 8, 55, 901, DateTimeKind.Local).AddTicks(7622), "Arlie89@gmail.com", "Hans", "Jacobson", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 23, new DateTime(2021, 12, 20, 9, 20, 52, 306, DateTimeKind.Local).AddTicks(9015), "Mikayla21@yahoo.com", "Kristy", "Huels", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 24, new DateTime(2021, 10, 25, 13, 45, 34, 803, DateTimeKind.Local).AddTicks(5193), "Perry71@hotmail.com", "Jaquan", "Lang", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 25, new DateTime(2022, 6, 15, 4, 38, 35, 298, DateTimeKind.Local).AddTicks(6290), "Jayce32@hotmail.com", "Una", "Macejkovic", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 26, new DateTime(2021, 9, 14, 12, 41, 9, 550, DateTimeKind.Local).AddTicks(2315), "Frederik59@yahoo.com", "Nelle", "Feil", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 27, new DateTime(2022, 7, 5, 19, 49, 3, 818, DateTimeKind.Local).AddTicks(5866), "Elna_Streich79@gmail.com", "Dora", "Veum", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 28, new DateTime(2022, 1, 30, 12, 44, 17, 897, DateTimeKind.Local).AddTicks(2857), "Bradford34@hotmail.com", "Lucious", "Johns", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 29, new DateTime(2021, 8, 26, 10, 36, 57, 226, DateTimeKind.Local).AddTicks(87), "Jasper_Price61@hotmail.com", "Charity", "Treutel", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 30, new DateTime(2021, 12, 7, 2, 48, 18, 595, DateTimeKind.Local).AddTicks(5275), "Juliana_Bernier18@hotmail.com", "Andy", "Bailey", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "AuthorId", "CreatedAt", "Deadline", "Description", "Name", "TeamId" },
                values: new object[,]
                {
                    { 1, 9, new DateTime(2022, 1, 14, 0, 1, 22, 950, DateTimeKind.Local).AddTicks(8054), new DateTime(2022, 9, 27, 21, 32, 6, 907, DateTimeKind.Local).AddTicks(1109), "Non doloremque esse qui et alias quidem.", "Web", 2 },
                    { 2, 26, new DateTime(2021, 10, 8, 22, 25, 31, 759, DateTimeKind.Local).AddTicks(6339), new DateTime(2022, 12, 9, 17, 26, 20, 912, DateTimeKind.Local).AddTicks(9045), "Quo totam laboriosam debitis veniam occaecati sed.", "Usability", 2 },
                    { 3, 15, new DateTime(2022, 6, 22, 16, 34, 34, 943, DateTimeKind.Local).AddTicks(3136), new DateTime(2022, 8, 30, 23, 5, 2, 21, DateTimeKind.Local).AddTicks(3531), "Magni necessitatibus quos quia illum qui et.", "Assurance", 1 },
                    { 4, 2, new DateTime(2022, 3, 17, 15, 40, 36, 249, DateTimeKind.Local).AddTicks(821), new DateTime(2022, 12, 5, 19, 57, 26, 852, DateTimeKind.Local).AddTicks(8239), "Aspernatur sint harum expedita incidunt amet amet.", "Communications", 1 },
                    { 5, 21, new DateTime(2021, 12, 28, 17, 26, 44, 75, DateTimeKind.Local).AddTicks(9519), new DateTime(2023, 1, 21, 19, 47, 56, 328, DateTimeKind.Local).AddTicks(3618), "Vitae ut tempora inventore consequuntur rerum libero.", "Security", 2 },
                    { 6, 14, new DateTime(2021, 7, 28, 17, 33, 0, 152, DateTimeKind.Local).AddTicks(5072), new DateTime(2022, 12, 16, 19, 27, 7, 619, DateTimeKind.Local).AddTicks(9985), "Iusto dicta qui consectetur nisi culpa expedita.", "Marketing", 2 },
                    { 7, 7, new DateTime(2022, 4, 20, 9, 37, 35, 659, DateTimeKind.Local).AddTicks(6915), new DateTime(2022, 12, 27, 4, 27, 18, 741, DateTimeKind.Local).AddTicks(4831), "Ea velit est et fugiat quisquam velit.", "Branding", 2 },
                    { 8, 20, new DateTime(2022, 2, 7, 16, 51, 53, 253, DateTimeKind.Local).AddTicks(6572), new DateTime(2023, 5, 19, 15, 11, 33, 121, DateTimeKind.Local).AddTicks(65), "Totam eaque natus exercitationem est possimus est.", "Usability", 2 },
                    { 9, 30, new DateTime(2021, 8, 1, 15, 57, 11, 393, DateTimeKind.Local).AddTicks(7350), new DateTime(2022, 10, 31, 14, 10, 14, 178, DateTimeKind.Local).AddTicks(3635), "Laudantium rem sunt labore temporibus tempora facilis.", "Implementation", 2 },
                    { 10, 6, new DateTime(2022, 1, 6, 7, 42, 20, 431, DateTimeKind.Local).AddTicks(3336), new DateTime(2022, 8, 27, 12, 22, 11, 75, DateTimeKind.Local).AddTicks(6377), "Voluptatem facilis cum dolorum molestias mollitia quas.", "Factors", 2 },
                    { 11, 30, new DateTime(2022, 5, 20, 21, 32, 51, 656, DateTimeKind.Local).AddTicks(381), new DateTime(2023, 2, 5, 18, 35, 3, 257, DateTimeKind.Local).AddTicks(4763), "Non eligendi rerum iste commodi at sed.", "Mobility", 2 },
                    { 12, 4, new DateTime(2021, 12, 12, 5, 56, 23, 57, DateTimeKind.Local).AddTicks(5569), new DateTime(2023, 5, 3, 16, 13, 50, 819, DateTimeKind.Local).AddTicks(4213), "Necessitatibus temporibus ut temporibus neque asperiores assumenda.", "Communications", 2 },
                    { 13, 21, new DateTime(2022, 3, 16, 1, 40, 30, 36, DateTimeKind.Local).AddTicks(9806), new DateTime(2023, 4, 1, 18, 14, 12, 688, DateTimeKind.Local).AddTicks(8174), "Iusto culpa repellat suscipit voluptas a recusandae.", "Data", 2 },
                    { 14, 26, new DateTime(2022, 3, 15, 8, 40, 3, 104, DateTimeKind.Local).AddTicks(4219), new DateTime(2023, 4, 13, 2, 15, 37, 430, DateTimeKind.Local).AddTicks(14), "Aut eos rerum quidem magnam officiis ipsum.", "Paradigm", 1 },
                    { 15, 17, new DateTime(2021, 12, 7, 5, 6, 45, 846, DateTimeKind.Local).AddTicks(524), new DateTime(2023, 1, 5, 16, 39, 29, 297, DateTimeKind.Local).AddTicks(9709), "Quia fugit voluptatem voluptas quasi maiores animi.", "Accounts", 1 },
                    { 16, 20, new DateTime(2021, 8, 30, 8, 50, 46, 212, DateTimeKind.Local).AddTicks(7829), new DateTime(2023, 4, 22, 20, 14, 39, 751, DateTimeKind.Local).AddTicks(9027), "Ea saepe quis non animi necessitatibus sit.", "Configuration", 2 },
                    { 17, 12, new DateTime(2022, 3, 13, 18, 21, 31, 898, DateTimeKind.Local).AddTicks(9358), new DateTime(2023, 1, 22, 0, 43, 12, 372, DateTimeKind.Local).AddTicks(1774), "Quia aut modi at ipsam molestiae aut.", "Optimization", 2 },
                    { 18, 19, new DateTime(2022, 1, 9, 17, 10, 33, 506, DateTimeKind.Local).AddTicks(2756), new DateTime(2022, 8, 7, 22, 5, 18, 935, DateTimeKind.Local).AddTicks(8303), "Autem inventore id sequi dolorum velit aliquid.", "Security", 2 },
                    { 19, 30, new DateTime(2022, 5, 28, 18, 23, 38, 712, DateTimeKind.Local).AddTicks(4355), new DateTime(2022, 10, 28, 18, 42, 28, 770, DateTimeKind.Local).AddTicks(9742), "Quia a porro nisi praesentium libero voluptatum.", "Factors", 1 },
                    { 20, 11, new DateTime(2022, 5, 8, 18, 4, 19, 302, DateTimeKind.Local).AddTicks(2120), new DateTime(2022, 10, 23, 20, 57, 33, 529, DateTimeKind.Local).AddTicks(834), "Dolor qui deserunt facilis repudiandae inventore et.", "Mobility", 2 }
                });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "CreatedAt", "Description", "FinishedAt", "PerformerId", "ProjectId", "RenamedName", "State", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 4, 19, 7, 5, 50, 14, DateTimeKind.Local).AddTicks(2214), "Aliquam minima est velit aut.", new DateTime(2021, 9, 13, 1, 32, 10, 217, DateTimeKind.Local).AddTicks(6472), 30, 1, "Burnice", 2, null },
                    { 2, new DateTime(2022, 5, 18, 21, 54, 7, 954, DateTimeKind.Local).AddTicks(7715), "Doloribus placeat aliquid sequi quis.", new DateTime(2021, 9, 22, 13, 39, 34, 242, DateTimeKind.Local).AddTicks(1234), 17, 7, "Glenna", 3, null },
                    { 3, new DateTime(2022, 5, 4, 21, 46, 48, 737, DateTimeKind.Local).AddTicks(7314), "Aut cum voluptates provident aut.", new DateTime(2021, 11, 30, 13, 16, 0, 187, DateTimeKind.Local).AddTicks(5743), 7, 3, "Emilio", 2, null },
                    { 4, new DateTime(2021, 8, 30, 21, 22, 57, 739, DateTimeKind.Local).AddTicks(6794), "Quia ex sint quia necessitatibus.", new DateTime(2021, 11, 20, 10, 38, 5, 933, DateTimeKind.Local).AddTicks(675), 19, 13, "Merlin", 2, null },
                    { 5, new DateTime(2022, 1, 13, 20, 51, 39, 746, DateTimeKind.Local).AddTicks(8618), "Minima cupiditate dolores rerum veritatis.", new DateTime(2021, 12, 26, 13, 22, 45, 192, DateTimeKind.Local).AddTicks(869), 13, 1, "Mervin", 3, null },
                    { 6, new DateTime(2021, 11, 9, 20, 7, 24, 346, DateTimeKind.Local).AddTicks(5026), "Explicabo debitis aut autem maiores.", null, 18, 10, "Gerald", 1, null },
                    { 7, new DateTime(2021, 10, 3, 3, 50, 57, 396, DateTimeKind.Local).AddTicks(7581), "Voluptatem provident eaque et aperiam.", new DateTime(2022, 1, 6, 5, 58, 38, 559, DateTimeKind.Local).AddTicks(9701), 21, 1, "Jeff", 0, null },
                    { 8, new DateTime(2021, 11, 15, 13, 59, 42, 267, DateTimeKind.Local).AddTicks(3500), "Blanditiis iure et quaerat quo.", new DateTime(2021, 10, 5, 11, 54, 9, 861, DateTimeKind.Local).AddTicks(9177), 12, 20, "Geoffrey", 3, null },
                    { 9, new DateTime(2022, 1, 29, 21, 29, 32, 635, DateTimeKind.Local).AddTicks(4254), "Quibusdam similique deserunt velit harum.", new DateTime(2022, 7, 6, 21, 27, 53, 199, DateTimeKind.Local).AddTicks(7469), 29, 16, "Lavina", 1, null },
                    { 10, new DateTime(2022, 1, 11, 17, 23, 34, 727, DateTimeKind.Local).AddTicks(5819), "Quia et esse eum sit.", new DateTime(2021, 7, 21, 7, 36, 57, 67, DateTimeKind.Local).AddTicks(7141), 14, 15, "Carter", 0, null },
                    { 11, new DateTime(2022, 5, 31, 6, 6, 58, 577, DateTimeKind.Local).AddTicks(8160), "Facilis rerum voluptatem quod voluptate.", null, 19, 15, "Carolina", 1, null },
                    { 12, new DateTime(2022, 5, 1, 6, 15, 39, 474, DateTimeKind.Local).AddTicks(9691), "Ipsam incidunt neque beatae omnis.", new DateTime(2022, 3, 26, 17, 37, 1, 520, DateTimeKind.Local).AddTicks(141), 21, 15, "Verlie", 2, null },
                    { 13, new DateTime(2021, 8, 27, 8, 25, 22, 516, DateTimeKind.Local).AddTicks(63), "Non sunt labore eligendi quam.", new DateTime(2021, 11, 10, 5, 30, 10, 883, DateTimeKind.Local).AddTicks(7943), 21, 1, "Nathanael", 3, null },
                    { 14, new DateTime(2022, 6, 6, 1, 54, 59, 313, DateTimeKind.Local).AddTicks(5895), "Aut aut sit tenetur repellat.", new DateTime(2022, 3, 25, 18, 45, 19, 133, DateTimeKind.Local).AddTicks(8842), 16, 3, "Tyler", 2, null },
                    { 15, new DateTime(2021, 8, 22, 1, 26, 49, 395, DateTimeKind.Local).AddTicks(8484), "Alias perferendis quod nisi autem.", null, 1, 11, "Imogene", 2, null },
                    { 16, new DateTime(2021, 12, 5, 8, 19, 7, 517, DateTimeKind.Local).AddTicks(9080), "Sed nam qui eaque qui.", null, 26, 18, "Otha", 2, null },
                    { 17, new DateTime(2022, 5, 22, 12, 19, 6, 146, DateTimeKind.Local).AddTicks(1597), "Iure numquam aut repellendus quis.", new DateTime(2021, 9, 8, 17, 50, 47, 490, DateTimeKind.Local).AddTicks(3232), 15, 1, "Taurean", 0, null },
                    { 18, new DateTime(2022, 5, 30, 3, 52, 28, 317, DateTimeKind.Local).AddTicks(9602), "Iusto laborum saepe aut qui.", null, 25, 14, "Friedrich", 2, null },
                    { 19, new DateTime(2022, 1, 26, 15, 17, 25, 936, DateTimeKind.Local).AddTicks(1551), "Ratione optio quaerat ut quaerat.", null, 27, 11, "Nico", 0, null },
                    { 20, new DateTime(2021, 11, 7, 8, 42, 53, 363, DateTimeKind.Local).AddTicks(5723), "Qui fuga similique quia beatae.", new DateTime(2021, 12, 6, 20, 21, 9, 928, DateTimeKind.Local).AddTicks(8190), 12, 2, "Josiah", 2, null },
                    { 21, new DateTime(2022, 5, 21, 20, 42, 20, 891, DateTimeKind.Local).AddTicks(9309), "Aut autem vel quis officiis.", new DateTime(2022, 4, 22, 1, 53, 9, 814, DateTimeKind.Local).AddTicks(2518), 26, 19, "Jarred", 3, null },
                    { 22, new DateTime(2021, 8, 4, 16, 36, 52, 7, DateTimeKind.Local).AddTicks(5878), "Sed repudiandae rerum est facilis.", new DateTime(2021, 7, 17, 8, 24, 38, 345, DateTimeKind.Local).AddTicks(300), 19, 12, "Arch", 0, null },
                    { 23, new DateTime(2021, 7, 21, 11, 39, 24, 649, DateTimeKind.Local).AddTicks(7951), "Quos veritatis aut expedita ducimus.", new DateTime(2022, 5, 12, 17, 6, 41, 418, DateTimeKind.Local).AddTicks(8207), 2, 7, "Ervin", 2, null },
                    { 24, new DateTime(2021, 7, 20, 2, 15, 38, 433, DateTimeKind.Local).AddTicks(8169), "Dolorem dolores reiciendis dolor quos.", null, 5, 6, "Camryn", 2, null },
                    { 25, new DateTime(2021, 11, 23, 0, 34, 50, 315, DateTimeKind.Local).AddTicks(1328), "Et eos quibusdam quia consequatur.", new DateTime(2022, 2, 9, 17, 35, 34, 609, DateTimeKind.Local).AddTicks(9054), 11, 17, "Malinda", 3, null },
                    { 26, new DateTime(2021, 7, 15, 10, 16, 30, 295, DateTimeKind.Local).AddTicks(726), "Accusantium praesentium aut suscipit id.", new DateTime(2021, 9, 16, 0, 42, 37, 972, DateTimeKind.Local).AddTicks(2374), 1, 1, "Christine", 3, null },
                    { 27, new DateTime(2022, 1, 2, 5, 21, 30, 674, DateTimeKind.Local).AddTicks(1755), "Sed minima ex ut doloremque.", new DateTime(2021, 7, 19, 2, 40, 46, 916, DateTimeKind.Local).AddTicks(4552), 22, 17, "Art", 2, null },
                    { 28, new DateTime(2022, 4, 21, 20, 22, 1, 679, DateTimeKind.Local).AddTicks(4657), "In sint est aut sunt.", null, 28, 7, "Norene", 2, null },
                    { 29, new DateTime(2022, 5, 15, 12, 37, 3, 173, DateTimeKind.Local).AddTicks(4134), "Totam dolore ullam omnis excepturi.", null, 26, 7, "Alphonso", 0, null },
                    { 30, new DateTime(2021, 9, 2, 0, 9, 27, 948, DateTimeKind.Local).AddTicks(3083), "Voluptatem tenetur et eligendi architecto.", null, 3, 2, "Odie", 2, null },
                    { 31, new DateTime(2022, 3, 20, 3, 45, 15, 748, DateTimeKind.Local).AddTicks(2560), "Distinctio aut voluptatem accusantium aperiam.", new DateTime(2022, 3, 23, 9, 37, 28, 335, DateTimeKind.Local).AddTicks(9677), 1, 6, "Mathilde", 3, null },
                    { 32, new DateTime(2021, 7, 17, 8, 12, 53, 380, DateTimeKind.Local).AddTicks(9716), "Omnis incidunt necessitatibus et est.", new DateTime(2021, 8, 3, 23, 55, 44, 310, DateTimeKind.Local).AddTicks(2067), 8, 8, "Arjun", 2, null },
                    { 33, new DateTime(2022, 7, 1, 5, 24, 20, 277, DateTimeKind.Local).AddTicks(2800), "Delectus veniam temporibus voluptas consequuntur.", new DateTime(2022, 5, 27, 10, 57, 41, 312, DateTimeKind.Local).AddTicks(4778), 12, 18, "Lauren", 1, null },
                    { 34, new DateTime(2021, 8, 26, 0, 44, 53, 962, DateTimeKind.Local).AddTicks(3722), "Quidem voluptatibus vero non veritatis.", new DateTime(2022, 7, 4, 7, 28, 26, 197, DateTimeKind.Local).AddTicks(8177), 4, 1, "Esther", 0, null },
                    { 35, new DateTime(2021, 10, 11, 2, 17, 59, 685, DateTimeKind.Local).AddTicks(3164), "Eos doloribus eos laborum corporis.", null, 1, 11, "Ryan", 3, null },
                    { 36, new DateTime(2021, 12, 31, 23, 16, 23, 781, DateTimeKind.Local).AddTicks(1079), "Est vero deserunt labore fuga.", new DateTime(2022, 4, 4, 20, 26, 21, 842, DateTimeKind.Local).AddTicks(6080), 2, 17, "Eduardo", 2, null },
                    { 37, new DateTime(2021, 8, 29, 8, 31, 50, 769, DateTimeKind.Local).AddTicks(6370), "Soluta repellendus alias aspernatur perspiciatis.", new DateTime(2022, 4, 7, 9, 7, 34, 407, DateTimeKind.Local).AddTicks(7424), 24, 2, "Leland", 3, null },
                    { 38, new DateTime(2021, 10, 8, 9, 25, 47, 827, DateTimeKind.Local).AddTicks(7172), "Beatae sed reprehenderit consectetur velit.", new DateTime(2021, 11, 28, 23, 59, 10, 52, DateTimeKind.Local).AddTicks(6608), 22, 8, "Gaetano", 1, null },
                    { 39, new DateTime(2021, 11, 1, 18, 8, 15, 379, DateTimeKind.Local).AddTicks(1300), "Quaerat reprehenderit aliquam libero consectetur.", new DateTime(2022, 2, 12, 18, 32, 16, 284, DateTimeKind.Local).AddTicks(6183), 6, 9, "Meredith", 2, null },
                    { 40, new DateTime(2022, 1, 8, 4, 48, 24, 925, DateTimeKind.Local).AddTicks(3508), "Nostrum vel ut rerum eligendi.", new DateTime(2022, 1, 14, 9, 32, 29, 939, DateTimeKind.Local).AddTicks(894), 15, 8, "Orrin", 0, null },
                    { 41, new DateTime(2022, 2, 21, 4, 50, 15, 688, DateTimeKind.Local).AddTicks(8806), "A at inventore quos et.", new DateTime(2022, 4, 7, 1, 0, 48, 125, DateTimeKind.Local).AddTicks(8297), 14, 13, "Dora", 2, null },
                    { 42, new DateTime(2021, 12, 13, 10, 55, 46, 182, DateTimeKind.Local).AddTicks(3977), "Nihil optio id et at.", new DateTime(2022, 2, 1, 2, 19, 3, 625, DateTimeKind.Local).AddTicks(5479), 11, 8, "Donny", 2, null }
                });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "CreatedAt", "Description", "FinishedAt", "PerformerId", "ProjectId", "RenamedName", "State", "UserId" },
                values: new object[,]
                {
                    { 43, new DateTime(2022, 4, 10, 20, 37, 25, 183, DateTimeKind.Local).AddTicks(4187), "Reprehenderit est molestias unde alias.", new DateTime(2022, 7, 12, 13, 42, 59, 879, DateTimeKind.Local).AddTicks(8494), 20, 5, "Roberta", 3, null },
                    { 44, new DateTime(2022, 4, 2, 8, 2, 39, 882, DateTimeKind.Local).AddTicks(5341), "Qui animi excepturi rerum nulla.", new DateTime(2022, 6, 27, 5, 28, 29, 167, DateTimeKind.Local).AddTicks(7876), 15, 10, "Magdalena", 3, null },
                    { 45, new DateTime(2021, 11, 25, 13, 26, 10, 545, DateTimeKind.Local).AddTicks(8968), "Rem ad sed quis beatae.", null, 23, 1, "Garrett", 3, null },
                    { 46, new DateTime(2021, 9, 21, 23, 8, 30, 670, DateTimeKind.Local).AddTicks(1555), "Accusamus tenetur veniam aut iusto.", new DateTime(2022, 5, 14, 8, 9, 40, 714, DateTimeKind.Local).AddTicks(9695), 13, 7, "Declan", 3, null },
                    { 47, new DateTime(2022, 6, 8, 22, 55, 19, 922, DateTimeKind.Local).AddTicks(2076), "Quam incidunt molestias et corrupti.", new DateTime(2022, 1, 29, 3, 56, 50, 372, DateTimeKind.Local).AddTicks(2057), 18, 16, "Greyson", 0, null },
                    { 48, new DateTime(2022, 4, 1, 1, 20, 21, 178, DateTimeKind.Local).AddTicks(6951), "Quia nesciunt officia facilis tenetur.", null, 25, 20, "Aileen", 0, null },
                    { 49, new DateTime(2022, 1, 30, 20, 30, 53, 352, DateTimeKind.Local).AddTicks(2792), "Odit et a omnis debitis.", null, 2, 4, "Alda", 3, null },
                    { 50, new DateTime(2021, 8, 7, 5, 32, 1, 962, DateTimeKind.Local).AddTicks(1640), "Maiores eum dolorem voluptatem sed.", new DateTime(2022, 1, 8, 15, 46, 59, 784, DateTimeKind.Local).AddTicks(5845), 21, 15, "London", 1, null },
                    { 51, new DateTime(2021, 9, 6, 12, 51, 5, 86, DateTimeKind.Local).AddTicks(2937), "Aperiam quisquam magnam iste enim.", new DateTime(2021, 9, 16, 4, 54, 37, 4, DateTimeKind.Local).AddTicks(7674), 12, 20, "Madonna", 1, null },
                    { 52, new DateTime(2021, 11, 8, 19, 24, 28, 512, DateTimeKind.Local).AddTicks(3814), "Fugiat ad et vel est.", new DateTime(2022, 4, 29, 5, 59, 45, 0, DateTimeKind.Local).AddTicks(8022), 23, 10, "Kyler", 0, null },
                    { 53, new DateTime(2021, 7, 25, 11, 32, 58, 895, DateTimeKind.Local).AddTicks(8233), "Est dolores tempore et voluptatem.", new DateTime(2022, 5, 20, 17, 12, 57, 460, DateTimeKind.Local).AddTicks(8763), 13, 2, "Madisen", 0, null },
                    { 54, new DateTime(2022, 1, 24, 0, 55, 12, 861, DateTimeKind.Local).AddTicks(5200), "Modi voluptatem voluptatem eius natus.", new DateTime(2021, 10, 31, 2, 33, 30, 754, DateTimeKind.Local).AddTicks(4953), 15, 5, "Cristobal", 1, null },
                    { 55, new DateTime(2021, 9, 15, 5, 4, 0, 448, DateTimeKind.Local).AddTicks(4032), "Commodi adipisci labore inventore mollitia.", new DateTime(2021, 7, 24, 12, 2, 52, 586, DateTimeKind.Local).AddTicks(6291), 26, 15, "Kelton", 2, null },
                    { 56, new DateTime(2021, 8, 22, 15, 18, 50, 76, DateTimeKind.Local).AddTicks(9248), "Et amet illum quia qui.", new DateTime(2021, 10, 26, 17, 32, 47, 976, DateTimeKind.Local).AddTicks(5167), 21, 6, "Augusta", 2, null },
                    { 57, new DateTime(2022, 6, 27, 11, 10, 55, 744, DateTimeKind.Local).AddTicks(6206), "Nihil sunt velit quo voluptatem.", new DateTime(2022, 3, 13, 2, 6, 7, 150, DateTimeKind.Local).AddTicks(4672), 23, 6, "Alysha", 2, null },
                    { 58, new DateTime(2022, 1, 12, 16, 39, 6, 207, DateTimeKind.Local).AddTicks(885), "Aperiam sint odit rerum accusamus.", new DateTime(2021, 8, 31, 11, 8, 10, 120, DateTimeKind.Local).AddTicks(2893), 16, 3, "Maggie", 3, null },
                    { 59, new DateTime(2022, 2, 11, 2, 10, 53, 260, DateTimeKind.Local).AddTicks(4977), "Quas dolorum consequatur est nihil.", new DateTime(2021, 8, 30, 1, 12, 44, 168, DateTimeKind.Local).AddTicks(5890), 11, 16, "Leann", 3, null },
                    { 60, new DateTime(2021, 9, 14, 23, 20, 29, 678, DateTimeKind.Local).AddTicks(7734), "Quam minus ut quis sit.", new DateTime(2022, 5, 14, 19, 0, 46, 196, DateTimeKind.Local).AddTicks(5977), 21, 19, "Fabiola", 3, null },
                    { 61, new DateTime(2022, 5, 31, 10, 7, 7, 426, DateTimeKind.Local).AddTicks(6083), "Sed voluptate velit nobis qui.", new DateTime(2021, 11, 9, 21, 22, 32, 764, DateTimeKind.Local).AddTicks(9814), 25, 15, "Leda", 2, null },
                    { 62, new DateTime(2022, 6, 28, 17, 54, 55, 689, DateTimeKind.Local).AddTicks(4158), "Et nostrum asperiores ipsa sunt.", new DateTime(2021, 9, 19, 11, 15, 6, 348, DateTimeKind.Local).AddTicks(2781), 10, 2, "Grayce", 0, null },
                    { 63, new DateTime(2021, 11, 7, 12, 16, 4, 905, DateTimeKind.Local).AddTicks(2474), "Enim dignissimos aut eos in.", new DateTime(2021, 12, 15, 19, 41, 29, 856, DateTimeKind.Local).AddTicks(9568), 6, 5, "Tre", 1, null },
                    { 64, new DateTime(2022, 5, 15, 23, 2, 55, 901, DateTimeKind.Local).AddTicks(1749), "Placeat accusamus cum eaque quia.", null, 11, 4, "Kiarra", 1, null },
                    { 65, new DateTime(2022, 4, 27, 5, 38, 52, 280, DateTimeKind.Local).AddTicks(835), "Molestiae ipsam aperiam quod quia.", new DateTime(2022, 4, 20, 9, 3, 38, 144, DateTimeKind.Local).AddTicks(1545), 27, 20, "Ciara", 0, null },
                    { 66, new DateTime(2022, 1, 27, 6, 59, 31, 380, DateTimeKind.Local).AddTicks(4471), "Quod modi eius et ex.", new DateTime(2022, 3, 30, 19, 42, 54, 179, DateTimeKind.Local).AddTicks(8750), 10, 7, "Alene", 0, null },
                    { 67, new DateTime(2021, 11, 27, 16, 16, 29, 988, DateTimeKind.Local).AddTicks(2973), "In laboriosam inventore molestiae sint.", new DateTime(2022, 5, 21, 23, 18, 43, 792, DateTimeKind.Local).AddTicks(3023), 16, 2, "Quentin", 2, null },
                    { 68, new DateTime(2021, 9, 16, 0, 35, 37, 303, DateTimeKind.Local).AddTicks(3047), "Eaque nulla vero beatae molestias.", new DateTime(2022, 4, 3, 1, 34, 18, 184, DateTimeKind.Local).AddTicks(3921), 29, 6, "Erich", 3, null },
                    { 69, new DateTime(2022, 5, 7, 18, 3, 16, 969, DateTimeKind.Local).AddTicks(7368), "Itaque voluptatibus ipsa sint ullam.", new DateTime(2022, 2, 28, 10, 4, 43, 990, DateTimeKind.Local).AddTicks(6502), 13, 1, "Kamron", 2, null },
                    { 70, new DateTime(2022, 1, 13, 10, 9, 24, 605, DateTimeKind.Local).AddTicks(729), "Enim reiciendis quasi voluptatem dolor.", new DateTime(2022, 2, 2, 7, 36, 50, 117, DateTimeKind.Local).AddTicks(8839), 15, 10, "Rudolph", 2, null },
                    { 71, new DateTime(2022, 1, 26, 0, 46, 51, 441, DateTimeKind.Local).AddTicks(2597), "Vitae minus sit quaerat rerum.", null, 8, 5, "Jordan", 0, null },
                    { 72, new DateTime(2022, 4, 3, 3, 9, 39, 101, DateTimeKind.Local).AddTicks(5447), "Asperiores voluptatem aut aut officia.", new DateTime(2022, 1, 2, 3, 14, 25, 73, DateTimeKind.Local).AddTicks(4650), 5, 18, "Jillian", 3, null },
                    { 73, new DateTime(2022, 1, 23, 21, 41, 3, 528, DateTimeKind.Local).AddTicks(308), "Eos incidunt quas est velit.", new DateTime(2022, 7, 8, 8, 22, 39, 835, DateTimeKind.Local).AddTicks(1985), 19, 9, "Jennyfer", 2, null },
                    { 74, new DateTime(2022, 6, 7, 6, 57, 13, 59, DateTimeKind.Local).AddTicks(5273), "Deleniti maxime laborum corrupti neque.", null, 26, 13, "Victoria", 1, null },
                    { 75, new DateTime(2021, 10, 15, 3, 34, 40, 431, DateTimeKind.Local).AddTicks(7540), "Praesentium optio totam pariatur voluptatem.", new DateTime(2022, 4, 26, 18, 6, 12, 591, DateTimeKind.Local).AddTicks(321), 4, 18, "Ken", 1, null },
                    { 76, new DateTime(2022, 2, 19, 3, 6, 44, 210, DateTimeKind.Local).AddTicks(4136), "Culpa velit quia harum qui.", new DateTime(2021, 10, 21, 4, 11, 37, 510, DateTimeKind.Local).AddTicks(3558), 10, 17, "Crawford", 1, null },
                    { 77, new DateTime(2021, 8, 20, 20, 19, 12, 992, DateTimeKind.Local).AddTicks(4740), "Eveniet minus dolorum voluptatem ab.", new DateTime(2021, 12, 13, 22, 55, 47, 254, DateTimeKind.Local).AddTicks(4645), 13, 6, "Nelda", 0, null },
                    { 78, new DateTime(2022, 2, 1, 17, 51, 21, 312, DateTimeKind.Local).AddTicks(252), "Et qui fugit ut et.", new DateTime(2021, 8, 23, 10, 25, 36, 434, DateTimeKind.Local).AddTicks(3117), 20, 13, "Angelita", 1, null },
                    { 79, new DateTime(2022, 4, 29, 9, 48, 34, 156, DateTimeKind.Local).AddTicks(9572), "Ea laudantium nisi maxime ratione.", new DateTime(2022, 2, 26, 14, 21, 16, 841, DateTimeKind.Local).AddTicks(9708), 4, 18, "Emiliano", 1, null },
                    { 80, new DateTime(2022, 1, 14, 23, 49, 47, 143, DateTimeKind.Local).AddTicks(7838), "Voluptatibus ad enim autem molestiae.", new DateTime(2021, 10, 4, 5, 25, 20, 480, DateTimeKind.Local).AddTicks(9137), 14, 8, "Wallace", 1, null },
                    { 81, new DateTime(2021, 10, 31, 9, 16, 52, 450, DateTimeKind.Local).AddTicks(8436), "Ut ea voluptate corrupti sunt.", new DateTime(2021, 9, 27, 6, 4, 28, 748, DateTimeKind.Local).AddTicks(4715), 27, 2, "Stacey", 0, null },
                    { 82, new DateTime(2021, 8, 15, 4, 59, 29, 868, DateTimeKind.Local).AddTicks(2128), "Possimus delectus et ipsa sit.", new DateTime(2022, 4, 15, 8, 21, 6, 458, DateTimeKind.Local).AddTicks(8574), 14, 3, "Roxanne", 0, null },
                    { 83, new DateTime(2021, 7, 20, 13, 58, 33, 536, DateTimeKind.Local).AddTicks(3624), "Nobis at dolor nobis excepturi.", new DateTime(2021, 11, 30, 6, 0, 8, 452, DateTimeKind.Local).AddTicks(6975), 13, 18, "Carlee", 3, null },
                    { 84, new DateTime(2022, 5, 26, 8, 9, 43, 376, DateTimeKind.Local).AddTicks(2709), "Tenetur ipsa sit sed ea.", new DateTime(2022, 4, 17, 10, 44, 38, 105, DateTimeKind.Local).AddTicks(3459), 20, 15, "Jewell", 3, null }
                });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "CreatedAt", "Description", "FinishedAt", "PerformerId", "ProjectId", "RenamedName", "State", "UserId" },
                values: new object[,]
                {
                    { 85, new DateTime(2021, 10, 18, 23, 51, 59, 511, DateTimeKind.Local).AddTicks(5183), "Occaecati porro eum sint doloremque.", null, 14, 7, "Roscoe", 1, null },
                    { 86, new DateTime(2022, 1, 29, 14, 55, 31, 137, DateTimeKind.Local).AddTicks(587), "Non officiis consequatur necessitatibus reprehenderit.", null, 4, 5, "Dorian", 2, null },
                    { 87, new DateTime(2021, 11, 24, 7, 25, 22, 14, DateTimeKind.Local).AddTicks(5310), "Consequatur id voluptatem aut ratione.", new DateTime(2022, 2, 18, 0, 31, 42, 751, DateTimeKind.Local).AddTicks(1348), 26, 5, "Bradley", 0, null },
                    { 88, new DateTime(2022, 4, 8, 15, 15, 42, 803, DateTimeKind.Local).AddTicks(5149), "Sint asperiores totam est modi.", new DateTime(2022, 3, 28, 20, 28, 25, 929, DateTimeKind.Local).AddTicks(956), 28, 19, "Blanca", 0, null },
                    { 89, new DateTime(2022, 1, 6, 3, 53, 49, 734, DateTimeKind.Local).AddTicks(6722), "Maxime pariatur sit et aut.", null, 11, 16, "Yvonne", 2, null },
                    { 90, new DateTime(2022, 6, 16, 8, 24, 44, 89, DateTimeKind.Local).AddTicks(3804), "Quis officia optio ipsum quia.", new DateTime(2021, 10, 15, 23, 56, 44, 826, DateTimeKind.Local).AddTicks(4203), 22, 7, "Norbert", 1, null },
                    { 91, new DateTime(2021, 8, 7, 22, 43, 43, 743, DateTimeKind.Local).AddTicks(9056), "Ea est adipisci rerum necessitatibus.", new DateTime(2021, 10, 25, 13, 52, 7, 139, DateTimeKind.Local).AddTicks(3922), 2, 16, "Ines", 2, null },
                    { 92, new DateTime(2021, 10, 9, 18, 10, 6, 308, DateTimeKind.Local).AddTicks(3190), "Necessitatibus exercitationem rerum ullam accusantium.", new DateTime(2022, 6, 12, 7, 44, 59, 959, DateTimeKind.Local).AddTicks(5508), 26, 15, "Hyman", 2, null },
                    { 93, new DateTime(2021, 8, 31, 21, 26, 43, 153, DateTimeKind.Local).AddTicks(4672), "Vero necessitatibus quia nemo velit.", new DateTime(2021, 11, 5, 23, 40, 26, 821, DateTimeKind.Local).AddTicks(8674), 22, 10, "Nedra", 3, null },
                    { 94, new DateTime(2021, 12, 1, 11, 49, 33, 820, DateTimeKind.Local).AddTicks(9054), "Ipsam eaque rerum voluptates modi.", null, 27, 11, "Leila", 3, null },
                    { 95, new DateTime(2021, 11, 27, 6, 43, 17, 873, DateTimeKind.Local).AddTicks(8238), "Ipsum et velit quas rerum.", new DateTime(2022, 5, 1, 2, 39, 44, 423, DateTimeKind.Local).AddTicks(8034), 1, 15, "Gregoria", 2, null },
                    { 96, new DateTime(2021, 9, 2, 12, 44, 37, 513, DateTimeKind.Local).AddTicks(9912), "Et molestiae est ut architecto.", new DateTime(2022, 5, 2, 21, 7, 20, 563, DateTimeKind.Local).AddTicks(5237), 26, 1, "Jaleel", 2, null },
                    { 97, new DateTime(2021, 11, 25, 5, 56, 59, 284, DateTimeKind.Local).AddTicks(9395), "Suscipit tempore tempora sequi deleniti.", new DateTime(2021, 9, 18, 9, 52, 21, 514, DateTimeKind.Local).AddTicks(6479), 15, 16, "Emery", 1, null },
                    { 98, new DateTime(2021, 12, 23, 11, 32, 54, 639, DateTimeKind.Local).AddTicks(3933), "Modi nesciunt distinctio eaque facere.", new DateTime(2021, 11, 18, 6, 20, 54, 389, DateTimeKind.Local).AddTicks(6183), 16, 11, "Rita", 2, null },
                    { 99, new DateTime(2022, 6, 6, 7, 40, 15, 340, DateTimeKind.Local).AddTicks(7474), "Quis est perspiciatis in rerum.", new DateTime(2021, 10, 15, 23, 41, 54, 477, DateTimeKind.Local).AddTicks(7306), 16, 3, "Ara", 3, null },
                    { 100, new DateTime(2022, 3, 10, 21, 21, 30, 864, DateTimeKind.Local).AddTicks(1057), "Eos id quo eos assumenda.", new DateTime(2021, 9, 11, 22, 17, 9, 993, DateTimeKind.Local).AddTicks(2903), 10, 5, "Mohammad", 1, null }
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
                name: "IX_Tasks_UserId",
                table: "Tasks",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_TeamId",
                table: "Users",
                column: "TeamId");
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
