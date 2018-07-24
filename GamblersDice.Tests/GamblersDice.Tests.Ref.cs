using System;
using Xunit;
using GamblersDice;

namespace GamblersDice.Tests
{
    [Trait("Category", "Gamblers")]
    [Trait("Category", "Reference")]
    public class GamblersDieTestsRef
    {
        Random _rnd = new Random();

        [Fact]
        public void ConstructDie() => Assert.IsType<GamblersDie>(new GamblersDie(ref _rnd));

        [Fact]
        public void ConstructDie_Sides() => Assert.IsType<GamblersDie>(new GamblersDie(ref _rnd, 6));

        [Fact]
        public void ConstructDie_Weights() => Assert.IsType<GamblersDie>(new GamblersDie(ref _rnd, 1, 2, 3, 4, 5, 6));

        [Fact]
        public void ConstructDie_Weights_Array() => Assert.IsType<GamblersDie>(new GamblersDie(ref _rnd, new int[] { 1, 2, 3, 4, 5, 6 }));

        [Theory]
        [InlineData(6)]
        [InlineData(20)]
        public void Uniform(int sides)
        {
            var die = new GamblersDie(ref _rnd, sides);
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

        [Theory]
        [InlineData(new int[] { 0, 0, 1, 0, 0, 0 }, 3)]
        [InlineData(new int[] { 0, 0, 0, 0, 1, 0 }, 5)]
        public void NonUniform(int[] weights, int expected) => Assert.Equal(expected, new GamblersDie(ref _rnd, weights).Roll());

        [Fact]
        public void NonUniform_Inferred()
        {
            // Given this state, [4,3,2,1]
            // 1 should be rolled 40% of the time
            // 2 should be rolled 30% of the time
            // 3 should be rolled 20% of the time
            // 4 should be rolled 10% of the time

            decimal iters = 100_000_000M;
            int[] result = new int[] { 0, 0, 0, 0 };

            for (int run = 0; run < iters; run++)
            {
                var die = new GamblersDie(ref _rnd, 4, 3, 2, 1);
                result[die.Roll() - 1]++;
            }

            Assert.True(Math.Abs(0.4M - result[0] / iters) < 0.001M, $"Side one is outside of uniformity tolerance: {Math.Abs(0.4M - result[0] / iters)}");
            Assert.True(Math.Abs(0.3M - result[1] / iters) < 0.001M, $"Side two is outside of uniformity tolerance: {Math.Abs(0.3M - result[1] / iters)}");
            Assert.True(Math.Abs(0.2M - result[2] / iters) < 0.001M, $"Side three is outside of uniformity tolerance: {Math.Abs(0.2M - result[2] / iters)}");
            Assert.True(Math.Abs(0.1M - result[3] / iters) < 0.001M, $"Side four is outside of uniformity tolerance: {Math.Abs(0.1M - result[3] / iters)}");
        }
    }
}