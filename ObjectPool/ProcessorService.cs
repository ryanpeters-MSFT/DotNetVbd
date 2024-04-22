using Microsoft.Extensions.ObjectPool;

public class ProcessorService : IResettable
{
    private readonly Guid id = Guid.NewGuid();
    private readonly Queue<Func<bool>> taskQueue = new();

    public ProcessorService()
    {
        // simulate a long instance construction time
        Thread.Sleep(2000);
    }

    public Guid GetInstanceId() => id;

    public int ProcessJobs()
    {
        LoadTasks(10);

        //foreach (var task in taskQueue)
        while (taskQueue.Count != 0)
        {
            var work = taskQueue.Dequeue();

            try
            {
                var result = work();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"EXCEPTION => {ex.Message}");
                // uh oh...
            }
        }

        return taskQueue.Count;
    }

    // optionally, apply any "reset" logic when the instance is returned to the pool
    public bool TryReset()
    {
        Console.WriteLine($"Instance ID {id} reset");

        // clear all items from the queue
        taskQueue.Clear();

        return true;
    }

    private void LoadTasks(int tasksToRetrieve)
    {
        var random = new Random();

        // create some fake tasks that can be processed
        for(var i = 0; i < tasksToRetrieve; i++)
        {
            taskQueue.Enqueue(() =>
            {
                Console.WriteLine($"Processing task on instance {id}");
                Thread.Sleep(1000);

                // simulate a long-running process

                // assume one of our steps will fail 25% of the time
                if (random.Next(1, 4) == 1)
                {
                    throw new ApplicationException("Something broke!");
                }

                return true;
            });
        }
    }
}