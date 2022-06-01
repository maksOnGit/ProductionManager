using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProductionManager_EndProject.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Country = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ZIP = table.Column<int>(type: "int", maxLength: 50, nullable: false),
                    Street = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Number = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthDay = table.Column<DateTime>(type: "datetime2", maxLength: 50, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    ClientId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Country = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ZIP = table.Column<int>(type: "int", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Number = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.ClientId);
                });

            migrationBuilder.CreateTable(
                name: "ProdTaskStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdTaskStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Productions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ProductionName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Country = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ZIP = table.Column<int>(type: "int", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Number = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    PriceFor = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RealStock = table.Column<double>(type: "float", nullable: false),
                    OrderedStock = table.Column<double>(type: "float", nullable: true),
                    NotOrderedStock = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Reference = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Price = table.Column<double>(type: "float", maxLength: 6, nullable: false),
                    ClientId = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeliveryDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProdTasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaskName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TaskDescription = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ProdTaskStatusId = table.Column<int>(type: "int", nullable: false),
                    ProductionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdTasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProdTasks_ProdTaskStatuses_ProdTaskStatusId",
                        column: x => x.ProdTaskStatusId,
                        principalTable: "ProdTaskStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProdTasks_Productions_ProductionId",
                        column: x => x.ProductionId,
                        principalTable: "Productions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ProductionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rooms_Productions_ProductionId",
                        column: x => x.ProductionId,
                        principalTable: "Productions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductOrders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductOrders_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductOrders_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProdTasksUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProdTaskId = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdTasksUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProdTasksUsers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProdTasksUsers_ProdTasks_ProdTaskId",
                        column: x => x.ProdTaskId,
                        principalTable: "ProdTasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Lots",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Reference = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsGrowing = table.Column<bool>(type: "bit", nullable: true),
                    RecoltedQuantitie = table.Column<double>(type: "float", nullable: false),
                    EstimatedQuantitie = table.Column<double>(type: "float", nullable: false),
                    UnitType = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lots", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lots_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Lots_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1", "dfdsf", "admin", "ADMIN" },
                    { "2", "dfd4564sf", "manager", "MANAGER" },
                    { "3", "dfdsffds", "worker", "WORKER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BirthDay", "City", "ConcurrencyStamp", "Country", "Email", "EmailConfirmed", "FirstName", "ImageUrl", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "Number", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Street", "TwoFactorEnabled", "UserName", "ZIP" },
                values: new object[,]
                {
                    { "2", 0, new DateTime(2022, 6, 1, 3, 8, 35, 781, DateTimeKind.Local).AddTicks(4268), "Bruxelles", "0804f8ae-f938-4cba-b490-2aa18b55ebfa", "Belgium", "admin@intec.be", true, "Admin", null, "The first one", false, null, "ADMIN@INTEC.BE", "ADMIN", 5, "AQAAAAEAACcQAAAAENcfhOix6dZlNmzoJXdzh+ME3CDBWry8Knrt98yHKxmabyL9AE919xKsTAWVIHp26A==", "02/189.181", false, "283ffb98-47b8-4a52-b5c7-56e80f0b6ce5", "Nieuwe Straat", false, "admin", 1000 },
                    { "1", 0, new DateTime(2022, 6, 1, 3, 8, 35, 776, DateTimeKind.Local).AddTicks(8674), "Bruxelles", "f1dea21f-79d3-4f42-8934-aff1b5fdac2e", "Belgium", "max@intec.be", true, "Maximilian", null, "Poniatowski", false, null, "MAX@INTEC.BE", "MAX", 5, "AQAAAAEAACcQAAAAENcfhOix6dZlNmzoJXdzh+ME3CDBWry8Knrt98yHKxmabyL9AE919xKsTAWVIHp26A==", "02/789.321", false, "3b3215bb-d5a7-4c9e-92ae-f7880e36fe36", "Nieuwe Straat", false, "max", 1000 },
                    { "3", 0, new DateTime(2022, 6, 1, 3, 8, 35, 781, DateTimeKind.Local).AddTicks(4330), "Bruxelles", "4e9d2dcc-5e15-4b2a-8350-69e6cce68a2b", "Belgium", "worker@intec.be", true, "Worker", null, "The first one", false, null, "WORKER@INTEC.BE", "WORKER", 5, "AQAAAAEAACcQAAAAENcfhOix6dZlNmzoJXdzh+ME3CDBWry8Knrt98yHKxmabyL9AE919xKsTAWVIHp26A==", "02/189.181", false, "d9d296a9-b697-40f0-adde-6fa0a1b15e35", "Nieuwe Straat", false, "worker", 1000 },
                    { "4", 0, new DateTime(2022, 6, 1, 3, 8, 35, 781, DateTimeKind.Local).AddTicks(4345), "Bruxelles", "6f02c956-a23d-453b-b306-b327c5f71603", "Belgium", "worker@intec.be", true, "Manager", null, "The first one", false, null, "MANAGER@INTEC.BE", "MANAGER", 5, "AQAAAAEAACcQAAAAENcfhOix6dZlNmzoJXdzh+ME3CDBWry8Knrt98yHKxmabyL9AE919xKsTAWVIHp26A==", "02/189.181", false, "b82f2136-fde6-4dca-a61b-18fafdcd5637", "Nieuwe Straat", false, "manager", 1000 }
                });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "ClientId", "City", "Country", "Email", "ImageUrl", "Number", "PhoneNumber", "Street", "ZIP" },
                values: new object[,]
                {
                    { "RoyVeggies", "Bruxelles", "Belgium", "RoyBalzac@outlook.be", null, 5, "02/124.124", "Butcher's Street", 1000 },
                    { "SmartKitchens-Anderlecht", "Bruxelles", "Belgium", "SmartKitchens1000@outlook.be", null, 152, "02/358.424", "Food Straat", 1000 },
                    { "Luxus Restaurant", "Bruxelles", "Belgium", "LuxusRest@outlook.be", null, 5, "02/458.124", "Food Straat", 1000 }
                });

            migrationBuilder.InsertData(
                table: "ProdTaskStatuses",
                columns: new[] { "Id", "StatusName" },
                values: new object[,]
                {
                    { 2, "Assigned" },
                    { 3, "Closed" },
                    { 1, "New" }
                });

            migrationBuilder.InsertData(
                table: "Productions",
                columns: new[] { "Id", "City", "Country", "Email", "Number", "PhoneNumber", "ProductionName", "Street", "ZIP" },
                values: new object[,]
                {
                    { 1, "Bruxelles", "Belgium", "SmartFood@smartfood.com", 10, "02/153.154", "SmartFood", "High Street", 1000 },
                    { 2, "Bruxelles", "Belgium", "SmartFoodGreen@smartfood.com", 10, "02/153.154", "SmartFoodGreens", "High Street", 1000 },
                    { 3, "Bruxelles", "Belgium", "SmartFoodSpace@smartfood.com", 10, "02/153.154", "SmartFoodSpace-Brusels", "High Street", 1000 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "ImageUrl", "NotOrderedStock", "OrderedStock", "Price", "PriceFor", "ProductName", "RealStock" },
                values: new object[,]
                {
                    { 1, null, 0.0, 0.0, 18.0, "Kilogram", "Shitake", 40.579999999999998 },
                    { 3, null, 0.0, 0.0, 20.0, "Kilogram", "Nameko", 0.0 },
                    { 4, null, 0.0, 0.0, 10.0, "Unit", "Amaranth", 0.0 },
                    { 5, null, 0.0, 0.0, 6.5, "Unit", "Black Mustard", 0.0 },
                    { 6, null, 0.0, 0.0, 5.2000000000000002, "Unit", "Sunflower", 0.0 },
                    { 2, null, 0.0, 0.0, 26.5, "Kilogram", "Maitake", 0.0 }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "1", "2" },
                    { "3", "3" },
                    { "2", "4" }
                });

            migrationBuilder.InsertData(
                table: "ProdTasks",
                columns: new[] { "Id", "ProdTaskStatusId", "ProductionId", "TaskDescription", "TaskName" },
                values: new object[,]
                {
                    { 1, 1, 1, "- Recolt Shitake in growing room 1 and clean old substracts", "Recolt" },
                    { 2, 1, 1, "- Recolt Maitake in growing room 3 and clean old substracts", "Recolt" },
                    { 3, 1, 1, "- Check if we have substracts ready to go into the growing rooms", "Grow" },
                    { 4, 1, 1, "- Big Cleaning of growing room 2", "Clean" }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "ProductionId", "RoomName" },
                values: new object[,]
                {
                    { 1, 1, "Growing Room 1" },
                    { 2, 1, "Growing Room 2" },
                    { 3, 1, "Growing Room 3" },
                    { 4, 2, "MicroGreen Room 1" },
                    { 5, 2, "MicroGreen Room 2" },
                    { 6, 2, "MicroGreen Room 3" }
                });

            migrationBuilder.InsertData(
                table: "Lots",
                columns: new[] { "Id", "Description", "EndDate", "EstimatedQuantitie", "IsGrowing", "ProductId", "ProductName", "RecoltedQuantitie", "Reference", "RoomId", "StartDate", "UnitType" },
                values: new object[,]
                {
                    { 1, "DanishTrolley 12, 13, 14", null, 50.0, true, 1, "Shitake", 28.0, "SHIe14022022-14026045", 1, new DateTime(2022, 5, 27, 3, 8, 35, 782, DateTimeKind.Local).AddTicks(3584), "Kilogram" },
                    { 2, "DanishTrolley 15, 16, 17", null, 50.0, true, 1, "Shitake", 12.58, "SHIe15022022-17048045", 1, new DateTime(2022, 6, 1, 3, 8, 35, 782, DateTimeKind.Local).AddTicks(6080), "Kilogram" },
                    { 3, "In the middle of the central column", null, 15.0, true, 2, "Maitake", 0.0, "MAIe15022022-17057055", 3, new DateTime(2022, 6, 1, 3, 8, 35, 782, DateTimeKind.Local).AddTicks(6099), "Kilogram" },
                    { 4, "In the middle of the central column", null, 30.0, true, 4, "Amaranth", 0.0, "MAIe21022022-08033014", 4, new DateTime(2022, 6, 1, 3, 8, 35, 782, DateTimeKind.Local).AddTicks(6104), "Unit" },
                    { 5, "In the middle of the central column", null, 50.0, true, 5, "Black Mustard", 0.0, "BLAm22022022-14034012", 5, new DateTime(2022, 6, 1, 3, 8, 35, 782, DateTimeKind.Local).AddTicks(6109), "Unit" },
                    { 6, "In the middle of the central column", null, 80.0, true, 6, "Sunflower", 0.0, "SUNr25022022-18020005", 6, new DateTime(2022, 6, 1, 3, 8, 35, 782, DateTimeKind.Local).AddTicks(6114), "Unit" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

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
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Lots_ProductId",
                table: "Lots",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Lots_RoomId",
                table: "Lots",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ClientId",
                table: "Orders",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProdTasks_ProdTaskStatusId",
                table: "ProdTasks",
                column: "ProdTaskStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_ProdTasks_ProductionId",
                table: "ProdTasks",
                column: "ProductionId");

            migrationBuilder.CreateIndex(
                name: "IX_ProdTasksUsers_ProdTaskId",
                table: "ProdTasksUsers",
                column: "ProdTaskId");

            migrationBuilder.CreateIndex(
                name: "IX_ProdTasksUsers_UserId",
                table: "ProdTasksUsers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Productions_ProductionName",
                table: "Productions",
                column: "ProductionName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductOrders_OrderId",
                table: "ProductOrders",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductOrders_ProductId",
                table: "ProductOrders",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_ProductionId",
                table: "Rooms",
                column: "ProductionId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_RoomName",
                table: "Rooms",
                column: "RoomName",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                name: "Lots");

            migrationBuilder.DropTable(
                name: "ProdTasksUsers");

            migrationBuilder.DropTable(
                name: "ProductOrders");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "ProdTasks");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "ProdTaskStatuses");

            migrationBuilder.DropTable(
                name: "Productions");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Clients");
        }
    }
}
