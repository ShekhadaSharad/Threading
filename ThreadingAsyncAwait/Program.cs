using AsyncVsSyncExample;
using ThreadingAsyncAwait.AsyncVsSyncExample;

namespace ThreadingAsyncAwait
{
    public class Program
    {
        public async static Task Main(string[] args)
        {
            await ExecuteTasksAsync();
        }

        public static async Task ExecuteTasksAsync()
        {
            while (true)
            {
                Console.Write("Enter Any number :- ");
                int no = Convert.ToInt32(Console.ReadLine());
                switch (no)
                {
                    case 1:
                        AwaitAndAsync awaitAndAsync = new AwaitAndAsync();
                        await  awaitAndAsync.ThreadAsync();
                        break;

                    case 2:
                        AwaitAndAsyncA awaitAndAsyncA = new AwaitAndAsyncA();
                        awaitAndAsyncA.NonThread();
                        break;

                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
            }
        } 
    }
}