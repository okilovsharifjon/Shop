using System;

namespace OsonCommerce.Domain.Entities
{
    public static class CartStatus
    {
        public const int Active = 1;      // Корзина, которая в настоящее время используется и содержит товары.
        public const int Abandoned = 2;   // Корзина, которая была оставлена пользователем без завершения покупки.
        public const int Completed = 3;   // Корзина, для которой была завершена покупка и заказ оформлен.
        public const int Cancelled = 4;   // Корзина, которая была отменена пользователем или системой.
        public const int Expired = 5;     // Корзина, которая была автоматически закрыта после определенного времени бездействия.
    }
}
