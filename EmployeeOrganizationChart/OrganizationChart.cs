using System;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeOrganizationChart
{
    public enum EmployeePosition
    {
        Employee = 0,
        Manager,
        TopManager
    }
    
    public class OrganizationChart
    {
        private List<Employee> _Employees = new List<Employee>();

        public void ListAllEmployees()
        {
            Console.WriteLine("Employee list");
            foreach (var emp in _Employees.OrderBy(emp => emp.LastName))
            {
                Console.WriteLine(emp.ShortStatus());
            }
        }

        public void AddEmployee(string lastname, string firstname, EmployeePosition position, string managerLastName)
        {
            if (string.IsNullOrWhiteSpace(lastname))
                throw new ArgumentException("Last name cannot be null or whitespace");

            if (string.IsNullOrWhiteSpace(firstname))
                throw new ArgumentException("First name cannot be null or whitespace");

            var employee = _Employees.FirstOrDefault(e => e.LastName == lastname);

            if (employee != default(Employee))
                throw new ArgumentException("This employee was already added to Org. Chart");

            if (position != EmployeePosition.TopManager && string.IsNullOrWhiteSpace(managerLastName))
                throw new ArgumentException("Managers last name cannot be null or whitespace, for mere employees or managers");

            var manager = (_Employees.FirstOrDefault(e => e.LastName == managerLastName)) as Manager;

            if (manager == default(Manager) && position != EmployeePosition.TopManager)
                throw new ArgumentException("The manager with provided last name is not listed in Org. Chart");

            switch (position)
            {
                case EmployeePosition.TopManager:
                    _Employees.Add(new TopManager(lastname, firstname));
                    break;
                case EmployeePosition.Manager:
                    _Employees.Add(new Manager(lastname, firstname, manager));
                    break;
                case EmployeePosition.Employee:
                    _Employees.Add(new Employee(lastname, firstname, manager));
                    break;
                default:
                    throw new ArgumentException("Check position argument");
            }
        }

        public void FindEmployee(string namePart)
        {
            var employees = _Employees.Where(e => e.FullName.ToUpper().Contains(namePart.ToUpper()));
            foreach (var emp in employees)
            {
                Console.WriteLine(emp.ShortStatus());
            }
        }

        public void DeleteEmployee(string lastname)
        {
            var employee = ExistingEmployee(lastname);
            var manager = employee as Manager;
            if (manager != null)
            {
                var directSubordinates = DirectSubordinatesOf(manager);
                foreach (var subordinate in directSubordinates)
                {
                    subordinate.Manager = employee.Manager;
                }
            }
            _Employees.Remove(employee);
        }

        public void DisplayStatus(string employeeLastname)
        {
            var employee = ExistingEmployee(employeeLastname);
            employee.PrintStatus();
        }

        public void ReassignEmployee(string employeeLastname, string newManagerLastname)
        {
            var employee = ExistingEmployee(employeeLastname);
            var manager = _Employees.FirstOrDefault(emp => emp.LastName == newManagerLastname) as Manager;
            if (manager == default(Manager))
            {
                throw new ArgumentException("Manager with provided last name doesn't exist in Org. Chart");
            }

            employee.Manager = manager;
        }

        private Employee ExistingEmployee(string employeeLastname)
        {
            var employee = _Employees.FirstOrDefault(emp => emp.LastName == employeeLastname);
            if (employee == default(Employee))
            {
                throw new ArgumentException("Employee with provided last name doesn't exist in Org. Chart");
            }
            return employee;
        }

        internal IEnumerable<Employee> DirectSubordinatesOf(Manager manager)
        {
            return _Employees.Where(emp => emp.Manager == manager).ToArray();
        }
    }
}
