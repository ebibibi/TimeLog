using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TimeLog
{
    public class Job
    {
        public int jobID { get; set; }
        public string name { get; set; }
        public DateTime startTime { get; set; }
        public DateTime endTime { get; set; }
        public bool isRunning { get; set; }
        public string totalWorkingTime { get; set; }

        public Job(string jobname)
        {
            this.name = jobname;
            this.isRunning = false;
            this.startTime = TimeHelper.Null();
            this.endTime = TimeHelper.Null();
            this.totalWorkingTime = "00:00:00";
            
        }

        public Job(string jobname, TimeSpan totalWorkingTime) : this(jobname)
        {
            this.totalWorkingTime = Timespan2String(totalWorkingTime);

        }

        public void start(DateTime startTime)
        {
            this.startTime = startTime;
            this.isRunning = true;
            this.endTime = TimeHelper.Null();
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

        private string Timespan2String(TimeSpan time)
        {
            return time.Hours.ToString("00") + ":" + time.Minutes.ToString("00") + ":" + time.Seconds.ToString("00");
        }

        
    }
}
