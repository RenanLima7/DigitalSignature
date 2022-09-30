using System.Security.Cryptography;
using System.Text;

namespace DigitalSignatureAPI.Security
{
    public class RSAAlgorithm
    {
        private static readonly UnicodeEncoding ByteConverter = new UnicodeEncoding();
        private static readonly RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();

        public static byte[] RSAEncrypt(string plainText)
        {
            try
            {
                byte[] dataToEncrypt = ByteConverter.GetBytes(plainText);
                byte[] encryptedData;

                encryptedData = RSA.Encrypt(dataToEncrypt, false);

                return encryptedData;
            }
            catch (CryptographicException e)
            {
                return ByteConverter.GetBytes("Encryption failed: " + e.Message);
            }
        }

        public static byte[] RSADecrypt(byte[] encryptedText)
        {
            try
            {
                byte[] decryptedData;
                decryptedData = RSA.Decrypt(encryptedText, false);

                return decryptedData;
            }
            catch (CryptographicException e)
            {
                return ByteConverter.GetBytes("Decryption failed: " + e.Message);
            }
        }
    }
}
