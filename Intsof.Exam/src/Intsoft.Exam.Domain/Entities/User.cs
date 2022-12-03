using Intsoft.Domain.ValueObjects;

namespace Intsoft.Domain.Entities;

public class User
{
    public int UserId { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public ulong NationalCode { get; set; }
    public ulong PhoneNumber { get; set; }
}
