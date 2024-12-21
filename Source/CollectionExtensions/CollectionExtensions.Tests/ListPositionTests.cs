using FluentAssertions;

namespace CollectionExtensions.Tests
{
    public class ListPositionTests
    {
        [Fact]
        public void Ensure_IncreaseIndexByOne_MovesItemCorrectly()
        {
            // Arrange
            List<int> data = [1, 2, 3];

            // Act
            data.IncreaseIndexByOne(2);

            // Assert
            data.Should().Equal([1, 3, 2]);
        }

        [Fact]
        public void Ensure_IncreaseIndexByOne_DoesNotMoveOutsideOfBounds()
        {
            // Arrange
            List<int> data = [1, 2, 3];

            // Act
            data.IncreaseIndexByOne(3);

            // Assert
            data.Should().Equal([1, 2, 3]);
        }

        [Fact]
        public void Ensure_ReduceIndexByOne_MovesItemCorrectly()
        {
            // Arrange
            List<int> data = [1, 2, 3];

            // Act
            data.ReduceIndexByOne(2);

            // Assert
            data.Should().Equal([2, 1, 3]);
        }

        [Fact]
        public void Ensure_ReduceIndexByOne_DoesNotMoveOutsideOfBounds()
        {
            // Arrange
            List<int> data = [1, 2, 3];

            // Act
            data.ReduceIndexByOne(1);

            // Assert
            data.Should().Equal([1, 2, 3]);
        }

        [Fact]
        public void Ensure_MoveToStart_MovesItemCorrectly()
        {
            // Arrange
            List<int> data = [1, 2, 3];

            // Act
            data.MoveToStart(3);

            // Assert
            data.Should().Equal([3, 1, 2]);
        }

        [Fact]
        public void Ensure_MoveToEnd_MovesItemCorrectly()
        {
            // Arrange
            List<int> data = [1, 2, 3];

            // Act
            data.MoveToEnd(1);

            // Assert
            data.Should().Equal([2, 3, 1]);
        }

        [Fact]
        public void Ensure_MoveItem_FromLeftToRightOverMultiplePlaces_MovesOtherItemsCorrectly()
        {
            // Arrange
            List<int> data = [1, 2, 3, 4, 5, 6];

            // Act
            data.MoveItem(2, 4);

            // Assert
            data.Should().Equal([1, 3, 4, 5, 2, 6]);
        }

        [Fact]
        public void Ensure_MoveItem_FromRightToLeftOverMultiplePlaces_MovesOtherItemsCorrectly()
        {
            // Arrange
            List<int> data = [1, 2, 3, 4, 5, 6];

            // Act
            data.MoveItem(5, 1);

            // Assert
            data.Should().Equal([1, 5, 2, 3, 4, 6]);
        }

        [Fact]
        public void Ensure_MoveItem_DoesNotMoveItemOutOfBounds()
        {
            // Arrange
            List<int> data = [1, 2, 3, 4, 5, 6];

            // Act
            data.MoveItem(2, 99999);

            // Assert
            data.Should().Equal([1, 2, 3, 4, 5, 6]);
        }

        [Fact]
        public void Ensure_MoveIndex_FromLeftToRightOverMultiplePlaces_MovesOtherItemsCorrectly()
        {
            // Arrange
            List<int> data = [1, 2, 3, 4, 5, 6];

            // Act
            data.MoveIndex(1, 4);

            // Assert
            data.Should().Equal([1, 3, 4, 5, 2, 6]);
        }

        [Fact]
        public void Ensure_MoveIndex_FromRightToLeftOverMultiplePlaces_MovesOtherItemsCorrectly()
        {
            // Arrange
            List<int> data = [1, 2, 3, 4, 5, 6];

            // Act
            data.MoveIndex(4, 1);

            // Assert
            data.Should().Equal([1, 5, 2, 3, 4, 6]);
        }

        [Fact]
        public void Ensure_MoveIndex_DoesNotMoveItemOutOfBounds()
        {
            // Arrange
            List<int> data = [1, 2, 3, 4, 5, 6];

            // Act
            data.MoveIndex(1, 99999);

            // Assert
            data.Should().Equal([1, 2, 3, 4, 5, 6]);
        }
    }
}
