// See https://aka.ms/new-console-template for more information

using System;

// Product interface
public interface IShape
{
    void Draw();
}

// Concrete Product 1
public class Circle : IShape
{
    public void Draw()
    {
        Console.WriteLine("Drawing a Circle.");
    }
}

// Concrete Product 2
public class Square : IShape
{
    public void Draw()
    {
        Console.WriteLine("Drawing a Square.");
    }
}

// Creator (Abstract Factory)
public abstract class ShapeFactory
{
    public abstract IShape CreateShape();
}

// Concrete Factory 1
public class CircleFactory : ShapeFactory
{
    public override IShape CreateShape()
    {
        return new Circle();
    }
}

// Concrete Factory 2
public class SquareFactory : ShapeFactory
{
    public override IShape CreateShape()
    {
        return new Square();
    }
}

class Program
{
    static void Main(string[] args)
    {
        ShapeFactory factory1 = new CircleFactory();
        IShape shape1 = factory1.CreateShape();
        shape1.Draw();

        ShapeFactory factory2 = new SquareFactory();
        IShape shape2 = factory2.CreateShape();
        shape2.Draw();
    }
}


