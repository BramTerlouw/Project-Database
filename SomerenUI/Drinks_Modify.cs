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
            int drinkId = int.Parse(txtChangeStockDrink.Text);
            int stock = int.Parse(txtChangeStockStock.Text);

            if ((drinkId > 0) && stock > 0)
                drink_Service.ModifyStock(drinkId, stock);
        }

        private void btnChangeName_Click(object sender, EventArgs e)
        {
            string oldName = txtChangeNameOld.Text;
            string newName = txtChangeNameNew.Text;

            if ((!String.IsNullOrEmpty(oldName)) && !String.IsNullOrEmpty(newName))
                drink_Service.ModifyName(oldName, newName);
        }
    }
}
