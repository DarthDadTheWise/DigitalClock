namespace DigitalClock.Circuitry.Tests
{
    [TestClass()]
    public class JKFlipFlopTests
    {
        [TestMethod()]
        public void JKFlipFlopInvalidTest()
        {
            // Clk = 0, J = 0, K = 0 ==> Q = 0
            Board board = new();
            JKFlipFlop gate = new(board);
            Assert.IsFalse(gate.Clk.State);
            Assert.IsFalse(gate.J.State);
            Assert.IsFalse(gate.K.State);
            Assert.IsFalse(gate.Q.State);
            Assert.IsTrue(gate.NotQ.State);

            // Clk = 0 -> 1, J = 0, K = 0 ==> Q = 0
            SwitchGate clockSwitch = new();
            board.Connect(board.Battery.Output, clockSwitch.Input);
            board.Connect(clockSwitch.Output, gate.Clk);
            clockSwitch.Close();
            Assert.IsTrue(gate.Clk.State);
            Assert.IsFalse(gate.J.State);
            Assert.IsFalse(gate.K.State);
            Assert.IsFalse(gate.Q.State);
            Assert.IsTrue(gate.NotQ.State);

            // Clk = 1 -> 0, J = 0, K = 0 ==> Q = 0
            clockSwitch.Open();
            Assert.IsFalse(gate.Clk.State);
            Assert.IsFalse(gate.J.State);
            Assert.IsFalse(gate.K.State);
            Assert.IsFalse(gate.Q.State);
            Assert.IsTrue(gate.NotQ.State);
        }

        [TestMethod()]
        public void JKFlipFlopResetTest()
        {
            // Clk=   0 J=0 K=0 => Q=0 NotQ=1
            Board board = new();
            JKFlipFlop gate = new(board);
            Assert.IsFalse(gate.Clk.State);
            Assert.IsFalse(gate.J.State);
            Assert.IsFalse(gate.K.State);
            Assert.IsFalse(gate.Q.State);
            Assert.IsTrue(gate.NotQ.State);

            // Clk = 0 -> 0, J = 0, K = 1 ==> Q = 0
            // Clk=0->1 J=0 K=1 => Q=0 NotQ=1
            // Clk=1->0 J=0 K=1 => Q=0 NotQ=1
            // Clk=0->1 J=0 K=1 => Q=0 NotQ=1
            // Clk=1->0 J=0 K=1 => Q=0 NotQ=1
            board.Connect(board.Battery.Output, gate.K);
            Assert.IsFalse(gate.Clk.State);
            Assert.IsFalse(gate.J.State);
            Assert.IsTrue(gate.K.State);
            Assert.IsFalse(gate.Q.State);
            Assert.IsTrue(gate.NotQ.State);

            // Clk = 0 -> 1, J = 0, K = 1 ==> Q = 0
            SwitchGate clockSwitch = new();
            board.Connect(board.Battery.Output, clockSwitch.Input);
            board.Connect(clockSwitch.Output, gate.Clk);
            clockSwitch.Close();
            Assert.IsTrue(gate.Clk.State);
            Assert.IsFalse(gate.J.State);
            Assert.IsTrue(gate.K.State);
            Assert.IsFalse(gate.Q.State);
            Assert.IsTrue(gate.NotQ.State);

            // Clk = 1 -> 0, J = 0, K = 1 ==> Q = 0
            clockSwitch.Open();
            Assert.IsFalse(gate.Clk.State);
            Assert.IsFalse(gate.J.State);
            Assert.IsTrue(gate.K.State);
            Assert.IsFalse(gate.Q.State);
            Assert.IsTrue(gate.NotQ.State);

            // Clk = 0 -> 1, J = 0, K = 1 ==> Q = 0
            clockSwitch.Close();
            Assert.IsTrue(gate.Clk.State);
            Assert.IsFalse(gate.J.State);
            Assert.IsTrue(gate.K.State);
            Assert.IsFalse(gate.Q.State);
            Assert.IsTrue(gate.NotQ.State);
        }

        [TestMethod()]
        public void JKFlipFlopSetTest()
        {
            Board board = new();
            JKFlipFlop gate = new(board);
            Assert.IsFalse(gate.Clk.State);
            Assert.IsFalse(gate.J.State);
            Assert.IsFalse(gate.K.State);
            Assert.IsFalse(gate.Q.State);
            Assert.IsTrue(gate.NotQ.State);

            // Clk = 0, J = 1, K = 0 ==> Q = 1
            board.Connect(board.Battery.Output, gate.J);
            Assert.IsFalse(gate.Clk.State);
            Assert.IsTrue(gate.J.State);
            Assert.IsFalse(gate.K.State);
            Assert.IsFalse(gate.Q.State);
            Assert.IsTrue(gate.NotQ.State);

            // Clk = 0 -> 1, J = 1, K = 0 ==> Q = 1
            SwitchGate clockSwitch = new();
            board.Connect(board.Battery.Output, clockSwitch.Input);
            board.Connect(clockSwitch.Output, gate.Clk);
            clockSwitch.Close();
            Assert.IsTrue(gate.Clk.State);
            Assert.IsTrue(gate.J.State);
            Assert.IsFalse(gate.K.State);
            Assert.IsFalse(gate.Q.State);
            Assert.IsTrue(gate.NotQ.State);

            // Clk = 1 -> 0, J = 1, K = 0 ==> Q = 1
            clockSwitch.Open();
            Assert.IsFalse(gate.Clk.State);
            Assert.IsTrue(gate.J.State);
            Assert.IsFalse(gate.K.State);
            Assert.IsTrue(gate.Q.State);
            Assert.IsFalse(gate.NotQ.State);

            // Clk = 0 -> 1, J = 1, K = 0 ==> Q = 1
            clockSwitch.Close();
            Assert.IsTrue(gate.Clk.State);
            Assert.IsTrue(gate.J.State);
            Assert.IsFalse(gate.K.State);
            Assert.IsTrue(gate.Q.State);
            Assert.IsFalse(gate.NotQ.State);
        }

        [TestMethod()]
        public void JKFlipFlopToggleTest()
        {
            Board board = new();
            JKFlipFlop gate = new(board);
            Assert.IsFalse(gate.Clk.State);
            Assert.IsFalse(gate.J.State);
            Assert.IsFalse(gate.K.State);
            Assert.IsFalse(gate.Q.State);
            Assert.IsTrue(gate.NotQ.State);

            // Clk=0, J=1, K=1 ==> Q=0
            board.Connect(board.Battery.Output, gate.J);
            board.Connect(board.Battery.Output, gate.K);
            Assert.IsFalse(gate.Clk.State);
            Assert.IsTrue(gate.J.State);
            Assert.IsTrue(gate.K.State);
            Assert.IsFalse(gate.Q.State);
            Assert.IsTrue(gate.NotQ.State);

            // Clk=1, J=1, K=1 ==> Q=1
            SwitchGate clockSwitch = new();
            board.Connect(board.Battery.Output, clockSwitch.Input);
            board.Connect(clockSwitch.Output, gate.Clk);
            clockSwitch.Close();
            Assert.IsTrue(gate.Clk.State);
            Assert.IsTrue(gate.J.State);
            Assert.IsTrue(gate.K.State);
            Assert.IsFalse(gate.Q.State);
            Assert.IsTrue(gate.NotQ.State);

            // Clk=0, J=1, K=1 ==> Q=1
            clockSwitch.Open();
            Assert.IsFalse(gate.Clk.State);
            Assert.IsTrue(gate.J.State);
            Assert.IsTrue(gate.K.State);
            Assert.IsTrue(gate.Q.State);
            Assert.IsFalse(gate.NotQ.State);

            // Clk=1, J=1, K=1 ==> Q=1
            clockSwitch.Close();
            Assert.IsTrue(gate.Clk.State);
            Assert.IsTrue(gate.J.State);
            Assert.IsTrue(gate.K.State);
            Assert.IsTrue(gate.Q.State);
            Assert.IsFalse(gate.NotQ.State);

            // Clk=0, J=1, K=1 ==> Q=0
            clockSwitch.Open();
            Assert.IsFalse(gate.Clk.State);
            Assert.IsTrue(gate.J.State);
            Assert.IsTrue(gate.K.State);
            Assert.IsFalse(gate.Q.State);
            Assert.IsTrue(gate.NotQ.State);

            // Clk=1, J=1, K=1 ==> Q=0
            clockSwitch.Close();
            Assert.IsTrue(gate.Clk.State);
            Assert.IsTrue(gate.J.State);
            Assert.IsTrue(gate.K.State);
            Assert.IsFalse(gate.Q.State);
            Assert.IsTrue(gate.NotQ.State);

            // Clk=0, J=1, K=1 ==> Q=1
            clockSwitch.Open();
            Assert.IsFalse(gate.Clk.State);
            Assert.IsTrue(gate.J.State);
            Assert.IsTrue(gate.K.State);
            Assert.IsTrue(gate.Q.State);
            Assert.IsFalse(gate.NotQ.State);

            // Clk=1, J=1, K=1 ==> Q=1
            clockSwitch.Close();
            Assert.IsTrue(gate.Clk.State);
            Assert.IsTrue(gate.J.State);
            Assert.IsTrue(gate.K.State);
            Assert.IsTrue(gate.Q.State);
            Assert.IsFalse(gate.NotQ.State);

            // Clk=0, J=1, K=1 ==> Q=0
            clockSwitch.Open();
            Assert.IsFalse(gate.Clk.State);
            Assert.IsTrue(gate.J.State);
            Assert.IsTrue(gate.K.State);
            Assert.IsFalse(gate.Q.State);
            Assert.IsTrue(gate.NotQ.State);

            // Clk=1, J=1, K=1 ==> Q=0
            clockSwitch.Close();
            Assert.IsTrue(gate.Clk.State);
            Assert.IsTrue(gate.J.State);
            Assert.IsTrue(gate.K.State);
            Assert.IsFalse(gate.Q.State);
            Assert.IsTrue(gate.NotQ.State);
        }

        [TestMethod()]
        public void JKFlipFlopCountHexTest()
        {
            Board board = new();
            JKFlipFlop jk4 = new(board);
            JKFlipFlop jk3 = new(board);
            JKFlipFlop jk2 = new(board);
            JKFlipFlop jk1 = new(board);
            SwitchGate clockSwitch = new();

            board.Connect(board.Battery.Output, clockSwitch.Input);
            board.Connect(clockSwitch.Output, jk1.Clk);
            board.Connect(jk1.Q, jk2.Clk);
            board.Connect(jk2.Q, jk3.Clk);
            board.Connect(jk3.Q, jk4.Clk);
            board.Connect(board.Battery.Output, jk1.J);
            board.Connect(board.Battery.Output, jk1.K);
            board.Connect(board.Battery.Output, jk2.J);
            board.Connect(board.Battery.Output, jk2.K);
            board.Connect(board.Battery.Output, jk3.J);
            board.Connect(board.Battery.Output, jk3.K);
            board.Connect(board.Battery.Output, jk4.J);
            board.Connect(board.Battery.Output, jk4.K);

            //for (int i = 0; i < 64; i++)
            //{
            //    if (clockSwitch.IsOpen)
            //        clockSwitch.Close();
            //    else
            //        clockSwitch.Open();

            //    var binString =
            //        (clockSwitch.Output.State ? "1" : "0") +
            //        ": " +
            //        (jk4.Q.State ? "1" : "0") +
            //        (jk3.Q.State ? "1" : "0") +
            //        (jk2.Q.State ? "1" : "0") +
            //        (jk1.Q.State ? "1" : "0");

            //    var states =
            //        " jk1 " + (jk1.J.State ? "1" : "0") + (jk1.K.State ? "1" : "0") +
            //        " jk2 " + (jk2.J.State ? "1" : "0") + (jk2.K.State ? "1" : "0") +
            //        " jk3 " + (jk3.J.State ? "1" : "0") + (jk3.K.State ? "1" : "0") +
            //        " jk4 " + (jk4.J.State ? "1" : "0") + (jk4.K.State ? "1" : "0");
            //    Console.WriteLine(binString + states);

            //}

            // Clk 0: 0000
            Assert.IsFalse(jk4.Q.State);
            Assert.IsFalse(jk3.Q.State);
            Assert.IsFalse(jk2.Q.State);
            Assert.IsFalse(jk1.Q.State);

            // Clk 0: 0000
            clockSwitch.Open();
            Assert.IsFalse(jk4.Q.State);
            Assert.IsFalse(jk3.Q.State);
            Assert.IsFalse(jk2.Q.State);
            Assert.IsFalse(jk1.Q.State);

            // Clk 1: 0000
            clockSwitch.Close();
            Assert.IsFalse(jk4.Q.State);
            Assert.IsFalse(jk3.Q.State);
            Assert.IsFalse(jk2.Q.State);
            Assert.IsFalse(jk1.Q.State);

            // Clk 0: 0001
            clockSwitch.Open();
            Assert.IsFalse(jk4.Q.State);
            Assert.IsFalse(jk3.Q.State);
            Assert.IsFalse(jk2.Q.State);
            Assert.IsTrue(jk1.Q.State);

            // Clk 1: 0001
            clockSwitch.Close();
            Assert.IsFalse(jk4.Q.State);
            Assert.IsFalse(jk3.Q.State);
            Assert.IsFalse(jk2.Q.State);
            Assert.IsTrue(jk1.Q.State);

            // Clk 0: 0010
            clockSwitch.Open();
            Assert.IsFalse(jk4.Q.State);
            Assert.IsFalse(jk3.Q.State);
            Assert.IsTrue(jk2.Q.State);
            Assert.IsFalse(jk1.Q.State);

            // Clk 1: 0010
            clockSwitch.Close();
            Assert.IsFalse(jk4.Q.State);
            Assert.IsFalse(jk3.Q.State);
            Assert.IsTrue(jk2.Q.State);
            Assert.IsFalse(jk1.Q.State);

            // Clk 0: 0011
            clockSwitch.Open();
            Assert.IsFalse(jk4.Q.State);
            Assert.IsFalse(jk3.Q.State);
            Assert.IsTrue(jk2.Q.State);
            Assert.IsTrue(jk1.Q.State);

            // Clk 1: 0011
            clockSwitch.Close();
            Assert.IsFalse(jk4.Q.State);
            Assert.IsFalse(jk3.Q.State);
            Assert.IsTrue(jk2.Q.State);
            Assert.IsTrue(jk1.Q.State);

            // Clk 0: 0100
            clockSwitch.Open();
            Assert.IsFalse(jk4.Q.State);
            Assert.IsTrue(jk3.Q.State);
            Assert.IsFalse(jk2.Q.State);
            Assert.IsFalse(jk1.Q.State);

            // Clk 1: 0100
            clockSwitch.Close();
            Assert.IsFalse(jk4.Q.State);
            Assert.IsTrue(jk3.Q.State);
            Assert.IsFalse(jk2.Q.State);
            Assert.IsFalse(jk1.Q.State);

            // Clk 0: 0101
            clockSwitch.Open();
            Assert.IsFalse(jk4.Q.State);
            Assert.IsTrue(jk3.Q.State);
            Assert.IsFalse(jk2.Q.State);
            Assert.IsTrue(jk1.Q.State);

            // Clk 1: 0101
            clockSwitch.Close();
            Assert.IsFalse(jk4.Q.State);
            Assert.IsTrue(jk3.Q.State);
            Assert.IsFalse(jk2.Q.State);
            Assert.IsTrue(jk1.Q.State);

            // Clk 0: 0110
            clockSwitch.Open();
            Assert.IsFalse(jk4.Q.State);
            Assert.IsTrue(jk3.Q.State);
            Assert.IsTrue(jk2.Q.State);
            Assert.IsFalse(jk1.Q.State);

            // Clk 1: 0110
            clockSwitch.Close();
            Assert.IsFalse(jk4.Q.State);
            Assert.IsTrue(jk3.Q.State);
            Assert.IsTrue(jk2.Q.State);
            Assert.IsFalse(jk1.Q.State);

            // Clk 0: 0111
            clockSwitch.Open();
            Assert.IsFalse(jk4.Q.State);
            Assert.IsTrue(jk3.Q.State);
            Assert.IsTrue(jk2.Q.State);
            Assert.IsTrue(jk1.Q.State);

            // Clk 1: 0111
            clockSwitch.Close();
            Assert.IsFalse(jk4.Q.State);
            Assert.IsTrue(jk3.Q.State);
            Assert.IsTrue(jk2.Q.State);
            Assert.IsTrue(jk1.Q.State);

            // Clk 0: 1000
            clockSwitch.Open();
            Assert.IsTrue(jk4.Q.State);
            Assert.IsFalse(jk3.Q.State);
            Assert.IsFalse(jk2.Q.State);
            Assert.IsFalse(jk1.Q.State);

            // Clk 1: 1000
            clockSwitch.Close();
            Assert.IsTrue(jk4.Q.State);
            Assert.IsFalse(jk3.Q.State);
            Assert.IsFalse(jk2.Q.State);
            Assert.IsFalse(jk1.Q.State);

            // Clk 0: 1001
            clockSwitch.Open();
            Assert.IsTrue(jk4.Q.State);
            Assert.IsFalse(jk3.Q.State);
            Assert.IsFalse(jk2.Q.State);
            Assert.IsTrue(jk1.Q.State);

            // Clk 1: 1001
            clockSwitch.Close();
            Assert.IsTrue(jk4.Q.State);
            Assert.IsFalse(jk3.Q.State);
            Assert.IsFalse(jk2.Q.State);
            Assert.IsTrue(jk1.Q.State);

            // Clk 0: 1010
            clockSwitch.Open();
            Assert.IsTrue(jk4.Q.State);
            Assert.IsFalse(jk3.Q.State);
            Assert.IsTrue(jk2.Q.State);
            Assert.IsFalse(jk1.Q.State);

            // Clk 1: 1010
            clockSwitch.Close();
            Assert.IsTrue(jk4.Q.State);
            Assert.IsFalse(jk3.Q.State);
            Assert.IsTrue(jk2.Q.State);
            Assert.IsFalse(jk1.Q.State);

            // Clk 0: 1011
            clockSwitch.Open();
            Assert.IsTrue(jk4.Q.State);
            Assert.IsFalse(jk3.Q.State);
            Assert.IsTrue(jk2.Q.State);
            Assert.IsTrue(jk1.Q.State);

            // Clk 1: 1011
            clockSwitch.Close();
            Assert.IsTrue(jk4.Q.State);
            Assert.IsFalse(jk3.Q.State);
            Assert.IsTrue(jk2.Q.State);
            Assert.IsTrue(jk1.Q.State);

            // Clk 0: 1100
            clockSwitch.Open();
            Assert.IsTrue(jk4.Q.State);
            Assert.IsTrue(jk3.Q.State);
            Assert.IsFalse(jk2.Q.State);
            Assert.IsFalse(jk1.Q.State);

            // Clk 1: 1100
            clockSwitch.Close();
            Assert.IsTrue(jk4.Q.State);
            Assert.IsTrue(jk3.Q.State);
            Assert.IsFalse(jk2.Q.State);
            Assert.IsFalse(jk1.Q.State);

            // Clk 0: 1101
            clockSwitch.Open();
            Assert.IsTrue(jk4.Q.State);
            Assert.IsTrue(jk3.Q.State);
            Assert.IsFalse(jk2.Q.State);
            Assert.IsTrue(jk1.Q.State);

            // Clk 1: 1101
            clockSwitch.Close();
            Assert.IsTrue(jk4.Q.State);
            Assert.IsTrue(jk3.Q.State);
            Assert.IsFalse(jk2.Q.State);
            Assert.IsTrue(jk1.Q.State);

            // Clk 0: 1110
            clockSwitch.Open();
            Assert.IsTrue(jk4.Q.State);
            Assert.IsTrue(jk3.Q.State);
            Assert.IsTrue(jk2.Q.State);
            Assert.IsFalse(jk1.Q.State);

            // Clk 1: 1110
            clockSwitch.Close();
            Assert.IsTrue(jk4.Q.State);
            Assert.IsTrue(jk3.Q.State);
            Assert.IsTrue(jk2.Q.State);
            Assert.IsFalse(jk1.Q.State);

            // Clk 0: 1111
            clockSwitch.Open();
            Assert.IsTrue(jk4.Q.State);
            Assert.IsTrue(jk3.Q.State);
            Assert.IsTrue(jk2.Q.State);
            Assert.IsTrue(jk1.Q.State);

            // Clk 1: 1111
            clockSwitch.Close();
            Assert.IsTrue(jk4.Q.State);
            Assert.IsTrue(jk3.Q.State);
            Assert.IsTrue(jk2.Q.State);
            Assert.IsTrue(jk1.Q.State);

            // Clk 0: 0000
            clockSwitch.Open();
            Assert.IsFalse(jk4.Q.State);
            Assert.IsFalse(jk3.Q.State);
            Assert.IsFalse(jk2.Q.State);
            Assert.IsFalse(jk1.Q.State);

            // Clk 1: 0000
            clockSwitch.Close();
            Assert.IsFalse(jk4.Q.State);
            Assert.IsFalse(jk3.Q.State);
            Assert.IsFalse(jk2.Q.State);
            Assert.IsFalse(jk1.Q.State);

            // Clk 0: 0001
            clockSwitch.Open();
            Assert.IsFalse(jk4.Q.State);
            Assert.IsFalse(jk3.Q.State);
            Assert.IsFalse(jk2.Q.State);
            Assert.IsTrue(jk1.Q.State);

            // Clk 1: 0001
            clockSwitch.Close();
            Assert.IsFalse(jk4.Q.State);
            Assert.IsFalse(jk3.Q.State);
            Assert.IsFalse(jk2.Q.State);
            Assert.IsTrue(jk1.Q.State);



        }
    }
}