namespace Circuitry.Tests
{
    [TestClass()]
    public class WireTests
    {
        [TestMethod()]
        public void WireFFTest()
        {
            Wire gate = new();
            Assert.IsFalse(gate.Input.State);
            Assert.IsFalse(gate.Output.State);
        }

        [TestMethod()]
        public void WireTTTest()
        {
            Wire gate = new();
            Assert.IsFalse(gate.Input.State);
            Assert.IsFalse(gate.Output.State);

            Board board = new();
            board.Connect(board.Battery.Output, gate.Input);
            Assert.IsTrue(gate.Input.State);
            Assert.IsTrue(gate.Output.State);
        }
    }
}