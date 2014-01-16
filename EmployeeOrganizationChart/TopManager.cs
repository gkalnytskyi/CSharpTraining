using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;

namespace EmployeeOrganizationChart
{
    class TopManager : Manager
    {
        #region CTOR
        public TopManager(string lastname, string firstname) : base(lastname, firstname) { }
        #endregion

        #region Functions
        public override string ShortStatus()
        {
            return "Top Manager " + base.ShortStatus();
        }
        #endregion
    }
}
