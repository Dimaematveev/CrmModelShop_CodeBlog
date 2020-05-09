using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CrmBl.Model
{
    /// <summary>
    /// Касса
    /// Cash desk
    /// </summary>
    public class CashDesk
    {
        /// <summary>
        /// Контекст БД 
        /// </summary>
        CrmContext db = new CrmContext();

        /// <summary>
        /// Номер кассы
        /// Cash desk number 
        /// </summary>
        public int Number { get; set; }
        /// <summary>
        /// Продавец
        /// Seller
        /// </summary>
        public Seller Seller { get; set; }
        /// <summary>
        /// Очередь (состоит из корзин покупателей)
        /// Queue (consists of carts customers)
        /// </summary>
        public Queue<Cart> Queue { get; set; }
        /// <summary>
        /// Максимальная длина очереди. После которой покупатель уйдет
        /// Max length queue. After which the buyer will leave
        /// </summary>

        public int MaxQueueLength { get; set; }
        /// <summary>
        /// Количество ушедших покупателей
        /// Number of departed customers
        /// </summary>
        public int ExitCustomert { get; set; }
        /// <summary>
        /// Количество покупателей в очереди
        /// Number customers in queue
        /// </summary>
        public int Count => Queue.Count;
       
        /// <summary>
        /// Событие продажи
        /// </summary>
        public event EventHandler<Check> CheckClosed;
        /// <summary>
        /// Если true то значит модель , то есть не сохранять данные в базу.
        /// If true, it means a model, that is, do not save data to the database.
        /// </summary>
        public bool IsModel { get; set; }
        public CashDesk(int number,Seller seller)
        {
            Number = number;
            Seller = seller;
            Queue = new Queue<Cart>();
            IsModel = true;
            MaxQueueLength = 10;
        }

        /// <summary>
        /// Добавляем корзину в очередь
        /// Add the cart to the queue
        /// </summary>
        /// <param name="cart"> </param>
        public void Enqueu(Cart cart)
        {
            if (Queue.Count <= MaxQueueLength) 
            {
                Queue.Enqueue(cart);
            }
            else
            {
                ExitCustomert++;
            }
        }
        /// <summary>
        /// Извлекаем корзину из очереди
        /// We remove the basket from the queue
        /// </summary>
        /// <returns>Количество денег за продукты в корзине. Count money at product in cart</returns>
        public decimal Dequeue()
        {
            decimal sum = 0;
            if (Queue.Count == 0)
            {
                return 0;
            }
            var card = Queue.Dequeue();
            if (card != null)
            {
                var check = new Check()
                {
                    SellerId = Seller.SellerId,
                    Seller = Seller,
                    CustomerId = card.Customer.CustomerID,
                    Customer = card.Customer,
                    Created = DateTime.Now
                };

                if (!IsModel)
                {
                    db.Checks.Add(check);
                    db.SaveChanges();
                }
                else
                {
                    check.CheckId = 0;
                }

                var sells = new List<Sell>();

                foreach (Product product in card)
                {
                    if (product.Count > 0) 
                    {
                        var sell = new Sell()
                        {
                            CheckId = check.CheckId,
                            Check = check,
                            ProductId = product.ProductId,
                            Product = product
                        };

                        sells.Add(sell);

                        if (!IsModel)
                        {
                            db.Sells.Add(sell);
                        }

                        product.Count--;
                        sum += product.Price;
                    }
                }
                check.Price = sum;

                if (!IsModel)
                {
                    db.SaveChanges();
                }
                ///получим информацию и о кассе и о чеке
                CheckClosed?.Invoke(this, check);
            }
            return sum;
        }

        public override string ToString()
        {
            return $"Касса №{Number}";
        }
    }
}
