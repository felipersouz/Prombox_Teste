using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Prombox.Service.Utilities
{
    public class Crypt
    {
        #region [Constantes privadas ]
        
        private const string PEPPER = "45564f543d45564f4c55c7c34f265445434e4f4c4f474941212121";
        private const string FAKE_PEPER = "5355434b204d59204259544553";

        #endregion [Constantes privadas ]

        private static byte[] GenerateRandomCryptographicBytes(int keyLength)
        {
            RNGCryptoServiceProvider rngCryptoServiceProvider = new RNGCryptoServiceProvider();
            byte[] randomBytes = new byte[keyLength];
            rngCryptoServiceProvider.GetBytes(randomBytes);
            return randomBytes;
        }

        public static string GetPepper()
        {
            return FAKE_PEPER;
        }

        public static string CreateSalt(int saltLength)
        {
            byte[] saltBytes = GenerateRandomCryptographicBytes(saltLength);
            return Convert.ToBase64String(saltBytes);
        }
        /// <summary>
        /// Gerador de Salt padrão da Evot que cria um random de 64 caracteres
        /// </summary>
        public static string CreateSalt()
        {
            byte[] saltBytes = GenerateRandomCryptographicBytes(64);
            return Convert.ToBase64String(saltBytes);
        }

        /// <summary>
        /// Hash padrão da Evot que utiliza Sha512 na criptografia
        /// </summary>
        /// <param name="password"></param>
        /// <param name="salt"></param>
        /// <returns></returns>
        public static string HashWithSalt(string password, string salt)
        {
            return HashWithSalt(password, salt, PEPPER, SHA512.Create());
        }

        /// <summary>
        /// Hash Padrão da Evot que utiliza Sha512 na criptografia
        /// </summary>
        /// <param name="password"></param>
        /// <param name="salt"></param>
        /// <returns></returns>
        public static string HashWithSalt(string password, string salt, string pepper)
        {
            return HashWithSalt(password, salt, pepper, SHA512.Create());
        }


        public static string HashWithSalt(string password, string salt, HashAlgorithm hashAlgo)
        {
            return HashWithSalt(password, salt, PEPPER, hashAlgo);
        }

        public static string HashWithSalt(string password, string salt, string pepper, HashAlgorithm hashAlgo)
        {
            byte[] passwordAsBytes = Encoding.UTF8.GetBytes(password);
            byte[] saltBytes = Encoding.UTF8.GetBytes(salt);
            byte[] peperBytes = Encoding.UTF8.GetBytes(pepper);
            List<byte> passwordWithSaltBytes = new List<byte>();
            passwordWithSaltBytes.AddRange(saltBytes);
            passwordWithSaltBytes.AddRange(passwordAsBytes);
            passwordWithSaltBytes.AddRange(peperBytes);
            byte[] passwordDigestBytes = hashAlgo.ComputeHash(passwordWithSaltBytes.ToArray());
            return Convert.ToBase64String(passwordDigestBytes);
        }

    }
}
