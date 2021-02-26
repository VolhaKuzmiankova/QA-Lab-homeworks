using System;

namespace Collections.Utils
{
    public static class RandomUtil
    {

        private static readonly Random _random = new Random();
        
        public static int NexRandomInt(int min = 1, int max = 10)
        {
            return _random.Next(min, max);
        }
    }
}