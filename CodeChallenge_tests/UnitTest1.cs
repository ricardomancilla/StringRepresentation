using CodeChallenge.Controllers;
using CodeChallenge.Data;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace CodeChallenge_tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase(21)]
        public void Test21_ResultOk(int number)
        {
            var repository = new Mock<IStringRepresentationRepository>();
            repository.Setup(x => x.Insert(It.IsAny<StringRepresentation>()));
            var controller = new StringRepresentationController(repository.Object);

            var expected = new List<string>{
                "1",
                "2",
                "Fizz",
                "4",
                "Buzz",
                "Fizz",
                "Jazz",
                "8",
                "Fizz",
                "Buzz",
                "11",
                "Fizz",
                "13",
                "Jazz",
                "FizzBuzz",
                "16",
                "17",
                "Fizz",
                "19",
                "Buzz",
                "FizzJazz" };
            var actual = controller.Get(number);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(21)]
        public void Test21_Result13_AreEqual(int number)
        {
            var repository = new Mock<IStringRepresentationRepository>();
            repository.Setup(x => x.Insert(It.IsAny<StringRepresentation>()));
            var controller = new StringRepresentationController(repository.Object);

            var expected = "13";
            var actual = controller.Get(number).ElementAt(12);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(21)]
        public void Test21_Result13_AreDifferent(int number)
        {
            var repository = new Mock<IStringRepresentationRepository>();
            repository.Setup(x => x.Insert(It.IsAny<StringRepresentation>()));
            var controller = new StringRepresentationController(repository.Object);

            var expected = "13";
            var actual = controller.Get(number).ElementAt(13);

            Assert.AreNotEqual(expected, actual);
        }
    }
}