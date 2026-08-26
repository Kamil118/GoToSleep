using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Runtime.CompilerServices;

namespace GoToSleep
{
    public partial class CountdownForm : Form
    {
        public bool active = true;
        private PowerDownData task;
        private Thread taskThread;

        private FormCollection windowsToRestore;

        private Form parent;


        public CountdownForm(PowerDownData taskData, Form parent)
        {
            this.parent = parent;

            task = taskData;
            InitializeComponent();
            this.Text = task.actionType.ToString() + " Countdown";
            countdown.Text = getTimerText();
            taskThread = new Thread(threadFunction);
            taskThread.Start();
            windowsToRestore = Application.OpenForms;

            // Remove placeholders and replace with labels because the editor
            // doesn't let you add the lables directly.
            notificationMenu.Items.RemoveAt(0);
            notificationMenu.Items.RemoveAt(0);
            notificationMenu.Items.Insert(0, new ToolStripLabel());
            notificationMenu.Items.Insert(0, new ToolStripLabel());

            notificationMenu.Items[0].Text = task.actionType.ToString();
            notificationMenu.Items[0].Padding = new Padding { Top = 1, Bottom = 1 };

            notificationMenu.Items[1].Text = countdown.Text;
            notificationMenu.Items[1].Padding = new Padding { Top = 1, Bottom = 1 };

            trayIcon.Text = task.actionType.ToString() + "\n" + countdown.Text;

        }
        string getTimerText()
        {
            var timeRemaining = task.when - DateTime.Now;
            return $"Time Remaining: {(int)timeRemaining.TotalHours:D2}:{timeRemaining.Minutes:D2}:{timeRemaining.Seconds:D2}";
        }

        void updateTimer()
        {

            try
            {
                countdown.Invoke((MethodInvoker)delegate
                {
                    // both controls should be owned by same thread
                    countdown.Text = getTimerText();
                    notificationMenu.Items[1].Text = countdown.Text;
                    trayIcon.Text = task.actionType.ToString() + "\n" + countdown.Text;
                });
            }
            catch
            {
                //the window most likely has been closed
                return;
            }
        }

        void threadFunction()
        {
            while (DateTime.Now < task.when)
            {
                Thread.Sleep(1000);
                if (!active)
                {
                    return;
                }
                updateTimer();

            }
            executeStateChange();
        }

        void executeStateChange()
        {
            active = false;
            task.onCountdownEnd();

            this.Invoke((MethodInvoker)delegate
            {
                this.Close();
            });

        }

        private void execNow_Click(object sender, EventArgs e)
        {
            executeStateChange();
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            active = false;
            this.Close();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.None && this.Visible == false)
            {
                // the window has been minimzed to tray, do not destroy it
                e.Cancel = true;
                return;
            }
            parent.Enabled = true;
            trayIcon.Visible = false;
            base.OnFormClosing(e);
            active = false;
        }

        private void countdown_Click(object sender, EventArgs e)
        {

        }

        private void onResize(object sender, EventArgs e)
        {
            return;
            // do we even want this behavior?
            //if (this.WindowState == FormWindowState.Minimized)
            //{
            //    hideToSystemTray(sender, e);
            //}
        }

        private void hideToSystemTray(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                form.Visible = false;
            }
            trayIcon.Visible = true;
        }

        private void restoreFromSystemTray(object sender, EventArgs e)
        {
            foreach (Form form in this.windowsToRestore)
            {
                form.Show();
            }
            this.Activate();
            trayIcon.Visible = false;
        }

        private void execNowTray_Click(object sender, EventArgs e)
        {
            parent.Visible = true;
            trayIcon.Visible = false;
            execNow_Click(sender, e);
        }

        private void cancelTray_Click(object sender, EventArgs e)
        {
            parent.Visible = true;
            trayIcon.Visible = false;
            cancel_Click(sender, e);
        }
    }
}
