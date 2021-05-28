using System;
using System.Collections.Generic;

namespace ShutTheBox.Classes
{
    public class Menus
    {
        private static string winner;
        private static List<Player> players;
        private static int optionSelected;
        private static string input;
        private const string MENULOGO = @"
              _______
   ______    | .   . |\
  /     /\   |   .   |.\
 /  '  /  \  | .   . |.'|
/_____/. . \ |_______|.'|
\ . . \    /  \ ' .   \'|
 \ . . \  /    \____'__\|
  \_____\/";


        public static void MainMenu()
        {
            // Initialize class variables
            optionSelected = 0;

            input = string.Empty;
            winner = string.Empty;
            

            while (input != "2")
            {
                Console.Clear();

                // Display the Game and Menu Logo
                Console.WriteLine("\n--- Shut the Box ---");
                Console.WriteLine(MENULOGO + "\n\n");

                // Display the available options
                Console.WriteLine("Options:");
                Console.WriteLine("  1 - Start new game");
                Console.WriteLine("  2 - Exit\n\n");

                // Prompt user for menu selection
                Console.Write("Please select an option: ");
                input = Console.ReadLine();

                // Check if input is numeric
                if (int.TryParse(input, out optionSelected) && optionSelected == 1)
                {
                    // Display the PlayerMenu
                    PlayerMenu();

                    // List the players
                    Console.WriteLine("Players:");
                    foreach (Player player in players)
                    {
                        Console.WriteLine("  - " + player.Name);
                    }

                    // TODO: Fix game logic to use the rules: https://en.wikipedia.org/wiki/Shut_the_box
                    // Start a new game
                    Console.WriteLine("Starting new game!");
                    winner = Game.New(players);
                    Console.WriteLine($"Congratulations {winner}, you won!\n\n");
                    Console.Write("Press any key to continue...");
                    Console.ReadKey();
                    while(Console.KeyAvailable) 
                        Console.ReadKey(false);

                    input = "0";
                }
            }
        }

        public static void PlayerMenu()
        {
            // Initialize class variables
            players = new List<Player>();
            optionSelected = 0;
            input = string.Empty;

            while (optionSelected < 1 || optionSelected > 4)
            {
                // Prompt user for number of players
                Console.Write("Enter the number of players (1-4): ");
                input = Console.ReadLine();

                // Check if input is numeric
                if (int.TryParse(input, out optionSelected) && optionSelected >= 1 && optionSelected <= 4)
                {
                    for (int i = 1; i <= optionSelected; i++)
                    {
                        Console.Write($"Enter the name of Player {i}: ");
                        players.Add(new Player(Console.ReadLine().Trim()));
                    }
                }
                else
                {
                    Console.WriteLine("Please enter a valid option.");
                }
            }
        }
    }
}