using System;
using WiredBrainCoffee_StorageApp.Data;
using WiredBrainCoffee_StorageApp.Entities;
using WiredBrainCoffee_StorageApp.Repositories;

namespace WiredBrainCoffee_StorageApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var employeeRepository = new SqlRepository<Employee>(new StorageAppDbContext());
            AddEmployees(employeeRepository);
            GetEmployeeById(employeeRepository);

            var organizationRepository = new ListRepository<Organization>();
            AddOrganizations(organizationRepository);

            Console.ReadLine();
        }

        private static void GetEmployeeById(IRepository<Employee> employeeRepository)
        {
            var employee = employeeRepository.GetById(2);
            Console.WriteLine($"employee with id 2: {employee.FirstName}");
        }

        private static void AddOrganizations(IRepository<Organization> organizationRepository)
        {
            organizationRepository.Add(new Organization { Name = "CodeLabs" });
            organizationRepository.Add(new Organization { Name = "Pluralsight" });
            organizationRepository.Save();
        }

        private static void AddEmployees(IRepository<Employee> employeeRepository)
        {
            employeeRepository.Add(new Employee { FirstName = "Suyatna" });
            employeeRepository.Add(new Employee { FirstName = "Light" });
            employeeRepository.Add(new Employee { FirstName = "Tiara" });
            employeeRepository.Save();
        }
    }
}
