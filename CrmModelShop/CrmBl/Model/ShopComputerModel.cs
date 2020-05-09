using System;
using System.Collections.Generic;
using System.Linq;

namespace CrmBl.Model
{
    /// <summary>
    /// Компьютерная модель, для проверки работоспособности логики приложения
    /// Computer model, for check work logic application
    /// </summary>
    public class ShopComputerModel
    {
        /// <summary>
        /// Генератор наших классов
        /// </summary>
        Generator Generator = new Generator();
        /// <summary>
        /// Для рандома
        /// </summary>
        Random rnd = new Random();

        /// <summary>
        /// Список касс
        /// </summary>
        public List<CashDesk> CashDesks { get; set; } = new List<CashDesk>();
        /// <summary>
        /// Список корзин
        /// </summary>
        public List<Cart> Carts { get; set; } = new List<Cart>();

        /// <summary>
        /// Список чеков
        /// </summary>
        public List<Check> Checks { get; set; } = new List<Check>();

        /// <summary>
        /// Список покупок
        /// </summary>
        public List<Sell> Sells { get; set; } = new List<Sell>();

        /// <summary>
        /// Очередь продавцов
        /// </summary>
        public Queue<Seller> Sellers { get; set; } = new Queue<Seller>();
        public ShopComputerModel()
        {
            var sellers = Generator.GetNewSellers(20);
            Generator.GetNewProducts(1000);
            Generator.GetNewCustomers(100);
            foreach (var seller in sellers)
            {
                Sellers.Enqueue(seller);
            }

            for (int i = 0; i < 3; i++) 
            {
                CashDesks.Add(new CashDesk(CashDesks.Count, Sellers.Dequeue()));
            }

        }

        /// <summary>
        /// Запустиь компьютерную модель
        /// </summary>
        public void Start()
        {
            var customers = Generator.GetNewCustomers(10);
            var carts = new Queue<Cart>();
            foreach (var customer in customers)
            {
                var cart = new Cart(customer);
                foreach (var prod in Generator.GetRandomProducts(10,30))
                {
                    cart.Add(prod);
                }
                carts.Enqueue(cart);
            }

            while (carts.Count > 0)
            {
                var cash = CashDesks[rnd.Next(CashDesks.Count - 1)];//ToDO:
                cash.Enqueu(carts.Dequeue());
            }


            while (true)
            {
                var cash = CashDesks[rnd.Next(CashDesks.Count - 1)];//ToDO:
                var money = cash.Dequeue();
            }
        }
    }
}
