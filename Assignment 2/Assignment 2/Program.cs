using System;
using System.Threading;

namespace Assignment_2
{
    // ASU CSE 445 Summer '17
    // Name: Harith Neralla
    // 06/03/2017

    public delegate void priceCutEvent(Int32 pr, string senderID);
    public delegate void orderProcessedEvent(string senderID, Int32 amountToCharge, Int32 price, Int32 amount);
    public delegate void orderCreatedEvent();
   
    public class Program
    {
        public static bool chickenThreadRunning = true; 
        public static MultiCellBuffer mcb;
        public static Thread[] retailers; 

        static void Main(string[] args)
        {
            ChickenFarm chicken = new ChickenFarm(); //chicken object
            Retailer chickenStore = new Retailer(); //retailer object

            mcb = new MultiCellBuffer(3); //initializes MultiCellBuffer with 3 cells

            Thread chickenFunc = new Thread(new ThreadStart(chicken.chickenFunc)); //chicken thread
            
            chickenFunc.Start(); // starts the chicken thread

            ChickenFarm.priceCut += new priceCutEvent(chickenStore.chickenOnSale); //execute chickenOnSale method when price is cut
            Retailer.orderCreated += new orderCreatedEvent(chicken.runOrder); //runOrder when the orderCreated event is emitted
            OrderProcessing.orderProcessed += new orderProcessedEvent(chickenStore.orderProcessed); //order processed confirmation callback

            retailers = new Thread[5]; //create 5 threads 
            
            for (int i = 0; i < 5; i++) // N = 5 here
            { //Start N retailer threads
                retailers[i] = new Thread(new ThreadStart(chickenStore.retailerFunc)); //starts thread with retailer function
                retailers[i].Name = (i + 1).ToString();
                retailers[i].Start(); 
            }
        }
    }
}
