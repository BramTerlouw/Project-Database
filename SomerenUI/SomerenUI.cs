using SomerenModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace SomerenUI
{
    public partial class SomerenUI : Form
    {
        public SomerenUI()
        {
            InitializeComponent();
        }

        private void SomerenUI_Load(object sender, EventArgs e)
        {
            showPanel("pnl_Dashboard");
        }

        private void show_pnl_Dashboard()
        {
            pnl_Dashboard.Show();
            img_Dashboard.Show();
        }

        private void show_pnl_Students()
        {
            pnl_DisplayData.Show();
            
            // fill the students listview within the students panel with a list of students
            SomerenLogic.Student_Service studService = new SomerenLogic.Student_Service();
            List<Student> studentList = studService.GetStudents();
            ClearDataGridView();
            generateGridLayout(studentList.FirstOrDefault().dataGridList());

            foreach (var student in studentList)
            {
                FillDataInGridView(student.dataGrid(student));
            }
        }


        private void show_pnl_Teachers()
        {
            pnl_DisplayData.Show();

            // fill the teachers listview within the teachers panel with a list of teachers
            SomerenLogic.Teacher_Service teachService = new SomerenLogic.Teacher_Service();
            List<Teacher> teacherList = teachService.GetTeachers();

            ClearDataGridView();
            // clear the listview before filling it again
            /*listViewStudents.Clear();

            foreach (SomerenModel.Teacher s in teacherList)
            {
                ListViewItem li = new ListViewItem(s.Name);
                listViewStudents.Items.Add(li);
            }*/
        }

        private void hide_pnl()
        {
            pnl_Dashboard.Hide();
            img_Dashboard.Hide();
            pnl_DisplayData.Hide();
        }

        private void showPanel(string panelName)
        {
            hide_pnl();
            lbl_Header_Name.Text = panelName.Split('_')[1];

            var show = new Dictionary<string, Action>() {
                  {"pnl_Dashboard", () =>  show_pnl_Dashboard()},
                  {"pnl_Students", () => show_pnl_Students()},
                  {"pnl_Teachers", () => show_pnl_Teachers()},
            };

            if (panelName != null) {
                show[panelName]();
            }
        }

        private void dashboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
           //
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dashboardToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            showPanel("pnl_Dashboard");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void img_Dashboard_Click(object sender, EventArgs e)
        {
            MessageBox.Show("What happens in Someren, stays in Someren!");
        }

        private void studentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showPanel("pnl_Students");
        }
        

        private void teachersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showPanel("pnl_Teachers");
        }

        private void listViewStudents_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
