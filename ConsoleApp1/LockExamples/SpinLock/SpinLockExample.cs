namespace ConsoleApp1.LockExamples.SpinLock;

internal class SpinLockExample
{
    // Create a new spinlock. The creating thread does not own the spinlock.
    private static System.Threading.SpinLock mut;
    private const int numThreads = 3;

    public static void Example()
    {
        // Create the threads that will use the protected resource.
        for (int i = 0; i < numThreads; i++)
        {
            var newThread = new Thread(UseResource)
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
    private static void UseResource()
    {
        // Wait until it is safe to enter.
        Console.WriteLine("{0} is requesting the spinlock",
            Thread.CurrentThread.Name);
        var gotLock = false;
        try
        {
            mut.Enter(ref gotLock);

            Console.WriteLine("{0} has entered the protected area",
                Thread.CurrentThread.Name);

            // Place code to access non-reentrant resources here.

            // Simulate some work.
            Thread.Sleep(500);

            Console.WriteLine("{0} is leaving the protected area",
                Thread.CurrentThread.Name);
        }
        finally
        {
            if (gotLock)
            {
                // Release the spinlock.
                mut.Exit();
                Console.WriteLine("{0} has released the spinlock",
                    Thread.CurrentThread.Name);
            }
        }
    }
}