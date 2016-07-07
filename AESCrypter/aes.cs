using System;
using System.Globalization;
using System.IO;
using System.Security.Cryptography;
using System.Text;



namespace Crypt
{
    public static class AES
    {
        public static string GenerateKey(int keySize)
        {
            RijndaelManaged aesEncryption = new RijndaelManaged();
            aesEncryption.KeySize = keySize;
            aesEncryption.BlockSize = 128;
            aesEncryption.Mode = CipherMode.CBC;
            aesEncryption.Padding = PaddingMode.PKCS7;
            aesEncryption.GenerateIV();
            string ivStr = Convert.ToBase64String(aesEncryption.IV);
            aesEncryption.GenerateKey();
            string keyStr = Convert.ToBase64String(aesEncryption.Key);

            //Console.WriteLine("Using key '{0}'", keyStr, ivStr);           
            //Console.WriteLine("Using iv '{0}'", ivStr);           
            string completeKey = ivStr + "," + keyStr;

            return Convert.ToBase64String(ASCIIEncoding.UTF8.GetBytes(completeKey));
        }

        public  static string Encrypt(string plainStr, string completeEncodedKey, int keySize)
        {
            RijndaelManaged aesEncryption = new RijndaelManaged();
            aesEncryption.KeySize = keySize;
            aesEncryption.BlockSize = 128;
            aesEncryption.Mode = CipherMode.CBC;
            aesEncryption.Padding = PaddingMode.PKCS7;
            aesEncryption.IV = Convert.FromBase64String(ASCIIEncoding.UTF8.GetString(Convert.FromBase64String(completeEncodedKey)).Split(',')[0]);
            aesEncryption.Key = Convert.FromBase64String(ASCIIEncoding.UTF8.GetString(Convert.FromBase64String(completeEncodedKey)).Split(',')[1]);
            byte[] plainText = ASCIIEncoding.UTF8.GetBytes(plainStr);
            ICryptoTransform crypto = aesEncryption.CreateEncryptor();
            // The result of the encryption and decryption           
            byte[] cipherText = crypto.TransformFinalBlock(plainText, 0, plainText.Length);
            return Convert.ToBase64String(cipherText);
        }

        public static string Decrypt(string encryptedText, string completeEncodedKey, int keySize)
        {
            RijndaelManaged aesEncryption = new RijndaelManaged();
            aesEncryption.KeySize = keySize;
            aesEncryption.BlockSize = 128;
            aesEncryption.Mode = CipherMode.CBC;
            aesEncryption.Padding = PaddingMode.PKCS7;
            aesEncryption.IV = Convert.FromBase64String(ASCIIEncoding.UTF8.GetString(Convert.FromBase64String(completeEncodedKey)).Split(',')[0]);
            aesEncryption.Key = Convert.FromBase64String(ASCIIEncoding.UTF8.GetString(Convert.FromBase64String(completeEncodedKey)).Split(',')[1]);
            ICryptoTransform decrypto = aesEncryption.CreateDecryptor();
            byte[] encryptedBytes = Convert.FromBase64CharArray(encryptedText.ToCharArray(), 0, encryptedText.Length);
            return ASCIIEncoding.UTF8.GetString(decrypto.TransformFinalBlock(encryptedBytes, 0, encryptedBytes.Length));
        }
    }
}

/*
namespace previon.security
{
    public interface ICryptoService
    {

        /// <summary>
        /// Verschlüsselt (AES) einen String mittels <paramref name="key"/> und
        /// <paramref name="iv"/>.
        /// Liefert die Verschlüsselten Daten als Hex String.
        /// </summary>
        /// <param name="data">Die zu verschlüsselnden Daten.</param>
        /// <param name="key">Der Schlüssel.</param>
        /// <param name="iv">Der Initialvektor.</param>
        /// <returns>Verschlüsselte Daten als Hex String.</returns>
        string Encypt(string data, string key, string iv);

        /// <summary>
        /// Entschlüsselt (AES) als Hex String vorliegende Daten mittels <paramref name="key"/> und
        /// <paramref name="iv"/>.
        /// </summary>
        /// <param name="data">Verschlüsselte Daten als Hex String.</param>
        /// <param name="key">Der Schlüssel.</param>
        /// <param name="iv">Der Initialvektor.</param>
        /// <returns>Entschlüsselte Daten.</returns>
        string Decrypt(string data, string key, string iv);

    }
    

    public class CryptoService : ICryptoService
    {

        /// <summary>
        /// Verschlüsselt (AES) einen String mittels <paramref name="key"/> und
        /// <paramref name="iv"/>.
        /// Liefert die Verschlüsselten Daten als Hex String.
        /// </summary>
        /// <param name="data">Die zu verschlüsselnden Daten.</param>
        /// <param name="key">Der Schlüssel.</param>
        /// <param name="iv">Der Initialvektor.</param>
        /// <returns>Verschlüsselte Daten als Hex String.</returns>
        public string Encypt(string data, string key, string iv)
        {
            if (data == null)
                throw new ArgumentNullException("data");
            if (string.IsNullOrEmpty(key))
                throw new ArgumentException("key darf weder null noch empty sein.", "key");
            if (string.IsNullOrEmpty(iv))
                throw new ArgumentException("iv darf weder null noch empty sein.", "iv");

            string encryptedData = null;

            SymmetricAlgorithm algorithm = null;
            ICryptoTransform encryptor = null;
            MemoryStream encryptedDataStream = null;
            CryptoStream cryptoStream = null;

            try
            {

                //Algorithmus holen und Encryptor erstellen
                algorithm = new RijndaelManaged
                {
                    KeySize = key.Length * 8,
                    BlockSize = iv.Length * 8,
                    Key = Encoding.ASCII.GetBytes(key),
                    IV = Encoding.ASCII.GetBytes(iv),
                    Mode = CipherMode.CBC,
                    Padding = PaddingMode.PKCS7
                };
                encryptor = algorithm.CreateEncryptor(algorithm.Key,
                    algorithm.IV);

                //Streams und Writer erstellen
                encryptedDataStream = new MemoryStream();
                cryptoStream = new CryptoStream(encryptedDataStream, encryptor,
                    CryptoStreamMode.Write);

                //Daten direkt über Encoding in Utf8 Transformieren da der StreamWriter die 
                //Utf8 Präambel den Daten voranstellt
                var utf8Data = Encoding.UTF8.GetBytes(data);
                cryptoStream.Write(utf8Data, 0, utf8Data.Length);
                cryptoStream.Flush();
                cryptoStream.FlushFinalBlock();

                //Verschlüsselte Daten codieren
                var encryptedDataBuffer = encryptedDataStream.ToArray();
                encryptedData = this.Encode(encryptedDataBuffer);
            }
            finally
            {
                if (cryptoStream != null)
                    cryptoStream.Dispose();
                if (encryptedDataStream != null)
                    encryptedDataStream.Dispose();
                if (encryptor != null)
                    encryptor.Dispose();
                if (algorithm != null)
                    algorithm.Clear();
            }

            return encryptedData;
        }

        /// <summary>
        /// Entschlüsselt (AES) als Hex String vorliegende Daten mittels <paramref name="key"/> und
        /// <paramref name="iv"/>.
        /// </summary>
        /// <param name="data">Verschlüsselte Daten als Hex String.</param>
        /// <param name="key">Der Schlüssel.</param>
        /// <param name="iv">Der Initialvektor.</param>
        /// <returns>Entschlüsselte Daten.</returns>
        public string Decrypt(string data, string key, string iv)
        {

            if (string.IsNullOrEmpty(data))
                throw new ArgumentException("Das Argument data darf weder null noch empty sein.",
                    "data");

            //Daten decodieren
            var decodedData = this.Decode(data);
            if (decodedData == null)
                throw new ArgumentException("Das Argument data enthält ungültige Daten.",
                    "data");

            string decryptedData = null;

            SymmetricAlgorithm algorithm = null;
            ICryptoTransform decryptor = null;
            MemoryStream encryptedDataStream = null;
            CryptoStream cryptoStream = null;
            StreamReader cryptoStreamReader = null;

            try
            {

                //Algorithmus und Decryptor erstellen
                algorithm = new RijndaelManaged
                {
                    KeySize = key.Length * 8,
                    BlockSize = iv.Length * 8,
                    Key = Encoding.ASCII.GetBytes(key),
                    IV = Encoding.ASCII.GetBytes(iv),
                    Mode = CipherMode.CBC,
                    Padding = PaddingMode.PKCS7
                };

                decryptor = algorithm.CreateDecryptor(algorithm.Key,
                    algorithm.IV);

                //Verschlüsselte Daten in MemoryStream schreiben
                encryptedDataStream = new MemoryStream(decodedData);

                //Crypto Stream erstellen
                cryptoStream = new CryptoStream(encryptedDataStream, decryptor,
                    CryptoStreamMode.Read);
                cryptoStreamReader = new StreamReader(cryptoStream, Encoding.UTF8);

                //Daten entschlüsseln
                decryptedData = cryptoStreamReader.ReadToEnd();

            }
            finally
            {
                if (cryptoStreamReader != null)
                    cryptoStreamReader.Dispose();
                if (cryptoStream != null)
                    cryptoStream.Dispose();
                if (encryptedDataStream != null)
                    encryptedDataStream.Dispose();
                if (decryptor != null)
                    decryptor.Dispose();
                if (algorithm != null)
                    algorithm.Clear();
            }

            return decryptedData;
        }

        /// <summary>
        /// Encodiert Binärdaten in einen Hex String.
        /// </summary>
        /// <param name="data">Die Daten.</param>
        /// <returns>Hex String der Daten.</returns>
        private string Encode(byte[] data)
        {
            var encodeWriter = new StringWriter();

            for (int i = 0; i < data.Length; i++)
            {
                encodeWriter.Write("{0:x2}", data[i]);
            }

            return encodeWriter.ToString();
        }

        /// <summary>
        /// Decodiert einen Hex String in Binärdaten.
        /// </summary>
        /// <param name="data">Hex String der Daten.</param>
        /// <returns>Daten Binär.</returns>
        private byte[] Decode(string data)
        {
            var byteCount = data.Length / 2;

            var decodedData = new byte[byteCount];

            for (int i = 0; i < byteCount; i++)
            {
                var startIndex = i * 2;
                decodedData[i] = byte.Parse(data.Substring(startIndex, 2), NumberStyles.HexNumber);
            }

            return decodedData;
        }
    }
}

*/