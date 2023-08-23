using System.Diagnostics;
using System.Text;

namespace AsyncVsSyncExample
{
    public class AwaitAndAsync
    {
        public async Task ThreadAsync()
        {
            string[] fileNames = new string[]
            {
                  @"C:\Users\digip\Desktop\ThreadAsync\Thread1.txt",
                  @"C:\Users\digip\Desktop\ThreadAsync\Thread2.txt",
                  @"C:\Users\digip\Desktop\ThreadAsync\Thread3.txt",
                  @"C:\Users\digip\Desktop\ThreadAsync\Thread4.txt",
                  @"C:\Users\digip\Desktop\ThreadAsync\Thread5.txt"
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


            Task task1 = Task.Run(async () =>
            {
                using (FileStream fs = File.Create(fileNames[0]))
                {
                    for (int i = 0; i < a; i++)
                    {
                        for (int j = 0; j < 2000; j++)
                        {
                            string message = $"Thread 1 - Elapsed time for iteration {i + 1}: {stopwatch.Elapsed.TotalSeconds} seconds\n";
                            byte[] messageBytes = Encoding.UTF8.GetBytes(message);
                            await fs.WriteAsync(messageBytes, 0, messageBytes.Length);
                        }
                        await Task.Delay(10);
                    }
                }
            });
            Task task2 = Task.Run(async () =>
            {
                using (FileStream fs = File.Create(fileNames[1]))
                {
                    for (int i = 0; i < a; i++)
                    {
                        for (int j = 0; j < 2000; j++)
                        {
                            string message = $"Thread 2 - Elapsed time for iteration {i + 1}: {stopwatch.Elapsed.TotalSeconds} seconds\n";
                            byte[] messageBytes = Encoding.UTF8.GetBytes(message);
                            await fs.WriteAsync(messageBytes, 0, messageBytes.Length);
                        }
                        await Task.Delay(10);
                    }
                }
            });
            Task task3 = Task.Run(async () =>
            {
                using (FileStream fs = File.Create(fileNames[2]))
                {
                    for (int i = 0; i < a; i++)
                    {
                        for (int j = 0; j < 2000; j++)
                        {
                            string message = $"Thread 3 - Elapsed time for iteration {i + 1}: {stopwatch.Elapsed.TotalSeconds} seconds\n";
                            byte[] messageBytes = Encoding.UTF8.GetBytes(message);
                            await fs.WriteAsync(messageBytes, 0, messageBytes.Length);
                        }
                        await Task.Delay(10);
                    }
                }
            });
            Task task4 = Task.Run(async () =>
            {
                using (FileStream fs = File.Create(fileNames[3]))
                {
                    for (int i = 0; i < a; i++)
                    {
                        for (int j = 0; j < 2000; j++)
                        {
                            string message = $"Thread 4 - Elapsed time for iteration {i + 1}: {stopwatch.Elapsed.TotalSeconds} seconds\n";
                            byte[] messageBytes = Encoding.UTF8.GetBytes(message);
                            await fs.WriteAsync(messageBytes, 0, messageBytes.Length);
                        }
                        await Task.Delay(10);
                    }
                }
            });
            Task task5 = Task.Run(async () =>
            {
                using (FileStream fs = File.Create(fileNames[4]))
                {
                    for (int i = 0; i < a; i++)
                    {
                        for (int j = 0; j < 2000; j++)
                        {
                            string message = $"Thread 5 - Elapsed time for iteration {i + 1}: {stopwatch.Elapsed.TotalSeconds} seconds\n";
                            byte[] messageBytes = Encoding.UTF8.GetBytes(message);
                            await fs.WriteAsync(messageBytes, 0, messageBytes.Length);
                        }
                        await Task.Delay(10);
                    }
                }
            });
             
            await Task.WhenAll(task1, task2, task3, task4, task5);

            stopwatch.Stop();
            Console.WriteLine($"Total time taken: {stopwatch.Elapsed.TotalSeconds} seconds");
        }
    }
}