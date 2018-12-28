namespace Database.Tests
{
    using System;
    using System.Linq;
    using System.Reflection;
    using NUnit.Framework;

    [TestFixture]
    public class DbTests
    {
        [Test]
        public void EmptyConstructorShouldInitData()
        {
            // Arrange
            Database db = new Database();
            Type type = typeof(Database);

            // Act
            var expectedValue = 16;
            var actualValue = ((int[])type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .FirstOrDefault(x => x.Name == "data")
                .GetValue(db)).Length;

            // Assert
            Assert.That(actualValue, Is.EqualTo(expectedValue), "Internal Array is not initialized properly.");
        }

        [Test]
        public void EmptyConstructorShouldInitIndexToMinusOne()
        {
            // Arrange
            Database db = new Database();
            Type type = typeof(Database);

            // Act
            var expectedValue = -1;
            var actualValue = ((int)type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .FirstOrDefault(x => x.Name == "index")
                .GetValue(db));

            // Assert
            Assert.That(actualValue, Is.EqualTo(expectedValue));
        }

        [Test]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, })]
        [TestCase(new int[] { 1 })]
        public void ConstructorShouldIniIndexToArrayLength(int[] values)
        {
            // Arrange
            Database db = new Database(values);
            Type type = typeof(Database);

            // Act
            var expectedSize = values.Length - 1;
            var actualSize = (int)type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .FirstOrDefault(x => x.Name == "index")
                .GetValue(db);

            // Assert
            Assert.AreEqual(expectedSize, actualSize);
        }

        [Test]
        public void ConstructorShuldThrowInvalidOperationExArrayBiggerThanSixteen()
        {
            int[] values = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17 };

            Assert.Throws<InvalidOperationException>(() => new Database(values));
        }

        [Test]
        public void AddShouldThrowInvalidOperationExIfDbIsFull()
        {
            // Arrange
            int[] values = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };
            Database db = new Database(values);

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => db.Add(1));
        }

        [Test]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 })]
        [TestCase(new int[] { 1 })]
        [TestCase(new int[] { })]
        public void AddMethodShouldMoveIndexCorrectly(int[] values)
        {
            // Arrange
            Database db = new Database(values);
            Type type = typeof(Database);

            // Act
            int expectedIndex = values.Length;

            db.Add(50);


            int index = (int)type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .First(x => x.Name == "index")
                .GetValue(db);


            // Assert
            Assert.That(index, Is.EqualTo(expectedIndex));
        }
    }
}
