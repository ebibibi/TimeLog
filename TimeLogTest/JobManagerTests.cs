using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Collections.Generic;
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
            string jobname = "CreateJob test job1";
            JobManager manager = new JobManager();

            //Execute
            manager.CreateNewJob(jobname);
            
            //Test
            Assert.IsTrue(manager.IsThereJob(jobname));
            Assert.IsFalse(manager.IsThereJob(jobname + "dummy"));
        }

        [TestMethod]
        public void Create2Jobs()
        {
            //Setup
            string jobname1 = "Create2Jobs test job1";
            string jobname2 = "Create2Jobs test job2";
            JobManager manager = new JobManager();

            //Execute
            manager.CreateNewJob(jobname1);
            manager.CreateNewJob(jobname2);
            
            //Test
            Assert.IsTrue(manager.IsThereJob(jobname1));
            Assert.IsTrue(manager.IsThereJob(jobname2));
            Assert.IsFalse(manager.IsThereJob(jobname1 + "dummy"));

        }

        [TestMethod]
        public void CreateAndStartJob()
        {
            //Setup
            string jobname = "CreateAndStartJob test job1";
            JobManager manager = new JobManager();

            //Execute
            manager.CreateNewJob(jobname);
            manager.StartJob(jobname);

            //Test
            Assert.IsTrue(manager.IsRunningJob(jobname));
            Assert.IsFalse(manager.IsRunningJob(jobname + "dummy"));
        }

        [TestMethod]
        public void CreateAndStart2Jobs()
        {
            //Setup
            string jobname1 = "CreateAndStart2Jobs test job1";
            string jobname2 = "CreateAndStart2Jobs test job2";
            JobManager manager = new JobManager();

            //Execute
            manager.CreateNewJob(jobname1);
            manager.StartJob(jobname1);
            manager.CreateNewJob(jobname2);
            manager.StartJob(jobname2);

            //Test
            Assert.IsTrue(manager.IsRunningJob(jobname1));
            Assert.IsTrue(manager.IsRunningJob(jobname2));
        }

        [TestMethod]
        public void CreateAndStartAndStopJob()
        {
            //Setup
            string jobname = "CreateAndStartAndStopJob test job1";
            JobManager manager = new JobManager();

            //Execute
            manager.CreateNewJob(jobname);
            manager.StartJob(jobname);

            //Test
            Assert.IsTrue(manager.IsRunningJob(jobname));
            
            //Execute
            manager.StopJob(jobname);

            //Test
            Assert.IsFalse(manager.IsRunningJob(jobname));
            
        }

        [TestMethod]
        public void CurrentWorkingTime()
        {
            //Setup
            string jobname = "CurrentWorkingTime";
            JobManager manager = new JobManager();

            //Execute
            manager.CreateNewJob(jobname);
            manager.StartJob(jobname);

            //Test
            Assert.IsTrue(manager.currentWorkingTime(jobname).StartsWith("00:00:"));

        }

        [TestMethod]
        public void totalWorkingTime()
        {
            //Setup
            string jobname = "totalWorkingTime";
            JobManager manager = new JobManager();

            //Execute
            manager.CreateNewJob(jobname);
            manager.StartJob(jobname);
            System.Threading.Thread.Sleep(1000);

            //Test
            Assert.IsTrue(manager.totalWorkingTime(jobname).StartsWith("00:00:"));

            manager.StopJob(jobname);
            string time = manager.totalWorkingTime(jobname);

            manager.StartJob(jobname);
            System.Threading.Thread.Sleep(1000);
            Assert.IsTrue(time.CompareTo(manager.totalWorkingTime(jobname)) != 0);
            
        }

        [TestMethod]
        public void ReadJobsFromDatabase()
        {
            //Setup
            string jobname = "ReadJobsFromDatabase";
            JobManager manager = new JobManager();

            //Execute
            manager.CreateNewJob(jobname);
            manager = null;
            manager = new JobManager();

            //Test
            Assert.IsTrue(manager.IsThereJob(jobname));
            Assert.IsFalse(manager.IsThereJob(jobname + "dummy"));
        }

        [TestMethod]
        public void GetJobList()
        {
            //Setup
            string jobname = "GetJobList";
            JobManager manager = new JobManager();

            //Execute
            manager.CreateNewJob(jobname);
            manager = null;
            manager = new JobManager();
            var list = manager.GetJobList();

            //Test
            Assert.IsTrue(list.Count > 0);
            Assert.IsTrue(list.Contains(jobname));

        }

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
            JobRecord record = records.Last();
            Assert.IsTrue(0 < records.Count());
            Assert.AreEqual(DateTime.Today, record.date);
            Assert.IsTrue(new TimeSpan(0, 0, 1) <= TimeHelper.String2Timespan(record.duration));
            Assert.AreEqual<string>(jobname, record.name);
            Assert.IsTrue(DateTime.Now > record.startTime);
            Assert.IsTrue(DateTime.Now > record.endTime);
            Assert.IsTrue(record.startTime < record.endTime);

        }

        [TestMethod]
        public void GetAllJobRecords()
        {
            JobManager manager = new JobManager();

            List<JobRecord> records = manager.GetAllJobRecords();
            Assert.IsTrue(0 < records.Count());
        }

        [TestMethod]
        public void DeleteJob()
        {
            //Setup
            string jobname = "DeleteJob";
            JobManager manager = new JobManager();

            //Execute
            manager.CreateNewJob(jobname);
            manager = null;
            manager = new JobManager();
            var list = manager.GetJobList();

            //Test
            Assert.IsTrue(list.Contains(jobname));

            //Execute
            manager.DeleteJob(jobname);
            list = manager.GetJobList();

            //Test
            Assert.IsFalse(list.Contains(jobname));

        }

    }
}
