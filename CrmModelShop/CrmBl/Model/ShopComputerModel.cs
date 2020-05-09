using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

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

        List<Task> tasks = new List<Task>();
        CancellationTokenSource cancellationTokenSource;
        CancellationToken token;
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
        public int CustomesSpeed { get; set; } = 100;
        public int CashDeskSpeed { get; set; } = 100;

        public ShopComputerModel()
        {
            var sellers = Generator.GetNewSellers(20);
            Generator.GetNewProducts(1000);
            Generator.GetNewCustomers(100);

            cancellationTokenSource = new CancellationTokenSource();
            token = cancellationTokenSource.Token;

            foreach (var seller in sellers)
            {
                Sellers.Enqueue(seller);
            }

            for (int i = 0; i < 3; i++) 
            {
                CashDesks.Add(new CashDesk(CashDesks.Count, Sellers.Dequeue(), null));
            }

        }

        /// <summary>
        /// Запустиь компьютерную модель
        /// </summary>
        public void Start()
        {
            //Запуск в отдельном потоке
            //isWorking = true;

            
            tasks.Add(new Task(()=> CreateCarts(10,token)));

            tasks.AddRange(CashDesks.Select(c => new Task(() => CashDeskWork(c,token))));

            foreach (var task in tasks)
            {
                task.Start();
            }
           
        }

        /// <summary>
        /// Для остановки потоков
        /// </summary>
        public void Stop()
        {
            cancellationTokenSource.Cancel();

        }

        /// <summary>
        /// Работа касс
        /// </summary>
        /// <param name="cashDesk">касса</param>
        /// <param name="sleep">Время задержки после создания покупателя. в мс</param>
        private void CashDeskWork(CashDesk cashDesk, CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                if (cashDesk.Count > 0)
                {
                    cashDesk.Dequeue();
                    Thread.Sleep(CashDeskSpeed);
                }
            }

        }

        /// <summary>
        /// Создание Корзин и покупателей. Делаем в отдельных потоках
        /// </summary>
        /// <param name="customerCounts">Кол-во покупателей(корзин)</param>
        /// <param name="sleep">Время задержки после создания покупателя. в мс</param>
        private void CreateCarts(int customerCounts, CancellationToken token)
        {
            while(!token.IsCancellationRequested)
            {
                var customers = Generator.GetNewCustomers(customerCounts);
                

                foreach (var customer in customers)
                {
                    var cart = new Cart(customer);
                    foreach (var product in Generator.GetRandomProducts(10,30))
                    {
                        cart.Add(product);
                    }
                    var cash = CashDesks[rnd.Next(CashDesks.Count)];//ToDO:
                    cash.Enqueu(cart);
                }
                Thread.Sleep(CustomesSpeed);
            }
            
        }
    }
}
