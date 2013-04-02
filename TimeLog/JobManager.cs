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
        public void CreateNewJob(string jobname)
        {
            //check if already exists.
            using (var context = new JobContext())
            {
                try
                {
                    var job = context.Jobs.First(j => j.name == jobname);
                    if (job != null)
                    {
                        Debug.WriteLine(jobname + "はすでにテーブルに存在しているため追加しませんでした。");
                        return;
                    }
                }
                catch
                {
                }

                
            }

            Job newjob = new Job(jobname);
            using (var context = new JobContext())
            {

                context.Jobs.Add(newjob);
                context.SaveChanges();
            }
        }

        public bool IsThereJob(string jobname)
        {
            using (var context = new JobContext())
            {
                Job job = null;
                try
                {
                    job = context.Jobs.First(j => j.name == jobname);
                }
                catch { }

                if (job != null)
                    return true;
                else
                    return false;
            }
        }

        public void StartJob(string jobname)
        {
            using (var context = new JobContext())
            {
                var job = context.Jobs.First(j => j.name == jobname);
                job.start(DateTime.Now);
                context.SaveChanges();
            }
        }

        public bool IsRunningJob(string jobname)
        {
            using (var context = new JobContext())
            {
                try
                {
                    var job = context.Jobs.First(j => j.name == jobname);
                    return job.isRunning;
                }
                catch
                {
                    return false;
                }
                
            }
        }

        public void StopJob(string jobname)
        {
            using (var context = new JobContext())
            {
                var job = context.Jobs.First(j => j.name == jobname);
                DateTime now = DateTime.Now;
                job.stop(now);

                JobRecord record = new JobRecord(job);
                context.JobRecords.Add(record);

                context.SaveChanges();
            }
        }

        public string currentWorkingTime(string jobname)
        {
            using (var context = new JobContext())
            {
                var job = context.Jobs.First(j => j.name == jobname);
                TimeSpan time = job.currentWorkingTime(DateTime.Now);
                return TimeHelper.Timespan2String(time);
            }
        }

        


        public string totalWorkingTime(string jobname)
        {
            using (var context = new JobContext())
            {
                var job = context.Jobs.First(j => j.name == jobname);

                TimeSpan time = TimeHelper.String2Timespan(job.totalWorkingTime);
                if (job.isRunning)
                    time = time.Add(job.currentWorkingTime(DateTime.Now));
                return TimeHelper.Timespan2String(time);
            }
        }



        public List<string> GetJobList()
        {
            List<string> joblist = new List<string>();

            using (var context = new JobContext())
            {
                foreach (var job in context.Jobs)
                {
                    joblist.Add(job.name);
                }
            }

            return joblist;
        }

        public List<JobRecord> GetAllRecordAboutJob(string jobname)
        {
            try
            {
                using (var context = new JobContext())
                {
                    var records = from record in context.JobRecords
                                  where record.name == jobname
                                  select record;
                    return records.ToList();
                }
            }
            catch
            {
                return null;
            }
        }
    }
    
}
