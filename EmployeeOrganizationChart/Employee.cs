using System;
using System.Runtime.CompilerServices;

namespace EmployeeOrganizationChart
{
    class Employee : IEquatable<Employee>
    {
        #region Fields and Properties

        public Employee Manager { get; set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string FullName { get { return LastName + ", " + FirstName; } }
        
        #endregion

        #region Ctor
        protected Employee(string lastname, string firstname)
        {
            if (string.IsNullOrWhiteSpace(lastname))
            {
                throw new ArgumentException("Lastname cannot be null or empty");
            }

            if (string.IsNullOrWhiteSpace(firstname))
            {
                throw new ArgumentException("Firstname cannot be null or empty");
            }

            LastName = lastname;
            FirstName = firstname;
        }

        public Employee(string lastname, string firstname, Manager manager) : this(lastname, firstname)
        {
            Manager = manager;
        }
        #endregion

        #region Functions

        public bool Equals(Employee other)
        {
            if (other == null)
            {
                return false;
            }

            return this.LastName.Equals(other.LastName);
        }

        // override of object.Equals
        public override bool Equals (object obj)
        {
            if (obj == null) 
            {
                return false;
            }

            Employee employeeObj = obj as Employee;
            if (employeeObj == null)
            {
                return false;
            }

            return Equals (employeeObj); 
        }
    
        public static bool operator ==(Employee left, Employee right)
        {
            if ((object)left == null || (object)right == null)
                return Object.Equals(left,right);

            return left.Equals(right);
        }
        
        public static bool operator !=(Employee left, Employee right)
        {
            if ((object)left == null || (object)right == null)
                return !Object.Equals(left,right);

            return !left.Equals(right);
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            return LastName.GetHashCode();
        }

        public virtual string ShortStatus()
        {
            return FullName + ": employee";
        }

        public virtual string Status()
        {
            return ShortStatus();
        }

        public virtual void PrintStatus()
        {
            Console.WriteLine(Status());
        }
        #endregion
    }
}
