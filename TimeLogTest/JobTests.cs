using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TimeLog;

namespace TimeLogTest
{
    [TestClass]
    public class JobTests
    {
        [TestMethod]
        public void JobName()
        {
            //Setup
            string jobname = "ジョブ名";
            Job job = new Job(jobname);

            //Execute

            //Test
            Assert.AreEqual<string>(jobname, job.name);
        }
        
        [TestMethod]
        public void StartJob()
        {
            //Setup
            string jobname = "StartJobTest";
            Job job = new Job(jobname);
            
            //Execute
            DateTime startTime = new DateTime(2000, 1, 1, 1, 1, 1);
            job.start(startTime);

            //Test
            Assert.AreEqual<DateTime>(startTime, job.startTime);
        }

        [TestMethod]
        public void Start2Jobs()
        {

            //Setup
            Job job1 = new Job("job1");
            Job job2 = new Job("job2");

            //Execute
            DateTime startTime1 = new DateTime(2001, 1, 1, 1, 1, 1);
            job1.start(startTime1);

            DateTime startTime2 = new DateTime(2002, 2, 2, 2, 2, 2);
            job2.start(startTime2);

            //Test
            Assert.AreEqual<DateTime>(startTime1, job1.startTime);
            Assert.AreEqual<DateTime>(startTime2, job2.startTime);
        }
    }
}
