using System;

namespace Assignment_2
{
    // ASU CSE 445 Summer '17
    // Name: Harith Neralla
    // 06/03/2017

    public class OrderClass
    {
        private string senderId; //identity of the sender
        private Int32 cardNo; //credit card number
        private Int32 amount; //number of chickens to order

        public OrderClass(string senderId, Int32 cardNo, Int32 amount) //constructor
        {
            this.senderId = senderId;
            this.cardNo = cardNo;
            this.amount = amount;
        }

        // Accessor methods
        public string getSenderId()
        {
            return senderId;
        }

        public Int32 getCardNo()
        {
            return cardNo;
        }

        public Int32 getAmount()
        {
            return amount;
        }
    }
}