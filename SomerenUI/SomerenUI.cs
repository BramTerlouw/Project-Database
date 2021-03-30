using SomerenModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace SomerenUI
{
    public partial class SomerenUI : Form
    {
        private string role;
        
        public SomerenUI()
        {
            InitializeComponent();
            menuStrip1.Hide();
            role = "user";
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
            // Show modify and refresh button
            pnl_DisplayData.Show();
            btnRefresh.Show();

            // only accesible when logged in as admin
            if (role == "admin")
                btnModify.Show();

            // fill a list with drinks by calling a function from the service layer
            SomerenLogic.Drink_Service drinkService = new SomerenLogic.Drink_Service();
            List<Drink> drinkList = drinkService.GetDrinks();


            // clear the DataGridView and fill the column names
            ClearDataGridView();
            generateGridLayout(drinkList.FirstOrDefault().dataGridList());

            // Fill the DataGridView with all the drinks using a foreach
            foreach (var drink in drinkList)
            {
                FillDataInGridView(drink.dataGrid(drink, soldDrinks(drink.Id)));
            }
        }
        
        private int soldDrinks(int id)
        {
            // get the amount of times sold per drink for the drink data grid
            SomerenLogic.Drink_Service drinkService = new SomerenLogic.Drink_Service();
            int amount = drinkService.GetSold(id);
            return amount;
        }
        
        private void btnModify_Click(object sender, EventArgs e)
        {
            // When clicked on modify, new modify form is shown
            var Drinks_Modify = new Drinks_Modify();
            Drinks_Modify.ShowDialog();
        }
        
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            // Button to refresh the drink panel
            showPanel("pnl_Drinks");
        }




        private void show_pnl_Order()
        {
            // only accesible when logged in as admin
            if (role == "admin")
                pnl_Order.Show();

            // get all the drinks and students
            SomerenLogic.Drink_Service drinkService = new SomerenLogic.Drink_Service();
            List<Drink> drinkList = drinkService.GetDrinks();
            SomerenLogic.Student_Service studService = new SomerenLogic.Student_Service();
            List<Student> studentList = studService.GetStudents();

            // Fill each combobox with either drinks or students
            cmbDrinks.Items.Clear();
            cmbStudents.Items.Clear();
            foreach (Drink drink in drinkList)
            {
                cmbDrinks.Items.Add(drink.type);
            }
            cmbDrinks.SelectedIndex = 0; // selected index to 0

            foreach (Student student in studentList)
            {
                cmbStudents.Items.Add(student.Name);
            }
            cmbStudents.SelectedIndex = 0; // selected index to 0
        }
        
        private void btnSubmitOrder_Click(object sender, EventArgs e)
        {
            // get the selected index
            int studentId = cmbStudents.SelectedIndex + 1;
            int drinkId = cmbDrinks.SelectedIndex + 1;

            SomerenLogic.Drink_Service drinkService = new SomerenLogic.Drink_Service();
            try
            {
                // first decrease the stock of the drink, then add transaction to sold table
                drinkService.decreaseStock(drinkId);
                drinkService.addTransaction(studentId, drinkId);
                MessageBox.Show("Transaction succeeded"); // display message
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }





        private void show_pnl_Revenue()
        {
            // Show calender and rapport button
            pnl_DisplayData.Show();
            btngetRapport.Show();
            RapportCalender.Show();
            ClearDataGridView();
        }

        private void btngetRapport_Click(object sender, EventArgs e)
        {
            // get the start and end date of selected range
            DateTime start = RapportCalender.SelectionRange.Start;
            DateTime end = RapportCalender.SelectionRange.End;
            
            // get rapport and convert date to amount of ticks
            try
            {
                SomerenLogic.Drink_Service drinkService = new SomerenLogic.Drink_Service();
                Sold sold = drinkService.getRapport(start.Ticks, end.Ticks);

                // clear the DataGridView and fill the column names
                ClearDataGridView();
                generateGridLayout(sold.dataGridList());

                // Fill the DataGridView with all the rooms using a foreach
                FillDataInGridView(sold.dataGrid(sold));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }




        private void show_pnl_Activities()
        {
            // show panel and buttons
            pnl_DisplayData.Show();
            btnRefreshActivity.Show();

            // only accesible when logged in as admin
            if (role == "admin")
                btnModifyActivities.Show();

            try
            {
                SomerenLogic.Activity_Service activity_Service = new SomerenLogic.Activity_Service();
                List<Activity> activities = activity_Service.GetActivities();

                // clear the DataGridView and fill the column names
                ClearDataGridView();
                generateGridLayout(activities.FirstOrDefault().dataGridList());

                // Fill the DataGridView with all the drinks using a foreach
                foreach (var activity in activities)
                {
                    FillDataInGridView(activity.dataGrid(activity, aantalStudentenActiviteit(activity.id), aantalBegeleidersActiviteit(activity.id)));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnModifyActivities_Click(object sender, EventArgs e)
        {
            // open the activity modify form
            var activity_Modify = new Activities_Modify();
            activity_Modify.ShowDialog();
        }

        private void btnRefreshActivity_Click(object sender, EventArgs e)
        {
            // refresh activity panel
            showPanel("pnl_Activities");
        }

        private int aantalStudentenActiviteit(int activityId)
        {
            // get the amount of students that participate in this activity
            SomerenLogic.Activity_Service activity_Service = new SomerenLogic.Activity_Service();
            return activity_Service.getAantalStudenten(activityId);
        }

        private int aantalBegeleidersActiviteit(int activityId)
        {
            // get the amount of mentors per activity
            SomerenLogic.Activity_Service activity_Service = new SomerenLogic.Activity_Service();
            return activity_Service.getAantalBegeleiders(activityId);
        }





        private void show_pnl_PlannedActivities()
        {
            // show panel and buttons
            pnl_DisplayData.Show();
            btnRefreshRooster.Show();

            // only accesible when logged in as admin
            if (role == "admin")
                btnModifyRooster.Show();

            try
            {
                SomerenLogic.Activity_Service activity_Service = new SomerenLogic.Activity_Service();
                List<ActivityForeignGroup> list = activity_Service.GetActivityForiegnGroup();

                // clear the DataGridView and fill the column names
                ClearDataGridView();
                generateGridLayout(list.FirstOrDefault().dataGridList());

                // Fill the DataGridView with all the drinks using a foreach
                foreach (var s in list)
                {
                    FillDataInGridView(s.dataGrid(s));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnRefreshRooster_Click(object sender, EventArgs e)
        {
            showPanel("pnl_Planned Activities");
        }

        private void btnModifyRooster_Click(object sender, EventArgs e)
        {
            Rooster_Modify rooster_Modify = new Rooster_Modify();
            rooster_Modify.ShowDialog();
        }






        private void show_pnl_Mentor()
        {
            // show panel and buttons
            pnl_DisplayData.Show();
            btnRefreshMentor.Show();

            // only accesible when logged in as admin
            if (role == "admin")
                btnModifyMentor.Show();

            try
            {
                SomerenLogic.Group_Service group_Service = new SomerenLogic.Group_Service();
                List<GroupForeignTeacher> listGroupForeignTeacher = group_Service.GetGroupForeignTeacher();

                // clear the DataGridView and fill the column names
                ClearDataGridView();
                generateGridLayout(listGroupForeignTeacher.FirstOrDefault().dataGridList());

                // Fill the DataGridView with all the drinks using a foreach
                foreach (var s in listGroupForeignTeacher)
                {
                    FillDataInGridView(s.dataGrid(s));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnModifyMentor_Click(object sender, EventArgs e)
        {
            Mentor_Modify mentor_Modify = new Mentor_Modify();
            mentor_Modify.ShowDialog();
        }

        private void btnRefreshMentor_Click(object sender, EventArgs e)
        {
            showPanel("pnl_Mentor");
        }






        private void show_pnl_Register()
        {
            pnl_Register.Show();
            pnl_ForgotPasswordPanel.Hide();
            pnl_Login.Hide();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            
            
            // user information
            string name = txtRegisterName.Text;
            string email = txtRegisterEmail.Text;
            

            // password and repeat
            string password = txtRegisterWachtwoord.Text;
            string repeatPassword = txtRegisterRepeatWW.Text;

            // question and answer
            string question = txtRegisterQuestion.Text;
            string answer = txtRegisterAnswer.Text;

            SomerenLogic.Register_Service register_Service = new SomerenLogic.Register_Service();

            // validate the user
            if (register_Service.CheckForExistence(email))
            {
                MessageBox.Show("User already exists!");
                return;
            }
            if (txtRegisterLicenseKey.Text != "XsZAb-tgz3PsD-qYh69un-WQCEx")
            {
                MessageBox.Show("License Key don't match!");
                return;
            }
            if (password != repeatPassword)
            {
                MessageBox.Show("Passwords don't match!");
                return;
            }

            if (!ValidatePassword(password))
                return;

            // add user
            register_Service.InsertUser(name, email, SHA512(password), question, answer);

            menuStrip1.Show();
            pnl_Dashboard.Show();
            menuStrip2.Hide();
            pnl_Register.Hide();
        }

        private void LogouttoolStripMenuItem_Click(object sender, EventArgs e)
        {
            // logout and show register panel
            menuStrip1.Hide();
            hide_pnl();
            menuStrip2.Show();
            pnl_Register.Show();

            // when logged out, role goes back to user, only way to get it to admin is by logging in or change password and log in
            role = "user";
        }

        private string SHA512(string input)
        {
            var bytes = System.Text.Encoding.UTF8.GetBytes(input);
            using (var hash = System.Security.Cryptography.SHA512.Create())
            {
                var hashedInputBytes = hash.ComputeHash(bytes);
                // Convert to text
                // StringBuilder Capacity is 128, because 512 bits / 8 bits in byte * 2 symbols for byte 
                var hashedInputStringBuilder = new System.Text.StringBuilder(128);
                foreach (var b in hashedInputBytes)
                    hashedInputStringBuilder.Append(b.ToString("X2"));
                return hashedInputStringBuilder.ToString();
            }
        }


        private void show_pnl_Login()
        {
            pnl_Login.Show();
            pnl_Register.Hide();
            pnl_ForgotPasswordPanel.Hide();

            // clear fields when opened
            txtLoginEmail.Clear();
            txtLoginPassword.Clear();
        }



        private void btnLogin_Click(object sender, EventArgs e)
        {
            SomerenLogic.Register_Service register_Service = new SomerenLogic.Register_Service();

            // get the email and password from textboxes
            string email = txtLoginEmail.Text;
            string password = txtLoginPassword.Text;

            // validate the user

            // if validuser then show application and hide login and register and password forgotten
            if (register_Service.CheckUserLogin(email, SHA512(password)))
            {
                role = register_Service.GetRole(email);
                menuStrip2.Hide();
                pnl_Login.Hide();

                menuStrip1.Show();
                pnl_Dashboard.Show();
            }
            else
            {
                MessageBox.Show("Wrong email or password!"); // show messagebox with message, application keeps running
                return;
            }
        }




        private void pnl_ForgotPassword()
        {
            // show the panel and hide others
            pnl_ForgotPasswordPanel.Show();
            pnl_Register.Hide();
            pnl_Login.Hide();
            
            // when switched between register, login and pw forgotten show this txtbox
            txtForgotPasswordEmail.Show();

            // clear textboxes for when you switch between register, login and pw forgotten
            txtForgotPasswordEmail.Clear();
            txtForgotPasswordSecretAwnser.Clear();
            txtForgotPassword.Clear();
            txtForgotRepeatPassword.Clear();
        }

        private void btnForgotValidateEmail_Click(object sender, EventArgs e)
        {
            // get the question for the input email
            SomerenLogic.Register_Service register_Service = new SomerenLogic.Register_Service();
            lblSecretQuestion.Text = register_Service.GetSecretQuestion(txtForgotPasswordEmail.Text);

            // when there is a result, show the next part of the panel with for answerring the secret question
            if (!String.IsNullOrEmpty(lblSecretQuestion.Text))
            {
                label3.Show();
                label12.Show();
                lblSecretQuestion.Show();
                txtForgotPasswordSecretAwnser.Show();
                btnCheckQandA.Show();

                // make the given email permanent so it cant be changed after the question was given
                txtForgotPasswordEmail.Hide();
                lblForgottenEmail.Text = txtForgotPasswordEmail.Text;
                lblForgottenEmail.Show();
            }
            else
            {
                // give message showing there was nothing found with the given email
                MessageBox.Show("No user found with this email!");
            }
        }



        private void btnCheckQandA_Click(object sender, EventArgs e)
        {
            // get the email, question and given answer
            SomerenLogic.Register_Service register_Service = new SomerenLogic.Register_Service();
            string email = lblForgottenEmail.Text;
            string sQuestion = lblSecretQuestion.Text;
            string sAwnser = txtForgotPasswordSecretAwnser.Text;

            // validate the question and given answer
            bool validateQuestionAndAwnser = register_Service.CheckForExistenceSecretQuestion(email, sQuestion, sAwnser);

            if (!validateQuestionAndAwnser)
            {
                // display error message when Q and A dont match
                MessageBox.Show("Wrong Secret question and or anwser");
                return;
            }

            // show the final part where the user can enter a new password
            label14.Show();
            label17.Show();
            txtForgotPassword.Show();
            txtForgotRepeatPassword.Show();
            btnSubmitForgotPassword.Show();
        }

        
        
        private void btnSubmitForgotPassword_Click(object sender, EventArgs e)
        {
            // get the email, password and repeated password
            SomerenLogic.Register_Service register_Service = new SomerenLogic.Register_Service();
            string email = lblForgottenEmail.Text;
            string password = txtForgotPassword.Text;
            string repeatPassword = txtForgotRepeatPassword.Text;

            // check passwords match
            if (password != repeatPassword)
            {
                MessageBox.Show("passwords dont match");
                return;
            }

            // validate password
            if (!ValidatePassword(password))
                return;

            // update password
            register_Service.updateUserPassword(email, SHA512(password));
            MessageBox.Show("Updated password and succesfully logged in");

            // hide these menus en show application
            menuStrip2.Hide();
            pnl_ForgotPasswordPanel.Hide();
            pnl_Login.Hide();
            pnl_Register.Hide();

            role = register_Service.GetRole(email);
            menuStrip1.Show();
            pnl_Dashboard.Show();
        }





        private bool ValidatePassword(string password)
        {
            // input = password
            var input = password;

            // if empty give error in messagebox
            if (string.IsNullOrWhiteSpace(input))
            {
                MessageBox.Show("Password should not be empty");
            }

            var hasNumber = new Regex(@"[0-9]+");
            var hasUpperChar = new Regex(@"[A-Z]+");
            var hasMiniMaxChars = new Regex(@".{8,15}");
            var hasLowerChar = new Regex(@"[a-z]+");
            //var hasSymbols = new Regex(@"[!@#$%^&*()_+=\[{\]};:<>|./?,-]");

            // check each condition and if all good then return true, else give error with messagebox
            if (!hasLowerChar.IsMatch(input))
            {
                MessageBox.Show("Password should contain At least one lower case letter");
                return false;
            }
            else if (!hasUpperChar.IsMatch(input))
            {
                MessageBox.Show("Password should contain At least one upper case letter");
                return false;
            }
            else if (!hasMiniMaxChars.IsMatch(input))
            {
                MessageBox.Show("Password should be between 8 and 15 chars");
                return false;
            }
            else if (!hasNumber.IsMatch(input))
            {
                MessageBox.Show("Password should contain At least one numeric value");
                return false;
            }
            //else if (!hasSymbols.IsMatch(input))
            //{
            //    MessageBox.Show("Password should contain At least one special case characters");
            //    return false;
            //}
            else
            {
                return true;
            }
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
            btngetRapport.Hide();
            RapportCalender.Hide();
            btnModifyActivities.Hide();
            btnRefreshActivity.Hide();
            btnRefreshMentor.Hide();
            btnModifyMentor.Hide();
            btnModifyRooster.Hide();
            btnRefreshRooster.Hide();
            pnl_Register.Hide();
            label14.Hide();
            label17.Hide();
            txtForgotPassword.Hide();
            txtForgotRepeatPassword.Hide();
            btnSubmitForgotPassword.Hide();
            label3.Hide();
            label12.Hide();
            lblSecretQuestion.Hide();
            txtForgotPasswordSecretAwnser.Hide();
            btnCheckQandA.Hide();
            lblForgottenEmail.Hide();
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
                  {"pnl_Activities", () => show_pnl_Activities()},
                  {"pnl_Mentor", () => show_pnl_Mentor()},
                  {"pnl_Planned Activities", () => show_pnl_PlannedActivities()},
                  {"pnl_Register", () => show_pnl_Register()},
                  {"pnl_Login", () => show_pnl_Login()},
                  {"pnl_ForgotPassword", () => pnl_ForgotPassword()}
            };

            // depending on the panelname, call the function
            if (panelName != null) {
                show[panelName]();
            }
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

        private void roomsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // call the function showPanel with the parameter
            showPanel("pnl_Rooms");
        }

        private void orderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // call the function showPanel with the parameter
            showPanel("pnl_Order");
        } 

        private void revenueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // call the function showPanel with the parameter
            showPanel("pnl_Revenue");
        }

        private void activitiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // call the function showPanel with the parameter
            showPanel("pnl_Activities");
        }

        private void groupMentorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // call the function showPanel with the parameter
            showPanel("pnl_Mentor");
        }
        
        private void plannedActivitiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // call the function showPanel with the parameter
            showPanel("pnl_Planned Activities");
        }

        private void RegistertoolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            // call the function showPanel with the parameter
            showPanel("pnl_Register");
        }

        private void LogintoolStripMenuItem_Click(object sender, EventArgs e)
        {
            // call the function showPanel with the parameter
            showPanel("pnl_Login");
        }

        private void ForgotPasswordtoolStripMenuItem_Click(object sender, EventArgs e)
        {
            // call the function showPanel with the parameter
            showPanel("pnl_ForgotPassword");
        }
    }
}
