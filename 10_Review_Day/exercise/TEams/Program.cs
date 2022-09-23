using System;
using System.Collections.Generic;

namespace TEams
{
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            program.Run();
        }

        List<Department> departments = new List<Department>();
        List<Employee> employees = new List<Employee>();
        Dictionary<string, Project> projects = new Dictionary<string, Project>();

        private void Run()
        {
            // create some departments
            CreateDepartments();

            // print each department by name
            PrintDepartments();

            // create employees
            CreateEmployees();

            // give Angie a 10% raise, she is doing a great job!
            employees[1].Salary = employees[1].RaiseSalary(.10);

            // print all employees
            PrintEmployees();

            // create the TEams project
            CreateTeamsProject();

            // create the Marketing Landing Page Project
            CreateLandingPageProject();

            // print each project name and the total number of employees on the project
            PrintProjectsReport();
        }

        /**
         * Create departments and add them to the collection of departments
         */
        private void CreateDepartments()
        {
            Department marketing = new Department(1, "Marketing");
            Department sales = new Department(2, "Sales");
            Department engineering = new Department(3, "Engineering");
            departments.Add(marketing);
            departments.Add(sales);
            departments.Add(engineering);
        }

        /**
         * Print out each department in the collection.
         */
        private void PrintDepartments()
        {
            Console.WriteLine("------------- DEPARTMENTS ------------------------------");
            foreach (Department item in departments)
            {
                Console.WriteLine(item.Name);
            }

        }

        /**
         * Create employees and add them to the collection of employees
         */
        private void CreateEmployees()
        {
            Employee deanJohnson = new Employee();
            deanJohnson.EmployeeId = 1;
            deanJohnson.FirstName = "Dean";
            deanJohnson.LastName = "Johnson";
            deanJohnson.Email = "djohnson@teams.com";
            deanJohnson.Department = departments[2];
            deanJohnson.HireDate = "08/21/2020";
            Employee angieSmith = new Employee(2, "Angie", "Smith", "asmith@teams.com", departments[2], "08/21/2020");
            Employee margaretThompson = new Employee(3, "Margaret", "Thompson", "mthompson@teams.com", departments[0], "08/21/2020");
            employees.Add(deanJohnson);
            employees.Add(angieSmith);
            employees.Add(margaretThompson);
        }

        /**
         * Print out each employee in the collection.
         */
        private void PrintEmployees()
        {
            Console.WriteLine("\n------------- EMPLOYEES ------------------------------");
            foreach(Employee item in employees)
            {
                Console.WriteLine(item.FullName + " (" + item.Salary + ") " + item.Department.Name);
            }
        }

        /**
         * Create the 'TEams' project.
         */
        private void CreateTeamsProject()
        {
            Project teams = new Project("TEams", "Project Management Software", "10/10/2020", "11/10/2020");
            foreach (Employee item in employees)
            {
                if (item.Department.Name == "Engineering")
                {
                    teams.TeamMembers.Add(item);
                }
            }
            projects["TEams"] = teams;
        }

        /**
         * Create the 'Marketing Landing Page' project.
         */
        private void CreateLandingPageProject()
        {
            Project createLandingPage = new Project("Marketing Landing Page", "Lead Capture Landing Page for Marketing", "10/10/2020", "10/17/2020");
            foreach (Employee item in employees)
            {
                if (item.Department.Name == "Marketing")
                {
                    createLandingPage.TeamMembers.Add(item);
                }
            }
            projects["Marketing Landing Page"] = createLandingPage;
        }

        /**
         * Print out each project in the collection.
         */
        private void PrintProjectsReport()
        {
            Console.WriteLine("\n------------- PROJECTS ------------------------------");
            foreach (KeyValuePair<string, Project> kvp in projects)
            {
                Console.WriteLine(kvp.Key + ": " + kvp.Value.TeamMembers.Count);
            }
        }
    }
}
