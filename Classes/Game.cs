using System;
using System.Collections.Generic;
using ShutTheBox.Classes;

namespace ShutTheBox.Classes
{
    public class Game
    {
        private static bool isGameOver;
        private static string input;
        private static int optionSelected;
        private static int sumOfRolls;
        
        public static void New(List<Player> players)
        {
            // Reset each game
            isGameOver = false;

            // Take turns until a player wins
            while (!isGameOver)
            {
                foreach (var player in players)
                {
                    // Reset each turn
                    input = string.Empty;
                    optionSelected = 0;
                    sumOfRolls = 0;

                    // Indicate whose turn it is
                    Console.WriteLine($"It is currently {player.Name}'s turn.\n\n");
                    
                    // Ask how many dice the player wants to roll
                    Console.Write("How many dice do you want to roll: ");
                    input = Console.ReadLine();

                    // Check if input is numeric
                    // TODO: Run check until valid input is given
                    if (int.TryParse(input, out optionSelected))
                    {
                        sumOfRolls = Dice.Roll(optionSelected);
                    }
                }
            }
        }
    }
}