using System;
using System.Collections.Generic;

namespace CrmBl.Model
{
    /// <summary>
    /// Товарный чек
    /// check
    /// </summary>
    public class Check
    {
        /// <summary>
        /// ID уникальный
        /// ID unique
        /// </summary>
        public int CheckId { get; set; }
        /// <summary>
        /// ID Покупателя
        /// ID Customer
        /// </summary>
        public int CustomerId { get; set; }
        /// <summary>
        /// Покупатель
        /// Customer
        /// </summary>
        public virtual Customer Customer { get; set; }
        /// <summary>
        /// ID Продавца
        /// ID Seller
        /// </summary>
        public int SellerId { get; set; }
        /// <summary>
        /// Продавец
        /// Seller
        /// </summary>
        public virtual Seller Seller { get; set; }
        /// <summary>
        /// Дата и время покупки
        /// Date and time of purchase
        /// </summary>
        public DateTime Created { get; set; }

        /// <summary>
        /// Проданные товары, связь с таблицей Продажа(Sell)
        /// Goods sold, link to the table Sell
        /// </summary>
        public virtual ICollection<Sell> Sells { get; set; }

        public override string ToString()
        {
            return $"{CheckId} от {Created.ToString("dd.MM.yy hh:mm:ss")}";
        }
    }
}
