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

        public MainForm()
        {
            InitializeComponent();
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

            jobIconsFlowLayoutPanel.Controls.Add(jobIcon);
        }
    }
}
