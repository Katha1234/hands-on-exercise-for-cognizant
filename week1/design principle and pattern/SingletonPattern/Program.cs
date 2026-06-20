using System;

namespace SingletonPatternExample
{
    // --- Step 1: Define the Singleton Class ---
    public sealed class Logger
    {
        // 1. Private static variable to hold the single instance.
        // Lazy<T> handles thread safety and lazy loading automatically in C#.
        private static readonly Lazy<Logger> _instance = 
            new Lazy<Logger>(() => new Logger());

        // 2. Private constructor prevents "new Logger()" from outside the class.
        private Logger()
        {
            Console.WriteLine("System Alert: Logger utility instance initialized.");
        }

        // 3. Public static property to provide global access to the instance.
        public static Logger Instance
        {
            get
            {
                return _instance.Value;
            }
        }

        // A sample method to demonstrate logging utility behavior
        public void Log(string message)
        {
            Console.WriteLine($"[LOG - {DateTime.Now:yyyy-MM-dd HH:mm:ss}]: {message}");
        }
    }

    // --- Step 2: Test the Singleton Implementation ---
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- Starting C# Singleton Pattern Test ---");

            // Request the logger instance for the first time
            Logger logger1 = Logger.Instance;
            logger1.Log("User 'Katha1234' logged in successfully.");

            // Request the logger instance a second time
            Logger logger2 = Logger.Instance;
            logger2.Log("Database entry synchronized securely.");

            // VERIFICATION: Check if both variables reference the exact same memory allocation
            Console.WriteLine("\n--- Verification Checking ---");
            Console.WriteLine($"Memory Reference Logger 1: {logger1.GetHashCode()}");
            Console.WriteLine($"Memory Reference Logger 2: {logger2.GetHashCode()}");

            if (ReferenceEquals(logger1, logger2))
            {
                Console.WriteLine("\nSUCCESS: Both variables point to the identical instance. Singleton pattern works perfectly in C#!");
            }
            else
            {
                Console.WriteLine("\nFAILURE: Multiple distinct instances exist.");
            }
        }
    }
}