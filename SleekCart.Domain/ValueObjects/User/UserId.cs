using e_commerse.Domain.Exceptions.User;

namespace SleekCart.Domain.ValueObjects.User
{
    public record UserId
    {
        public Guid Value { get; }

        public UserId(Guid value)
        {
            if(string.IsNullOrEmpty(value.ToString()))
            {
                throw new EmptyUserIdException();
            }

            Value = value;
        }

        public static implicit operator Guid(UserId userId) => userId.Value;

        public static implicit operator UserId(Guid value) => new UserId(value);
    }
}
