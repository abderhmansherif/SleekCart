using e_commerse.Domain.Exceptions.User;

namespace SleekCart.Domain.ValueObjects.User
{
    public record UserFullName
    {
        public string Value { get; }

        public UserFullName(string value)
        {
            if(string.IsNullOrEmpty(value))
            {
                throw new EmptyUserFullNameException();
            }

            Value = value;
        }

        public static implicit operator string(UserFullName fullName) => fullName.Value;

        public static implicit operator UserFullName(string value) => new UserFullName(value);
    }
}
