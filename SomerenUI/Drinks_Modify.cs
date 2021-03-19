using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SomerenModel;
using SomerenLogic;

namespace SomerenUI
{
    public partial class Drinks_Modify : Form
    {
        SomerenLogic.Drink_Service drink_Service = new Drink_Service();
        public Drinks_Modify()
        {
            InitializeComponent();
        }

        private void btnChangeStock_Click(object sender, EventArgs e)
        {
            try
            {
                // check of both are filled or give an exception
                if (String.IsNullOrEmpty(txtChangeStockDrink.Text))
                    throw new Exception("Empty drink id!");
                else if (String.IsNullOrEmpty(txtChangeStockStock.Text))
                    throw new Exception("Empty stock amount!");

                // get the values from the textboxes
                int drinkId = int.Parse(txtChangeStockDrink.Text);
                int stock = int.Parse(txtChangeStockStock.Text);

                drink_Service.ModifyStock(drinkId, stock);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnChangeName_Click(object sender, EventArgs e)
        {
            // get the values from the textboxes
            string oldName = txtChangeNameOld.Text;
            string newName = txtChangeNameNew.Text;

            // modify name or give exception
            try
            {
                drink_Service.ModifyName(oldName, newName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAddDrink_Click(object sender, EventArgs e)
        {
            try
            {
                // get all values
                int id = int.Parse(txtAddId.Text);
                string type = txtAddType.Text;
                int amount = int.Parse(txtAddAmount.Text);
                double price = double.Parse(txtAddPrice.Text);
                bool alcohol = bool.Parse(txtAddAlcohol.Text);

                // add drink to database
                drink_Service.addDrink(id, type, amount, price, alcohol);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnCloseModify_Click(object sender, EventArgs e)
        {
            // close the modify form
            this.Close();
        }
    }
}
