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
                    ProductionId = table.Column<int>(type: "int", nullable: true),
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
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Productions_ProductionId",
                        column: x => x.ProductionId,
                        principalTable: "Productions",
                        principalColumn: "Id",
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
                    ProductionId = table.Column<int>(type: "int", nullable: false)
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
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    PriceFor = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductionId = table.Column<int>(type: "int", nullable: false),
                    RealStock = table.Column<int>(type: "int", nullable: false),
                    OrderedStock = table.Column<int>(type: "int", nullable: false),
                    NotOrderedStock = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Productions_ProductionId",
                        column: x => x.ProductionId,
                        principalTable: "Productions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    Price = table.Column<int>(type: "int", maxLength: 6, nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProductionId = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeliveryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClientId1 = table.Column<string>(type: "nvarchar(50)", nullable: true)
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
                        name: "FK_Orders_Clients_ClientId1",
                        column: x => x.ClientId1,
                        principalTable: "Clients",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_Productions_ProductionId",
                        column: x => x.ProductionId,
                        principalTable: "Productions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProdTasksUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProdTaskId = table.Column<int>(type: "int", nullable: false)
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
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PositionInRoom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsGrowing = table.Column<bool>(type: "bit", nullable: true),
                    RecoltedQuantitie = table.Column<double>(type: "float", nullable: true),
                    EstimatedQuantitie = table.Column<double>(type: "float", nullable: true),
                    QuantitificationUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MinEstimation = table.Column<double>(type: "float", nullable: true),
                    MaxEstimation = table.Column<double>(type: "float", nullable: true)
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
                        principalColumn: "Id");
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

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BirthDay", "City", "ConcurrencyStamp", "Country", "Email", "EmailConfirmed", "FirstName", "ImageUrl", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "Number", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProductionId", "SecurityStamp", "Street", "TwoFactorEnabled", "UserName", "ZIP" },
                values: new object[,]
                {
                    { "1", 0, new DateTime(2022, 5, 23, 21, 28, 45, 293, DateTimeKind.Local).AddTicks(6117), "Bruxelles", "3009ee62-14ad-4214-b5f8-5eefb719ea9b", "Belgium", "max@intec.be", true, "Maximilian", null, "Poniatowski", false, null, "MAX@INTEC.BE", "MAX", 5, "AQAAAAEAACcQAAAAEHScFWpMe/tRyGdLpMthOtCNuYBgyEhsUz0x8ztIeVIKo8DX8oHZrKtYkEwkVlRmkw==", "02/789.321", false, null, "9d4d65f4-bc9d-412e-a1dc-86f23813b6ac", "Nieuwe Straat", false, "max", 1000 },
                    { "2", 0, new DateTime(2022, 5, 23, 21, 28, 45, 310, DateTimeKind.Local).AddTicks(3172), "Bruxelles", "886a706b-70ad-4afb-a3f1-10bf1b577502", "Belgium", "admin@intec.be", true, "Admin", null, "The first one", false, null, "ADMIN@INTEC.BE", "ADMIN", 5, "AQAAAAEAACcQAAAAEHScFWpMe/tRyGdLpMthOtCNuYBgyEhsUz0x8ztIeVIKo8DX8oHZrKtYkEwkVlRmkw==", "02/189.181", false, null, "e24308a9-f470-4282-a51f-9679315fa62f", "Nieuwe Straat", false, "admin", 1000 }
                });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "ClientId", "City", "Country", "Email", "ImageUrl", "Number", "PhoneNumber", "Street", "ZIP" },
                values: new object[,]
                {
                    { "Luxus Restaurant", "Bruxelles", "Belgium", "LuxusRest@outlook.be", null, 5, "02/458.124", "Food Straat", 1000 },
                    { "SmartKitchens-Anderlecht", "Bruxelles", "Belgium", "SmartKitchens1000@outlook.be", null, 152, "02/358.424", "Food Straat", 1000 },
                    { "RoyVeggies", "Bruxelles", "Belgium", "RoyBalzac@outlook.be", null, 5, "02/124.124", "Butcher's Street", 1000 }
                });

            migrationBuilder.InsertData(
                table: "Productions",
                columns: new[] { "Id", "City", "Country", "Email", "Number", "PhoneNumber", "ProductionName", "Street", "ZIP" },
                values: new object[] { 1, "Bruxelles", "Belgium", "SmartFood@smartfood.com", 10, "02/153.154", "SmartFood-Brusels", "High Street", 1000 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "ImageUrl", "NotOrderedStock", "OrderedStock", "Price", "PriceFor", "ProductName", "ProductionId", "RealStock" },
                values: new object[,]
                {
                    { 1, null, 45, 15, 18, "kilogram", "Shitake", 1, 60 },
                    { 2, null, 6, 56, 26, "kilogram", "Maitake", 1, 62 }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "ProductionId", "RoomName" },
                values: new object[,]
                {
                    { 1, 1, "Room 1" },
                    { 2, 1, "Room 2" },
                    { 3, 1, "Room 3" }
                });

            migrationBuilder.InsertData(
                table: "Lots",
                columns: new[] { "Id", "EndDate", "EstimatedQuantitie", "IsGrowing", "MaxEstimation", "MinEstimation", "PositionInRoom", "ProductId", "ProductName", "QuantitificationUnit", "RecoltedQuantitie", "RoomId", "StartDate" },
                values: new object[] { 1, null, 50.0, true, 60.0, 40.0, "DanishTrolley 12, 13, 14", 1, "Shitake", "Kg", 24.5, 1, new DateTime(2022, 5, 18, 21, 28, 45, 311, DateTimeKind.Local).AddTicks(2465) });

            migrationBuilder.InsertData(
                table: "Lots",
                columns: new[] { "Id", "EndDate", "EstimatedQuantitie", "IsGrowing", "MaxEstimation", "MinEstimation", "PositionInRoom", "ProductId", "ProductName", "QuantitificationUnit", "RecoltedQuantitie", "RoomId", "StartDate" },
                values: new object[] { 2, null, 50.0, true, 60.0, 40.0, "DanishTrolley 15, 16, 17", 1, "Shitake", "Kg", 0.0, 1, new DateTime(2022, 5, 23, 21, 28, 45, 311, DateTimeKind.Local).AddTicks(6026) });

            migrationBuilder.InsertData(
                table: "Lots",
                columns: new[] { "Id", "EndDate", "EstimatedQuantitie", "IsGrowing", "MaxEstimation", "MinEstimation", "PositionInRoom", "ProductId", "ProductName", "QuantitificationUnit", "RecoltedQuantitie", "RoomId", "StartDate" },
                values: new object[] { 3, null, 15.0, true, 20.0, 10.0, "In the middle of the central column", 2, "Maitake", "Kg", 0.0, 3, new DateTime(2022, 5, 23, 21, 28, 45, 311, DateTimeKind.Local).AddTicks(6048) });

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
                name: "IX_AspNetUsers_ProductionId",
                table: "AspNetUsers",
                column: "ProductionId");

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
                name: "IX_Orders_ClientId1",
                table: "Orders",
                column: "ClientId1");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ProductionId",
                table: "Orders",
                column: "ProductionId");

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
                name: "IX_Products_ProductionId",
                table: "Products",
                column: "ProductionId");

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
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Productions");
        }
    }
}
