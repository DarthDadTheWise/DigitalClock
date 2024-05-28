namespace DigitalClock.Tests
{
    [TestClass()]
    public class ClockTests
    {
        [TestMethod()]
        public void SetTest()
        {
            Clock clock = new();
            var currentTime = DateTime.Now;
            clock.Set(currentTime.Hour, currentTime.Minute, currentTime.Second);
            string expected = currentTime.ToString("HH:mm:ss");
            string actual = clock.Time;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void AddOneSecondTest()
        {
            Clock clock = new();
            Assert.AreEqual("00:00:00", clock.Time);

            clock.AddOneSecond();
            Assert.AreEqual("00:00:01", clock.Time);

            clock.Set(0, 0, 9);
            Assert.AreEqual("00:00:09", clock.Time);
            clock.AddOneSecond();
            Assert.AreEqual("00:00:10", clock.Time);

            clock.Set(0, 0, 59);
            Assert.AreEqual("00:00:59", clock.Time);
            clock.AddOneSecond();
            Assert.AreEqual("00:01:00", clock.Time);

            clock.Set(0, 9, 59);
            Assert.AreEqual("00:09:59", clock.Time);
            clock.AddOneSecond();
            Assert.AreEqual("00:10:00", clock.Time);

            clock.Set(0, 59, 59);
            Assert.AreEqual("00:59:59", clock.Time);
            clock.AddOneSecond();
            Assert.AreEqual("01:00:00", clock.Time);

            clock.Set(9, 59, 59);
            Assert.AreEqual("09:59:59", clock.Time);
            clock.AddOneSecond();
            Assert.AreEqual("10:00:00", clock.Time);

            clock.Set(12, 59, 59);
            Assert.AreEqual("12:59:59", clock.Time);
            clock.AddOneSecond();
            Assert.AreEqual("13:00:00", clock.Time);

            clock.Set(13, 0, 9);
            Assert.AreEqual("13:00:09", clock.Time);
            clock.AddOneSecond();
            Assert.AreEqual("13:00:10", clock.Time);

            clock.Set(13, 0, 59);
            Assert.AreEqual("13:00:59", clock.Time);
            clock.AddOneSecond();
            Assert.AreEqual("13:01:00", clock.Time);

            clock.Set(13, 9, 59);
            Assert.AreEqual("13:09:59", clock.Time);
            clock.AddOneSecond();
            Assert.AreEqual("13:10:00", clock.Time);

            clock.Set(13, 59, 59);
            Assert.AreEqual("13:59:59", clock.Time);
            clock.AddOneSecond();
            Assert.AreEqual("14:00:00", clock.Time);

            clock.Set(23, 59, 59);
            Assert.AreEqual("23:59:59", clock.Time);
            clock.AddOneSecond();
            Assert.AreEqual("00:00:00", clock.Time);
        }

        //   [TestMethod()]
        //   public void AddOneSecond2Test()
        //   {
        //       Clock clock = new();
        //       Assert.AreEqual("00:00:00", clock.Time);

        //       for (int hourTens = 0; hourTens < 3; hourTens++)
        //       {
        //           for (int hourOnes = 0; hourOnes < 10; hourOnes++)
        //           {
        //               for (int minuteTens = 0; minuteTens < 6; minuteTens++)
        //               {
        //                   for (int minuteOnes = 0; minuteOnes < 10; minuteOnes++)
        //                   {
        //                       for (int secondTens = 0; secondTens < 6; secondTens++)
        //                       {
        //                           for (int secondOnes = 0; secondOnes < 10; secondOnes++)
        //                           {
        //                               var expected = $"{hourTens}{hourOnes}:{minuteTens}{minuteOnes}:{secondTens}{secondOnes}";
        //                               Assert.AreEqual(expected, clock.Time);

        //                               clock.AddOneSecond();
        //                           }
        //                       }
        //                   }
        //               }
        //           }
        //       }
        //   }

        [TestMethod()]
        public void StartTest()
        {
            List<string> receivedEvents = new List<string>();
            Clock clock = new();
            clock.Tick += delegate (object? sender, EventArgs e)
            {
                Assert.IsInstanceOfType(sender, typeof(Clock));
                var clk = sender as Clock;
                Assert.IsNotNull(clk);
                receivedEvents.Add(clk.Time);
                clock.Stop();
            };

            Assert.AreEqual(0, receivedEvents.Count);
            clock.Start();

            // wait for event
            while (0 == receivedEvents.Count) { }

            Assert.AreEqual(1, receivedEvents.Count);
            Assert.AreEqual("00:00:00", receivedEvents[0]);
        }

        [TestMethod()]
        public void StopTest()
        {
            List<string> receivedEvents = new List<string>();
            Clock clock = new();
            clock.Tick += delegate (object? sender, EventArgs e)
            {
                Assert.IsInstanceOfType(sender, typeof(Clock));
                var clk = sender as Clock;
                Assert.IsNotNull(clk);
                receivedEvents.Add(clk.Time);

                if (receivedEvents.Count == 2)
                {
                    clock.Stop();
                }
            };

            Assert.AreEqual(0, receivedEvents.Count);
            clock.Start();

            // wait for event
            while (2 > receivedEvents.Count) { }

            Assert.AreEqual(2, receivedEvents.Count);
            Assert.AreEqual("00:00:00", receivedEvents[0]);
            Assert.AreEqual("00:00:01", receivedEvents[1]);
        }
    }
}