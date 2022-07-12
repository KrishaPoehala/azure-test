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
                values: new object[] { 1, new DateTime(2022, 6, 24, 12, 56, 14, 738, DateTimeKind.Local).AddTicks(5050), "O'Keefe - Bruen" });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "CreatedAt", "Name" },
                values: new object[] { 2, new DateTime(2022, 4, 8, 21, 59, 20, 434, DateTimeKind.Local).AddTicks(2161), "Jenkins - Spinka" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "BirthDay", "Email", "FirstName", "LastName", "RegisteredAt", "TeamId" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 2, 9, 0, 24, 24, 604, DateTimeKind.Local).AddTicks(8922), "Berta72@gmail.com", "Maegan", "Ruecker", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 2, new DateTime(2022, 1, 15, 3, 0, 0, 557, DateTimeKind.Local).AddTicks(8873), "Damien.Yundt96@yahoo.com", "Eriberto", "Heathcote", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 3, new DateTime(2021, 11, 22, 0, 49, 52, 274, DateTimeKind.Local).AddTicks(5391), "Randy1@hotmail.com", "Norval", "Torp", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 4, new DateTime(2022, 2, 14, 20, 22, 9, 60, DateTimeKind.Local).AddTicks(3056), "Harley80@gmail.com", "Adrien", "Torphy", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 5, new DateTime(2021, 12, 11, 2, 29, 27, 419, DateTimeKind.Local).AddTicks(9245), "Salma_Bechtelar@gmail.com", "Cassandre", "Wisoky", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 6, new DateTime(2021, 11, 27, 7, 48, 54, 571, DateTimeKind.Local).AddTicks(7668), "Edyth.Hackett@gmail.com", "Briana", "Donnelly", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 7, new DateTime(2022, 5, 8, 14, 37, 2, 689, DateTimeKind.Local).AddTicks(599), "Xander.Flatley84@hotmail.com", "Gerhard", "Leffler", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 8, new DateTime(2021, 9, 26, 19, 17, 55, 563, DateTimeKind.Local).AddTicks(4567), "Virgil_Quigley@hotmail.com", "Easton", "Padberg", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 9, new DateTime(2022, 7, 2, 16, 31, 48, 62, DateTimeKind.Local).AddTicks(3251), "Britney.Gislason@yahoo.com", "Dedric", "Ebert", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 10, new DateTime(2021, 8, 10, 18, 52, 54, 5, DateTimeKind.Local).AddTicks(7418), "Kassandra.Langosh68@yahoo.com", "Lukas", "Tillman", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 11, new DateTime(2022, 4, 13, 12, 18, 2, 686, DateTimeKind.Local).AddTicks(7861), "Everette81@hotmail.com", "Tessie", "Homenick", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 12, new DateTime(2021, 12, 30, 12, 57, 38, 122, DateTimeKind.Local).AddTicks(2060), "Green_Kling@yahoo.com", "Vickie", "Blick", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 13, new DateTime(2021, 10, 23, 13, 25, 8, 831, DateTimeKind.Local).AddTicks(6597), "Terrance14@hotmail.com", "Mya", "Cronin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 14, new DateTime(2021, 12, 9, 10, 14, 23, 507, DateTimeKind.Local).AddTicks(3566), "Kody.McKenzie@gmail.com", "Luis", "Shanahan", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 15, new DateTime(2022, 4, 7, 2, 38, 25, 532, DateTimeKind.Local).AddTicks(3802), "Okey8@yahoo.com", "Francesca", "Koelpin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 16, new DateTime(2022, 5, 3, 0, 2, 3, 144, DateTimeKind.Local).AddTicks(320), "Grant.Schowalter83@hotmail.com", "Otho", "Armstrong", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 17, new DateTime(2021, 12, 31, 15, 34, 51, 145, DateTimeKind.Local).AddTicks(6945), "Ignatius4@yahoo.com", "Madge", "Schamberger", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 18, new DateTime(2021, 9, 3, 20, 51, 45, 475, DateTimeKind.Local).AddTicks(480), "Jaclyn.Hodkiewicz14@gmail.com", "Mona", "Crona", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 19, new DateTime(2021, 9, 16, 9, 16, 27, 718, DateTimeKind.Local).AddTicks(6167), "Eudora34@yahoo.com", "Malika", "Yost", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 20, new DateTime(2021, 7, 25, 9, 57, 16, 633, DateTimeKind.Local).AddTicks(5720), "Roberto90@yahoo.com", "Jessie", "Pacocha", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 21, new DateTime(2021, 10, 1, 18, 57, 23, 41, DateTimeKind.Local).AddTicks(4936), "Clemmie38@hotmail.com", "Bettie", "Gulgowski", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 22, new DateTime(2022, 4, 1, 17, 56, 41, 502, DateTimeKind.Local).AddTicks(9728), "Tiana_Jacobi33@yahoo.com", "Rey", "Raynor", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 23, new DateTime(2021, 10, 27, 9, 27, 45, 21, DateTimeKind.Local).AddTicks(4583), "Zackery59@hotmail.com", "Alicia", "Schroeder", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 24, new DateTime(2022, 2, 3, 17, 34, 37, 854, DateTimeKind.Local).AddTicks(3645), "Henderson.Mitchell@gmail.com", "Dale", "McCullough", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 25, new DateTime(2022, 3, 12, 16, 13, 31, 408, DateTimeKind.Local).AddTicks(6521), "Mellie40@gmail.com", "Stan", "Moen", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 26, new DateTime(2022, 4, 13, 11, 40, 58, 112, DateTimeKind.Local).AddTicks(5524), "Joel_Kulas2@yahoo.com", "Jabari", "Willms", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 27, new DateTime(2021, 11, 1, 0, 34, 10, 254, DateTimeKind.Local).AddTicks(7046), "Mabelle0@yahoo.com", "Kevin", "Sauer", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 28, new DateTime(2022, 3, 21, 14, 24, 46, 512, DateTimeKind.Local).AddTicks(3739), "Vladimir56@yahoo.com", "Iva", "Beer", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 29, new DateTime(2022, 1, 9, 3, 33, 12, 797, DateTimeKind.Local).AddTicks(7986), "Judah.White@yahoo.com", "Montana", "Haag", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 30, new DateTime(2022, 5, 3, 7, 26, 43, 314, DateTimeKind.Local).AddTicks(6800), "Patrick_Leannon@yahoo.com", "Blanca", "Hessel", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "AuthorId", "CreatedAt", "Deadline", "Description", "Name", "TeamId" },
                values: new object[,]
                {
                    { 1, 12, new DateTime(2022, 5, 12, 15, 12, 59, 649, DateTimeKind.Local).AddTicks(8769), new DateTime(2022, 8, 1, 16, 32, 29, 600, DateTimeKind.Local).AddTicks(6945), "Et dignissimos consequatur non exercitationem blanditiis cupiditate.", "Assurance", 1 },
                    { 2, 25, new DateTime(2022, 4, 22, 10, 10, 37, 5, DateTimeKind.Local).AddTicks(9142), new DateTime(2022, 10, 27, 19, 43, 57, 811, DateTimeKind.Local).AddTicks(6615), "Odio aliquam blanditiis quia numquam vero nisi.", "Mobility", 2 },
                    { 3, 23, new DateTime(2022, 5, 16, 15, 26, 1, 727, DateTimeKind.Local).AddTicks(2848), new DateTime(2022, 8, 2, 15, 55, 13, 378, DateTimeKind.Local).AddTicks(3995), "Facilis vel nihil beatae non impedit non.", "Branding", 2 },
                    { 4, 22, new DateTime(2021, 9, 14, 11, 41, 10, 751, DateTimeKind.Local).AddTicks(6550), new DateTime(2022, 12, 29, 4, 40, 55, 411, DateTimeKind.Local).AddTicks(3967), "Eligendi ut impedit dolores mollitia eos totam.", "Program", 2 },
                    { 5, 21, new DateTime(2022, 1, 13, 10, 5, 50, 907, DateTimeKind.Local).AddTicks(6118), new DateTime(2023, 3, 28, 10, 52, 54, 462, DateTimeKind.Local).AddTicks(2821), "Est voluptatem cupiditate nam et distinctio velit.", "Directives", 2 },
                    { 6, 1, new DateTime(2022, 1, 6, 8, 49, 18, 233, DateTimeKind.Local).AddTicks(7088), new DateTime(2023, 6, 1, 22, 18, 54, 503, DateTimeKind.Local).AddTicks(6664), "Aut aliquam voluptatem est quam voluptatem repudiandae.", "Directives", 2 },
                    { 7, 22, new DateTime(2021, 9, 8, 21, 16, 57, 82, DateTimeKind.Local).AddTicks(9288), new DateTime(2023, 2, 6, 22, 45, 2, 460, DateTimeKind.Local).AddTicks(9845), "Voluptatibus in ipsa eius corporis odio explicabo.", "Integration", 2 },
                    { 8, 27, new DateTime(2021, 11, 9, 10, 44, 20, 748, DateTimeKind.Local).AddTicks(9621), new DateTime(2022, 9, 17, 15, 3, 46, 468, DateTimeKind.Local).AddTicks(7136), "Labore rerum magnam nesciunt sed ipsum quidem.", "Marketing", 2 },
                    { 9, 7, new DateTime(2021, 10, 15, 5, 5, 44, 786, DateTimeKind.Local).AddTicks(724), new DateTime(2022, 8, 2, 7, 19, 50, 57, DateTimeKind.Local).AddTicks(8686), "Quia occaecati alias vero ipsum dolor qui.", "Intranet", 1 },
                    { 10, 22, new DateTime(2021, 9, 28, 7, 0, 9, 716, DateTimeKind.Local).AddTicks(5110), new DateTime(2022, 10, 13, 6, 42, 27, 361, DateTimeKind.Local).AddTicks(6647), "Eveniet saepe nihil reiciendis cupiditate distinctio quas.", "Usability", 1 },
                    { 11, 4, new DateTime(2022, 1, 2, 12, 48, 24, 661, DateTimeKind.Local).AddTicks(8422), new DateTime(2022, 12, 7, 10, 17, 31, 992, DateTimeKind.Local).AddTicks(9132), "Veritatis placeat cum numquam nihil esse soluta.", "Interactions", 2 },
                    { 12, 26, new DateTime(2021, 9, 4, 16, 55, 30, 749, DateTimeKind.Local).AddTicks(413), new DateTime(2023, 2, 7, 8, 27, 51, 7, DateTimeKind.Local).AddTicks(3247), "Quia debitis quaerat natus sit qui magni.", "Usability", 2 },
                    { 13, 12, new DateTime(2022, 2, 23, 11, 52, 55, 936, DateTimeKind.Local).AddTicks(9128), new DateTime(2022, 10, 8, 14, 25, 11, 596, DateTimeKind.Local).AddTicks(8855), "Autem sint repellendus autem quis aut dolore.", "Creative", 1 },
                    { 14, 22, new DateTime(2022, 6, 26, 7, 15, 34, 706, DateTimeKind.Local).AddTicks(9906), new DateTime(2022, 10, 27, 8, 52, 52, 668, DateTimeKind.Local).AddTicks(8993), "Cum qui ullam sit facilis quibusdam earum.", "Infrastructure", 2 },
                    { 15, 16, new DateTime(2022, 5, 26, 10, 12, 16, 541, DateTimeKind.Local).AddTicks(5030), new DateTime(2023, 2, 4, 2, 14, 21, 126, DateTimeKind.Local).AddTicks(7642), "Quasi consequatur quod sunt necessitatibus est laborum.", "Markets", 1 },
                    { 16, 22, new DateTime(2022, 5, 9, 11, 45, 39, 396, DateTimeKind.Local).AddTicks(8561), new DateTime(2023, 4, 26, 20, 40, 5, 120, DateTimeKind.Local).AddTicks(4039), "In hic quod voluptatem ex temporibus rerum.", "Usability", 1 },
                    { 17, 6, new DateTime(2022, 2, 20, 18, 19, 35, 831, DateTimeKind.Local).AddTicks(8639), new DateTime(2022, 10, 19, 6, 54, 31, 845, DateTimeKind.Local).AddTicks(146), "Omnis ex sint est quod nisi officia.", "Identity", 1 },
                    { 18, 17, new DateTime(2021, 9, 27, 15, 1, 9, 685, DateTimeKind.Local).AddTicks(8767), new DateTime(2023, 4, 26, 19, 33, 15, 541, DateTimeKind.Local).AddTicks(6671), "Consequatur sit neque quia ut tempore laboriosam.", "Marketing", 2 },
                    { 19, 25, new DateTime(2021, 10, 2, 5, 55, 17, 456, DateTimeKind.Local).AddTicks(6695), new DateTime(2022, 12, 22, 11, 15, 39, 343, DateTimeKind.Local).AddTicks(5334), "Ipsa unde maiores in ut earum nobis.", "Group", 1 },
                    { 20, 22, new DateTime(2021, 10, 20, 5, 14, 14, 92, DateTimeKind.Local).AddTicks(3548), new DateTime(2022, 9, 12, 14, 37, 26, 66, DateTimeKind.Local).AddTicks(5764), "Sunt pariatur est cumque ea optio ipsum.", "Accounts", 2 }
                });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "CreatedAt", "Description", "FinishedAt", "PerformerId", "ProjectId", "RenamedName", "State", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 8, 11, 17, 40, 2, 470, DateTimeKind.Local).AddTicks(8072), "Earum neque et consequatur vel.", new DateTime(2022, 5, 14, 20, 40, 10, 270, DateTimeKind.Local).AddTicks(8417), 24, 17, "Emerson", 2, null },
                    { 2, new DateTime(2022, 6, 2, 18, 36, 25, 962, DateTimeKind.Local).AddTicks(4381), "Necessitatibus aliquid similique dolores nulla.", null, 9, 7, "Wilhelmine", 3, null },
                    { 3, new DateTime(2021, 8, 20, 18, 15, 54, 195, DateTimeKind.Local).AddTicks(9985), "Porro eum quod tenetur labore.", null, 16, 1, "Lawson", 3, null },
                    { 4, new DateTime(2021, 12, 21, 5, 45, 22, 89, DateTimeKind.Local).AddTicks(3952), "Aspernatur eum sunt ea sed.", new DateTime(2021, 11, 22, 14, 12, 26, 514, DateTimeKind.Local).AddTicks(2639), 12, 14, "Corene", 3, null },
                    { 5, new DateTime(2021, 8, 28, 9, 1, 58, 844, DateTimeKind.Local).AddTicks(9114), "Adipisci qui voluptate magnam rerum.", new DateTime(2021, 12, 24, 19, 58, 21, 937, DateTimeKind.Local).AddTicks(3870), 25, 7, "Carley", 1, null },
                    { 6, new DateTime(2021, 11, 26, 19, 52, 10, 9, DateTimeKind.Local).AddTicks(2329), "Corrupti quo eaque magnam sit.", new DateTime(2021, 11, 27, 10, 42, 23, 371, DateTimeKind.Local).AddTicks(3300), 20, 14, "Desiree", 1, null },
                    { 7, new DateTime(2022, 6, 8, 12, 21, 58, 191, DateTimeKind.Local).AddTicks(4161), "Esse eos itaque amet illum.", new DateTime(2022, 6, 19, 12, 15, 1, 259, DateTimeKind.Local).AddTicks(9624), 29, 10, "Terrell", 0, null },
                    { 8, new DateTime(2021, 8, 27, 1, 38, 55, 833, DateTimeKind.Local).AddTicks(6125), "Minus nobis et aut possimus.", new DateTime(2021, 9, 22, 2, 49, 31, 81, DateTimeKind.Local).AddTicks(1254), 17, 12, "Maxime", 3, null },
                    { 9, new DateTime(2022, 1, 5, 17, 56, 20, 533, DateTimeKind.Local).AddTicks(6130), "Itaque ab quam quos aperiam.", new DateTime(2022, 3, 10, 1, 19, 23, 333, DateTimeKind.Local).AddTicks(2329), 14, 2, "Chelsea", 1, null },
                    { 10, new DateTime(2022, 4, 22, 16, 23, 7, 212, DateTimeKind.Local).AddTicks(8389), "Sapiente et illo similique molestiae.", null, 15, 14, "Dina", 3, null },
                    { 11, new DateTime(2022, 1, 15, 0, 44, 25, 590, DateTimeKind.Local).AddTicks(2676), "Aperiam qui et et error.", null, 5, 18, "Oswaldo", 0, null },
                    { 12, new DateTime(2021, 10, 27, 19, 10, 9, 63, DateTimeKind.Local).AddTicks(7753), "Harum voluptatem quae quo sed.", new DateTime(2022, 4, 18, 0, 27, 30, 953, DateTimeKind.Local).AddTicks(4138), 1, 4, "Randi", 0, null },
                    { 13, new DateTime(2021, 8, 14, 17, 30, 5, 204, DateTimeKind.Local).AddTicks(7629), "Aut voluptas culpa nemo alias.", new DateTime(2021, 8, 21, 17, 59, 33, 79, DateTimeKind.Local).AddTicks(2305), 17, 10, "Rudolph", 0, null },
                    { 14, new DateTime(2022, 6, 6, 4, 38, 14, 104, DateTimeKind.Local).AddTicks(2404), "Eos velit rem ducimus recusandae.", new DateTime(2021, 12, 30, 4, 38, 36, 988, DateTimeKind.Local).AddTicks(5857), 4, 1, "Dayton", 0, null },
                    { 15, new DateTime(2022, 3, 15, 22, 55, 24, 303, DateTimeKind.Local).AddTicks(5863), "Tempora illum error a esse.", new DateTime(2022, 2, 14, 3, 34, 28, 781, DateTimeKind.Local).AddTicks(5746), 29, 6, "Osbaldo", 2, null },
                    { 16, new DateTime(2022, 2, 1, 2, 26, 53, 302, DateTimeKind.Local).AddTicks(5553), "Laudantium enim ut sunt sed.", null, 1, 7, "Liam", 2, null },
                    { 17, new DateTime(2021, 12, 27, 14, 1, 1, 284, DateTimeKind.Local).AddTicks(7261), "Laboriosam minus et veniam voluptas.", null, 5, 10, "Lauryn", 2, null },
                    { 18, new DateTime(2022, 5, 22, 19, 18, 47, 402, DateTimeKind.Local).AddTicks(1110), "Assumenda consequatur voluptatibus veniam harum.", new DateTime(2021, 8, 19, 3, 51, 37, 217, DateTimeKind.Local).AddTicks(6641), 23, 19, "Geo", 2, null },
                    { 19, new DateTime(2022, 6, 14, 1, 16, 11, 431, DateTimeKind.Local).AddTicks(2307), "In magni non eos sit.", new DateTime(2022, 3, 19, 2, 1, 27, 735, DateTimeKind.Local).AddTicks(668), 12, 8, "Isobel", 2, null },
                    { 20, new DateTime(2021, 8, 5, 15, 31, 17, 440, DateTimeKind.Local).AddTicks(2275), "Quis qui labore totam qui.", new DateTime(2021, 12, 10, 10, 31, 13, 160, DateTimeKind.Local).AddTicks(8052), 6, 6, "Ellis", 2, null },
                    { 21, new DateTime(2021, 11, 28, 10, 25, 12, 230, DateTimeKind.Local).AddTicks(2415), "Assumenda voluptas repellendus voluptatem itaque.", null, 22, 17, "Dessie", 3, null },
                    { 22, new DateTime(2022, 3, 4, 1, 6, 33, 615, DateTimeKind.Local).AddTicks(8899), "In fugit ea velit velit.", null, 17, 1, "Loraine", 2, null },
                    { 23, new DateTime(2021, 9, 5, 10, 24, 0, 892, DateTimeKind.Local).AddTicks(2700), "Quia et quidem sint illo.", new DateTime(2021, 12, 7, 12, 23, 43, 445, DateTimeKind.Local).AddTicks(8249), 10, 6, "Marina", 0, null },
                    { 24, new DateTime(2021, 12, 14, 19, 35, 20, 36, DateTimeKind.Local).AddTicks(2012), "Qui consequatur in a pariatur.", new DateTime(2022, 1, 6, 20, 7, 52, 336, DateTimeKind.Local).AddTicks(2613), 16, 4, "Madison", 3, null },
                    { 25, new DateTime(2022, 6, 1, 22, 1, 18, 486, DateTimeKind.Local).AddTicks(983), "Dolores aliquid quos aut voluptatum.", new DateTime(2021, 10, 11, 1, 8, 52, 530, DateTimeKind.Local).AddTicks(760), 7, 20, "Shaina", 0, null },
                    { 26, new DateTime(2021, 11, 18, 11, 23, 23, 563, DateTimeKind.Local).AddTicks(5877), "Et pariatur voluptates quo nam.", null, 30, 18, "Kara", 0, null },
                    { 27, new DateTime(2021, 9, 28, 0, 51, 11, 965, DateTimeKind.Local).AddTicks(8382), "Vitae sit ea voluptatum id.", new DateTime(2022, 1, 9, 7, 48, 16, 560, DateTimeKind.Local).AddTicks(5932), 14, 6, "Annamae", 0, null },
                    { 28, new DateTime(2021, 11, 15, 22, 25, 42, 934, DateTimeKind.Local).AddTicks(7413), "Sequi et dignissimos perferendis voluptatem.", null, 12, 14, "Wilma", 2, null },
                    { 29, new DateTime(2022, 1, 18, 13, 35, 29, 460, DateTimeKind.Local).AddTicks(9324), "Quas et praesentium maxime et.", null, 3, 12, "Annalise", 1, null },
                    { 30, new DateTime(2021, 10, 18, 17, 37, 52, 352, DateTimeKind.Local).AddTicks(8849), "Distinctio sint quis aspernatur sunt.", null, 28, 7, "Addison", 2, null },
                    { 31, new DateTime(2022, 5, 12, 3, 10, 27, 850, DateTimeKind.Local).AddTicks(7383), "Assumenda facilis et et non.", new DateTime(2022, 5, 31, 15, 25, 39, 224, DateTimeKind.Local).AddTicks(585), 30, 8, "Eliza", 3, null },
                    { 32, new DateTime(2022, 6, 7, 13, 41, 8, 575, DateTimeKind.Local).AddTicks(9608), "Ratione ut pariatur unde et.", new DateTime(2022, 1, 24, 2, 1, 6, 521, DateTimeKind.Local).AddTicks(7473), 8, 6, "Marlene", 3, null },
                    { 33, new DateTime(2022, 1, 15, 7, 14, 5, 599, DateTimeKind.Local).AddTicks(583), "Magni provident qui culpa quasi.", new DateTime(2022, 5, 26, 3, 50, 5, 606, DateTimeKind.Local).AddTicks(1576), 7, 6, "Jewel", 1, null },
                    { 34, new DateTime(2021, 12, 23, 5, 46, 47, 819, DateTimeKind.Local).AddTicks(3587), "Sed ea voluptatum quia incidunt.", new DateTime(2022, 7, 8, 7, 0, 48, 458, DateTimeKind.Local).AddTicks(794), 26, 12, "Bret", 2, null },
                    { 35, new DateTime(2021, 12, 15, 19, 13, 11, 383, DateTimeKind.Local).AddTicks(803), "Nemo molestiae natus occaecati architecto.", new DateTime(2022, 7, 3, 17, 41, 9, 138, DateTimeKind.Local).AddTicks(1553), 17, 18, "Zack", 2, null },
                    { 36, new DateTime(2021, 8, 5, 14, 4, 59, 682, DateTimeKind.Local).AddTicks(5130), "Sint delectus qui recusandae commodi.", new DateTime(2021, 9, 1, 17, 19, 38, 966, DateTimeKind.Local).AddTicks(2063), 18, 17, "Taya", 1, null },
                    { 37, new DateTime(2021, 9, 9, 20, 39, 28, 109, DateTimeKind.Local).AddTicks(3355), "Consectetur molestiae sit odit ipsa.", new DateTime(2022, 6, 22, 6, 15, 50, 245, DateTimeKind.Local).AddTicks(9459), 5, 5, "Davon", 3, null },
                    { 38, new DateTime(2022, 3, 25, 1, 29, 47, 888, DateTimeKind.Local).AddTicks(566), "Aperiam est illo vitae quos.", new DateTime(2022, 1, 10, 21, 37, 5, 309, DateTimeKind.Local).AddTicks(7236), 19, 9, "Edmond", 2, null },
                    { 39, new DateTime(2021, 9, 26, 16, 58, 38, 612, DateTimeKind.Local).AddTicks(330), "Modi ipsum ad architecto incidunt.", new DateTime(2022, 4, 21, 22, 46, 0, 2, DateTimeKind.Local).AddTicks(9414), 22, 19, "Colten", 0, null },
                    { 40, new DateTime(2021, 9, 26, 16, 34, 55, 859, DateTimeKind.Local).AddTicks(331), "Ipsam officia eveniet consequatur et.", new DateTime(2021, 10, 24, 7, 50, 56, 538, DateTimeKind.Local).AddTicks(4518), 12, 16, "Kaycee", 1, null },
                    { 41, new DateTime(2022, 2, 14, 3, 11, 16, 236, DateTimeKind.Local).AddTicks(9983), "Corporis at omnis voluptatem ea.", null, 13, 11, "Hubert", 2, null },
                    { 42, new DateTime(2022, 4, 21, 10, 5, 45, 374, DateTimeKind.Local).AddTicks(5178), "Consequuntur nesciunt ipsa quod aperiam.", new DateTime(2021, 12, 14, 23, 33, 21, 841, DateTimeKind.Local).AddTicks(8890), 10, 11, "Aimee", 0, null }
                });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "CreatedAt", "Description", "FinishedAt", "PerformerId", "ProjectId", "RenamedName", "State", "UserId" },
                values: new object[,]
                {
                    { 43, new DateTime(2022, 5, 16, 3, 5, 48, 908, DateTimeKind.Local).AddTicks(846), "Maxime rerum accusamus quia eligendi.", null, 30, 18, "Carlie", 1, null },
                    { 44, new DateTime(2022, 1, 22, 2, 37, 43, 931, DateTimeKind.Local).AddTicks(2325), "Aliquam aut corporis ratione porro.", new DateTime(2021, 11, 3, 14, 16, 21, 694, DateTimeKind.Local).AddTicks(2880), 12, 11, "Antoinette", 3, null },
                    { 45, new DateTime(2022, 6, 5, 6, 36, 15, 177, DateTimeKind.Local).AddTicks(1026), "Voluptatum qui modi ex molestias.", new DateTime(2021, 12, 9, 2, 38, 18, 771, DateTimeKind.Local).AddTicks(6990), 23, 11, "Lucio", 0, null },
                    { 46, new DateTime(2021, 7, 28, 13, 32, 37, 566, DateTimeKind.Local).AddTicks(1593), "Sapiente ducimus molestias ut quibusdam.", new DateTime(2021, 12, 10, 6, 32, 56, 906, DateTimeKind.Local).AddTicks(601), 19, 2, "Tina", 3, null },
                    { 47, new DateTime(2022, 3, 1, 3, 52, 18, 930, DateTimeKind.Local).AddTicks(2263), "Quasi voluptatibus enim aliquid atque.", null, 6, 1, "Tristian", 3, null },
                    { 48, new DateTime(2021, 9, 30, 21, 53, 13, 136, DateTimeKind.Local).AddTicks(5527), "Officia velit libero numquam quia.", new DateTime(2021, 10, 1, 11, 27, 48, 902, DateTimeKind.Local).AddTicks(5408), 1, 17, "Lucio", 3, null },
                    { 49, new DateTime(2022, 6, 2, 4, 4, 38, 32, DateTimeKind.Local).AddTicks(4676), "Dolorem non sit nesciunt inventore.", null, 23, 17, "Rasheed", 2, null },
                    { 50, new DateTime(2021, 11, 26, 4, 22, 37, 859, DateTimeKind.Local).AddTicks(5926), "Perferendis porro perferendis qui eaque.", new DateTime(2021, 9, 14, 15, 29, 39, 321, DateTimeKind.Local).AddTicks(4067), 29, 14, "Juanita", 0, null },
                    { 51, new DateTime(2021, 8, 23, 22, 6, 3, 352, DateTimeKind.Local).AddTicks(5189), "Magnam ab illo voluptatum similique.", null, 19, 13, "Mossie", 1, null },
                    { 52, new DateTime(2022, 1, 12, 14, 6, 7, 846, DateTimeKind.Local).AddTicks(6381), "Culpa corporis autem voluptas deserunt.", null, 4, 9, "Augusta", 1, null },
                    { 53, new DateTime(2022, 3, 9, 21, 34, 38, 88, DateTimeKind.Local).AddTicks(4542), "Quaerat et voluptates est veniam.", new DateTime(2021, 8, 11, 13, 12, 35, 641, DateTimeKind.Local).AddTicks(5335), 8, 19, "Donavon", 3, null },
                    { 54, new DateTime(2022, 2, 16, 9, 31, 3, 280, DateTimeKind.Local).AddTicks(1759), "Eum pariatur est corrupti quisquam.", new DateTime(2022, 4, 8, 1, 0, 32, 956, DateTimeKind.Local).AddTicks(4401), 21, 12, "Assunta", 3, null },
                    { 55, new DateTime(2021, 12, 27, 11, 58, 21, 26, DateTimeKind.Local).AddTicks(5792), "Et temporibus repellendus at dolorem.", null, 6, 18, "Sabrina", 3, null },
                    { 56, new DateTime(2022, 3, 3, 13, 47, 31, 911, DateTimeKind.Local).AddTicks(5873), "Necessitatibus aut sunt voluptatibus reprehenderit.", null, 25, 9, "Valentine", 2, null },
                    { 57, new DateTime(2021, 12, 25, 4, 53, 19, 53, DateTimeKind.Local).AddTicks(6423), "Sapiente numquam ut quo consequuntur.", null, 21, 20, "Ansel", 2, null },
                    { 58, new DateTime(2021, 12, 26, 11, 57, 30, 681, DateTimeKind.Local).AddTicks(4984), "Sed atque odio laudantium perferendis.", new DateTime(2021, 12, 17, 7, 21, 20, 115, DateTimeKind.Local).AddTicks(1051), 16, 17, "Emily", 2, null },
                    { 59, new DateTime(2022, 3, 20, 8, 11, 15, 894, DateTimeKind.Local).AddTicks(1564), "Voluptatem aut quis laborum nulla.", new DateTime(2021, 8, 19, 5, 24, 0, 288, DateTimeKind.Local).AddTicks(9235), 1, 2, "Icie", 2, null },
                    { 60, new DateTime(2021, 8, 12, 1, 50, 53, 406, DateTimeKind.Local).AddTicks(5734), "Sint ab aut rerum perferendis.", new DateTime(2021, 9, 30, 10, 11, 36, 12, DateTimeKind.Local).AddTicks(357), 3, 1, "Camila", 1, null },
                    { 61, new DateTime(2021, 12, 8, 18, 40, 37, 811, DateTimeKind.Local).AddTicks(8014), "Saepe fugit saepe consequuntur suscipit.", new DateTime(2022, 5, 22, 13, 26, 8, 70, DateTimeKind.Local).AddTicks(9480), 7, 5, "Bernadine", 2, null },
                    { 62, new DateTime(2021, 12, 15, 23, 31, 21, 803, DateTimeKind.Local).AddTicks(1274), "Vitae facere repudiandae quasi sed.", new DateTime(2022, 5, 4, 13, 47, 28, 350, DateTimeKind.Local).AddTicks(696), 17, 5, "Edyth", 0, null },
                    { 63, new DateTime(2022, 2, 18, 3, 9, 44, 711, DateTimeKind.Local).AddTicks(9044), "Qui est consequatur aspernatur ipsam.", new DateTime(2021, 12, 3, 9, 33, 8, 165, DateTimeKind.Local).AddTicks(6105), 3, 13, "Raleigh", 0, null },
                    { 64, new DateTime(2021, 12, 17, 9, 2, 3, 475, DateTimeKind.Local).AddTicks(900), "Quo possimus eum assumenda esse.", new DateTime(2021, 9, 6, 17, 0, 57, 925, DateTimeKind.Local).AddTicks(8901), 16, 11, "Nichole", 3, null },
                    { 65, new DateTime(2021, 11, 7, 21, 50, 57, 182, DateTimeKind.Local).AddTicks(6934), "Suscipit rerum quis consequatur fuga.", new DateTime(2022, 7, 3, 22, 41, 48, 955, DateTimeKind.Local).AddTicks(6810), 28, 1, "Sibyl", 0, null },
                    { 66, new DateTime(2021, 7, 27, 14, 46, 7, 994, DateTimeKind.Local).AddTicks(4109), "Ab voluptatem rerum fugiat explicabo.", null, 18, 19, "Marisa", 2, null },
                    { 67, new DateTime(2022, 4, 6, 19, 44, 9, 761, DateTimeKind.Local).AddTicks(7433), "Eum non tempore porro itaque.", null, 28, 17, "Casimer", 3, null },
                    { 68, new DateTime(2022, 2, 11, 4, 25, 32, 897, DateTimeKind.Local).AddTicks(3132), "Delectus cumque voluptatem perferendis quia.", null, 2, 14, "Skylar", 3, null },
                    { 69, new DateTime(2021, 10, 1, 1, 55, 40, 23, DateTimeKind.Local).AddTicks(5472), "Sequi eos magni ea enim.", new DateTime(2021, 9, 23, 7, 54, 29, 536, DateTimeKind.Local).AddTicks(1992), 22, 18, "Deja", 3, null },
                    { 70, new DateTime(2022, 3, 28, 3, 18, 36, 259, DateTimeKind.Local).AddTicks(2545), "Accusamus sint ea dolorum incidunt.", new DateTime(2021, 11, 28, 14, 40, 1, 287, DateTimeKind.Local).AddTicks(4509), 25, 6, "Jillian", 1, null },
                    { 71, new DateTime(2022, 1, 26, 6, 40, 13, 100, DateTimeKind.Local).AddTicks(5245), "Ut facilis necessitatibus et libero.", new DateTime(2021, 9, 5, 0, 59, 23, 487, DateTimeKind.Local).AddTicks(8396), 20, 15, "Ladarius", 2, null },
                    { 72, new DateTime(2022, 2, 12, 1, 59, 20, 810, DateTimeKind.Local).AddTicks(5676), "Ipsam qui dolor impedit earum.", new DateTime(2021, 10, 19, 10, 7, 14, 833, DateTimeKind.Local).AddTicks(7157), 28, 11, "Marina", 2, null },
                    { 73, new DateTime(2021, 8, 5, 22, 20, 56, 495, DateTimeKind.Local).AddTicks(6810), "Voluptatem debitis placeat dolores aperiam.", null, 15, 6, "Russell", 1, null },
                    { 74, new DateTime(2021, 12, 31, 10, 16, 5, 810, DateTimeKind.Local).AddTicks(4854), "Omnis quas at nihil ut.", new DateTime(2021, 11, 10, 15, 2, 44, 810, DateTimeKind.Local).AddTicks(2100), 22, 10, "Clint", 3, null },
                    { 75, new DateTime(2022, 3, 28, 14, 4, 43, 949, DateTimeKind.Local).AddTicks(8253), "Doloribus error qui nulla qui.", new DateTime(2022, 1, 6, 15, 39, 5, 434, DateTimeKind.Local).AddTicks(1581), 22, 18, "Candida", 3, null },
                    { 76, new DateTime(2022, 6, 6, 7, 25, 48, 387, DateTimeKind.Local).AddTicks(7894), "Qui et eum a harum.", null, 10, 3, "Ofelia", 3, null },
                    { 77, new DateTime(2021, 9, 5, 13, 3, 4, 805, DateTimeKind.Local).AddTicks(8293), "Ut sequi enim aut corporis.", new DateTime(2022, 2, 9, 5, 5, 19, 462, DateTimeKind.Local).AddTicks(9678), 24, 16, "Mariela", 2, null },
                    { 78, new DateTime(2021, 10, 26, 1, 35, 31, 589, DateTimeKind.Local).AddTicks(4375), "Et ut eius vel enim.", new DateTime(2021, 11, 28, 5, 16, 15, 326, DateTimeKind.Local).AddTicks(3873), 11, 3, "Camilla", 1, null },
                    { 79, new DateTime(2021, 9, 5, 6, 36, 50, 929, DateTimeKind.Local).AddTicks(50), "Repellat unde laboriosam assumenda quas.", new DateTime(2021, 8, 31, 13, 31, 12, 393, DateTimeKind.Local).AddTicks(3727), 27, 7, "Jay", 1, null },
                    { 80, new DateTime(2022, 7, 1, 11, 27, 41, 848, DateTimeKind.Local).AddTicks(8136), "Cumque praesentium laudantium sit labore.", new DateTime(2021, 11, 10, 5, 25, 42, 784, DateTimeKind.Local).AddTicks(6361), 1, 12, "Linnea", 1, null },
                    { 81, new DateTime(2022, 1, 16, 8, 18, 24, 213, DateTimeKind.Local).AddTicks(2057), "Officiis et quod laboriosam unde.", new DateTime(2021, 9, 9, 2, 46, 37, 667, DateTimeKind.Local).AddTicks(6091), 7, 1, "Carolyne", 3, null },
                    { 82, new DateTime(2021, 10, 11, 4, 20, 32, 24, DateTimeKind.Local).AddTicks(447), "Autem quis eveniet et dolorem.", new DateTime(2022, 3, 13, 14, 18, 28, 945, DateTimeKind.Local).AddTicks(6114), 14, 1, "Dominique", 3, null },
                    { 83, new DateTime(2021, 7, 22, 0, 29, 1, 969, DateTimeKind.Local).AddTicks(265), "Autem alias illo autem numquam.", null, 21, 19, "Lelah", 0, null },
                    { 84, new DateTime(2022, 2, 21, 16, 49, 57, 858, DateTimeKind.Local).AddTicks(970), "Possimus suscipit distinctio id autem.", new DateTime(2021, 12, 1, 22, 43, 11, 138, DateTimeKind.Local).AddTicks(6891), 15, 19, "Kendra", 3, null }
                });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "CreatedAt", "Description", "FinishedAt", "PerformerId", "ProjectId", "RenamedName", "State", "UserId" },
                values: new object[,]
                {
                    { 85, new DateTime(2022, 2, 28, 12, 57, 34, 715, DateTimeKind.Local).AddTicks(9623), "Voluptates sed dolorem commodi qui.", new DateTime(2022, 1, 1, 18, 36, 3, 442, DateTimeKind.Local).AddTicks(5258), 13, 4, "Laurianne", 1, null },
                    { 86, new DateTime(2021, 8, 22, 22, 41, 58, 136, DateTimeKind.Local).AddTicks(1492), "Corporis id sit at iste.", new DateTime(2022, 1, 12, 12, 40, 3, 988, DateTimeKind.Local).AddTicks(474), 12, 15, "Vickie", 1, null },
                    { 87, new DateTime(2021, 10, 5, 22, 41, 35, 25, DateTimeKind.Local).AddTicks(4505), "Quo aspernatur ullam est ut.", new DateTime(2022, 1, 28, 19, 2, 43, 699, DateTimeKind.Local).AddTicks(3853), 24, 5, "Ebony", 1, null },
                    { 88, new DateTime(2022, 3, 24, 10, 1, 37, 267, DateTimeKind.Local).AddTicks(7511), "Earum dolor quasi sint asperiores.", null, 29, 17, "Jermaine", 3, null },
                    { 89, new DateTime(2021, 12, 29, 18, 6, 5, 11, DateTimeKind.Local).AddTicks(5622), "Sit fuga molestias impedit quidem.", new DateTime(2022, 1, 5, 7, 15, 49, 770, DateTimeKind.Local).AddTicks(6404), 11, 20, "Kendra", 0, null },
                    { 90, new DateTime(2021, 9, 14, 17, 40, 28, 115, DateTimeKind.Local).AddTicks(304), "Iusto voluptate aliquid nam perspiciatis.", new DateTime(2021, 12, 21, 11, 40, 25, 593, DateTimeKind.Local).AddTicks(3328), 17, 10, "Vinnie", 1, null },
                    { 91, new DateTime(2021, 10, 7, 11, 33, 1, 342, DateTimeKind.Local).AddTicks(6953), "Voluptas et aut dolore rerum.", new DateTime(2022, 4, 24, 17, 43, 36, 491, DateTimeKind.Local).AddTicks(6393), 26, 13, "Jeramie", 3, null },
                    { 92, new DateTime(2021, 12, 20, 10, 30, 11, 462, DateTimeKind.Local).AddTicks(3019), "Neque ullam enim ex ex.", new DateTime(2021, 11, 17, 12, 24, 37, 260, DateTimeKind.Local).AddTicks(8605), 6, 11, "Alexanne", 1, null },
                    { 93, new DateTime(2021, 7, 21, 21, 35, 30, 892, DateTimeKind.Local).AddTicks(7380), "Voluptatem non soluta aut similique.", new DateTime(2022, 2, 23, 5, 27, 52, 511, DateTimeKind.Local).AddTicks(5443), 22, 7, "Dalton", 3, null },
                    { 94, new DateTime(2022, 5, 24, 8, 0, 51, 727, DateTimeKind.Local).AddTicks(215), "Sunt quo qui vero sit.", new DateTime(2021, 11, 21, 19, 10, 49, 294, DateTimeKind.Local).AddTicks(4819), 1, 6, "Pascale", 2, null },
                    { 95, new DateTime(2022, 3, 16, 22, 29, 45, 938, DateTimeKind.Local).AddTicks(5997), "Expedita velit enim quis labore.", null, 17, 5, "Chance", 0, null },
                    { 96, new DateTime(2021, 10, 7, 11, 23, 38, 297, DateTimeKind.Local).AddTicks(1239), "Ut maiores distinctio voluptate error.", null, 23, 3, "Wanda", 2, null },
                    { 97, new DateTime(2021, 8, 19, 0, 44, 26, 173, DateTimeKind.Local).AddTicks(8013), "Aut voluptates eius voluptatem deleniti.", null, 4, 4, "Victoria", 3, null },
                    { 98, new DateTime(2021, 9, 4, 8, 11, 45, 766, DateTimeKind.Local).AddTicks(2664), "Accusantium harum quasi vel doloribus.", new DateTime(2022, 6, 25, 7, 25, 57, 586, DateTimeKind.Local).AddTicks(6667), 5, 11, "Emmitt", 3, null },
                    { 99, new DateTime(2021, 7, 30, 17, 56, 9, 183, DateTimeKind.Local).AddTicks(2126), "Architecto et quos corporis quos.", new DateTime(2022, 4, 23, 23, 18, 39, 480, DateTimeKind.Local).AddTicks(8960), 4, 13, "Adrien", 1, null },
                    { 100, new DateTime(2021, 10, 31, 0, 26, 24, 553, DateTimeKind.Local).AddTicks(6592), "Quia eveniet sit in officiis.", new DateTime(2022, 6, 5, 9, 27, 29, 568, DateTimeKind.Local).AddTicks(7402), 17, 14, "Oswald", 3, null }
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
