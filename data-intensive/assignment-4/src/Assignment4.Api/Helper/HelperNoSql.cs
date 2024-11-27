using Assignment4.Api.Entities;
using Microsoft.Azure.Cosmos;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace Assignment4.Api.Helper;

public static class HelperNoSql
{
    private static readonly string _connectionString = "AccountEndpoint=https://dis-assign4.documents.azure.com:443/;AccountKey=WpqVlpUDkCV0pmuplIiUTfZJutO0lV0WB2SmsJjhEhgq3g4VQ3vqSBca8hdtFGMw3wa2fTzj37qeACDbh3sUmg==;";
    private static readonly string _databaseId = "assignment4";
    private static readonly string _containerId = "families";

    private const string PARTITIONKEY = "ExtentedFamily";

    public static async Task<List<FamilyNoSql>> GetAllAsync()
    {
        try
        {
            CosmosClient client = new CosmosClient(_connectionString);
            Container container = client.GetContainer(_databaseId, _containerId);
            string query = "SELECT * FROM c WHERE c.partitionKey='" + PARTITIONKEY + "'";

            QueryDefinition queryDefinition = new QueryDefinition(query);

            FeedIterator<FamilyNoSql> queryResult = container.GetItemQueryIterator<FamilyNoSql>(queryDefinition);

            List<FamilyNoSql> families = new List<FamilyNoSql>();

            while (queryResult.HasMoreResults)
            {
                FeedResponse<FamilyNoSql> familyCurrentResultSet = await queryResult.ReadNextAsync().ConfigureAwait(false);

                foreach (FamilyNoSql family in familyCurrentResultSet)
                {
                    families.Add(family);
                }
            }
           
            return families;
        }
        catch (Exception)
        {
            return null;
        }
    }

    public static async Task<string> CreateAsync(FamilyNoSql family)
    {
        try
        {
            CosmosClient client = new CosmosClient(_connectionString);
            Container container = client.GetContainer(_databaseId, _containerId);

            ItemResponse<FamilyNoSql> response = await container.CreateItemAsync<FamilyNoSql>(family, new PartitionKey(PARTITIONKEY)).ConfigureAwait(false);

            return response.Resource.Id;
        }
        catch (Exception)
        {
            return "";
        }
    }

    public static async Task<string> UpdateRegistrationAsync(string id, bool registration)
    {
        try
        {
            CosmosClient client = new CosmosClient(_connectionString);
            Container container = client.GetContainer(_databaseId, _containerId);

            ItemResponse<FamilyNoSql> response = await container.ReadItemAsync<FamilyNoSql>(id, new PartitionKey(PARTITIONKEY)).ConfigureAwait(false);

            response.Resource.IsRegistered = registration;

            response = await container.ReplaceItemAsync<FamilyNoSql>(response.Resource, id, new PartitionKey(PARTITIONKEY)).ConfigureAwait(false);

            return response.Resource.Id;
        }
        catch (Exception)
        {
            return "";
        }
    }

    public static async Task<string> DeleteAsync(string id)
    {
        try
        {
            CosmosClient client = new CosmosClient(_connectionString);
            Container container = client.GetContainer(_databaseId, _containerId);

            ItemResponse<FamilyNoSql> response = await container.DeleteItemAsync<FamilyNoSql>(id, new PartitionKey(PARTITIONKEY)).ConfigureAwait(false);

            return id;
        }
        catch (Exception)
        {
            return "";
        }
    }
}