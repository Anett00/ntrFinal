using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuseNit.Actions
{
    public class SQLStringsToDataBase
    {
        public static string user = "CREATE TABLE IF NOT EXISTS users ( " +
            "userID INTEGER NOT NULL UNIQUE, " +
            "userName VARCHAR(255) NOT NULL UNIQUE, " +
            "password VARCHAR(255) NOT NULL, " +
            "firstName VARCHAR(255), " +
            "lastName VARCHAR(255), " +
            "isItAdmin BOOL, " +
            "isItADriver BOOL, " +
            "createdAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP, " +
            "PRIMARY KEY (userID AUTOINCREMENT) );";
        public static string driver = "CREATE TABLE IF NOT EXISTS drivers ( " +
            "driverID INTEGER NOT NULL UNIQUE, " +
            "userID INTEGER NOT NULL, " +
            "birthCountry VARCHAR(255), " +
            "birthPlace VARCHAR(255), " +
            "birthDate DATE, " +
            "mothersName VARCHAR(255), " +
            "drivingLicenseNumber VARCHAR(255), " +
            "drivingLicenseExpireDate DATE, " +
            "PRIMARY KEY (driverID AUTOINCREMENT), " +
            "FOREIGN KEY (userID) " +
            "REFERENCES users(userID) ON DELETE CASCADE);";
        public static string vehicle = "CREATE TABLE IF NOT EXISTS vehicles ( " +
            "vehicleID INTEGER NOT NULL UNIQUE, " +
            "make VARCHAR(255) NOT NULL, " +
            "model VARCHAR(255) NOT NULL, " +
            "registrationNumber VARCHAR(255) NOT NULL UNIQUE, " +
            "year INTEGER NOT NULL, dateOfFirstRegistration DATE, " +
            "vehicleCategorie INTEGER, " +
            "registrationMark VARCHAR(255), " +
            "selfWeight DOUBLE, " +
            "cilynderCapacity DOUBLE, " +
            "vehicleRoadworthinessTestExpireDate DATE, " +
            "PRIMARY KEY (vehicleID AUTOINCREMENT));";
        public static string project = "CREATE TABLE IF NOT EXISTS project ( " +
            "projectID INTEGER NOT NULL UNIQUE, " +
            "projectName VARCHAR(255) NOT NULL, " +
            "projectOtherNumber VARCHAR(255), " +
            "projectCountry VARCHAR(255), " +
            "projectCity VARCHAR(255), " +
            "projectStreet VARCHAR(255), " +
            "projectNumber VARCHAR(255), " +
            "projectZIP VARCHAR(255), " +
            "PRIMARY KEY (projectID AUTOINCREMENT) );";
        public static string company = "CREATE TABLE IF NOT EXISTS selfCompany ( " +
            "companyID INTEGER NOT NULL UNIQUE, " +
            "companyName VARCHAR(255) NOT NULL UNIQUE, " +
            "companyHeadCountry VARCHAR(255), " +
            "companyHeadCity VARCHAR(255), " +
            "companyHeadStreet VARCHAR(255), " +
            "companyHeadPlace VARCHAR(255), " +
            "companyHeadNumber VARCHAR(255), " +
            "companyHeadZIP VARCHAR(255), " +
            "companyHeadBuilding VARCHAR(255), " +
            "companyHeadFloor VARCHAR(255), " +
            "companyHeadDoor VARCHAR(255), " +
            "companyMailCountry VARCHAR(255), " +
            "companyMailCity VARCHAR(255), " +
            "companyMailStreet VARCHAR(255), " +
            "companyMailPlace VARCHAR(255), " +
            "companyMailNumber VARCHAR(255), " +
            "companyMailZIP VARCHAR(255), " +
            "companyMailBuilding VARCHAR(255), " +
            "companyMailFloor VARCHAR(255), " +
            "companyMailDoor VARCHAR(255), " +
            "companyVAT VARCHAR(255), " +
            "companyExecutiveDirector VARCHAR(255), " +
            "PRIMARY KEY (companyID AUTOINCREMENT) );";
        public static string customer = "CREATE TABLE customer( " +
            "customerID INTEGER NOT NULL UNIQUE, " +
            "customerName VARCHAR(255) NOT NULL, " +
            "customerType VARCHAR(25), " +
            "customerHeadCountry VARCHAR(255), " +
            "customerHeadCity VARCHAR(255), " +
            "customerHeadStreet VARCHAR(255), " +
            "customerHeadPlace VARCHAR(255), " +
            "customerHeadNumber VARCHAR(255), " +
            "customerHeadBuilding VARCHAR(255), " +
            "customerHeadFloor VARCHAR(255), " +
            "customerHeadDoor VARCHAR(255), " +
            "customerHeadZIP VARCHAR(255), " +
            "customerMailCountry VARCHAR(255), " +
            "customerMailCity VARCHAR(255), " +
            "customerMailStreet VARCHAR(255), " +
            "customerMailPlace VARCHAR(255), " +
            "customerMailNumber VARCHAR(255), " +
            "customerMailBuilding VARCHAR(255), " +
            "customerMailFloor VARCHAR(255), " +
            "customerMailDoor VARCHAR(255), " +
            "customerMailZIP VARCHAR(255), " +
            "customerVAT VARCHAR(255), " +
            "customerExecutiveDirector VARCHAR(255), " +
            "PRIMARY KEY(customerID AUTOINCREMENT) );";
        public static string qlicat = "CREATE TABLE IF NOT EXISTS qualificationLevelInCareerAptitudeTest( " +
            "drivingAptitudeTestID INTEGER NOT NULL UNIQUE, " +
            "drivingAptitudeTestName VARCHAR(255), " +
            "PRIMARY KEY (drivingAptitudeTestID AUTOINCREMENT) );";
        public static string categorie = "CREATE TABLE IF NOT EXISTS categorie( " +
            "categorieID INTEGER NOT NULL UNIQUE, " +
            "categorieName VARCHAR(255), " +
            "PRIMARY KEY (categorieID AUTOINCREMENT) );";
        public static string catDriver = "CREATE TABLE IF NOT EXISTS catDrivers( " +
            "categorieDriverID INTEGER NOT NULL UNIQUE, " +
            "driverID INTEGER, " +
            "categorieID INTEGER, " +
            "PRIMARY KEY (categorieDriverID AUTOINCREMENT) );";
        public static string datDriver = "CREATE TABLE IF NOT EXISTS datDrivers( " +
            "datDriverID INTEGER NOT NULL UNIQUE, " +
            "driverID INTEGER, " +
            "datID INTEGER, " +
            "PRIMARY KEY (datDriverID AUTOINCREMENT) );";
        public static string note = "CREATE TABLE IF NOT EXISTS deliveryNote (" +
            "noteID INTEGER NOT NULL UNIQUE, " +
            "projectID INTEGER, " +
            "vehicleID INTEGER, " +
            "driverID INTEGER, " +
            "companyID INTEGER, " +
            "customerID INTEGER, " +
            "departureCountry VARCHAR(255), " +
            "departureCity VARCHAR(255), " +
            "departureStreet VARCHAR(255), " +
            "departurePlace VARCHAR(255), " +
            "departureNumber VARCHAR(255), " +
            "departureBuilding VARCHAR(255), " +
            "departureFloor VARCHAR(255), " +
            "departureDoor VARCHAR(255), " +
            "departureZIP VARCHAR(255), " +
            "destinationCountry VARCHAR(255), " +
            "destinationCity VARCHAR(255), " +
            "destinationStreet VARCHAR(255), " +
            "destinationPlace VARCHAR(255), " +
            "destinationNumber VARCHAR(255), " +
            "destinationBuilding VARCHAR(255), " +
            "destinationFloor VARCHAR(255), " +
            "destinationDoor VARCHAR(255), " +
            "destinationZIP VARCHAR(255), " +
            "vehicleTotalWeight DOUBLE, " +
            "isItActive BOOLEAN, " +
            "dateFrom DATE, " +
            "dateTo DATE, " +
            "deliveryNoteID VARCHAR(255), " +
            "PRIMARY KEY (noteID AUTOINCREMENT) );";
        public static string product = "CREATE TABLE IF NOT EXISTS product ( " +
            "productID INTEGER NOT NULL, " +
            "productName VARCHAR(255) NOT NULL, " +
            "productDeliveryNote VARCHAR(255), " +
            "productQuantity DOUBLE, " +
            "productUnit VARCHAR(255), " +
            "productWeight DOUBLE, " +
            "PRIMARY KEY (productID AUTOINCREMENT) );";
    }
}
