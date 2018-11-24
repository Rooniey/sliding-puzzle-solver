using System;
using System.Collections.Generic;
using DataContract;
using DataContract.Model;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SiseAssignment;
using SiseAssignment.Implementations;

namespace SiseTests
{
    [TestClass]
    public class DFSTests
    {
        private DfsAlgorithm _dfsSolver;

        private readonly MoveDirection[] _priority = new MoveDirection[]
        {
            MoveDirection.Right,
            MoveDirection.Up,
            MoveDirection.Left,
            MoveDirection.Down
        };

        [TestInitialize]
        public void SetUp()
        {
            _dfsSolver = new DfsAlgorithm(_priority, 20);
        }

        [TestMethod]
        public void When_SolvePuzzleCalled_WithTrivialSolution_ShouldReturnCorrectAnswer()
        {
            PuzzleState initState = new PuzzleState(
                dimensionX: 4,
                dimensionY: 4,
                state: new byte[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 0, 15});

            SolvingProcessData result = _dfsSolver.SolvePuzzle(initState);

            result.Solution.Should().BeEquivalentTo(new List<MoveDirection>() {MoveDirection.Right});
        }
    }
}