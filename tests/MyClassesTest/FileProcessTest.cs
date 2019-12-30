namespace MyClassesTest
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using MyClasses;
    using System;
    using System.IO;

    [TestClass]
    public class FileProcessTest
    {
        private readonly FileProcess fileProcess = new FileProcess();
        private string fullPath;

        [TestMethod]
        public void WhenFileNameDoesExistsShouldReturnTrue()
        {
            this.CreateTestFile();
            bool fromCall = fileProcess.FileExists(fullPath);
            this.DeleteTestFile();
            Assert.IsTrue(fromCall);
        }

        [TestMethod]
        public void WhenFileNameDoesNotExistsShouldReturnFalse()
        {
            string fullPath = @"C:\Test.txt";       
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

        private void CreateTestFile()
        {
            this.fullPath = $"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}\\Test.txt";
            using (File.Create(fullPath))
            {

            }
        }

        private void DeleteTestFile()
        {
            File.Delete(this.fullPath);
        }
    }
}
