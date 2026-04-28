using SleekCart.Domain.ValueObjects.User;

namespace SleekCart.Domain.Entities;

public class RefreshToken
{
    public Guid Id { get; set; }
    public Guid JWTId { get; set; }
    public string Token { get; set; }
    public UserId UserId { get; set; }
    public bool IsRevoked { get; set; }
    public bool IsUsed { get; set; }
    public DateTime ExpiryDate { get; set; }

    public RefreshToken(Guid jwtId, string token, UserId userId, TimeSpan duration)
    {
        this.Id = Guid.NewGuid();
        this.JWTId = jwtId;
        this.Token = token;
        this.UserId = userId;
        this.IsRevoked = false;
        this.IsUsed = false;
        this.ExpiryDate = DateTime.UtcNow.Add(duration);
    }
}
