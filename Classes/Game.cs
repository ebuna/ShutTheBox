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
        private static string winner;
        
        public static string New(List<Player> players)
        {
            // Reset each game
            isGameOver = false;
            winner = string.Empty;

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
                        //  Check if rolls are exhausted to end turn
                        if (sumOfRolls <= 0 || sumOfRolls < player.GetAvailableLevers()[0])
                        {
                            isTurnOver = true;
                        }
                        else
                        {
                            optionSelected = Utils.GetValidInput("\nWhich lever do you want to remove?", player.GetAvailableLevers());
                            sumOfRolls = player.RemoveLever(optionSelected, sumOfRolls);

                            // Check if the player has won the game
                            if (player.SumOfRemainingLevers() == 0)
                            {
                                isGameOver = true;
                                winner = player.Name;
                                return winner;
                            }

                            Console.WriteLine($"\nYou have {sumOfRolls} remaining.\n\n");
                            player.DisplayAvailableLevers();
                        }
                    }
                }
            }

            return winner;
        }
    }
}