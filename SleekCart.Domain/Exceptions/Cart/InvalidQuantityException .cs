using e_commerse.Domain.Abstractions.Exceptions;

public class InvalidQuantityException : CartException
{
    public InvalidQuantityException()
        : base("Quantity must be greater than zero.") { }
}