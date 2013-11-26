using EmployeeOrganizationChart;
using NUnit.Framework;
using FluentAssertions;

namespace EmployeeOrganizationChartTests
{
    [TestFixture]
    public class MangerTests
    {
        [TestCase("John", "Dow", "John", "Dow", Result=true)]
        [TestCase("John", "Dow", "John", "Smith", Result = false)]
        public bool Manager_Equals_Tests(string firstName1, string lastName1, string firstName2, string lastName2)
        {
            // Arrange
            var first = new Manager(firstName1, lastName1);
            var second = new Manager(firstName2, lastName2);
            // Act
            return first.Equals(second);
        }

        [Test]
        public void Manager_and_Top_Manager_are_not_equal()
        {
            // Arrange
            var firstName = "John";
            var lastName = "Smith";
            var manager = new Manager(firstName, lastName);
            var topManager = new TopManager(firstName, lastName);

            // Act & Assert
            manager.Equals(topManager).Should().Be(false);
        }

        [Test]
        public void Manager_and_Employee_are_not_equal()
        {
            // Arrange
            var firstName = "John";
            var lastName = "Smith";
            var manager = new Manager(firstName, lastName);
            var employee = new Employee(firstName, lastName);

            // Act & Assert
            manager.Equals(employee).Should().Be(false);
        }

        [Test]
        public void Status_Test()
        {
            // Arrange
            var manager = new Manager("John", "Smith");

            // Act & Assert
            manager.Status().Should().Be("Smith, John: Manager");
        }
    }
}
