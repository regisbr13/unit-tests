namespace MyClassesTest
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using MyClasses;
    using System;
    using System.IO;

    [TestClass]
    public class FileProcessTest
    {
        public TestContext TestContext { get; set; }

        private FileProcess fileProcess;
        private string fullPath;

        #region Test Initialize and Clenup
        [TestInitialize]
        public void TestInitialize()
        {
            this.fileProcess = new FileProcess();
            this.fullPath = $@"{TestContext.DeploymentDirectory}\TestFile.txt";
            if (TestContext.TestName == "WhenFileNameDoesExistsShouldReturnTrue")
            {
                using (File.Create(fullPath))
                {
                    TestContext.WriteLine("Creating file: " + this.fullPath);
                }
            }
        }

        [TestCleanup]
        public void TestCleanup()
        {
            if (TestContext.TestName == "WhenFileNameDoesExistsShouldReturnTrue")
            {
                File.Delete(this.fullPath);
                TestContext.WriteLine("Deleting file: " + this.fullPath);
            }
        }
        #endregion

        [TestMethod]
        public void WhenFileNameDoesExistsShouldReturnTrue()
        {
            TestContext.WriteLine("Testing file: " + this.fullPath);
            bool fromCall = fileProcess.FileExists(fullPath);
            Assert.IsTrue(fromCall, "The file exists");
        }

        [TestMethod]
        public void WhenFileNameDoesNotExistsShouldReturnFalse()
        {
            string fullPath = this.fullPath;       
            bool fromCall = fileProcess.FileExists(fullPath);
            Assert.IsFalse(fromCall);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FileNameIsNullOrEmptyShouldThrowArgumentNullException()
        {
            string fullPath = string.Empty;
            fileProcess.FileExists(fullPath);
        }

        [TestMethod]
        public void FileNameIsNullOrEmptyShouldThrowArgumentNullException_UsingTryCatch()
        {
            string fullPath = string.Empty;
            try
            {
                fileProcess.FileExists(fullPath);
            }
            catch(ArgumentNullException)
            {
                return;
            }
            Assert.Fail($"Expected Fail:");
        }

        [TestMethod]
        [Timeout(2000)]
        public void SimulateTimeOut()
        {
            System.Threading.Thread.Sleep(1000);
        }
    }
}
