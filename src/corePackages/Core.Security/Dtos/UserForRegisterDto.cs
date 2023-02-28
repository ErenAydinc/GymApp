namespace Core.Security.Dtos;

public class UserForRegisterDto
{
    public string Email { get; set; }
    public string Password { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int CustomerId { get; set; }
    public int CompanyId { get; set; }
    public int Type { get; set; }
    public int TimeZone { get; set; }
    public DateTime MemberStartDate { get; set; } = DateTime.UtcNow;
    public DateTime MemberEndDate { get; set; }
}