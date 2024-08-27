namespace DesignPatterns
{
    internal class FactoryMethod
    {
        // purpose :
        // Provides an interface for creating objects in a superclass.
        // Each subclass that inherits from that original base class that implemented that interface will create a different "kind" of object.

        // good for :
        // 1. Encapsulating object creation when it is too complex / conditional.
        // 2. Decoupling client code from concrete classes.
        // 3. Multiple product / service variations.
        // 4. Customization and Configuration.

        // components:

        // 1. Creator : abstract class / iface that has a (factory) method for creating objects. Can also have other methods for dealing with said objects.

        // 2. Concrete Creator : subclasses that implement the factory method of Creator to ACTUALLY create DIFFERENT SPECIFIC TYPES of objects. 1 each.

        // 3. Product : abstract class / iface for the objects that the FACTORY METHOD CREATES. Meant to give a COMMON INTERFACE to ALL OBJECTS MADE BY DIFFERENT FACTORIES (that implemented the same base Creator class).

        // 4. Concrete Product : actually implement the product. There can be many different kinds of these. 1 type each is RETURNED by each Concrete Creator.

        public void Demo()
        {
            // create the factories to pass into the squares
            ChessPieceFactory rookFactory = new RookFactory();
            ChessPieceFactory knightFactory = new KnightFactory();

            // each square gets its own piece
            Square square1 = new Square(rookFactory);
            Square square2 = new Square(knightFactory);

            // let's see the pieces that each square holds
            square1.GetChessPiece().printChessPiece();
            square2.GetChessPiece().printChessPiece();

            Console.WriteLine();
            Console.WriteLine();
        }

        // class to use the factory in, e.g. a Square that the ChessPiece occupies
        // the factory and the product are abstracted
        // so as to make them easily switchable with different kinds
        public class Square
        {
            private ChessPiece _chessPiece;

            // this could be any chess piece factory
            public Square(ChessPieceFactory chessPieceFactory)
            { 
                // this could be any chess piece
                _chessPiece = chessPieceFactory.CreateChessPiece();
            }

            public ChessPiece GetChessPiece()
            { 
                // get the piece occupying this square, after it has been created
                return _chessPiece;
            }
        }

        // abstract product, e.g. a library class
        public abstract class ChessPiece
        {
            public abstract void printChessPiece();
        }

        // concrete product
        public class Rook : ChessPiece
        {
            public override void printChessPiece()
            {
                Console.WriteLine("This is a Rook.");
            }
        }

        // concrete product
        public class Knight : ChessPiece
        {
            public override void printChessPiece()
            {
                Console.WriteLine("This is a Knight.");
            }
        }

        // factory interface
        public interface ChessPieceFactory
        {
            ChessPiece CreateChessPiece();
        }

        // concrete factory for Rooks
        public class RookFactory : ChessPieceFactory
        { 
            public ChessPiece CreateChessPiece()
            {
                return new Rook();
            }
        }

        // concrete factory for Knights
        public class KnightFactory : ChessPieceFactory
        {
            public ChessPiece CreateChessPiece()
            {
                return new Knight();
            }
        }
    }
}



































