using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Prime.Library.Services
{
    public class PrimeSecurityService
    {
        /// <summary>
        /// Function taking a plain text string and returns an encrypted version using
        /// MD5 and TripleDES encryption.
        /// </summary>
        /// <param name="plainText"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static string Encrypt(string plainText)
        {
            if(string.IsNullOrEmpty(plainText))
                throw new ArgumentNullException(nameof(plainText), "Input cannot be null or empty.");

            byte[] keyArray;
            byte[] toEncryptArray = Encoding.UTF8.GetBytes(plainText);

            var key = "mYsUpErLoNgKey123!";

            MD5 hashMd5 = MD5.Create();
            keyArray = MD5.HashData(Encoding.UTF8.GetBytes(key));

            // Considered best practice to release and flush data of Cryptographic
            // service provider
            hashMd5.Clear();

            TripleDES tdes = TripleDES.Create();
            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;

            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateEncryptor();

            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
            tdes.Clear();

            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }

        public static string Decrypt(string cipherText)
        {
            if(string.IsNullOrEmpty(cipherText))
                throw new ArgumentNullException(nameof(cipherText), "Input cannot be null or empty.");
            
            byte[] keyArray;
            byte[] toDecryptArray = Convert.FromBase64String(cipherText);
            var key = "mYsUpErLoNgKey123!";
            MD5 hashMd5 = MD5.Create();
            keyArray = MD5.HashData(Encoding.UTF8.GetBytes(key));
            
            hashMd5.Clear();
            TripleDES tdes = TripleDES.Create();
            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;
            ICryptoTransform cTransform = tdes.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toDecryptArray, 0, toDecryptArray.Length);
            tdes.Clear();
            return Encoding.UTF8.GetString(resultArray);
        }
    }
}
