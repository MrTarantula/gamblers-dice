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
        [Trait("Category", "Constructors")]
        public void ConstructFairDie()
        {
            Assert.IsType<FairDie>(new FairDie());
        }

        [Fact]
        [Trait("Category", "Constructors")]
        public void ConstructFairDie_Sides()
        {
            Assert.IsType<FairDie>(new FairDie(6));
        }

        [Fact]
        [Trait("Category", "Constructors")]
        [Trait("Category", "Random")]
        public void ConstructFairDie_Random()
        {
            Assert.IsType<FairDie>(new FairDie(_rnd));
        }

        [Fact]
        [Trait("Category", "Constructors")]
        [Trait("Category", "Random")]
        public void ConstructFairDie_Sides_Random()
        {
            Assert.IsType<FairDie>(new FairDie(_rnd, 6));
        }
    }
}
