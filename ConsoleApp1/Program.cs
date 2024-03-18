using System;

namespace ConsoleApp1
{
    class Employee
    {
        private int Id;
        private string Name;
        private string DepartmentName;

        // Event declaration
        public event EventHandler MethodCalled;

        // Constructor
        public Employee(int id, string name, string departmentName)
        {
            Id = id;
            Name = name;
            DepartmentName = departmentName;
        }

        // Methods to get properties
        public int GetId()
        {
            // Firing the event when method is called
            OnMethodCalled("GetId() method called");
            return Id;
        }

        public string GetName()
        {
            // Firing the event when method is called
            OnMethodCalled("GetName() method called");
            return Name;
        }

        public string GetDepartmentName()
        {
            // Firing the event when method is called
            OnMethodCalled("GetDepartmentName() method called");
            return DepartmentName;
        }

        // Method to raise the event
        protected virtual void OnMethodCalled(string message)
        {
            Console.WriteLine(message);
        }

        // Overloaded methods to update properties
        public void UpdateId(int newId)
        {
            Id = newId;
        }

        public void UpdateName(string newName)
        {
            Name = newName;
        }

        public void UpdateDepartmentName(string newDepartmentName)
        {
            DepartmentName = newDepartmentName;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Employee details:");
            Console.Write("Id: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Name: ");
            string name = Console.ReadLine();

            Console.Write("Department Name: ");
            string departmentName = Console.ReadLine();

            // Creating an object of Employee class
            Employee employee = new Employee(id, name, departmentName);

            // Subscribing to the event
            employee.MethodCalled += (sender, eventArgs) =>
            {
                Console.WriteLine(eventArgs);
            };

            // Printing all three properties
            Console.WriteLine("Employee details:");
            Console.WriteLine($"Id: {employee.GetId()}");
            Console.WriteLine($"Name: {employee.GetName()}");
            Console.WriteLine($"Department Name: {employee.GetDepartmentName()}");

            // Updating properties
            Console.WriteLine("\nEnter new details to update employee:");
            Console.Write("New Id: ");
            int newId = int.Parse(Console.ReadLine());
            employee.UpdateId(newId);

            Console.Write("New Name: ");
            string newName = Console.ReadLine();
            employee.UpdateName(newName);

            Console.Write("New Department Name: ");
            string newDepartmentName = Console.ReadLine();
            employee.UpdateDepartmentName(newDepartmentName);

            // Printing updated properties
            Console.WriteLine("\nEmployee details after update:");
            Console.WriteLine($"Id: {employee.GetId()}");
            Console.WriteLine($"Name: {employee.GetName()}");
            Console.WriteLine($"Department Name: {employee.GetDepartmentName()}");

        }
    }

}
