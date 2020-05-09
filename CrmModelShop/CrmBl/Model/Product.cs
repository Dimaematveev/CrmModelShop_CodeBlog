using System.Collections.Generic;

namespace CrmBl.Model
{
    /// <summary>
    /// Продукты 
    /// Product
    /// </summary>
    public class Product
    {
        /// <summary>
        /// ID уникальный
        /// ID unique
        /// </summary>
        public int ProductId { get; set; }
        /// <summary>
        /// Наименование продукта
        /// Product name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Цена
        /// Price
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// Количество товара
        /// Count
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// Список продаж этого продукта
        /// List sell this product
        /// </summary>
        public virtual ICollection<Sell> Sells { get; set; }
        public override string ToString()
        {
            return $"{Name} - {Price}";
        }

        public override int GetHashCode()
        {
            return ProductId;
        }
        public override bool Equals(object obj)
        {
            if (obj is Product product)
            {
                return ProductId.Equals(product.ProductId);
            }
            return false;
            
        }
    }
}
