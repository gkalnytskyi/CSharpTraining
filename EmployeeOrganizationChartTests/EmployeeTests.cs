using EmployeeOrganizationChart;
using NUnit.Framework;
using FluentAssertions;

namespace EmployeeOrganizationChartTests
{
    [TestFixture]
    public class EmployeeTests
    {
        [Test]
        public void Employee_Position()
        {
            Employee.Position.Should().Be(EmployeePosition.Employee);
        }

        [Test]
        public void Employee_Status()
        {
            // Arrange
            var emp = new Employee("John", "Dow");
            
            // Act & Assert
            emp.Status().Should().Be("Dow, John: Employee");
        }

        [Test]
        public void EqualsTest()
        {
            //Arrange
            var emp1 = new Employee("John", "Dow");
            var emp2 = new Employee("John", "Dow");

            // Act & Assert
            emp1.Equals(emp2).Should().Be(true);
        }


    }
}
