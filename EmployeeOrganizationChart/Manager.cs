using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("EmployeeOrganizationChartTests")]
namespace EmployeeOrganizationChart
{
    class Manager : Employee, IEquatable<Manager>
    {
        #region Fields and Properties

        protected HashSet<Employee> _Subordinates;

        #endregion

        #region Ctor
        public Manager(string firstName, string lastName)
            : base(firstName, lastName)
        {
            _Subordinates = new HashSet<Employee>();
        }

        #endregion

        #region Methods

        public Manager AddSubordinate(Employee emp)
        {
            _Subordinates.Add(emp);
            return this;
        }

        public Manager RemoveSubordinate(Employee emp)
        {
            _Subordinates.Remove(emp);

            return this;
        }

        public string[] ListSubordinates()
        {
            return _Subordinates.Select(s => s.ToString()).ToArray();
        }

        public override string Status()
        {
            var sb = new StringBuilder();
            sb.AppendLine(ToString());
            sb.AppendLine("Suboridinates:");
            foreach (var employee in _Subordinates)
            {
                sb.AppendLine("\t" + employee.ToString());
            }

            return sb.ToString();
        }
        #endregion

        #region Overriden and Interface Methods

        public override string ToString()
        {
            return FullName + ": Manager";
        }

        public bool Equals(Manager other)
        {
            if (other == null)
                return false;

            if (Object.ReferenceEquals(this, other))
                return true;

            if (this.GetHashCode() != other.GetHashCode())
                return false;

            if (base.Equals(other) && this._Subordinates.SetEquals(other._Subordinates))
                return true;

            return false;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            Manager objManager = obj as Manager;
            if (objManager == null)
                return false;

            return Equals(objManager);
        }

        public override int GetHashCode()
        {
            var hash = base.GetHashCode();
            foreach (var employee in _Subordinates)
            {
                hash = hash ^ employee.GetHashCode();
            }
            return hash;
        }
        #endregion
    }
}
