namespace SpikeDetectorRMS
{
    public partial class SpikeDetectorRMSControl : UserControl
    {
        public SpikeDetectorRMSControl()
        {
            InitializeComponent();
        }

        private void btCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                if (btCalculate.Text == "Calculate")
                {

                }
                else
                {
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #region Load/Save
        private void btSave_Click(object sender, EventArgs e)
        {

        }

        private void btLoad_Click(object sender, EventArgs e)
        {

        }
        #endregion

        private void lbxDetectedSpikes_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
