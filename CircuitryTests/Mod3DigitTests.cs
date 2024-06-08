namespace Circuitry.Tests;

[TestClass()]
public class Mod3DigitTests
{
    [TestMethod()]
    public void Mod3DigitTest()
    {
        Board board = new();
        Mod3Counter digit = new(board);
        ClockGate clock = new();
        board.Connect(clock.Output, digit.Clk);

        // Clk 0: 00
        Assert.IsFalse(digit.Bit1.State);
        Assert.IsFalse(digit.Bit0.State);

        // Clk 0: 00
        clock.Toggle();
        Assert.IsFalse(digit.Bit1.State);
        Assert.IsFalse(digit.Bit0.State);

        // Clk 0: 01
        clock.Toggle();
        Assert.IsFalse(digit.Bit1.State);
        Assert.IsTrue(digit.Bit0.State);

        // Clk 1: 01
        clock.Toggle();
        Assert.IsFalse(digit.Bit1.State);
        Assert.IsTrue(digit.Bit0.State);

        // Clk 0: 10
        clock.Toggle();
        Assert.IsTrue(digit.Bit1.State);
        Assert.IsFalse(digit.Bit0.State);

        // Clk 1: 10
        clock.Toggle();
        Assert.IsTrue(digit.Bit1.State);
        Assert.IsFalse(digit.Bit0.State);

        // Clk 0: 00
        clock.Toggle();
        Assert.IsFalse(digit.Bit1.State);
        Assert.IsFalse(digit.Bit0.State);

        // Clk 0: 00
        clock.Toggle();
        Assert.IsFalse(digit.Bit1.State);
        Assert.IsFalse(digit.Bit0.State);

        // Clk 0: 01
        clock.Toggle();
        Assert.IsFalse(digit.Bit1.State);
        Assert.IsTrue(digit.Bit0.State);

        // Clk 1: 01
        clock.Toggle();
        Assert.IsFalse(digit.Bit1.State);
        Assert.IsTrue(digit.Bit0.State);

        // Clk 0: 10
        clock.Toggle();
        Assert.IsTrue(digit.Bit1.State);
        Assert.IsFalse(digit.Bit0.State);

        // Clk 1: 10
        clock.Toggle();
        Assert.IsTrue(digit.Bit1.State);
        Assert.IsFalse(digit.Bit0.State);
    }

    [TestMethod()]
    public void SetTest()
    {
        Board board = new();
        Mod3Counter digit = new(board);
        ClockGate clock = new();
        board.Connect(clock.Output, digit.Clk);

        for (int expected = 0; expected < 3; expected++)
        {
            digit.Set(expected);
            Assert.AreEqual(expected, digit.DisplayValue);
        }
    }
}
