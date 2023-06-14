using System.ComponentModel;

namespace Domain.Enums;

public enum PaymentMethodEnum
{
    [Description("Cash")]
    Cash,
    [Description("Debit Card")]
    DebitCard,
    [Description("Credit Card")]
    CreditCard,
    [Description("Mobile Payments")]
    MobilePayments
}