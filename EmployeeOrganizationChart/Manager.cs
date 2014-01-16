using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;

namespace EmployeeOrganizationChart
{
    class Manager : Employee
    {
        public delegate IEnumerable<Employee> GetSubordinateEmployees(Manager manager);
        
        #region CTOR
        public Manager(string lastname, string firstname, Manager manager) : base(lastname, firstname, manager) { }

        protected Manager(string lastname, string firstname) : base(lastname, firstname) { }
        #endregion

        #region Functions
        public override string ShortStatus()
        {
            return FullName + ": manager";
        }

        public IEnumerable<Employee> DirectSubordinates(GetSubordinateEmployees getSubordinates)
        {
            return getSubordinates(this);
        }

        public string Status(GetSubordinateEmployees getSubordinates)
        {
            var sb = new StringBuilder(Status());
            sb.AppendLine();
            var subordinates = getSubordinates(this).OrderBy(emp => emp.LastName);
            foreach (var emp in subordinates)
            {
                sb.Append('\t').AppendLine(emp.ShortStatus());
            }

            return sb.ToString();
        }
        #endregion
    }
}
