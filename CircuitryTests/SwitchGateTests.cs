namespace Circuitry.Tests;

[TestClass()]
public class SwitchGateTests
{
    [TestMethod()]
    public void OpenTest()
    {
        SwitchGate gate = new();
        Assert.IsTrue(gate.IsOpen);
        Assert.IsFalse(gate.Input.State);
        Assert.IsFalse(gate.Output.State);

        gate.Open();
        Assert.IsTrue(gate.IsOpen);
        Assert.IsFalse(gate.Input.State);
        Assert.IsFalse(gate.Output.State);
    }

    [TestMethod()]
    public void OpenWithBatteryTest()
    {
        Board board = new();
        SwitchGate gate = new();
        Assert.IsTrue(gate.IsOpen);
        Assert.IsFalse(gate.Input.State);
        Assert.IsFalse(gate.Output.State);

        board.Connect(board.Battery.Output, gate.Input);

        Assert.IsTrue(gate.IsOpen);
        Assert.IsTrue(gate.Input.State);
        Assert.IsFalse(gate.Output.State);

        gate.Open();
        Assert.IsTrue(gate.IsOpen);
        Assert.IsTrue(gate.Input.State);
        Assert.IsFalse(gate.Output.State);
    }

    [TestMethod()]
    public void CloseTest()
    {
        SwitchGate gate = new();
        Assert.IsTrue(gate.IsOpen);
        Assert.IsFalse(gate.Input.State);
        Assert.IsFalse(gate.Output.State);

        gate.Close();
        Assert.IsFalse(gate.IsOpen);
        Assert.IsFalse(gate.Input.State);
        Assert.IsFalse(gate.Output.State);
    }

    [TestMethod()]
    public void CloseWithBatteryTest()
    {
        Board board = new();
        SwitchGate gate = new();
        Assert.IsTrue(gate.IsOpen);
        Assert.IsFalse(gate.Input.State);
        Assert.IsFalse(gate.Output.State);

        board.Connect(board.Battery.Output, gate.Input);

        gate.Close();
        Assert.IsFalse(gate.IsOpen);
        Assert.IsTrue(gate.Input.State);
        Assert.IsTrue(gate.Output.State);
    }
}