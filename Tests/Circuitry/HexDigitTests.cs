namespace DigitalClock.Circuitry.Tests
{
    [TestClass()]
    public class HexDigitTests
    {
        [TestMethod()]
        public void HexDigitTest()
        {
            Board board = new();
            HexDigit digit = new(board);
            ClockGate clock = new();
            board.Connect(clock.Output, digit.Clk);

            // Clk 0: 0000
            Assert.IsFalse(digit.Bit3);
            Assert.IsFalse(digit.Bit2);
            Assert.IsFalse(digit.Bit1);
            Assert.IsFalse(digit.Bit0);

            // Clk 0: 0000
            clock.Toggle();
            Assert.IsFalse(digit.Bit3);
            Assert.IsFalse(digit.Bit2);
            Assert.IsFalse(digit.Bit1);
            Assert.IsFalse(digit.Bit0);

            // Clk 0: 0001
            clock.Toggle();
            Assert.IsFalse(digit.Bit3);
            Assert.IsFalse(digit.Bit2);
            Assert.IsFalse(digit.Bit1);
            Assert.IsTrue(digit.Bit0);

            // Clk 1: 0001
            clock.Toggle();
            Assert.IsFalse(digit.Bit3);
            Assert.IsFalse(digit.Bit2);
            Assert.IsFalse(digit.Bit1);
            Assert.IsTrue(digit.Bit0);

            // Clk 0: 0010
            clock.Toggle();
            Assert.IsFalse(digit.Bit3);
            Assert.IsFalse(digit.Bit2);
            Assert.IsTrue(digit.Bit1);
            Assert.IsFalse(digit.Bit0);

            // Clk 1: 0010
            clock.Toggle();
            Assert.IsFalse(digit.Bit3);
            Assert.IsFalse(digit.Bit2);
            Assert.IsTrue(digit.Bit1);
            Assert.IsFalse(digit.Bit0);

            // Clk 0: 0011
            clock.Toggle();
            Assert.IsFalse(digit.Bit3);
            Assert.IsFalse(digit.Bit2);
            Assert.IsTrue(digit.Bit1);
            Assert.IsTrue(digit.Bit0);

            // Clk 1: 0011
            clock.Toggle();
            Assert.IsFalse(digit.Bit3);
            Assert.IsFalse(digit.Bit2);
            Assert.IsTrue(digit.Bit1);
            Assert.IsTrue(digit.Bit0);

            // Clk 0: 0100
            clock.Toggle();
            Assert.IsFalse(digit.Bit3);
            Assert.IsTrue(digit.Bit2);
            Assert.IsFalse(digit.Bit1);
            Assert.IsFalse(digit.Bit0);

            // Clk 1: 0100
            clock.Toggle();
            Assert.IsFalse(digit.Bit3);
            Assert.IsTrue(digit.Bit2);
            Assert.IsFalse(digit.Bit1);
            Assert.IsFalse(digit.Bit0);

            // Clk 0: 0101
            clock.Toggle();
            Assert.IsFalse(digit.Bit3);
            Assert.IsTrue(digit.Bit2);
            Assert.IsFalse(digit.Bit1);
            Assert.IsTrue(digit.Bit0);

            // Clk 1: 0101
            clock.Toggle();
            Assert.IsFalse(digit.Bit3);
            Assert.IsTrue(digit.Bit2);
            Assert.IsFalse(digit.Bit1);
            Assert.IsTrue(digit.Bit0);

            // Clk 0: 0110
            clock.Toggle();
            Assert.IsFalse(digit.Bit3);
            Assert.IsTrue(digit.Bit2);
            Assert.IsTrue(digit.Bit1);
            Assert.IsFalse(digit.Bit0);

            // Clk 1: 0110
            clock.Toggle();
            Assert.IsFalse(digit.Bit3);
            Assert.IsTrue(digit.Bit2);
            Assert.IsTrue(digit.Bit1);
            Assert.IsFalse(digit.Bit0);

            // Clk 0: 0111
            clock.Toggle();
            Assert.IsFalse(digit.Bit3);
            Assert.IsTrue(digit.Bit2);
            Assert.IsTrue(digit.Bit1);
            Assert.IsTrue(digit.Bit0);

            // Clk 1: 0111
            clock.Toggle();
            Assert.IsFalse(digit.Bit3);
            Assert.IsTrue(digit.Bit2);
            Assert.IsTrue(digit.Bit1);
            Assert.IsTrue(digit.Bit0);

            // Clk 0: 1000
            clock.Toggle();
            Assert.IsTrue(digit.Bit3);
            Assert.IsFalse(digit.Bit2);
            Assert.IsFalse(digit.Bit1);
            Assert.IsFalse(digit.Bit0);

            // Clk 1: 1000
            clock.Toggle();
            Assert.IsTrue(digit.Bit3);
            Assert.IsFalse(digit.Bit2);
            Assert.IsFalse(digit.Bit1);
            Assert.IsFalse(digit.Bit0);

            // Clk 0: 1001
            clock.Toggle();
            Assert.IsTrue(digit.Bit3);
            Assert.IsFalse(digit.Bit2);
            Assert.IsFalse(digit.Bit1);
            Assert.IsTrue(digit.Bit0);

            // Clk 1: 1001
            clock.Toggle();
            Assert.IsTrue(digit.Bit3);
            Assert.IsFalse(digit.Bit2);
            Assert.IsFalse(digit.Bit1);
            Assert.IsTrue(digit.Bit0);

            // Clk 0: 1010
            clock.Toggle();
            Assert.IsTrue(digit.Bit3);
            Assert.IsFalse(digit.Bit2);
            Assert.IsTrue(digit.Bit1);
            Assert.IsFalse(digit.Bit0);

            // Clk 1: 1010
            clock.Toggle();
            Assert.IsTrue(digit.Bit3);
            Assert.IsFalse(digit.Bit2);
            Assert.IsTrue(digit.Bit1);
            Assert.IsFalse(digit.Bit0);

            // Clk 0: 1011
            clock.Toggle();
            Assert.IsTrue(digit.Bit3);
            Assert.IsFalse(digit.Bit2);
            Assert.IsTrue(digit.Bit1);
            Assert.IsTrue(digit.Bit0);

            // Clk 1: 1011
            clock.Toggle();
            Assert.IsTrue(digit.Bit3);
            Assert.IsFalse(digit.Bit2);
            Assert.IsTrue(digit.Bit1);
            Assert.IsTrue(digit.Bit0);

            // Clk 0: 1100
            clock.Toggle();
            Assert.IsTrue(digit.Bit3);
            Assert.IsTrue(digit.Bit2);
            Assert.IsFalse(digit.Bit1);
            Assert.IsFalse(digit.Bit0);

            // Clk 1: 1100
            clock.Toggle();
            Assert.IsTrue(digit.Bit3);
            Assert.IsTrue(digit.Bit2);
            Assert.IsFalse(digit.Bit1);
            Assert.IsFalse(digit.Bit0);

            // Clk 0: 1101
            clock.Toggle();
            Assert.IsTrue(digit.Bit3);
            Assert.IsTrue(digit.Bit2);
            Assert.IsFalse(digit.Bit1);
            Assert.IsTrue(digit.Bit0);

            // Clk 1: 1101
            clock.Toggle();
            Assert.IsTrue(digit.Bit3);
            Assert.IsTrue(digit.Bit2);
            Assert.IsFalse(digit.Bit1);
            Assert.IsTrue(digit.Bit0);

            // Clk 0: 1110
            clock.Toggle();
            Assert.IsTrue(digit.Bit3);
            Assert.IsTrue(digit.Bit2);
            Assert.IsTrue(digit.Bit1);
            Assert.IsFalse(digit.Bit0);

            // Clk 1: 1110
            clock.Toggle();
            Assert.IsTrue(digit.Bit3);
            Assert.IsTrue(digit.Bit2);
            Assert.IsTrue(digit.Bit1);
            Assert.IsFalse(digit.Bit0);

            // Clk 0: 1111
            clock.Toggle();
            Assert.IsTrue(digit.Bit3);
            Assert.IsTrue(digit.Bit2);
            Assert.IsTrue(digit.Bit1);
            Assert.IsTrue(digit.Bit0);

            // Clk 1: 1111
            clock.Toggle();
            Assert.IsTrue(digit.Bit3);
            Assert.IsTrue(digit.Bit2);
            Assert.IsTrue(digit.Bit1);
            Assert.IsTrue(digit.Bit0);

            // Clk 0: 0000
            clock.Toggle();
            Assert.IsFalse(digit.Bit3);
            Assert.IsFalse(digit.Bit2);
            Assert.IsFalse(digit.Bit1);
            Assert.IsFalse(digit.Bit0);

            // Clk 1: 0000
            clock.Toggle();
            Assert.IsFalse(digit.Bit3);
            Assert.IsFalse(digit.Bit2);
            Assert.IsFalse(digit.Bit1);
            Assert.IsFalse(digit.Bit0);

            // Clk 0: 0001
            clock.Toggle();
            Assert.IsFalse(digit.Bit3);
            Assert.IsFalse(digit.Bit2);
            Assert.IsFalse(digit.Bit1);
            Assert.IsTrue(digit.Bit0);

            // Clk 1: 0001
            clock.Toggle();
            Assert.IsFalse(digit.Bit3);
            Assert.IsFalse(digit.Bit2);
            Assert.IsFalse(digit.Bit1);
            Assert.IsTrue(digit.Bit0);
        }
    }
}