using SomerenDAL;
using SomerenModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomerenLogic
{
    public class Drink_Service
    {
        readonly Drink_DAO dao = new Drink_DAO();

        public List<Drink> GetDrinks()
        {
            try
            {
                // get the list with rooms by calling a function from the DAL layer
                List<Drink> drink = dao.Db_Get_All_Drinks();
                return drink;
            }
            catch (Exception)
            {
                // something went wrong connecting to the database, so we will add a fake room to the list to make sure the rest of the application continues working!

                return null;
            }
        }

        public int GetSold(int drinkId)
        {
            try
            {
                // get the list with rooms by calling a function from the DAL layer
                int amount = dao.Db_Get_Sold_Drinks(drinkId);
                return amount;
            }
            catch (Exception)
            {
                // something went wrong connecting to the database, so we will add a fake room to the list to make sure the rest of the application continues working!

                return 0;
            }
        }
    }
}
