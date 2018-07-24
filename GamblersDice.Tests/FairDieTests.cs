using System;
using Xunit;
using GamblersDice;

namespace GamblersDice.Tests
{
    [Trait("Category", "Fair")]
    public class FairDieTests
    {
        Random _rnd = new Random();

        [Fact]
        public void ConstructFairDie() => Assert.IsType<FairDie>(new FairDie());

        [Fact]
        public void ConstructFairDie_Sides() => Assert.IsType<FairDie>(new FairDie(6));

        [Fact]
        [Trait("Category", "Random")]
        public void ConstructFairDie_Random() => Assert.IsType<FairDie>(new FairDie(_rnd));

        [Fact]
        [Trait("Category", "Random")]
        public void ConstructFairDie_Sides_Random() => Assert.IsType<FairDie>(new FairDie(_rnd, 6));

        [Theory]
        [InlineData(6)]
        [InlineData(20)]
        public void Uniform(int sides)
        {
            var die = new FairDie(sides);
            int[] result = new int[sides];
            decimal iters = 10_000_000M;

            for (int i = 0; i < iters; i++)
            {
                result[die.Roll() - 1]++;
            }

            for (int i = 0; i < sides; i++)
            {
                decimal roll = (result[i] - iters / sides) / iters;
                Assert.True(0.001M > roll, $"{roll} is outside of uniformity tolerance of 0.001");
            }
        }
    }
}
