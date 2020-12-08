using DevTeamsProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramUI
{
    public class UI
    {
        private DeveloperRepo _developerRepo = new DeveloperRepo();
        private DevTeamRepo _devTeam = new DevTeamRepo();
        public void Run()
        {
            SeedDevelopers();
            Menu();
        }

        private void Menu()
        {
            bool keepRunning = true;
            while(keepRunning)
            {
                Console.WriteLine("Select Menu Option: \n" +
                    "1. Add New Developer\n" +
                    "2. View All Developers\n" +
                    "3. View Data by Employee ID\n" +
                    "4. Update Existing Developer\n" +
                    "5. Delete Existing Developer\n" +
                    "6. Add Developer To DevTeam\n" +
                    "7. Exit");
                   

                //Get user input
                string input = Console.ReadLine();

                //Evaluate the user input
                switch (input)
                {
                    case "1":
                        //Create New Developer
                        CreateNewDeveloper();
                        break;
                    case "2":
                        //ViewAllDevelopers
                        ViewAllDevelopers();
                        break;
                    case "3":
                        //View Data by Employee ID
                        ViewDataByEmployeeID();
                        break;
                    case "4":
                        //Update Existing Developer
                        UpdateExistingDeveloper();
                        break;
                    case "5":
                        //Delete Existing Developer
                        DeleteExistingDeveloper();
                        break;
                    case "6":
                        //Add Dev to DevTeam
                        AddDevtoDevTeam();
                        break;
                    case "7":
                        //Exit
                        Console.WriteLine("Have a nice day!");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please Enter a Valid Number!");
                        break;
                }
                Console.WriteLine("Please Press Any Key to Continue!!!");
                Console.ReadKey();
                Console.Clear();
            }
        }

        //Create New Developer
        private void CreateNewDeveloper()
        {
            Console.Clear();
            Developer newContent = new Developer();

            //Name
            Console.WriteLine("Enter the Full Name of the New Developer:");
            newContent.Name = Console.ReadLine();

            //ID
            Console.WriteLine("Enter the Employee ID for the New Developer:");
            //Console.ReadLine is a string, which is why this is erroring try parsing this as an integer *int.Parse()*
            string oldIDAsString = Console.ReadLine();
            int oldIDAsInt = int.Parse(oldIDAsString);
            newContent.ID = oldIDAsInt;

            //TeamName
            Console.WriteLine("Enter Desired Team Name.");
            string TeamNameAsString = Console.ReadLine();
           
            newContent.Name = TeamNameAsString;

            //License
            Console.WriteLine("Does the New Developer have a Pluralsight License? (y/n)");
            string pLic = Console.ReadLine().ToLower();

            if(pLic == "y")
            {
                newContent.License = true;
            }
            else
            {
                newContent.License = false;
            }
        }

        public void AddDevtoDevTeam()
        {
            Console.Clear();
            //Prompt the user for a Desired Developer ID
            Console.WriteLine("Enter Developer ID you with to add");
            //Create a Developer object and instantiate the GetDeveloperById helper method and pass in the desired Id the user gave.
            string idAsString = Console.ReadLine();
            int idAsInt = int.Parse(idAsString);
            Developer newDeveloper = _developerRepo.GetDeveloperByID(idAsInt);
            //prompt the user for a desired DevTeam Id
            Console.WriteLine("Enter Desired Team Name");
            string teamNameasString = Console.ReadLine();

            ////Create a DevTeam object and instantiate the GetDevTeamById helper method and pass in the desired Id the user gave.
            DevTeam newDevTeam = _devTeam.GetTeamByTeamName(teamNameasString);


            //Then your going to call the_devTeam field and then the AddDevtoDevTeam Method within the DevTeamRepo and pass in you Developer object (local variable) and your DevTeam object (Local variable)
            _devTeam.AddDevToDevTeam(newDeveloper, newDevTeam);
        }
        private void ViewAllDevelopers()
        {
            Console.Clear();
            List<Developer> listOfDevelopers = _developerRepo.GetDeveloperList();

            foreach(Developer content in listOfDevelopers)
            {
                Console.WriteLine($"Name: {content.Name}\n" +
                    $"ID Number: {content.ID}\n" +
                    $"Team Name: {content.NameOfTeam}\n" +
                    $"License: {content.License}");
            }
        }

        private void ViewDataByEmployeeID()
        {
            Console.Clear();
            //Prompt to get an ID
            Console.WriteLine("Enter the Employee ID of the Desired Employee");

            //Get user input
            string oldIDAsString = Console.ReadLine();
            int oldIDAsInt = int.Parse(oldIDAsString);
            


            //find content by employee ID
            Developer content = _developerRepo.GetDeveloperByID(oldIDAsInt);

            //display content if it isnt null
            if(content != null)
            {
                Console.WriteLine($"Name: {content.Name}\n" +
                    $"ID Number: {content.ID}\n" +
                    $"Team Name: {content.NameOfTeam}\n" +
                    $"License: {content.License}");
            }
            else
            {
                Console.WriteLine("No Employee by that Employee ID Number!");
            }
        }
        private void UpdateExistingDeveloper()
        {
            //Display all content
            ViewAllDevelopers();
            //Build A New Object
            Developer newDeveloper = new Developer();
            //Ask for Employee ID to update
            Console.WriteLine("Enter the Employee ID to update!");
            //get ID
            string oldIDAsString = Console.ReadLine();
            int oldIDAsInt = int.Parse(oldIDAsString);
            //I'm not sure what you're trying to do here, but you don't have any object named 'id' remove that and this should work fine.
            newDeveloper.ID = oldIDAsInt;
            Console.Clear();
            //^^ this works now
           
            //Name
            Console.WriteLine("Enter the new name for the Employee");
            newDeveloper.Name = Console.ReadLine();
            //ID
            Console.WriteLine("Enter the New Employee ID for the Employee");
            string eIDAsString = Console.ReadLine();
            int eIDAsInt = int.Parse(eIDAsString);
            //same as the lower case id problem you have ten 
            newDeveloper.ID = eIDAsInt;
            //^^ this works now

            //License
            Console.WriteLine("Do this Employee have a License? (y/n)");
            string lic = Console.ReadLine().ToLower();

            if(lic == "y")
            {
                newDeveloper.License = true;
            }
            else
            {
                newDeveloper.License = false;
            }
            //TeamName
            Console.WriteLine("Enter the New TeamName for the Employee:\n" +
                "1. Alpha\n" +
                "2. Beta\n" +
                "3. Gamma");

            string teamNameAsString = Console.ReadLine();
            int teamNameAsInt = int.Parse(teamNameAsString);
            newDeveloper.NameOfTeam = (TeamName)teamNameAsInt;

            _developerRepo.UpdateExistingDeveloper(oldIDAsInt, newDeveloper);

            //verify it worked
            bool wasUpdated = _developerRepo.UpdateExistingDeveloper(oldIDAsInt, newDeveloper);
            if(wasUpdated)
            {
                Console.WriteLine("Developer Updated Successfully");
            }
            else
            {
                Console.WriteLine("Developer Not Updated!");
            }

        }
    

        //Delete Existing Developer
        private void DeleteExistingDeveloper()
        {
            ViewAllDevelopers();
            //get ID they want to remove
            Console.WriteLine("\n Enter the Employee ID of the Employee You'd like to Remove!");
            string oldIDAsString = Console.ReadLine();
            int oldIDAsInt = int.Parse(oldIDAsString);
            bool wasDeleted = _developerRepo.RemoveContentFromList(oldIDAsInt);
            if(wasDeleted)
            {
                Console.WriteLine("The Employee Record was Removed");
            }
            else
            {
                Console.WriteLine("The Employee Record was Not Removed");
            }
        }

        //Seed Method
        private void SeedDevelopers()
        {
            Developer jon = new Developer("Jon Kinne", 121, true, TeamName.Alpha);
            Developer mike = new Developer("Mike Jones", 122, false, TeamName.Beta);
            Developer travis = new Developer("Travis Lockmiller", 123, true, TeamName.Gamma);
            Developer jose = new Developer("Jose Garcia", 124, true, TeamName.Alpha);
            Developer michael = new Developer("Michael Jenkins", 125, false, TeamName.Beta);
            Developer julian = new Developer("Julian Sampedro", 126, false, TeamName.Gamma);
            Developer stephanie = new Developer("Stephanie Wu", 127, true, TeamName.Alpha);
            Developer justin = new Developer("Justin Swans", 128, true, TeamName.Beta);
            Developer joe = new Developer("Joe Smith", 129, true, TeamName.Gamma);
            Developer rob = new Developer("Rob Hill", 130, true, TeamName.Alpha);
            Developer brittany = new Developer("Brittany Lemons", 131, false, TeamName.Beta);
            Developer lucas = new Developer("Lucas Nancy", 132, true, TeamName.Gamma);

            _developerRepo.AddDeveloperToList(jon);
            _developerRepo.AddDeveloperToList(mike);
            _developerRepo.AddDeveloperToList(travis);
            _developerRepo.AddDeveloperToList(jose);
            _developerRepo.AddDeveloperToList(michael);
            _developerRepo.AddDeveloperToList(julian);
            _developerRepo.AddDeveloperToList(stephanie);
            _developerRepo.AddDeveloperToList(justin);
            _developerRepo.AddDeveloperToList(joe);
            _developerRepo.AddDeveloperToList(rob);
            _developerRepo.AddDeveloperToList(brittany);
            _developerRepo.AddDeveloperToList(lucas);
        }
    }
}
