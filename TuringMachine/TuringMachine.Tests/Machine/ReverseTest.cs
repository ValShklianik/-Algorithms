using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TuringMachine.Tests.Machine
{
    [TestClass]
    public class ReverseTest
    {
        
        [TestMethod]
        public void ReverseSequence()
        {
            const string expected = "11100";
            var sut = new TuringMachine.Machine(
                0,
                new Head(new[] { '0', '0', '1', '1', '1' }, 0),
                TransitionTableGenerator.Reverse());

            var result = sut.Run();
            Assert.AreEqual(expected, result.Head.ToString());
        }

    }
}