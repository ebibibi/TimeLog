using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TimeLog
{
    public class Job
    {

        public string name { get; set; }
        public DateTime startTime { get; set; }
        public DateTime endTime { get; set; }
        public bool isRunning { get; set; }

        public Job(string jobname)
        {
            this.name = jobname;
            this.isRunning = false;
            this.startTime = new DateTime(0); 
            this.endTime = new DateTime(0);
            
        }

        public void start(DateTime startTime)
        {
            this.startTime = startTime;
            this.isRunning = true;
            this.endTime = new DateTime(0);
            return;
        }

        public void stop(DateTime endTime)
        {
            this.endTime = endTime;
            this.isRunning = false;
            return;
        }



        public TimeSpan currentWorkingTime(DateTime currentTime)
        {
            return currentTime - this.startTime;
        }
    }
}
