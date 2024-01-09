using System.Globalization;
using Course.Entities.Enums;
using Course.Entities;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.Write("Enter department's name: ");
        string dept = Console.ReadLine();
        Console.WriteLine("Enter the worker data: ");
        Console.Write("Name: ");
        string name = Console.ReadLine();
        Console.Write("Level (Junior/MidLevel/Senior): ");
        WorkLevel level = Enum.Parse<WorkLevel>(Console.ReadLine());
        Console.Write("Base salary: ");
        double baseSalary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

        Department department = new Department(dept);
        Worker worker = new Worker(name, level, baseSalary, department);
        Console.WriteLine();
        Console.Write("How many contracts to this worker? ");
        int n = int.Parse(Console.ReadLine());

        for (int i = 1; i <= n; i++)
        {
            Console.WriteLine($"Enter #{i} contract data:");
            Console.Write("Date (DD/MM/YYYY): ");
            DateTime date = DateTime.Parse(Console.ReadLine());
            Console.Write("Value per hour: ");
            double value = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.Write("Duration (hours): ");
            int hours = int.Parse(Console.ReadLine());
            HourContract contract = new HourContract(date, value, hours);
            worker.AddContract(contract);
        }

        Console.WriteLine();
        Console.Write("Enter month and year to calculate income (MM/YYYY): ");
        string yearAndMonth = Console.ReadLine();
        int month = int.Parse(yearAndMonth.Substring(0, 2));
        int year = int.Parse(yearAndMonth.Substring(3));

        Console.WriteLine("Name: " + worker.Name);
        Console.WriteLine("Department: " + worker.Department.Name);
        Console.WriteLine("Income for: " + yearAndMonth + ": " + worker.Income(year, month));   





    }
}