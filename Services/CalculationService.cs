namespace MinMaxCalculator.Services
{
    public class CalculationService : ICalculationService
    {
        public CalculationService() { }
        private static string inputString { get; set; }

        private static int GetMin()
        {
            if (inputString.Length == 0)
                return 0;
            int number1, number2;
            int minValue;
            int indexOfFirstHalf = inputString.IndexOf(',', 1);
            int indexOfSecondHalf = inputString.IndexOf(')', 1);
            int tempNumber;
            if (Char.IsLetter(inputString[0]))
            {
                if ("GetMax(".Equals(inputString.Substring(0, 7), StringComparison.Ordinal))
                {
                    inputString = inputString.Substring(7);
                    tempNumber = GetMax();
                    inputString = tempNumber + inputString;
                }
                else if ("GetMin(".Equals(inputString.Substring(0, 7), StringComparison.Ordinal))
                {
                    inputString = inputString.Substring(7);
                    tempNumber = GetMin();
                    inputString = tempNumber + inputString;
                }
                else
                {
                    Console.Write("Invalid Input String");
                    inputString = string.Empty;
                    return 0;
                }
            }

            if (indexOfFirstHalf == -1 || indexOfSecondHalf == -1)
                return 0;
            int length = indexOfSecondHalf - (indexOfFirstHalf + 1);
            bool isNumber1Found = int.TryParse(inputString.Substring(0, indexOfFirstHalf), out number1);
            bool isNumber2Found = int.TryParse(inputString.Substring(indexOfFirstHalf + 1, length), out number2);
            if (isNumber1Found && isNumber2Found)
            {
                minValue = number1 < number2 ? number1 : number2;
                inputString = inputString.Substring(indexOfSecondHalf + 1);
                return minValue;
            }

            if (!isNumber1Found && !isNumber2Found)
            {
                number1 = CalculateMinMax();
                number2 = CalculateMinMax();
                minValue = number1 < number2 ? number1 : number2;
                return minValue;
            }

            if (isNumber1Found)
            {
                inputString = inputString.Substring(indexOfFirstHalf + 1);
                number2 = CalculateMinMax();

                Console.WriteLine(inputString + " number2 " + number2);

                minValue = number1 < number2 ? number1 : number2;

                return minValue;
            }
            if (isNumber2Found)
            {
                inputString = inputString.Substring(0, indexOfFirstHalf) + inputString.Substring(indexOfSecondHalf);
                number1 = CalculateMinMax();

                Console.WriteLine(inputString + " number1 " + number1);

                minValue = number1 < number2 ? number1 : number2;

                return minValue;
            }
            CalculateMinMax();
            return 0;
        }

        private static int GetMax()
        {
            if (inputString.Length == 0)
                return 0;
            int number1, number2;
            int maxValue;
            int indexOfFirstHalf = inputString.IndexOf(',', 1);
            int indexOfSecondHalf = inputString.IndexOf(')', 1);
            int tempNumber;
            if (Char.IsLetter(inputString[0]))
            {
                if ("GetMax(".Equals(inputString.Substring(0, 7), StringComparison.Ordinal))
                {
                    inputString = inputString.Substring(7);
                    tempNumber = GetMax();
                    inputString = tempNumber + inputString;
                }
                else if ("GetMin(".Equals(inputString.Substring(0, 7), StringComparison.Ordinal))
                {
                    inputString = inputString.Substring(7);
                    tempNumber = GetMin();
                    inputString = tempNumber + inputString;
                }
                else
                {
                    Console.Write("Invalid Input String");
                    inputString = string.Empty;
                    return 0;
                }
            }

            if (indexOfFirstHalf == -1 || indexOfSecondHalf == -1)
                return 0;
            int length = indexOfSecondHalf - (indexOfFirstHalf + 1);
            bool isNumber1Found = int.TryParse(inputString.Substring(0, indexOfFirstHalf), out number1);
            bool isNumber2Found = int.TryParse(inputString.Substring(indexOfFirstHalf + 1, length), out number2);
            if (isNumber1Found && isNumber2Found)
            {
                maxValue = number1 > number2 ? number1 : number2;
                inputString = inputString.Substring(indexOfSecondHalf + 1);
                return maxValue;
            }

            if (!isNumber1Found && !isNumber2Found)
            {
                number1 = CalculateMinMax();
                number2 = CalculateMinMax();
                maxValue = number1 > number2 ? number1 : number2;
                return maxValue;
            }

            if (isNumber1Found)
            {
                inputString = inputString.Substring(indexOfFirstHalf + 1);
                number2 = CalculateMinMax();

                Console.WriteLine(inputString + " number2 " + number2);

                maxValue = number1 > number2 ? number1 : number2;

                return maxValue;
            }
            if (isNumber2Found)
            {
                inputString = inputString.Substring(0, indexOfFirstHalf) + inputString.Substring(indexOfSecondHalf);
                number1 = CalculateMinMax();

                Console.WriteLine(inputString + " number1 " + number1);

                maxValue = number1 > number2 ? number1 : number2;

                return maxValue;
            }
            CalculateMinMax();
            return 0;
        }

        private static int CalculateMinMax()
        {
            if (inputString.Length == 0)
                return 0;
            List<int> list = new List<int>();
            char sign = '+';
            int number = 0;
            while (inputString.Length > 0)
            {
                char character = inputString[0];
                int tempNumber;

                if (Char.IsLetter(character))
                {
                    if ("GetMax(".Equals(inputString.Substring(0, 7), StringComparison.Ordinal))
                    {
                        inputString = inputString.Substring(7);
                        tempNumber = GetMax();
                        inputString = tempNumber + inputString;
                    }
                    else if ("GetMin(".Equals(inputString.Substring(0, 7), StringComparison.Ordinal))
                    {
                        inputString = inputString.Substring(7);
                        tempNumber = GetMin();
                        inputString = tempNumber + inputString;
                    }
                    else
                    {
                        Console.Write("Invalid Input String");
                        inputString = string.Empty;
                        return 0;
                    }
                }

                if (!Char.IsLetter(character))
                    inputString = inputString.Substring(1);

                if (Char.IsDigit(character))
                {
                    number = number * 10 + int.Parse(character.ToString());
                }

                if (character.Equals('('))
                {
                    number = CalculateMinMax();
                }

                if (inputString.Length == 0 || (character.Equals('+') || character.Equals('-') || character.Equals('*') || character.Equals('/') || character.Equals(')') || character.Equals(',')))
                {
                    if (sign.Equals('+'))
                    {
                        list.Add(number);
                    }
                    else if (sign.Equals('-'))
                    {
                        list.Add(-number);
                    }
                    else if (sign.Equals('*'))
                    {
                        list[list.Count - 1] = list[list.Count - 1] * number;

                    }
                    else if (sign.Equals('/'))
                    {
                        list[list.Count - 1] = list[list.Count - 1] / number;
                    }

                    sign = character;
                    number = 0;

                    if (character.Equals(')') || character.Equals(','))
                        break;
                }
            }

            return list.Sum(x => Convert.ToInt32(x));
        }

        public int Calculate(string input)
        {
            if (string.IsNullOrEmpty(input)) return 0;
            inputString = input;
            inputString = inputString.Replace(" ", string.Empty);
            return CalculateMinMax();
        }
    }
}
