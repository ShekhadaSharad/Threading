using System.Diagnostics;
using System.Text;

namespace ThreadingAsyncAwait
{
    namespace AsyncVsSyncExample
    {
        public class AwaitAndAsyncA
        {
            public void NonThread()
            {
                string[] fileNames = new string[]
                {
                   @"C:\Users\digip\Desktop\NonThread\NonThread1.txt",
                   @"C:\Users\digip\Desktop\NonThread\NonThread2.txt",
                   @"C:\Users\digip\Desktop\NonThread\NonThread3.txt",
                   @"C:\Users\digip\Desktop\NonThread\NonThread4.txt",
                   @"C:\Users\digip\Desktop\NonThread\NonThread5.txt",
                };

                foreach (string fileName in fileNames)
                {
                    if (File.Exists(fileName))
                    {
                        File.Delete(fileName);
                    }
                }

                var stopwatch = Stopwatch.StartNew();
                int a = 100;

                using (FileStream fs = File.Create(fileNames[0]))
                {
                    for (int i = 0; i < a; i++)
                    {
                        for (int j = 0; j < 2000; j++)
                        {
                            string message = $"NonThread 1 - Elapsed time for iteration {i + 1}: {stopwatch.Elapsed.TotalSeconds} seconds\n";
                            byte[] messageBytes = Encoding.UTF8.GetBytes(message);
                             fs.WriteAsync(messageBytes, 0, messageBytes.Length);
                        }

                    }
                }
                using (FileStream fs = File.Create(fileNames[1]))
                {
                    for (int i = 0; i < a; i++)
                    {
                        for (int j = 0; j < 2000; j++)
                        {
                            string message = $"NonThread 2 - Elapsed time for iteration {i + 1}: {stopwatch.Elapsed.TotalSeconds} seconds\n";
                            byte[] messageBytes = Encoding.UTF8.GetBytes(message);
                            fs.WriteAsync(messageBytes, 0, messageBytes.Length);
                        }
                    }
                }
                using (FileStream fs = File.Create(fileNames[2]))
                {
                    for (int i = 0; i < a; i++)
                    {
                        for (int j = 0; j < 2000; j++)
                        {
                            string message = $"NonThread 3 - Elapsed time for iteration {i + 1}: {stopwatch.Elapsed.TotalSeconds} seconds\n";
                            byte[] messageBytes = Encoding.UTF8.GetBytes(message);
                            fs.WriteAsync(messageBytes, 0, messageBytes.Length);
                        }
                    }
                }
                using (FileStream fs = File.Create(fileNames[3]))
                {
                    for (int i = 0; i < a; i++)
                    {
                        for (int j = 0; j < 2000; j++)
                        {
                            string message = $"NonThread 4 - Elapsed time for iteration {i + 1}: {stopwatch.Elapsed.TotalSeconds} seconds\n";
                            byte[] messageBytes = Encoding.UTF8.GetBytes(message);
                            fs.WriteAsync(messageBytes, 0, messageBytes.Length);
                        }
                    }
                }
                using (FileStream fs = File.Create(fileNames[4]))
                {
                    for (int i = 0; i < a; i++)
                    {
                        for (int j = 0; j < 2000; j++)
                        {
                            string message = $"NonThread 5  - Elapsed time for iteration {i + 1}: {stopwatch.Elapsed.TotalSeconds} seconds\n";
                            byte[] messageBytes = Encoding.UTF8.GetBytes(message);
                            fs.WriteAsync(messageBytes, 0, messageBytes.Length);
                        }
                    }
                }

                stopwatch.Stop();
                Console.WriteLine($"Total time taken: {stopwatch.Elapsed.TotalSeconds} seconds");
            }

        }
    }
}