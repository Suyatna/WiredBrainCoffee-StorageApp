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

            employeeRepository.ItemAdded += EmployeeRepository_ItemAdded;

            AddEmployees(employeeRepository);
            AddManagers(employeeRepository);
            WriteAllToConsole(employeeRepository);
            GetEmployeeById(employeeRepository);

            var organizationRepository = new ListRepository<Organization>();
            AddOrganizations(organizationRepository);
            WriteAllToConsole(organizationRepository);

            Console.ReadLine();
        }

        private static void EmployeeRepository_ItemAdded(object? sender, Employee e)
        {                    
            Console.WriteLine($"Employee added => {e.FirstName}");
        }

        private static void AddManagers(IWriteRepository<Manager> managerRepository)
        {
            var saraManager = new Manager { FirstName = "Sara" };
            var saraManagerCopy = saraManager.Copy();
            managerRepository.Add(saraManager);

            if (saraManagerCopy is not null)
            {
                saraManagerCopy.FirstName += "_Copy";
                managerRepository.Add(saraManagerCopy);
            }

            managerRepository.Add(new Manager { FirstName = "Henry" });
            managerRepository.Save();
        }

        private static void WriteAllToConsole(IReadRepository<IEntity> repository)
        {
            var items = repository.GetAll();
            foreach (var item in items)
            {
                Console.WriteLine(item);
            }
        }

        private static void GetEmployeeById(IRepository<Employee> employeeRepository)
        {
            var employee = employeeRepository.GetById(2);
            Console.WriteLine($"employee with id 2: {employee.FirstName}");
        }        

        private static void AddEmployees(IRepository<Employee> employeeRepository)
        {
            var employees = new[]
            {
                new Employee { FirstName = "Windy" },
                new Employee { FirstName = "Suyatna" },
                new Employee { FirstName = "Tiara" }
            };

            AddBatch(employeeRepository, employees);
        }

        private static void AddOrganizations(IRepository<Organization> organizationRepository)
        {
            var organizations = new[]
            {
                new Organization { Name = "Pluralsight" },
                new Organization { Name = "Globomantics" }
            };

            AddBatch(organizationRepository, organizations);                       
        }

        private static void AddBatch<T>(IWriteRepository<T> repository, T[] items)
        {
            foreach (var item in items)
            {
                repository.Add(item);
            }

            repository.Save();
        }
    }
}
