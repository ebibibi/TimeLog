namespace TimeLog
{
    partial class MainForm
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.currentWorkingTimeLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.totalWorkingTimeLabel = new System.Windows.Forms.Label();
            this.jobNameTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.jobIconsFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(261, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.fileToolStripMenuItem.Text = "File(&F)";
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // currentWorkingTimeLabel
            // 
            this.currentWorkingTimeLabel.AutoSize = true;
            this.currentWorkingTimeLabel.Font = new System.Drawing.Font("Verdana", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentWorkingTimeLabel.Location = new System.Drawing.Point(71, 24);
            this.currentWorkingTimeLabel.Name = "currentWorkingTimeLabel";
            this.currentWorkingTimeLabel.Size = new System.Drawing.Size(149, 35);
            this.currentWorkingTimeLabel.TabIndex = 1;
            this.currentWorkingTimeLabel.Text = "00:00:00";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "経過時間";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "合計時間";
            // 
            // totalWorkingTimeLabel
            // 
            this.totalWorkingTimeLabel.AutoSize = true;
            this.totalWorkingTimeLabel.Font = new System.Drawing.Font("Verdana", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalWorkingTimeLabel.Location = new System.Drawing.Point(71, 62);
            this.totalWorkingTimeLabel.Name = "totalWorkingTimeLabel";
            this.totalWorkingTimeLabel.Size = new System.Drawing.Size(149, 35);
            this.totalWorkingTimeLabel.TabIndex = 1;
            this.totalWorkingTimeLabel.Text = "00:00:00";
            // 
            // jobNameTextBox
            // 
            this.jobNameTextBox.Location = new System.Drawing.Point(77, 115);
            this.jobNameTextBox.Name = "jobNameTextBox";
            this.jobNameTextBox.Size = new System.Drawing.Size(174, 19);
            this.jobNameTextBox.TabIndex = 3;
            this.jobNameTextBox.TextChanged += new System.EventHandler(this.jobNameTextBox_TextChanged);
            this.jobNameTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.jobNameTextBox_KeyDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 118);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 12);
            this.label5.TabIndex = 2;
            this.label5.Text = "タスク名";
            // 
            // jobIconsFlowLayoutPanel
            // 
            this.jobIconsFlowLayoutPanel.Location = new System.Drawing.Point(14, 140);
            this.jobIconsFlowLayoutPanel.Name = "jobIconsFlowLayoutPanel";
            this.jobIconsFlowLayoutPanel.Size = new System.Drawing.Size(237, 187);
            this.jobIconsFlowLayoutPanel.TabIndex = 4;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(261, 339);
            this.Controls.Add(this.jobIconsFlowLayoutPanel);
            this.Controls.Add(this.jobNameTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.totalWorkingTimeLabel);
            this.Controls.Add(this.currentWorkingTimeLabel);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainForm";
            this.Text = "TimeLog";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.Label currentWorkingTimeLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label totalWorkingTimeLabel;
        private System.Windows.Forms.TextBox jobNameTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.FlowLayoutPanel jobIconsFlowLayoutPanel;
    }
}

