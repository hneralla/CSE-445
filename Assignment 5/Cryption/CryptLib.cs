using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

namespace Cryption
{
    public class CryptLib
    {
        public static string Encrypt(string plainString)
        {
            byte[] encryptedBytes = Encoding.ASCII.GetBytes(plainString);
            string encrypted = "";

            foreach (byte digit in encryptedBytes)
            {
                encrypted += digit;
            }

            return encrypted;
        }

        public static string Decrypt(string encryptedString)
        {
            string decrypted = "";
            IEnumerable<string> arr = Enumerable.Range(0, encryptedString.Length / 3).Select(i => encryptedString.Substring(i * 3, 3));
            List<byte> byteArr = new List<byte>();
            string[] strArr = arr.ToArray();

            int[] myInts = Array.ConvertAll(strArr, int.Parse);

            foreach (int num in myInts)
            {
                byteArr.Add((byte)num);
            }

            decrypted = Encoding.Default.GetString(byteArr.ToArray<byte>());
            return decrypted;
        }
    }
}
