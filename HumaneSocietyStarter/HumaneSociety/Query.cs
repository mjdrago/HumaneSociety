using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumaneSociety
{
    public static class Query
    {
        public static void RunEmployeeQueries(Employee employee, string type)
        {
            Console.Clear();
            UserInterface.DisplayUserOptions("Would you like to 1) create, 2) read, 3) update or 4) delete an employee?");
            string input = UserInterface.GetUserInput();
            switch (input)
            {
                case "create":
                    CreateEmployee();
                    break;
                case "read":
                    ReadEmployee();
                    break;
                case "update":
                    UpdateEmployee();
                    break;
                case "delete":
                    DeleteEmployee();
                    break;
                default:
                    UserInterface.DisplayUserOptions("Incorrect Input type please enter create, read, update or delete");
                    RunEmployeeQueries(employee, type);
                    break;
            }
        }
        private static void CreateEmployee()
        {

        }
        private static void ReadEmployee()
        {

        }
        private static void UpdateEmployee()
        {

        }
 
        private static void DeleteEmployee()
        {

        }
      


        public static Client GetClient(string userName, string password)
        {
            return GetClient(userName, password);
        }
        public static List<ClientAnimalJunction> GetPendingAdoptions() //not sure about parameters needed? 
        {
            return GetPendingAdoptions();
        }
        public static List<ClientAnimalJunction> GetUserAdoptionStatus(Client client)
        {
            return GetUserAdoptionStatus(client);
        }

        public static Animal GetAnimalByID(int ID)
        {
            return GetAnimalByID(ID);
        }

        public static void Adopt(Animal animal, Client client)
        {

        }

        public static IQueryable<Client> RetrieveClients()
        {
            return RetrieveClients();
        }

        public static IQueryable<USState> GetStates()
        {
            return GetStates();
        }

        public static void AddNewClient(string firstName, string lastName, string userName, string password, string email, string streetAddress, int zipCode, int state)
        {
            
        }

        public static void UpdateClient(Client client)
        {
            
        }
        public static void UpdateUsername(Client client)
        {

        }
        public static void UpdateEmail(Client client)
        {

        }
        public static void UpdateAddress(Client client)
        {

        }
        public static void UpdateFirstName(Client client)
        {

        }
        public static void UpdateLastName(Client client)
        {

        }

        public static void UpdateAdoption(bool value, ClientAnimalJunction clientAnimalJunction)
        {

        }

        public static List<AnimalShotJunction> GetShots(Animal animal)
        {
            return GetShots(animal);
        }

        public static void UpdateShot(string input, Animal animal)
        {

        }

        public static void EnterUpdate(Animal animal, Dictionary<int, string> client) //not sure what identifier to use for Dictionary
        {

        }

        public static void RemoveAnimal(Animal animal)
        {

        }
        public static int GetBreed()
        {
            return GetBreed();
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

        }
        public static Employee EmployeeLogin(string userName, string password)
        {
            return EmployeeLogin(userName, password);
        }
        public static Employee RetrieveEmployeeUser(string email, int employeeNumber)
        {
            return RetrieveEmployeeUser(email, employeeNumber);
        }
        public static void AddUsernameAndPassword(Employee employee)
        {

        }
        public static bool CheckEmployeeUserNameExist(string username)
        {
            return CheckEmployeeUserNameExist(username);
        }

    }
}
