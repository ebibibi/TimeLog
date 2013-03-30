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
    }
}
