using System;
using System.Collections.Generic;

// Flyweight
public abstract class Flyweight
{
    public abstract void Operation(string extrinsicState);
}

// ConcreteFlyweight
public class ConcreteFlyweight : Flyweight
{
    private string intrinsicState;

    public ConcreteFlyweight(string intrinsicState)
    {
        this.intrinsicState = intrinsicState;
    }

    public override void Operation(string extrinsicState)
    {
        Console.WriteLine($"Intrinsic State: {intrinsicState}, Extrinsic State: {extrinsicState}");
    }
}

// FlyweightFactory
public class FlyweightFactory
{
    private Dictionary<string, Flyweight> flyweights = new Dictionary<string, Flyweight>();

    public Flyweight GetFlyweight(string key)
    {
        if (!flyweights.ContainsKey(key))
        {
            flyweights[key] = new ConcreteFlyweight(key);
        }
        return flyweights[key];
    }
}

// Client code
class Program
{
    static void Main(string[] args)
    {
        FlyweightFactory factory = new FlyweightFactory();

        Flyweight flyweight1 = factory.GetFlyweight("A");
        flyweight1.Operation("First Call");

        Flyweight flyweight2 = factory.GetFlyweight("A");
        flyweight2.Operation("Second Call");

        Flyweight flyweight3 = factory.GetFlyweight("B");
        flyweight3.Operation("Third Call");
    }
}
