namespace SomerenModel
{//SELECT id, [type], amount, price, alcohol FROM drinks WHERE amount > 1 AND price > 1.00
    public class Drink
    {
        public readonly int Id;
        public readonly string type;
        public readonly int amount;
        public readonly string price;
        public readonly bool alcohol;

        // id, [type], amount, price, alcohol
        public Drink(int v1, string v2, int v3, string v4, bool v5)
        {
            // constructor for the class Drink
            Id = v1;
            type = v2;
            amount = v3;
            price = v4;
            alcohol = v5;
        }

        public string[] dataGridList()
        {
            // return the column names
            return new string[] { "id", "type", "amount", "price", "alcohol", "sold"};
        }

        public string[] dataGrid(Drink drink, int amount)
        {
            // return an array with all the teacher properties
            return new string[] {
                drink.Id.ToString(),
                drink.type,
                drink.amount.ToString(),
                drink.price,
                drink.alcohol.ToString(),
                amount.ToString()
            };
        }
    }
}
