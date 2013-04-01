using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity.Validation;
using System.Diagnostics;

namespace TimeLog
{
    public class JobManager
    {
        private static Dictionary<string, Job> jobs = new Dictionary<string, Job>();
        
        public void CreateNewJob(string jobname)
        {
            Job job = new Job(jobname);
            jobs.Add(jobname, job);

            using (var context = new JobContext())
            {
                context.Jobs.Add(job);
                context.SaveChanges();
            }
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

        public string currentWorkingTime(string jobname)
        {
            TimeSpan time = jobs[jobname].currentWorkingTime(DateTime.Now);
            return TimeHelper.Timespan2String(time);
        }

        


        public string totalWorkingTime(string jobname)
        {
            TimeSpan time = TimeHelper.String2Timespan(jobs[jobname].totalWorkingTime);
            if (jobs[jobname].isRunning)
                time = time.Add(jobs[jobname].currentWorkingTime(DateTime.Now));
            return TimeHelper.Timespan2String(time);
        }

        
    }
    
}
