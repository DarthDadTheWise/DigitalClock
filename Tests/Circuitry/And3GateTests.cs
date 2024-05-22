namespace DigitalClock.Circuitry.Tests
{
    [TestClass()]
    public class And3GateTests
    {
        [TestMethod()]
        public void AndGateFFFTest()
        {
            // F and F and F = F
            And3Gate gate = new();
            Assert.IsFalse(gate.Input1.State);
            Assert.IsFalse(gate.Input2.State);
            Assert.IsFalse(gate.Input3.State);
            Assert.IsFalse(gate.Output.State);
        }

        [TestMethod()]
        public void AndGateFFTTest()
        {
            And3Gate gate = new();
            Assert.IsFalse(gate.Input1.State);
            Assert.IsFalse(gate.Input2.State);
            Assert.IsFalse(gate.Input3.State);
            Assert.IsFalse(gate.Output.State);

            // F and F and T = F
            Board board = new();
            board.Connect(board.Battery.Output, gate.Input3);
            Assert.IsFalse(gate.Input1.State);
            Assert.IsFalse(gate.Input2.State);
            Assert.IsTrue(gate.Input3.State);
            Assert.IsFalse(gate.Output.State);
        }

        [TestMethod()]
        public void AndGateFTFTest()
        {
            And3Gate gate = new();
            Assert.IsFalse(gate.Input1.State);
            Assert.IsFalse(gate.Input2.State);
            Assert.IsFalse(gate.Input3.State);
            Assert.IsFalse(gate.Output.State);

            // F and T and F = F
            Board board = new();
            board.Connect(board.Battery.Output, gate.Input2);
            Assert.IsFalse(gate.Input1.State);
            Assert.IsTrue(gate.Input2.State);
            Assert.IsFalse(gate.Input3.State);
            Assert.IsFalse(gate.Output.State);
        }

        [TestMethod()]
        public void AndGateFTTTest()
        {
            And3Gate gate = new();
            Assert.IsFalse(gate.Input1.State);
            Assert.IsFalse(gate.Input2.State);
            Assert.IsFalse(gate.Input3.State);
            Assert.IsFalse(gate.Output.State);

            // F and T and T = F
            Board board = new();
            board.Connect(board.Battery.Output, gate.Input2);
            board.Connect(board.Battery.Output, gate.Input3);
            Assert.IsFalse(gate.Input1.State);
            Assert.IsTrue(gate.Input2.State);
            Assert.IsTrue(gate.Input3.State);
            Assert.IsFalse(gate.Output.State);
        }

        [TestMethod()]
        public void AndGateTFFTest()
        {
            And3Gate gate = new();
            Assert.IsFalse(gate.Input1.State);
            Assert.IsFalse(gate.Input2.State);
            Assert.IsFalse(gate.Input3.State);
            Assert.IsFalse(gate.Output.State);

            // T and F and F = F
            Board board = new();
            board.Connect(board.Battery.Output, gate.Input1);
            Assert.IsTrue(gate.Input1.State);
            Assert.IsFalse(gate.Input2.State);
            Assert.IsFalse(gate.Input3.State);
            Assert.IsFalse(gate.Output.State);
        }

        [TestMethod()]
        public void AndGateTFTTest()
        {
            And3Gate gate = new();
            Assert.IsFalse(gate.Input1.State);
            Assert.IsFalse(gate.Input2.State);
            Assert.IsFalse(gate.Input3.State);
            Assert.IsFalse(gate.Output.State);

            // T and F and T = F
            Board board = new();
            board.Connect(board.Battery.Output, gate.Input1);
            board.Connect(board.Battery.Output, gate.Input3);
            Assert.IsTrue(gate.Input1.State);
            Assert.IsFalse(gate.Input2.State);
            Assert.IsTrue(gate.Input3.State);
            Assert.IsFalse(gate.Output.State);
        }

        [TestMethod()]
        public void AndGateTTFTest()
        {
            And3Gate gate = new();
            Assert.IsFalse(gate.Input1.State);
            Assert.IsFalse(gate.Input2.State);
            Assert.IsFalse(gate.Input3.State);
            Assert.IsFalse(gate.Output.State);

            // T and T and F = F
            Board board = new();
            board.Connect(board.Battery.Output, gate.Input1);
            board.Connect(board.Battery.Output, gate.Input2);
            Assert.IsTrue(gate.Input1.State);
            Assert.IsTrue(gate.Input2.State);
            Assert.IsFalse(gate.Input3.State);
            Assert.IsFalse(gate.Output.State);
        }

        [TestMethod()]
        public void AndGateTTTTest()
        {
            And3Gate gate = new();
            Assert.IsFalse(gate.Input1.State);
            Assert.IsFalse(gate.Input2.State);
            Assert.IsFalse(gate.Input3.State);
            Assert.IsFalse(gate.Output.State);

            // T and T and T = T
            Board board = new();
            board.Connect(board.Battery.Output, gate.Input1);
            board.Connect(board.Battery.Output, gate.Input2);
            board.Connect(board.Battery.Output, gate.Input3);
            Assert.IsTrue(gate.Input1.State);
            Assert.IsTrue(gate.Input2.State);
            Assert.IsTrue(gate.Input3.State);
            Assert.IsTrue(gate.Output.State);
        }
    }
}