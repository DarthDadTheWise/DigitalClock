namespace Circuitry.Tests
{
    [TestClass()]
    public class RSNandLatchTests
    {
        [TestMethod()]
        public void RSNandLatchSetTest()
        {
            // S R Q !Q
            // --------
            // F F undefined/not allowed
            // F T T  F (Reset)
            // T F F  T (Set)
            // T T no change

            Board board = new();
            RSNandLatch gate = new(board);
            Assert.IsFalse(gate.R.State);
            Assert.IsFalse(gate.S.State);
            Assert.IsTrue(gate.Q.State);
            Assert.IsTrue(gate.NotQ.State);

            board.Connect(board.Battery.Output, gate.S);
            Assert.IsFalse(gate.R.State);
            Assert.IsTrue(gate.S.State);
            Assert.IsFalse(gate.Q.State);
            Assert.IsTrue(gate.NotQ.State);
        }

        [TestMethod()]
        public void RSNandLatchResetTest()
        {
            // S R Q !Q
            // --------
            // F F undefined/not allowed
            // F T T  F (Reset)
            // T F F  T (Set)
            // T T no change

            Board board = new();
            RSNandLatch gate = new(board);
            Assert.IsFalse(gate.R.State);
            Assert.IsFalse(gate.S.State);
            Assert.IsTrue(gate.Q.State);
            Assert.IsTrue(gate.NotQ.State);

            board.Connect(board.Battery.Output, gate.R);
            Assert.IsTrue(gate.R.State);
            Assert.IsFalse(gate.S.State);
            Assert.IsTrue(gate.Q.State);
            Assert.IsFalse(gate.NotQ.State);
        }

        [TestMethod()]
        public void RSNandLatchNoChange1Test()
        {
            // S R Q !Q
            // --------
            // F F undefined/not allowed
            // F T T  F (Reset)
            // T F F  T (Set)
            // T T no change

            Board board = new();
            RSNandLatch gate = new(board);
            Assert.IsFalse(gate.R.State);
            Assert.IsFalse(gate.S.State);
            Assert.IsTrue(gate.Q.State);
            Assert.IsTrue(gate.NotQ.State);

            // Reset
            board.Connect(board.Battery.Output, gate.R);
            Assert.IsTrue(gate.R.State);
            Assert.IsFalse(gate.S.State);
            Assert.IsTrue(gate.Q.State);
            Assert.IsFalse(gate.NotQ.State);

            // Still reset
            board.Connect(board.Battery.Output, gate.S);
            Assert.IsTrue(gate.R.State);
            Assert.IsTrue(gate.S.State);
            Assert.IsTrue(gate.Q.State);
            Assert.IsFalse(gate.NotQ.State);
        }

        [TestMethod()]
        public void RSNandLatchNoChange2Test()
        {
            // S R Q !Q
            // --------
            // F F undefined/not allowed
            // F T T  F (Reset)
            // T F F  T (Set)
            // T T no change

            Board board = new();
            RSNandLatch gate = new(board);
            Assert.IsFalse(gate.R.State);
            Assert.IsFalse(gate.S.State);
            Assert.IsTrue(gate.Q.State);
            Assert.IsTrue(gate.NotQ.State);

            // Set
            board.Connect(board.Battery.Output, gate.S);
            Assert.IsFalse(gate.R.State);
            Assert.IsTrue(gate.S.State);
            Assert.IsFalse(gate.Q.State);
            Assert.IsTrue(gate.NotQ.State);

            // Still set
            board.Connect(board.Battery.Output, gate.R);
            Assert.IsTrue(gate.R.State);
            Assert.IsTrue(gate.S.State);
            Assert.IsFalse(gate.Q.State);
            Assert.IsTrue(gate.NotQ.State);
        }
        //[TestMethod()]
        //public void RSNandLatchTest()
        //{
        //    // http://www.play-hookey.com/digital/sequential/rs_nand_latch.html

        //    // S R Q !Q
        //    // --------
        //    // 0 0 undefined/not allowed
        //    // 0 1 1  0 (Reset)
        //    // 1 0 0  1 (Set)
        //    // 1 1 no change

        //    Board board = new();
        //    var gate = board.CreateGate("RSNandLatch") as RSNandLatch;
        //    var s = board.CreateGate("Switch") as Switch;
        //    var r = board.CreateGate("Switch") as Switch;
        //    ArgumentNullException.ThrowIfNull(gate);
        //    ArgumentNullException.ThrowIfNull(s);
        //    ArgumentNullException.ThrowIfNull(r);
        //    board.Connect(board.Battery.Output, s.Input);
        //    board.Connect(board.Battery.Output, r.Input);
        //    board.Connect(s.Output, gate.S);
        //    board.Connect(r.Output, gate.R);

        //    // Set
        //    s.Close();
        //    Assert.AreEqual(State.High, gate.S.State);
        //    Assert.AreEqual(State.Low, gate.R.State);
        //    Assert.AreEqual(State.Low, gate.Q.State);
        //    Assert.AreEqual(State.High, gate.NotQ.State);

        //    // No change - remain Set
        //    r.Close();
        //    Assert.AreEqual(State.High, gate.S.State);
        //    Assert.AreEqual(State.High, gate.R.State);
        //    Assert.AreEqual(State.Low, gate.Q.State);
        //    Assert.AreEqual(State.High, gate.NotQ.State);

        //    // No change - remain Set
        //    r.Open();
        //    Assert.AreEqual(State.High, gate.S.State);
        //    Assert.AreEqual(State.Low, gate.R.State);
        //    Assert.AreEqual(State.Low, gate.Q.State);
        //    Assert.AreEqual(State.High, gate.NotQ.State);

        //    // No change - remain Set
        //    r.Close();
        //    Assert.AreEqual(State.High, gate.S.State);
        //    Assert.AreEqual(State.High, gate.R.State);
        //    Assert.AreEqual(State.Low, gate.Q.State);
        //    Assert.AreEqual(State.High, gate.NotQ.State);

        //    // Reset
        //    s.Open();
        //    Assert.AreEqual(State.Low, gate.S.State);
        //    Assert.AreEqual(State.High, gate.R.State);
        //    Assert.AreEqual(State.High, gate.Q.State);
        //    Assert.AreEqual(State.Low, gate.NotQ.State);

        //    // No change - remain Reset
        //    s.Close();
        //    Assert.AreEqual(State.High, gate.S.State);
        //    Assert.AreEqual(State.High, gate.R.State);
        //    Assert.AreEqual(State.High, gate.Q.State);
        //    Assert.AreEqual(State.Low, gate.NotQ.State);

        //    // No change - remain Reset
        //    s.Open();
        //    Assert.AreEqual(State.Low, gate.S.State);
        //    Assert.AreEqual(State.High, gate.R.State);
        //    Assert.AreEqual(State.High, gate.Q.State);
        //    Assert.AreEqual(State.Low, gate.NotQ.State);

        //}
    }
}