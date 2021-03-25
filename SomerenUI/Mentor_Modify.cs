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
    public partial class Mentor_Modify : Form
    {
        SomerenLogic.Teacher_Service teacher_Service = new SomerenLogic.Teacher_Service();
        public Mentor_Modify()
        {
            InitializeComponent();
        }

        private void btnAddMentor_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtAddMentorGroup.Text) || String.IsNullOrEmpty(txtAddMentorTeacher.Text))
            {
                MessageBox.Show("Empty field(s)");
                return;
            }

            try
            {
                int groupId = int.Parse(txtAddMentorGroup.Text);
                int teacherId = int.Parse(txtAddMentorTeacher.Text);

                teacher_Service.AddMentor(groupId, teacherId);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDeleteMonitor_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtDeleteMentorGroup.Text) || String.IsNullOrEmpty(txtDeleteMentorTeacher.Text))
            {
                MessageBox.Show("Empty field(s)");
                return;
            }

            int groupId = int.Parse(txtDeleteMentorGroup.Text);
            int teacherId = int.Parse(txtDeleteMentorTeacher.Text);

            // validate the users choice by asking via a messagebox
            string message = "Are you sure you want to delete this mentor?";
            string caption = "Deleting a mentor";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo; // yes and no button
            DialogResult result;

            // get the result from the messagebox
            result = MessageBox.Show(this, message, caption, buttons);

            // when user says yes, delete the acticvity
            if (result == DialogResult.Yes)
                teacher_Service.DeleteMentor(groupId, teacherId);
        }

        private void btnCloseModifyMentor_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
