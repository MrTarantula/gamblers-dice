using System;

namespace GamblersDice
{
    public class FairDie : Die
    {
        private int _sides;
        private Random _rnd;

        /// <summary>Initializes a new fair die with a default of six sides.</summary>
        public FairDie() : this(new Random()) { }

        /// <summary>Initializes a new fair die with the specified number of sides.</summary>
        /// <param name="sides">Number of sides on the die.</param>
        public FairDie(int sides) : this(new Random(), sides) { }

        /// <summary>Initializes a new fair die with a default of six sides. Bring your own <c>Random</c> object.</summary>
        /// <param name="rnd"><c>Random</c> object to be used when rolling the die</param>
        public FairDie(Random rnd) : this(rnd, 6) { }

        /// <summary>Initializes a new fair die with the specified number of sides. Bring your own <c>Random</c> object.</summary>
        /// <param name="rnd"><c>Random</c> object to be used when rolling the die.</param>
        /// <param name="sides">Number of sides on the die.</param>
        public FairDie(Random rnd, int sides)
        {
            _rnd = rnd;
            _sides = sides;
        }

        /// <summary>Rolls the die.</summary>
        /// <returns>Returns the side rolled.</returns>
        public int Roll() => _rnd.Next(_sides) + 1;
    }
}
