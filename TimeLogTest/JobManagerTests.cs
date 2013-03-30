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
            Assert.IsFalse(manager.IsThereJob("test job2"));

        }

        [TestMethod]
        public void Create2Jobs()
        {
            //Setup
            JobManager manager = new JobManager();

            //Execute
            manager.CreateNewJob("test job1");
            manager.CreateNewJob("test job2");
            
            //Test
            Assert.IsTrue(manager.IsThereJob("test job1"));
            Assert.IsTrue(manager.IsThereJob("test job2"));

        }

        
    }
}
