namespace DigitalClock.Circuitry.Tests
{
    [TestClass()]
    public class NotGateTests
    {
        [TestMethod()]
        public void NotGateFTTest()
        {
            NotGate gate = new();
            Assert.IsFalse(gate.Input.State);
            Assert.IsTrue(gate.Output.State);
        }

        [TestMethod()]
        public void NotGateTFTest()
        {
            NotGate gate = new();
            Assert.IsFalse(gate.Input.State);
            Assert.IsTrue(gate.Output.State);

            Board board = new();
            board.Connect(board.Battery.Output, gate.Input);
            Assert.IsTrue(gate.Input.State);
            Assert.IsFalse(gate.Output.State);
        }
    }
}