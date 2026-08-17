namespace GoToSleep
{
    partial class GoToSleep
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GoToSleep));
            comboBox1 = new ComboBox();
            shutdownButton = new Button();
            suspendButton = new Button();
            hibernateButton = new Button();
            textBox1 = new TextBox();
            tableLayoutPanel2 = new TableLayoutPanel();
            flowLayoutPanel1 = new FlowLayoutPanel();
            tableLayoutPanel2.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "In", "At" });
            comboBox1.Location = new Point(3, 3);
            comboBox1.MinimumSize = new Size(50, 0);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(50, 23);
            comboBox1.TabIndex = 0;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // shutdownButton
            // 
            shutdownButton.Location = new Point(185, 3);
            shutdownButton.Margin = new Padding(3, 3, 0, 3);
            shutdownButton.Name = "shutdownButton";
            shutdownButton.Size = new Size(75, 23);
            shutdownButton.TabIndex = 1;
            shutdownButton.Text = "Shutdown";
            shutdownButton.UseVisualStyleBackColor = true;
            shutdownButton.Click += shutdownButton_Click;
            // 
            // suspendButton
            // 
            suspendButton.Location = new Point(104, 3);
            suspendButton.Name = "suspendButton";
            suspendButton.Size = new Size(75, 23);
            suspendButton.TabIndex = 2;
            suspendButton.Text = "Suspend";
            suspendButton.UseVisualStyleBackColor = true;
            suspendButton.Click += suspendButton_Click;
            // 
            // hibernateButton
            // 
            hibernateButton.Location = new Point(23, 3);
            hibernateButton.Name = "hibernateButton";
            hibernateButton.Size = new Size(75, 23);
            hibernateButton.TabIndex = 3;
            hibernateButton.Text = "Hibernate";
            hibernateButton.UseVisualStyleBackColor = true;
            hibernateButton.Click += hibernateButton_Click;
            // 
            // textBox1
            // 
            textBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBox1.Location = new Point(59, 3);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(422, 23);
            textBox1.TabIndex = 4;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel2.Controls.Add(comboBox1, 0, 0);
            tableLayoutPanel2.Controls.Add(textBox1, 1, 0);
            tableLayoutPanel2.Controls.Add(flowLayoutPanel1, 1, 1);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(0, 0);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 2;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle());
            tableLayoutPanel2.Size = new Size(484, 64);
            tableLayoutPanel2.TabIndex = 6;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            flowLayoutPanel1.Controls.Add(shutdownButton);
            flowLayoutPanel1.Controls.Add(suspendButton);
            flowLayoutPanel1.Controls.Add(hibernateButton);
            flowLayoutPanel1.FlowDirection = FlowDirection.RightToLeft;
            flowLayoutPanel1.Location = new Point(221, 33);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(260, 41);
            flowLayoutPanel1.TabIndex = 7;
            // 
            // GoToSleep
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(484, 64);
            Controls.Add(tableLayoutPanel2);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(500, 103);
            Name = "GoToSleep";
            Text = "Go To Sleep";
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private ComboBox comboBox1;
        private Button shutdownButton;
        private Button suspendButton;
        private Button hibernateButton;
        private TextBox textBox1;
        private TableLayoutPanel tableLayoutPanel2;
        private FlowLayoutPanel flowLayoutPanel1;
    }
}
