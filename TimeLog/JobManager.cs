using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TimeLog
{
    public class JobManager
    {
        private static Dictionary<string, Job> jobs = new Dictionary<string, Job>();
        
        public void CreateNewJob(string jobname)
        {
            Job job = new Job(jobname);
            jobs.Add(jobname, job);
        }

        public bool IsThereJob(string jobname)
        {
            Job job = null;
            try
            {
                job = jobs[jobname];
            }
            catch {}

            if (job != null)
            {
                return true;
            }
            else
            {
                return false;
            }
                
        }
    }
    
}
