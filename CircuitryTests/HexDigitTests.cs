namespace Circuitry.Tests;

[TestClass()]
public class HexDigitTests
{
    [TestMethod()]
    public void HexDigitTest()
    {
        Board board = new();
        HexCounter digit = new(board);
        ClockGate clock = new();
        board.Connect(clock.Output, digit.Clk);

        // Clk 0: 0000
        Assert.AreEqual(0, digit.DisplayValue);
        Assert.IsFalse(digit.Bit3.State);
        Assert.IsFalse(digit.Bit2.State);
        Assert.IsFalse(digit.Bit1.State);
        Assert.IsFalse(digit.Bit0.State);

        // Clk 0: 0000
        clock.Toggle();
        Assert.AreEqual(0, digit.DisplayValue);
        Assert.IsFalse(digit.Bit3.State);
        Assert.IsFalse(digit.Bit2.State);
        Assert.IsFalse(digit.Bit1.State);
        Assert.IsFalse(digit.Bit0.State);

        // Clk 0: 0001
        clock.Toggle();
        Assert.AreEqual(1, digit.DisplayValue);
        Assert.IsFalse(digit.Bit3.State);
        Assert.IsFalse(digit.Bit2.State);
        Assert.IsFalse(digit.Bit1.State);
        Assert.IsTrue(digit.Bit0.State);

        // Clk 1: 0001
        clock.Toggle();
        Assert.AreEqual(1, digit.DisplayValue);
        Assert.IsFalse(digit.Bit3.State);
        Assert.IsFalse(digit.Bit2.State);
        Assert.IsFalse(digit.Bit1.State);
        Assert.IsTrue(digit.Bit0.State);

        // Clk 0: 0010
        clock.Toggle();
        Assert.AreEqual(2, digit.DisplayValue);
        Assert.IsFalse(digit.Bit3.State);
        Assert.IsFalse(digit.Bit2.State);
        Assert.IsTrue(digit.Bit1.State);
        Assert.IsFalse(digit.Bit0.State);

        // Clk 1: 0010
        clock.Toggle();
        Assert.AreEqual(2, digit.DisplayValue);
        Assert.IsFalse(digit.Bit3.State);
        Assert.IsFalse(digit.Bit2.State);
        Assert.IsTrue(digit.Bit1.State);
        Assert.IsFalse(digit.Bit0.State);

        // Clk 0: 0011
        clock.Toggle();
        Assert.AreEqual(3, digit.DisplayValue);
        Assert.IsFalse(digit.Bit3.State);
        Assert.IsFalse(digit.Bit2.State);
        Assert.IsTrue(digit.Bit1.State);
        Assert.IsTrue(digit.Bit0.State);

        // Clk 1: 0011
        clock.Toggle();
        Assert.AreEqual(3, digit.DisplayValue);
        Assert.IsFalse(digit.Bit3.State);
        Assert.IsFalse(digit.Bit2.State);
        Assert.IsTrue(digit.Bit1.State);
        Assert.IsTrue(digit.Bit0.State);

        // Clk 0: 0100
        clock.Toggle();
        Assert.AreEqual(4, digit.DisplayValue);
        Assert.IsFalse(digit.Bit3.State);
        Assert.IsTrue(digit.Bit2.State);
        Assert.IsFalse(digit.Bit1.State);
        Assert.IsFalse(digit.Bit0.State);

        // Clk 1: 0100
        clock.Toggle();
        Assert.AreEqual(4, digit.DisplayValue);
        Assert.IsFalse(digit.Bit3.State);
        Assert.IsTrue(digit.Bit2.State);
        Assert.IsFalse(digit.Bit1.State);
        Assert.IsFalse(digit.Bit0.State);

        // Clk 0: 0101
        clock.Toggle();
        Assert.AreEqual(5, digit.DisplayValue);
        Assert.IsFalse(digit.Bit3.State);
        Assert.IsTrue(digit.Bit2.State);
        Assert.IsFalse(digit.Bit1.State);
        Assert.IsTrue(digit.Bit0.State);

        // Clk 1: 0101
        clock.Toggle();
        Assert.AreEqual(5, digit.DisplayValue);
        Assert.IsFalse(digit.Bit3.State);
        Assert.IsTrue(digit.Bit2.State);
        Assert.IsFalse(digit.Bit1.State);
        Assert.IsTrue(digit.Bit0.State);

        // Clk 0: 0110
        clock.Toggle();
        Assert.AreEqual(6, digit.DisplayValue);
        Assert.IsFalse(digit.Bit3.State);
        Assert.IsTrue(digit.Bit2.State);
        Assert.IsTrue(digit.Bit1.State);
        Assert.IsFalse(digit.Bit0.State);

        // Clk 1: 0110
        clock.Toggle();
        Assert.AreEqual(6, digit.DisplayValue);
        Assert.IsFalse(digit.Bit3.State);
        Assert.IsTrue(digit.Bit2.State);
        Assert.IsTrue(digit.Bit1.State);
        Assert.IsFalse(digit.Bit0.State);

        // Clk 0: 0111
        clock.Toggle();
        Assert.AreEqual(7, digit.DisplayValue);
        Assert.IsFalse(digit.Bit3.State);
        Assert.IsTrue(digit.Bit2.State);
        Assert.IsTrue(digit.Bit1.State);
        Assert.IsTrue(digit.Bit0.State);

        // Clk 1: 0111
        clock.Toggle();
        Assert.AreEqual(7, digit.DisplayValue);
        Assert.IsFalse(digit.Bit3.State);
        Assert.IsTrue(digit.Bit2.State);
        Assert.IsTrue(digit.Bit1.State);
        Assert.IsTrue(digit.Bit0.State);

        // Clk 0: 1000
        clock.Toggle();
        Assert.AreEqual(8, digit.DisplayValue);
        Assert.IsTrue(digit.Bit3.State);
        Assert.IsFalse(digit.Bit2.State);
        Assert.IsFalse(digit.Bit1.State);
        Assert.IsFalse(digit.Bit0.State);

        // Clk 1: 1000
        clock.Toggle();
        Assert.AreEqual(8, digit.DisplayValue);
        Assert.IsTrue(digit.Bit3.State);
        Assert.IsFalse(digit.Bit2.State);
        Assert.IsFalse(digit.Bit1.State);
        Assert.IsFalse(digit.Bit0.State);

        // Clk 0: 1001
        clock.Toggle();
        Assert.AreEqual(9, digit.DisplayValue);
        Assert.IsTrue(digit.Bit3.State);
        Assert.IsFalse(digit.Bit2.State);
        Assert.IsFalse(digit.Bit1.State);
        Assert.IsTrue(digit.Bit0.State);

        // Clk 1: 1001
        clock.Toggle();
        Assert.AreEqual(9, digit.DisplayValue);
        Assert.IsTrue(digit.Bit3.State);
        Assert.IsFalse(digit.Bit2.State);
        Assert.IsFalse(digit.Bit1.State);
        Assert.IsTrue(digit.Bit0.State);

        // Clk 0: 1010
        clock.Toggle();
        Assert.AreEqual(10, digit.DisplayValue);
        Assert.IsTrue(digit.Bit3.State);
        Assert.IsFalse(digit.Bit2.State);
        Assert.IsTrue(digit.Bit1.State);
        Assert.IsFalse(digit.Bit0.State);

        // Clk 1: 1010
        clock.Toggle();
        Assert.AreEqual(10, digit.DisplayValue);
        Assert.IsTrue(digit.Bit3.State);
        Assert.IsFalse(digit.Bit2.State);
        Assert.IsTrue(digit.Bit1.State);
        Assert.IsFalse(digit.Bit0.State);

        // Clk 0: 1011
        clock.Toggle();
        Assert.IsTrue(digit.Bit3.State);
        Assert.IsFalse(digit.Bit2.State);
        Assert.IsTrue(digit.Bit1.State);
        Assert.IsTrue(digit.Bit0.State);

        // Clk 1: 1011
        clock.Toggle();
        Assert.AreEqual(11, digit.DisplayValue);
        Assert.IsTrue(digit.Bit3.State);
        Assert.IsFalse(digit.Bit2.State);
        Assert.IsTrue(digit.Bit1.State);
        Assert.IsTrue(digit.Bit0.State);

        // Clk 0: 1100
        clock.Toggle();
        Assert.AreEqual(12, digit.DisplayValue);
        Assert.IsTrue(digit.Bit3.State);
        Assert.IsTrue(digit.Bit2.State);
        Assert.IsFalse(digit.Bit1.State);
        Assert.IsFalse(digit.Bit0.State);

        // Clk 1: 1100
        clock.Toggle();
        Assert.AreEqual(12, digit.DisplayValue);
        Assert.IsTrue(digit.Bit3.State);
        Assert.IsTrue(digit.Bit2.State);
        Assert.IsFalse(digit.Bit1.State);
        Assert.IsFalse(digit.Bit0.State);

        // Clk 0: 1101
        clock.Toggle();
        Assert.AreEqual(13, digit.DisplayValue);
        Assert.IsTrue(digit.Bit3.State);
        Assert.IsTrue(digit.Bit2.State);
        Assert.IsFalse(digit.Bit1.State);
        Assert.IsTrue(digit.Bit0.State);

        // Clk 1: 1101
        clock.Toggle();
        Assert.AreEqual(13, digit.DisplayValue);
        Assert.IsTrue(digit.Bit3.State);
        Assert.IsTrue(digit.Bit2.State);
        Assert.IsFalse(digit.Bit1.State);
        Assert.IsTrue(digit.Bit0.State);

        // Clk 0: 1110
        clock.Toggle();
        Assert.AreEqual(14, digit.DisplayValue);
        Assert.IsTrue(digit.Bit3.State);
        Assert.IsTrue(digit.Bit2.State);
        Assert.IsTrue(digit.Bit1.State);
        Assert.IsFalse(digit.Bit0.State);

        // Clk 1: 1110
        clock.Toggle();
        Assert.AreEqual(14, digit.DisplayValue);
        Assert.IsTrue(digit.Bit3.State);
        Assert.IsTrue(digit.Bit2.State);
        Assert.IsTrue(digit.Bit1.State);
        Assert.IsFalse(digit.Bit0.State);

        // Clk 0: 1111
        clock.Toggle();
        Assert.AreEqual(15, digit.DisplayValue);
        Assert.IsTrue(digit.Bit3.State);
        Assert.IsTrue(digit.Bit2.State);
        Assert.IsTrue(digit.Bit1.State);
        Assert.IsTrue(digit.Bit0.State);

        // Clk 1: 1111
        clock.Toggle();
        Assert.AreEqual(15, digit.DisplayValue);
        Assert.IsTrue(digit.Bit3.State);
        Assert.IsTrue(digit.Bit2.State);
        Assert.IsTrue(digit.Bit1.State);
        Assert.IsTrue(digit.Bit0.State);

        // Clk 0: 0000
        clock.Toggle();
        Assert.AreEqual(0, digit.DisplayValue);
        Assert.IsFalse(digit.Bit3.State);
        Assert.IsFalse(digit.Bit2.State);
        Assert.IsFalse(digit.Bit1.State);
        Assert.IsFalse(digit.Bit0.State);

        // Clk 1: 0000
        clock.Toggle();
        Assert.AreEqual(0, digit.DisplayValue);
        Assert.IsFalse(digit.Bit3.State);
        Assert.IsFalse(digit.Bit2.State);
        Assert.IsFalse(digit.Bit1.State);
        Assert.IsFalse(digit.Bit0.State);

        // Clk 0: 0001
        clock.Toggle();
        Assert.AreEqual(1, digit.DisplayValue);
        Assert.IsFalse(digit.Bit3.State);
        Assert.IsFalse(digit.Bit2.State);
        Assert.IsFalse(digit.Bit1.State);
        Assert.IsTrue(digit.Bit0.State);

        // Clk 1: 0001
        clock.Toggle();
        Assert.AreEqual(1, digit.DisplayValue);
        Assert.IsFalse(digit.Bit3.State);
        Assert.IsFalse(digit.Bit2.State);
        Assert.IsFalse(digit.Bit1.State);
        Assert.IsTrue(digit.Bit0.State);
    }

    [TestMethod()]
    public void SetTest()
    {
        Board board = new();
        HexCounter digit = new(board);
        ClockGate clock = new();
        board.Connect(clock.Output, digit.Clk);

        for (int expected = 0; expected < 16; expected++)
        {
            digit.Set(expected);
            Assert.AreEqual(expected, digit.DisplayValue);
        }
    }

    [TestMethod()]
    public void ClearTest()
    {
        Board board = new();
        HexCounter digit = new(board);
        ClockGate clock = new();
        board.Connect(clock.Output, digit.Clk);
        Assert.AreEqual(0, digit.DisplayValue);

        digit.Set(5);
        Assert.AreEqual(5, digit.DisplayValue);
    }
}