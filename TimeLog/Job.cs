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
        

        public Job(string jobname)
        {
            this.name = jobname;
        }

        public void start(DateTime startTime)
        {
            this.startTime = startTime;
            return;
        }

        public void stop(DateTime endTime)
        {
            this.endTime = endTime;
            return;
        }
    }
}
