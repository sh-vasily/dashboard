using StackExchange.Redis;

namespace Dashboard.Data;

public sealed class ApplicationsService
{
    public async Task<List<Application>> GetApplicationsAsync()
    {
        var connection = await ConnectionMultiplexer.ConnectAsync(
            new ConfigurationOptions()
            {
                EndPoints = { "localhost:6379" }
            });

        var db = connection.GetDatabase();

        var items = db.HashGetAll(new RedisKey("applications"));

        return items
            .Select(item => new Application(item.Name, item.Value.ToString()))
            .ToList();
    }

    public async Task<string> GetApplicationUrl(string application)
    {
        var connection = await ConnectionMultiplexer.ConnectAsync(
            new ConfigurationOptions()
            {
                EndPoints = { "localhost:6379" }
            });

        var db = connection.GetDatabase();
        
        return await db.HashGetAsync(new RedisKey("applications"), new RedisValue(application));
    }
}