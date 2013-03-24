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

            Job job = new Job();

            //Execute
            job.name = jobname;

            //Test
            Assert.AreEqual<string>(jobname, job.name);
            
        }
    }
}
