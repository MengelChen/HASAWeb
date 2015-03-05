using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Text;

namespace HASAWeb.Tools
{
    public class Security
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="plainText"></param>
        /// <returns>encryptedText</returns>
        public static string Encrypt(string plainText)
        {
            SHA256Managed _sha256 = new SHA256Managed();
            byte[] _cipherText = _sha256.ComputeHash(Encoding.Default.GetBytes(plainText));
            return Convert.ToBase64String(_cipherText);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="plainText"></param>
        /// <param name="encryptedText"></param>
        /// <returns>(plainText==encryptedText)?</returns>
        public static bool Equal(string plainText, string encryptedText)
        {
            if (Encrypt(plainText) == encryptedText) return true;
            else return false;
        }
    }
}