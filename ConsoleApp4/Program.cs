using System;
using System.Linq;
using System.Collections.Generic;

namespace ConsoleApp4
{
    public class Program
    {
        IList<Employee> employeeList;
        IList<Salary> salaryList;

        public Program()
        {
            employeeList = new List<Employee>() {
            new Employee(){ EmployeeID = 1, EmployeeFirstName = "Rajiv", EmployeeLastName = "Desai", Age = 49},
            new Employee(){ EmployeeID = 2, EmployeeFirstName = "Karan", EmployeeLastName = "Patel", Age = 32},
            new Employee(){ EmployeeID = 3, EmployeeFirstName = "Sujit", EmployeeLastName = "Dixit", Age = 28},
            new Employee(){ EmployeeID = 4, EmployeeFirstName = "Mahendra", EmployeeLastName = "Suri", Age = 26},
            new Employee(){ EmployeeID = 5, EmployeeFirstName = "Divya", EmployeeLastName = "Das", Age = 20},
            new Employee(){ EmployeeID = 6, EmployeeFirstName = "Ridhi", EmployeeLastName = "Shah", Age = 60},
            new Employee(){ EmployeeID = 7, EmployeeFirstName = "Dimple", EmployeeLastName = "Bhatt", Age = 53}
        };

            salaryList = new List<Salary>() {
            new Salary(){ EmployeeID = 1, Amount = 1000, Type = SalaryType.Monthly},
            new Salary(){ EmployeeID = 1, Amount = 500, Type = SalaryType.Performance},
            new Salary(){ EmployeeID = 1, Amount = 100, Type = SalaryType.Bonus},
            new Salary(){ EmployeeID = 2, Amount = 3000, Type = SalaryType.Monthly},
            new Salary(){ EmployeeID = 2, Amount = 1000, Type = SalaryType.Bonus},
            new Salary(){ EmployeeID = 3, Amount = 1500, Type = SalaryType.Monthly},
            new Salary(){ EmployeeID = 4, Amount = 2100, Type = SalaryType.Monthly},
            new Salary(){ EmployeeID = 5, Amount = 2800, Type = SalaryType.Monthly},
            new Salary(){ EmployeeID = 5, Amount = 600, Type = SalaryType.Performance},
            new Salary(){ EmployeeID = 5, Amount = 500, Type = SalaryType.Bonus},
            new Salary(){ EmployeeID = 6, Amount = 3000, Type = SalaryType.Monthly},
            new Salary(){ EmployeeID = 6, Amount = 400, Type = SalaryType.Performance},
            new Salary(){ EmployeeID = 7, Amount = 4700, Type = SalaryType.Monthly}
        };
        }

        public static void Main()
        {
            Program program = new Program();

            program.Task1();

            program.Task2();

            program.Task3();
        }

        public void Task1()
        {
            var totalSalaries = employeeList.Select(e => new
            {
                Name = $"{e.EmployeeFirstName} {e.EmployeeLastName}",
                TotalSalary = salaryList.Where(s => s.EmployeeID == e.EmployeeID).Sum(s => s.Amount)
            })
            .OrderBy(s => s.TotalSalary);

            Console.WriteLine("Total Salaries of Employees:");
            foreach (var entry in totalSalaries)
            {
                Console.WriteLine($"{entry.Name}: {entry.TotalSalary}");
            }
            Console.WriteLine();
        }

        public void Task2()
        {
            var secondOldestEmployee = employeeList.OrderByDescending(e => e.Age).Skip(1).First();
            var monthlySalary = salaryList.Where(s => s.EmployeeID == secondOldestEmployee.EmployeeID && s.Type == SalaryType.Monthly).Sum(s => s.Amount);
            Console.WriteLine($"Details of the Second Oldest Employee:");
            Console.WriteLine($"Name: {secondOldestEmployee.EmployeeFirstName} {secondOldestEmployee.EmployeeLastName}");
            Console.WriteLine($"Age: {secondOldestEmployee.Age}");
            Console.WriteLine($"Total Monthly Salary: {monthlySalary}");
            Console.WriteLine();
        }

        public void Task3()
        {
            var employeesAbove30 = employeeList.Where(e => e.Age > 30).Select(e => e.EmployeeID);

            var monthlyMean = salaryList.Where(s => employeesAbove30.Contains(s.EmployeeID) && s.Type == SalaryType.Monthly).Average(s => s.Amount);
            var performanceMean = salaryList.Where(s => employeesAbove30.Contains(s.EmployeeID) && s.Type == SalaryType.Performance).Average(s => s.Amount);
            var bonusMean = salaryList.Where(s => employeesAbove30.Contains(s.EmployeeID) && s.Type == SalaryType.Bonus).Average(s => s.Amount);

            Console.WriteLine("Means of Monthly, Performance, and Bonus Salaries for Employees above 30:");
            Console.WriteLine($"Monthly Mean: {monthlyMean}");
            Console.WriteLine($"Performance Mean: {performanceMean}");
            Console.WriteLine($"Bonus Mean: {bonusMean}");
        }
    }

    public enum SalaryType
    {
        Monthly,
        Performance,
        Bonus
    }

    public class Employee
    {
        public int EmployeeID { get; set; }
        public string EmployeeFirstName { get; set; }
        public string EmployeeLastName { get; set; }
        public int Age { get; set; }
    }

    public class Salary
    {
        public int EmployeeID { get; set; }
        public int Amount { get; set; }
        public SalaryType Type { get; set; }
    }


}
