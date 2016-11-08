using System;
using System.IO;
using Xunit;

namespace Trivia
{
    public class ExperimentsTests
    {
        [Fact]
        public void Blah()
        {
            using (var writer = File.CreateText("output1.txt"))
            {
                Console.SetOut(writer);
                var runner = new TestableGameRunner(7);
                runner.Run();
            }
        }

        class TestableGameRunner : GameRunner
        {
            readonly Int32 seed;

            public TestableGameRunner(Int32 seed)
            {
                this.seed = seed;
            }

            protected override Random CreateRandom()
            {
                return new Random(seed);
            }
        }
    }
}