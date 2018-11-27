using System;
using System.Collections.Generic;
using DataContract;
using DataContract.Model;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SiseAssignment.Implementations;

namespace SiseTests.AlgorithmTests
{
    [TestClass]
    public class BfsTest
    {
        private BfsAlgorithm _bfs;

        [TestInitialize]
        public void SetUp()
        {
            MoveDirection[] priorityStrategy = new MoveDirection[] { MoveDirection.Left, MoveDirection.Up, MoveDirection.Right, MoveDirection.Down };
            _bfs = new BfsAlgorithm(priorityStrategy);
        }

        [TestMethod]
        public void When_SolveCalled_Should_ReturnCorrectSolvingProcessData()
        {
            PuzzleState initialState = new PuzzleState(4, 4, new byte[]
            {
                1, 2, 3, 4,
                5, 6, 7, 8,
                9, 10, 11, 12,
                13, 14, 0, 15
            });

            SolvingProcessData solutionData = _bfs.SolvePuzzle(initialState);
            
            SolvingProcessData expectedSolutionData = new SolvingProcessData(
                solution: new List<MoveDirection>() {MoveDirection.Right},
                statesVisited:4,
                statesProcessed:9,
                maxDepth:1);

            solutionData.Should().BeEquivalentTo(expectedSolutionData);
        }

    }
}
