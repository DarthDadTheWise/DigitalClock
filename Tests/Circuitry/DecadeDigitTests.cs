namespace DigitalClock.Circuitry.Tests
{
    [TestClass()]
    public class DecadeDigitTests
    {
        [TestMethod()]
        public void DecimalDigitTest()
        {
            Board board = new();
            DecadeDigit digit = new(board);
            ClockGate clock = new();
            board.Connect(clock.Output, digit.Clk);

            // Clk 0: 0000
            Assert.AreEqual(0, digit.DecimalValue);
            Assert.IsFalse(digit.Bit3.State);
            Assert.IsFalse(digit.Bit2.State);
            Assert.IsFalse(digit.Bit1.State);
            Assert.IsFalse(digit.Bit0.State);

            // Clk 1: 0000
            clock.Toggle();
            Assert.AreEqual(0, digit.DecimalValue);
            Assert.IsFalse(digit.Bit3.State);
            Assert.IsFalse(digit.Bit2.State);
            Assert.IsFalse(digit.Bit1.State);
            Assert.IsFalse(digit.Bit0.State);

            // Clk 0: 0001
            clock.Toggle();
            Assert.AreEqual(1, digit.DecimalValue);
            Assert.IsFalse(digit.Bit3.State);
            Assert.IsFalse(digit.Bit2.State);
            Assert.IsFalse(digit.Bit1.State);
            Assert.IsTrue(digit.Bit0.State);

            // Clk 1: 0001
            clock.Toggle();
            Assert.AreEqual(1, digit.DecimalValue);
            Assert.IsFalse(digit.Bit3.State);
            Assert.IsFalse(digit.Bit2.State);
            Assert.IsFalse(digit.Bit1.State);
            Assert.IsTrue(digit.Bit0.State);

            // Clk 0: 0010
            clock.Toggle();
            Assert.AreEqual(2, digit.DecimalValue);
            Assert.IsFalse(digit.Bit3.State);
            Assert.IsFalse(digit.Bit2.State);
            Assert.IsTrue(digit.Bit1.State);
            Assert.IsFalse(digit.Bit0.State);

            // Clk 1: 0010
            clock.Toggle();
            Assert.AreEqual(2, digit.DecimalValue);
            Assert.IsFalse(digit.Bit3.State);
            Assert.IsFalse(digit.Bit2.State);
            Assert.IsTrue(digit.Bit1.State);
            Assert.IsFalse(digit.Bit0.State);

            // Clk 0: 0011
            clock.Toggle();
            Assert.AreEqual(3, digit.DecimalValue);
            Assert.IsFalse(digit.Bit3.State);
            Assert.IsFalse(digit.Bit2.State);
            Assert.IsTrue(digit.Bit1.State);
            Assert.IsTrue(digit.Bit0.State);

            // Clk 1: 0011
            clock.Toggle();
            Assert.AreEqual(3, digit.DecimalValue);
            Assert.IsFalse(digit.Bit3.State);
            Assert.IsFalse(digit.Bit2.State);
            Assert.IsTrue(digit.Bit1.State);
            Assert.IsTrue(digit.Bit0.State);

            // Clk 0: 0100
            clock.Toggle();
            Assert.AreEqual(4, digit.DecimalValue);
            Assert.IsFalse(digit.Bit3.State);
            Assert.IsTrue(digit.Bit2.State);
            Assert.IsFalse(digit.Bit1.State);
            Assert.IsFalse(digit.Bit0.State);

            // Clk 1: 0100
            clock.Toggle();
            Assert.AreEqual(4, digit.DecimalValue);
            Assert.IsFalse(digit.Bit3.State);
            Assert.IsTrue(digit.Bit2.State);
            Assert.IsFalse(digit.Bit1.State);
            Assert.IsFalse(digit.Bit0.State);

            // Clk 0: 0101
            clock.Toggle();
            Assert.AreEqual(5, digit.DecimalValue);
            Assert.IsFalse(digit.Bit3.State);
            Assert.IsTrue(digit.Bit2.State);
            Assert.IsFalse(digit.Bit1.State);
            Assert.IsTrue(digit.Bit0.State);

            // Clk 1: 0101
            clock.Toggle();
            Assert.AreEqual(5, digit.DecimalValue);
            Assert.IsFalse(digit.Bit3.State);
            Assert.IsTrue(digit.Bit2.State);
            Assert.IsFalse(digit.Bit1.State);
            Assert.IsTrue(digit.Bit0.State);

            // Clk 0: 0110
            clock.Toggle();
            Assert.AreEqual(6, digit.DecimalValue);
            Assert.IsFalse(digit.Bit3.State);
            Assert.IsTrue(digit.Bit2.State);
            Assert.IsTrue(digit.Bit1.State);
            Assert.IsFalse(digit.Bit0.State);

            // Clk 1: 0110
            clock.Toggle();
            Assert.AreEqual(6, digit.DecimalValue);
            Assert.IsFalse(digit.Bit3.State);
            Assert.IsTrue(digit.Bit2.State);
            Assert.IsTrue(digit.Bit1.State);
            Assert.IsFalse(digit.Bit0.State);

            // Clk 0: 0111
            clock.Toggle();
            Assert.AreEqual(7, digit.DecimalValue);
            Assert.IsFalse(digit.Bit3.State);
            Assert.IsTrue(digit.Bit2.State);
            Assert.IsTrue(digit.Bit1.State);
            Assert.IsTrue(digit.Bit0.State);

            // Clk 1: 0111
            clock.Toggle();
            Assert.AreEqual(7, digit.DecimalValue);
            Assert.IsFalse(digit.Bit3.State);
            Assert.IsTrue(digit.Bit2.State);
            Assert.IsTrue(digit.Bit1.State);
            Assert.IsTrue(digit.Bit0.State);

            // Clk 0: 1000
            clock.Toggle();
            Assert.AreEqual(8, digit.DecimalValue);
            Assert.IsTrue(digit.Bit3.State);
            Assert.IsFalse(digit.Bit2.State);
            Assert.IsFalse(digit.Bit1.State);
            Assert.IsFalse(digit.Bit0.State);

            // Clk 1: 1000
            clock.Toggle();
            Assert.AreEqual(8, digit.DecimalValue);
            Assert.IsTrue(digit.Bit3.State);
            Assert.IsFalse(digit.Bit2.State);
            Assert.IsFalse(digit.Bit1.State);
            Assert.IsFalse(digit.Bit0.State);

            // Clk 0: 1001
            clock.Toggle();
            Assert.AreEqual(9, digit.DecimalValue);
            Assert.IsTrue(digit.Bit3.State);
            Assert.IsFalse(digit.Bit2.State);
            Assert.IsFalse(digit.Bit1.State);
            Assert.IsTrue(digit.Bit0.State);

            // Clk 1: 1001
            clock.Toggle();
            Assert.AreEqual(9, digit.DecimalValue);
            Assert.IsTrue(digit.Bit3.State);
            Assert.IsFalse(digit.Bit2.State);
            Assert.IsFalse(digit.Bit1.State);
            Assert.IsTrue(digit.Bit0.State);

            // Clk 0: 0000
            clock.Toggle();
            Assert.AreEqual(0, digit.DecimalValue);
            Assert.IsFalse(digit.Bit3.State);
            Assert.IsFalse(digit.Bit2.State);
            Assert.IsFalse(digit.Bit1.State);
            Assert.IsFalse(digit.Bit0.State);

            // Clk 1: 0000
            clock.Toggle();
            Assert.AreEqual(0, digit.DecimalValue);
            Assert.IsFalse(digit.Bit3.State);
            Assert.IsFalse(digit.Bit2.State);
            Assert.IsFalse(digit.Bit1.State);
            Assert.IsFalse(digit.Bit0.State);

            // Clk 0: 0001
            clock.Toggle();
            Assert.AreEqual(1, digit.DecimalValue);
            Assert.IsFalse(digit.Bit3.State);
            Assert.IsFalse(digit.Bit2.State);
            Assert.IsFalse(digit.Bit1.State);
            Assert.IsTrue(digit.Bit0.State);

            // Clk 1: 0001
            clock.Toggle();
            Assert.AreEqual(1, digit.DecimalValue);
            Assert.IsFalse(digit.Bit3.State);
            Assert.IsFalse(digit.Bit2.State);
            Assert.IsFalse(digit.Bit1.State);
            Assert.IsTrue(digit.Bit0.State);
        }

        [TestMethod()]
        public void SetTest()
        {
            Board board = new();
            DecadeDigit digit = new(board);
            ClockGate clock = new();
            board.Connect(clock.Output, digit.Clk);

            for (int expected = 0; expected < 10; expected++)
            {
                digit.Set(expected);
                Assert.AreEqual(expected, digit.DecimalValue);
            }
        }

        [TestMethod()]
        public void ClearTest()
        {
            Board board = new();
            DecadeDigit digit = new(board);
            ClockGate clock = new();
            board.Connect(clock.Output, digit.Clk);
            Assert.AreEqual(0, digit.DecimalValue);

            digit.Set(5);
            Assert.AreEqual(5, digit.DecimalValue);






        }
    }
}