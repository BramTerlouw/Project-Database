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
                throw new Exception("Something went wrong!");
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
                throw new Exception("Something went wrong!");
            }
        }





        // Drinks modify and add
        public void ModifyStock(int drinkid, int stock)
        {
            // check the input
            if ((drinkid < 1) || stock < 0)
                throw new Exception("invalid id or stock");

            // call to dao to modify stock
            dao.ModifyStock(drinkid, stock);
        }

        public void ModifyName(string oldName, string newName)
        {
            // if one of them or both is empty, throw exception
            if ((String.IsNullOrEmpty(oldName)) || String.IsNullOrEmpty(newName))
                throw new Exception("Old or new name are empty");

            // call to dao to modify name
            dao.ModifyName(oldName, newName);
        }

        public void addDrink(int id, string type, int amount, double price, bool alcohol)
        {
            // call to dao to modify drink
            dao.addDrink(id, type, amount, price, alcohol);
        }





        // Kassa
        public void decreaseStock(int drinkId)
        {
            // call to dao to decrease stock
            dao.decreaseStock(drinkId);
        }

        public void addTransaction(int studentId, int drinkId)
        {
            // call to dao to insert a transaction
            dao.insertSold(studentId, drinkId);
        }





        // Omzet rapport
        public Sold getRapport(long startDate, long endDate)
        {
            // call the dao to get the afzet, omzet and aantal_klanten
            Int32 afzet = dao.getAfzet(startDate, endDate);
            double omzet = dao.getOmzet(startDate, endDate);
            Int32 aantal_klanten = dao.getSoldCustomers(startDate, endDate);

            // return a rapport
            Sold sold = new Sold(afzet, omzet, aantal_klanten);
            return sold;
        }

    }
}
