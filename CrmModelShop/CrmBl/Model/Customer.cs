using System.Collections.Generic;

namespace CrmBl.Model
{
    /// <summary>
    /// Покупатель
    /// Customer
    /// </summary>
    public class Customer
    {
        /// <summary>
        /// ID уникальный
        /// ID unique
        /// </summary>
        public int CustomerID { get; set; }
        /// <summary>
        /// Имя Покупателя
        /// Customer name
        /// </summary>
        public string Name{ get; set; }

        /// <summary>
        /// Товарные чеки данного покупателя
        /// Checks of this customer
        /// </summary>
        public virtual ICollection<Check> Checks { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
