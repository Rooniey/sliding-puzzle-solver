using System.Collections.Generic;
using DataContract;
using DataContract.Model;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SiseAssignment.Implementations;

namespace SiseTests.AlgorithmTests
{
    [TestClass]
    public class DfsTest
    {
        private DfsAlgorithm _dfs;

        [TestInitialize]
        public void SetUp()
        {
            int maxDepth = 2;
            MoveDirection[] priorityStrategy = new[] { MoveDirection.Down, MoveDirection.Left, MoveDirection.Up, MoveDirection.Right };
            
            _dfs = new DfsAlgorithm(priorityStrategy, maxDepth);
        }

        [TestMethod]
        public void When_SolveCalled_Should_ReturnCorrectSolvingProcessData()
        {
            PuzzleState initialState = new PuzzleState(4, 4, new byte[]
            {
                1, 2, 3, 4,
                5, 6, 7, 8,
                9, 10, 0, 12,
                13, 14, 11, 15
            });

            SolvingProcessData solutionData = _dfs.SolvePuzzle(initialState);

            SolvingProcessData expectedSolutionData = new SolvingProcessData(
                solution: new List<MoveDirection>() { MoveDirection.Down, MoveDirection.Right },
                statesVisited: 4,
                statesProcessed: 7,
                maxDepth: 2);

            solutionData.Should().BeEquivalentTo(expectedSolutionData);
        }

    }
}
