using SleekCart.Application.Abstractions.Commands;

namespace SleekCart.Application.Commands.Payment.ProcessPaymentWebhook;

public record ProcessPaymentWebhookCommand(string Provider, string EventType, string Payload) : ICommand;