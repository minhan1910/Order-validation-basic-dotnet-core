namespace Order_Customers_Assignment.Utils
{
    public class RandomManager
    {
        private static readonly Random _random = new Random();
        private const int DEFAULT_FROM = 1;
        private const int DEFAULT_TO = 99999;
        public int FROM { get; set; } = DEFAULT_FROM;
        public int TO { get; set; } = DEFAULT_TO;

        public int Exec()
        {
            return _random.Next(FROM, TO + 1);  
        }
    }
}
