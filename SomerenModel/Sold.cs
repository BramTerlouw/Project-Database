namespace SomerenModel
{//SELECT id, [type], amount, price, alcohol FROM drinks WHERE amount > 1 AND price > 1.00
    public class Sold
    {
        public readonly int Id;
        public readonly int Drink_id;
        public readonly int Student_id;

        // id, [type], amount, price, alcohol
        public Sold(int v1, int v2, int v3)
        {
            // constructor for the class Drink
            Id = v1;
            Drink_id = v2;
            Student_id = v3;
        }
    }
}