using DataContract.Model;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SiseAssignment.Heuristics;
using SiseAssignment.Implementations;

namespace SiseTests.HeuristicTests
{
    [TestClass]
    public class HammingHeuristicTests
    {
        private HammingsHeuristic _hammingHeuristic;

        [TestInitialize]
        public void SetUp()
        {
            _hammingHeuristic = new HammingsHeuristic();
        }

        [TestMethod]
        public void When_CalculateHeuristicCalled_WithValidState_ShouldReturnCorrectValue()
        {
            byte[] state = new byte[]
            {
                9, 3, 4, 0,
                2, 1, 5, 8,
                6, 10, 12, 7,
                13, 11, 14, 15
            };

            PuzzleState puzzState = new PuzzleState(4, 4, state);
            _hammingHeuristic.CalculateHeuristic(puzzState).Should().Be(13);
        }
    }
}