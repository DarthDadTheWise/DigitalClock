namespace DigitalClock.Circuitry.Tests
{
    [TestClass()]
    public class Nand3GateTests
    {
        [TestMethod()]
        public void Nand3GateFFFTest()
        {
            // F and F and F = T
            Board board = new();
            Nand3Gate gate = new(board);
            Assert.IsFalse(gate.Input1.State);
            Assert.IsFalse(gate.Input2.State);
            Assert.IsFalse(gate.Input3.State);
            Assert.IsTrue(gate.Output.State);
        }

        [TestMethod()]
        public void Nand3GateFFTTest()
        {
            Board board = new();
            Nand3Gate gate = new(board);
            Assert.IsFalse(gate.Input1.State);
            Assert.IsFalse(gate.Input2.State);
            Assert.IsFalse(gate.Input3.State);
            Assert.IsTrue(gate.Output.State);

            // F and F and T = T
            board.Connect(board.Battery.Output, gate.Input3);
            Assert.IsFalse(gate.Input1.State);
            Assert.IsFalse(gate.Input2.State);
            Assert.IsTrue(gate.Input3.State);
            Assert.IsTrue(gate.Output.State);
        }

        [TestMethod()]
        public void Nand3GateFTFTest()
        {
            Board board = new();
            Nand3Gate gate = new(board);
            Assert.IsFalse(gate.Input1.State);
            Assert.IsFalse(gate.Input2.State);
            Assert.IsFalse(gate.Input3.State);
            Assert.IsTrue(gate.Output.State);

            // F and T and F = T
            board.Connect(board.Battery.Output, gate.Input2);
            Assert.IsFalse(gate.Input1.State);
            Assert.IsTrue(gate.Input2.State);
            Assert.IsFalse(gate.Input3.State);
            Assert.IsTrue(gate.Output.State);
        }

        [TestMethod()]
        public void Nand3GateFTTTest()
        {
            Board board = new();
            Nand3Gate gate = new(board);
            Assert.IsFalse(gate.Input1.State);
            Assert.IsFalse(gate.Input2.State);
            Assert.IsFalse(gate.Input3.State);
            Assert.IsTrue(gate.Output.State);

            // F and T and T = T
            board.Connect(board.Battery.Output, gate.Input2);
            board.Connect(board.Battery.Output, gate.Input3);
            Assert.IsFalse(gate.Input1.State);
            Assert.IsTrue(gate.Input2.State);
            Assert.IsTrue(gate.Input3.State);
            Assert.IsTrue(gate.Output.State);
        }

        [TestMethod()]
        public void Nand3GateTFFTest()
        {
            Board board = new();
            Nand3Gate gate = new(board);
            Assert.IsFalse(gate.Input1.State);
            Assert.IsFalse(gate.Input2.State);
            Assert.IsFalse(gate.Input3.State);
            Assert.IsTrue(gate.Output.State);

            // T and F and F = T
            board.Connect(board.Battery.Output, gate.Input1);
            Assert.IsTrue(gate.Input1.State);
            Assert.IsFalse(gate.Input2.State);
            Assert.IsFalse(gate.Input3.State);
            Assert.IsTrue(gate.Output.State);
        }

        [TestMethod()]
        public void Nand3GateTFTTest()
        {
            Board board = new();
            Nand3Gate gate = new(board);
            Assert.IsFalse(gate.Input1.State);
            Assert.IsFalse(gate.Input2.State);
            Assert.IsFalse(gate.Input3.State);
            Assert.IsTrue(gate.Output.State);

            // T and F and T = T
            board.Connect(board.Battery.Output, gate.Input1);
            board.Connect(board.Battery.Output, gate.Input3);
            Assert.IsTrue(gate.Input1.State);
            Assert.IsFalse(gate.Input2.State);
            Assert.IsTrue(gate.Input3.State);
            Assert.IsTrue(gate.Output.State);
        }

        [TestMethod()]
        public void Nand3GateTTFTest()
        {
            Board board = new();
            Nand3Gate gate = new(board);
            Assert.IsFalse(gate.Input1.State);
            Assert.IsFalse(gate.Input2.State);
            Assert.IsFalse(gate.Input3.State);
            Assert.IsTrue(gate.Output.State);

            // T and T and F = T
            board.Connect(board.Battery.Output, gate.Input1);
            board.Connect(board.Battery.Output, gate.Input2);
            Assert.IsTrue(gate.Input1.State);
            Assert.IsTrue(gate.Input2.State);
            Assert.IsFalse(gate.Input3.State);
            Assert.IsTrue(gate.Output.State);
        }

        [TestMethod()]
        public void Nand3GateTTTTest()
        {
            Board board = new();
            Nand3Gate gate = new(board);
            Assert.IsFalse(gate.Input1.State);
            Assert.IsFalse(gate.Input2.State);
            Assert.IsFalse(gate.Input3.State);
            Assert.IsTrue(gate.Output.State);

            // T and T and T = F
            board.Connect(board.Battery.Output, gate.Input1);
            board.Connect(board.Battery.Output, gate.Input2);
            board.Connect(board.Battery.Output, gate.Input3);
            Assert.IsTrue(gate.Input1.State);
            Assert.IsTrue(gate.Input2.State);
            Assert.IsTrue(gate.Input3.State);
            Assert.IsFalse(gate.Output.State);
        }
    }
}