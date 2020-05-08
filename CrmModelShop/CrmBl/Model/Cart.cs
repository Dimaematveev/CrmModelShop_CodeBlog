using System.Collections;
using System.Collections.Generic;

namespace CrmBl.Model
{
    /// <summary>
    /// Корзина покупателя! 
    /// customer cart!
    /// </summary>
    public class Cart :IEnumerable
    {
        /// <summary>
        /// Покупатель.
        /// Buyer
        /// </summary>
        public Customer Customer { get; set; }
        /// <summary>
        /// Продукт с количеством
        /// Products with count
        /// </summary>
        public Dictionary<Product, int> Products { get; set; }


        public Cart(Customer customer)
        {
            Customer = customer;
            Products = new Dictionary<Product, int>();
        }

        /// <summary>
        /// Добавляем 1 продукт.
        /// Add 1 product.
        /// </summary>
        /// <param name="product">Добавляемый продукт. Product added.</param>
        public void Add(Product product)
        {
            if (Products.TryGetValue(product, out int count))
            {
                Products[product] = ++count;
            }
            else
            {
                Products.Add(product, 1);
            }
        }

        /// <summary>
        /// Перечисляем все продукты, по одному (если их несколько то выведен несколько раз)
        /// We list all products, one at a time (if there are several, then it is displayed several times)
        /// </summary>
        /// <returns>  </returns>
        public IEnumerator GetEnumerator()
        {
            foreach (var product in Products.Keys)
            {
                for (int i = 0; i < Products[product]; i++)
                {
                    yield return product;
                }
            }
        }
        /// <summary>
        /// Все продукты в Список (если их несколько то выведен несколько раз)
        /// All product in List (if there are several, then it is displayed several times)
        /// </summary>
        /// <returns>Список продуктов. List product</returns>
        public List<Product> GetAll()
        {
            var result = new List<Product>();
            foreach (Product i in this)
            {
                result.Add(i);
            }
            return result;
        }

    }
}
