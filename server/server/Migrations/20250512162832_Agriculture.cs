using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace server.Migrations
{
    /// <inheritdoc />
    public partial class Agriculture : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Phone = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Address = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Login = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Password = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Role = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "SeedCrops",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Amount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeedCrops", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Warehouses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Warehouses", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Fields",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    CultivatedArea = table.Column<double>(type: "double", nullable: false),
                    UncultivatedArea = table.Column<double>(type: "double", nullable: false),
                    CropId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fields", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fields_SeedCrops_CropId",
                        column: x => x.CropId,
                        principalTable: "SeedCrops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MachineryEquipment",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DateBought = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    WarehouseId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MachineryEquipment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MachineryEquipment_Warehouses_WarehouseId",
                        column: x => x.WarehouseId,
                        principalTable: "Warehouses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Pastures",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Area = table.Column<double>(type: "double", nullable: false),
                    FieldId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pastures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pastures_Fields_FieldId",
                        column: x => x.FieldId,
                        principalTable: "Fields",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "WorkOnFields",
                columns: table => new
                {
                    FieldId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    EmployeeId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkOnFields", x => new { x.EmployeeId, x.FieldId });
                    table.ForeignKey(
                        name: "FK_WorkOnFields_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkOnFields_Fields_FieldId",
                        column: x => x.FieldId,
                        principalTable: "Fields",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "EquipmentOnFields",
                columns: table => new
                {
                    EquipmentId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    FieldId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentOnFields", x => new { x.EquipmentId, x.FieldId });
                    table.ForeignKey(
                        name: "FK_EquipmentOnFields_Fields_FieldId",
                        column: x => x.FieldId,
                        principalTable: "Fields",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EquipmentOnFields_MachineryEquipment_EquipmentId",
                        column: x => x.EquipmentId,
                        principalTable: "MachineryEquipment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "RepairLogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    EquipmentId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    EmployeeId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    DateOfBreakage = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DateOfRepair = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CauseOfBreakage = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RepairLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RepairLogs_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RepairLogs_MachineryEquipment_EquipmentId",
                        column: x => x.EquipmentId,
                        principalTable: "MachineryEquipment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Animals",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PastureId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Animals_Pastures_PastureId",
                        column: x => x.PastureId,
                        principalTable: "Pastures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Address", "Login", "Name", "Password", "Phone", "Role" },
                values: new object[] { new Guid("33333333-3333-3333-3333-333333333333"), "г. Могилёв", "vladimir", "Владимир", "1234", "+375123456789", "Admin" });

            migrationBuilder.InsertData(
                table: "SeedCrops",
                columns: new[] { "Id", "Amount", "Name" },
                values: new object[] { new Guid("22222222-2222-2222-2222-222222222222"), 12, "Пшеница" });

            migrationBuilder.InsertData(
                table: "Warehouses",
                columns: new[] { "Id", "UpdatedAt" },
                values: new object[] { new Guid("88888888-8888-8888-8888-888888888888"), new DateTime(2024, 11, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Fields",
                columns: new[] { "Id", "CropId", "CultivatedArea", "UncultivatedArea" },
                values: new object[] { new Guid("44444444-4444-4444-4444-444444444444"), new Guid("22222222-2222-2222-2222-222222222222"), 25.5, 4.5 });

            migrationBuilder.InsertData(
                table: "MachineryEquipment",
                columns: new[] { "Id", "DateBought", "Name", "WarehouseId" },
                values: new object[] { new Guid("55555555-5555-5555-5555-555555555555"), new DateTime(2024, 11, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Трактор", new Guid("88888888-8888-8888-8888-888888888888") });

            migrationBuilder.InsertData(
                table: "EquipmentOnFields",
                columns: new[] { "EquipmentId", "FieldId" },
                values: new object[] { new Guid("55555555-5555-5555-5555-555555555555"), new Guid("44444444-4444-4444-4444-444444444444") });

            migrationBuilder.InsertData(
                table: "Pastures",
                columns: new[] { "Id", "Area", "FieldId" },
                values: new object[] { new Guid("66666666-6666-6666-6666-666666666666"), 5.5, new Guid("44444444-4444-4444-4444-444444444444") });

            migrationBuilder.InsertData(
                table: "RepairLogs",
                columns: new[] { "Id", "CauseOfBreakage", "DateOfBreakage", "DateOfRepair", "EmployeeId", "EquipmentId" },
                values: new object[] { new Guid("77777777-7777-7777-7777-777777777777"), "Тряска", new DateTime(2024, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("33333333-3333-3333-3333-333333333333"), new Guid("55555555-5555-5555-5555-555555555555") });

            migrationBuilder.InsertData(
                table: "WorkOnFields",
                columns: new[] { "EmployeeId", "FieldId" },
                values: new object[] { new Guid("33333333-3333-3333-3333-333333333333"), new Guid("44444444-4444-4444-4444-444444444444") });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "Id", "Amount", "Name", "PastureId" },
                values: new object[] { new Guid("11111111-1111-1111-1111-111111111111"), 12, "Овцы", new Guid("66666666-6666-6666-6666-666666666666") });

            migrationBuilder.CreateIndex(
                name: "IX_Animals_PastureId",
                table: "Animals",
                column: "PastureId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentOnFields_FieldId",
                table: "EquipmentOnFields",
                column: "FieldId");

            migrationBuilder.CreateIndex(
                name: "IX_Fields_CropId",
                table: "Fields",
                column: "CropId");

            migrationBuilder.CreateIndex(
                name: "IX_MachineryEquipment_WarehouseId",
                table: "MachineryEquipment",
                column: "WarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_Pastures_FieldId",
                table: "Pastures",
                column: "FieldId");

            migrationBuilder.CreateIndex(
                name: "IX_RepairLogs_EmployeeId",
                table: "RepairLogs",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_RepairLogs_EquipmentId",
                table: "RepairLogs",
                column: "EquipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkOnFields_FieldId",
                table: "WorkOnFields",
                column: "FieldId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Animals");

            migrationBuilder.DropTable(
                name: "EquipmentOnFields");

            migrationBuilder.DropTable(
                name: "RepairLogs");

            migrationBuilder.DropTable(
                name: "WorkOnFields");

            migrationBuilder.DropTable(
                name: "Pastures");

            migrationBuilder.DropTable(
                name: "MachineryEquipment");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Fields");

            migrationBuilder.DropTable(
                name: "Warehouses");

            migrationBuilder.DropTable(
                name: "SeedCrops");
        }
    }
}
