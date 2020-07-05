using System;

namespace Assets.scripts
{
    public class Rng
    {
        private static Random rand;

        private static Random Rand
        { 
            get
            {
                if (rand == null)
                    rand = new Random((int)DateTime.Now.Ticks);

                return rand;
            }
        }

        public static int NextInt(int min, int max) =>
            Rand.Next(min, max);
    }
}
