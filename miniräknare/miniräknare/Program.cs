using System;
using System;

class Program
{
    static double Calculate(double num1, double num2, string operation)
    {
        switch (operation)
        {
            case "+":
                return num1 + num2;
            case "-":
                return num1 - num2;
            case "*":
                return num1 * num2;
            case "/":
                if (num2 != 0)
                    return num1 / num2;
                else
                    throw new DivideByZeroException("Division med noll är inte accepterat.");
            case "^":
                return Math.Pow(num1, num2);
            default:
                throw new ArgumentException("Felaktigt räkne symbol.");
        }
    }

    static void Main()
    {
        double result = 0;

        while (true)
        {
            Console.Write("Skriv ett tal eller räknesätt, för Kvadratroten (Exampel '25 roten') (och 'avsluta' för avsluta): ");
            string input = Console.ReadLine();

            if (input.ToLower() == "avsluta")
                break;

            try
            {
                string[] parts = input.Split(' ');

                if (parts.Length == 2 && (parts[1].ToLower() == "roten" || parts[1].ToLower() == "root"))
                {
                    double number = double.Parse(parts[0]);
                    result = Squareroot.CalculateSquareroot(number);
                }
                else if (parts.Length == 3)
                {
                    double number = double.Parse(parts[0]);
                    double secondNumber = double.Parse(parts[2]);
                    result = Calculate(number, secondNumber, parts[1]);
                }
                else
                {
                    Console.WriteLine("Felaktigt inmatning.");
                    continue;
                }

                Console.WriteLine($"Resultat: {result}");
                Console.WriteLine($"{input} = {result}");

                SaveToFile.AppendToFile(input, result);

                // Låt användaren bygga vidare
                while (true)
                {
                    Console.Write("Skriv in ett räknesätt för att bygga vidare (Eller 'klar' om du inte vill bygga vidare): ");
                    string continueInput = Console.ReadLine();

                    if (continueInput.ToLower() == "klar")
                        break;

                    try
                    {
                        string[] continueParts = continueInput.Split(' ');

                        if (continueParts.Length == 2)
                        {
                            double secondNumber = double.Parse(continueParts[1]);
                            result = Calculate(result, secondNumber, continueParts[0]);
                        }
                        else
                        {
                            Console.WriteLine("Felaktigt inmatning.");
                            continue;
                        }

                        Console.WriteLine($"Resulat: {result}");
                        Console.WriteLine($"{continueInput} = {result}");

                        SaveToFile.AppendToFile(continueInput, result);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"Error: {e.Message}");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
        }
    }
}

