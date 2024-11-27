using Newtonsoft.Json;

namespace Assignment4.Api.Entities;

public class FamilyNoSql
{
    [JsonProperty(PropertyName = "id")]
    public string Id { get; set; }
    [JsonProperty(PropertyName = "partitionKey")]
    public string PartitionKey { get; } = "ExtentedFamily";
    public string FamilyType { get; } = "ExtentedFamily";
    public string LastName { get; set; }
    public ParentNoSql[] Parents { get; set; }
    public ChildNoSql[] Children { get; set; }
    public AddressNoSql Address { get; set; }
    public bool IsRegistered { get; set; }
    public override string ToString()
    {
        return JsonConvert.SerializeObject(this);
    }
}

public class ParentNoSql
{
    public string FamilyName { get; set; }
    public string FirstName { get; set; }
}

public class ChildNoSql
{
    public string FamilyName { get; set; }
    public string FirstName { get; set; }
    public string Gender { get; set; }
    public int Grade { get; set; }
    public PetNoSql[] Pets { get; set; }
}

public class PetNoSql
{
    public string GivenName { get; set; }
}

public class AddressNoSql
{
    public string State { get; set; }
    public string County { get; set; }
    public string City { get; set; }
}