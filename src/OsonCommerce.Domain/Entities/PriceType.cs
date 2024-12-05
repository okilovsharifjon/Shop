namespace OsonCommerce.Domain.Entities;

public class PriceType
{
    public const int RetailPrice = 1;          // Розничная цена
    public const int WholesalePrice = 2;        // Оптовая цена
    public const int DiscountedPrice = 3;       // Скидочная цена
    public const int PromotionalPrice = 4;      // Акционная цена
    public const int SubscriptionPrice = 5;      // Цена по подписке
    public const int LoyaltyPrice = 6;           // Цена для постоянных клиентов
    public const int CorporatePrice = 7;         // Цена для корпоративных клиентов
}
