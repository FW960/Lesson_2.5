using System;

namespace Lesson_2._5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string UserChoice = string.Empty;

            do
            {
                UserChoice = Console.ReadLine();

                switch (UserChoice)
                {
                    case "Сложить":
                        try
                        {
                            string[] AllNums = Converter();

                            ComplexNum result = (new ComplexNum(Convert.ToDouble(AllNums[0]), Convert.ToDouble(AllNums[1])) + new ComplexNum(Convert.ToDouble(AllNums[2]), Convert.ToDouble(AllNums[3])));

                            Console.WriteLine($"Результат: {result.ToString()}");
                        }
                        catch
                        {
                            Console.WriteLine("Введите параметры комплексного числа в корректном формате.");
                        }
                        break;
                    case "Вычесть":
                        try
                        {
                            string[] AllNums = Converter();

                            ComplexNum result = (new ComplexNum(Convert.ToDouble(AllNums[0]), Convert.ToDouble(AllNums[1])) - new ComplexNum(Convert.ToDouble(AllNums[2]), Convert.ToDouble(AllNums[3])));

                            Console.WriteLine($"Результат: {result.ToString()}");
                        }
                        catch
                        {
                            Console.WriteLine("Введите параметры комплексного числа в корректном формате.");
                        }
                        break;
                    case "Умножить":
                        try
                        {
                            string[] AllNums = Converter();

                            ComplexNum result = (new ComplexNum(Convert.ToDouble(AllNums[0]), Convert.ToDouble(AllNums[1])) * new ComplexNum(Convert.ToDouble(AllNums[2]), Convert.ToDouble(AllNums[3])));

                            Console.WriteLine($"Результат: {result.ToString()}");
                        }
                        catch
                        {
                            Console.WriteLine("Введите параметры комплексного числа в корректном формате.");
                        }
                        break;
                    case "Сравнить":
                        try
                        {
                            string[] AllNums = Converter();

                            bool result = (new ComplexNum(Convert.ToDouble(AllNums[0]), Convert.ToDouble(AllNums[1])) == new ComplexNum(Convert.ToDouble(AllNums[2]), Convert.ToDouble(AllNums[3])));

                            Console.WriteLine($"Результат: {result}");
                        }
                        catch
                        {
                            Console.WriteLine("Введите параметры комплексного числа в корректном формате.");
                        }
                        break;
                    default:
                        break;
                }
            } while (!(UserChoice == "Выход"));
            

        }
        public static string[] Converter()
        {
            string[] AllNums = new string[4];

            Console.WriteLine("Введите реальное и мнимое число первого комплексного числа через пробел.");

            string[] FirstComplexNumParams = Console.ReadLine().Split(' ');

            Console.WriteLine("Введите реальное и мнимое число второго комплексного числа через пробел.");

            string[] SecondComplexNumParams = Console.ReadLine().Split(' ');

            AllNums[0] = FirstComplexNumParams[0];

            AllNums[1] = FirstComplexNumParams[1];

            AllNums[2] = SecondComplexNumParams[0];

            AllNums[3] = SecondComplexNumParams[1];

            return AllNums;
        }
    }
    public class ComplexNum
    {
        public double RealNum { get; set; }
        public double ImagNum { get; set; }

        public ComplexNum(double R, double I)
        {

            this.RealNum = R;

            this.ImagNum = I;
        }

        public static ComplexNum operator +(ComplexNum first, ComplexNum second)
        {
            return new ComplexNum(first.RealNum + second.RealNum, first.ImagNum + second.ImagNum);
        }
        public static ComplexNum operator -(ComplexNum first, ComplexNum second)
        {
            return new ComplexNum(first.RealNum - second.RealNum, first.ImagNum - second.ImagNum);
        }
        public static bool operator ==(ComplexNum first, ComplexNum second)
        {
            return (first.RealNum == second.RealNum) && (first.ImagNum == second.ImagNum);
        }
        public static bool operator !=(ComplexNum first, ComplexNum second)
        {
            return (first.RealNum != second.RealNum) || (first.ImagNum != second.ImagNum);
        }
        public static ComplexNum operator *(ComplexNum first, ComplexNum second)
        {
            double a = first.RealNum * second.RealNum;

            double b = first.RealNum * second.ImagNum;

            double c = first.ImagNum * second.RealNum;

            double d = (first.ImagNum * second.ImagNum) * -1; // Возвел произведение мнимых чисел в квадрат, то есть согласно правилам умножил на -1.

            return new ComplexNum(a + d, b + c);
        }
        public string ToString()
        {
            return $"z = {this.RealNum} + {this.ImagNum}i";
        }

    }
}
