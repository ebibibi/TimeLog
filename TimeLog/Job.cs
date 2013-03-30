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
        public TimeSpan totalWorkingTime { get; set; }

        public Job(string jobname)
        {
            this.name = jobname;
            this.isRunning = false;
            this.startTime = new DateTime(0); 
            this.endTime = new DateTime(0);
            this.totalWorkingTime = new TimeSpan(0);
            
        }

        public Job(string jobname, TimeSpan totalWorkingTime) : this(jobname)
        {
            this.totalWorkingTime = totalWorkingTime;

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
            this.totalWorkingTime += this.endTime - this.startTime;
            return;
        }



        public TimeSpan currentWorkingTime(DateTime currentTime)
        {
            if (this.isRunning)
            {
                return currentTime - this.startTime;
            }
            else
            {
                return new TimeSpan(0);
            }
        
        }

        
    }
}
