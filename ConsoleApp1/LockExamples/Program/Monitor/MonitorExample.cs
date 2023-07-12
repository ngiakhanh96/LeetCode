namespace ConsoleApp1.LockExamples.Program.Monitor;
internal class MonitorExample
{
    // Create a new lock. The creating thread does not own the lock.
    private static object lockObject = new();
    private const int numThreads = 3;

    public static void ExampleWithMonitor()
    {
        // Create the threads that will use the protected resource.
        for (int i = 0; i < numThreads; i++)
        {
            var newThread = new Thread(UseResourceWithMonitor)
            {
                Name = $"Thread{i + 1}"
            };
            newThread.Start();
        }

        // The main thread exits, but the application continues to
        // run until all foreground threads have exited.
    }

    // This method represents a resource that must be synchronized
    // so that only one thread at a time can enter.
    private static void UseResourceWithMonitor()
    {
        // Wait until it is safe to enter.
        Console.WriteLine("{0} is requesting the lock",
            Thread.CurrentThread.Name);
        var lockWasTaken = false;
        try
        {
            Monitor.Enter(lockObject, ref lockWasTaken);
            Console.WriteLine("{0} has entered the protected area",
                Thread.CurrentThread.Name);

            // Place code to access non-reentrant resources here.

            // Simulate some work.
            Thread.Sleep(500);

            Console.WriteLine("{0} is leaving the protected area",
                Thread.CurrentThread.Name);

            // Release the lock.
            Console.WriteLine("{0} has released the lock",
                Thread.CurrentThread.Name);
        }
        finally
        {
            if (lockWasTaken)
            {
                Monitor.Exit(lockObject);
            }
        }
    }

    public static void ExampleWithLock()
    {
        // Create the threads that will use the protected resource.
        for (int i = 0; i < numThreads; i++)
        {
            var newThread = new Thread(UseResourceWithLock)
            {
                Name = $"Thread{i + 1}"
            };
            newThread.Start();
        }

        // The main thread exits, but the application continues to
        // run until all foreground threads have exited.
    }

    // This method represents a resource that must be synchronized
    // so that only one thread at a time can enter.
    private static void UseResourceWithLock()
    {
        // Wait until it is safe to enter.
        Console.WriteLine("{0} is requesting the lock",
            Thread.CurrentThread.Name);
        lock (lockObject)
        {
            Console.WriteLine("{0} has entered the protected area",
                Thread.CurrentThread.Name);

            // Place code to access non-reentrant resources here.

            // Simulate some work.
            Thread.Sleep(500);

            Console.WriteLine("{0} is leaving the protected area",
                Thread.CurrentThread.Name);

            // Release the lock.
            Console.WriteLine("{0} has released the lock",
                Thread.CurrentThread.Name);
        }
    }
}