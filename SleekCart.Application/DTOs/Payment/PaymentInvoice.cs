using SleekCart.Application.DTOs.Product;

namespace SleekCart.Application.DTOs.Payment;

public class PaymentInvoice
{
    public Guid OrderId { get; set; }
    public MoneyDto Price { get; set; } = null!;
    public string Descreption { get; set; } = string.Empty;
    public string CustomerEmail { get; set; } = string.Empty;

    public PaymentInvoice(Guid orderId, MoneyDto price, string descreption, string customerEmail)
    {
        this.OrderId = orderId;
        this.Price = price;
        this.Descreption = descreption;
        this.CustomerEmail = customerEmail;
    }
}