
namespace AoC2018.Test
{
    using System;
    using System.Collections.Generic;
    using AoC2018.Lib;
    using Xunit;

    public class Day03ClaimTest
    {
        [Theory]
        [InlineData("#1 @ 1,3: 4x4", "#1 @ 1,3: 4x4")]
        [InlineData("#2 @ 3,1: 4x4", "#2 @ 3,1: 4x4")]
        [InlineData("#3 @ 5,5: 2x2", "#3 @ 5,5: 2x2")]
        public void TestChecksum(string input, string should)
        {
            Day03.Claim claim = new Day03.Claim(input);

            Assert.Equal(should, claim.ToString());
        }

        [Fact]
        public void TestOverlap() {
            Day03.Claim claim1 = new Day03.Claim("#1 @ 1,3: 4x4");
            Day03.Claim claim2 = new Day03.Claim("#2 @ 3,1: 4x4");
            Day03.Claim claim3 = new Day03.Claim("#3 @ 5,5: 2x2");

            HashSet<Tuple<int, int>> o1 = claim1.Overlap(claim3);

            Assert.Empty(o1);

            HashSet<Tuple<int, int>> o2 = claim1.Overlap(claim2);

            Assert.Equal(4, o2.Count);

            HashSet<Tuple<int, int>> o3 = claim2.Overlap(claim1);

            Assert.Equal(4, o3.Count);
        }



    }
}
