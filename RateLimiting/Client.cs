public class Client(HttpClient httpClient)
{
    public async Task ConcurrentTestAsync(string url, string segment, int requests)
    {
        Console.WriteLine($"\n\nMaking {requests} requests against {url}/{segment}\n");

        var requestTasks = new Task[requests];

        for(var i = 0; i < requests; i++) 
        {
            requestTasks[i] = MakeRequestAsync($"{url}/{segment}/{i}");
        }

        Task.WaitAll(requestTasks);

        Console.WriteLine();
    }

    private async Task MakeRequestAsync(string url)
    {
        var response = await httpClient.GetAsync(url);

        var body = await response.Content.ReadAsStringAsync();

        Console.WriteLine($"{DateTime.Now:hh:mm:ss} {url} [{response.StatusCode}] => {body}");
    }
}