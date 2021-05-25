using System;
using System.Collections.Generic;
using System.Linq;

namespace ShutTheBox.Classes
{
    public class Utils
    {
        private static int optionSelected;
        private static string rawInput;
        private static bool isInputNumeric;


        public static int GetValidInput(string message, IEnumerable<int> validInputs)
        {
            optionSelected = 0;
            rawInput = string.Empty;
            isInputNumeric = false;


            while (true)
            {
                Console.Write(message + " ");
                rawInput = Console.ReadLine();
                isInputNumeric = int.TryParse(rawInput, out optionSelected);


                if (isInputNumeric && validInputs.Contains<int>(optionSelected))
                {
                    return optionSelected;
                }
                else
                {
                    Console.WriteLine("Please enter a valid input.\n");
                }
            }
        }
    }
}