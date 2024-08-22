namespace DesignPatterns
{
    internal class Decorator
    {
        // purpose : add functionality to a class without extending or modifying it, just wrapping it

        public void Demo()
        {
            // make a plain cheese pizza
            IPizza pizza = new CheesePizza();
            Console.WriteLine(pizza.GetPizzaType());
            Console.WriteLine();

            // decorate it with pepperoni
            IPizza pepperoniPizza = new PepperoniDecorator(pizza);
            Console.WriteLine(pepperoniPizza.GetPizzaType());
            Console.WriteLine();

            // then add mushrooms to that
            IPizza mushroomPepperoniPizza = new MushroomDecorator(pepperoniPizza);
            Console.WriteLine(mushroomPepperoniPizza.GetPizzaType());
            Console.WriteLine();

            // then add onions to that
            IPizza onionMushroomPepperoniPizza = new OnionDecorator(mushroomPepperoniPizza);
            Console.WriteLine(onionMushroomPepperoniPizza.GetPizzaType());
            Console.WriteLine();

            Console.WriteLine();
        }
    }

    // base interface
    internal interface IPizza
    {
        public string GetPizzaType();
    }

    // implementing the interface
    class CheesePizza : IPizza
    {
        public string GetPizzaType()
        {
            return "This is a cheese pizza";
        }
    }

    // base decorator for a pizza
    //for adding topping to it without changing the base pizza
    class PizzaDecorator : IPizza
    {
        // this stores the pizza to be decorated
        private IPizza _pizza;

        // pass the pizza to be decorated here when constructing the decorator
        public PizzaDecorator(IPizza pizza)
        {
            _pizza = pizza;
        }

        // override this in children so that a specific topping is added
        public virtual string GetPizzaType()
        {
            return _pizza.GetPizzaType();
        }
    }

    class PepperoniDecorator : PizzaDecorator
    {
        // inherit the constructor of the base decorator
        public PepperoniDecorator(IPizza pizza) : base(pizza) { }

        // make this decorator add pepperoni to the pizza passed in
        public override string GetPizzaType()
        {
            string type = base.GetPizzaType();
            type += "\r\n with pepperoni";
            return type;
        }
    }

    class MushroomDecorator : PizzaDecorator
    {
        public MushroomDecorator(IPizza pizza) : base(pizza) { }

        // same, but add mushrooms
        public override string GetPizzaType()
        {
            string type = base.GetPizzaType();
            type += "\r\n with mushroom";
            return type;
        }
    }

    class OnionDecorator : PizzaDecorator
    {
        public OnionDecorator(IPizza pizza) : base(pizza) { }

        // same, but add onions
        public override string GetPizzaType()
        {
            string type = base.GetPizzaType();
            type += "\r\n with onion";
            return type;
        }
    }
}
















