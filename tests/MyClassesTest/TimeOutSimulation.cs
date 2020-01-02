namespace MyClassesTest
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class TimeOutSimulation
    {
        [TestMethod]
        [Timeout(10)]
        public void SimulateTimeOut()
        {
            System.Threading.Thread.Sleep(5);
        }
    }
}
