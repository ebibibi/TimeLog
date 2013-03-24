using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TimeLog
{
    public class Job
    {

        public Job(string jobname)
        {
            this.name = jobname;
        }
        public string name { get; set; }

        public void start(DateTime startTime)
        {
            this.startTime = startTime;
            return;
        }

        public DateTime startTime { get; set; }
    }
}
