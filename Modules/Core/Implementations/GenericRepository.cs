using FormBuilder.Modules.Core.Interfaces;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private readonly CosmosClient _cosmosClient;
    private readonly string _databaseName;
    private readonly Container _container;

    public GenericRepository(CosmosClient cosmosClient, string databaseName)
    {
        _cosmosClient = cosmosClient;
        _databaseName = databaseName;
        _container = _cosmosClient.GetContainer(databaseName, typeof(T).Name);
    }

    public async Task<T> GetSingleAsync(string id, string partitionkey)
    {
        try
        {
            ItemResponse<T> response = await _container.ReadItemAsync<T>(id, new PartitionKey(partitionkey));
            return response.Resource;
        }
        catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        var query = _container.GetItemLinqQueryable<T>()
                              .ToFeedIterator();

        List<T> results = new List<T>();
        while (query.HasMoreResults)
        {
            var response = await query.ReadNextAsync();
            results.AddRange(response);
        }
        return results;
    }

    public async Task AddAsync(T item)
    {
        await _container.CreateItemAsync(item);
    }

    public async Task UpdateAsync(string partitionkey, T item)
    {
        await _container.UpsertItemAsync(item, new PartitionKey(partitionkey));
    }

    public async Task DeleteAsync(string id, string partitionkey)
    {
        await _container.DeleteItemAsync<T>(id, new PartitionKey(partitionkey));
    }


}
