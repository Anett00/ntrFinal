using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuseNit.Actions
{
    public class User
    {
        public int userID { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string fullName
        {
            get
            {
                return string.Concat(firstName, " ", lastName);
            }
            set
            {
                fullName = string.Concat(firstName, " ", lastName);
            }
        }
        public bool isItAdmin { get; set; }
        public bool isItADriver { get; set; }
        public DateTime createdAt { get; set; }
    }

    public class Driver
    {
        public int driverID { get; set; }
        public int userID { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string fullName
        {
            get
            {
                return string.Concat(firstName, " ", lastName);
            }
            set
            {
                fullName = string.Concat(firstName, " ", lastName);
            }
        }
        public DateTime birthDate { get; set; }
        public string birthCountry { get; set; }
        public string birthPlace { get; set; }
        public string mothersName { get; set; }
        public string drivingLicenseNumber { get; set; }
        public DateTime drivingLicenseExpireDate { get; set; }
        public List<Categorie> categories { get; set; }
        public List<QualificationLevelInCareerAptitudeTest> qualificationLevelInCareerAptitudeTest { get; set; }
    }

    public class Vehicle
    {
        public int vehicleID { get; set; }
        public string make { get; set; }
        public string model { get; set; }
        public string registrationNumber { get; set; }
        public int year { get; set; }
        public DateTime dateOfFirstRegistration { get; set; }
        public int vehicleCategory { get; set; }
        public string registrationMark { get; set; }
        public double selfWeight { get; set; }
        public double cilynderCapacity { get; set; }
        public DateTime vehicleRoadworthinessTestExpireDate { get; set; }
        public double loadability
        {
            get
            {
                return (cilynderCapacity - selfWeight);
            }
            set
            {
                loadability = (cilynderCapacity - selfWeight);
            }
        }
    }

    public class Categorie
    {
        public int categorieID { get; set; }
        public string categorieName { get; set; }
    }

    public class QualificationLevelInCareerAptitudeTest
    {
        public int qlicatID { get; set; }
        public string qlicatName { get; set; }
    }

    public class Company
    {
        public int companyID { get; set; }
        public string companyName { get; set; }
        public string companyVATNumber { get; set; }
        public string companyExeCutiveDirector { get; set; }
        public string companyHeadCountry { get; set; }
        public string companyHeadCity { get; set; }
        public string companyHeadStreet { get; set; }
        public string companyHeadPlace { get; set; }
        public string companyHeadNumber { get; set; }
        public string companyHeadBuilding { get; set; }
        public string companyHeadFloor { get; set; }
        public string companyHeadDoor { get; set; }
        public string companyHeadZIPCode { get; set; }
        public string companyMailCountry { get; set; }
        public string companyMailCity { get; set; }
        public string companyMailStreet { get; set; }
        public string companyMailPlace { get; set; }
        public string companyMailNumber { get; set; }
        public string companyMailBuilding { get; set; }
        public string companyMailFloor { get; set; }
        public string companyMailDoor { get; set; }
        public string companyMailZIPCode { get; set; }
    }

    public class Customer
    {
        public int customerID { get; set; }
        public string customerName { get; set; }
        public string customerType { get; set; }
        public string customerVAT { get; set; }
        public string customerExecutiveDirector { get; set; }
        public string customerHeadCountry { get; set; }
        public string customerHeadCity { get; set; }
        public string customerHeadStreet { get; set; }
        public string customerHeadPlace { get; set; }
        public string customerHeadNumber { get; set; }
        public string customerHeadBuilding { get; set; }
        public string customerHeadFloor { get; set; }
        public string customerHeadDoor { get; set; }
        public string customerHeadZIPCode { get; set; }
        public string customerMailCountry { get; set; }
        public string customerMailCity { get; set; }
        public string customerMailStreet { get; set; }
        public string customerMailPlace { get; set; }
        public string customerMailNumber { get; set; }
        public string customerMailBuilding { get; set; }
        public string customerMailFloor { get; set; }
        public string customerMailDoor { get; set; }
        public string customerMailZIPCode { get; set; }
    }

    public class Project
    {
        public int projectID { get; set; }
        public string projectName { get; set; }
        public string projectPlaceZIPCode { get; set; }
        public string projectCountry { get; set; }
        public string projectPlaceCity { get; set; }
        public string projectPlaceStreet { get; set; }
        public string projectPlaceNumber { get; set; }
        public string projectNumber { get; set; }
    }

    public class Product
    {
        public int productID { get; set; }
        public string deliveryNoteID { get; set; }
        public string name { get; set; }
        public string unit { get; set; }
        public double quantity { get; set; }
        public double weight { get; set; }

    }

    public class DeliveryNote
    {
        public int noteID { get; set; }
        public string deliveryNoteID { get; set; }
        public int projectID { get; set; }
        public int vehicleID { get; set; }
        public int driverID { get; set; }
        public int companyID { get; set; }
        public int customerID { get; set; }
        public string departureCountry { get; set; }
        public string deparutureCity { get; set; }
        public string departureStreet { get; set; }
        public string departurePlace { get; set; }
        public string departureNumber { get; set; }
        public string departureBuilding { get; set; }
        public string departureFloor { get; set; }
        public string departureDoor { get; set; }
        public string departureZIP { get; set; }
        public string destinationCountry { get; set; }
        public string destinationCity { get; set; }
        public string destinationStreet { get; set; }
        public string destinationPlace { get; set; }
        public string destinationNumber { get; set; }
        public string destinationBuilding { get; set; }
        public string destinationFloor { get; set; }
        public string destinationDoor { get; set; }
        public string destinationZIP { get; set; }
        public double vehicleTotalWeight { get; set; }
        public bool isItActive { get; set; }
        public DateTime dateFrom { get; set; }
        public DateTime dateTo { get; set; }
    }
}
