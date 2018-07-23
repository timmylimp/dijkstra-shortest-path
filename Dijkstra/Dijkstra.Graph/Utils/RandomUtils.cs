using RandomNameGeneratorLibrary;
using System;

namespace Dijkstra.Graph.Utils
{
    class RandomUtils
    {
        private static PlaceNameGenerator _placeGenerator = new PlaceNameGenerator();
        private static readonly Random _random = new Random();

        public static int NextDistance(int minDistance, int maxDistance)
        {
            if (minDistance <= 0)
                throw new ArgumentOutOfRangeException("minDistance should be greater than 0.");
            if (maxDistance <= 0 || maxDistance < minDistance)
                throw new ArgumentOutOfRangeException("maxDistance should be greater than minDistance.");

            return _random.Next(minDistance, maxDistance);
        }

        public static bool NextAppearance(double percentage)
        {
            if (percentage < 0 || percentage >= 1)
                throw new ArgumentOutOfRangeException("percentage should be greater than or equal 0 and less than 1.");

            return _random.NextDouble() > percentage;
        }

        public static string NextPlaceName()
        {
            return _placeGenerator.GenerateRandomPlaceName();
        }
    }
}
