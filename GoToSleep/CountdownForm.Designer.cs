namespace GoToSleep
{
    partial class CountdownForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CountdownForm));
            countdown = new Label();
            cancel = new Button();
            execNow = new Button();
            tableLayoutPanel1 = new TableLayoutPanel();
            HideToSystemTray = new Button();
            trayIcon = new NotifyIcon(components);
            notificationMenu = new ContextMenuStrip(components);
            actionPHToolStripMenuItem = new ToolStripMenuItem();
            cDPHToolStripMenuItem = new ToolStripMenuItem();
            executeToolStripMenuItem = new ToolStripMenuItem();
            cancelToolStripMenuItem = new ToolStripMenuItem();
            tableLayoutPanel1.SuspendLayout();
            notificationMenu.SuspendLayout();
            SuspendLayout();
            // 
            // countdown
            // 
            countdown.AutoSize = true;
            tableLayoutPanel1.SetColumnSpan(countdown, 3);
            countdown.Dock = DockStyle.Fill;
            countdown.Font = new Font("Segoe UI", 27.75F, FontStyle.Regular, GraphicsUnit.Point, 238);
            countdown.Location = new Point(3, 0);
            countdown.Name = "countdown";
            countdown.Size = new Size(478, 63);
            countdown.TabIndex = 0;
            countdown.Text = "Time Remaining: 99:99:99";
            countdown.TextAlign = ContentAlignment.MiddleCenter;
            countdown.Click += countdown_Click;
            // 
            // cancel
            // 
            cancel.Anchor = AnchorStyles.Left;
            cancel.Location = new Point(285, 68);
            cancel.Name = "cancel";
            cancel.Size = new Size(75, 23);
            cancel.TabIndex = 1;
            cancel.Text = "Cancel";
            cancel.UseVisualStyleBackColor = true;
            cancel.Click += cancel_Click;
            // 
            // execNow
            // 
            execNow.Anchor = AnchorStyles.Right;
            execNow.Location = new Point(123, 68);
            execNow.Name = "execNow";
            execNow.Size = new Size(75, 23);
            execNow.TabIndex = 2;
            execNow.Text = "Execute";
            execNow.UseVisualStyleBackColor = true;
            execNow.Click += execNow_Click;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 81F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(HideToSystemTray, 1, 1);
            tableLayoutPanel1.Controls.Add(countdown, 0, 0);
            tableLayoutPanel1.Controls.Add(execNow, 0, 1);
            tableLayoutPanel1.Controls.Add(cancel, 2, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 33F));
            tableLayoutPanel1.Size = new Size(484, 96);
            tableLayoutPanel1.TabIndex = 3;
            // 
            // HideToSystemTray
            // 
            HideToSystemTray.Anchor = AnchorStyles.Right;
            HideToSystemTray.Location = new Point(204, 68);
            HideToSystemTray.Name = "HideToSystemTray";
            HideToSystemTray.Size = new Size(75, 23);
            HideToSystemTray.TabIndex = 3;
            HideToSystemTray.Text = "Hide";
            HideToSystemTray.UseVisualStyleBackColor = true;
            HideToSystemTray.Click += hideToSystemTray;
            // 
            // trayIcon
            // 
            trayIcon.ContextMenuStrip = notificationMenu;
            trayIcon.Icon = (Icon)resources.GetObject("trayIcon.Icon");
            trayIcon.Text = "notifyIcon1";
            trayIcon.DoubleClick += restoreFromSystemTray;
            // 
            // notificationMenu
            // 
            notificationMenu.Items.AddRange(new ToolStripItem[] { actionPHToolStripMenuItem, cDPHToolStripMenuItem, executeToolStripMenuItem, cancelToolStripMenuItem });
            notificationMenu.Name = "contextMenuStrip1";
            notificationMenu.Size = new Size(137, 92);
            // 
            // actionPHToolStripMenuItem
            // 
            actionPHToolStripMenuItem.Enabled = false;
            actionPHToolStripMenuItem.Name = "actionPHToolStripMenuItem";
            actionPHToolStripMenuItem.Size = new Size(136, 22);
            actionPHToolStripMenuItem.Text = "Placeholder";
            // 
            // cDPHToolStripMenuItem
            // 
            cDPHToolStripMenuItem.Name = "cDPHToolStripMenuItem";
            cDPHToolStripMenuItem.Size = new Size(136, 22);
            cDPHToolStripMenuItem.Text = "Placeholder";
            // 
            // executeToolStripMenuItem
            // 
            executeToolStripMenuItem.Name = "executeToolStripMenuItem";
            executeToolStripMenuItem.Size = new Size(136, 22);
            executeToolStripMenuItem.Text = "Execute";
            executeToolStripMenuItem.Click += execNowTray_Click;
            // 
            // cancelToolStripMenuItem
            // 
            cancelToolStripMenuItem.Name = "cancelToolStripMenuItem";
            cancelToolStripMenuItem.Size = new Size(136, 22);
            cancelToolStripMenuItem.Text = "Cancel";
            cancelToolStripMenuItem.Click += cancelTray_Click;
            // 
            // CountdownForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(484, 96);
            Controls.Add(tableLayoutPanel1);
            MinimumSize = new Size(500, 135);
            Name = "CountdownForm";
            Text = "CountdownForm";
            Shown += CountdownForm_Shown;
            Resize += onResize;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            notificationMenu.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Label countdown;
        private Button cancel;
        private Button execNow;
        private TableLayoutPanel tableLayoutPanel1;
        private Button HideToSystemTray;
        private NotifyIcon trayIcon;
        private ContextMenuStrip notificationMenu;
        private ToolStripMenuItem actionPHToolStripMenuItem;
        private ToolStripMenuItem cDPHToolStripMenuItem;
        private ToolStripMenuItem executeToolStripMenuItem;
        private ToolStripMenuItem cancelToolStripMenuItem;
    }
}