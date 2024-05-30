using System;

// Абстрактний об'єкт
public abstract class AbstractObject
{
    public abstract void Request();
}

// Реальний об'єкт
public class RealObject : AbstractObject
{
    public override void Request()
    {
        Console.WriteLine("RealObject Request");
    }
}

// Null-об'єкт
public class NullObject : AbstractObject
{
    public override void Request()
    {
        // Нічого не робить
    }
}

// Клієнтський код
class Client
{
    private AbstractObject obj;

    public Client(AbstractObject obj)
    {
        this.obj = obj;
    }

    public void Execute()
    {
        obj.Request();
    }
}

// Приклад використання
class Program
{
    static void Main(string[] args)
    {
        AbstractObject realObject = new RealObject();
        AbstractObject nullObject = new NullObject();

        Client client1 = new Client(realObject);
        Client client2 = new Client(nullObject);

        client1.Execute();
        client2.Execute();
    }
}
