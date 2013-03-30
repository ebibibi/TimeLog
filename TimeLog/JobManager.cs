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

        public void StartJob(string jobname)
        {
            Job job = jobs[jobname];
            job.start(DateTime.Now);
        }

        public bool IsRunningJob(string jobname)
        {
            Job job;
            try
            {
                job = jobs[jobname];
            } catch {
                return false;
            }
            return job.isRunning;
        }

        public void StopJob(string jobname)
        {
            jobs[jobname].stop(DateTime.Now);
        }
    }
    
}
