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

        protected List<Employee> _Subordinates;

        #endregion

        #region Ctor

        static Manager()
        {
            Position = EmployeePosition.Manager;
        }

        public Manager(string firstName, string lastName)
            : base(firstName, lastName)
        {
            _Subordinates = new List<Employee>();
        }

        #endregion

        #region Methods

        public Manager AddSubordinate(Employee emp)
        {
            if (_Subordinates.Contains(emp))
            {
                throw new ArgumentException("Manager already manages this subordinate");
            }
            _Subordinates.Add(emp);
            return this;
        }

        public Manager RemoveSubordinate(Employee emp)
        {
            if (_Subordinates.Contains(emp))
            {
                _Subordinates.Remove(emp);
            }

            return this;
        }

        public string[] ListSubordinates()
        {
            return _Subordinates.Select(s => s.ToString()).ToArray();
        }

        public override string Status()
        {
            var sb = new StringBuilder();
            sb.AppendLine(base.Status());
            sb.AppendLine("Suboridinates:");
            foreach (var employee in _Subordinates)
            {
                sb.AppendLine("\t" + employee.ToString());
            }

            return sb.ToString();
        }
        #endregion

        #region Overriden and Interface Methods
        public bool Equals(Manager other)
        {
            if (other == null)
                return false;

            if (Object.ReferenceEquals(this, other))
                return true;

            if (this.GetHashCode() != other.GetHashCode())
                return false;

            if (base.Equals(other) &&
                Enumerable.SequenceEqual(this._Subordinates, other._Subordinates))
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
