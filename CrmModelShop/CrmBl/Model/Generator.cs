using System;
using System.Collections.Generic;

namespace CrmBl.Model
{
    /// <summary>
    /// Создает виртуальные объекты
    /// </summary>
    public class Generator
    {
        /// <summary>
        /// Рандом
        /// </summary>
        Random rnd = new Random();
        /// <summary>
        /// Список покупателей
        /// </summary>
        public List<Customer> Customers { get; set; } = new List<Customer>();
        /// <summary>
        /// Список продуктов
        /// </summary>
        public List<Product> Products { get; set; } = new List<Product>();
        /// <summary>
        /// Список продавцов
        /// </summary>
        public List<Seller> Sellers { get; set; } = new List<Seller>();


        /// <summary>
        /// Получить список покупателей. Добавляет новых покупателей к имеющимся
        /// </summary>
        /// <param name="count">Кол-во добавляемых</param>
        /// <returns>Список новых покупателей</returns>
        public List<Customer> GetNewCustomers(int count)
        {
            var result = new List<Customer>();
            for (int i = 0; i < count; i++)
            {
                var customer = new Customer()
                {
                    CustomerID=Customers.Count,
                    Name = GetRandomText(),
                };
                Customers.Add(customer);
                result.Add(customer);
            }
            return result;
        }

        /// <summary>
        /// Получить список Продавцов. Добавляет новых Продавцов к имеющимся
        /// </summary>
        /// <param name="count">Кол-во добавляемых</param>
        /// <returns>Список новых Продавцов</returns>
        public List<Seller> GetNewSellers(int count)
        {
            var result = new List<Seller>();
            for (int i = 0; i < count; i++)
            {
                var seller = new Seller()
                {
                    SellerId = Sellers.Count,
                    Name = GetRandomText(),
                };
                Sellers.Add(seller);
                result.Add(seller);
            }
            return result;
        }

        /// <summary>
        /// Получить список продуктов. Добавляет новых продуктов к имеющимся
        /// </summary>
        /// <param name="count">Кол-во добавляемых</param>
        /// <returns>Список новых продуктов</returns>
        public List<Product> GetNewProducts(int count)
        {
            var result = new List<Product>();
            for (int i = 0; i < count; i++)
            {
                var product = new Product()
                {
                    ProductId = Products.Count,
                    Name = GetRandomText(),
                    Price = Convert.ToDecimal(rnd.Next(5, 100000) + rnd.NextDouble()),
                    Count = rnd.Next(10, 1000)
                };
                Products.Add(product);
                result.Add(product);
            }
            return result;
        }

        /// <summary>
        /// Выбрать случайные продукты из общего списка.
        /// </summary>
        /// <param name="min">Минимальное кол-во получаемых продуктов</param>
        /// <param name="max">Максимальное кол-во получаемых продуктов</param>
        /// <returns>Список продуктов</returns>
        public List<Product> GetRandomProducts(int min, int max)
        {
            var result = new List<Product>();

            var count = rnd.Next(min, max);
            for (int i = 0; i < count; i++)
            {
                result.Add(Products[rnd.Next(Products.Count - 1)]);
            }

            return result;
        }


        /// <summary>
        /// Получить случайный текст из 5 букв
        /// </summary>
        /// <returns></returns>
        private static string GetRandomText()
        {
            return Guid.NewGuid().ToString().Substring(0, 5);
        }
    
    }
}
