using System;

namespace intro.Services
{
    public class RandomService
    {
        private Random random = new Random();

        public int Integer => random.Next();
    }
}
