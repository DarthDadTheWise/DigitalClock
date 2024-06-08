namespace Circuitry.Tests;

[TestClass()]
public class OrGateTests
{
    [TestMethod()]
    public void OrGateFFTest()
    {
        // F and F = F
        OrGate gate = new();
        Assert.IsFalse(gate.Input1.State);
        Assert.IsFalse(gate.Input2.State);
        Assert.IsFalse(gate.Output.State);
    }

    [TestMethod()]
    public void OrGateTFTest()
    {
        OrGate gate = new();
        Assert.IsFalse(gate.Input1.State);
        Assert.IsFalse(gate.Input2.State);
        Assert.IsFalse(gate.Output.State);

        // T and F = T
        Board board = new();
        board.Connect(board.Battery.Output, gate.Input1);
        Assert.IsTrue(gate.Input1.State);
        Assert.IsFalse(gate.Input2.State);
        Assert.IsTrue(gate.Output.State);
    }

    [TestMethod()]
    public void OrGateFTTest()
    {
        OrGate gate = new();
        Assert.IsFalse(gate.Input1.State);
        Assert.IsFalse(gate.Input2.State);
        Assert.IsFalse(gate.Output.State);

        // F and T = T
        Board board = new();
        board.Connect(board.Battery.Output, gate.Input2);
        Assert.IsFalse(gate.Input1.State);
        Assert.IsTrue(gate.Input2.State);
        Assert.IsTrue(gate.Output.State);
    }

    [TestMethod()]
    public void OrGateTTTest()
    {
        OrGate gate = new();
        Assert.IsFalse(gate.Input1.State);
        Assert.IsFalse(gate.Input2.State);
        Assert.IsFalse(gate.Output.State);

        // T and T = T
        Board board = new();
        board.Connect(board.Battery.Output, gate.Input1);
        board.Connect(board.Battery.Output, gate.Input2);
        Assert.IsTrue(gate.Input1.State);
        Assert.IsTrue(gate.Input2.State);
        Assert.IsTrue(gate.Output.State);
    }
}