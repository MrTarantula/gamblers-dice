using System;
using Xunit;
using GamblersDice;

namespace GamblersDice.Tests
{
    public class GamblersDiceTests
    {
        [Theory]
        [InlineData(6)]
        [InlineData(20)]
        public void Uniform(int sides)
        {
            var die = new GamblersDie(sides);
            int[] result = new int[sides];
            int iters = 10_000_000;

            for (int i = 0; i < iters; i++)
            {
                result[die.Roll() - 1]++;
            }

            double avg = iters / sides;

            for (int i = 0; i < sides; i++)
            {
                double roll = (result[i] - avg) / iters;
                Assert.True(0.001 > roll, $"{roll} is outside of uniformity tolerance of 0.001");
            }
        }

        [Theory]
        [InlineData(new int[] { 0, 0, 1, 0, 0, 0 }, 3)]
        [InlineData(new int[] { 0, 0, 0, 0, 1, 0 }, 5)]
        public void NonUniform(int[] weights, int expected)
        {
            var die = new GamblersDie(weights);

            Assert.Equal(expected, die.Roll());
        }

        [Theory]
        [InlineData(0.4, 0)]
        [InlineData(0.3, 1)]
        [InlineData(0.2, 2)]
        [InlineData(0.1, 3)]
        public void NonUniform_Inferred(double percent, int side)
        {
            // Given this state, [4,3,2,1]
            // 1 should be rolled 40% of the time
            // 2 should be rolled 30% of the time
            // 3 should be rolled 20% of the time
            // 4 should be rolled 10% of the time

            int[] result = new int[] { 0, 0, 0, 0 };

            for (int run = 0; run < 1_000_000; run++)
            {
                var die = new GamblersDie(4, 3, 2, 1);
                result[die.Roll() - 1]++;
            }

            var tolerance = Math.Abs(percent - result[side] / 1_000_000D);
            Assert.True(tolerance < 0.001, $"{tolerance} is outside uniformity tolerance of .001");
        }
    }
}
