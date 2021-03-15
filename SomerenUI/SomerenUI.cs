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
            
            // fill a list with students by calling a function from the service layer
            SomerenLogic.Student_Service studService = new SomerenLogic.Student_Service();
            List<Student> studentList = studService.GetStudents();
            
            // clear the DataGridView and fill the column names
            ClearDataGridView();
            generateGridLayout(studentList.FirstOrDefault().dataGridList());

            // Fill the DatagridView with all the students using a foreach
            foreach (var student in studentList)
            {
                FillDataInGridView(student.dataGrid(student));
            }
        }


        private void show_pnl_Teachers()
        {
            pnl_DisplayData.Show();

            // fill a list with teachers by calling a function from the service layer
            SomerenLogic.Teacher_Service teachService = new SomerenLogic.Teacher_Service();
            List<Teacher> teacherList = teachService.GetTeachers();

            // clear the DataGridView and fill the column names
            ClearDataGridView();
            generateGridLayout(teacherList.FirstOrDefault().dataGridList());

            // Fill the DataGridView with all the teachers using a foreach
            foreach (var teacher in teacherList)
            {
                FillDataInGridView(teacher.dataGrid(teacher));
            }
        }

        private void show_pnl_Rooms()
        {
            pnl_DisplayData.Show();

            // fill a list with rooms by calling a function from the service layer
            SomerenLogic.Room_Service roomService = new SomerenLogic.Room_Service();
            List<Room> roomList = roomService.GetRooms();

            ClearDataGridView(); // clear the DataGridView and fill the column names
            generateGridLayout(roomList.FirstOrDefault().dataGridList());

            // Fill the DataGridView with all the rooms using a foreach
            foreach (var room in roomList)
            {
                FillDataInGridView(room.dataGrid(room));
            }
        }

        private void show_pnl_Drinks()
        {
            pnl_DisplayData.Show();

            // fill a list with rooms by calling a function from the service layer
            SomerenLogic.Drink_Service drinkService = new SomerenLogic.Drink_Service();
            List<Drink> drinkList = drinkService.GetDrinks();

            
        
            ClearDataGridView(); // clear the DataGridView and fill the column names
            generateGridLayout(drinkList.FirstOrDefault().dataGridList());

            // Fill the DataGridView with all the rooms using a foreach
            foreach (var drink in drinkList)
            {
                FillDataInGridView(drink.dataGrid(drink, soldDrinks(drink.Id)));
            }
        }

        private int soldDrinks(int id){
            SomerenLogic.Drink_Service drinkService = new SomerenLogic.Drink_Service();
            int amount = drinkService.GetSold(id);
            return amount;
        }

        private void hide_pnl()
        {
            // Hide the panels below
            pnl_Dashboard.Hide();
            img_Dashboard.Hide();
            pnl_DisplayData.Hide();
        }

        private void showPanel(string panelName)
        {
            hide_pnl();
            lbl_Header_Name.Text = panelName.Split('_')[1];

            // A dictionary with panelnames and a function linked together
            var show = new Dictionary<string, Action>() {
                  {"pnl_Dashboard", () =>  show_pnl_Dashboard()},
                  {"pnl_Students", () => show_pnl_Students()},
                  {"pnl_Teachers", () => show_pnl_Teachers()},
                  {"pnl_Rooms", () => show_pnl_Rooms()},
                  {"pnl_Drinks", () => show_pnl_Drinks()},
            };

            // depending on the panelname, call the function
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
            // exit the application
            Application.Exit();
        }

        private void dashboardToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // call the function showPanel with the parameter
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
            // call the function showPanel with the parameter
            showPanel("pnl_Students");
        }
        

        private void teachersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // call the function showPanel with the parameter
            showPanel("pnl_Teachers");
        }

        private void drinksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // call the function showPanel with the parameter
            showPanel("pnl_Drinks");
        }

        private void listViewStudents_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void roomsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // call the function showPanel with the parameter
            showPanel("pnl_Rooms");
        }
    }
}
