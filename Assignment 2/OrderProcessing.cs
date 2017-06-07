using System;

namespace Assignment_2
{
    // ASU CSE 445 Summer '17
    // Name: Harith Neralla
    // 06/03/2017

    public class OrderProcessing
    {
        // Class contains processOrder(...) method which checks credit card validity and calculates total amount of the order
        public static event orderProcessedEvent orderProcessed; // Event is triggered whenever a new order has been processed (retailer will print verification)
        public static void processOrder(OrderClass orderObject, Int32 unitPrice) // for starting a thread
        {
            if (!checkValidity(orderObject.getCardNo()))
            {
                Console.WriteLine("{0} is not a valid credit card number.", orderObject.getCardNo()); 
                return;
            }
            else
            {
                Int32 amountToPay = Convert.ToInt32(1.08 * (unitPrice * orderObject.getAmount())); // unitPrice * amount + tax (8%)  
                orderProcessed(orderObject.getSenderId(), amountToPay, unitPrice, orderObject.getAmount()); // emits event to subscribers
            }
        }

        private static Boolean checkValidity(Int32 cardNo)
        {
            // Makes sure that the credit-card number is a valid number 
            if (cardNo <= 9999 && cardNo >= 9000) // Checks if card number is in range
                return true;
            else
                return false;
        }
    }
}