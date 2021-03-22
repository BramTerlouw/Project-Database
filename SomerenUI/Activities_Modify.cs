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

            if (String.IsNullOrEmpty(txtAddActivityId.Text) || String.IsNullOrEmpty(txtAddDescription.Text) || String.IsNullOrEmpty(txtAddActivityStudents.Text) 
                || String.IsNullOrEmpty(txtAddActivityBegeleiders.Text))
            {
                MessageBox.Show("Field(s) empty!");
                return;
            }

            int id = int.Parse(txtAddActivityId.Text);
            string description = txtAddDescription.Text;
            int aantal_Students = int.Parse(txtAddActivityStudents.Text);
            int aantal_Begeleiders = int.Parse(txtAddActivityBegeleiders.Text);


            activity_Service.InsertActivity(id, description, aantal_Students, aantal_Begeleiders);
        }

        private void btnDeleteActivity_Click(object sender, EventArgs e)
        {
            SomerenLogic.Activity_Service activity_Service = new Activity_Service();

            if (String.IsNullOrEmpty(txtDeleteId.Text))
            {
                MessageBox.Show("No id was given!");
                return;
            }

            int id = int.Parse(txtDeleteId.Text);

            string message = "Are you sure you want to delete this activity?";
            string caption = "Deleting an activity";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;

            result = MessageBox.Show(this, message, caption, buttons);

            if (result == DialogResult.Yes)
                activity_Service.DeleteActivity(id);
        }

        private void btnCloseActivityModify_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnChangeActivity_Click(object sender, EventArgs e)
        {
            SomerenLogic.Activity_Service activity_Service = new Activity_Service();

            if (String.IsNullOrEmpty(txtChangeActivityId.Text) || String.IsNullOrEmpty(txtChangeActivityName.Text))
            {
                MessageBox.Show("Field(s) empty!");
                return;
            }

            int id = int.Parse(txtChangeActivityId.Text);
            string description = txtChangeActivityName.Text;

            activity_Service.ChangeActivity(id, description);
        }
    }
}
