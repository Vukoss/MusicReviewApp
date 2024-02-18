using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MusicReviewAPI.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Country = table.Column<string>(type: "text", nullable: true),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    GenreName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Musicians",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "text", nullable: true),
                    LastName = table.Column<string>(type: "text", nullable: true),
                    Nickname = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Musicians", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    ProviderKey = table.Column<string>(type: "text", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    RoleId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Albums",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Country = table.Column<string>(type: "text", nullable: true),
                    Label = table.Column<string>(type: "text", nullable: true),
                    Duration = table.Column<double>(type: "double precision", nullable: true),
                    BandId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Albums", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Albums_Bands_BandId",
                        column: x => x.BandId,
                        principalTable: "Bands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BandGenre",
                columns: table => new
                {
                    BandId = table.Column<int>(type: "integer", nullable: false),
                    GenreId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BandGenre", x => new { x.BandId, x.GenreId });
                    table.ForeignKey(
                        name: "FK_BandGenre_Bands_BandId",
                        column: x => x.BandId,
                        principalTable: "Bands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BandGenre_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MusicianBand",
                columns: table => new
                {
                    MusicianId = table.Column<int>(type: "integer", nullable: false),
                    BandId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MusicianBand", x => new { x.BandId, x.MusicianId });
                    table.ForeignKey(
                        name: "FK_MusicianBand_Bands_BandId",
                        column: x => x.BandId,
                        principalTable: "Bands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MusicianBand_Musicians_MusicianId",
                        column: x => x.MusicianId,
                        principalTable: "Musicians",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MusicianGenre",
                columns: table => new
                {
                    MusicianId = table.Column<int>(type: "integer", nullable: false),
                    GenreId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MusicianGenre", x => new { x.MusicianId, x.GenreId });
                    table.ForeignKey(
                        name: "FK_MusicianGenre_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MusicianGenre_Musicians_MusicianId",
                        column: x => x.MusicianId,
                        principalTable: "Musicians",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AlbumGenre",
                columns: table => new
                {
                    AlbumId = table.Column<int>(type: "integer", nullable: false),
                    GenreId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlbumGenre", x => new { x.AlbumId, x.GenreId });
                    table.ForeignKey(
                        name: "FK_AlbumGenre_Albums_AlbumId",
                        column: x => x.AlbumId,
                        principalTable: "Albums",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlbumGenre_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tracks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TrackName = table.Column<string>(type: "text", nullable: false),
                    AlbumId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tracks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tracks_Albums_AlbumId",
                        column: x => x.AlbumId,
                        principalTable: "Albums",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GenreTrack",
                columns: table => new
                {
                    GenresId = table.Column<int>(type: "integer", nullable: false),
                    TracksId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenreTrack", x => new { x.GenresId, x.TracksId });
                    table.ForeignKey(
                        name: "FK_GenreTrack_Genres_GenresId",
                        column: x => x.GenresId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GenreTrack_Tracks_TracksId",
                        column: x => x.TracksId,
                        principalTable: "Tracks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Text = table.Column<string>(type: "text", nullable: false),
                    Rating = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    AlbumId = table.Column<int>(type: "integer", nullable: true),
                    TrackId = table.Column<int>(type: "integer", nullable: true),
                    BandId = table.Column<int>(type: "integer", nullable: true),
                    MusicianId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_Albums_AlbumId",
                        column: x => x.AlbumId,
                        principalTable: "Albums",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Reviews_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reviews_Bands_BandId",
                        column: x => x.BandId,
                        principalTable: "Bands",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Reviews_Musicians_MusicianId",
                        column: x => x.MusicianId,
                        principalTable: "Musicians",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Reviews_Tracks_TrackId",
                        column: x => x.TrackId,
                        principalTable: "Tracks",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d5e4f75c-cbd1-4258-9033-006fd9065a19", null, "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "dbf6c373-7249-4c7e-841f-565141fe184f", 0, "04ba3b16-48fd-485c-9ae4-9a0a039027cb", "admin@admin.pl", true, false, null, "ADMIN@ADMIN.PL", "ADMIN@ADMIN.PL", "AQAAAAIAAYagAAAAEGPJD3it3ADyx9drI0rFf8OMYe/Q8y8PLrT1Nx9OUrpE4/xaWRyUpu/E7QiDQ99T/Q==", null, false, "f7eb0546-c43b-493a-ad54-fe06a397a52a", false, "admin@admin.pl" });

            migrationBuilder.InsertData(
                table: "Bands",
                columns: new[] { "Id", "Country", "Name", "StartDate" },
                values: new object[,]
                {
                    { 1, "Poland", "Band_1", new DateTime(2024, 2, 18, 18, 8, 44, 516, DateTimeKind.Utc).AddTicks(4890) },
                    { 2, "Poland", "Band_2", new DateTime(2024, 2, 18, 18, 8, 44, 516, DateTimeKind.Utc).AddTicks(4890) },
                    { 3, "Poland", "Band_2", new DateTime(2024, 2, 18, 18, 8, 44, 516, DateTimeKind.Utc).AddTicks(4890) }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "GenreName" },
                values: new object[,]
                {
                    { 1, "Rock" },
                    { 2, "Indie" },
                    { 3, "Jazz" },
                    { 4, "Smooth Jazz" },
                    { 5, "Electronic" },
                    { 6, "Pop" },
                    { 7, "Indie Pop" },
                    { 8, "Classic" },
                    { 9, "Metal" }
                });

            migrationBuilder.InsertData(
                table: "Musicians",
                columns: new[] { "Id", "FirstName", "LastName", "Nickname" },
                values: new object[,]
                {
                    { 1, "John", "Travolta", "Johnny" },
                    { 2, "Winston", "Schmidt", "Schmidt" },
                    { 3, "Winston", "Bishop", "Bishop" },
                    { 4, "Jessica", "Day", "Day" },
                    { 5, "Nick", "Miller", "Miller" },
                    { 6, "Monicka", "Geller", "Geller" },
                    { 7, "Chandler", "Bing", "Bing" },
                    { 8, "Jack", "Geller", "Geller" },
                    { 9, "Will", "Smith", "Smith" },
                    { 10, "Leonardo", "DiCaprio", "DiCaprio" }
                });

            migrationBuilder.InsertData(
                table: "Albums",
                columns: new[] { "Id", "BandId", "Country", "Duration", "Label", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Poland", 11.109999999999999, "Kayah", "Album_1" },
                    { 2, 1, "Poland", 11.109999999999999, "Kayah", "Album_2" },
                    { 3, 1, "Poland", 11.109999999999999, "Kayah", "Album_3" },
                    { 4, 2, "Poland", 11.109999999999999, "Kayah", "Album_4" },
                    { 5, 2, "Poland", 11.109999999999999, "Kayah", "Album_5" },
                    { 6, 2, "Poland", 11.109999999999999, "Kayah", "Album_6" },
                    { 7, 3, "Poland", 11.109999999999999, "Kayah", "Album_7" },
                    { 8, 3, "Poland", 11.109999999999999, "Kayah", "Album_8" },
                    { 9, 3, "Poland", 11.109999999999999, "Kayah", "Album_9" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "d5e4f75c-cbd1-4258-9033-006fd9065a19", "dbf6c373-7249-4c7e-841f-565141fe184f" });

            migrationBuilder.InsertData(
                table: "BandGenre",
                columns: new[] { "BandId", "GenreId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 1, 3 },
                    { 2, 4 },
                    { 2, 5 },
                    { 2, 6 },
                    { 3, 7 },
                    { 3, 8 },
                    { 3, 9 }
                });

            migrationBuilder.InsertData(
                table: "MusicianBand",
                columns: new[] { "BandId", "MusicianId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 1, 3 },
                    { 1, 4 },
                    { 2, 5 },
                    { 2, 6 },
                    { 2, 7 },
                    { 2, 8 },
                    { 3, 9 },
                    { 3, 10 }
                });

            migrationBuilder.InsertData(
                table: "MusicianGenre",
                columns: new[] { "GenreId", "MusicianId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 },
                    { 4, 4 },
                    { 5, 5 },
                    { 6, 6 },
                    { 7, 7 },
                    { 8, 8 },
                    { 9, 9 },
                    { 9, 10 }
                });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "AlbumId", "BandId", "MusicianId", "Rating", "Text", "TrackId", "UserId" },
                values: new object[,]
                {
                    { 10, null, 1, null, 5, "Best", null, "dbf6c373-7249-4c7e-841f-565141fe184f" },
                    { 11, null, 1, null, 4, "Great", null, "dbf6c373-7249-4c7e-841f-565141fe184f" },
                    { 12, null, 1, null, 3, "Good", null, "dbf6c373-7249-4c7e-841f-565141fe184f" },
                    { 13, null, 2, null, 5, "Best", null, "dbf6c373-7249-4c7e-841f-565141fe184f" },
                    { 14, null, 2, null, 4, "Great", null, "dbf6c373-7249-4c7e-841f-565141fe184f" },
                    { 15, null, 2, null, 3, "Good", null, "dbf6c373-7249-4c7e-841f-565141fe184f" },
                    { 16, null, 3, null, 5, "Best", null, "dbf6c373-7249-4c7e-841f-565141fe184f" },
                    { 17, null, 3, null, 4, "Great", null, "dbf6c373-7249-4c7e-841f-565141fe184f" },
                    { 18, null, 3, null, 3, "Good", null, "dbf6c373-7249-4c7e-841f-565141fe184f" },
                    { 19, null, null, 1, 5, "Best", null, "dbf6c373-7249-4c7e-841f-565141fe184f" },
                    { 20, null, null, 1, 4, "Great", null, "dbf6c373-7249-4c7e-841f-565141fe184f" },
                    { 21, null, null, 1, 3, "Good", null, "dbf6c373-7249-4c7e-841f-565141fe184f" },
                    { 22, null, null, 2, 5, "Best", null, "dbf6c373-7249-4c7e-841f-565141fe184f" },
                    { 23, null, null, 2, 4, "Great", null, "dbf6c373-7249-4c7e-841f-565141fe184f" },
                    { 24, null, null, 2, 3, "Good", null, "dbf6c373-7249-4c7e-841f-565141fe184f" },
                    { 25, null, null, 3, 5, "Best", null, "dbf6c373-7249-4c7e-841f-565141fe184f" },
                    { 26, null, null, 3, 4, "Great", null, "dbf6c373-7249-4c7e-841f-565141fe184f" },
                    { 27, null, null, 3, 3, "Good", null, "dbf6c373-7249-4c7e-841f-565141fe184f" }
                });

            migrationBuilder.InsertData(
                table: "AlbumGenre",
                columns: new[] { "AlbumId", "GenreId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 },
                    { 4, 4 },
                    { 5, 5 },
                    { 6, 6 },
                    { 7, 7 },
                    { 8, 8 },
                    { 9, 9 }
                });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "AlbumId", "BandId", "MusicianId", "Rating", "Text", "TrackId", "UserId" },
                values: new object[,]
                {
                    { 1, 1, null, null, 5, "Best", null, "dbf6c373-7249-4c7e-841f-565141fe184f" },
                    { 2, 1, null, null, 4, "Great", null, "dbf6c373-7249-4c7e-841f-565141fe184f" },
                    { 3, 1, null, null, 3, "Good", null, "dbf6c373-7249-4c7e-841f-565141fe184f" },
                    { 4, 2, null, null, 5, "Best", null, "dbf6c373-7249-4c7e-841f-565141fe184f" },
                    { 5, 2, null, null, 4, "Great", null, "dbf6c373-7249-4c7e-841f-565141fe184f" },
                    { 6, 2, null, null, 3, "Good", null, "dbf6c373-7249-4c7e-841f-565141fe184f" },
                    { 7, 3, null, null, 5, "Best", null, "dbf6c373-7249-4c7e-841f-565141fe184f" },
                    { 8, 3, null, null, 4, "Great", null, "dbf6c373-7249-4c7e-841f-565141fe184f" },
                    { 9, 3, null, null, 3, "Good", null, "dbf6c373-7249-4c7e-841f-565141fe184f" }
                });

            migrationBuilder.InsertData(
                table: "Tracks",
                columns: new[] { "Id", "AlbumId", "TrackName" },
                values: new object[,]
                {
                    { 1, 1, "Track_1_A1" },
                    { 2, 1, "Track_2_A1" },
                    { 3, 1, "Track_3_A1" },
                    { 4, 2, "Track_1_A2" },
                    { 5, 2, "Track_2_A2" },
                    { 6, 2, "Track_3_A2" },
                    { 7, 3, "Track_1_A3" },
                    { 8, 3, "Track_2_A3" },
                    { 9, 3, "Track_3_A3" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AlbumGenre_GenreId",
                table: "AlbumGenre",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_Albums_BandId",
                table: "Albums",
                column: "BandId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BandGenre_GenreId",
                table: "BandGenre",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_GenreTrack_TracksId",
                table: "GenreTrack",
                column: "TracksId");

            migrationBuilder.CreateIndex(
                name: "IX_MusicianBand_MusicianId",
                table: "MusicianBand",
                column: "MusicianId");

            migrationBuilder.CreateIndex(
                name: "IX_MusicianGenre_GenreId",
                table: "MusicianGenre",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_AlbumId",
                table: "Reviews",
                column: "AlbumId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_BandId",
                table: "Reviews",
                column: "BandId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_MusicianId",
                table: "Reviews",
                column: "MusicianId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_TrackId",
                table: "Reviews",
                column: "TrackId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_UserId",
                table: "Reviews",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Tracks_AlbumId",
                table: "Tracks",
                column: "AlbumId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlbumGenre");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "BandGenre");

            migrationBuilder.DropTable(
                name: "GenreTrack");

            migrationBuilder.DropTable(
                name: "MusicianBand");

            migrationBuilder.DropTable(
                name: "MusicianGenre");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Musicians");

            migrationBuilder.DropTable(
                name: "Tracks");

            migrationBuilder.DropTable(
                name: "Albums");

            migrationBuilder.DropTable(
                name: "Bands");
        }
    }
}
