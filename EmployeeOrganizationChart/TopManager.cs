using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("EmployeeOrganizationChartTests")]
namespace EmployeeOrganizationChart
{
    class TopManager : Manager, IEquatable<TopManager>
    {
        #region Ctor

        public TopManager(string firstName, string lastName) : base(firstName, lastName) { }
        
        #endregion

        #region Methods

        public override string Status()
        {
            return new StringBuilder().AppendLine("Top Manager").Append(base.Status()).ToString();
        }

        #endregion

        #region Overriden and Interface Methods

        public override string ToString()
        {
            return FullName + ": Top Manager" ;
        }

        public bool Equals(TopManager other)
        {
            return Equals((Manager)other);
        }

        public override bool Equals(Object obj)
        {
            if (obj == null)
                return false;

            TopManager objTopManager = obj as TopManager;
            if (objTopManager == null)
                return false;
            else
                return Equals(objTopManager);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        #endregion
    }
}
