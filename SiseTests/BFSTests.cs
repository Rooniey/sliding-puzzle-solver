using System;
using DataContract;
using DataContract.Model;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SiseAssignment;

namespace SiseTests
{
    [TestClass]
    public class BFSTests
    {
        private BFSAlgorithm _bfsSolver;

        private readonly MoveDirection[] _priority = new MoveDirection[]
        {
            MoveDirection.Left,
            MoveDirection.Up,
            MoveDirection.Right,
            MoveDirection.Down
        };

        [TestInitialize]
        public void SetUp()
        {
            _bfsSolver = new BFSAlgorithm(_priority);
        }

        [TestMethod]
        public void When_SolvePuzzleCalled_WithTrivialSolution_ShouldReturnCorrectAnswer()
        {
            PuzzleState initState = new PuzzleState(
                dimensionX: 4,
                dimensionY: 4,
                state: new byte[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 0, 15});

            string result = _bfsSolver.SolvePuzzle(initState);

            result.Should().BeEquivalentTo("R");
        }
    }
}