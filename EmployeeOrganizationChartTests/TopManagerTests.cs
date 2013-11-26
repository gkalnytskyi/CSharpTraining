using EmployeeOrganizationChart;
using NUnit.Framework;
using FluentAssertions;

namespace EmployeeOrganizationChartTests
{
    [TestFixture]
    class TopManagerTests
    {
        [TestCase("John", "Dow", "John", "Dow", Result = true)]
        [TestCase("John", "Dow", "John", "Smith", Result = false)]
        public bool Top_Manager_Equals(string firstName1, string lastName1, string firstName2, string lastName2)
        {
            var first = new TopManager(firstName1, lastName1);
            var second = new TopManager(firstName2, lastName2);
            return first.Equals(second);
        }
    }
}
