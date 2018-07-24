using RandomNameGeneratorLibrary;
using System;

namespace Dijkstra.Graph.Utils
{
    public class RandomUtils
    {
        private static PlaceNameGenerator _placeGenerator = new PlaceNameGenerator();
        private static readonly Random _random = new Random();

        /// <summary>
        /// Random distance between node.
        /// </summary>
        /// <param name="minDistance"></param>
        /// <param name="maxDistance"></param>
        /// <returns>Random integer from minDistance to maxDistance</returns>
        public static int NextDistance(int minDistance, int maxDistance)
        {
            if (minDistance <= 0)
                throw new ArgumentOutOfRangeException("minDistance should be greater than 0.");
            if (maxDistance <= 0 || maxDistance < minDistance)
                throw new ArgumentOutOfRangeException("maxDistance should be greater than minDistance.");

            return _random.Next(minDistance, maxDistance);
        }

        /// <summary>
        /// Random if it should be appear.
        /// </summary>
        /// <param name="percentage">Double from 0 to 1. The more is the more chance to be true.</param>
        /// <returns>True if random value is less than input percentage. Otherwise false.</returns>
        public static bool NextAppearance(double percentage)
        {
            if (percentage < 0 || percentage > 1)
                throw new ArgumentOutOfRangeException("percentage should be greater than or equal 0 and less than 1.");
            else if (percentage == 0)
                return false;
            else if (Math.Abs(percentage - 1.0) < 0.0000001)
                return true;

            return _random.NextDouble() > percentage;
        }

        /// <summary>
        /// Generate a place name randomly.
        /// </summary>
        /// <returns>Random place name</returns>
        public static string NextPlaceName()
        {
            return _placeGenerator.GenerateRandomPlaceName();
        }
    }
}
