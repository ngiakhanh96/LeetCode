namespace ConsoleApp1.LockExamples.Mutex;

internal class MutexExample
{
    // Create a new Mutex. The creating thread does not own the mutex.
    private static System.Threading.Mutex mut = new();
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
        Console.WriteLine("{0} is requesting the mutex",
            Thread.CurrentThread.Name);
        mut.WaitOne();

        Console.WriteLine("{0} has entered the protected area",
            Thread.CurrentThread.Name);

        // Place code to access non-reentrant resources here.

        // Simulate some work.
        Thread.Sleep(500);

        Console.WriteLine("{0} is leaving the protected area",
            Thread.CurrentThread.Name);

        // Release the Mutex.
        mut.ReleaseMutex();
        Console.WriteLine("{0} has released the mutex",
            Thread.CurrentThread.Name);
    }
}