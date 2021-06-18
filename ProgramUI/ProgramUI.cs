using DeveloperRepo;
using DeveloperNameSpace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevTeamRepo;
using DevTeamNameSpace;

namespace ProgramUINamespace
{
    public class ProgramUI
    {
        private DeveloperCRUD _developerRepo = new DeveloperCRUD();
        private DevTeamCRUD _devTeamRepo = new DevTeamCRUD();
        int id = 1;
        int teamID = 1;
        public void Run()
        {
            SeedData();
            Menu();
        }

        private void Menu()
        {
            bool keepGoing = true;
            while (keepGoing)
            {
                Console.WriteLine("Developer Menu \n" +
                                  "1) Add New Developer \n" +
                                  "2) View Developer\n" +
                                  "3) Delete Developer\n" +
                                  "4) Update Developer\n\n" +
                                  "Team Menu\n" +
                                  "5) Add New Team\n" +
                                  "6) View Teams \n" +
                                  "7) Delete Teams\n" +
                                  "8) Update Team Name\n" +
                                  "9) Add Team Members \n" +
                                  "10) Delete Team Member \n" +
                                  "11) View Team Memebrs \n \n" +
                                  "12) Exit") ; 
                string userInput = Console.ReadLine();

                switch (userInput)
                {   
                    //Create New Developer
                    case "1":
                        AddNewDeveloper();
                        break;

                    case "2":
                        ViewAllDeveloper();
                        break;

                    case "3":
                        DeleteDeveloper();
                        break;

                    case "4":
                        UpdateDeveloper();
                        break;
                    case "5":
                        AddNewTeam();
                        break;
                    case "6":
                        ViewTeams();
                        break;
                    case "7":
                        DeleteTeam();
                        break;
                    case "8":
                        UpdateTeamName();
                        break;
                    case "9":
                        AddTeamMembers();
                        break;
                    case "10":
                        DeleteTeamMemeber();
                        break;
                    case "11":
                        ViewTeamMembers();
                        break;
                    case "12":
                        Console.WriteLine("Goodbye");
                        keepGoing = false;
                        break;

                    default:
                        Console.WriteLine("Invalid input");
                        break;








                }
            }
        }

        private void AddNewDeveloper()
        {
            Console.Clear();
            Developer devloper = new Developer();
            Console.WriteLine("What is your name? ");
            devloper.Name = Console.ReadLine(); //Name
            devloper.ID = id;  //Id
            id++;
            
            
            Console.WriteLine("Do you have access to plural sight? Y | N");
            string pluralSight = Console.ReadLine().ToLower();
            if (pluralSight == "y")
            {
                devloper.HasPluralSight = true;
            }
            else if (pluralSight == "n")
            {
                devloper.HasPluralSight = false;
            }
            else
            {
                Console.WriteLine("Not sure what you mean");
            }
            _developerRepo.AddDeveloper(devloper);




        } //end Add New Developer
        private void ViewAllDeveloper()
        {
            Console.Clear();
            List<Developer> devlopers = _developerRepo.GetDevelopers();
            foreach(Developer developer in devlopers)
            {
                Console.WriteLine($" ID: {developer.ID} \n Name: {developer.Name} \n Pluralsight: {developer.HasPluralSight} \n \n");
            }
        } // end View Developer
        private void DeleteDeveloper()
        {
            ViewAllDeveloper();
            Console.WriteLine("Select The ID of the Developer you want to remove");
            int userInput = Convert.ToInt32(Console.ReadLine());
            bool wasDeleted = _developerRepo.DeleteDeveloper(userInput);
            if (wasDeleted)
            {
                Console.WriteLine("Developer Deleted");
            }
            else
            {
                Console.WriteLine("Developer could not be deleted");
            }

        } //end Delete Developer
        private void UpdateDeveloper()
        {
            ViewAllDeveloper();
            Console.WriteLine("Which Developer ID Do you want to edit?");
            int oldID = Convert.ToInt32(Console.ReadLine());

            Console.Clear();
            Developer newDevloper = new Developer();
            Console.WriteLine("What is your name? ");
            newDevloper.Name = Console.ReadLine(); //Name
            newDevloper.ID = id;  //Id
            id++;
            Console.WriteLine("Do you have access to plural sight? Y | N");
            string pluralSight = Console.ReadLine().ToLower();
            if (pluralSight == "y")
            {
                newDevloper.HasPluralSight = true;
            }
            else if (pluralSight == "n")
            {
                newDevloper.HasPluralSight = false;
            }
            else
            {
                Console.WriteLine("Not sure what you mean");
            }
            _developerRepo.UpdateDeveloper(oldID, newDevloper);

        } //end Update Developer

        private void AddNewTeam()
        {
            Console.Clear();
            DevTeam devteam = new DevTeam();
            Console.WriteLine("What is your Team Name?");
            devteam.TeamName = Console.ReadLine();
            devteam.TeamID = teamID;
            _devTeamRepo.CreateDevTeam(devteam);

            

        } //end Add New Team
        private void ViewTeams()
        {
            Console.Clear();
            List<DevTeam> devteams = _devTeamRepo.GetDevTeam();
            foreach(DevTeam devteam in devteams)
            { 
                Console.WriteLine($" Team ID: {devteam.TeamID} \n Team Name:{devteam.TeamName} \n \n");
            }

        } //end View All Team
        private void DeleteTeam()
        {
            Console.Clear();
            ViewTeams();
            Console.WriteLine("Select the ID of the Team you want to Delete");
            int removeTeamID = Convert.ToInt32(Console.ReadLine());
            bool wasDeleted =_devTeamRepo.DeleteTeam(removeTeamID);
            if(wasDeleted == true)
            {
                Console.WriteLine("Team Was Deleted");
            }
            else if(wasDeleted == false)
            {
                Console.WriteLine("Team was not deleted");
            }
        } //end Delete Team
        private void UpdateTeamName()
        {
            Console.Clear();
            ViewTeams();
            Console.WriteLine("Select The Team ID you want to update");
            int teamIdUpdate = Convert.ToInt32(Console.ReadLine());
            DevTeam newDevTeam = new DevTeam();
            Console.WriteLine("What is your Team Name?");
            newDevTeam.TeamName = Console.ReadLine();
            newDevTeam.TeamID = teamID;

           bool wasUpdated = _devTeamRepo.UpdateDevTeam(teamIdUpdate, newDevTeam);


        } //end Update Team
        private void ViewTeamMembers(/*DevTeam devteam*/)
        {
            //See All Teams available  
            ViewTeams();
            Console.WriteLine("Select Team ID to view Members");
            int teamID = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            List<Developer> developers = _devTeamRepo.ViewTeamMembers(teamID);
            foreach (Developer developer in developers)
            {
                Console.WriteLine($" ID: {developer.ID} \n Name: {developer.Name} \n \n");
            }
            /*
            foreach(Developer developer in devteam.Developers)
            {
                Console.WriteLine($" Assigned Team: {devteam.TeamName} \n Developer ID: {developer.ID} \n Developer Name:{developer.Name} \n \n ");
            }
            */

            
        } //end View Team Members
        private void DeleteTeamMemeber()
        {
            ViewTeams();
            Console.WriteLine("Select Team ID to view Members");
            int teamID = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            List<Developer> developers = _devTeamRepo.ViewTeamMembers(teamID);
            foreach (Developer developer in developers)
            {
                Console.WriteLine($" ID: {developer.ID} \n Name: {developer.Name} \n \n");
            }
            Console.WriteLine("Select THE ID of the Developer you want to remove");
            int devloperID = Convert.ToInt32(Console.ReadLine());
            Developer devObj = _developerRepo.GetDeveloperByID(devloperID);

            bool wasTrue =_devTeamRepo.DeleteTeamMember(teamID, devObj);
            if(wasTrue)
            {
                Console.WriteLine("Developer Deleteed \n \n");
            }
            else
            {
                Console.WriteLine("Developer Could Not Be Deleted \n \n");
            }
           
            


        } //end Delete Team Member
        private void AddTeamMembers()
        {
            //See All Teams available  
            ViewTeams();
            Console.WriteLine("Select the ID of the Team you want to add members too");
            int teamID = Convert.ToInt32(Console.ReadLine());
            ViewAllDeveloper();
            Console.WriteLine("Select the ID of the Developer you want to add");
            int developerID = Convert.ToInt32(Console.ReadLine());
            Developer developer = _developerRepo.GetDeveloperByID(developerID);
            _devTeamRepo.AddTeamMember(developer, teamID);






        } // end Add Team Members

        public void SeedData()
        {
            Developer Robert = new Developer("Robert", 0, true);
            Developer Emma = new Developer("Emma", 2, false);
            Developer Hannah = new Developer("Hannah", 3, true);
            Developer Matt = new Developer("Matt", 4, false);

            _developerRepo.AddDeveloper(Robert);
            _developerRepo.AddDeveloper(Emma);

            DevTeam Red = new DevTeam(0, "Red", new List<Developer>() {Robert, Emma});
            DevTeam Blue = new DevTeam(2, "Blue", new List<Developer>() { Hannah, Matt });

            _devTeamRepo.CreateDevTeam(Red);
            _devTeamRepo.CreateDevTeam(Blue);

        }

    }




}
