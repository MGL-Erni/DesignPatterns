namespace DesignPatterns
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Decorator - Structural
            new Decorator().Demo();

            // Strategy - Behavioral
            new Strategy().Demo();

            // Adapter - Structural
            new Adapter().Demo();

            // Factory Method - Creational
            // cont. https://refactoring.guru/design-patterns/factory-method

            // Chain of Responsibility - Behavioral
            // cont. https://www.youtube.com/watch?v=qI_v31n1ZTk
        }
    }
}
