namespace Circuitry.Tests;

[TestClass()]
public class AndGateTests
{
    [TestMethod()]
    public void AndGateFFTest()
    {
        // F and F = F
        AndGate gate = new();
        Assert.IsFalse(gate.Input1.State);
        Assert.IsFalse(gate.Input2.State);
        Assert.IsFalse(gate.Output.State);
    }

    [TestMethod()]
    public void AndGateTFTest()
    {
        AndGate gate = new();
        Assert.IsFalse(gate.Input1.State);
        Assert.IsFalse(gate.Input2.State);
        Assert.IsFalse(gate.Output.State);

        // T and F = F
        Board board = new();
        SwitchGate switch1 = new();
        board.Connect(board.Battery.Output, switch1.Input);
        board.Connect(switch1.Output, gate.Input1);
        switch1.Close();
        Assert.IsTrue(gate.Input1.State);
        Assert.IsFalse(gate.Input2.State);
        Assert.IsFalse(gate.Output.State);

        switch1.Open();
        Assert.IsFalse(gate.Input1.State);
        Assert.IsFalse(gate.Input2.State);
        Assert.IsFalse(gate.Output.State);

        switch1.Close();
        Assert.IsTrue(gate.Input1.State);
        Assert.IsFalse(gate.Input2.State);
        Assert.IsFalse(gate.Output.State);
    }

    [TestMethod()]
    public void AndGateFTTest()
    {
        AndGate gate = new();
        Assert.IsFalse(gate.Input1.State);
        Assert.IsFalse(gate.Input2.State);
        Assert.IsFalse(gate.Output.State);

        // F and T = F
        Board board = new();
        SwitchGate switch2 = new();
        board.Connect(board.Battery.Output, switch2.Input);
        board.Connect(switch2.Output, gate.Input2);
        switch2.Close();
        Assert.IsFalse(gate.Input1.State);
        Assert.IsTrue(gate.Input2.State);
        Assert.IsFalse(gate.Output.State);

        switch2.Open();
        Assert.IsFalse(gate.Input1.State);
        Assert.IsFalse(gate.Input2.State);
        Assert.IsFalse(gate.Output.State);

        switch2.Close();
        Assert.IsFalse(gate.Input1.State);
        Assert.IsTrue(gate.Input2.State);
        Assert.IsFalse(gate.Output.State);
    }

    [TestMethod()]
    public void AndGateTTTest()
    {
        AndGate gate = new();
        Assert.IsFalse(gate.Input1.State);
        Assert.IsFalse(gate.Input2.State);
        Assert.IsFalse(gate.Output.State);

        // T and T = T
        Board board = new();
        SwitchGate switch1 = new();
        board.Connect(board.Battery.Output, switch1.Input);
        board.Connect(switch1.Output, gate.Input1);
        SwitchGate switch2 = new();
        board.Connect(board.Battery.Output, switch2.Input);
        board.Connect(switch2.Output, gate.Input2);

        switch1.Close();
        switch2.Close();
        Assert.IsTrue(gate.Input1.State);
        Assert.IsTrue(gate.Input2.State);
        Assert.IsTrue(gate.Output.State);

        switch1.Open();
        switch2.Open();
        Assert.IsFalse(gate.Input1.State);
        Assert.IsFalse(gate.Input2.State);
        Assert.IsFalse(gate.Output.State);

        switch1.Close();
        switch2.Close();
        Assert.IsTrue(gate.Input1.State);
        Assert.IsTrue(gate.Input2.State);
        Assert.IsTrue(gate.Output.State);
    }
}