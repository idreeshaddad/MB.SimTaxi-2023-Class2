namespace Test
{
    internal class Program
    {
        static string firstName = "Sameer";
        static string lastName = "Abu Laila";
        static DateTime dateOfBirth = new DateTime(1994, 5, 17);

        static void Main(string[] args)
        {
            PrintFirstName();
            PrintFullName();
            PrintAllInfo();
        }

        private static void PrintAllInfo()
        {
            Console.WriteLine($"Full name is: {firstName} {lastName}. DOB: {dateOfBirth}");
        }

        private static void PrintFullName()
        {
            Console.WriteLine($"Full name is: {firstName} {lastName}");
        }

        private static void PrintFirstName()
        {
            Console.WriteLine($"First name is {firstName}");
        }
    }
}