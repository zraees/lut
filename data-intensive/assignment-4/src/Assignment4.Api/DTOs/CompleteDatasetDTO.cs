using Assignment4.Api.Entities;

namespace Assignment4.Api.DTOs;

public class CompleteDatasetDTO
{
    public List<FamilyNoSql> NoSqlData { get; set; } = [];

    public List<FamilySql> SqlData { get; set; } = [];

    public List<Family> CombineData { get; set; } = [];
}
