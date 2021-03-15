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
        public Drinks_Modify()
        {
            InitializeComponent();
        }

        private void btnChangeStock_Click(object sender, EventArgs e)
        {
            SomerenLogic.Drink_Service drink_Service = new Drink_Service();
            int drinkId = int.Parse(txtChangeStockDrink.Text);
            int stock = int.Parse(txtChangeStockStock.Text);

            drink_Service.modifyStock(drinkId, stock);
        }
    }
}
