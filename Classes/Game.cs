using System;
using System.Collections.Generic;
using ShutTheBox.Classes;

namespace ShutTheBox.Classes
{
    public class Game
    {
        private static bool isGameOver;
        
        public static void New(List<Player> players)
        {
            // Initialize class variables
            isGameOver = false;

            // Take turns until a player wins
            while (!isGameOver)
            {
                foreach (var player in players)
                {
                    Console.WriteLine($"It is currently {player.Name}'s turn.");
                    // Pause on each turn
                    // TODO: Implement Dice class and game logic
                    Console.ReadKey();
                }
            }
        }
    }
}