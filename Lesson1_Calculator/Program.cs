using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Lesson1_Calculator
{

    class Calculator
    {

        public double number1, number2;
        public double Add(double value1,double value2)
        {
             return value1 + value2; 
        }

        public double Subtract(double value1, double value2)
        {
            return value1 - value2;
        }

        public double Multiply(double value1, double value2)
        {
            return value1 * value2;
        }
        public double Divide(double value1, double value2)
        {
            if (value2 == 0)
            {
                Console.WriteLine("Помилка: ділення на нуль!");
                return double.NaN; 
            }
            return value1 / value2;
        }

        public double Power(double value1, double value2)
        {
            return Math.Pow(value1, value2);
        }

        public double SquareRoot(double value1)
        {
            if (value1 < 0)
            {
                Console.WriteLine("Помилка: неможливо взяти корінь з від’ємного числа.");
                return double.NaN;
            }
            return Math.Sqrt(value1);
        }
    }
    internal class Program
    {
        static void Main()
        {
            Calculator calc = new Calculator();
            Console.OutputEncoding = Encoding.UTF8;

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Введіть перше число:");
                if (!double.TryParse(Console.ReadLine(), out calc.number1))
                {
                    Console.WriteLine("Помилка: некоректне число.");
                    Console.ReadKey();
                    continue;
                }

                Console.WriteLine("\nОберіть оператор:");
                Console.WriteLine("+   - Додавання");
                Console.WriteLine("-   - Віднімання");
                Console.WriteLine("*   - Множення");
                Console.WriteLine("/   - Ділення");
                Console.WriteLine("^   - Степінь");
                Console.WriteLine("sqrt - Корінь");

                Console.Write("\nВведіть оператор: ");
                string oper = Console.ReadLine();

                if (oper != "sqrt") 
                {
                    Console.WriteLine("\nВведіть друге число:");
                    if (!double.TryParse(Console.ReadLine(), out calc.number2))
                    {
                        Console.WriteLine("Помилка: некоректне число.");
                        Console.ReadKey();
                        continue;
                    }
                }

                double result = 0;
                bool validOperation = true;

                switch (oper)
                {
                    case "+":
                        result = calc.Add(calc.number1, calc.number2);
                        break;
                    case "-":
                        result = calc.Subtract(calc.number1, calc.number2);
                        break;
                    case "*":
                        result = calc.Multiply(calc.number1, calc.number2);
                        break;
                    case "/":
                        result = calc.Divide(calc.number1, calc.number2);
                        if (double.IsNaN(result))
                        {
                            validOperation = false;
                        }
                        break;
                    case "^":
                        result = calc.Power(calc.number1, calc.number2);
                        break;
                    case "sqrt":
                        result = calc.SquareRoot(calc.number1);
                        if (double.IsNaN(result))
                        {
                            validOperation = false;
                        }
                        break;
                    default:
                        Console.WriteLine("Помилка: невірний оператор.");
                        validOperation = false;
                        break;
                }

                if (validOperation)
                {
                    Console.WriteLine($"\nРезультат: {result}");
                }

                Console.WriteLine("\nНатисніть будь-яку клавішу для продовження або Esc для виходу.");
                if (Console.ReadKey().Key == ConsoleKey.Escape)
                    break;
            }
        }
    }
}
