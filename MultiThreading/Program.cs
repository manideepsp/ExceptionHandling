using System;
using System.Threading;

/// <summary>
/// This program demonstrates exception handling in a multithreaded application.
/// </summary>
class MultithreadedExceptionHandlingProgram
{
    /// <summary>
    /// Entry point of the program.
    /// </summary>
    static void Main()
    {
        // Create a new thread and start it
        Thread workerThread = new Thread(WorkerThreadMethod);
        workerThread.Start();

        Console.WriteLine("Main thread is running.");

        // Simulate some work on the main thread
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine($"Main thread working... {i}");
            Thread.Sleep(1000);
        }

        // Wait for the worker thread to complete
        workerThread.Join();

        Console.WriteLine("Main thread has finished.");
    }

    /// <summary>
    /// Method executed by the worker thread.
    /// </summary>
    static void WorkerThreadMethod()
    {
        try
        {
            Console.WriteLine("Worker thread is running.");

            // Simulate some work on the worker thread
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Worker thread working... {i}");
                Thread.Sleep(1000);
            }

            // Simulate different exceptions occurring in the worker thread
            if (DateTime.Now.Second % 2 == 0)
                throw new InvalidOperationException("Invalid operation occurred!");
            else
                throw new ArgumentException("Invalid argument passed!");
        }
        catch (InvalidOperationException ex)
        {
            // Handle InvalidOperationException
            Console.WriteLine("InvalidOperationException caught in the worker thread:");
            Console.WriteLine(ex.Message);
            Console.WriteLine("Logging the exception and notifying the main thread...");

            // Log the exception and notify the main thread or user interface
            // You can use appropriate techniques here depending on your application's requirements
        }
        catch (ArgumentException ex)
        {
            // Handle ArgumentException
            Console.WriteLine("ArgumentException caught in the worker thread:");
            Console.WriteLine(ex.Message);
            Console.WriteLine("Logging the exception and notifying the main thread...");

            // Log the exception and notify the main thread or user interface
            // You can use appropriate techniques here depending on your application's requirements
        }
        catch (Exception ex)
        {
            // Handle any other type of exception
            Console.WriteLine("Exception caught in the worker thread:");
            Console.WriteLine(ex.Message);
            Console.WriteLine("Logging the exception and notifying the main thread...");

            // Log the exception and notify the main thread or user interface
            // You can use appropriate techniques here depending on your application's requirements
        }
    }
}
