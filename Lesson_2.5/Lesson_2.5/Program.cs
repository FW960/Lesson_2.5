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

                            RationalNum result = new RationalNum(Convert.ToInt32(AllNums[0]), Convert.ToInt32(AllNums[1])) + new RationalNum(Convert.ToInt32(AllNums[2]), Convert.ToInt32(AllNums[3]));

                            Console.WriteLine($@"Результат: 
{result.ToString()} или {(float)result}");
                        }
                        catch
                        {
                            Console.WriteLine("Введите числитель и знаменатель в корректном формате.");
                        }
                        break;
                    case "Вычесть":
                        try
                        {
                            string[] AllNums = Converter();

                            RationalNum result = new RationalNum(Convert.ToInt32(AllNums[0]), Convert.ToInt32(AllNums[1])) - new RationalNum(Convert.ToInt32(AllNums[2]), Convert.ToInt32(AllNums[3]));

                            Console.WriteLine($@"Результат: 
{result.ToString()} или {(float)result}");
                        }
                        catch
                        {
                            Console.WriteLine("Введите числитель и знаменатель в корректном формате.");
                        }
                        break;
                    case "Умножить":
                        try
                        {
                            string[] AllNums = Converter();

                            RationalNum result = new RationalNum(Convert.ToInt32(AllNums[0]), Convert.ToInt32(AllNums[1])) * new RationalNum(Convert.ToInt32(AllNums[2]), Convert.ToInt32(AllNums[3]));

                            Console.WriteLine($@"Результат: 
{result.ToString()} или {(float)result}");
                        }
                        catch
                        {
                            Console.WriteLine("Введите числитель и знаменатель в корректном формате.");
                        }
                        break;
                    case "Делить":
                        try
                        {
                            string[] AllNums = Converter();

                            RationalNum result = new RationalNum(Convert.ToInt32(AllNums[0]), Convert.ToInt32(AllNums[1])) / new RationalNum(Convert.ToInt32(AllNums[2]), Convert.ToInt32(AllNums[3]));

                            Console.WriteLine($@"Результат: 
                    или {(float)result}
{result.ToString()} ");
                        }
                        catch
                        {
                            Console.WriteLine("Введите числитель и знаменатель в корректном формате.");
                        }
                        break;
                    case "Остаток деления":
                        try
                        {
                            string[] AllNums = Converter();

                            RationalNum result = new RationalNum(Convert.ToInt32(AllNums[0]), Convert.ToInt32(AllNums[1])) % new RationalNum(Convert.ToInt32(AllNums[2]), Convert.ToInt32(AllNums[3]));

                            Console.WriteLine($@"Результат: 
{result.ToString()} или {(float)result}");
                        }
                        catch
                        {
                            Console.WriteLine("Введите числитель и знаменатель в корректном формате.");
                        }
                        break;
                    default:
                        break;

                }



            } while (UserChoice != "Выход.");
        }

        public static string[] Converter()
        {
            string[] Result = new string[4];

            Console.WriteLine("Введить числитель и знаменатель первой дроби.");

            string[] First = (Console.ReadLine()).Split(' ');

            Console.WriteLine("Введите числитель и знаменатель для второй дроби.");

            string[] Second = (Console.ReadLine()).Split(' ');

            Result[0] = First[0];

            Result[1] = First[1];

            Result[2] = Second[0];

            Result[3] = Second[1];

            return Result;
        }
    }
    internal class RationalNum
    {
        public float Numerator;

        public float Denominator;

        public RationalNum(float Numerator, float Denominator) //Логика замены + на - в числителе и знаменателе и если исключение на случай если числитель равен 0.
        {
            int checkCode = 0;

            if (Denominator == 0)
            {
                throw new Exception("Can't set 0 value to denominator.");
            }

            if (Numerator < 0 && Denominator < 0) 
            {
                Numerator = Math.Abs(Numerator);

                Denominator = Math.Abs(Denominator);

                checkCode = 1;
            }
            else if (Denominator < 0 && checkCode == 0)
            {

                Numerator = Numerator * -1;

                checkCode = 1;

            }
            else if (Numerator < 0 && checkCode == 0)
            {

                Denominator = Denominator * -1;

            }

            this.Numerator = Numerator;

            this.Denominator = Denominator;
        }

        public static bool operator ==(RationalNum first, RationalNum second)
        {
            return (first.Equals(second));
        }

        public static bool operator !=(RationalNum first, RationalNum second)
        {
            return (!first.Equals(second));
        }
        /*
         Постарался написать логику сравнения, сложения, вычитания и тд знаменателей как в математике.
         */
        public static bool operator >(RationalNum first, RationalNum second)
        {
            if (first.Denominator > second.Denominator)
            {
                if (second.Denominator < 0 && first.Denominator > 0)
                {
                    return false;
                }
                float difference = first.Denominator / second.Denominator;

                float full = second.Numerator * difference;

                return first.Numerator > full;
            }
            if (second.Denominator > first.Denominator)
            {
                if (first.Denominator < 0 && second.Denominator > 0)
                {
                    return true;
                }
                float difference = second.Denominator / first.Denominator;

                float full = first.Numerator * difference;

                return full > second.Numerator;
            }

            return first.Numerator > second.Numerator;
        }
        public static bool operator <(RationalNum first, RationalNum second)
        {

            if (first.Denominator > second.Denominator)
            {
                if (second.Denominator < 0 && first.Denominator > 0)
                {
                    return false;
                }
                float difference = first.Denominator / second.Denominator;

                float full = second.Numerator * difference;

                return first.Numerator < full;
            }
            if (second.Denominator > first.Denominator)
            {
                if (first.Denominator < 0 && second.Denominator > 0)
                {
                    return true;
                }
                float difference = second.Denominator / first.Denominator;

                float full = first.Numerator * difference;

                return full < second.Numerator;
            }

            return first.Numerator < second.Numerator;
        }

        public static bool operator >=(RationalNum first, RationalNum second)
        {
            if (first.Denominator > second.Denominator)
            {
                if (second.Denominator < 0 && first.Denominator > 0)
                {
                    return false;
                }
                float difference = first.Denominator / second.Denominator;

                float full = second.Numerator * difference;

                return first.Numerator >= full;
            }
            if (second.Denominator > first.Denominator)
            {
                if (first.Denominator < 0 && second.Denominator > 0)
                {
                    return true;
                }
                float difference = second.Denominator / first.Denominator;

                float full = first.Numerator * difference;

                return full >= second.Numerator;
            }

            return first.Numerator >= second.Numerator;
        }
        public static bool operator <=(RationalNum first, RationalNum second)
        {
            if (first.Denominator > second.Denominator)
            {
                if (second.Denominator < 0 && first.Denominator > 0)
                {
                    return false;
                }
                float difference = first.Denominator / second.Denominator;

                float full = second.Numerator * difference;

                return first.Numerator <= full;
            }
            if (second.Denominator > first.Denominator)
            {
                if (first.Denominator < 0 && second.Denominator > 0)
                {
                    return true;
                }
                float difference = second.Denominator / first.Denominator;

                float full = first.Numerator * difference;

                return full <= second.Numerator;
            }

            return first.Numerator <= second.Numerator;
        }
        public static RationalNum operator +(RationalNum first, RationalNum second)
        {
            float Result = first.Numerator + second.Numerator;

            if (first.Numerator < 0 && second.Numerator < 0)
            {
                Result = Result * -1;
            }

            if (first.Denominator > second.Denominator)
            {
                float change = Math.Abs(first.Denominator / second.Denominator);

                Result = (second.Numerator * change) + first.Numerator;

                if (first.Numerator < 0 && second.Numerator < 0)
                {
                    Result = Result * -1;
                }

                return new RationalNum(Result, first.Denominator);
            }
            if (second.Denominator > first.Denominator)
            {
                float change = Math.Abs(second.Denominator / first.Denominator);

                Result = (first.Numerator * change) + second.Numerator;

                if (first.Numerator < 0 && second.Numerator < 0)
                {
                    Result = Result * -1;
                }

                return new RationalNum(Result, second.Denominator);
            }

            return new RationalNum(Result, first.Denominator);
        }
        public static RationalNum operator -(RationalNum first, RationalNum second)
        {
            if (first.Denominator > second.Denominator)
            {
                float change = Math.Abs(first.Denominator / second.Denominator);

                float Numerator = first.Numerator - (second.Numerator * change);

                return new RationalNum(Numerator,first.Denominator);
            }
            if (second.Denominator > first.Denominator)
            {
                float change = Math.Abs(second.Denominator / first.Denominator);

                float Numerator = (first.Numerator * change) - second.Numerator;

                return new RationalNum(Numerator, second.Denominator);
            }

            return new RationalNum(first.Numerator - second.Numerator, first.Denominator);
        }
        public static RationalNum operator *(RationalNum first, RationalNum second)
        {
            return new RationalNum(first.Numerator * second.Numerator, first.Denominator * second.Denominator);
        }
        public static RationalNum operator /(RationalNum first, RationalNum second)
        {
            float Temp = second.Denominator;

            second.Denominator = second.Numerator;

            second.Numerator = Temp;

            return new RationalNum(first.Numerator * second.Numerator, first.Denominator * second.Denominator);
        }
        public static RationalNum operator %(RationalNum first, RationalNum second)
        {
            if (first.Denominator < second.Denominator)
            {
                float change = second.Denominator / first.Denominator;

                float Numerator = (first.Numerator * change) % second.Numerator;

                return new RationalNum(Numerator, second.Denominator);
            }
            if (second.Denominator < first.Denominator)
            {
                float change = first.Denominator / second.Denominator;

                float Numerator = (second.Numerator * change) % first.Numerator;

                return new RationalNum(Numerator, first.Denominator);
            }

            return new RationalNum((first.Numerator % second.Numerator), second.Denominator);
        }
        public static RationalNum operator ++(RationalNum rationalNum)
        {
            ++rationalNum.Numerator;

            return rationalNum;
        }
        public static RationalNum operator --(RationalNum rationalNum)
        {
            --rationalNum.Numerator;

            return rationalNum;
        }
        
        public static explicit operator int(RationalNum rationalNum)
        {
            if (rationalNum.Numerator < 0 || rationalNum.Denominator < 0)
            {
                int ConvertedInt = (int)(rationalNum.Numerator / rationalNum.Denominator);

                return ConvertedInt * -1;
            }

            return (int)(rationalNum.Numerator / rationalNum.Denominator);
        }
        public static explicit operator float(RationalNum rationalNum)
        {
            if (rationalNum.Numerator < 0 || rationalNum.Denominator < 0)
            {
                float ConvertedFloat = (float)(rationalNum.Numerator / rationalNum.Denominator);

                return ConvertedFloat * -1;
            }

            return (float)(rationalNum.Numerator / rationalNum.Denominator);
        }

        public override string ToString()
        {
            string Text = string.Empty;

            if (this.Numerator < 0 && this.Denominator < 0)
            {
                Text =
@$"   {this.Numerator * -1}
- ────
   {this.Denominator * -1}";

                return Text;
            }

            Text =
@$"{this.Numerator}
────
{this.Denominator}";

            return Text;
        }
    }
}
