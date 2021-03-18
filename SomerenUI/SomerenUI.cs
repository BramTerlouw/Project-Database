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
            btnModify.Show();
            btnRefresh.Show();

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

        private void show_pnl_Order(){
            pnl_Order.Show();

            SomerenLogic.Drink_Service drinkService = new SomerenLogic.Drink_Service();
            List<Drink> drinkList = drinkService.GetDrinks();
            SomerenLogic.Student_Service studService = new SomerenLogic.Student_Service();
            List<Student> studentList = studService.GetStudents();

            cmbDrinks.Items.Clear();
            cmbStudents.Items.Clear();
            foreach (Drink drink in drinkList)
            {
                cmbDrinks.Items.Add(drink.type);
            }
            cmbDrinks.SelectedIndex = 0;

            foreach (Student student in studentList)
            {
                cmbStudents.Items.Add(student.Name);
            }
            cmbStudents.SelectedIndex = 0;
        }


        public struct totalListPrice
        {
            public int drank_id;
            public float total_price;
            public int customer_amount;

            public totalListPrice(int v1, float v2, int v3){
                drank_id = v1;
                total_price = v2;
                customer_amount = v3;
            }
        }

        private void show_pnl_Revenue(){
            pnl_DisplayData.Show();

            SomerenLogic.Drink_Service drinkService = new SomerenLogic.Drink_Service();
            List<Drink> drinkList = drinkService.GetDrinks();
            List<Sold> soldList = drinkService.getRevenue(637516731784124020, 637516731885973093);


            // create new object heeft drank_id, total_price, ->
            // Daarna deze list loopen en perm id sold drinks op halen en daar totaal van pakken

            List<totalListPrice> list = new List<totalListPrice>();

            foreach (Drink d in drinkList)
                list.Add(new totalListPrice(d.Id, 0.00f, 0));
            
            for(int i = 0; i < list.Count; i++){
                foreach(Sold s in soldList){
                    if(s.Drink_id == list[i].drank_id){
                        var values = drinkList
                            .Where(drinkList => drinkList.id == s.Drink_id)
                            .Select(drinkList => new { price = drinkList.price});

                        list[i].total_price = list[i].total_price + values.price;
                    }
                } 
                System.Console.WriteLine(list[i].total_price);
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
            pnl_Order.Hide();
            btnModify.Hide();
            btnRefresh.Hide();
        }

        public void showPanel(string panelName)
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
                  {"pnl_Order", () => show_pnl_Order()},
                  {"pnl_Revenue", () => show_pnl_Revenue()},
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

        private void btnModify_Click(object sender, EventArgs e)
        {
            var Drinks_Modify = new Drinks_Modify();
            Drinks_Modify.ShowDialog();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            showPanel("pnl_Drinks");
        }
        
        private void orderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showPanel("pnl_Order");
        } 

        private void revenueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showPanel("pnl_Revenue");
        }

        private void btnSubmitOrder_Click(object sender, EventArgs e)
        {
            int studentId = cmbStudents.SelectedIndex + 1;
            int drinkId = cmbDrinks.SelectedIndex + 1;

            SomerenLogic.Drink_Service drinkService = new SomerenLogic.Drink_Service();
            try
            {
                drinkService.decreaseStock(drinkId);
                drinkService.addTransaction(studentId, drinkId);
                MessageBox.Show("Transaction succeeded");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
