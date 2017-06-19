using System;
using System.Threading;

namespace Assignment_2
{
    // ASU CSE 445 Summer '17
    // Name: Harith Neralla
    // 06/03/2017

    public class ChickenFarm
    {
        static Random rnd = new Random(); // To generate random numbers
        public static event priceCutEvent priceCut; // Link event to delegate

        private static Int32 priceCutCount = 0;
        private static Int32 loc = 0;
        private static Int32 chickenPrice = 15; //initial price

        public Int32 getPrice() { return chickenPrice; }

        public static void changePrice(Int32 price)
        {
            if (loc == Program.retailers.Length) // makes sure that no index-out-of-bounds exception occurs
                loc = 0;

            if (priceCut != null)//there is at least a subscriber
            {
                if (price < chickenPrice) //checks if new price is less than original price
                {
                    priceCut(price, Program.retailers[loc].Name); // emits event only if the price has been decreased
                    loc++;
                    priceCutCount++; //increments number of priceCut events
                }

                if (price != chickenPrice) //changes chicken price as long as new price is different from the old one
                    chickenPrice = price; 
            }
        }

        private Int32 pricingModel()
        {
            Int32 price = rnd.Next(10, 40); //generates a random price between $10 and $50
            return price;         
        }

        public void chickenFunc()
        {
            while (priceCutCount < 10)
            {
                Thread.Sleep(rnd.Next(1000, 2000)); //generates a new price every 500-1000 seconds
                Int32 price = pricingModel(); 
                changePrice(price); //changes the price
            }
            Program.chickenThreadRunning = false; // lets retailer threads know that the chicken thread has ended
        }

        public void runOrder() //event handler
        {
            string order = Program.mcb.getOneCell(); //retrieves the order from the MultiCellBuffer
            OrderClass orderObject = encodeDecode.decode(order); //decodes the string
            Thread thread = new Thread(() => OrderProcessing.processOrder(orderObject, getPrice())); 
            thread.Start(); //starts the order processing thread
        }

    }   
}