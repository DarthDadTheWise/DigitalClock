namespace Circuitry.Tests
{
    [TestClass()]
    public class SenaryDigitTests
    {
        [TestMethod()]
        public void SenaryDigitTest()
        {
            Board board = new();
            SenaryDigit digit = new(board);
            ClockGate clock = new();
            board.Connect(clock.Output, digit.Clk);

            // Clk 0: 000
            Assert.IsFalse(digit.Bit2.State);
            Assert.IsFalse(digit.Bit1.State);
            Assert.IsFalse(digit.Bit0.State);

            // Clk 0: 000
            clock.Toggle();
            Assert.IsFalse(digit.Bit2.State);
            Assert.IsFalse(digit.Bit1.State);
            Assert.IsFalse(digit.Bit0.State);

            // Clk 0: 0001
            clock.Toggle();
            Assert.IsFalse(digit.Bit2.State);
            Assert.IsFalse(digit.Bit1.State);
            Assert.IsTrue(digit.Bit0.State);

            // Clk 1: 0001
            clock.Toggle();
            Assert.IsFalse(digit.Bit2.State);
            Assert.IsFalse(digit.Bit1.State);
            Assert.IsTrue(digit.Bit0.State);

            // Clk 0: 0010
            clock.Toggle();
            Assert.IsFalse(digit.Bit2.State);
            Assert.IsTrue(digit.Bit1.State);
            Assert.IsFalse(digit.Bit0.State);

            // Clk 1: 0010
            clock.Toggle();
            Assert.IsFalse(digit.Bit2.State);
            Assert.IsTrue(digit.Bit1.State);
            Assert.IsFalse(digit.Bit0.State);

            // Clk 0: 0011
            clock.Toggle();
            Assert.IsFalse(digit.Bit2.State);
            Assert.IsTrue(digit.Bit1.State);
            Assert.IsTrue(digit.Bit0.State);

            // Clk 1: 0011
            clock.Toggle();
            Assert.IsFalse(digit.Bit2.State);
            Assert.IsTrue(digit.Bit1.State);
            Assert.IsTrue(digit.Bit0.State);

            // Clk 0: 0100
            clock.Toggle();
            Assert.IsTrue(digit.Bit2.State);
            Assert.IsFalse(digit.Bit1.State);
            Assert.IsFalse(digit.Bit0.State);

            // Clk 1: 0100
            clock.Toggle();
            Assert.IsTrue(digit.Bit2.State);
            Assert.IsFalse(digit.Bit1.State);
            Assert.IsFalse(digit.Bit0.State);

            // Clk 0: 0101
            clock.Toggle();
            Assert.IsTrue(digit.Bit2.State);
            Assert.IsFalse(digit.Bit1.State);
            Assert.IsTrue(digit.Bit0.State);

            // Clk 1: 0101
            clock.Toggle();
            Assert.IsTrue(digit.Bit2.State);
            Assert.IsFalse(digit.Bit1.State);
            Assert.IsTrue(digit.Bit0.State);

            // Clk 0: 000
            clock.Toggle();
            Assert.IsFalse(digit.Bit2.State);
            Assert.IsFalse(digit.Bit1.State);
            Assert.IsFalse(digit.Bit0.State);

            // Clk 0: 000
            clock.Toggle();
            Assert.IsFalse(digit.Bit2.State);
            Assert.IsFalse(digit.Bit1.State);
            Assert.IsFalse(digit.Bit0.State);

            // Clk 0: 0001
            clock.Toggle();
            Assert.IsFalse(digit.Bit2.State);
            Assert.IsFalse(digit.Bit1.State);
            Assert.IsTrue(digit.Bit0.State);

            // Clk 1: 0001
            clock.Toggle();
            Assert.IsFalse(digit.Bit2.State);
            Assert.IsFalse(digit.Bit1.State);
            Assert.IsTrue(digit.Bit0.State);

            // Clk 0: 0010
            clock.Toggle();
            Assert.IsFalse(digit.Bit2.State);
            Assert.IsTrue(digit.Bit1.State);
            Assert.IsFalse(digit.Bit0.State);

            // Clk 1: 0010
            clock.Toggle();
            Assert.IsFalse(digit.Bit2.State);
            Assert.IsTrue(digit.Bit1.State);
            Assert.IsFalse(digit.Bit0.State);

            // Clk 0: 0011
            clock.Toggle();
            Assert.IsFalse(digit.Bit2.State);
            Assert.IsTrue(digit.Bit1.State);
            Assert.IsTrue(digit.Bit0.State);

            // Clk 1: 0011
            clock.Toggle();
            Assert.IsFalse(digit.Bit2.State);
            Assert.IsTrue(digit.Bit1.State);
            Assert.IsTrue(digit.Bit0.State);

            // Clk 0: 0100
            clock.Toggle();
            Assert.IsTrue(digit.Bit2.State);
            Assert.IsFalse(digit.Bit1.State);
            Assert.IsFalse(digit.Bit0.State);

            // Clk 1: 0100
            clock.Toggle();
            Assert.IsTrue(digit.Bit2.State);
            Assert.IsFalse(digit.Bit1.State);
            Assert.IsFalse(digit.Bit0.State);

            // Clk 0: 0101
            clock.Toggle();
            Assert.IsTrue(digit.Bit2.State);
            Assert.IsFalse(digit.Bit1.State);
            Assert.IsTrue(digit.Bit0.State);

            // Clk 1: 0101
            clock.Toggle();
            Assert.IsTrue(digit.Bit2.State);
            Assert.IsFalse(digit.Bit1.State);
            Assert.IsTrue(digit.Bit0.State);
        }

        [TestMethod()]
        public void SetTest()
        {
            Board board = new();
            SenaryDigit digit = new(board);
            ClockGate clock = new();
            board.Connect(clock.Output, digit.Clk);

            for (int expected = 0; expected < 6; expected++)
            {
                digit.Set(expected);
                Assert.AreEqual(expected, digit.DecimalValue);
            }
        }
    }
}