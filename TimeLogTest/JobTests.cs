﻿using System;
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
            Assert.AreEqual<DateTime>(TimeHelper.Null(), job.startTime);
            Assert.AreEqual<DateTime>(TimeHelper.Null(), job.endTime);
            Assert.AreEqual<string>("00:00:00", job.totalWorkingTime);
        }

        [TestMethod]
        public void TesttotalWorkingTimeWhenCreated()
        {
            //Setup
            string jobname = "TesttotalWorkingTimeWhenCreated";
            Job job = new Job(jobname, new TimeSpan(1, 1, 1));

            //Test
            Assert.AreEqual<string>(jobname, job.name);
            Assert.AreEqual<DateTime>(TimeHelper.Null(), job.startTime);
            Assert.AreEqual<DateTime>(TimeHelper.Null(), job.endTime);
            Assert.AreEqual<string>("01:01:01", job.totalWorkingTime);

        }


        
        [TestMethod]
        public void StartJobAndCheckStartTime()
        {
            //Setup
            string jobname = "StartJobTest";
            Job job = new Job(jobname);
            
            //Execute
            DateTime startTime = new DateTime(2000, 1, 1, 1, 1, 1);
            job.start(startTime);

            //Test
            Assert.AreEqual<DateTime>(startTime, job.startTime);
            Assert.IsTrue(job.isRunning);
            Assert.AreEqual<DateTime>(TimeHelper.Null(), job.endTime);
        }

        [TestMethod]
        public void Start2JobsAndCheckStartTimes()
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

        [TestMethod]
        public void StopJobAndCheckStartAndStopTime()
        {
            //Setup
            Job job = new Job("job");
            DateTime startTime = new DateTime(2001, 1, 1, 1, 1, 1);
            DateTime endTime = new DateTime(2001, 1, 1, 2, 1, 1);

            //Execute
            job.start(startTime);

            //Test
            Assert.AreEqual<DateTime>(startTime, job.startTime);
            Assert.AreEqual<DateTime>(TimeHelper.Null(), job.endTime);

            //Execute
            job.stop(endTime);

            //Test
            Assert.AreEqual<DateTime>(startTime, job.startTime);
            Assert.AreEqual<DateTime>(endTime, job.endTime);
        }

        [TestMethod]
        public void Stop2JobsAndCheckStartAndStopTimes()
        {
            //Setup
            Job job1 = new Job("job1");
            DateTime startTime1 = new DateTime(2001, 1, 1, 1, 1, 1);
            DateTime endTime1 = new DateTime(2001, 1, 1, 2, 1, 1);

            Job job2 = new Job("job2");
            DateTime startTime2 = new DateTime(2002, 2, 2, 2, 2, 2);
            DateTime endTime2 = new DateTime(2002, 2, 2, 3, 2, 2);

            //Execute
            job1.start(startTime1);
            job2.start(startTime2);

            job1.stop(endTime1);
            job2.stop(endTime2);

            //Test
            Assert.AreEqual<DateTime>(startTime1, job1.startTime);
            Assert.AreEqual<DateTime>(startTime2, job2.startTime);

            Assert.AreEqual<DateTime>(endTime1, job1.endTime);
            Assert.AreEqual<DateTime>(endTime2, job2.endTime);

        }

        [TestMethod]
        public void StartAndStopAndStart()
        {
            //Setup
            Job job = new Job("job");
            DateTime startTime = new DateTime(2001, 1, 1, 1, 1, 1);
            DateTime endTime = new DateTime(2001, 1, 1, 2, 1, 1);

            //Test
            Assert.IsFalse(job.isRunning);
            Assert.AreEqual<DateTime>(TimeHelper.Null(), job.startTime);
            Assert.AreEqual<DateTime>(TimeHelper.Null(), job.endTime);

            //Execute
            job.start(startTime);

            //Test
            Assert.IsTrue(job.isRunning);
            Assert.AreEqual<DateTime>(startTime, job.startTime);
            Assert.AreEqual<DateTime>(TimeHelper.Null(), job.endTime);

            //Execute
            job.stop(endTime);

            //Test
            Assert.IsFalse(job.isRunning);
            Assert.AreEqual<DateTime>(startTime, job.startTime);
            Assert.AreEqual<DateTime>(endTime, job.endTime);

            //Execute
            DateTime startTime2 = new DateTime(2002, 1, 1, 1, 1, 1);
            job.start(startTime2);

            //Test
            Assert.IsTrue(job.isRunning);
            Assert.AreEqual<DateTime>(startTime2, job.startTime);
            Assert.AreEqual<DateTime>(TimeHelper.Null(), job.endTime);
        }

        [TestMethod]
        public void CurrentWorkingTime()
        {
            //Setup
            string jobname = "CurrentWorkingTime";
            Job job = new Job(jobname);

            //Execute
            DateTime startTime = new DateTime(2000, 1, 1, 1, 1, 1);
            job.start(startTime);

            //Test
            DateTime currentTime = new DateTime(2000, 1, 1, 2, 2, 2);
            Assert.AreEqual<TimeSpan>(new TimeSpan(1, 1, 1), job.currentWorkingTime(currentTime));

            currentTime = new DateTime(2000, 1, 1, 3, 3, 3);
            Assert.AreEqual<TimeSpan>(new TimeSpan(2, 2, 2), job.currentWorkingTime(currentTime));


            //Execute
            DateTime endTime = new DateTime(2000, 1, 1, 4, 4, 4);
            job.stop(endTime);

            Assert.AreEqual<TimeSpan>(new TimeSpan(0), job.currentWorkingTime(currentTime));
        }

        [TestMethod]
        public void totalWorkingTime()
        {
            //Setup
            string jobname = "TotalWorkingTime";
            Job job = new Job(jobname);

            //Execute
            DateTime startTime = new DateTime(2000, 1, 1, 1, 1, 1);
            DateTime endTime = new DateTime(2000, 1, 1, 2, 2, 2);
            job.start(startTime);
            job.stop(endTime);

            //Test
            Assert.AreEqual<string>("01:01:01", job.totalWorkingTime);

            //Execute
            startTime = new DateTime(2000, 1, 1, 3, 3, 3);
            endTime = new DateTime(2000, 1, 1, 4, 4, 4);
            job.start(startTime);
            job.stop(endTime);

            Assert.AreEqual<string>("02:02:02", job.totalWorkingTime);
        }
    }
}
