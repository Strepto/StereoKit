using FluentAssertions;
using System;
using Xunit;

namespace StereoKit.UnitTests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            SKMath.AngleDist(3, 10)
                .Should().Be(7);
        }

    }
}