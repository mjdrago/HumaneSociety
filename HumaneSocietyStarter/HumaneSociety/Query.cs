using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumaneSociety
{
    public static class Query
    {
        public delegate void CRUD(Employee employee);
        public static void RunEmployeeQueries(Employee employee, string type)
        {
            CRUD crudOption;
            if (type == "create")
            {
                crudOption = CreateEmployee;
            }
            else if (type == "read")
            {
                crudOption = ReadEmployee;
            }
            else if (type == "update")
            {
                crudOption = UpdateEmployee;
            }
            else
            {
                crudOption = DeleteEmployee;
            }
            crudOption(employee);
        }
        private static void CreateEmployee(Employee employee)
        {
            using (HumaneSocietyDataContext context = new HumaneSocietyDataContext())
            {
                context.Employees.InsertOnSubmit(employee);
                context.SubmitChanges();
            }
        }
        private static void ReadEmployee(Employee employee)
        {
            List<string> info = new List<string>() { $"Employee Number: {employee.employeeNumber}", $"Last Name: {employee.lastName}", $"First Name: {employee.firsttName}", $"E-mail: {employee.email}" };
            UserInterface.DisplayUserOptions(info);
            Console.ReadLine();
        }
        private static void UpdateEmployee(Employee employee)
        {
            using (HumaneSocietyDataContext context = new HumaneSocietyDataContext())
            {
                var employeeToUpdate = context.Employees.Where(r => r.ID == employee.ID).FirstOrDefault();
                employeeToUpdate.firsttName = employee.firsttName;
                employeeToUpdate.lastName = employee.lastName;
                employeeToUpdate.employeeNumber = employee.employeeNumber;
                employeeToUpdate.email = employee.email;
                context.SubmitChanges();
            }
        }

        private static void DeleteEmployee(Employee employee)
        {
            using (HumaneSocietyDataContext context = new HumaneSocietyDataContext())
            {
                context.Employees.DeleteOnSubmit(employee);
                context.SubmitChanges();
            }
        }



        public static Client GetClient(string userName, string password)
        {
            using (HumaneSocietyDataContext context = new HumaneSocietyDataContext())
            {
                var client = context.Clients.Where(r => r.userName == userName && r.pass == password).ToList();
                return client[0];
            }
        }
        public static List<ClientAnimalJunction> GetPendingAdoptions()
        {
            using (HumaneSocietyDataContext context = new HumaneSocietyDataContext())
            {
                var pendingAdoptions = context.ClientAnimalJunctions.Where(r => r.approvalStatus == null).ToList();
                return pendingAdoptions;
            }
        }
        public static List<ClientAnimalJunction> GetUserAdoptionStatus(Client client)
        {
            using (HumaneSocietyDataContext context = new HumaneSocietyDataContext())
            {
                var adoptionStatus = context.ClientAnimalJunctions.Where(r => r.client == client.ID).ToList();
                return adoptionStatus;
            }
        }

        public static Animal GetAnimalByID(int ID)
        {
            using (HumaneSocietyDataContext context = new HumaneSocietyDataContext())
            {
                var animal = context.Animals.Where(r => r.ID == ID).ToList();
                return animal[0];
            }
        }

        public static void Adopt(Animal animal, Client client)
        {
            using (HumaneSocietyDataContext context = new HumaneSocietyDataContext())
            {
                ClientAnimalJunction submitAdoption = new ClientAnimalJunction();
                submitAdoption.animal = animal.ID;
                submitAdoption.client = client.ID;
                context.ClientAnimalJunctions.InsertOnSubmit(submitAdoption);
                context.SubmitChanges();
            }
        }

        public static IQueryable<Client> RetrieveClients()
        {
            using (HumaneSocietyDataContext context = new HumaneSocietyDataContext())
            {
                var allClients = context.Clients;
                return allClients;
            }
        }

        public static IQueryable<USState> GetStates()
        {
            using (HumaneSocietyDataContext context = new HumaneSocietyDataContext())
            {
                var allStates = context.USStates;
                return allStates;
            }
        }

        public static void AddNewClient(string firstName, string lastName, string userName, string password, string email, string streetAddress, int zipCode, int state)
        {
            using (HumaneSocietyDataContext context = new HumaneSocietyDataContext())
            {
                Client newClient = new Client();
                newClient.firstName = firstName;
                newClient.lastName = lastName;
                newClient.userName = userName;
                newClient.pass = password;
                newClient.email = email;
                newClient.userAddress = CreateAddressRecord(streetAddress, zipCode, state);
                context.Clients.InsertOnSubmit(newClient);
                context.SubmitChanges();
            }
        }
        private static int CreateAddressRecord(string streetAddress, int zipCode, int state)
        {
            using (HumaneSocietyDataContext context = new HumaneSocietyDataContext())
            {
                string address1 = default(string);
                string address2 = default(string);
                int maxLength = 50;
                if (streetAddress.Length > maxLength)
                {
                    address1 = streetAddress.Substring(0, maxLength);
                    address2 = streetAddress.Substring(maxLength, maxLength);
                }
                else
                {
                    address1 = streetAddress;
                }
                UserAddress newAddress = new UserAddress();
                newAddress.addessLine1 = address1;
                newAddress.addressLine2 = address2;
                newAddress.zipcode = zipCode;
                newAddress.USStates = state;
                context.UserAddresses.InsertOnSubmit(newAddress);
                context.SubmitChanges();
                return newAddress.ID;
            }

        }
        public static void UpdateClient(Client client)
        {
            using (HumaneSocietyDataContext context = new HumaneSocietyDataContext())
            {
                Client clientToUpdate = context.Clients.Where(r => r.ID == client.ID).FirstOrDefault();
                clientToUpdate.homeSize = client.homeSize;
                clientToUpdate.kids = client.kids;
                clientToUpdate.income = client.income;
                clientToUpdate.pass = client.pass;
                context.SubmitChanges();
            }
        }
        public static void UpdateUsername(Client client)
        {
            using (HumaneSocietyDataContext context = new HumaneSocietyDataContext())
            {
                Client clientToUpdate = context.Clients.Where(r => r.ID == client.ID).FirstOrDefault();
                clientToUpdate.userName = client.userName;
                context.SubmitChanges();
            }
        }
        public static void UpdateEmail(Client client)
        {
            using (HumaneSocietyDataContext context = new HumaneSocietyDataContext())
            {
                Client clientToUpdate = context.Clients.Where(r => r.ID == client.ID).FirstOrDefault();
                clientToUpdate.email = client.email;
                context.SubmitChanges();
            }
        }
        public static void UpdateAddress(Client client)
        {
            using (HumaneSocietyDataContext context = new HumaneSocietyDataContext())
            {
                Client clientToUpdate = context.Clients.Where(r => r.ID == client.ID).FirstOrDefault();
                clientToUpdate.userAddress = client.userAddress;
                context.SubmitChanges();
            }
        }
        public static void UpdateFirstName(Client client)
        {
            using (HumaneSocietyDataContext context = new HumaneSocietyDataContext())
            {
                Client clientToUpdate = context.Clients.Where(r => r.ID == client.ID).FirstOrDefault();
                clientToUpdate.firstName = client.firstName;
                context.SubmitChanges();
            }
        }
        public static void UpdateLastName(Client client)
        {
            using (HumaneSocietyDataContext context = new HumaneSocietyDataContext())
            {
                Client clientToUpdate = context.Clients.Where(r => r.ID == client.ID).FirstOrDefault();
                clientToUpdate.lastName = client.lastName;
                context.SubmitChanges();
            }
        }

        public static void UpdateAdoption(bool value, ClientAnimalJunction clientAnimalJunction)
        {
            using (HumaneSocietyDataContext context = new HumaneSocietyDataContext())
            {
                ClientAnimalJunction updateAdoptionStatus = context.ClientAnimalJunctions.Where(r => r.animal == clientAnimalJunction.animal && r.client == clientAnimalJunction.client).FirstOrDefault();
                updateAdoptionStatus.approvalStatus = UserInterface.BoolToYesNo(value);
                context.SubmitChanges();
            }
        }

        public static List<AnimalShotJunction> GetShots(Animal animal)
        {
            using (HumaneSocietyDataContext context = new HumaneSocietyDataContext())
            {
                var shotsGiven = context.AnimalShotJunctions.Where(r => r.Animal_ID == animal.ID).ToList();
                return shotsGiven;
            }
        }

        public static void UpdateShot(string input, Animal animal)
        {
            using (HumaneSocietyDataContext context = new HumaneSocietyDataContext())
            {
                int shotID = GetShotType(input);
                AnimalShotJunction newShot = new AnimalShotJunction();
                newShot.Animal_ID = animal.ID;
                newShot.Shot_ID = shotID;
                newShot.dateRecieved = DateTime.Now;
                context.AnimalShotJunctions.InsertOnSubmit(newShot);
                context.SubmitChanges();
            }
        }
        private static int GetShotType(string shot)
        {
            using (HumaneSocietyDataContext context = new HumaneSocietyDataContext())
            {
                var shotWanted = context.Shots.Where(r => r.name == shot).ToList();
                return shotWanted[0].ID;
            }
        }

        public static void EnterUpdate(Animal animal, Dictionary<int, string> updates)
        {

        }

        public static void RemoveAnimal(Animal animal)
        {
            using (HumaneSocietyDataContext context = new HumaneSocietyDataContext())
            {
                context.Animals.DeleteOnSubmit(animal);
                context.SubmitChanges();
            }
        }
        public static int GetBreed()
        {
            using (HumaneSocietyDataContext context = new HumaneSocietyDataContext())
            {
                int categoryId = DetermineCategory();
                int breedId = DeterminedBreedIndex(categoryId);
                return breedId;
            }
        }

        private static int DetermineCategory()
        {
            using (HumaneSocietyDataContext context = new HumaneSocietyDataContext())
            {
                List<string> categoryTypeInfo = new List<string>();
                var categories = context.Catagories.ToList();
                int categoryCounter = 1;
                int categoryOutput;
                foreach (var category in categories)
                {
                    categoryTypeInfo.Add($"{categoryCounter}. {category.catagory1}");
                }
                UserInterface.DisplayUserOptions("Select type of animal: (Enter the number)");
                UserInterface.DisplayUserOptions(categoryTypeInfo);
                try
                {
                    int categoryIndex = int.Parse(UserInterface.GetUserInput());
                    if (categoryIndex >= categoryTypeInfo.Count)
                    {
                        UserInterface.DisplayUserOptions("Not a valid category. Please try again.");
                        categoryOutput = DetermineCategory();
                    }
                    else
                    {
                        categoryOutput = categories[categoryIndex - 1].ID;
                    }
                }
                catch
                {
                    UserInterface.DisplayUserOptions("Input was not a valide number. Please enter a valide number.");
                    categoryOutput = DetermineCategory();
                }
                return categoryOutput;
            }
        }
        private static int DeterminedBreedIndex(int categoryIndex)
        {
            using (HumaneSocietyDataContext context = new HumaneSocietyDataContext())
            {
                List<string> breedTypeInfo = new List<string>();
                var breeds = context.Breeds.Where(r => r.catagory == categoryIndex).ToList();
                int breedCounter = 1;
                int breedOutput;
                foreach (var breed in breeds)
                {
                    breedTypeInfo.Add($"{breedCounter}. {breed.breed1} with a {breed.pattern} pattern.");
                }
                UserInterface.DisplayUserOptions("Select the breed and pattern: (Enter the number)");
                UserInterface.DisplayUserOptions(breedTypeInfo);
                try
                {
                    int breedIndex = int.Parse(UserInterface.GetUserInput());
                    if (categoryIndex >= breedTypeInfo.Count)
                    {
                        UserInterface.DisplayUserOptions("Not a valid category. Please try again.");
                        breedOutput = DeterminedBreedIndex(categoryIndex);
                    }
                    else
                    {
                        breedOutput = breeds[breedIndex - 1].ID;
                    }
                }
                catch
                {
                    UserInterface.DisplayUserOptions("Input was not a valide number. Please enter a valide number.");
                    breedOutput = DeterminedBreedIndex(categoryIndex);
                }
                return breedOutput;
            }
        }
        public static int GetDiet()
        {
            return GetDiet();
        }
        public static int GetLocation()
        {
            return GetLocation();
        }
        public static void AddAnimal(Animal animal)
        {
            using (HumaneSocietyDataContext context = new HumaneSocietyDataContext())
            {
                context.Animals.InsertOnSubmit(animal);
                context.SubmitChanges();
            }
        }
        public static Employee EmployeeLogin(string userName, string password)
        {
            using (HumaneSocietyDataContext context = new HumaneSocietyDataContext())
            {
                var employee = context.Employees.Where(r => r.userName == userName && r.pass == password).ToList();
                return employee[0];
            }
        }
        public static Employee RetrieveEmployeeUser(string email, int employeeNumber)
        {
            using (HumaneSocietyDataContext context = new HumaneSocietyDataContext())
            {
                var employee = context.Employees.Where(r => r.email == email && r.employeeNumber == employeeNumber).ToList();
                return employee[0];
            }
        }
        public static void AddUsernameAndPassword(Employee employee)
        {
            using (HumaneSocietyDataContext context = new HumaneSocietyDataContext())
            {
                var newUser = context.Employees.Where(r => r.ID == employee.ID).FirstOrDefault();
                newUser.userName = employee.userName;
                newUser.pass = employee.pass;
                context.SubmitChanges();
            }
        }
        public static bool CheckEmployeeUserNameExist(string username)
        {
            using (HumaneSocietyDataContext context = new HumaneSocietyDataContext())
            {
                var employees = context.Employees;
                foreach (var employee in employees)
                {
                    if (employee.userName == username)
                    {
                        return true;
                    }
                }
                return false;
            }
        }

    }

}
