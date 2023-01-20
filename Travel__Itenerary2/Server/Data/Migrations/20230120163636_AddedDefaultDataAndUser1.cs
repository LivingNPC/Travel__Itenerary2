﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace Travel__Itenerary2.Server.Data.Migrations
{
    public partial class AddedDefaultDataAndUser1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "ad2bcf0c-20db-474f-8407-5a6b159518ba", "6df25073-e6fa-4a81-9653-e55371df939c", "Administrator", "ADMINISTRATOR" },
                    { "bd2bcf0c-20db-474f-8407-5a6b159518bb", "15dd0e22-04c7-44e6-83bf-92af4a2d2962", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "3781efa7-66dc-47f0-860f-e506d04102e4", 0, "db6017bf-32c3-4f5e-87b7-e0c4c86fda52", "admin@localhost.com", false, "Admin", "User", false, null, "ADMIN@LOCALHOST.COM", "ADMIN", "AQAAAAEAACcQAAAAEDBeLiGCRY4i+X71NQ44hgejarzop04VHycu7+rrG1BEVUlx0+l3/F1PllweNjtNFQ==", null, false, "a8e37e99-2cd3-4736-b8eb-d93dd4dfa8e6", false, "Admin" });

            migrationBuilder.InsertData(
                table: "Flights",
                columns: new[] { "Id", "FlightClass", "FlightDesc", "FlightDestination", "FlightName" },
                values: new object[,]
                {
                    { 1, "First-Class", "First class is a premium class of service on an airplane, offering the highest level of comfort, amenities, and service ", "Portugal", "Singapore Airlines" },
                    { 2, "Business-Class", "Business class is a class of service on an airplane that is nothing short for comfort", "Belgium", "Singapore Airlines" },
                    { 3, "Economy-Class", "Economy class is a class of service on an airplane that offers the basic standards", "Japan", "Singapore Airlines" }
                });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "Id", "HotelAddress", "HotelDesc", "HotelName" },
                values: new object[,]
                {
                    { 1, "Praça Martim Moniz 2, 1100-341 Lisboa, Portugal", "$296/night", "Hotel Mundial" },
                    { 2, "Rue Bara 101, 1070 Brussels, Belgium", "$74/night", "MEININGER Hotel Bruxelles Gare du Midi" },
                    { 3, "4 Chome-10-30 Takanawa, Minato City, Tokyo 108-6111, Japan", "$145/night", "Shinagawa Prince Hotel" }
                });

            migrationBuilder.InsertData(
                table: "Package",
                columns: new[] { "Id", "PackageAmount", "PackageDescription", "PackageName" },
                values: new object[,]
                {
                    { 1, 800, "Lisbon, also known as Lisboa, is the capital and largest city of Portugal. It is located on the Atlantic coast of the Iberian Peninsula and is known for its historic architecture, lively cultural scene, and picturesque neighborhoods.", "Lisboa_Tour" },
                    { 2, 890, "Brussels is the capital and largest city of Belgium, and serves as the administrative center of the European Union. It is located in the center of the country and is known for its historic architecture, including the Grand Place, a UNESCO World Heritage site.", "Brussel_Tour" },
                    { 3, 1000, "Tokyo is the capital and largest city of Japan. It is located in the eastern part of the main island of Honshu and is considered one of the most populous cities in the world. Tokyo is known for its vibrant culture, cutting-edge technology, and unique blend of modern and traditional elements.", "Tokyo_Tour" }
                });

            migrationBuilder.InsertData(
                table: "Staff",
                columns: new[] { "Id", "Address", "ContactNumber", "EmailAddress", "Name", "Position" },
                values: new object[,]
                {
                    { 1, 823616, 91233219, "johndoe123@gmail.com", "John", "CEO" },
                    { 2, 712321, 81233218, "maryjane321@gmail.com", "Mary", "Customer Service" },
                    { 3, 612321, 90000009, "peterparker0123@gmail.com", "Peter", "Payment Handler" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "ad2bcf0c-20db-474f-8407-5a6b159518ba", "3781efa7-66dc-47f0-860f-e506d04102e4" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bd2bcf0c-20db-474f-8407-5a6b159518bb");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "ad2bcf0c-20db-474f-8407-5a6b159518ba", "3781efa7-66dc-47f0-860f-e506d04102e4" });

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Package",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Package",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Package",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Staff",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Staff",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Staff",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ad2bcf0c-20db-474f-8407-5a6b159518ba");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3781efa7-66dc-47f0-860f-e506d04102e4");
        }
    }
}
