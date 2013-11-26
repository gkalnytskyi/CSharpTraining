using EmployeeOrganizationChart;
using NUnit.Framework;
using FluentAssertions;

namespace EmployeeOrganizationChartTests
{
    [TestFixture]
    public class EmployeeTests
    {
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

        [Test]
        public void Employee_not_equals_Manager()
        {
            var firstName = "John";
            var lastName = "Smith";
            var employee = new Employee(firstName, lastName);
            var manager = new Manager(firstName, lastName);

            employee.Equals(manager).Should().Be(false);
        }

        [Test]
        public void Employee_not_equals_Top_Manager()
        {
            var firstName = "John";
            var lastName = "Smith";
            var employee = new Employee(firstName, lastName);
            var topManager = new TopManager(firstName, lastName);

            employee.Equals(topManager).Should().Be(false);
        }
    }
}
