using System;
using WiredBrainCoffee_StorageApp.Entities;
using WiredBrainCoffee_StorageApp.Repositories;

namespace WiredBrainCoffee_StorageApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var employeeRepository = new EmployeeRepository();

            employeeRepository.Add(new Employee { FirstName = "Suyatna" });
            employeeRepository.Add(new Employee { FirstName = "Light" });
            employeeRepository.Add(new Employee { FirstName = "Tiara" });

            employeeRepository.Save();

            Console.ReadLine();
        }
    }
}
