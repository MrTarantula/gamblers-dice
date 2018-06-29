using System;

namespace GamblersDice
{
    public class FairDie : Die
    {
        private int _sides;
        private Random _rnd;

        /// <summary>
        /// Initializes a new fair die with a default of six sides.
        /// </summary>
        public FairDie() : this(6) { }

        /// <summary>
        /// Initializes a new fair die with the specified number of sides.
        /// </summary>
        /// <param name="size">Size of the die.</param>
        public FairDie(int sides)
        {
            _sides = sides;
            _rnd = new Random();
        }

        /// <summary>
        /// Rolls the die.
        /// </summary>
        /// <returns>Returns the side rolled.</returns>
        public int Roll()
        {
            return _rnd.Next(_sides) + 1;
        }
    }
}
