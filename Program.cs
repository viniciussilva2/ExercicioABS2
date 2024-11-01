using ExercicioABS2.Entities;
using System;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        List<TaxPayer> list = new List<TaxPayer>(); 
        Console.WriteLine("Enter the number of tax payers: ");
        int p = int.Parse(Console.ReadLine());

        for(int i = 1; i <= p; i++)
        {

            Console.Write($"Tax payer #{i} data: ");
            Console.Write("Individual or company (i/c)? ");
            char cmp = char.Parse(Console.ReadLine());

            while(cmp != 'c' && cmp != 'i')
            {
                Console.Write("Error: ");
                Console.Write("Individual or company (i/c)? ");
                cmp = char.Parse(Console.ReadLine());
            }

            if(cmp == 'c')
            {
                Console.Write("Name: ");
                string name = Console.ReadLine();

                Console.Write("Anual Income: ");
                double anualLncome = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                Console.Write("Number of Employees: ");
                int numberOfEmployess = int.Parse(Console.ReadLine());

                list.Add(new Company(numberOfEmployess, name, anualLncome));
            } else if(cmp == 'i')
            {
                Console.Write("Name: ");
                string name = Console.ReadLine();

                Console.Write("Anual Income: ");
                double anualLncome = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                Console.Write("Health Expenditures: ");
                double healthExpenditures = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                list.Add(new Individual(healthExpenditures, name, anualLncome));
            }
        }

        double sum = 0.0;
        Console.WriteLine();
        Console.WriteLine("TAXES PAID:");
        foreach (TaxPayer tp in list)
        {
            double tax = tp.Tax();
            Console.WriteLine(tp.Name + ": $ " + tax.ToString("F2", CultureInfo.InvariantCulture));
            sum += tax;
        }

        Console.WriteLine();
        Console.WriteLine("TOTAL TAXES: $ " + sum.ToString("F2", CultureInfo.InvariantCulture));
    }
}
