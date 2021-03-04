﻿using SomerenModel;
using System;
using System.Collections.Generic;
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
            showPanel("Dashboard");
        }

        private void showPanel(string panelName)
        {
            switch (panelName)
            {
                case "Dashboard":
                    // hide all other panels
                    pnl_Students.Hide();

                    // show dashboard
                    pnl_Dashboard.Show();
                    img_Dashboard.Show();
                    break;
                case "Students":
                    // hide all other panels
                    pnl_Dashboard.Hide();
                    img_Dashboard.Hide();

                    // show students
                    pnl_Students.Show();

                    // fill the students listview within the students panel with a list of students
                    SomerenLogic.Student_Service studService = new SomerenLogic.Student_Service();
                    List<Student> studentList = studService.GetStudents();

                    // clear the listview before filling it again
                    listViewStudents.Clear();

                    foreach (SomerenModel.Student s in studentList)
                    {

                        ListViewItem li = new ListViewItem(s.Name);
                        listViewStudents.Items.Add(li);
                    }
                    break;
                case "Teachers":
                    // hide all other panels
                    pnl_Dashboard.Hide();
                    img_Dashboard.Hide();

                    // show teachers
                    pnl_Students.Show();

                    // fill the teachers listview within the teachers panel with a list of teachers
                    SomerenLogic.Teacher_Service teachService = new SomerenLogic.Teacher_Service();
                    List<Teacher> teacherList = teachService.GetTeachers();

                    // clear the listview before filling it again
                    listViewStudents.Clear();

                    foreach (SomerenModel.Teacher s in teacherList)
                    {

                        ListViewItem li = new ListViewItem(s.Name);
                        listViewStudents.Items.Add(li);
                    }
                    break;
                default:
                    break;
            }
        }

        private void dashboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
           //
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dashboardToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            showPanel("Dashboard");
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
            showPanel("Students");
        }

        private void teachersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showPanel("Teachers");
        }
    }
}
