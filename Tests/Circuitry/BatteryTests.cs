namespace DigitalClock.Circuitry.Tests
{
    [TestClass()]
    public class BatteryTests
    {
        [TestMethod()]
        public void BatteryTest()
        {
            Battery gate = new();
            Assert.IsTrue(gate.Output.State);
        }

        //[TestMethod()]
        //public void RefreshStateTest()
        //{
        //    Assert.Fail();
        //}
    }
}