using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimeLog
{
    public partial class MainForm : Form
    {
        private static JobManager jobManager = new JobManager();
        public string currentJobName { get; set; }

        public MainForm()
        {
            InitializeComponent();
            currentJobName = null;

            foreach(var job in jobManager.GetJobList())
            {
                CreateJobIcon(job);
            }
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void jobNameTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void jobNameTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.Enter)
            {
                if (jobNameTextBox.Text != null)
                {
                    string jobname = jobNameTextBox.Text;
                    if (jobManager.IsThereJob(jobname) == false)
                    {
                        jobManager.CreateNewJob(jobname);
                        this.CreateJobIcon(jobname);
                    }
                    jobNameTextBox.Text = "";
                }
            }

        }

        private void CreateJobIcon(string jobname)
        {
            Button jobButton = new Button();
            jobButton.Name = jobname;
            jobButton.Text = jobname;
            jobButton.Click += jobButton_Click;

            //size
            Size size = TextRenderer.MeasureText(jobname, new Font("Verdana", 10));
            jobButton.Width = size.Width;

            jobButton.ContextMenuStrip = jobButtonContextMenuStrip;
            jobIconsFlowLayoutPanel.Controls.Add(jobButton);
        }

        void jobButton_Click(object sender, EventArgs e)
        {
            Button jobIcon = (Button)sender;
            string jobname = jobIcon.Text;

            //job stop
            if (this.currentJobName != null)
            {
                jobManager.StopJob(this.currentJobName);
                Button button = (Button)jobIconsFlowLayoutPanel.Controls.Find(this.currentJobName, false)[0];
                button.BackColor = SystemColors.Control;
            }

            //when same value -> job stop only.
            if (currentJobName != null && currentJobName.CompareTo(jobname) == 0)
            {
                this.currentJobName = null;
                timer.Stop();
                return;
            }


            //job start
            this.currentJobName = jobname;
            jobIcon.BackColor = SystemColors.Highlight;
            jobManager.StartJob(jobname);
            timer.Start();
        }

        

        private void timer_Tick(object sender, EventArgs e)
        {
            FormRewrite();
        }

        private void FormRewrite()
        {
            currentWorkingTimeLabel.Text = jobManager.currentWorkingTime(currentJobName);
            totalWorkingTimeLabel.Text = jobManager.totalWorkingTime(currentJobName);
        }

        private void cSVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.FileName = "workhistory.csv";
            sfd.InitialDirectory = @"C:\";
            sfd.Title = "保存先のファイルを選択してください";
            sfd.RestoreDirectory = true;
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                System.IO.Stream stream;
                stream = sfd.OpenFile();
                if (stream != null)
                {
                    System.IO.StreamWriter sw = new System.IO.StreamWriter(stream);

                    //header
                    sw.WriteLine("name, date, starttime, endtime, duration");

                    List<JobRecord> records = jobManager.GetAllJobRecords();
                    foreach (JobRecord record in records)
                    {
                        sw.WriteLine("{0},{1},{2},{3},{4}", record.name, record.date, record.startTime, record.endTime, record.duration);
                    }
                    
                    sw.Close();
                    stream.Close();
                }
            }
        }

        private void toolStripMenuItem_deleteButton_Click(object sender, EventArgs e)
        {
            ToolStripItem item = sender as ToolStripItem;
            ContextMenuStrip strip = item.Owner as ContextMenuStrip;
            Button button = strip.SourceControl as Button;

            string jobname = button.Text;
            jobManager.DeleteJob(jobname);

            button.Visible = false;

        }
    }
}
