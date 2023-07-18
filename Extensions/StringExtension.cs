using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Extensions_Lecture9.Extensions
{
    public static class StringExtension
    {
        public static bool IsNumber(this string str)
        {
            return int.TryParse(str, out _);
        }
        public static bool IsDate(this string str)
        {
            return DateTime.TryParse(str, out _);
        }
        public static string[] ToWords(this string str)
        {
            return str.Split(" ");
        }
        public static void SaveToFile(this string filePath)
        {
            string text = "Hello World!";
            using(StreamWriter sw = File.CreateText(filePath))
            {
                sw.Write(text);
            }
        }
        public static string Encrypt(this string plainText, string key, string iv)
        {
            byte[] keyBytes = Encoding.UTF8.GetBytes(key);
            byte[] ivBytes = Encoding.UTF8.GetBytes(iv);
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);

            using (Aes aes = Aes.Create())
            {
                aes.Key = keyBytes;
                aes.IV = ivBytes;

                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                byte[] encryptedBytes = encryptor.TransformFinalBlock(plainTextBytes, 0, plainTextBytes.Length);

                string encryptedString = Convert.ToBase64String(encryptedBytes);
                return encryptedString;
            }
            
        }
        public static string Decrypt(this string  plainText, string key, string iv)
        {
            byte[] keyBytes = Encoding.UTF8.GetBytes(key);
            byte[] ivBytes = Encoding.UTF8.GetBytes(iv);
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            using (Aes aes = Aes.Create())
            {
                aes.Key = keyBytes;
                aes.IV = ivBytes;
                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
                byte[] decryptedBytes = decryptor.TransformFinalBlock(plainTextBytes, 0, plainText.Length);
                string decryptedString = Convert.ToBase64String(decryptedBytes);
                return decryptedString;
            }

        }

    }
}
