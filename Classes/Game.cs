using System;
using System.Collections.Generic;
using ShutTheBox.Classes;

namespace ShutTheBox.Classes
{
    public class Game
    {
        private static bool isGameOver;
        private static int optionSelected;
        private static int sumOfRolls;
        private static int[] validInputs;
        private static bool isTurnOver;
        private static List<int> levers;
        
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
                    optionSelected = 0;
                    sumOfRolls = 0;
                    isTurnOver = false;
                    levers = player.GetAvailableLevers();

                    // Indicate whose turn it is
                    Console.WriteLine($"\nIt is currently {player.Name}'s turn.\n\n");
                    
                    // Display current players game state
                    player.DisplayAvailableLevers();

                    // Ask how many dice to roll
                    validInputs = new int[2] {1, 2};
                    optionSelected = Utils.GetValidInput("\nHow many dice do you want to roll (1-2):", validInputs);
                    
                    // Get and display rolls and sumOfRolls
                    sumOfRolls = Dice.Roll(optionSelected);

                    // Prompt for lever to remove
                    while (sumOfRolls > 0 && !isTurnOver)
                    {
                        optionSelected = Utils.GetValidInput("\nWhich lever do you want to remove?", player.GetAvailableLevers());
                        sumOfRolls = player.RemoveLever(optionSelected, sumOfRolls);
                        Console.WriteLine($"\nYou have {sumOfRolls} remaining.\n\n");
                        player.DisplayAvailableLevers();

                        if (sumOfRolls <= 0 || sumOfRolls < player.GetAvailableLevers()[0])
                        {
                            isTurnOver = true;
                        }
                    }
                }
            }
        }
    }
}