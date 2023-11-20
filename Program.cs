using Order_Customers_Assignment.Utils;

namespace Order_Customers_Assignment
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddTransient<RandomManager>();

            var app = builder.Build();

            app.MapControllers();
            app.Run();
        }
    }
}