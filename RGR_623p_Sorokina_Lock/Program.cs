using System;
using System.Threading;

public class Lock
{
    private readonly object _lockObject = new object();

    public void Acquire()
    {
        Monitor.Enter(_lockObject);
    }

    public void Release()
    {
        Monitor.Exit(_lockObject);
    }
}

public class Client
{
    private Lock _lock;
    private string _name;

    public Client(Lock lockObject, string name)
    {
        _lock = lockObject;
        _name = name;
    }

    public void AccessResource()
    {
        Console.WriteLine($"{_name} is trying to acquire the lock.");
        _lock.Acquire();
        try
        {
            Console.WriteLine($"{_name} has acquired the lock.");
            // Критична секція
            Console.WriteLine($"{_name} is accessing the resource.");
            Thread.Sleep(1000); // Симуляція роботи з ресурсом
            Console.WriteLine($"{_name} is releasing the lock.");
        }
        finally
        {
            _lock.Release();
        }
    }
}

// Приклад використання
class Program
{
    static void Main(string[] args)
    {
        Lock lockObject = new Lock();

        Client client1 = new Client(lockObject, "Client 1");
        Client client2 = new Client(lockObject, "Client 2");

        Thread thread1 = new Thread(new ThreadStart(client1.AccessResource));
        Thread thread2 = new Thread(new ThreadStart(client2.AccessResource));

        thread1.Start();
        thread2.Start();

        thread1.Join();
        thread2.Join();
    }
}
