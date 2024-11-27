using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment4.Api.Entities;

public class Family
{
    public string Id { get; set; }
    public string FamilyType { get; } = "ExtentedFamily";
    public string LastName { get; set; }
    public bool IsRegistered { get; set; }

    public List<Parent> Parents { get; set; }
    public List<Child> Children { get; set; }
}

public class Parent
{
    //public string Id { get; set; }
    //public string FamilyId { get; set; }
    public string FirstName { get; set; }
    public string FamilyName { get; set; }
}

public class Child
{
    //public int Id { get; set; }
    //public string FamilyId { get; set; }
    public string FirstName { get; set; }
    public string Gender { get; set; }
    public int Grade { get; set; }
    public string FamilyName { get; set; }

    //public Family Family { get; set; }
}
