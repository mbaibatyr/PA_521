namespace EF_CodeFirst
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyDbContext db = new MyDbContext();
            foreach (var item in db.Country.ToList())
            {
                Console.WriteLine($"{item.Id} - {item.Name}" );
            }
            
        }
    }
}
