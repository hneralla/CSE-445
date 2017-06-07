using System;


namespace Assignment_2
{
    // ASU CSE 445 Summer '17
    // Name: Harith Neralla
    // 06/03/2017
   
    public class encodeDecode
    {
        // Class contains encode(...) and decode(...) methods for the Retailer and ChickenFarm to call.
        public static string encode(OrderClass orderObject)
        {
            // Encodes into following format: "senderId:cardNo:amount"
            string data = orderObject.getSenderId() + ":" + orderObject.getCardNo().ToString()
                            + ":" + orderObject.getAmount().ToString();
            return data;
        }

        public static OrderClass decode(string data)
        {
            // Decodes the string input and returns an orderObject
            var output = data.Split(new[] { ':' }); //splits the string with the colons
            OrderClass orderObject = new OrderClass(output[0], Convert.ToInt32(output[1]), Convert.ToInt32(output[2]));
            return orderObject;
        }
    } 
}