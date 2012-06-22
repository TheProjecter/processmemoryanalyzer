using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace PMA.Utils
{
    public class OperationUtils
    {
        //----------------------------------------------------------------------------------------------
        /// <summary>
        /// Encrypts decrypt text provided with the key.
        /// </summary>
        /// <param name="textToEncrypt">The text to encrypt.</param>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public static string EncryptDecrypt(string textToEncrypt)
        {
            if (textToEncrypt != null)
            {
                int key = 22;
                StringBuilder inSb = new StringBuilder(textToEncrypt);
                StringBuilder outSb = new StringBuilder(textToEncrypt.Length);
                char c;
                for (int i = 0; i < textToEncrypt.Length; i++)
                {
                    c = inSb[i];
                    c = (char)(c ^ key);
                    outSb.Append(c);
                }
                return outSb.ToString();
            }
            else return null;
       
        }

        /// <summary>
        /// Encodes the password to md5.
        /// </summary>
        /// <param name="originalPassword">The original password.</param>
        /// <returns></returns>
        public static string EncodePasswordToMD5(string originalPassword)
        {
            //Declarations
            Byte[] originalBytes;
            Byte[] encodedBytes;
            MD5 md5;

            //Instantiate MD5CryptoServiceProvider, get bytes for original password and compute hash (encoded password)
            md5 = new MD5CryptoServiceProvider();
            originalBytes = ASCIIEncoding.Default.GetBytes(originalPassword);
            encodedBytes = md5.ComputeHash(originalBytes);

            //Convert encoded bytes back to a 'readable' string
            return BitConverter.ToString(encodedBytes);
        }





    }
}
