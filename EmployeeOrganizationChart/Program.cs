using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeOrganizationChart
{
    class Program
    {
        static void Main(string[] args)
        {
            var orgChart = new OrganizationChart();

            orgChart.AddEmployee("Smith", "John", EmployeePosition.TopManager, null);
            orgChart.AddEmployee("Gibbs", "Oliver", EmployeePosition.Manager, "Smith");
            orgChart.AddEmployee("Rogers", "Susan", EmployeePosition.Manager, "Smith");
            orgChart.AddEmployee("Wright", "Nicky", EmployeePosition.Employee, "Gibbs");
            orgChart.AddEmployee("Howard", "Jack", EmployeePosition.Employee, "Gibbs");
            orgChart.AddEmployee("Hall", "Lily", EmployeePosition.Employee, "Rogers");

            Console.WriteLine("Listing all employees");
            orgChart.ListAllEmployees();
            Console.WriteLine();
            
            Console.WriteLine("Find Employee");
            orgChart.FindEmployee("h");
            Console.WriteLine();

            Console.WriteLine("Deleting Employee Howard");
            orgChart.DeleteEmployee("Howard");
            Console.WriteLine("Listing all employees");
            orgChart.ListAllEmployees();
            
            Console.ReadLine();
        }
    }
}
