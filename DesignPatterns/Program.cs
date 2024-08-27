namespace DesignPatterns
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter number of design pattern to demo:");
            Console.WriteLine("1. Decorator");
            Console.WriteLine("2. Strategy");
            Console.WriteLine("3. Adapter");
            Console.WriteLine("4. Factory Method");
            Console.WriteLine("5. Chain of Responsibility");

            int choice = 0;

            try
            {
                choice = int.Parse(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message); 
            }

            Console.WriteLine();
            Console.WriteLine();

            switch (choice)
            {
                case 1:
                    // Decorator - Structural
                    new Decorator().Demo();
                    break;
                case 2:
                    // Strategy - Behavioral
                    new Strategy().Demo();
                    break;
                case 3:
                    // Adapter - Structural
                    new Adapter().Demo();
                    break;
                case 4:
                    // Factory Method - Creational
                    new FactoryMethod().Demo();
                    break;
                case 5:
                    // Chain of Responsibility - Behavioral
                    new ChainOfResponsibility().Demo();
                    break;
                default:
                    Console.WriteLine("Wrong input.");
                    break;
            }

            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
