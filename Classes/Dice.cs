using System;
using System.Collections.Generic;

namespace ShutTheBox.Classes
{
    public class Dice
    {
        #region diceArt
        private const string ONE = @"-------
|     |
|  o  |
|     |
-------";
        private const string TWO = @"-------
| o   |
|     |
|   o |
-------";
        private const string THREE = @"-------
| o   |
|  o  |
|   o |
-------";
        private const string FOUR = @"-------
| o o |
|     |
| o o |
-------";
        private const string FIVE = @"-------
| o o |
|  o  |
| o o |
-------";
        private const string SIX = @"-------
| o o |
| o o |
| o o |
-------";
        #endregion

        private static List<int> rollOutcomes;
        private static int sumOfRolls;
        private static Random roll;

        public static int Roll (int numberOfDice)
        {
            rollOutcomes = new List<int>();
            sumOfRolls = 0;
            roll = new Random();

            // Roll n dice, where n = numberOfDice
            for (int i = 0; i < numberOfDice; i++)
            {
                rollOutcomes.Add(roll.Next(1, 7));
            }

            // Display the roll outcomes and the sum of the rolls
            Console.WriteLine("Here are your rolls:");
            PrintValues(rollOutcomes);
            Console.WriteLine($"\nThe sum of your rolls is {SumOfRolls(rollOutcomes)}");
            
            return SumOfRolls(rollOutcomes);
        }

        private static void PrintValues( List<int> rolls )  {
            foreach ( int roll in rolls )
            {
                switch (roll)
                {
                    case 1:
                        Console.WriteLine(ONE);
                        break;
                    case 2:
                        Console.WriteLine(TWO);
                        break;
                    case 3:
                        Console.WriteLine(THREE);
                        break;
                    case 4:
                        Console.WriteLine(FOUR);
                        break;
                    case 5:
                        Console.WriteLine(FIVE);
                        break;
                    default:
                        Console.WriteLine(SIX);
                        break;
                }
            }
        }

        private static int SumOfRolls(List<int> rolls)
        {
            int sum = 0;

            foreach (int roll in rolls)
            {
                sum += roll;
            }

            return sum;
        }
    }
}