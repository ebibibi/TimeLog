using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

using TimeLog;
using TimeLogTest;

namespace TimeLogTest
{
    [TestClass]
    public class JobRecordTest
    {
        [TestMethod]
        public void GetAllRecordAboutJob()
        {
            //Setup
            string jobname = "GetAllRecordAboutJob";
            JobManager manager = new JobManager();

            //Execute
            manager.CreateNewJob(jobname);
            manager.StartJob(jobname);
            System.Threading.Thread.Sleep(1001);
            manager.StopJob(jobname);

            List<JobRecord> records = manager.GetAllRecordAboutJob(jobname);
            JobRecord record = records.First();
            Assert.IsTrue(0 < records.Count());
            Assert.AreEqual(DateTime.Today, record.date);
            Assert.IsTrue(new TimeSpan(0, 0, 1) <= TimeHelper.String2Timespan(record.duration));
            Assert.AreEqual<string>(jobname, record.name);
            Assert.IsTrue(DateTime.Now > record.startTime);
            Assert.IsTrue(DateTime.Now > record.endTime);
            Assert.IsTrue(record.startTime < record.endTime);

        }
    }
}
