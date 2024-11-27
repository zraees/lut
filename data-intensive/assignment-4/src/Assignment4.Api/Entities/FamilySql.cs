using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment4.Api.Entities;

public class FamilySql
{
    public string Id { get; set; }
    public string FamilyType { get; } = "ExtentedFamily";
    public string LastName { get; set; }
    public bool IsRegistered { get; set; }

    public IEnumerable<ParentSql> Parents { get; set; }
    public IEnumerable<ChildSql> Children { get; set; }
}

public class ParentSql
{
    public string Id { get; set; }
    public string FamilyId { get; set; }
    public string FirstName { get; set; }

    //public FamilySql Family { get; set; }
}

public class ChildSql
{
    public int Id { get; set; }
    public string FamilyId { get; set; }
    public string FirstName { get; set; }
    public string Gender { get; set; }
    public int Grade { get; set; }

    //public FamilySql Family { get; set; }
}
