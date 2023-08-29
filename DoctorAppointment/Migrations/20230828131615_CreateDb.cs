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
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StreetName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
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
                        name: "FK_HospitalInfo_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Address",
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
                name: "Contacts",
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
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contacts_HospitalInfo_HospitalId",
                        column: x => x.HospitalId,
                        principalTable: "HospitalInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    HospitalInfoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Departments_HospitalInfo_HospitalInfoId",
                        column: x => x.HospitalInfoId,
                        principalTable: "HospitalInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Gender = table.Column<int>(type: "int", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UrlToPicture = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    HospitalInfoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Doctors_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Doctors_HospitalInfo_HospitalInfoId",
                        column: x => x.HospitalInfoId,
                        principalTable: "HospitalInfo",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DateSlots",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoctorId = table.Column<int>(type: "int", nullable: false),
                    AvailableDay = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DateSlots", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DateSlots_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Gender = table.Column<int>(type: "int", maxLength: 20, nullable: false),
                    Nationality = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DoctorId = table.Column<int>(type: "int", nullable: false),
                    HospilInfoId = table.Column<int>(type: "int", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    HospitalInfoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Patients_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Patients_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Patients_HospitalInfo_HospitalInfoId",
                        column: x => x.HospitalInfoId,
                        principalTable: "HospitalInfo",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TimeSlots",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoctorId = table.Column<int>(type: "int", nullable: false),
                    AvailAbleTime = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeSlots", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TimeSlots_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Appointments",
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
                    table.PrimaryKey("PK_Appointments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Appointments_DateSlots_DateSlotId",
                        column: x => x.DateSlotId,
                        principalTable: "DateSlots",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Appointments_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Appointments_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Appointments_TimeSlots_TimeSlotId",
                        column: x => x.TimeSlotId,
                        principalTable: "TimeSlots",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Address",
                columns: new[] { "Id", "City", "Country", "PostCode", "StreetName" },
                values: new object[] { 1, "Sandikharkha", "Nepal", "2123", "MilanChok" });

            migrationBuilder.InsertData(
                table: "HospitalInfo",
                columns: new[] { "Id", "AddressId", "Name", "UrlToPicture" },
                values: new object[] { 1, 1, "Shandhikharkha Distric Hospital", "Gangalal national heart center.jpeg" });

            migrationBuilder.InsertData(
                table: "Departments",
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
                table: "Doctors",
                columns: new[] { "Id", "DOB", "DepartmentId", "Email", "Gender", "HospitalInfoId", "Name", "Phone", "UrlToPicture" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Jasper@gmail.com", 0, 1, "Jasper", "+977-9856325689", "Jasper.jpeg" },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Tiler@gmail.com", 0, 1, "Timerman", "+977-9756325680", "Timerman.jpeg" },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Umr@outlook.be", 0, 1, "Umer", "+977-9656325254", "Umer.jpeg" },
                    { 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Sneha@gmail.com", 1, 1, "Sneha", "+977-9875325691", "Sneha.jpeg" },
                    { 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Kristof@gmail.com", 2, 1, "kristof", "+977-1456325689", "Kristof.jpeg" },
                    { 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Tomer@Yahoomail.com", 0, 1, "Tomar", "+977-9856325689", "Tomer.jpeg" },
                    { 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "Iveta@gmail.com", 1, 1, "Iveta", "+977-4856325632", "Iveta.jpeg" },
                    { 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, "Roland@gmail.com", 0, 1, "Roland", "+977-9756325645", "Roland.jpeg" },
                    { 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, "Amanda@Yahoo.com", 1, 1, "Amanda", "+977-9756325685", "Amanda.jpeg" }
                });

            migrationBuilder.InsertData(
                table: "DateSlots",
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
                table: "Patients",
                columns: new[] { "Id", "Address", "DOB", "DepartmentId", "DoctorId", "Gender", "HospilInfoId", "HospitalInfoId", "Name", "Nationality" },
                values: new object[,]
                {
                    { 1, "Bhddhanager 24,Kathmandu,Nepal", new DateTime(1985, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 1, 0, 1, null, "Gokarna", "Nepalese" },
                    { 2, "MaitiGhar 124,Kathmandu,Nepal", new DateTime(2002, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 2, 0, 1, null, "DGSon", "Nepalese" },
                    { 3, "Sinamangal 68,Kathmandu,Nepal", new DateTime(2018, 4, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 3, 0, 1, null, "Paula", "Belgium" },
                    { 4, "Sinamangal 68,Kathmandu,Nepal", new DateTime(2018, 4, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 4, 0, 1, null, "Paula", "Belgium" },
                    { 5, "MaitiGhar 124,Kathmandu,Nepal", new DateTime(2002, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 5, 0, 1, null, "DGSon", "Nepalese" },
                    { 6, "Bhddhanager 24,Kathmandu,Nepal", new DateTime(1985, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 6, 0, 1, null, "Gokarna", "Nepalese" },
                    { 7, "NieuweStraat 120, Gent,Belgium", new DateTime(1965, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 7, 0, 1, null, "Kenan", "Belgie" },
                    { 8, "Donderlieuw 121,Belgium", new DateTime(1994, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 8, 1, 1, null, "Anu", "Indian" },
                    { 9, "GroteMarkt 220, Brussel,Belgium", new DateTime(1980, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 9, 1, 1, null, "Sabrina", "Belgie" },
                    { 10, "GentSeesteenweg 120, Gent,Belgium", new DateTime(1985, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 1, 0, 1, null, "Rufat", "Azerbizan" },
                    { 11, "Mechanlenlaan 85, Mechelen,Belgium", new DateTime(1999, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2, 0, 1, null, "Jonas", "Belgie" },
                    { 12, "Grotelaan 45, Brussels,Belgium", new DateTime(1997, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 3, 0, 1, null, "Ahmed", "Belgie" },
                    { 13, "Zuidstation 36, Brussels,Belgium", new DateTime(1997, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, 0, 1, null, "Arijs", "Belgie" },
                    { 14, "Tournailaan 45, Tournai,Belgium", new DateTime(1991, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 5, 1, 1, null, "Madalina", "Romania" },
                    { 15, "Leuvenlaan 45, Leuven,Belgium", new DateTime(1999, 4, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 6, 0, 1, null, "Fida", "Turkia" },
                    { 16, "Molenbeeklaan 150, Brussels,Belgium", new DateTime(1997, 4, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 7, 0, 1, null, "Mohamad", "Marrokko" },
                    { 17, "Oplinter 102, Tienen,Belgium", new DateTime(2008, 9, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 8, 1, 1, null, "Amanda", "Belgie" },
                    { 18, "DiestSesteenweg 111, Diest,Belgium", new DateTime(2012, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 9, 1, 1, null, "Rolis", "Belgie" }
                });

            migrationBuilder.InsertData(
                table: "TimeSlots",
                columns: new[] { "Id", "AvailAbleTime", "DoctorId" },
                values: new object[,]
                {
                    { 1, "9 AM", 1 },
                    { 2, "10 AM", 1 },
                    { 3, "11 AM", 1 },
                    { 4, "12 AM", 1 }
                });

            migrationBuilder.InsertData(
                table: "TimeSlots",
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
                name: "IX_Appointments_DateSlotId",
                table: "Appointments",
                column: "DateSlotId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_DoctorId",
                table: "Appointments",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_PatientId",
                table: "Appointments",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_TimeSlotId",
                table: "Appointments",
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
                name: "IX_Contacts_HospitalId",
                table: "Contacts",
                column: "HospitalId");

            migrationBuilder.CreateIndex(
                name: "IX_DateSlots_DoctorId",
                table: "DateSlots",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_HospitalInfoId",
                table: "Departments",
                column: "HospitalInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_DepartmentId",
                table: "Doctors",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_HospitalInfoId",
                table: "Doctors",
                column: "HospitalInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_HospitalInfo_AddressId",
                table: "HospitalInfo",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_DepartmentId",
                table: "Patients",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_DoctorId",
                table: "Patients",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_HospitalInfoId",
                table: "Patients",
                column: "HospitalInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeSlots_DoctorId",
                table: "TimeSlots",
                column: "DoctorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appointments");

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
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "DateSlots");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "TimeSlots");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "HospitalInfo");

            migrationBuilder.DropTable(
                name: "Address");
        }
    }
}
