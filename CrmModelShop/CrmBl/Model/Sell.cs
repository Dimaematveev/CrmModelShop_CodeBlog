namespace CrmBl.Model
{
    /// <summary>
    /// Продажа продукта
    /// Sell product
    /// </summary>
    public class Sell
    {
        /// <summary>
        /// ID уникальный
        /// ID unique
        /// </summary>
        public int SellId{ get; set; }
        /// <summary>
        /// ID чека
        /// ID check
        /// </summary>
        public int CheckId { get; set; }
        /// <summary>
        /// чек
        /// Check
        /// </summary>
        public virtual Check Check { get; set; }
        /// <summary>
        /// ID продукта
        /// ID Product
        /// </summary>
        public int ProductId { get; set; }
        /// <summary>
        /// Продукт
        /// Product
        /// </summary>
        public virtual Product Product { get; set; }


    }
}
