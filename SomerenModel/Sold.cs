namespace SomerenModel
{
    public class Sold
    {
        public readonly int afzet;
        public readonly double omzet;
        public readonly int aantal_klanten;

        public Sold(int v1, double v2, int v3)
        {
            afzet = v1;
            omzet = v2;
            aantal_klanten = v3;
        }

        public string[] dataGridList()
        {
            // return the column names
            return new string[] { "Afzet", "Omzet", "Aantal klanten"};
        }

        public string[] dataGrid(Sold sold)
        {
            // return array with all the room properties
            return new string[] {
                sold.afzet.ToString(),
                sold.omzet.ToString(),
                sold.aantal_klanten.ToString()
            };
        }
    }
}