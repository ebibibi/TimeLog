using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity.Validation;
using System.Diagnostics;

namespace TimeLog
{
    public class JobRecord
    {
        public JobRecord() { }

        public JobRecord(Job job)
        {
            this.name = job.name;
            this.date = job.startTime.Date;
            this.startTime = job.startTime;
            this.endTime = job.endTime;
            this.duration = TimeHelper.Timespan2String(this.endTime - this.startTime);

        }
        public int JobrecordID { get; set; }
        public string name { get; set; }
        public DateTime date { get; set; }
        public DateTime startTime { get; set; }
        public DateTime endTime { get; set; }
        public string duration { get; set; }
    }
}