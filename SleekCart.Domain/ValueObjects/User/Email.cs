using e_commerse.Domain.Exceptions.User;

namespace e_commerse.Domain.ValueObjects.User
{
    public record Email
    {
        public string Value { get; }

        public Email(string value)
        {
            if(string.IsNullOrEmpty(value))
            {
                throw new EmptyUserEmailException();
            }

            Value = value;
        }

        public static implicit operator string(Email email) => email.Value;

        public static implicit operator Email(string value) => new Email(value);
    }
}
