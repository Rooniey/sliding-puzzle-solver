using System;
using System.Collections.Generic;
using DataContract;
using DataContract.Model;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SiseTests
{
    [TestClass]
    public class PuzzleStateModelTests
    {
        private readonly byte[] _sampleState = new byte[]
        {
            9, 3, 4, 0,
            2, 1, 5, 8,
            6, 10, 12, 7,
            13, 11, 14, 15
        };

        private readonly byte[] _solvedState = new byte[]
        {
            1, 2, 3, 4,
            5, 6, 7, 8,
            9, 10, 11, 12,
            13, 14, 15, 0
        };

        private readonly byte _dimensionX = 4;
        private readonly byte _dimensionY = 4;

        private PuzzleState _samplePuzzleState;
        private PuzzleState _solvedPuzzleState;

        [TestInitialize]
        public void SetUp()
        {
            _samplePuzzleState = new PuzzleState(_dimensionX, _dimensionY, _sampleState);
            _solvedPuzzleState = new PuzzleState(_dimensionX, _dimensionY, _solvedState);
        }

        [TestMethod]
        public void When_PublicConstructorCalled_Should_SetPropertiesToCorrectValues()
        {
            PuzzleState testState = new PuzzleState(_dimensionX, _dimensionY, _sampleState);

            testState.LastMove.Should().Be(MoveDirection.None);
            testState.Path.Should().BeEmpty();
            testState.PathLength.Should().Be(0);
            testState.ZeroIndex.Should().Be(3);
        }

        [TestMethod]
        public void
            When_MoveCalled_With_PossibleMove_Should_CreateNewInstanceOfPuzzleState_With_CorrectValuesOfProperties()
        {
            PuzzleState movedState = _samplePuzzleState.Move(MoveDirection.Down);

            movedState.LastMove.Should().Be(MoveDirection.Down);
            movedState.Path.Should().BeEquivalentTo(new List<MoveDirection>() {MoveDirection.Down});
            movedState.PathLength.Should().Be(1);
            movedState.ZeroIndex.Should().Be(7);
            movedState.State.Should().BeEquivalentTo(new byte[]
            {
                9, 3, 4, 8,
                2, 1, 5, 0,
                6, 10, 12, 7,
                13, 11, 14, 15
            });
        }

        [TestMethod]
        public void
            When_ConsecutiveMoveCalled_With_PossibleMove_Should_CreateNewInstanceOfPuzzleState_With_CorrectValuesOfProperties()
        {
            PuzzleState movedState = _samplePuzzleState
                .Move(MoveDirection.Down)
                .Move(MoveDirection.Left)
                .Move(MoveDirection.Down)
                .Move(MoveDirection.Right);

            movedState.LastMove.Should().Be(MoveDirection.Right);
            movedState.Path.Should().BeEquivalentTo(new List<MoveDirection>()
            {
                MoveDirection.Down,
                MoveDirection.Left,
                MoveDirection.Down,
                MoveDirection.Right
            }, options => options.WithStrictOrdering());
            movedState.PathLength.Should().Be(4);
            movedState.ZeroIndex.Should().Be(11);
            movedState.State.Should().BeEquivalentTo(new byte[]
            {
                9, 3, 4, 8,
                2, 1, 12, 5,
                6, 10, 7, 0,
                13, 11, 14, 15
            });
        }

        [TestMethod]
        public void When_IsSolvedCalled_With_NotSolvedPuzzleState_Should_ReturnFalse()
        {
            _samplePuzzleState.IsSolved().Should().BeFalse();
        }

        [TestMethod]
        public void When_IsSolvedCalled_With_SolvedPuzzleState_Should_ReturnTrue()
        {
            _solvedPuzzleState.IsSolved().Should().BeTrue();
        }

        [TestMethod]
        public void When_PossibleMovesCalled_Should_ReturnProperListOfPossibleMoves()
        {
            _samplePuzzleState.PossibleMoves().Should().BeEquivalentTo(
                new List<MoveDirection>()
                {
                    MoveDirection.Left,
                    MoveDirection.Down
                });
        }
    }
}