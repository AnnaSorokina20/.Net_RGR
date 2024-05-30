// Продукт
public abstract class Product
{
    public abstract void Operation();
}

// Конкретний продукт A
public class ConcreteProductA : Product
{
    public override void Operation()
    {
        Console.WriteLine("ConcreteProductA Operation");
    }
}

// Конкретний продукт B
public class ConcreteProductB : Product
{
    public override void Operation()
    {
        Console.WriteLine("ConcreteProductB Operation");
    }
}

// Творець
public abstract class Creator
{
    public abstract Product FactoryMethod();
    public void AnOperation()
    {
        var product = FactoryMethod();
        product.Operation();
    }
}

// Конкретний творець A
public class ConcreteCreatorA : Creator
{
    public override Product FactoryMethod()
    {
        return new ConcreteProductA();
    }
}

// Конкретний творець B
public class ConcreteCreatorB : Creator
{
    public override Product FactoryMethod()
    {
        return new ConcreteProductB();
    }
}

// Приклад використання
class Program
{
    static void Main(string[] args)
    {
        Creator creatorA = new ConcreteCreatorA();
        creatorA.AnOperation();

        Creator creatorB = new ConcreteCreatorB();
        creatorB.AnOperation();
    }
}
