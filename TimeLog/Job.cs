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

        private TimeSpan _totalWorkingTime;
        public string totalWorkingTime 
        {
            get { return TimeHelper.Timespan2String(_totalWorkingTime); }
            set { _totalWorkingTime = TimeHelper.String2Timespan(value); }
        }

        public Job(string jobname)
        {
            this.name = jobname;
            this.isRunning = false;
            this.startTime = TimeHelper.Null();
            this.endTime = TimeHelper.Null();
            this._totalWorkingTime = new TimeSpan(0);
            
        }

        public Job(string jobname, TimeSpan totalWorkingTime) : this(jobname)
        {
            this._totalWorkingTime = totalWorkingTime;

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
            this._totalWorkingTime += this.endTime - this.startTime;
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
