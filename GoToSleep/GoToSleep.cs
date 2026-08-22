namespace GoToSleep
{
    public partial class GoToSleep : Form
    {
        string timeSelector = "in";
        SystemPowerManager manager;
        public GoToSleep()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
            textBox1.Select();
            manager = new SystemPowerManager(this);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    timeSelector = "in";
                    break;
                case 1:
                    timeSelector = "";
                    break;
                default:
                    //this should never happen, something went very wrong, the combo box should only have 2 options
                    throw new Exception("Invalid selection index");
            }


        }

        private string getTimeString()
        {
            return timeSelector + " " + textBox1.Text;
        }

        private void shutdownButton_Click(object sender, EventArgs e)
        {
            try
            {
                manager.shutdown(getTimeString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void suspendButton_Click(object sender, EventArgs e)
        {
            try
            {
                manager.suspend(getTimeString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void hibernateButton_Click(object sender, EventArgs e)
        {
            try
            {
                manager.hibernate(getTimeString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void restart_Click(object sender, EventArgs e)
        {
            try
            {
                manager.restart(getTimeString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
