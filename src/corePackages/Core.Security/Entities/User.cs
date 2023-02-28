using Core.Persistence.Repositories;
using Core.Security.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Security.Entities;

public class User : Entity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public int CustomerId { get; set; }
    public int CompanyId { get; set; }
    [NotMapped]
    public byte[] PasswordSalt { get; set; }
    [NotMapped]
    public byte[] PasswordHash { get; set; }
    public bool Status { get; set; }
    public int Type { get; set; }
    public int TimeZone { get; set; }
    public DateTime MemberStartDate { get; set; } = DateTime.UtcNow;
    public DateTime? MemberEndDate { get; set; } = null;
    public AuthenticatorType AuthenticatorType { get; set; }

    public virtual Customer Customer { get; set; }
    public virtual Company Company { get; set; }
    public virtual ICollection<UserOperationClaim> UserOperationClaims { get; set; }
    public virtual ICollection<RefreshToken> RefreshTokens { get; set; }

    public User()
    {

        UserOperationClaims = new HashSet<UserOperationClaim>();
        RefreshTokens = new HashSet<RefreshToken>();
    }

    public User(int id,string firstName, string lastName, string email, int customerId, int companyId, byte[] passwordSalt, byte[] passwordHash,
        bool status, int type, int timeZone, DateTime memberStartDate, DateTime? memberEndDate, AuthenticatorType authenticatorType):base(id)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        CustomerId = customerId;
        CompanyId = companyId;
        PasswordSalt = passwordSalt;
        PasswordHash = passwordHash;
        Status = status;
        Type = type;
        TimeZone = timeZone;
        MemberStartDate = memberStartDate;
        MemberEndDate = memberEndDate;
        AuthenticatorType = authenticatorType;
    }
}