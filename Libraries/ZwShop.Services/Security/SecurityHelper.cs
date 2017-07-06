using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using ZwShop.Services.Configuration.Settings;
using ZwShop.Services.Infrastructure;
using ZwShop.Services.Orders;
using ZwShop.Common;

namespace ZwShop.Services.Security
{
    /// <summary>
    /// Represents a security helper
    /// </summary>
    public partial class SecurityHelper
    {
        #region Utilities

        private static byte[] EncryptTextToMemory(string data, byte[] key, byte[] iv)
        {
            var mStream = new MemoryStream();
            var cStream = new CryptoStream(mStream, new TripleDESCryptoServiceProvider().CreateEncryptor(key, iv), CryptoStreamMode.Write);
            byte[] toEncrypt = new UnicodeEncoding().GetBytes(data);
            cStream.Write(toEncrypt, 0, toEncrypt.Length);
            cStream.FlushFinalBlock();
            byte[] ret = mStream.ToArray();
            cStream.Close();
            mStream.Close();
            return ret;
        }

        private static string DecryptTextFromMemory(byte[] data, byte[] key, byte[] iv)
        {
            var msDecrypt = new MemoryStream(data);
            var csDecrypt = new CryptoStream(msDecrypt, new TripleDESCryptoServiceProvider().CreateDecryptor(key, iv), CryptoStreamMode.Read);
            var sReader = new StreamReader(csDecrypt, new UnicodeEncoding());
            return sReader.ReadLine();
        }

        #endregion

        #region Methods
        /// <summary>
        /// Decrypts text
        /// </summary>
        /// <param name="cipherText">Cipher text</param>
        /// <returns>Decrypted string</returns>
        public static string Decrypt(string cipherText)
        {
            string encryptionPrivateKey = IoC.Resolve<ISettingManager>().GetSettingValue("Security.EncryptionPrivateKey");
            return Decrypt(cipherText, encryptionPrivateKey);
        }

        /// <summary>
        /// Decrypts text
        /// </summary>
        /// <param name="cipherText">Cipher text</param>
        /// <param name="encryptionPrivateKey">Encryption private key</param>
        /// <returns>Decrypted string</returns>
        protected static string Decrypt(string cipherText, string encryptionPrivateKey)
        {
            if (String.IsNullOrEmpty(cipherText))
                return cipherText;

            var tDESalg = new TripleDESCryptoServiceProvider();
            tDESalg.Key = new ASCIIEncoding().GetBytes(encryptionPrivateKey.Substring(0, 16));
            tDESalg.IV = new ASCIIEncoding().GetBytes(encryptionPrivateKey.Substring(8, 8));

            byte[] buffer = Convert.FromBase64String(cipherText);
            string result = DecryptTextFromMemory(buffer, tDESalg.Key, tDESalg.IV);
            return result;
        }

        /// <summary>
        /// Encrypts text
        /// </summary>
        /// <param name="plainText">Plaint text</param>
        /// <returns>Encrypted string</returns>
        public static string Encrypt(string plainText)
        {
            string encryptionPrivateKey = IoC.Resolve<ISettingManager>().GetSettingValue("Security.EncryptionPrivateKey");
            return Encrypt(plainText, encryptionPrivateKey);
        }

        /// <summary>
        /// Encrypts text
        /// </summary>
        /// <param name="plainText">Plaint text</param>
        /// <param name="encryptionPrivateKey">Encryption private key</param>
        /// <returns>Encrypted string</returns>
        protected static string Encrypt(string plainText, string encryptionPrivateKey)
        {
            if (String.IsNullOrEmpty(plainText))
                return plainText;

            var tDESalg = new TripleDESCryptoServiceProvider();
            tDESalg.Key = new ASCIIEncoding().GetBytes(encryptionPrivateKey.Substring(0, 16));
            tDESalg.IV = new ASCIIEncoding().GetBytes(encryptionPrivateKey.Substring(8, 8));

            byte[] encryptedBinary = EncryptTextToMemory(plainText, tDESalg.Key, tDESalg.IV);
            string result = Convert.ToBase64String(encryptedBinary);
            return result;
        }

        /// <summary>
        /// Change encryption private key
        /// </summary>
        /// <param name="newEncryptionPrivateKey">New encryption private key</param>
        public static void ChangeEncryptionPrivateKey(string newEncryptionPrivateKey)
        {
            if (String.IsNullOrEmpty(newEncryptionPrivateKey) || newEncryptionPrivateKey.Length != 16)
                throw new ShopException("Encryption private key must be 16 characters long");

            string oldEncryptionPrivateKey = IoC.Resolve<ISettingManager>().GetSettingValue("Security.EncryptionPrivateKey");

            if (oldEncryptionPrivateKey == newEncryptionPrivateKey)
                return;

            var orders = IoC.Resolve<IOrderService>().LoadAllOrders();
            //uncomment this line to support transactions
            //using (var scope = new System.Transactions.TransactionScope())
            {
                foreach (var order in orders)
                {
                    string decryptedCardType = Decrypt(order.CardType, oldEncryptionPrivateKey);
                    string decryptedCardName = Decrypt(order.CardName, oldEncryptionPrivateKey);
                    string decryptedCardNumber = Decrypt(order.CardNumber, oldEncryptionPrivateKey);
                    string decryptedMaskedCreditCardNumber = Decrypt(order.MaskedCreditCardNumber, oldEncryptionPrivateKey);
                    string decryptedCardCvv2 = Decrypt(order.CardCvv2, oldEncryptionPrivateKey);
                    string decryptedCardExpirationMonth = Decrypt(order.CardExpirationMonth, oldEncryptionPrivateKey);
                    string decryptedCardExpirationYear = Decrypt(order.CardExpirationYear, oldEncryptionPrivateKey);

                    string encryptedCardType = Encrypt(decryptedCardType, newEncryptionPrivateKey);
                    string encryptedCardName = Encrypt(decryptedCardName, newEncryptionPrivateKey);
                    string encryptedCardNumber = Encrypt(decryptedCardNumber, newEncryptionPrivateKey);
                    string encryptedMaskedCreditCardNumber = Encrypt(decryptedMaskedCreditCardNumber, newEncryptionPrivateKey);
                    string encryptedCardCvv2 = Encrypt(decryptedCardCvv2, newEncryptionPrivateKey);
                    string encryptedCardExpirationMonth = Encrypt(decryptedCardExpirationMonth, newEncryptionPrivateKey);
                    string encryptedCardExpirationYear = Encrypt(decryptedCardExpirationYear, newEncryptionPrivateKey);

                    order.CardType = encryptedCardType;
                    order.CardName = encryptedCardName;
                    order.CardNumber = encryptedCardNumber;
                    order.MaskedCreditCardNumber = encryptedMaskedCreditCardNumber;
                    order.CardCvv2 = encryptedCardCvv2;
                    order.CardExpirationMonth = encryptedCardExpirationMonth;
                    order.CardExpirationYear = encryptedCardExpirationYear;
                    IoC.Resolve<IOrderService>().UpdateOrder(order);
                }

                IoC.Resolve<ISettingManager>().SetParam("Security.EncryptionPrivateKey", newEncryptionPrivateKey);

                //uncomment this line to support transactions
                //scope.Complete();
            }

        }

        #endregion
    }
}
