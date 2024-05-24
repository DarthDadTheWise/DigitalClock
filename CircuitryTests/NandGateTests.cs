namespace Circuitry.Tests
{
    [TestClass()]
    public class NandGateTests
    {
        // F F => T
        // F T => T
        // T F => T
        // T T => F

        [TestMethod()]
        public void NandGateFFTest()
        {
            Board board = new();
            NandGate gate = new(board);
            // F and F = T
            Assert.IsFalse(gate.Input1.State);
            Assert.IsFalse(gate.Input2.State);
            Assert.IsTrue(gate.Output.State);
        }

        [TestMethod()]
        public void NandGateTFTest()
        {
            Board board = new();
            NandGate gate = new(board);
            Assert.IsFalse(gate.Input1.State);
            Assert.IsFalse(gate.Input2.State);
            Assert.IsTrue(gate.Output.State);

            // T and F = T
            board.Connect(board.Battery.Output, gate.Input1);
            Assert.IsTrue(gate.Input1.State);
            Assert.IsFalse(gate.Input2.State);
            Assert.IsTrue(gate.Output.State);
        }

        [TestMethod()]
        public void NandGateFTTest()
        {
            Board board = new();
            NandGate gate = new(board);
            Assert.IsFalse(gate.Input1.State);
            Assert.IsFalse(gate.Input2.State);
            Assert.IsTrue(gate.Output.State);

            // F and T = T
            board.Connect(board.Battery.Output, gate.Input2);
            Assert.IsFalse(gate.Input1.State);
            Assert.IsTrue(gate.Input2.State);
            Assert.IsTrue(gate.Output.State);
        }

        [TestMethod()]
        public void NandGateTTTest()
        {
            Board board = new();
            NandGate gate = new(board);
            Assert.IsFalse(gate.Input1.State);
            Assert.IsFalse(gate.Input2.State);
            Assert.IsTrue(gate.Output.State);

            // T and T = F
            board.Connect(board.Battery.Output, gate.Input1);
            board.Connect(board.Battery.Output, gate.Input2);
            Assert.IsTrue(gate.Input1.State);
            Assert.IsTrue(gate.Input2.State);
            Assert.IsFalse(gate.Output.State);
        }
    }
}