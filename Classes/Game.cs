using System;
using System.Collections.Generic;
using ShutTheBox.Classes;

namespace ShutTheBox.Classes
{
    public class Game
    {
        private static int optionSelected;
        private static int sumOfRolls;
        private static int[] validInputs;
        private static bool isTurnOver;
        private static List<int> levers;
        private static string winner;
        private static Player potentialWinner;
        
        public static string New(List<Player> players)
        {
            // Reset each game
            winner = string.Empty;

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


                // Prompt for lever to remove
                while ((sumOfRolls >= player.GetAvailableLevers()[0] || sumOfRolls == 0) && !isTurnOver)
                {
                    // Ask how many dice to roll
                    validInputs = new int[2] {1, 2};
                    optionSelected = Utils.GetValidInput("\nHow many dice do you want to roll (1-2):", validInputs);
                    
                    // Get and display rolls and sumOfRolls
                    sumOfRolls = Dice.Roll(optionSelected);

                    while (sumOfRolls > 0 && !isTurnOver)
                    {
                        //  Check if rolls are exhausted to end turn
                        if (sumOfRolls < player.GetAvailableLevers()[0])
                        {
                            isTurnOver = true;
                            player.Score += player.SumOfRemainingLevers();
                        }
                        else
                        {
                            optionSelected = Utils.GetValidInput("\nWhich lever do you want to remove?", player.GetAvailableLevers());
                            sumOfRolls = player.RemoveLever(optionSelected, sumOfRolls);

                            Console.WriteLine($"\nYou have {sumOfRolls} remaining.\n");
                            player.DisplayAvailableLevers();
                        }
                    }
                }

                Console.WriteLine($"{player.Name}'s score: {player.Score}\n");
            }

            // Determine the winner
            foreach (var player in players)
            {
                Console.WriteLine($"{player.Name}'s score: {player.Score}");
                if (string.IsNullOrEmpty(winner))
                {
                    potentialWinner = player;
                    winner = player.Name;
                }
                else
                {
                    if (player.Score < potentialWinner.Score)
                    {
                        potentialWinner = player;
                        winner = player.Name;
                    }
                }
            }

            return winner;
        }
    }
}