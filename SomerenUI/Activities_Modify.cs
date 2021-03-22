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
    public partial class Activities_Modify : Form
    {
        public Activities_Modify()
        {
            InitializeComponent();
        }

        private void btnAddActivity_Click(object sender, EventArgs e)
        {
            SomerenLogic.Activity_Service activity_Service = new Activity_Service();

            // check for empty fields
            if (String.IsNullOrEmpty(txtAddActivityId.Text) || String.IsNullOrEmpty(txtAddDescription.Text) || String.IsNullOrEmpty(txtAddActivityStudents.Text) 
                || String.IsNullOrEmpty(txtAddActivityBegeleiders.Text))
            {
                MessageBox.Show("Field(s) empty!");
                return; // when a field is empty, display message and return
            }

            // get all values from the textboxes
            int id = int.Parse(txtAddActivityId.Text);
            string description = txtAddDescription.Text;
            int aantal_Students = int.Parse(txtAddActivityStudents.Text);
            int aantal_Begeleiders = int.Parse(txtAddActivityBegeleiders.Text);

            // insert the activity, reference to service layer
            activity_Service.InsertActivity(id, description, aantal_Students, aantal_Begeleiders);
        }

        private void btnDeleteActivity_Click(object sender, EventArgs e)
        {
            SomerenLogic.Activity_Service activity_Service = new Activity_Service();

            // check for empty field
            if (String.IsNullOrEmpty(txtDeleteId.Text))
            {
                MessageBox.Show("No id was given!");
                return; // when field is empty, display message and return
            }

            // get value from textbox
            int id = int.Parse(txtDeleteId.Text);

            // validate the users choice by asking via a messagebox
            string message = "Are you sure you want to delete this activity?";
            string caption = "Deleting an activity";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo; // yes and no button
            DialogResult result;

            // get the result from the messagebox
            result = MessageBox.Show(this, message, caption, buttons);

            // when user says yes, delete the acticvity
            if (result == DialogResult.Yes)
                activity_Service.DeleteActivity(id);
        }

        private void btnCloseActivityModify_Click(object sender, EventArgs e)
        {
            // close activity modify menu
            this.Close();
        }

        private void btnChangeActivity_Click(object sender, EventArgs e)
        {
            SomerenLogic.Activity_Service activity_Service = new Activity_Service();

            // check for empty fields
            if (String.IsNullOrEmpty(txtChangeActivityId.Text) || String.IsNullOrEmpty(txtChangeActivityName.Text))
            {
                MessageBox.Show("Field(s) empty!");
                return; // when fields are empty display message and return
            }

            // get values from textboxes
            int id = int.Parse(txtChangeActivityId.Text);
            string description = txtChangeActivityName.Text;

            // change activity
            activity_Service.ChangeActivity(id, description);
        }
    }
}
