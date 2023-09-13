using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorAppointment.Migrations
{
    public partial class CreateDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Adress",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StreetName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PostCode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Country = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adress", x => x.Id);
                });

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
                name: "Genre",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Gender = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genre", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HospitalInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    AddressId = table.Column<int>(type: "int", nullable: false),
                    UrlToPicture = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HospitalInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HospitalInfo_Adress_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Adress",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                name: "Contact",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HospitalId = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contact", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contact_HospitalInfo_HospitalId",
                        column: x => x.HospitalId,
                        principalTable: "HospitalInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    HospitalInfoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Department_HospitalInfo_HospitalInfoId",
                        column: x => x.HospitalInfoId,
                        principalTable: "HospitalInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Doctor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    GenreId = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UrlToPicture = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    HospitalInfoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Doctor_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Department",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Doctor_Genre_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genre",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Doctor_HospitalInfo_HospitalInfoId",
                        column: x => x.HospitalInfoId,
                        principalTable: "HospitalInfo",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DateSlot",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoctorId = table.Column<int>(type: "int", nullable: false),
                    AvailableDay = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DateSlot", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DateSlot_Doctor_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctor",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Patient",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    GenreId = table.Column<int>(type: "int", nullable: false),
                    Nationality = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DoctorId = table.Column<int>(type: "int", nullable: false),
                    HospitalInfoId = table.Column<int>(type: "int", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patient", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Patient_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Department",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Patient_Doctor_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Patient_Genre_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genre",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Patient_HospitalInfo_HospitalInfoId",
                        column: x => x.HospitalInfoId,
                        principalTable: "HospitalInfo",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TimeSlot",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoctorId = table.Column<int>(type: "int", nullable: false),
                    AvailAbleTime = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeSlot", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TimeSlot_Doctor_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctor",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Appointment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DoctorId = table.Column<int>(type: "int", nullable: false),
                    DateSlotId = table.Column<int>(type: "int", nullable: false),
                    TimeSlotId = table.Column<int>(type: "int", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Appointment_DateSlot_DateSlotId",
                        column: x => x.DateSlotId,
                        principalTable: "DateSlot",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Appointment_Doctor_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctor",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Appointment_Patient_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patient",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Appointment_TimeSlot_TimeSlotId",
                        column: x => x.TimeSlotId,
                        principalTable: "TimeSlot",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Adress",
                columns: new[] { "Id", "City", "Country", "PostCode", "StreetName" },
                values: new object[] { 1, "Sandikharkha", "Nepal", "2123", "MilanChok" });

            migrationBuilder.InsertData(
                table: "Genre",
                columns: new[] { "Id", "Gender" },
                values: new object[,]
                {
                    { 1, "Male" },
                    { 2, "Female" },
                    { 3, "Other" }
                });

            migrationBuilder.InsertData(
                table: "HospitalInfo",
                columns: new[] { "Id", "AddressId", "Name", "UrlToPicture" },
                values: new object[] { 1, 1, "Shandhikharkha Distric Hospital", "Gangalal national heart center.jpeg" });

            migrationBuilder.InsertData(
                table: "Contact",
                columns: new[] { "Id", "Email", "HospitalId", "Phone" },
                values: new object[] { 1, "info@hospital.com.np", 1, "+97718544232565" });

            migrationBuilder.InsertData(
                table: "Department",
                columns: new[] { "Id", "HospitalInfoId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Accident and Emergency Department (A & E)" },
                    { 2, 1, "Intensive Care Unit (ICU)" },
                    { 3, 1, "Pediatric" },
                    { 4, 1, "Radiology" },
                    { 5, 1, "General Surgery" },
                    { 6, 1, "ENT" }
                });

            migrationBuilder.InsertData(
                table: "Doctor",
                columns: new[] { "Id", "DOB", "DepartmentId", "Email", "GenreId", "HospitalInfoId", "Name", "Phone", "UrlToPicture" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Jasper@gmail.com", 1, 1, "Jasper", "+977-9856325689", "Jasper.jpeg" },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Tiler@gmail.com", 1, 1, "Timerman", "+977-9756325680", "Timerman.jpeg" },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Umr@outlook.be", 1, 1, "Umer", "+977-9656325254", "Umer.jpeg" },
                    { 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Sneha@gmail.com", 2, 1, "Sneha", "+977-9875325691", "Sneha.jpeg" },
                    { 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Kristof@gmail.com", 3, 1, "Kristof", "+977-1456325689", "Kristof.jpeg" },
                    { 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Tomer@Yahoomail.com", 1, 1, "Tomar", "+977-9856325689", "Tomar.jpeg" },
                    { 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "Iveta@gmail.com", 2, 1, "Iveta", "+977-4856325632", "Iveta.jpeg" },
                    { 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, "Roland@gmail.com", 1, 1, "Roland", "+977-9756325645", "Roland.jpeg" },
                    { 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, "Amanda@Yahoo.com", 2, 1, "Amanda", "+977-9756325685", "Amanda.jpeg" }
                });

            migrationBuilder.InsertData(
                table: "DateSlot",
                columns: new[] { "Id", "AvailableDay", "DoctorId" },
                values: new object[,]
                {
                    { 1, "18.09.2023", 1 },
                    { 2, "18.09.2023", 2 },
                    { 3, "18.09.2023", 3 },
                    { 4, "18.09.2023", 4 },
                    { 5, "18.09.2023", 5 },
                    { 6, "19.09.2023", 6 },
                    { 7, "19.09.2023", 7 },
                    { 8, "19.09.2023", 1 },
                    { 9, "20.09.2023", 1 },
                    { 10, "19.09.2023", 2 },
                    { 11, "18.09.2023", 3 },
                    { 12, "19.09.2023", 4 },
                    { 13, "19.09.2023", 5 },
                    { 14, "20.09.2023", 6 },
                    { 15, "20.09.2023", 7 },
                    { 16, "18.09.2023", 8 },
                    { 17, "18.09.2023", 8 },
                    { 18, "18.09.2023", 9 },
                    { 19, "20.09.2023", 9 },
                    { 20, "21.09.2023", 6 }
                });

            migrationBuilder.InsertData(
                table: "Patient",
                columns: new[] { "Id", "Address", "DOB", "DepartmentId", "DoctorId", "Email", "GenreId", "HospitalInfoId", "Name", "Nationality", "Phone" },
                values: new object[,]
                {
                    { 1, "Bhddhanager 24,Kathmandu,Nepal", new DateTime(1985, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 1, "gokarna@outlook.be", 1, 1, "Gokarna", "Nepalese", "+977-9846324524" },
                    { 2, "MaitiGhar 124,Kathmandu,Nepal", new DateTime(2002, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 2, "dgson@gmail.be", 1, 1, "DGSon", "Nepalese", "+977-9846324552" },
                    { 3, "Sinamangal 68,Kathmandu,Nepal", new DateTime(2018, 4, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 3, "paula@outlook.be", 1, 1, "Paula", "Belgium", "+977-9856324520" },
                    { 4, "Sinamangal 68,Kathmandu,Nepal", new DateTime(2018, 4, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 4, "agnese@outlook.be", 2, 1, "Agnese", "Belgium", "+977-9846324527" },
                    { 5, "MaitiGhar 124,Kathmandu,Nepal", new DateTime(2002, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 5, "dgson@gmail.be", 1, 1, "DGSon", "Nepalese", "+977-9846324524" },
                    { 6, "Bhddhanager 24,Kathmandu,Nepal", new DateTime(1985, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 6, "gokarna@yahoomail.be", 1, 1, "Gokarna", "Nepalese", "+977-9846324550" },
                    { 7, "NieuweStraat 120, Gent,Belgium", new DateTime(1965, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 7, "kenan.kurda@outlook.be", 1, 1, "Kenan", "Belgie", "+977-98463245456" },
                    { 8, "Donderlieuw 121,Belgium", new DateTime(1994, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 8, "anu@intec.be", 2, 1, "Anu", "Indian", "+977-9846324658" },
                    { 9, "GroteMarkt 220, Brussel,Belgium", new DateTime(1980, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 9, "sabrina@outlook.be", 2, 1, "Sabrina", "Belgie", "+977-9846324578" },
                    { 10, "GentSeesteenweg 120, Gent,Belgium", new DateTime(1985, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 1, "rufat@gmail.be", 1, 1, "Rufat", "Azerbizan", "+977-9846324689" },
                    { 11, "Mechanlenlaan 85, Mechelen,Belgium", new DateTime(1999, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2, "jonas@outlook.be", 1, 1, "Jonas", "Belgie", "+977-9846324510" },
                    { 12, "Grotelaan 45, Brussels,Belgium", new DateTime(1997, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 3, "ahmed@outlook.be", 1, 1, "Ahmed", "Belgie", "+977-9846324515" },
                    { 13, "Zuidstation 36, Brussels,Belgium", new DateTime(1997, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, "arijs@outlook.be", 2, 1, "Arijs", "Belgie", "+977-9846324986" },
                    { 14, "Tournailaan 45, Tournai,Belgium", new DateTime(1991, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 5, "madalina@outlook.be", 2, 1, "Madalina", "Romania", "+977-9846324524" },
                    { 15, "Leuvenlaan 45, Leuven,Belgium", new DateTime(1999, 4, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 6, "fida@outlook.be", 1, 1, "Fida", "Turkia", "+977-9846324550" },
                    { 16, "Molenbeeklaan 150, Brussels,Belgium", new DateTime(1997, 4, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 7, "mohamd@gmail.be", 1, 1, "Mohamad", "Marrokko", "+977-9846324585" },
                    { 17, "Oplinter 102, Tienen,Belgium", new DateTime(2008, 9, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 8, "amanda@outlook.be", 2, 1, "Amanda", "Belgie", "+977-9846324513" },
                    { 18, "DiestSesteenweg 111, Diest,Belgium", new DateTime(2012, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 9, "roland@outlook.be", 1, 1, "Rolis", "Belgie", "+977-9846324534" }
                });

            migrationBuilder.InsertData(
                table: "TimeSlot",
                columns: new[] { "Id", "AvailAbleTime", "DoctorId" },
                values: new object[,]
                {
                    { 1, "9 AM", 1 },
                    { 2, "10 AM", 1 },
                    { 3, "11 AM", 1 },
                    { 4, "12 AM", 1 }
                });

            migrationBuilder.InsertData(
                table: "TimeSlot",
                columns: new[] { "Id", "AvailAbleTime", "DoctorId" },
                values: new object[,]
                {
                    { 5, "13 PM", 2 },
                    { 6, "14 PM", 2 },
                    { 7, "15 PM", 2 },
                    { 8, "16 PM", 2 },
                    { 9, "17 PM", 3 },
                    { 10, "18 PM", 3 },
                    { 11, "19 PM", 3 },
                    { 12, "20 PM", 3 },
                    { 13, "9 AM", 4 },
                    { 14, "10 AM", 4 },
                    { 15, "11 AM", 4 },
                    { 16, "12 AM", 4 },
                    { 17, "13 PM", 5 },
                    { 18, "14 PM", 5 },
                    { 19, "15 PM", 5 },
                    { 20, "16 PM", 5 },
                    { 21, "17 PM", 6 },
                    { 22, "18 PM", 6 },
                    { 23, "19 PM", 6 },
                    { 24, "20 PM", 6 },
                    { 25, "9 AM", 7 },
                    { 26, "10 AM", 7 },
                    { 27, "11 AM", 7 },
                    { 28, "12 AM", 7 },
                    { 29, "13 PM", 8 },
                    { 30, "14 PM", 8 },
                    { 31, "15 PM", 8 },
                    { 32, "16 PM", 8 },
                    { 33, "17 PM", 9 },
                    { 34, "18 PM", 9 },
                    { 35, "19 PM", 9 },
                    { 36, "20 PM", 9 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_DateSlotId",
                table: "Appointment",
                column: "DateSlotId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_DoctorId",
                table: "Appointment",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_PatientId",
                table: "Appointment",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_TimeSlotId",
                table: "Appointment",
                column: "TimeSlotId");

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
                name: "IX_Contact_HospitalId",
                table: "Contact",
                column: "HospitalId");

            migrationBuilder.CreateIndex(
                name: "IX_DateSlot_DoctorId",
                table: "DateSlot",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Department_HospitalInfoId",
                table: "Department",
                column: "HospitalInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctor_DepartmentId",
                table: "Doctor",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctor_GenreId",
                table: "Doctor",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctor_HospitalInfoId",
                table: "Doctor",
                column: "HospitalInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_HospitalInfo_AddressId",
                table: "HospitalInfo",
                column: "AddressId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Patient_DepartmentId",
                table: "Patient",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Patient_DoctorId",
                table: "Patient",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Patient_GenreId",
                table: "Patient",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_Patient_HospitalInfoId",
                table: "Patient",
                column: "HospitalInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeSlot_DoctorId",
                table: "TimeSlot",
                column: "DoctorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appointment");

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
                name: "Contact");

            migrationBuilder.DropTable(
                name: "DateSlot");

            migrationBuilder.DropTable(
                name: "Patient");

            migrationBuilder.DropTable(
                name: "TimeSlot");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Doctor");

            migrationBuilder.DropTable(
                name: "Department");

            migrationBuilder.DropTable(
                name: "Genre");

            migrationBuilder.DropTable(
                name: "HospitalInfo");

            migrationBuilder.DropTable(
                name: "Adress");
        }
    }
}
