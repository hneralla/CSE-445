using System;
using System.Threading;

namespace Assignment_2
{
    // ASU CSE 445 Summer '17
    // Name: Harith Neralla
    // 06/03/2017

    public class Retailer
    {
        public static event orderCreatedEvent orderCreated; // Event to let chickenFarm know that a new order is available to process 
        public static Random rnd = new Random();
        public void retailerFunc() // for starting a thread
        {
            while(Program.chickenThreadRunning) //thread will run until the chicken thread has ended
            {
                Thread.Sleep(rnd.Next(1500, 3000));
                createOrder(Thread.CurrentThread.Name);
            }
        }

        private void createOrder(string senderID)
        {
            Int32 cardNo = rnd.Next(9000, 9999); //generates a random valid credit card number
            Int32 amount = rnd.Next(10, 100); //generates a random number of chickens needed (between 10 and 100)

            OrderClass orderObject = new OrderClass(senderID, cardNo, amount); //creates orderObject with generated data
            string orderString = encodeDecode.encode(orderObject); //encodes orderObject into a string

            Console.WriteLine("Store {0}'s order has been created at {1}.", senderID, DateTime.Now.ToString("hh:mm:ss"));

            Program.mcb.setOneCell(orderString); //inserts order into the MultiCellBuffer
            orderCreated(); //emits event to subscribers
        }

        public void orderProcessed(string senderID, Int32 amountToCharge, Int32 price, Int32 amount) // Event handler when the order is processed
        {
            Console.WriteLine("Store {0}'s order has been processed. The amount to be charged is $" + amountToCharge + " ($" + price + " per chicken for " + amount + " chickens).", senderID, Thread.CurrentThread.Name);
        }

        public void chickenOnSale(Int32 p, string senderID) // Event handler 
        {
            // order chickens from chicken farm - send order into queue    
            Console.WriteLine("Chickens are on sale. Store {0} is about to place an order.", senderID);
            createOrder(senderID);
        }
    }
}