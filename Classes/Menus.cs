using System;

namespace ShutTheBox.Classes
{
    public class Menus
    {
        private static int optionSelected;
        private static int numberOfPlayers;
        private static string input;
        private const string MENULOGO = @"
              _______.
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
            numberOfPlayers = 0;
            input = string.Empty;
            

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

                    // TODO: Implement game logic
                    Console.WriteLine("New game starting.");
                }
            }
        }

        public static void PlayerMenu()
        {
            // Initialize class variables
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
                    // TODO: Implement Player class
                }
                else
                {
                    Console.WriteLine("Please enter a valid option.");
                }
            }
        }
    }
}