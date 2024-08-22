namespace DesignPatterns
{
    internal class FactoryMethod
    {

    }

    internal class Dialog
    {
        public virtual IButton CreateButton() 
        { }

        public void Render()
        {
            IButton okButton = CreateButton();
            okButton.Render();
        }
    }

    internal interface IButton
    {
        public void Render();
    }

    internal class ClassicButton : IButton
    {
        public void Render()
        {
            Console.WriteLine("Rendered a Classic Button.");
        }
    }

    internal class ModernButton : IButton
    {
        public void Render()
        {
            Console.WriteLine("Rendered a Classic Button.");
        }
    }
}
