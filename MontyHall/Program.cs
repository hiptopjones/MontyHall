using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MontyHall
{
    class Program
    {
        private static Random _random = new Random();

        private const string Goat = "Goat";
        private const string Car = "Car";

        static void Main(string[] args)
        {
            int iterations = 0;
            int userWinsIfStays = 0;
            int userWinsIfChanges = 0;

            while (true)
            {
                iterations++;

                // Initialization
                string[] doors = Enumerable.Range(0, 3).Select(i => Goat).ToArray();
                int carIndex = _random.Next(doors.Length);
                doors[carIndex] = Car;

                // Player makes choice
                int userIndex = _random.Next(doors.Length);
                doors[userIndex] += "[U]";

                // Host shows a door with a goat
                int shownIndex = 0;
                for (int i = 0; i < doors.Length; i++)
                {
                    if (i != carIndex && i != userIndex)
                    {
                        shownIndex = i;
                        doors[shownIndex] += "[S]";
                        break;
                    }
                }

                // Calculate the winning choice for the player
                if (userIndex == carIndex)
                {
                    userWinsIfStays++;
                }
                else
                {
                    userWinsIfChanges++;
                }

                // Output the results
                Console.WriteLine("Iterations: {0} Doors: {1} Stay: {2} Change: {3}",
                    iterations, string.Join(" ", doors), userWinsIfStays, userWinsIfChanges);
            }
        }
    }
}
