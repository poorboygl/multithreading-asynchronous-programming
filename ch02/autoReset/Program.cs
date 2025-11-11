using System;
using System.Threading;

///////////////////////////////////////////////////////////////
// 🧍 SINGLE WORKER THREAD
///////////////////////////////////////////////////////////////
{
    using AutoResetEvent autoResetEvent = new AutoResetEvent(false);
    string? userInput = null;

    // Tạo một thread duy nhất
    Thread workerThread = new Thread(WorkerSingle);
    workerThread.Name = "Single Worker";
    workerThread.Start();

    Console.WriteLine("=== SINGLE WORKER MODE ===");
    Console.WriteLine("Type 'go' to signal or 'exit' to stop.\n");

    while (true)
    {
        userInput = Console.ReadLine();
        if (userInput?.ToLower() == "exit") break;

        if (userInput?.ToLower() == "go")
        {
            autoResetEvent.Set();
        }
    }

    void WorkerSingle()
    {
        while (true)
        {
            Console.WriteLine($"{Thread.CurrentThread.Name} is waiting for signal...");
            autoResetEvent.WaitOne(); // Chờ tín hiệu từ main thread

            Console.WriteLine($"{Thread.CurrentThread.Name} proceeds!");
            Thread.Sleep(2000);
        }
    }
}

///////////////////////////////////////////////////////////////
// 👷 MULTIPLE WORKER THREADS
///////////////////////////////////////////////////////////////
{
    using AutoResetEvent autoResetEvent = new AutoResetEvent(false);
    string? userInput = null;

    // Tạo 3 worker threads
    for (int i = 0; i < 3; i++)
    {
        Thread workerThread = new Thread(WorkerMulti);
        workerThread.Name = $"Worker {i + 1}";
        workerThread.Start();
    }

    Console.WriteLine("\n=== MULTIPLE WORKER MODE ===");
    Console.WriteLine("Type 'go' to signal one worker or 'exit' to stop.\n");

    while (true)
    {
        userInput = Console.ReadLine();
        if (userInput?.ToLower() == "exit") break;

        if (userInput?.ToLower() == "go")
        {
            autoResetEvent.Set();
        }
    }

    void WorkerMulti()
    {
        while (true)
        {
            Console.WriteLine($"{Thread.CurrentThread.Name} is waiting for signal...");
            autoResetEvent.WaitOne(); // Tất cả 3 thread cùng chờ tín hiệu

            Console.WriteLine($"{Thread.CurrentThread.Name} proceeds!");
            Thread.Sleep(2000);
        }
    }
}