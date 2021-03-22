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
            int id = int.Parse(txtAddActivityId.Text);
            string description = txtAddDescription.Text;
            int aantal_Students = int.Parse(txtAddActivityStudents.Text);
            int aantal_Begeleiders = int.Parse(txtAddActivityBegeleiders.Text);

            SomerenLogic.Activity_Service activity_Service = new Activity_Service();
            activity_Service.InsertActivity(id, description, aantal_Students, aantal_Begeleiders);
        }

        private void btnDeleteActivity_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtDeleteId.Text);

            SomerenLogic.Activity_Service activity_Service = new Activity_Service();
            activity_Service.DeleteActivity(id);
        }

        private void btnCloseActivityModify_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnChangeActivity_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtChangeActivityId.Text);
            string description = txtChangeActivityName.Text;

            SomerenLogic.Activity_Service activity_Service = new Activity_Service();
            activity_Service.ChangeActivity(id, description);
        }
    }
}
