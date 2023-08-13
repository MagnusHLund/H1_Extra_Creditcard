namespace H1_Extra_Creditcard
{
    internal class Program
    {
        static void Main()
        {
            // Gets array with card numbers, from other class
            string[] cardNumbers = CardNumbers.cardNumbers;

            foreach (string cardNumber in cardNumbers)
            {
                // Step 1
                // gets the last digit in the "last" variable and converts it to int called "lastInt". stores the other characters in the "others" variable.
                string last = cardNumber.Remove(0, cardNumber.Length - 1);
                int lastInt = int.Parse(last);
                string others = cardNumber.Remove(cardNumber.Length - 1, cardNumber.Length - 15);


                // Step 2
                // Converts the "others" variable to a char array and names the new variable "charNumbers".
                char[] charNumbers = others.ToCharArray();

                // Reverses the order of characters and puts them in a string named "reverseNumber"
                string reverseNumber = string.Join(" ", charNumbers.Reverse());

                // Creates an int array called "individualNumber" and puts in the "reverseNumber" converted to array
                int[] individualNumber = reverseNumber.Split(" ").Select(x => Convert.ToInt32(x)).ToArray();


                // Step 3
                // Creates a counter to keep track of odd and even numbers and a list to keep track of the ints returning from the OddEven method
                short counter = 0;
                List<int> afterMath = new List<int>();

                // Goes through each number in the individualNumber array
                foreach (int number in individualNumber)
                {
                    // Counter goes up by 1
                    counter++;

                    // Step 4
                    // Adds each returning value from OddEven() to the aftermath list
                    afterMath.Add(OddEven(number, counter));
                }
                
                // Takes the sum of the aftermath list and puts it in the new "sum" variable
                int sum = afterMath.Sum(x => Convert.ToInt32(x));

                // Step 5
                // Gets the 2nd number of sum and reduces that number with 10. Puts the result inside the "result" variable.
                int lastNumberOfSum = sum % 10;
                int result = 10 - lastNumberOfSum;

                // if lastInt and result is the same number then the card number is valid, else its invalid
                if (lastInt == result)
                    Console.WriteLine($"{cardNumber} is valid");
                else Console.WriteLine($"{cardNumber} is invalid");

            }
        }

        // Step 3
        static int OddEven(int number, int counter)
        {
            int result;

            // Every odd number passes this if statement
            if (counter % 2 != 0)
            {
                // Doubles the value of number
                result = number * 2;

                // If the result is 10 or more
                if (result >= 10)
                {
                    // Splits up the value of result (12 becomes 1 and 2, for first and second number)
                    int first = result / 10;
                    int second = result % 10;

                    // Adds the value of first and second together and puts the result into the "number" variable
                    number = first + second;
                }
                else
                {
                    // if the result is less than 10, then the "number" becomes the same value as the "result".
                    number = result;
                }
            }

            // If its even then the number remains unedited and returns, but if its odd then it has been given a new value
            return number;
        }
    }
}