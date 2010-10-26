using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

    }
}
