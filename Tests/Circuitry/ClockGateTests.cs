namespace DigitalClock.Circuitry.Tests
{
    [TestClass()]
    public class ClockGateTests
    {
        [TestMethod()]
        public void ClockGateTest()
        {
            ClockGate gate = new();
            Assert.IsFalse(gate.Output.State);
            Assert.IsFalse(gate.IsRunning);

            gate.Start();
            Assert.IsTrue(gate.IsRunning);

            gate.Stop();
            Assert.IsFalse(gate.IsRunning);
        }
    }
}