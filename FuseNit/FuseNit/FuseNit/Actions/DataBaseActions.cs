using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FuseNit.Actions
{
    class DataBaseActions
    {
        public List<Actions.User> GetAllUser(List<Actions.User> userList)
        {
            userList.Clear();

            int id;
            string userName;
            string firstName;
            string lastName;
            string password;
            bool admin = false;
            bool driver = false;

            SQLiteConnection connection = new SQLiteConnection(Properties.Settings.Default.connection);
            try
            {
                connection.Open();
                using (connection)
                {
                    string sqlUser = "SELECT * FROM users";
                    using (SQLiteCommand command = new SQLiteCommand(sqlUser, connection))
                    {
                        command.CommandText = sqlUser;
                        using (SQLiteDataReader dataReader = command.ExecuteReader())
                        {
                            while (dataReader.Read())
                            {
                                id = dataReader.GetInt32(0);
                                userName = dataReader.GetString(1);
                                password = dataReader.GetString(2);
                                firstName = dataReader.GetString(3);
                                lastName = dataReader.GetString(4);
                                if (dataReader.GetString(5) == "True" || dataReader.GetString(5) == "true")
                                {
                                    admin = true;
                                }
                                if (dataReader.GetString(6) == "True" || dataReader.GetString(6) == "true")
                                {
                                    driver = true;
                                }

                                User user = new User();
                                user.userID = id;
                                user.userName = userName;
                                user.password = password;
                                user.firstName = firstName;
                                user.lastName = lastName;
                                user.isItAdmin = admin;
                                user.isItADriver = driver;

                                userList.Add(user);
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error: " + e.Message);
            }
            finally
            {

            }

            return userList;
        }

        public List<Actions.Driver> GetAllDriver(List<Actions.Driver> driverList)
        {
            driverList.Clear();

            int id;
            int userID;
            string firstName;
            string lastName;
            DateTime birthDate;
            string birthPlace;
            string birthCountry;
            string mothersName;
            string drivingLicenseNumber;
            DateTime dlExpireDate;


            SQLiteConnection connection = new SQLiteConnection(Properties.Settings.Default.connection);
            try
            {
                connection.Open();
                using (connection)
                {
                    string sqlDriver = "SELECT driverID, drivers.userID, users.firstName, users.lastName, birthCountry, birthPlace, birthDate, mothersName, drivingLicenseNumber, drivingLicenseExpireDate " +
                        "FROM drivers " +
                        "INNER JOIN users ON users.userID = drivers.userID ";
                    using (SQLiteCommand command = new SQLiteCommand(sqlDriver, connection))
                    {
                        command.CommandText = sqlDriver;
                        using (SQLiteDataReader dataReader = command.ExecuteReader())
                        {
                            while (dataReader.Read())
                            {
                                id = dataReader.GetInt32(0);
                                userID = dataReader.GetInt32(1);
                                firstName = dataReader.GetString(2);
                                lastName = dataReader.GetString(3);
                                birthDate = Convert.ToDateTime(dataReader.GetString(6));
                                birthPlace = dataReader.GetString(5);
                                birthCountry = dataReader.GetString(4);
                                mothersName = dataReader.GetString(7);
                                drivingLicenseNumber = dataReader.GetString(8);
                                dlExpireDate = Convert.ToDateTime(dataReader.GetString(9));

                                Driver driver = new Driver();
                                driver.driverID = id;
                                driver.userID = userID;
                                driver.firstName = firstName;
                                driver.lastName = lastName;
                                driver.birthCountry = birthCountry;
                                driver.birthPlace = birthPlace;
                                driver.birthDate = birthDate;
                                driver.mothersName = mothersName;
                                driver.drivingLicenseNumber = drivingLicenseNumber;
                                driver.drivingLicenseExpireDate = dlExpireDate;
                                driverList.Add(driver);
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error: " + e.Message);
            }
            finally
            {

            }

            return driverList;
        }

        public List<Actions.Vehicle> GetAllVehicle(List<Actions.Vehicle> vehicleList)
        {

            vehicleList.Clear();

            int id;
            string make;
            string model;
            string registrationNumber;
            int year;
            DateTime firstRegistration;
            int categorie;
            string registrationMark;
            double selfWeight;
            double cilynderCapacity;
            DateTime rwtExpireDate;

            SQLiteConnection connection = new SQLiteConnection(Properties.Settings.Default.connection);
            try
            {
                connection.Open();
                using (connection)
                {
                    string sqlVehicle = "SELECT * FROM vehicles";
                    using (SQLiteCommand command = new SQLiteCommand(sqlVehicle, connection))
                    {
                        command.CommandText = sqlVehicle;
                        using (SQLiteDataReader dataReader = command.ExecuteReader())
                        {
                            while (dataReader.Read())
                            {
                                id = dataReader.GetInt32(0);
                                make = dataReader.GetString(1);
                                model = dataReader.GetString(2);
                                registrationNumber = dataReader.GetString(3);
                                year = dataReader.GetInt32(4);
                                firstRegistration = Convert.ToDateTime(dataReader.GetString(5));
                                categorie = dataReader.GetInt32(6);
                                registrationMark = dataReader.GetString(7);
                                selfWeight = dataReader.GetDouble(8);
                                cilynderCapacity = dataReader.GetDouble(9);
                                rwtExpireDate = Convert.ToDateTime(dataReader.GetString(10));

                                Vehicle vehicle = new Vehicle();
                                vehicle.vehicleID = id;
                                vehicle.make = make;
                                vehicle.model = model;
                                vehicle.registrationNumber = registrationNumber;
                                vehicle.registrationMark = registrationMark;
                                vehicle.year = year;
                                vehicle.dateOfFirstRegistration = firstRegistration;
                                vehicle.vehicleCategory = categorie;
                                vehicle.selfWeight = selfWeight;
                                vehicle.cilynderCapacity = cilynderCapacity;
                                vehicle.vehicleRoadworthinessTestExpireDate = rwtExpireDate;
                                vehicleList.Add(vehicle);
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error: " + e.Message);
            }
            finally
            {
            }

            return vehicleList;
        }

        public List<Actions.Categorie> GetAllCategorie(List<Actions.Categorie> categorieList)
        {
            categorieList.Clear();

            int id;
            string catName;

            SQLiteConnection connection = new SQLiteConnection(Properties.Settings.Default.connection);
            try
            {
                connection.Open();
                using (connection)
                {
                    string sqlCategorie = "SELECT * FROM categorie";
                    using (SQLiteCommand command = new SQLiteCommand(sqlCategorie, connection))
                    {
                        command.CommandText = sqlCategorie;
                        using (SQLiteDataReader dataReader = command.ExecuteReader())
                        {
                            while (dataReader.Read())
                            {
                                id = Convert.ToInt32(0);
                                catName = dataReader.GetString(1);

                                Categorie categorie = new Categorie();
                                categorie.categorieID = id;
                                categorie.categorieName = catName;
                                categorieList.Add(categorie);
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error: " + e.Message);
            }
            finally
            {
            }

            return categorieList;
        }

        public List<Actions.Categorie> GetDriverCategorie(List<Actions.Categorie> categorieList, int driverID)
        {
            categorieList.Clear();

            int id;
            string catName;

            SQLiteConnection connection = new SQLiteConnection(Properties.Settings.Default.connection);
            try
            {
                connection.Open();
                using (connection)
                {
                    string sqlCategorie = "SELECT * FROM catDrivers WHERE driverID = '" + driverID + "'";
                    using (SQLiteCommand command = new SQLiteCommand(sqlCategorie, connection))
                    {
                        command.CommandText = sqlCategorie;
                        using (SQLiteDataReader dataReader = command.ExecuteReader())
                        {
                            while (dataReader.Read())
                            {
                                id = dataReader.GetInt32(0);
                                catName = dataReader.GetString(1);

                                Categorie categorie = new Categorie();
                                categorie.categorieID = id;
                                categorie.categorieName = catName;
                                categorieList.Add(categorie);
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error: " + e.Message);
            }
            finally
            {
            }

            return categorieList;
        }

        public List<Actions.QualificationLevelInCareerAptitudeTest> GetAllQLICAT(List<Actions.QualificationLevelInCareerAptitudeTest> qlicatList)
        {
            qlicatList.Clear();

            int id;
            string qlicatName;

            SQLiteConnection connection = new SQLiteConnection(Properties.Settings.Default.connection);
            try
            {
                connection.Open();
                using (connection)
                {
                    string sqlQLICAT = "SELECT * FROM qualificationLevelInCareerAptitudeTest";
                    using (SQLiteCommand command = new SQLiteCommand(sqlQLICAT, connection))
                    {
                        command.CommandText = sqlQLICAT;
                        using (SQLiteDataReader dataReader = command.ExecuteReader())
                        {
                            while (dataReader.Read())
                            {
                                id = dataReader.GetInt32(0);
                                qlicatName = dataReader.GetString(1);

                                QualificationLevelInCareerAptitudeTest qlicat = new QualificationLevelInCareerAptitudeTest();
                                qlicat.qlicatID = id;
                                qlicat.qlicatName = qlicatName;
                                qlicatList.Add(qlicat);
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error: " + e.Message);
            }
            finally
            {
            }

            return qlicatList;
        }

        public List<Actions.QualificationLevelInCareerAptitudeTest> GetDriverQLICAT(List<Actions.QualificationLevelInCareerAptitudeTest> qlicatList, int driverID)
        {
            qlicatList.Clear();

            int id;
            string qlicatName;

            SQLiteConnection connection = new SQLiteConnection(Properties.Settings.Default.connection);
            try
            {
                connection.Open();
                using (connection)
                {
                    string sqlQLICAT = "SELECT * FROM datDrivers WHERE driverID = '" + driverID + "'";
                    using (SQLiteCommand command = new SQLiteCommand(sqlQLICAT, connection))
                    {
                        command.CommandText = sqlQLICAT;
                        using (SQLiteDataReader dataReader = command.ExecuteReader())
                        {
                            while (dataReader.Read())
                            {
                                id = dataReader.GetInt32(0);
                                qlicatName = dataReader.GetString(1);

                                QualificationLevelInCareerAptitudeTest qlicat = new QualificationLevelInCareerAptitudeTest();
                                qlicat.qlicatID = id;
                                qlicat.qlicatName = qlicatName;
                                qlicatList.Add(qlicat);
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error: " + e.Message);
            }
            finally
            {
            }

            return qlicatList;
        }

        public List<Actions.Project> GetAllProject(List<Actions.Project> projectList)
        {
            projectList.Clear();

            int id;
            string name;
            string number;
            string country;
            string city;
            string street;
            string placeNumber;
            string zip;

            SQLiteConnection connection = new SQLiteConnection(Properties.Settings.Default.connection);
            try
            {
                connection.Open();
                using (connection)
                {
                    string sqlProject = "SELECT * FROM project";
                    using (SQLiteCommand command = new SQLiteCommand(sqlProject, connection))
                    {
                        command.CommandText = sqlProject;
                        using (SQLiteDataReader dataReader = command.ExecuteReader())
                        {
                            while (dataReader.Read())
                            {
                                id = dataReader.GetInt32(0);
                                name = dataReader.GetString(1);
                                number = dataReader.GetString(2);
                                country = dataReader.GetString(3);
                                city = dataReader.GetString(4);
                                street = dataReader.GetString(5);
                                placeNumber = dataReader.GetString(6);
                                zip = dataReader.GetString(7);

                                Project project = new Project();
                                project.projectID = id;
                                project.projectName = name;
                                project.projectNumber = number;
                                project.projectCountry = country;
                                project.projectPlaceCity = city;
                                project.projectPlaceStreet = street;
                                project.projectPlaceNumber = placeNumber;
                                project.projectPlaceZIPCode = zip;

                                projectList.Add(project);
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error: " + e.Message);
            }
            finally
            {
            }

            return projectList;
        }

        public List<Actions.Customer> GetAllCustomer(List<Actions.Customer> customerList)
        {
            customerList.Clear();

            int id;
            string name;
            string type;
            string vat;
            string director;
            string headCountry;
            string headCity;
            string headStreet;
            string headPlace;
            string headNumber;
            string headBuilding;
            string headFloor;
            string headDoor;
            string mailCountry;
            string mailCity;
            string mailStreet;
            string mailPlace;
            string mailNumber;
            string mailBuilding;
            string mailFloor;
            string mailDoor;
            string headZip;
            string mailZip;

            SQLiteConnection connection = new SQLiteConnection(Properties.Settings.Default.connection);
            try
            {
                connection.Open();
                using (connection)
                {
                    string sqlCustomer = "SELECT * FROM customer";
                    using (SQLiteCommand command = new SQLiteCommand(sqlCustomer, connection))
                    {
                        command.CommandText = sqlCustomer;
                        using (SQLiteDataReader dataReader = command.ExecuteReader())
                        {
                            while (dataReader.Read())
                            {
                                id = dataReader.GetInt32(0);
                                name = dataReader.GetString(1);
                                type = dataReader.GetString(2);
                                vat = dataReader.GetString(21);
                                director = dataReader.GetString(22);
                                headCountry = dataReader.GetString(3);
                                headCity = dataReader.GetString(4);
                                headStreet = dataReader.GetString(5);
                                headPlace = dataReader.GetString(6);
                                headNumber = dataReader.GetString(7);
                                headBuilding = dataReader.GetString(8);
                                headFloor = dataReader.GetString(9);
                                headDoor = dataReader.GetString(10);
                                headZip = dataReader.GetString(11);
                                mailCountry = dataReader.GetString(12);
                                mailCity = dataReader.GetString(13);
                                mailStreet = dataReader.GetString(14);
                                mailPlace = dataReader.GetString(15);
                                mailNumber = dataReader.GetString(16);
                                mailBuilding = dataReader.GetString(17);
                                mailFloor = dataReader.GetString(18);
                                mailDoor = dataReader.GetString(19);
                                mailZip = dataReader.GetString(20);

                                Customer customer = new Customer();
                                customer.customerID = id;
                                customer.customerType = type;
                                customer.customerName = name;
                                customer.customerVAT = vat;
                                customer.customerExecutiveDirector = director;
                                customer.customerHeadCountry = headCountry;
                                customer.customerHeadCity = headCity;
                                customer.customerHeadStreet = headStreet;
                                customer.customerHeadPlace = headPlace;
                                customer.customerHeadNumber = headNumber;
                                customer.customerHeadBuilding = headBuilding;
                                customer.customerHeadFloor = headFloor;
                                customer.customerHeadDoor = headDoor;
                                customer.customerHeadZIPCode = headZip;
                                customer.customerMailCountry = mailCountry;
                                customer.customerMailCity = mailCity;
                                customer.customerMailStreet = mailStreet;
                                customer.customerMailPlace = mailPlace;
                                customer.customerMailNumber = mailNumber;
                                customer.customerMailBuilding = mailBuilding;
                                customer.customerMailFloor = mailFloor;
                                customer.customerMailDoor = mailDoor;
                                customer.customerMailZIPCode = mailZip;
                                customerList.Add(customer);
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error: " + e.Message);
            }
            finally
            {
            }

            return customerList;
        }

        public List<Actions.Company> GetAllCompany(List<Actions.Company> companyList)
        {
            companyList.Clear();

            int id;
            string name;
            string vat;
            string director;
            string headCountry;
            string headCity;
            string headStreet;
            string headPlace;
            string headNumber;
            string headBuilding;
            string headFloor;
            string headDoor;
            string mailCountry;
            string mailCity;
            string mailStreet;
            string mailPlace;
            string mailNumber;
            string mailBuilding;
            string mailFloor;
            string mailDoor;
            string headZip;
            string mailZip;

            SQLiteConnection connection = new SQLiteConnection(Properties.Settings.Default.connection);
            try
            {
                connection.Open();
                using (connection)
                {
                    string sqlCompany = "SELECT * FROM selfCompany";
                    using (SQLiteCommand command = new SQLiteCommand(sqlCompany, connection))
                    {
                        command.CommandText = sqlCompany;
                        using (SQLiteDataReader dataReader = command.ExecuteReader())
                        {
                            while (dataReader.Read())
                            {
                                id = dataReader.GetInt32(0);
                                name = dataReader.GetString(1);
                                vat = dataReader.GetString(20);
                                director = dataReader.GetString(21);
                                headCountry = dataReader.GetString(2);
                                headCity = dataReader.GetString(3);
                                headStreet = dataReader.GetString(4);
                                headPlace = dataReader.GetString(5);
                                headNumber = dataReader.GetString(6);
                                headBuilding = dataReader.GetString(8);
                                headFloor = dataReader.GetString(9);
                                headDoor = dataReader.GetString(10);
                                headZip = dataReader.GetString(7);
                                mailCountry = dataReader.GetString(11);
                                mailCity = dataReader.GetString(12);
                                mailStreet = dataReader.GetString(13);
                                mailPlace = dataReader.GetString(14);
                                mailNumber = dataReader.GetString(15);
                                mailBuilding = dataReader.GetString(17);
                                mailFloor = dataReader.GetString(18);
                                mailDoor = dataReader.GetString(19);
                                mailZip = dataReader.GetString(16);

                                Company company = new Company();
                                company.companyID = id;
                                company.companyName = name;
                                company.companyVATNumber = vat;
                                company.companyExeCutiveDirector = director;
                                company.companyHeadCountry = headCountry;
                                company.companyHeadCity = headCity;
                                company.companyHeadStreet = headStreet;
                                company.companyHeadPlace = headPlace;
                                company.companyHeadNumber = headNumber;
                                company.companyHeadBuilding = headBuilding;
                                company.companyHeadFloor = headFloor;
                                company.companyHeadDoor = headDoor;
                                company.companyHeadZIPCode = headZip;
                                company.companyMailCountry = mailCountry;
                                company.companyMailCity = mailCity;
                                company.companyMailStreet = mailStreet;
                                company.companyMailPlace = mailPlace;
                                company.companyMailNumber = mailNumber;
                                company.companyMailBuilding = mailBuilding;
                                company.companyMailFloor = mailFloor;
                                company.companyMailDoor = mailDoor;
                                company.companyMailZIPCode = mailZip;
                                companyList.Add(company);
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error: " + e.Message);
            }
            finally
            {
            }

            return companyList;
        }

        public List<Actions.DeliveryNote> GetAllSheet(List<Actions.DeliveryNote> noteList)
        {
            noteList.Clear();

            int id;
            string noteID;
            int projectID;
            int vehicleID;
            int driverID;
            int companyID;
            int customerID;
            double vehicleWeight;
            bool active = false;
            string depCountry;
            string depCity;
            string depStreet;
            string depPlace;
            string depNumber;
            string depBuilding;
            string depFloor;
            string depDoor;
            string depZip;
            string desCountry;
            string desCity;
            string desStreet;
            string desPlace;
            string desNumber;
            string desBuilding;
            string desFloor;
            string desDoor;
            string desZip;
            DateTime from;
            DateTime until;

            SQLiteConnection connection = new SQLiteConnection(Properties.Settings.Default.connection);
            try
            {
                connection.Open();
                using (connection)
                {
                    string sqlNote = "SELECT * FROM deliveryNote ORDER BY isItActive DESC, dateFrom ASC";
                    using (SQLiteCommand command = new SQLiteCommand(sqlNote, connection))
                    {
                        command.CommandText = sqlNote;
                        using (SQLiteDataReader dataReader = command.ExecuteReader())
                        {
                            while (dataReader.Read())
                            {
                                if (dataReader.GetString(25) == "True" || dataReader.GetString(25) == "true")
                                {
                                    active = true;
                                }
                                else
                                {
                                    active = false;
                                }

                                id = dataReader.GetInt32(0);
                                noteID = dataReader.GetString(28);
                                projectID = dataReader.GetInt32(1);
                                vehicleID = dataReader.GetInt32(2);
                                driverID = dataReader.GetInt32(3);
                                companyID = dataReader.GetInt32(4);
                                customerID = dataReader.GetInt32(5);
                                depCountry = dataReader.GetString(6);
                                depCity = dataReader.GetString(7);
                                depStreet = dataReader.GetString(8);
                                depPlace = dataReader.GetString(9);
                                depNumber = dataReader.GetString(10);
                                depBuilding = dataReader.GetString(11);
                                depFloor = dataReader.GetString(12);
                                depDoor = dataReader.GetString(13);
                                depZip = dataReader.GetString(14);
                                desCountry = dataReader.GetString(15);
                                desCity = dataReader.GetString(16);
                                desStreet = dataReader.GetString(17);
                                desPlace = dataReader.GetString(18);
                                desNumber = dataReader.GetString(19);
                                desBuilding = dataReader.GetString(20);
                                desFloor = dataReader.GetString(21);
                                desDoor = dataReader.GetString(22);
                                desZip = dataReader.GetString(23);
                                vehicleWeight = dataReader.GetDouble(24);
                                from = Convert.ToDateTime(dataReader.GetString(26));
                                until = Convert.ToDateTime(dataReader.GetString(27));

                                DeliveryNote note = new DeliveryNote();
                                note.noteID = id;
                                note.deliveryNoteID = noteID;
                                note.projectID = projectID;
                                note.vehicleID = vehicleID;
                                note.driverID = driverID;
                                note.companyID = companyID;
                                note.customerID = customerID;
                                note.departureCountry = depCountry;
                                note.deparutureCity = depCity;
                                note.departureStreet = depStreet;
                                note.departurePlace = depPlace;
                                note.departureNumber = depNumber;
                                note.departureBuilding = depBuilding;
                                note.departureFloor = depFloor;
                                note.departureDoor = depDoor;
                                note.departureZIP = depZip;
                                note.destinationCountry = desCountry;
                                note.destinationCity = desCity;
                                note.destinationStreet = desStreet;
                                note.destinationPlace = desPlace;
                                note.destinationNumber = desNumber;
                                note.destinationBuilding = desBuilding;
                                note.destinationFloor = desFloor;
                                note.destinationDoor = desDoor;
                                note.destinationZIP = desZip;
                                note.vehicleTotalWeight = vehicleWeight;
                                note.dateFrom = from;
                                note.dateTo = until;
                                note.isItActive = active;
                                noteList.Add(note);
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error: " + e.Message);
            }
            finally
            {
            }

            return noteList;
        }

        public List<Actions.Product> GetTheProduct(List<Actions.Product> productList, string note)
        {
            productList.Clear();

            int id;
            string name;
            string noteID;
            string unit;
            double quantity;
            double weight;

            SQLiteConnection connection = new SQLiteConnection(Properties.Settings.Default.connection);
            try
            {
                connection.Open();
                using (connection)
                {
                    string sqlProduct = "SELECT * FROM product " +
                                "WHERE productDeliveryNote = '" + note + "'";
                    using (SQLiteCommand command = new SQLiteCommand(sqlProduct, connection))
                    {
                        command.CommandText = sqlProduct;
                        using (SQLiteDataReader dataReader = command.ExecuteReader())
                        {
                            while (dataReader.Read())
                            {
                                id = dataReader.GetInt32(0);
                                name = dataReader.GetString(1);
                                noteID = dataReader.GetString(2);
                                unit = dataReader.GetString(4);
                                quantity = dataReader.GetDouble(3);
                                weight = dataReader.GetDouble(5);

                                Product product = new Product();
                                product.productID = id;
                                product.name = name;
                                product.deliveryNoteID = noteID;
                                product.unit = unit;
                                product.quantity = quantity;
                                product.weight = weight;
                                productList.Add(product);
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error: " + e.Message);
            }
            finally
            {
            }

            return productList;
        }

        public int GetMyProfil(string userName, string password, Actions.User user, int count)
        {
            SQLiteConnection connection = new SQLiteConnection(Properties.Settings.Default.connection);
            string sql = "SELECT * FROM users WHERE userName = '" + userName + "' AND password = '" + password + "'";
            connection.Open();
            SQLiteCommand command = new SQLiteCommand(sql, connection);
            command.ExecuteNonQuery();
            SQLiteDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                count++;

                user.userID = dataReader.GetInt32(0);
                user.userName = dataReader.GetString(1);
                user.password = dataReader.GetString(2);
                user.firstName = dataReader.GetString(3);
                user.lastName = dataReader.GetString(4);
                if (dataReader.GetString(5) == "True" || dataReader.GetString(5) == "true")
                {
                    user.isItAdmin = true;
                }
                else
                {
                    user.isItAdmin = false;
                }
                if (dataReader.GetString(6) == "True" || dataReader.GetString(6) == "true")
                {
                    user.isItADriver = true;
                }
                else
                {
                    user.isItADriver = false;
                }

            }

            return count;
        }

        public Actions.User GetMyProfil(string userName, string password, Actions.User user)
        {
            SQLiteConnection connection = new SQLiteConnection(Properties.Settings.Default.connection);
            string sql = "SELECT * FROM users WHERE userName = '" + userName + "' AND password = '" + password + "'";
            connection.Open();
            SQLiteCommand command = new SQLiteCommand(sql, connection);
            command.ExecuteNonQuery();
            SQLiteDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                user.userID = dataReader.GetInt32(0);
                user.userName = dataReader.GetString(1);
                user.password = dataReader.GetString(2);
                user.firstName = dataReader.GetString(3);
                user.lastName = dataReader.GetString(4);
                if (dataReader.GetString(5) == "True" || dataReader.GetString(5) == "true")
                {
                    user.isItAdmin = true;
                }
                else
                {
                    user.isItAdmin = false;
                }
                if (dataReader.GetString(6) == "True" || dataReader.GetString(6) == "true")
                {
                    user.isItADriver = true;
                }
                else
                {
                    user.isItADriver = false;
                }

            }

            return user;
        }

        public void ActionWithDataBase(string sql)
        {
            SQLiteConnection sqlConnection = new SQLiteConnection(Properties.Settings.Default.connection);
            try
            {
                using (sqlConnection)
                {
                    sqlConnection.Open();
                    using (SQLiteCommand myCommand = new SQLiteCommand(sql, sqlConnection))
                    {
                        myCommand.CommandText = sql;
                        myCommand.ExecuteNonQuery();
                        //MessageBox.Show("Sikeres");
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
            }
        }

        public void ModifyDataBase(string sql)
        {
            string message = "Biztosan módosítani szeretnéd?";
            string title = "Módosítás";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);

            if (result == DialogResult.Yes)
            {
                ActionWithDataBase(sql);
            }
        }

        public void DeleteFromDataBase(string sql)
        {
            string message = "Biztosan törölni szeretnéd?";
            string title = "Törlés";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);

            if (result == DialogResult.Yes)
            {
                ActionWithDataBase(sql);
            }
        }
    }
}
