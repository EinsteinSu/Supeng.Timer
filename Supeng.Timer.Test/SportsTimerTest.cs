using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Supeng.Timer.Test
{
    [TestClass]
    public class SportsTimerTest
    {
        [TestMethod]
        public void IncreaseTimer()
        {
            SportsTimer timer = new SportsTimer(true, 50);
            timer.Start();
            Thread.Sleep(TimeSpan.FromSeconds(3));
            Assert.AreEqual(timer.CurrentSeconds, 53);
            timer.Stop();
            Thread.Sleep(TimeSpan.FromSeconds(3));
            Assert.AreEqual(timer.CurrentSeconds, 53);
            Thread.Sleep(TimeSpan.FromSeconds(3));
            timer.Reset();
            Assert.AreEqual(timer.CurrentSeconds, 50);
            Thread.Sleep(TimeSpan.FromSeconds(3));
            Assert.AreEqual(timer.CurrentSeconds, 53);
        }

        [TestMethod]
        public void DecreaseTimer()
        {
            SportsTimer timer = new SportsTimer(false, 50);
            timer.Start();
            Thread.Sleep(TimeSpan.FromSeconds(3));
            Assert.AreEqual(timer.CurrentSeconds, 47);
            timer.Stop();
            Thread.Sleep(TimeSpan.FromSeconds(3));
            Assert.AreEqual(timer.CurrentSeconds, 47);
            Thread.Sleep(TimeSpan.FromSeconds(3));
            timer.Reset();
            Assert.AreEqual(timer.CurrentSeconds, 50);
            Thread.Sleep(TimeSpan.FromSeconds(3));
            Assert.AreEqual(timer.CurrentSeconds, 47);
        }
    }
}
