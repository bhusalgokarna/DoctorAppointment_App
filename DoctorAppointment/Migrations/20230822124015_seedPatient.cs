using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorAppointment.Migrations
{
    public partial class seedPatient : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "Id", "Address", "DOB", "DepartmentId", "DoctorId", "Gender", "HospitalInfoId", "Name", "Nationality" },
                values: new object[] { 1, "Bhddhanager 24,Kathmandu,Nepal", new DateTime(1985, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, null, 0, null, "Gokarna", "Nepalese" });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "Id", "Address", "DOB", "DepartmentId", "DoctorId", "Gender", "HospitalInfoId", "Name", "Nationality" },
                values: new object[] { 2, "MaitiGhar 124,Kathmandu,Nepal", new DateTime(2002, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, null, 0, null, "DGSon", "Nepalese" });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "Id", "Address", "DOB", "DepartmentId", "DoctorId", "Gender", "HospitalInfoId", "Name", "Nationality" },
                values: new object[] { 3, "Sinamangal 68,Kathmandu,Nepal", new DateTime(2018, 4, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, null, 0, null, "Paula", "Belgium" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
