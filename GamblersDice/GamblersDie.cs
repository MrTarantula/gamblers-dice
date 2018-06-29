using System;

namespace GamblersDice
{
    public class GamblersDie : Die
    {
        private Random _rnd;
        public int[] Weight { get; private set; }

        /// <summary>
        /// Initializes a new gambler's die with a default of six sides.
        /// </summary>
        public GamblersDie() : this(6) { }

        /// <summary>
        /// Initializes a new gambler's die with the specified number of sides.
        /// </summary>
        /// <param name="size">Size of the die.</param>
        public GamblersDie(int size)
        {
            Weight = new int[size];
            _rnd = new Random();

            foreach (int i in Weight)
            {
                Weight[i] = 1;
            }
        }

        /// <summary>
        /// Initializes a new gambler's die with known weights.
        /// </summary>
        /// <param name="weights">Pre-calculated weights of the sides of the die</param>
        public GamblersDie(params int[] weights) : this(weights.Length)
        {
            for (int i = 0; i < Weight.Length; i++)
            {
                Weight[i] = weights[i];
            }
        }

        /// <summary>
        /// Rolls the die.
        /// </summary>
        /// <returns>Returns the side rolled.</returns>
        public int Roll()
        {
            int sum = 0;
            int target = 0;

            // Add up all of the states
            foreach (int w in Weight)
            {
                sum += w;
            }

            // Get a random number between 0 and the sum
            int rand = _rnd.Next(sum);

            // Find the target
            while (rand >= 0)
            {
                rand -= Weight[target++];
            }

            // Update the weights
            for (int i = 0; i < Weight.Length; i++)
            {
                if (i == target - 1)
                {
                    Weight[i] = 1;
                }
                else
                {
                    Weight[i]++;
                }
            }

            return target;
        }
    }
}
