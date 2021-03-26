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
        SomerenLogic.Activity_Service activity_Service = new SomerenLogic.Activity_Service(); // reference to logic layer
        public Rooster_Modify()
        {
            InitializeComponent();

            // get all activities
            List<Activity> rooster = activity_Service.GetActivities();

            // fill both comboboxes with those activities
            foreach (Activity activity in rooster)
            {
                cmbActivity1.Items.Add(activity.id);
                cmbActivity2.Items.Add(activity.id);
            }

            // set both selected index to 0
            cmbActivity1.SelectedIndex = 0;
            cmbActivity2.SelectedIndex = 0;
        }

        private void btnSwapActivities_Click(object sender, EventArgs e)
        {
            // get the selected index
            int activity1 = cmbActivity1.SelectedIndex + 1;
            int activity2 = cmbActivity2.SelectedIndex + 1;

            // validate the given index
            if (activity1 == activity2)
            {
                MessageBox.Show("These dates are the same!"); // when the samen are selected show a messagebox
            }
            else
            {
                // get the start and end date for activity 1
                string startactivity1 = activity_Service.GetDateTimeActivityStart(activity1);
                string endactivity1 = activity_Service.GetDateTimeActivityEnd(activity1);

                // get the start and end date for activity 2
                string startactivity2 = activity_Service.GetDateTimeActivityStart(activity2);
                string endactivity2 = activity_Service.GetDateTimeActivityEnd(activity2);

                // swap the dates for the activities
                activity_Service.SwapActivities(activity1, startactivity2, endactivity2);
                activity_Service.SwapActivities(activity2, startactivity1, endactivity1);
            }
        }

        private void btnCloseSwap_Click(object sender, EventArgs e)
        {
            // close the form
            this.Close();
        }
    }
}
