using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("EmployeeOrganizationChartTests")]
namespace EmployeeOrganizationChart
{
    class Employee : IEquatable<Employee>
    {
        #region Fields and Properties

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string FullName { get { return LastName + ", " + FirstName; } }
        
        #endregion

        #region Ctor

        public Employee(string firstName, string lastName)
        {
            if (string.IsNullOrWhiteSpace(lastName))
            {
                throw new ArgumentException("Last name could not be empty or whitespace");
            }
            FirstName = firstName;
            LastName = lastName;
        }

        #endregion

        #region Methods

        public virtual string Status()
        {
            return ToString();
        }

        #endregion

        #region Overriden and Interface methods
        
        public override string ToString()
        {
            return FullName + ": Employee";
        }
        
        public bool Equals(Employee other)
        {
            if (other == null)
            {
                return false;
            }

            if (object.ReferenceEquals(this, other))
                return true;

            if (this.GetHashCode() != other.GetHashCode())
                return false;

            if (this.LastName == other.LastName &&
                this.FirstName == other.FirstName &&
                this.GetType().Equals(other.GetType()))
                return true;

            return false;
        }

        public override bool Equals(object obj)
        {
 	        if (obj == null)
                return false;

            Employee empObj = obj as Employee;
            if (empObj == null)
                return false;
            else
                return Equals(empObj);                       
        }

        public override int GetHashCode()
        {
 	         return (LastName+FirstName).ToUpper().GetHashCode();
        }

        #endregion
    }
}
