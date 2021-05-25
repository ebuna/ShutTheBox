using System;
using System.Collections.Generic;

namespace ShutTheBox.Classes
{
    public class Player
    {
        public string Name { get; }
        public bool isWinner { get; set; }
        private List<int> availableLevers;


        public Player(string name)
        {
            Name = name;
            isWinner = false;
            availableLevers = new List<int>();
            for (int i = 1; i < 10; i++)
            {
                availableLevers.Add(i);
            }
        }

        public List<int> GetAvailableLevers()
        {
            return availableLevers;
        }

        public void DisplayAvailableLevers()
        {
            foreach (var lever in availableLevers)
            {
                Console.Write($"   {lever}");
            }
            Console.WriteLine();
        }

        public int SumOfRemainingLevers()
        {
            int sum = 0;

            foreach (var lever in availableLevers)
            {
                sum += lever;
            }

            return sum;
        }

        public int LeversRemaining()
        {
            return availableLevers.Count;
        }

        public int RemoveLever(int leverToRemove, int sumOfRolls)
        {
            if (leverToRemove <= sumOfRolls && availableLevers.Contains(leverToRemove))
            {
                availableLevers.Remove(leverToRemove);
                sumOfRolls -= leverToRemove;
            }
            else
            {
                Console.WriteLine("You cannot remove that lever.");
            }

            return sumOfRolls;
        }
    }
}