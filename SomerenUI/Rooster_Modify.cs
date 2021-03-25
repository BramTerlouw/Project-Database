using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SomerenLogic;
using SomerenModel;

namespace SomerenUI
{
    public partial class Rooster_Modify : Form
    {
        SomerenLogic.Activity_Service activity_Service = new SomerenLogic.Activity_Service();
        public Rooster_Modify()
        {
            InitializeComponent();

            List<Activity> rooster = activity_Service.GetActivities();

            foreach (Activity activity in rooster)
            {
                cmbActivity1.Items.Add(activity.id);
                cmbActivity2.Items.Add(activity.id);
            }
            cmbActivity1.SelectedIndex = 0;
            cmbActivity2.SelectedIndex = 0;
        }

        private void btnSwapActivities_Click(object sender, EventArgs e)
        {
            int activity1 = cmbActivity1.SelectedIndex + 1;
            int activity2 = cmbActivity2.SelectedIndex + 1;

            if (activity1 == activity2)
            {
                MessageBox.Show("These dates are the same!");
            }
            else
            {
                string startactivity1 = activity_Service.GetDateTimeActivityStart(activity1);
                string endactivity1 = activity_Service.GetDateTimeActivityEnd(activity1);

                string startactivity2 = activity_Service.GetDateTimeActivityStart(activity2);
                string endactivity2 = activity_Service.GetDateTimeActivityEnd(activity2);

                activity_Service.SwapActivities(activity1, startactivity2, endactivity2);
                activity_Service.SwapActivities(activity2, startactivity1, endactivity1);
            }
        }

        private void btnCloseSwap_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
