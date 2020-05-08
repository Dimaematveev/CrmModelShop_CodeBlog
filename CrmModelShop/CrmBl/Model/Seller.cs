using System.Collections.Generic;

namespace CrmBl.Model
{
    /// <summary>
    /// Продавец
    /// Seller
    /// </summary>
    public class Seller
    {
        /// <summary>
        /// ID уникальный
        /// ID unique
        /// </summary>
        public int SellerId { get; set; }
        /// <summary>
        /// Имя продавца
        /// Seller name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Список чеков этого продавца
        /// List checks this Seller
        /// </summary>
        public virtual ICollection<Check> Checks { get; set; }
        public override string ToString()
        {
            return Name;
        }
    }
}
