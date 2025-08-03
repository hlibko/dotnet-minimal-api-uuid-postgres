using System.ComponentModel.DataAnnotations;

namespace dotnet_minimal_api_uuid_postgres.Models;

public class User
{
    [Key]
    public Guid Id { get; set; }

    public required string Username { get; set; }
}
