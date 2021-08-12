using System;
using WiredBrainCoffee_StorageApp.Entities;
using WiredBrainCoffee_StorageApp.Repositories;

namespace WiredBrainCoffee_StorageApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var employeeRepository = new GenericRepository<Employee>();
            AddEmployees(employeeRepository);
            GetEmployeeById(employeeRepository);

            var organizationRepository = new GenericRepository<Organization>();
            AddOrganizations(organizationRepository);

            Console.ReadLine();
        }

        private static void GetEmployeeById(GenericRepository<Employee> employeeRepository)
        {
            var employee = employeeRepository.GetById(2);
            Console.WriteLine($"employee with id 2: {employee.FirstName}");
        }

        private static void AddOrganizations(GenericRepository<Organization> organizationRepository)
        {
            organizationRepository.Add(new Organization { Name = "CodeLabs" });
            organizationRepository.Add(new Organization { Name = "Pluralsight" });
            organizationRepository.Save();
        }

        private static void AddEmployees(GenericRepository<Employee> employeeRepository)
        {
            employeeRepository.Add(new Employee { FirstName = "Suyatna" });
            employeeRepository.Add(new Employee { FirstName = "Light" });
            employeeRepository.Add(new Employee { FirstName = "Tiara" });
            employeeRepository.Save();
        }
    }
}
