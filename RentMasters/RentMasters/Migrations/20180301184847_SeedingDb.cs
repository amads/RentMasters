using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace RentMasters.Migrations
{
    public partial class SeedingDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Owners (Name, Surname, Phone) VALUES ('Amadeusz', 'Snarski', '888999777')");
            migrationBuilder.Sql("INSERT INTO Owners (Name, Surname, Phone) VALUES ('Arkadiusz', 'Michalski', '999666333')");
            migrationBuilder.Sql("INSERT INTO Owners (Name, Surname, Phone) VALUES ('Mateusz', 'Matela', '777444111')");

            migrationBuilder.Sql("INSERT INTO Addresses (Street, City) VALUES ('Wiadukt', 'Białystok')");
            migrationBuilder.Sql("INSERT INTO Addresses (Street, City) VALUES ('Bema', 'Białystok')");
            migrationBuilder.Sql("INSERT INTO Addresses (Street, City) VALUES ('Pogodna', 'Białystok')");

            migrationBuilder.Sql("INSERT INTO Properties (Type, Description, Rooms, Area, Washer, Refrigerator, Iron, AddressId, OwnerId) VALUES (0, 'Opis1', 7, 170, 1, 1, 1, 1, 1 )");
            migrationBuilder.Sql("INSERT INTO Properties (Type, Description, Rooms, Area, Washer, Refrigerator, Iron, AddressId, OwnerId) VALUES (1, 'Opis2', 4, 50, 1, 0, 1, 2, 2 )");
            migrationBuilder.Sql("INSERT INTO Properties (Type, Description, Rooms, Area, Washer, Refrigerator, Iron, AddressId, OwnerId) VALUES (1, 'Opis3', 2, 29, 0, 0, 1, 3, 3 )");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Owners");
            migrationBuilder.Sql("DELETE FROM Addresses");
            migrationBuilder.Sql("DELETE FROM Properties");
        }
    }
}
