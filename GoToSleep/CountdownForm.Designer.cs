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
            countdown = new Label();
            cancel = new Button();
            execNow = new Button();
            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // countdown
            // 
            countdown.AutoSize = true;
            tableLayoutPanel1.SetColumnSpan(countdown, 2);
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
            cancel.Location = new Point(245, 68);
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
            execNow.Location = new Point(164, 68);
            execNow.Name = "execNow";
            execNow.Size = new Size(75, 23);
            execNow.TabIndex = 2;
            execNow.Text = "Execute";
            execNow.UseVisualStyleBackColor = true;
            execNow.Click += execNow_Click;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(countdown, 0, 0);
            tableLayoutPanel1.Controls.Add(cancel, 1, 1);
            tableLayoutPanel1.Controls.Add(execNow, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 33F));
            tableLayoutPanel1.Size = new Size(484, 96);
            tableLayoutPanel1.TabIndex = 3;
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
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label countdown;
        private Button cancel;
        private Button execNow;
        private TableLayoutPanel tableLayoutPanel1;
    }
}