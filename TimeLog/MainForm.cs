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
            Button jobIcon = new Button();
            jobIcon.Text = jobname;
            jobIcon.Click += jobIcon_Click;

            jobIconsFlowLayoutPanel.Controls.Add(jobIcon);
        }

        void jobIcon_Click(object sender, EventArgs e)
        {
            Button jobIcon = (Button)sender;
            string jobname = jobIcon.Text;

            //job stop
            if (this.currentJobName != null)
            {
                jobManager.StopJob(this.currentJobName);
                jobIcon.BackColor = SystemColors.Control;
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
    }
}
