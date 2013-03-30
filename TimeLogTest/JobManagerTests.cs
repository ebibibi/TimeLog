using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TimeLog;

namespace TimeLogTest
{
    [TestClass]
    public class JobManagerTests
    {
        [TestMethod]
        public void CreateJob()
        {
            //Setup
            JobManager manager = new JobManager();

            //Execute
            manager.CreateNewJob("test job1");
            
            //Test
            Assert.IsTrue(manager.IsThereJob("test job1"));

        }
    }
}
